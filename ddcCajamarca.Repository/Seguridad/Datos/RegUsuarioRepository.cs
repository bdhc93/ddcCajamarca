using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ddcCajamarca.Repository.Seguridad.Interfaces;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Seguridad.Datos
{
    class RegUsuarioRepository : MasterRepository, IRegUsuarioRepository
    {
        public void GuardarRegUsuario(RegUsuario movimiento)
        {
            Context.RegUsuarios.Add(movimiento);
            Context.SaveChanges();
        }

        public IEnumerable<RegUsuario> ObtenerRegUsuario(string usuario)
        {
            if (!String.IsNullOrEmpty(usuario))
            {
                return Context.RegUsuarios.OrderByDescending(p => p.Fecha).Where(p => p.Usuario.Equals(usuario));
            }
            else
            {
                return Context.RegUsuarios.OrderByDescending(p => p.Fecha);
            }
        }
    }
}
