using System;
using System.Collections.Generic;
using System.Linq;
using ddcCajamarca.Repository.ActividadesCulturales.Interfaces;
using ddcCajamarca.Services.ActividadesCulturales.Interfaces;
using ddcCajamarca.Models;

namespace ddcCajamarca.Services.ActividadesCulturales.Datos
{
    public class ActivoService : IActivoService
    {
        public IActivoRepository activoRepository { get; set; }

        public ActivoService(IActivoRepository activoRepository)
        {
            this.activoRepository = activoRepository;
        }

        public void EliminarActivo(int id)
        {
            activoRepository.EliminarActivo(id);
        }

        public void GuardarActivo(Activo activo)
        {
            activoRepository.GuardarActivo(activo);
        }

        public void ModificarActivo(Activo activo)
        {
            activoRepository.ModificarActivo(activo);
        }

        public IEnumerable<Activo> ObtenerActivoPorCriterio(string criterio)
        {
            return activoRepository.ObtenerActivoPorCriterio(criterio);
        }

        public Activo ObtenerActivoPorId(int id)
        {
            return activoRepository.ObtenerActivoPorId(id);
        }
    }
}
