using System;
using System.Collections.Generic;
using System.Linq;
using ddcCajamarca.Repository.Directorio.Interfaces;
using ddcCajamarca.Services.Directorio.Interfaces;
using ddcCajamarca.Models;

namespace ddcCajamarca.Services.Directorio.Datos
{
    public class PersonaService : IPersonaService
    {
        public IPersonaRepository personaRepository { get; set; }

        public PersonaService(IPersonaRepository personaRepository)
        {
            this.personaRepository = personaRepository;
        }

        public void EliminarPersona(int id)
        {
            personaRepository.EliminarPersona(id);
        }

        public void GuardarPersona(Persona persona)
        {
            personaRepository.GuardarPersona(persona);
        }

        public void ModificarPersona(Persona persona)
        {
            personaRepository.ModificarPersona(persona);
        }

        public IEnumerable<Persona> ObtenerPersonaPorCriterio(string criterio)
        {
            return personaRepository.ObtenerPersonaPorCriterio(criterio);
        }

        public IEnumerable<Persona> ObtenerPersonaPorFechaNacimiento()
        {
            return personaRepository.ObtenerPersonaPorFechaNacimiento();
        }

        public IEnumerable<Persona> ObtenerPersonaPorFiltro(string criterio, int IdOrganizacion, int IdProfesion, int IdOcupacion)
        {
            return personaRepository.ObtenerPersonaPorFiltro(criterio, IdOrganizacion, IdProfesion, IdOcupacion);
        }

        public Persona ObtenerPersonaPorId(int id)
        {
            return personaRepository.ObtenerPersonaPorId(id);
        }
    }
}
