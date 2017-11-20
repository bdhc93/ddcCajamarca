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

            Context.Activos.Remove(elim);
            Context.SaveChanges();
        }

        public void GuardarActivo(Activo activo)
        {
            Context.Activos.Add(activo);
            Context.SaveChanges();
        }

        public void ModificarActivo(Activo activo)
        {
            Context.Entry(activo).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public IEnumerable<Activo> ObtenerActivoPorCriterio(string criterio)
        {
            if (!String.IsNullOrEmpty(criterio))
            {
                return Context.Activos.Where(p => p.Nombre.ToUpper().Contains(criterio.ToUpper())).OrderBy(p => p.Nombre).ToList();
            }
            return Context.Activos.OrderBy(p => p.Nombre).ToList();
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
                           where p.EventoEnsayo.FechaInicio <= fechaini && p.EventoEnsayo.FechaFin >= fechafin
                           select p;

            return query.ToList();
        }
    }
}
