﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ddcCajamarca.Repository.ActividadesCulturales.Interfaces;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.ActividadesCulturales.Datos
{
    public class EventoEnsayoRepository : MasterRepository, IEventoEnsayoRepository
    {
        public void EliminarEventoEnsayo(int id)
        {
            var elim = ObtenerEventoEnsayoPorId(id);

            Context.EventoEnsayos.Remove(elim);
            Context.SaveChanges();
        }

        public void GuardarEventoEnsayo(EventoEnsayo eventoEnsayo)
        {
            Context.EventoEnsayos.Add(eventoEnsayo);
            Context.SaveChanges();
        }

        public void ModificarEventoEnsayo(EventoEnsayo eventoEnsayo)
        {
            Context.Entry(eventoEnsayo).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public IEnumerable<EventoEnsayo> ObtenerEventoEnsayoPorCriterio(string criterio)
        {
            var query = from p in Context.EventoEnsayos.Include("Ambiente").Include("DetalleRequerimientos").Include("DetalleRequerimientos.Activo")
                        select p;

            if (!String.IsNullOrEmpty(criterio))
            {
                query = from p in query
                        where p.NombreActividad.ToUpper().Contains(criterio.ToUpper()) || p.NombreActividad.ToUpper().Contains(criterio.ToUpper())
                        select p;
            }

            return query.ToList();
        }

        public IEnumerable<EventoEnsayo> ObtenerEventoEnsayoPorCriterioYFechas(string criterio, DateTime fechaIni, DateTime FechaFin)
        {
            var query = from p in Context.EventoEnsayos.Include("Ambiente")
                        select p;

            if (!String.IsNullOrEmpty(criterio))
            {
                query = from p in query
                        where p.NombreActividad.ToUpper().Contains(criterio.ToUpper()) || p.NombreActividad.ToUpper().Contains(criterio.ToUpper())
                        select p;
            }
            else
            {
                var fechainirest = fechaIni.AddDays(-5);
                var fechainipost = fechaIni.AddDays(5);
                query = from p in query
                        where p.FechaInicio <= fechaIni && p.FechaFin >= fechaIni || p.FechaInicio >= fechainirest && p.FechaFin <= fechainipost
                        select p;
            }

            return query.ToList();
        }

        public IEnumerable<EventoEnsayo> ObtenerEventoEnsayoPorIdAmbiente(int idAmbiente)
        {
            var query = from p in Context.EventoEnsayos.Include("Ambiente").Include("DetalleRequerimientos").Include("DetalleRequerimientos.Activo")
                        where p.IdAmbiente.Equals(idAmbiente)
                        select p;

            return query.ToList();
        }

        public EventoEnsayo ObtenerEventoEnsayoPorId(int id)
        {
            var query = from p in Context.EventoEnsayos.Include("Ambiente").Include("DetalleRequerimientos").Include("DetalleRequerimientos.Activo")
                        where p.Id.Equals(id)
                        select p;

            return query.Single();
        }

        public IEnumerable<DetalleHorasEvento> ObtenerDetalleHorasEventoPorCriterio(int criterio, bool evento)
        {
            var query = from p in Context.DetalleHorasEventos.Include("EventoEnsayo").Include("EventoEnsayo.DetalleRequerimientos").Include("EventoEnsayo.DetalleRequerimientos.Activo").Include("EventoEnsayo.Ambiente")
                        select p;

            if (evento)
            {
                if (criterio != 0)
                {
                    query = from p in query
                            where p.EventoEnsayo.Id.Equals(criterio)
                            select p;
                }
            }
            else
            {
                if (criterio != 0)
                {
                    query = from p in query
                            where p.EventoEnsayo.Ambiente.Id.Equals(criterio)
                            select p;
                }
            }

            return query.ToList();
        }

        public DetalleHorasEvento ObtenerDetalleHorasEventoPorIdEvento(int Id)
        {
            var query = from p in Context.DetalleHorasEventos.Include("EventoEnsayo").Include("EventoEnsayo.DetalleRequerimientos").Include("EventoEnsayo.DetalleRequerimientos.Activo").Include("EventoEnsayo.Ambiente")
                        select p;

            if (Id != 0)
            {
                query = from p in query
                        where p.Id.Equals(Id)
                        select p;
            }

            return query.Single();
        }
    }
}
