using System;
using System.Collections.Generic;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.ActividadesCulturales.Interfaces
{
    public interface IAmbienteRepository
    {
        Ambiente ObtenerAmbientePorId(Int32 id);
        IEnumerable<Ambiente> ObtenerAmbientePorCriterio(String criterio);

        void GuardarAmbiente(Ambiente ambiente);
        void ModificarAmbiente(Ambiente ambiente);
        void EliminarAmbiente(Int32 id);
    }
}
