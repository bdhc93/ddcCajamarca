using System;
using System.Collections.Generic;
using System.Linq;
using ddcCajamarca.Repository.ActividadesCulturales.Interfaces;
using ddcCajamarca.Services.ActividadesCulturales.Interfaces;
using ddcCajamarca.Models;

namespace ddcCajamarca.Services.ActividadesCulturales.Datos
{
    public class EventoEnsayoService : IEventoEnsayoService
    {
        public IEventoEnsayoRepository eventoEnsayoRepository { get; set; }

        public EventoEnsayoService(IEventoEnsayoRepository eventoEnsayoRepository)
        {
            this.eventoEnsayoRepository = eventoEnsayoRepository;
        }
        
        public void EliminarEventoEnsayo(int id)
        {
            eventoEnsayoRepository.EliminarEventoEnsayo(id);
        }

        public void GuardarEventoEnsayo(EventoEnsayo eventoEnsayo)
        {
            eventoEnsayoRepository.GuardarEventoEnsayo(eventoEnsayo);
        }

        public void ModificarEventoEnsayo(EventoEnsayo eventoEnsayo)
        {
            eventoEnsayoRepository.ModificarEventoEnsayo(eventoEnsayo);
        }

        public IEnumerable<EventoEnsayo> ObtenerEventoEnsayoPorCriterioYFechas(string criterio, DateTime fechaIni, DateTime FechaFin)
        {
            return eventoEnsayoRepository.ObtenerEventoEnsayoPorCriterioYFechas(criterio, fechaIni, FechaFin);
        }

        public EventoEnsayo ObtenerEventoEnsayoPorId(int id)
        {
            return eventoEnsayoRepository.ObtenerEventoEnsayoPorId(id);
        }

        public IEnumerable<EventoEnsayo> ObtenerEventoEnsayoPorIdAmbiente(int idAmbiente)
        {
            return eventoEnsayoRepository.ObtenerEventoEnsayoPorIdAmbiente(idAmbiente);
        }

        public IEnumerable<EventoEnsayo> ObtenerEventoEnsayoPorCriterio(string criterio)
        {
            return eventoEnsayoRepository.ObtenerEventoEnsayoPorCriterio(criterio);
        }

        public IEnumerable<DetalleHorasEvento> ObtenerDetalleHorasEventoPorCriterio(int criterio, bool evento)
        {
            return eventoEnsayoRepository.ObtenerDetalleHorasEventoPorCriterio(criterio, evento);
        }

        public DetalleHorasEvento ObtenerDetalleHorasEventoPorIdEvento(int Id)
        {
            return eventoEnsayoRepository.ObtenerDetalleHorasEventoPorIdEvento(Id);
        }

        public void EliminarDetalleEventoEnsayo(int id)
        {
            eventoEnsayoRepository.EliminarDetalleEventoEnsayo(id);
        }
    }
}
