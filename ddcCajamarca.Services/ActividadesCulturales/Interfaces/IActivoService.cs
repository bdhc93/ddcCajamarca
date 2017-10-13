using System;
using System.Collections.Generic;
using ddcCajamarca.Models;

namespace ddcCajamarca.Services.ActividadesCulturales.Interfaces
{
    public interface IActivoService
    {
        Activo ObtenerActivoPorId(Int32 id);
        IEnumerable<Activo> ObtenerActivoPorCriterio(String criterio);

        void GuardarActivo(Activo activo);
        void ModificarActivo(Activo activo);
        void EliminarActivo(Int32 id);
    }
}
