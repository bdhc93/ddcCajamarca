using System;
using System.Collections.Generic;
using ddcCajamarca.Models;

namespace ddcCajamarca.Services.Directorio.Interfaces
{
    public interface IOrganizacionService
    {
        Organizacion ObtenerOrganizacionPorId(Int32 id);
        IEnumerable<Organizacion> ObtenerOrganizacionPorCriterio(String criterio, Boolean completo);

        void GuardarOrganizacion(Organizacion organizacion);
        void ModificarOrganizacion(Organizacion organizacion);
        void EliminarOrganizacion(Int32 id);
    }
}
