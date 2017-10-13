using System;
using System.Collections.Generic;
using System.Linq;
using ddcCajamarca.Repository.ActividadesCulturales.Interfaces;
using ddcCajamarca.Services.ActividadesCulturales.Interfaces;
using ddcCajamarca.Models;

namespace ddcCajamarca.Services.ActividadesCulturales.Datos
{
    public class AmbienteService : IAmbienteService
    {
        public IAmbienteRepository ambienteRepository { get; set; }

        public AmbienteService(IAmbienteRepository ambienteRepository)
        {
            this.ambienteRepository = ambienteRepository;
        }

        public void EliminarAmbiente(int id)
        {
            ambienteRepository.EliminarAmbiente(id);
        }

        public void GuardarAmbiente(Ambiente ambiente)
        {
            ambienteRepository.GuardarAmbiente(ambiente);
        }

        public void ModificarAmbiente(Ambiente ambiente)
        {
            ambienteRepository.ModificarAmbiente(ambiente);
        }

        public IEnumerable<Ambiente> ObtenerAmbientePorCriterio(string criterio)
        {
            return ambienteRepository.ObtenerAmbientePorCriterio(criterio);
        }

        public Ambiente ObtenerAmbientePorId(int id)
        {
            return ambienteRepository.ObtenerAmbientePorId(id);
        }
    }
}
