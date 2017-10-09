using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ddcCajamarca.Repository.Directorio.Interfaces;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Directorio.Datos
{
    public class ProfesionRepository : MasterRepository, IProfesionRepository
    {
        public void EliminarProfesion(int id)
        {
            var elim = ObtenerProfesionPorId(id);

            Context.Profesiones.Remove(elim);
            Context.SaveChanges();
        }

        public void GuardarProfesion(Profesion profesion)
        {
            Context.Profesiones.Add(profesion);
            Context.SaveChanges();
        }

        public void ModificarProfesion(Profesion profesion)
        {
            Context.Entry(profesion).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public IEnumerable<Profesion> ObtenerProfesionPorCriterio(string criterio, bool completo)
        {
            if (completo)
            {
                if (!String.IsNullOrEmpty(criterio))
                {
                    return Context.Profesiones.Where(p => p.Nombre.ToUpper().Contains(criterio.ToUpper())).OrderBy(p => p.Nombre).ToList();
                }
                return Context.Profesiones.OrderBy(p => p.Nombre).ToList();
            }
            else
            {
                if (!String.IsNullOrEmpty(criterio))
                {
                    return Context.Profesiones.Where(p => p.Nombre.ToUpper().Contains(criterio.ToUpper())
                    && p.Nombre.ToUpper() != "DESCONOCIDA").OrderBy(p => p.Nombre).ToList();
                }
                return Context.Profesiones.Where(p => p.Nombre.ToUpper() != "DESCONOCIDA").OrderBy(p => p.Nombre).ToList();
            }
            
        }

        public Profesion ObtenerProfesionPorId(int id)
        {
            return Context.Profesiones.Find(id);
        }
    }
}
