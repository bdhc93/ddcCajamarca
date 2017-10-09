using System;
using System.Collections.Generic;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Directorio.Interfaces
{
    public interface IPersonaRepository
    {
        Persona ObtenerPersonaPorId(Int32 id);
        IEnumerable<Persona> ObtenerPersonaPorCriterio(String criterio);
        IEnumerable<Persona> ObtenerPersonaPorFechaNacimiento();
        IEnumerable<Persona> ObtenerPersonaPorFiltro(String criterio, Int32 IdOrganizacion, Int32 IdProfesion, Int32 IdOcupacion);

        void GuardarPersona(Persona persona);
        void ModificarPersona(Persona persona);
        void EliminarPersona(Int32 id);
    }
}
