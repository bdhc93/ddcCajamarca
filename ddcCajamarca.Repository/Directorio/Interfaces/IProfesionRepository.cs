using System;
using System.Collections.Generic;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Directorio.Interfaces
{
    public interface IProfesionRepository
    {
        Profesion ObtenerProfesionPorId(Int32 id);
        IEnumerable<Profesion> ObtenerProfesionPorCriterio(String criterio, Boolean completo);

        void GuardarProfesion(Profesion profesion);
        void ModificarProfesion(Profesion profesion);
        void EliminarProfesion(Int32 id);
    }
}
