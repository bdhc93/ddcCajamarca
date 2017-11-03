using System;
using System.Collections.Generic;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.ActividadesCulturales.Interfaces
{
    public interface IEventoEnsayoRepository
    {
        EventoEnsayo ObtenerEventoEnsayoPorId(Int32 id);
        IEnumerable<EventoEnsayo> ObtenerEventoEnsayoPorCriterio(String criterio);
        IEnumerable<DetalleHorasEvento> ObtenerDetalleHorasEventoPorCriterio(Int32 criterio, Boolean evento);
        DetalleHorasEvento ObtenerDetalleHorasEventoPorIdEvento(Int32 Id);
        IEnumerable<EventoEnsayo> ObtenerEventoEnsayoPorCriterioYFechas(String criterio, DateTime fechaIni, DateTime FechaFin);
        IEnumerable<EventoEnsayo> ObtenerEventoEnsayoPorIdAmbiente(Int32 idAmbiente);

        void GuardarEventoEnsayo(EventoEnsayo eventoEnsayo);
        void ModificarEventoEnsayo(EventoEnsayo eventoEnsayo);
        void EliminarEventoEnsayo(Int32 id);
    }
}
