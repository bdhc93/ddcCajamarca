using System;
using System.Collections.Generic;
using ddcCajamarca.Models;

namespace ddcCajamarca.Services.Directorio.Interfaces
{
    public interface IOcupacionCulturalService
    {
        OcupacionCultural ObtenerComercialPorId(Int32 id);
        IEnumerable<OcupacionCultural> ObtenerOcupacionCulturalPorCriterio(String criterio, Boolean completo);

        void GuardarOcupacionCultural(OcupacionCultural ocupacionCultural);
        void ModificarOcupacionCultural(OcupacionCultural ocupacionCultural);
        void EliminarOcupacionCultural(Int32 id);
    }
}
