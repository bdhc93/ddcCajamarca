using System;
using System.Collections.Generic;
using System.Linq;
using ddcCajamarca.Repository.Directorio.Interfaces;
using ddcCajamarca.Services.Directorio.Interfaces;
using ddcCajamarca.Models;

namespace ddcCajamarca.Services.Directorio.Datos
{
    public class OcupacionCulturalService : IOcupacionCulturalService
    {
        public IOcupacionCulturalRepository ocupacionCulturalRepository { get; set; }

        public OcupacionCulturalService(IOcupacionCulturalRepository ocupacionCulturalRepository)
        {
            this.ocupacionCulturalRepository = ocupacionCulturalRepository;
        }

        public void EliminarOcupacionCultural(int id)
        {
            ocupacionCulturalRepository.EliminarOcupacionCultural(id);
        }

        public void GuardarOcupacionCultural(OcupacionCultural ocupacionCultural)
        {
            ocupacionCulturalRepository.GuardarOcupacionCultural(ocupacionCultural);
        }

        public void ModificarOcupacionCultural(OcupacionCultural ocupacionCultural)
        {
            ocupacionCulturalRepository.ModificarOcupacionCultural(ocupacionCultural);
        }

        public OcupacionCultural ObtenerComercialPorId(int id)
        {
            return ocupacionCulturalRepository.ObtenerComercialPorId(id);
        }

        public IEnumerable<OcupacionCultural> ObtenerOcupacionCulturalPorCriterio(string criterio, bool completo)
        {
            return ocupacionCulturalRepository.ObtenerOcupacionCulturalPorCriterio(criterio, completo);
        }
    }
}
