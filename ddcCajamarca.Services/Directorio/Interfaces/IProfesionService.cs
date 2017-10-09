using System;
using System.Collections.Generic;
using ddcCajamarca.Models;

namespace ddcCajamarca.Services.Directorio.Interfaces
{
    public interface IProfesionService
    {
        Profesion ObtenerProfesionPorId(Int32 id);
        IEnumerable<Profesion> ObtenerProfesionPorCriterio(String criterio, Boolean completo);

        void GuardarProfesion(Profesion profesion);
        void ModificarProfesion(Profesion profesion);
        void EliminarProfesion(Int32 id);
    }
}
