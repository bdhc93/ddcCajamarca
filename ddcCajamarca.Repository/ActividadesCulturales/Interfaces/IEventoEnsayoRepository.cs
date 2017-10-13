using System;
using System.Collections.Generic;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.ActividadesCulturales.Interfaces
{
    public interface IEventoEnsayoRepository
    {
        EventoEnsayo ObtenerEventoEnsayoPorId(Int32 id);
        IEnumerable<EventoEnsayo> ObtenerAmbientePorCriterioYFechas(String criterio, DateTime fechaIni, DateTime FechaFin);

        void GuardarEventoEnsayo(EventoEnsayo eventoEnsayo);
        void ModificarEventoEnsayo(EventoEnsayo eventoEnsayo);
        void EliminarEventoEnsayo(Int32 id);
    }
}
