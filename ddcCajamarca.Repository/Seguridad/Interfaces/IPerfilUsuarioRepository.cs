using System;
using System.Collections.Generic;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Seguridad.Interfaces
{
    public interface IPerfilUsuarioRepository
    {
        PerfilUsuario ObtenerPerfilUsuarioPorId(Int32 id);
        PerfilUsuario ObtenerPerfilUsuarioPorNombre(String usuario);

        IEnumerable<PerfilUsuario> ObtenerPerfilUsuarioPorCriterio(String criterio);

        void ModificarPerfilUsuario(PerfilUsuario perfilUsuario);
        void EliminarPerfilUsuario(Int32 id);
    }
}
