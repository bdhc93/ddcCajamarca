﻿using System;
using System.Collections.Generic;
using ddcCajamarca.Models;

namespace ddcCajamarca.Services.ActividadesCulturales.Interfaces
{
    public interface IEventoEnsayoService
    {
        EventoEnsayo ObtenerEventoEnsayoPorId(Int32 id);
        IEnumerable<EventoEnsayo> ObtenerEventoEnsayoPorCriterio(String criterio);
        IEnumerable<DetalleHorasEvento> ObtenerDetalleHorasEventoPorCriterio(Int32 criterio, Boolean evento);
        IEnumerable<DetalleHorasEvento> ObtenerDetalleHorasEventoPorFecha(DateTime fechaini, DateTime fechafin, String criterio);
        DetalleHorasEvento ObtenerDetalleHorasEventoPorIdEvento(Int32 Id);
        IEnumerable<EventoEnsayo> ObtenerEventoEnsayoPorCriterioYFechas(String criterio, DateTime fechaIni, DateTime FechaFin);
        IEnumerable<EventoEnsayo> ObtenerEventoEnsayoPorIdAmbiente(Int32 idAmbiente);

        void GuardarEventoEnsayo(EventoEnsayo eventoEnsayo);
        void ModificarEventoEnsayo(EventoEnsayo eventoEnsayo);
        void EliminarEventoEnsayo(Int32 id);
        void EliminarDetalleEventoEnsayo(Int32 id);
    }
}
