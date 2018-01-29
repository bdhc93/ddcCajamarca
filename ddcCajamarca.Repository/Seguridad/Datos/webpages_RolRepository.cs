using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ddcCajamarca.Repository.Seguridad.Interfaces;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Seguridad.Datos
{
    public class webpages_RolRepository : MasterRepository, Iwebpages_RolRepository
    {
        public void EliminarRol(int id)
        {
            var elim = ObtenerRolPorId(id);

            Context.webpages_Roles.Remove(elim);
            Context.SaveChanges();
        }

        public void GuardarRol(webpages_Rol Rol)
        {
            Context.webpages_Roles.Add(Rol);
            Context.SaveChanges();
        }

        public void ModificarRol(webpages_Rol Rol)
        {
            Context.Entry(Rol).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public IEnumerable<webpages_Rol> ObtenerRolPorCriterio(string criterio)
        {
            var query = from p in Context.webpages_Roles
                        select p;

            if (!String.IsNullOrEmpty(criterio))
            {
                query = from p in query
                        where p.RoleName.ToUpper().Contains(criterio.ToUpper())
                        select p;
            }

            return query.OrderBy(p => p.RoleName).ToList();
        }

        public webpages_Rol ObtenerRolPorId(int id)
        {
            return Context.webpages_Roles.Find(id);
        }
    }
}
