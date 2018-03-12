using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ddcCajamarca.Repository.ActividadesCulturales.Interfaces;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.ActividadesCulturales.Datos
{
    public class ActivoRepository : MasterRepository, IActivoRepository
    {
        public void EliminarActivo(int id)
        {
            var elim = ObtenerActivoPorId(id);

            elim.Estado = false;
            Context.Entry(elim).State = EntityState.Modified;
            Context.SaveChanges();
            //Context.Activos.Remove(elim);
            //Context.SaveChanges();
        }

        public void GuardarActivo(Activo activo)
        {
            activo.Estado = true;
            Context.Activos.Add(activo);
            Context.SaveChanges();
        }

        public void ModificarActivo(Activo activo)
        {
            activo.Estado = true;
            Context.Entry(activo).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public IEnumerable<Activo> ObtenerActivoPorCriterio(string criterio)
        {
            if (!String.IsNullOrEmpty(criterio))
            {
                return Context.Activos.Where(p => p.Nombre.ToUpper().Contains(criterio.ToUpper()) && p.Estado == true).OrderBy(p => p.Nombre).ToList();
            }
            return Context.Activos.Where(p => p.Estado == true).OrderBy(p => p.Nombre).ToList();
        }

        public Activo ObtenerActivoPorId(int id)
        {
            return Context.Activos.Find(id);
        }

        public IEnumerable<Activo> ObtenerActivoSinUsoPorFechas(DateTime fechaini, DateTime fechafin)
        {
            var query = from p in Context.Activos
                        select p;
            
            var querydetalle = from p in Context.DetalleRequerimientos.Include("EventoEnsayo")
                               select p;

            querydetalle = from p in querydetalle
                           where p.EventoEnsayo.FechaInicio <= fechaini && p.EventoEnsayo.FechaFin >= fechafin && p.Estado == true
                           select p;

            return query.ToList();
        }
    }
}
