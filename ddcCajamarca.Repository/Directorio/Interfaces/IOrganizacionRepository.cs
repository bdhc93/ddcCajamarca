using System;
using System.Collections.Generic;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Directorio.Interfaces
{
    public interface IOrganizacionRepository
    {
        Organizacion ObtenerOrganizacionPorId(Int32 id);
        IEnumerable<Organizacion> ObtenerOrganizacionPorCriterio(String criterio, Boolean completo);

        void GuardarOrganizacion(Organizacion organizacion);
        void ModificarOrganizacion(Organizacion organizacion);
        void EliminarOrganizacion(Int32 id);
    }
}
