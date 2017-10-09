using System;
using System.Collections.Generic;
using System.Linq;
using ddcCajamarca.Repository.Directorio.Interfaces;
using ddcCajamarca.Services.Directorio.Interfaces;
using ddcCajamarca.Models;

namespace ddcCajamarca.Services.Directorio.Datos
{
    public class ProfesionService : IProfesionService
    {
        public IProfesionRepository profesionRepository { get; set; }

        public ProfesionService(IProfesionRepository profesionRepository)
        {
            this.profesionRepository = profesionRepository;
        }

        public void EliminarProfesion(int id)
        {
            profesionRepository.EliminarProfesion(id);
        }

        public void GuardarProfesion(Profesion profesion)
        {
            profesionRepository.GuardarProfesion(profesion);
        }

        public void ModificarProfesion(Profesion profesion)
        {
            profesionRepository.ModificarProfesion(profesion);
        }

        public IEnumerable<Profesion> ObtenerProfesionPorCriterio(string criterio, bool completo)
        {
            return profesionRepository.ObtenerProfesionPorCriterio(criterio, completo);
        }

        public Profesion ObtenerProfesionPorId(int id)
        {
            return profesionRepository.ObtenerProfesionPorId(id);
        }
    }
}
