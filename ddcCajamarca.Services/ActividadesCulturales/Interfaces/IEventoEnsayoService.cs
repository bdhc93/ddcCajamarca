using System;
using System.Collections.Generic;
using ddcCajamarca.Models;

namespace ddcCajamarca.Services.ActividadesCulturales.Interfaces
{
    public interface IEventoEnsayoService
    {
        EventoEnsayo ObtenerEventoEnsayoPorId(Int32 id);
        IEnumerable<EventoEnsayo> ObtenerAmbientePorCriterio(String criterio);
        IEnumerable<EventoEnsayo> ObtenerAmbientePorCriterioYFechas(String criterio, DateTime fechaIni, DateTime FechaFin);
        IEnumerable<EventoEnsayo> ObtenerAmbientePorIdAmbiente(Int32 idAmbiente);

        void GuardarEventoEnsayo(EventoEnsayo eventoEnsayo);
        void ModificarEventoEnsayo(EventoEnsayo eventoEnsayo);
        void EliminarEventoEnsayo(Int32 id);
    }
}
