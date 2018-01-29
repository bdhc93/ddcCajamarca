using System;
using System.Collections.Generic;
using System.Linq;
using ddcCajamarca.Repository.Seguridad.Interfaces;
using ddcCajamarca.Services.Seguridad.Interfaces;
using ddcCajamarca.Models;

namespace ddcCajamarca.Services.Seguridad.Datos
{
    public class PerfilUsuarioService : IPerfilUsuarioService
    {
        public IPerfilUsuarioRepository perfilUsuarioRepository { get; set; }

        public PerfilUsuarioService(IPerfilUsuarioRepository perfilUsuarioRepository)
        {
            this.perfilUsuarioRepository = perfilUsuarioRepository;
        }

        public PerfilUsuario ObtenerPerfilUsuarioPorNombre(string usuario)
        {
            return perfilUsuarioRepository.ObtenerPerfilUsuarioPorNombre(usuario);
        }

        public IEnumerable<PerfilUsuario> ObtenerPerfilUsuarioPorCriterio(string criterio)
        {
            return perfilUsuarioRepository.ObtenerPerfilUsuarioPorCriterio(criterio);
        }

        public void ModificarPerfilUsuario(PerfilUsuario perfilUsuario)
        {
            perfilUsuarioRepository.ModificarPerfilUsuario(perfilUsuario);
        }

        public void EliminarPerfilUsuario(int id)
        {
            throw new NotImplementedException();
        }
    }
}
