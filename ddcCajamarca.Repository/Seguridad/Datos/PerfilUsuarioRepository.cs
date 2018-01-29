using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ddcCajamarca.Repository.Seguridad.Interfaces;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Seguridad.Datos
{
    public class PerfilUsuarioRepository : MasterRepository, IPerfilUsuarioRepository
    {
        public void EliminarPerfilUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public void ModificarPerfilUsuario(PerfilUsuario perfilUsuario)
        {
            Context.Entry(perfilUsuario).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public IEnumerable<PerfilUsuario> ObtenerPerfilUsuarioPorCriterio(string criterio)
        {
            if (!String.IsNullOrEmpty(criterio))
            {
                return Context.PerfilUsuarios.Where(p => p.Usuario.ToUpper().Contains(criterio.ToUpper()) || p.NombreApellidos.ToUpper().Contains(criterio.ToUpper())).OrderBy(p => p.NombreApellidos).ToList();
            }
            return Context.PerfilUsuarios.OrderBy(p => p.NombreApellidos).ToList();
        }

        public PerfilUsuario ObtenerPerfilUsuarioPorNombre(string usuario)
        {
            var query = from p in Context.PerfilUsuarios.Include("webpages_UsersInRoles").Include("webpages_UsersInRoles.webpages_Roles")
                        select p;

            if (!String.IsNullOrEmpty(usuario))
            {
                query = from p in query
                        where p.Usuario.Equals(usuario)
                        select p;

                //foreach (var item in query)
                //{
                //    item.Imagen = ".." + item.Imagen;
                //}

                return query.SingleOrDefault();
            }
            else
            {
                return new PerfilUsuario { };
            }
        }
    }
}
