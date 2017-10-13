using System;
using System.Collections.Generic;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.ActividadesCulturales.Interfaces
{
    public interface IActivoRepository
    {
        Activo ObtenerActivoPorId(Int32 id);
        IEnumerable<Activo> ObtenerActivoPorCriterio(String criterio);

        void GuardarActivo(Activo activo);
        void ModificarActivo(Activo activo);
        void EliminarActivo(Int32 id);
    }
}
