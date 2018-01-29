using System;
using System.Collections.Generic;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Seguridad.Interfaces
{
    public interface Iwebpages_RolRepository
    {
        webpages_Rol ObtenerRolPorId(Int32 id);
        IEnumerable<webpages_Rol> ObtenerRolPorCriterio(String criterio);

        void GuardarRol(webpages_Rol Rol);
        void ModificarRol(webpages_Rol Rol);
        void EliminarRol(Int32 id);
    }
}
