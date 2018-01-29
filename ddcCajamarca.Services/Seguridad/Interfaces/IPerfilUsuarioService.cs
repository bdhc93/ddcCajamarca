using System;
using System.Collections.Generic;
using ddcCajamarca.Models;

namespace ddcCajamarca.Services.Seguridad.Interfaces
{
    public interface IPerfilUsuarioService
    {
        PerfilUsuario ObtenerPerfilUsuarioPorNombre(String usuario);
        IEnumerable<PerfilUsuario> ObtenerPerfilUsuarioPorCriterio(String criterio);
        
        void ModificarPerfilUsuario(PerfilUsuario perfilUsuario);
        void EliminarPerfilUsuario(Int32 id);
    }
}
