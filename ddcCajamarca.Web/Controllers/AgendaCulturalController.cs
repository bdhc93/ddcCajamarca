using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Syncfusion.XlsIO;
using System.Web.Mvc;
using ddcCajamarca.Services.ActividadesCulturales.Interfaces;
using ddcCajamarca.Models;

namespace ddcCajamarca.Web.Controllers
{
    public class AgendaCulturalController : Controller
    {
        public IAmbienteService ambienteService { get; set; }
        public IActivoService activoService { get; set; }
        public IEventoEnsayoService eventoEnsayoService { get; set; }

        public AgendaCulturalController(IAmbienteService ambienteService, IActivoService activoService, IEventoEnsayoService eventoEnsayoService)
        {
            this.ambienteService = ambienteService;
            this.activoService = activoService;
            this.eventoEnsayoService = eventoEnsayoService;
        }

        [HttpGet]
        public ActionResult ValidadFechaNuevo(Int32 idAmbientes, String FechaIni, String FechaFin, Boolean opcTodoDia, String HoraIni, String HoraFin)
        {
            var eventos = eventoEnsayoService.ObtenerDetalleHorasEventoPorFecha(DateTime.Parse(FechaIni), DateTime.Parse(FechaFin + " 23:59"));

            DateTime FechaIniFind;
            DateTime FechaFinFind;

            if (opcTodoDia)
            {
                FechaIniFind = DateTime.Parse(FechaIni);
                FechaFinFind = DateTime.Parse(FechaIni);
            }
            else
            {
                FechaIniFind = DateTime.Parse(FechaIni + " " + HoraIni);
                FechaFinFind = DateTime.Parse(FechaFin + " " + HoraFin);
            }

            var encontrado = false;

            foreach (var item in eventos)
            {
                if (item.EventoEnsayo.IdAmbiente == idAmbientes)
                {
                    if (item.EventoEnsayo.TodoDia)
                    {
                        encontrado = true;
                        break;
                    }
                    else
                    {
                        if (item.FechaInicio.Hour <= FechaFinFind.Hour && item.FechaFin.Hour >= FechaIniFind.Hour)
                        {
                            if (item.FechaInicio.Hour == FechaFinFind.Hour)
                            {
                                if (item.FechaInicio.Minute < FechaFinFind.Minute)
                                {
                                    encontrado = true;
                                    break;
                                }
                            }
                            else if (item.FechaFin.Hour == FechaIniFind.Hour)
                            {
                                if (item.FechaFin.Minute > FechaIniFind.Minute + 1)
                                {
                                    encontrado = true;
                                    break;
                                }
                            }
                            else
                            {
                                encontrado = true;
                                break;
                            }
                        }
                    }
                }
            }

            if (encontrado)
            {
                ViewBag.MSG = "ND";
            }

            return PartialView("_Mensaje");
        }

        [HttpGet]
        public ActionResult NuevoRegistro(Int32 idAmbientes, String OpcionEvento, String FechaIni, String FechaFin, Boolean opcTodoDia, String HoraIni, String HoraFin)
        {
            ViewBag.FechaHoy = FechaHoy();

            if (OpcionEvento == "Evento")
            {
                ViewBag.Evento = true + "";
            }
            else
            {
                ViewBag.Evento = false + "";
            }

            ViewBag.FechaInicio = FechaIni;
            ViewBag.FechaFin = FechaFin;
            if (opcTodoDia)
            {
                ViewBag.opcTodoDia = "True";
                ViewBag.HoraInicio = "00:00";
                ViewBag.HoraFin = "23:59";
                ViewBag.Activos = activoService.ObtenerActivoSinUsoPorFechas(DateTime.Parse(FechaIni), DateTime.Parse(FechaFin));
            }
            else
            {
                ViewBag.opcTodoDia = "False";
                ViewBag.HoraInicio = HoraIni;
                ViewBag.HoraFin = HoraFin;
                ViewBag.Activos = activoService.ObtenerActivoSinUsoPorFechas(DateTime.Parse(FechaIni + " " + HoraIni), DateTime.Parse(FechaFin + " " + HoraFin));
            }

            ViewBag.IdAmbiente = idAmbientes;
            ViewBag.Ambiente = ambienteService.ObtenerAmbientePorId(idAmbientes).NombreMostrar;
            ViewBag.EventosAuto = DataEventosAutocomplete(DateTime.Parse(FechaIni), DateTime.Parse(FechaFin));

            return View();
        }

        [HttpPost]
        public ActionResult NuevoRegistro(EventoEnsayo evento, String arryreq, String FechaInicio, String FechaFin, Boolean opcTodoDia, String HoraIni, String HoraFin, Boolean Eventotipo)
        {
            EventoEnsayo eventoguardar;

            evento.NombreActividad = evento.NombreActividad.Replace(char.ConvertFromUtf32(34), "'");
            evento.InstitucionEncargada = evento.InstitucionEncargada.Replace(char.ConvertFromUtf32(34), "'");

            if (opcTodoDia)
            {
                HoraIni = "";
                HoraFin = "";

                eventoguardar = new EventoEnsayo
                {
                    IdAmbiente = evento.IdAmbiente,
                    NombreActividad = evento.NombreActividad.ToUpper(),
                    InstitucionEncargada = evento.InstitucionEncargada.ToUpper(),
                    InformacionAdicional = evento.InformacionAdicional.ToUpper(),
                    TodoDia = true,
                    FechaInicio = DateTime.Parse(FechaInicio),
                    FechaFin = DateTime.Parse(FechaFin),
                    FechaRegistro = DateTime.Today,
                    Evento = Eventotipo
                };
            }
            else
            {
                eventoguardar = new EventoEnsayo
                {
                    IdAmbiente = evento.IdAmbiente,
                    NombreActividad = evento.NombreActividad.ToUpper(),
                    InstitucionEncargada = evento.InstitucionEncargada.ToUpper(),
                    InformacionAdicional = evento.InformacionAdicional.ToUpper(),
                    TodoDia = false,
                    FechaInicio = DateTime.Parse(FechaInicio + " " + HoraIni),
                    FechaFin = DateTime.Parse(FechaFin + " " + HoraFin),
                    FechaRegistro = DateTime.Today,
                    Evento = Eventotipo
                };
            }

            if (!String.IsNullOrEmpty(arryreq))
            {
                var encontrado = false;

                String[] requerimientos = arryreq.Split(',');

                foreach (var item in evento.DetalleRequerimientos)
                {
                    foreach (var itemreq in requerimientos)
                    {
                        if (item.IdActivo == Int32.Parse(itemreq))
                        {
                            encontrado = true;
                            break;
                        }
                    }

                    if (encontrado)
                    {
                        DetalleRequerimiento agregardet = new DetalleRequerimiento { IdActivo = item.IdActivo, Cantidad = item.Cantidad, FechaRegistro = DateTime.Today };

                        eventoguardar.DetalleRequerimientos.Add(agregardet);
                        encontrado = false;
                    }
                }
            }

            if (opcTodoDia)
            {
                DetalleHorasEvento detallehora = new DetalleHorasEvento
                {
                    FechaInicio = DateTime.Parse(FechaInicio),
                    FechaFin = DateTime.Parse(FechaFin)
                };

                eventoguardar.DetalleHorasEventos.Add(detallehora);

                eventoEnsayoService.GuardarEventoEnsayo(eventoguardar);
            }
            else
            {
                var dias = (eventoguardar.FechaFin.Day - eventoguardar.FechaInicio.Day) + 1;

                if (evento.FechaInicio.Month == evento.FechaFin.Month)
                {
                    var fechainiguard = eventoguardar.FechaInicio;
                    var fechafinguard = eventoguardar.FechaFin;

                    for (int i = 0; i < dias; i++)
                    {
                        DetalleHorasEvento detallehora = new DetalleHorasEvento
                        {
                            FechaInicio = new DateTime(fechainiguard.Year, fechainiguard.Month, fechainiguard.Day, fechainiguard.Hour, fechainiguard.Minute, fechainiguard.Millisecond),
                            FechaFin = new DateTime(fechafinguard.Year, fechafinguard.Month, fechainiguard.Day, fechafinguard.Hour, fechafinguard.Minute, fechafinguard.Millisecond)
                        };

                        fechainiguard = fechainiguard.AddDays(1);

                        eventoguardar.DetalleHorasEventos.Add(detallehora);
                    }

                    eventoEnsayoService.GuardarEventoEnsayo(eventoguardar);
                }
                else
                {
                    var fechainiguard = eventoguardar.FechaInicio;
                    var fechafinguard = eventoguardar.FechaFin;

                    for (int i = 0; i < 90; i++)
                    {
                        DetalleHorasEvento detallehora = new DetalleHorasEvento
                        {
                            FechaInicio = new DateTime(fechainiguard.Year, fechainiguard.Month, fechainiguard.Day, fechainiguard.Hour, fechainiguard.Minute, fechainiguard.Millisecond),
                            FechaFin = new DateTime(fechainiguard.Year, fechainiguard.Month, fechainiguard.Day, fechafinguard.Hour, fechafinguard.Minute, fechafinguard.Millisecond)
                        };

                        eventoguardar.DetalleHorasEventos.Add(detallehora);

                        if (fechainiguard >= DateTime.Parse(FechaFin))
                        {
                            break;
                        }
                        else
                        {
                            fechainiguard = fechainiguard.AddDays(1);
                        }
                    }
                    eventoEnsayoService.GuardarEventoEnsayo(eventoguardar);
                }
            }

            return Redirect(Url.Action("Calendario"));
        }

        [HttpGet]
        public ActionResult ModificarRegistro(Int32 idMod, Int32 IdModDet, Boolean todo)
        {
            var result = eventoEnsayoService.ObtenerEventoEnsayoPorId(idMod);

            ViewBag.Activos = activoService.ObtenerActivoPorCriterio("");

            ViewBag.Evento = result.Evento + "";

            ViewBag.opcTodoDia = result.TodoDia + "";

            return View(result);
        }

        [HttpPost]
        public ActionResult ModificarRegistro(EventoEnsayo evento, String arryreq, String FechaInicio, String FechaFin, String HoraIni, String HoraFin, Boolean Eventotipo, Boolean opcTodoDia)
        {
            EventoEnsayo eventoguardar;

            evento.NombreActividad = evento.NombreActividad.Replace(char.ConvertFromUtf32(34), "'");
            evento.InstitucionEncargada = evento.InstitucionEncargada.Replace(char.ConvertFromUtf32(34), "'");

            if (opcTodoDia)
            {
                HoraIni = "";
                HoraFin = "";

                eventoguardar = new EventoEnsayo
                {
                    Id = evento.Id,
                    IdAmbiente = evento.IdAmbiente,
                    NombreActividad = evento.NombreActividad.ToUpper(),
                    InstitucionEncargada = evento.InstitucionEncargada.ToUpper(),
                    InformacionAdicional = evento.InformacionAdicional.ToUpper(),
                    TodoDia = true,
                    FechaInicio = DateTime.Parse(FechaInicio),
                    FechaFin = DateTime.Parse(FechaFin),
                    FechaRegistro = DateTime.Today,
                    Evento = Eventotipo
                };
            }
            else
            {
                eventoguardar = new EventoEnsayo
                {
                    Id = evento.Id,
                    IdAmbiente = evento.IdAmbiente,
                    NombreActividad = evento.NombreActividad.ToUpper(),
                    InstitucionEncargada = evento.InstitucionEncargada.ToUpper(),
                    InformacionAdicional = evento.InformacionAdicional.ToUpper(),
                    TodoDia = false,
                    FechaInicio = DateTime.Parse(FechaInicio + " " + HoraIni),
                    FechaFin = DateTime.Parse(FechaFin + " " + HoraFin),
                    FechaRegistro = DateTime.Today,
                    Evento = Eventotipo
                };
            }

            if (!String.IsNullOrEmpty(arryreq))
            {
                var encontrado = false;

                String[] requerimientos = arryreq.Split(',');

                foreach (var item in evento.DetalleRequerimientos)
                {
                    foreach (var itemreq in requerimientos)
                    {
                        if (item.IdActivo == Int32.Parse(itemreq))
                        {
                            encontrado = true;
                            break;
                        }
                    }

                    if (encontrado)
                    {
                        DetalleRequerimiento agregardet = new DetalleRequerimiento { IdActivo = item.IdActivo, Cantidad = item.Cantidad, FechaRegistro = DateTime.Today, IdEventoEnsayo = evento.Id };

                        eventoguardar.DetalleRequerimientos.Add(agregardet);
                        encontrado = false;
                    }
                }
            }

            eventoEnsayoService.ModificarEventoEnsayo(eventoguardar);


            return Redirect(Url.Action("Calendario"));
        }

        [HttpGet]
        public ActionResult Calendario()
        {
            ViewBag.FechaHoy = FechaHoy();

            ViewBag.Ambientes = ambienteService.ObtenerAmbientePorCriterio("");

            var Eventos = eventoEnsayoService.ObtenerDetalleHorasEventoPorCriterio(0, false);

            //var tamb = Eventos.LongCount();

            //var contador = 0;

            //var titulo = new String[tamb];
            //var idEvento = new Int32[tamb];
            //var inicio = new DateTime[tamb];
            //var fin = new DateTime[tamb];
            //var tododia = new Boolean[tamb];
            //var color = new String[tamb];
            //var descripcion = new String[tamb];

            //foreach (var item in Eventos)
            //{
            //    var detallerequerimientos = "";

            //    foreach (var itemreq in item.EventoEnsayo.DetalleRequerimientos)
            //    {
            //        detallerequerimientos = detallerequerimientos + " " + itemreq.Activo.Nombre + " - " + itemreq.Cantidad + " <br />";
            //    }

            //    idEvento[contador] = item.Id;

            //    if (item.EventoEnsayo.Evento)
            //    {
            //        titulo[contador] = item.EventoEnsayo.Ambiente.Nombre + ": " + item.EventoEnsayo.NombreActividad + " - " + item.EventoEnsayo.InstitucionEncargada;
            //    }
            //    else
            //    {
            //        titulo[contador] = item.EventoEnsayo.Ambiente.Nombre + ": ENSAYO - " + item.EventoEnsayo.NombreActividad + " - " + item.EventoEnsayo.InstitucionEncargada;
            //    }

            //    if (item.FechaFin.Date != item.FechaInicio.Date)
            //    {
            //        inicio[contador] = new DateTime(item.FechaInicio.Year, item.FechaInicio.Month, item.FechaInicio.Day, item.FechaInicio.Hour, item.FechaInicio.Minute, item.FechaInicio.Millisecond);
            //        fin[contador] = new DateTime(item.FechaFin.Year, item.FechaFin.Month, item.FechaFin.Day + 1, item.FechaFin.Hour, item.FechaFin.Minute, item.FechaFin.Millisecond);
            //    }
            //    else
            //    {
            //        inicio[contador] = new DateTime(item.FechaInicio.Year, item.FechaInicio.Month, item.FechaInicio.Day, item.FechaInicio.Hour, item.FechaInicio.Minute, item.FechaInicio.Millisecond);
            //        fin[contador] = new DateTime(item.FechaFin.Year, item.FechaFin.Month, item.FechaFin.Day, item.FechaFin.Hour, item.FechaFin.Minute, item.FechaFin.Millisecond);
            //    }

            //    tododia[contador] = item.EventoEnsayo.TodoDia;
            //    color[contador] = item.EventoEnsayo.Ambiente.ColorNombre;
            //    descripcion[contador] = "<b>Requerimientos:</b> <br />" + detallerequerimientos + "<b>Información Adicional:</b> <br />" + item.EventoEnsayo.InformacionAdicional;

            //    contador++;
            //}

            //ViewBag.titulo = titulo;
            //ViewBag.IdEvento = idEvento;
            //ViewBag.inicio = inicio;
            //ViewBag.fin = fin;
            //ViewBag.tododia = tododia;
            //ViewBag.color = color;
            //ViewBag.descripcion = descripcion;

            List<EventoCalendar> datos = new List<EventoCalendar>();

            foreach (var item in Eventos)
            {
                var titulos = "";
                var inicios = "";
                var fines = "";

                if (item.EventoEnsayo.Evento)
                {
                    titulos = item.EventoEnsayo.Ambiente.Nombre + ": " + item.EventoEnsayo.NombreActividad + " - " + item.EventoEnsayo.InstitucionEncargada;
                }
                else
                {
                    titulos = item.EventoEnsayo.Ambiente.Nombre + ": ENSAYO - " + item.EventoEnsayo.NombreActividad + " - " + item.EventoEnsayo.InstitucionEncargada;
                }

                if (item.FechaFin.Date != item.FechaInicio.Date)
                {
                    if (item.FechaInicio.Day < 10)
                    {
                        if (item.FechaInicio.Month < 10)
                        {
                            inicios = item.FechaInicio.Year + "-0" + item.FechaInicio.Month + "-0" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;
                        }
                        else
                        {
                            inicios = item.FechaInicio.Year + "-" + item.FechaInicio.Month + "-0" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;
                        }

                        if (item.FechaFin.AddDays(1).Day > 9)
                        {
                            if (item.FechaInicio.Month < 10)
                            {
                                fines = item.FechaFin.Year + "-0" + item.FechaFin.Month + "-" + (item.FechaFin.AddDays(1).Day) + "T" + item.FechaFin.TimeOfDay;
                            }
                            else
                            {
                                fines = item.FechaFin.Year + "-" + item.FechaFin.Month + "-" + (item.FechaFin.AddDays(1).Day) + "T" + item.FechaFin.TimeOfDay;
                            }
                        }
                        else
                        {
                            if (item.FechaInicio.Month < 10)
                            {
                                fines = item.FechaFin.Year + "-0" + item.FechaFin.Month + "-0" + (item.FechaFin.AddDays(1).Day) + "T" + item.FechaFin.TimeOfDay;
                            }
                            else
                            {
                                fines = item.FechaFin.Year + "-" + item.FechaFin.Month + "-0" + (item.FechaFin.AddDays(1).Day) + "T" + item.FechaFin.TimeOfDay;
                            }
                        }
                    }
                    else
                    {
                        if (item.FechaInicio.Month < 10)
                        {
                            inicios = item.FechaInicio.Year + "-0" + item.FechaInicio.Month + "-" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;
                        }
                        else
                        {
                            inicios = item.FechaInicio.Year + "-" + item.FechaInicio.Month + "-" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;
                        }

                        if (item.FechaFin.AddDays(1).Day > 9)
                        {
                            if (item.FechaInicio.Month < 10)
                            {
                                fines = item.FechaFin.Year + "-0" + item.FechaFin.Month + "-" + (item.FechaFin.AddDays(1).Day + 1) + "T" + item.FechaFin.TimeOfDay;
                            }
                            else
                            {
                                fines = item.FechaFin.Year + "-" + item.FechaFin.Month + "-" + (item.FechaFin.AddDays(1).Day + 1) + "T" + item.FechaFin.TimeOfDay;
                            }
                        }
                        else
                        {
                            if (item.FechaInicio.Month < 10)
                            {
                                fines = item.FechaFin.Year + "-0" + item.FechaFin.Month + "-0" + (item.FechaFin.AddDays(1).Day + 1) + "T" + item.FechaFin.TimeOfDay;
                            }
                            else
                            {
                                fines = item.FechaFin.Year + "-" + item.FechaFin.Month + "-0" + (item.FechaFin.AddDays(1).Day + 1) + "T" + item.FechaFin.TimeOfDay;
                            }
                        }
                    }
                }
                else
                {
                    if (item.FechaInicio.Day < 10)
                    {
                        if (item.FechaInicio.Month < 10)
                        {
                            inicios = item.FechaInicio.Year + "-0" + item.FechaInicio.Month + "-0" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;
                            fines = item.FechaFin.Year + "-0" + item.FechaFin.Month + "-0" + item.FechaFin.Day + "T" + item.FechaFin.TimeOfDay;
                        }
                        else
                        {
                            inicios = item.FechaInicio.Year + "-" + item.FechaInicio.Month + "-0" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;
                            fines = item.FechaFin.Year + "-" + item.FechaFin.Month + "-0" + item.FechaFin.Day + "T" + item.FechaFin.TimeOfDay;
                        }
                    }
                    else
                    {
                        if (item.FechaInicio.Month < 10)
                        {
                            inicios = item.FechaInicio.Year + "-0" + item.FechaInicio.Month + "-" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;
                            fines = item.FechaFin.Year + "-0" + item.FechaFin.Month + "-" + item.FechaFin.Day + "T" + item.FechaFin.TimeOfDay;
                        }
                        else
                        {
                            inicios = item.FechaInicio.Year + "-" + item.FechaInicio.Month + "-" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;
                            fines = item.FechaFin.Year + "-" + item.FechaFin.Month + "-" + item.FechaFin.Day + "T" + item.FechaFin.TimeOfDay;
                        }
                    }
                }

                var detallerequerimientos = "";

                foreach (var itemreq in item.EventoEnsayo.DetalleRequerimientos)
                {
                    detallerequerimientos = detallerequerimientos + " " + itemreq.Activo.Nombre + " - " + itemreq.Cantidad + " <br />";
                }

                EventoCalendar x = new EventoCalendar
                {
                    title = titulos,
                    start = inicios,
                    end = fines,
                    allDay = item.EventoEnsayo.TodoDia,
                    color = item.EventoEnsayo.Ambiente.ColorNombre,
                    description = "<b>Requerimientos:</b> <br />" + detallerequerimientos + "<b>Información Adicional:</b> <br />" + item.EventoEnsayo.InformacionAdicional,
                    data = item.IdEventoEnsayo
                };
                datos.Add(x);
            }

            ViewBag.Eventos = datos;

            return View();
        }

        [HttpGet]
        public ActionResult MostrarCalendario(String idAmbiente)
        {
            var id = 0;

            if (!String.IsNullOrEmpty(idAmbiente))
            {
                id = Int32.Parse(idAmbiente);

                var Eventos = eventoEnsayoService.ObtenerDetalleHorasEventoPorCriterio(id, false);
                
                List<EventoCalendar> datos = new List<EventoCalendar>();

                foreach (var item in Eventos)
                {
                    var titulos = "";
                    var inicios = "";
                    var fines = "";

                    if (item.EventoEnsayo.Evento)
                    {
                        titulos = item.EventoEnsayo.Ambiente.Nombre + ": " + item.EventoEnsayo.NombreActividad + " - " + item.EventoEnsayo.InstitucionEncargada;
                    }
                    else
                    {
                        titulos = item.EventoEnsayo.Ambiente.Nombre + ": ENSAYO - " + item.EventoEnsayo.NombreActividad + " - " + item.EventoEnsayo.InstitucionEncargada;
                    }

                    if (item.FechaFin.Date != item.FechaInicio.Date)
                    {
                        if (item.FechaInicio.Day < 10)
                        {
                            if (item.FechaInicio.Month < 10)
                            {
                                inicios = item.FechaInicio.Year + "-0" + item.FechaInicio.Month + "-0" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;
                            }
                            else
                            {
                                inicios = item.FechaInicio.Year + "-" + item.FechaInicio.Month + "-0" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;
                            }
                            
                            if (item.FechaFin.AddDays(1).Day > 9)
                            {
                                if (item.FechaInicio.Month < 10)
                                {
                                    fines = item.FechaFin.Year + "-0" + item.FechaFin.Month + "-" + (item.FechaFin.AddDays(1).Day) + "T" + item.FechaFin.TimeOfDay;
                                }
                                else
                                {
                                    fines = item.FechaFin.Year + "-" + item.FechaFin.Month + "-" + (item.FechaFin.AddDays(1).Day) + "T" + item.FechaFin.TimeOfDay;
                                }
                            }
                            else
                            {
                                if (item.FechaInicio.Month < 10)
                                {
                                    fines = item.FechaFin.Year + "-0" + item.FechaFin.Month + "-0" + (item.FechaFin.AddDays(1).Day) + "T" + item.FechaFin.TimeOfDay;
                                }
                                else
                                {
                                    fines = item.FechaFin.Year + "-" + item.FechaFin.Month + "-0" + (item.FechaFin.AddDays(1).Day) + "T" + item.FechaFin.TimeOfDay;
                                }
                            }
                        }
                        else
                        {
                            if (item.FechaInicio.Month < 10)
                            {
                                inicios = item.FechaInicio.Year + "-0" + item.FechaInicio.Month + "-" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;
                            }
                            else
                            {
                                inicios = item.FechaInicio.Year + "-" + item.FechaInicio.Month + "-" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;
                            }
                            
                            if (item.FechaFin.AddDays(1).Day > 9)
                            {
                                if (item.FechaInicio.Month < 10)
                                {
                                    fines = item.FechaFin.Year + "-0" + item.FechaFin.Month + "-" + (item.FechaFin.AddDays(1).Day + 1) + "T" + item.FechaFin.TimeOfDay;
                                }
                                else
                                {
                                    fines = item.FechaFin.Year + "-" + item.FechaFin.Month + "-" + (item.FechaFin.AddDays(1).Day + 1) + "T" + item.FechaFin.TimeOfDay;
                                }
                            }
                            else
                            {
                                if (item.FechaInicio.Month < 10)
                                {
                                    fines = item.FechaFin.Year + "-0" + item.FechaFin.Month + "-0" + (item.FechaFin.AddDays(1).Day + 1) + "T" + item.FechaFin.TimeOfDay;
                                }
                                else
                                {
                                    fines = item.FechaFin.Year + "-" + item.FechaFin.Month + "-0" + (item.FechaFin.AddDays(1).Day + 1) + "T" + item.FechaFin.TimeOfDay;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (item.FechaInicio.Day < 10)
                        {
                            if (item.FechaInicio.Month < 10)
                            {
                                inicios = item.FechaInicio.Year + "-0" + item.FechaInicio.Month + "-0" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;
                                fines = item.FechaFin.Year + "-0" + item.FechaFin.Month + "-0" + item.FechaFin.Day + "T" + item.FechaFin.TimeOfDay;
                            }
                            else
                            {
                                inicios = item.FechaInicio.Year + "-" + item.FechaInicio.Month + "-0" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;
                                fines = item.FechaFin.Year + "-" + item.FechaFin.Month + "-0" + item.FechaFin.Day + "T" + item.FechaFin.TimeOfDay;
                            }
                        }
                        else
                        {
                            if (item.FechaInicio.Month < 10)
                            {
                                inicios = item.FechaInicio.Year + "-0" + item.FechaInicio.Month + "-" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;
                                fines = item.FechaFin.Year + "-0" + item.FechaFin.Month + "-" + item.FechaFin.Day + "T" + item.FechaFin.TimeOfDay;
                            }
                            else
                            {
                                inicios = item.FechaInicio.Year + "-" + item.FechaInicio.Month + "-" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;
                                fines = item.FechaFin.Year + "-" + item.FechaFin.Month + "-" + item.FechaFin.Day + "T" + item.FechaFin.TimeOfDay;
                            }
                        }
                    }

                    var detallerequerimientos = "";

                    foreach (var itemreq in item.EventoEnsayo.DetalleRequerimientos)
                    {
                        detallerequerimientos = detallerequerimientos + " " + itemreq.Activo.Nombre + " - " + itemreq.Cantidad + " <br />";
                    }

                    EventoCalendar x = new EventoCalendar
                    {
                        title = titulos,
                        start = inicios,
                        end = fines,
                        allDay = item.EventoEnsayo.TodoDia,
                        color = item.EventoEnsayo.Ambiente.ColorNombre,
                        description = "<b>Requerimientos:</b> <br />" + detallerequerimientos + "<b>Información Adicional:</b> <br />" + item.EventoEnsayo.InformacionAdicional,
                        data = item.IdEventoEnsayo
                    };
                    datos.Add(x);
                }

                ViewBag.Eventos = datos;

                return PartialView("_MostrarCalendario");
            }
            else
            {
                var Eventos = eventoEnsayoService.ObtenerDetalleHorasEventoPorCriterio(0, false);

                //var tamb = Eventos.LongCount();

                //var contador = 0;

                //var titulo = new String[tamb];
                //var idEvento = new Int32[tamb];
                //var inicio = new DateTime[tamb];
                //var fin = new DateTime[tamb];
                //var tododia = new Boolean[tamb];
                //var color = new String[tamb];
                //var descripcion = new String[tamb];

                //foreach (var item in Eventos)
                //{
                //    var detallerequerimientos = "";

                //    foreach (var itemreq in item.EventoEnsayo.DetalleRequerimientos)
                //    {
                //        detallerequerimientos = detallerequerimientos + " " + itemreq.Activo.Nombre + " - " + itemreq.Cantidad + " <br />";
                //    }

                //    idEvento[contador] = item.Id;

                //    if (item.EventoEnsayo.Evento)
                //    {
                //        titulo[contador] = item.EventoEnsayo.Ambiente.Nombre + ": " + item.EventoEnsayo.NombreActividad + " - " + item.EventoEnsayo.InstitucionEncargada;
                //    }
                //    else
                //    {
                //        titulo[contador] = item.EventoEnsayo.Ambiente.Nombre + ": ENSAYO - " + item.EventoEnsayo.NombreActividad + " - " + item.EventoEnsayo.InstitucionEncargada;
                //    }

                //    if (item.FechaFin.Date != item.FechaInicio.Date)
                //    {
                //        inicio[contador] = new DateTime(item.FechaInicio.Year, item.FechaInicio.Month, item.FechaInicio.Day, item.FechaInicio.Hour, item.FechaInicio.Minute, item.FechaInicio.Millisecond);
                //        fin[contador] = new DateTime(item.FechaFin.Year, item.FechaFin.Month, item.FechaFin.Day + 1, item.FechaFin.Hour, item.FechaFin.Minute, item.FechaFin.Millisecond);
                //    }
                //    else
                //    {
                //        inicio[contador] = new DateTime(item.FechaInicio.Year, item.FechaInicio.Month, item.FechaInicio.Day, item.FechaInicio.Hour, item.FechaInicio.Minute, item.FechaInicio.Millisecond);
                //        fin[contador] = new DateTime(item.FechaFin.Year, item.FechaFin.Month, item.FechaFin.Day, item.FechaFin.Hour, item.FechaFin.Minute, item.FechaFin.Millisecond);
                //    }

                //    tododia[contador] = item.EventoEnsayo.TodoDia;
                //    color[contador] = item.EventoEnsayo.Ambiente.ColorNombre;
                //    descripcion[contador] = "<b>Requerimientos:</b> <br />" + detallerequerimientos + "<b>Información Adicional:</b> <br />" + item.EventoEnsayo.InformacionAdicional;

                //    contador++;
                //}

                //ViewBag.IdEvento = idEvento;
                //ViewBag.titulo = titulo;
                //ViewBag.inicio = inicio;
                //ViewBag.fin = fin;
                //ViewBag.tododia = tododia;
                //ViewBag.color = color;
                //ViewBag.descripcion = descripcion;

                List<EventoCalendar> datos = new List<EventoCalendar>();

                foreach (var item in Eventos)
                {
                    var titulos = "";
                    var inicios = "";
                    var fines = "";

                    if (item.EventoEnsayo.Evento)
                    {
                        titulos = item.EventoEnsayo.Ambiente.Nombre + ": " + item.EventoEnsayo.NombreActividad + " - " + item.EventoEnsayo.InstitucionEncargada;
                    }
                    else
                    {
                        titulos = item.EventoEnsayo.Ambiente.Nombre + ": ENSAYO - " + item.EventoEnsayo.NombreActividad + " - " + item.EventoEnsayo.InstitucionEncargada;
                    }
                    if (item.FechaFin.Date != item.FechaInicio.Date)
                    {
                        if (item.FechaInicio.Day < 10)
                        {
                            inicios = item.FechaInicio.Year + "-" + item.FechaInicio.Month + "-0" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;

                            if (item.FechaFin.AddDays(1).Day > 9)
                            {
                                fines = item.FechaFin.Year + "-" + item.FechaFin.Month + "-" + (item.FechaFin.AddDays(1).Day) + "T" + item.FechaFin.TimeOfDay;
                            }
                            else
                            {
                                fines = item.FechaFin.Year + "-" + item.FechaFin.Month + "-0" + (item.FechaFin.AddDays(1).Day) + "T" + item.FechaFin.TimeOfDay;
                            }

                        }
                        else
                        {
                            inicios = item.FechaInicio.Year + "-" + item.FechaInicio.Month + "-" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;

                            if (item.FechaFin.AddDays(1).Day > 9)
                            {
                                fines = item.FechaFin.Year + "-" + item.FechaFin.Month + "-" + (item.FechaFin.AddDays(1).Day + 1) + "T" + item.FechaFin.TimeOfDay;
                            }
                            else
                            {
                                fines = item.FechaFin.Year + "-" + item.FechaFin.Month + "-0" + (item.FechaFin.AddDays(1).Day + 1) + "T" + item.FechaFin.TimeOfDay;
                            }

                        }
                    }
                    else
                    {
                        if (item.FechaInicio.Day < 10)
                        {
                            inicios = item.FechaInicio.Year + "-" + item.FechaInicio.Month + "-0" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;
                            fines = item.FechaFin.Year + "-" + item.FechaFin.Month + "-0" + item.FechaFin.Day + "T" + item.FechaFin.TimeOfDay;
                        }
                        else
                        {
                            inicios = item.FechaInicio.Year + "-" + item.FechaInicio.Month + "-" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;
                            fines = item.FechaFin.Year + "-" + item.FechaFin.Month + "-" + item.FechaFin.Day + "T" + item.FechaFin.TimeOfDay;

                        }
                    }

                    var detallerequerimientos = "";

                    foreach (var itemreq in item.EventoEnsayo.DetalleRequerimientos)
                    {
                        detallerequerimientos = detallerequerimientos + " " + itemreq.Activo.Nombre + " - " + itemreq.Cantidad + " <br />";
                    }

                    EventoCalendar x = new EventoCalendar
                    {
                        title = titulos,
                        start = inicios,
                        end = fines,
                        allDay = item.EventoEnsayo.TodoDia,
                        color = item.EventoEnsayo.Ambiente.ColorNombre,
                        description = "<b>Requerimientos:</b> <br />" + detallerequerimientos + "<b>Información Adicional:</b> <br />" + item.EventoEnsayo.InformacionAdicional,
                        data = item.IdEventoEnsayo
                    };
                    datos.Add(x);
                }

                ViewBag.Eventos = datos;

                return PartialView("_MostrarCalendario");
            }
        }

        [HttpGet]
        public ActionResult ListarAmbientes(String Tp)
        {
            if (Tp == "G1")
            {
                ViewBag.ToasMS = "G1";

                var Amb = ambienteService.ObtenerAmbientePorCriterio("");

                ViewBag.Coincidencias = Amb.LongCount();

                ViewBag.Ambiente = Amb;
            }
            else if (Tp == "M1")
            {
                ViewBag.ToasMS = "M1";

                var Amb = ambienteService.ObtenerAmbientePorCriterio("");

                ViewBag.Coincidencias = Amb.LongCount();

                ViewBag.Ambiente = Amb;
            }
            else
            {
                ViewBag.ToasMS = "G4";

                var Amb = ambienteService.ObtenerAmbientePorCriterio("");

                ViewBag.Coincidencias = Amb.LongCount();

                ViewBag.Ambiente = Amb;
            }

            ViewBag.FechaHoy = FechaHoy();

            return View();
        }

        [HttpGet]
        public ActionResult ListarActivos(String Tp)
        {
            var act = activoService.ObtenerActivoPorCriterio("");

            ViewBag.Coincidencias = act.LongCount();

            ViewBag.Activo = act;

            ViewBag.ToasMS = Tp;

            ViewBag.FechaHoy = FechaHoy();

            return View();
        }

        [HttpGet]
        public ActionResult GuardarAmbiente(String Nombre, String aforo, String color)
        {
            try
            {
                if (String.IsNullOrEmpty(aforo))
                {
                    aforo = "0";
                }
                
                ViewBag.msg = "G1";

                Ambiente amb = new Ambiente { Nombre = Nombre.ToUpper(), Aforo = Int32.Parse(aforo), Color = color, FechaRegistro = DateTime.Today };

                ambienteService.GuardarAmbiente(amb);
            }
            catch (Exception)
            {
                ViewBag.msg = "G4";
                return PartialView("_GuardarAmbiente");
            }

            return PartialView("_GuardarAmbiente");
        }

        [HttpGet]
        public ActionResult GuardarActivo(String nombre, String cantidad)
        {
            try
            {
                if (String.IsNullOrEmpty(cantidad))
                {
                    cantidad = "0";
                }

                ViewBag.msg = "G1";

                Activo amb = new Activo { Nombre = nombre.ToUpper(), Cantidad = Int32.Parse(cantidad), FechaRegistro = DateTime.Today };

                activoService.GuardarActivo(amb);

                return PartialView("_GuardarActivo");
            }
            catch (Exception)
            {
                ViewBag.msg = "G4";
                return PartialView("_GuardarActivo");
            }
        }

        [HttpGet]
        public ActionResult EliminarAmbiente(Int32 idelim)
        {
            try
            {
                ViewBag.MSG = "E1";

                ambienteService.EliminarAmbiente(idelim);
            }
            catch (Exception)
            {
                ViewBag.MSG = "E2";
            }

            return PartialView("_EliminarAmbiente");
        }

        [HttpGet]
        public ActionResult EliminarActivo(Int32 idelim)
        {
            try
            {
                ViewBag.MSG = "E1";

                activoService.EliminarActivo(idelim);
            }
            catch (Exception)
            {
                ViewBag.MSG = "E2";
            }

            return PartialView("_EliminarActivo");
        }

        [HttpGet]
        public ActionResult EliminarEventoEnsayo(Int32 idelim, Int32 idelimdet, Boolean todo)
        {
            try
            {
                ViewBag.MSG = "E1";

                if (todo)
                {
                    eventoEnsayoService.EliminarEventoEnsayo(idelim);
                }
                else
                {
                    var evento = eventoEnsayoService.ObtenerEventoEnsayoPorId(idelim);

                    if (evento.DetalleHorasEventos.Count > 1)
                    {
                        eventoEnsayoService.EliminarDetalleEventoEnsayo(idelimdet);
                    }
                    else
                    {
                        eventoEnsayoService.EliminarEventoEnsayo(idelim);
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.MSG = "E2";
            }

            return PartialView("_EliminarActivo");
        }

        [HttpGet]
        public ActionResult BuscarAmbiente(String criterio)
        {
            try
            {
                var result = ambienteService.ObtenerAmbientePorCriterio(criterio);

                ViewBag.Coincidencias = result.Count();

                return PartialView("_BuscarAmbiente", result);
            }
            catch (Exception)
            {
                ViewBag.Coincidencias = 0;

                return PartialView("_BuscarAmbiente");
            }
        }

        [HttpGet]
        public ActionResult BuscarActivo(String criterio)
        {
            try
            {
                var result = activoService.ObtenerActivoPorCriterio(criterio);

                ViewBag.Coincidencias = result.Count();

                return PartialView("_BuscarActivo", result);
            }
            catch (Exception)
            {
                ViewBag.Coincidencias = 0;

                return PartialView("_BuscarActivo");
            }
        }

        [HttpGet]
        public ActionResult OBtenerAmbientePorId(Int32 Id)
        {
            try
            {
                ViewBag.FechaHoy = FechaHoy();

                var result = ambienteService.ObtenerAmbientePorId(Id);
                return PartialView("_OBtenerAmbientePorId", result);
            }
            catch (Exception)
            {
                return Redirect(Url.Action("ListarAmbientes"));
            }
        }

        [HttpGet]
        public ActionResult OBtenerActivoPorId(Int32 Id)
        {
            try
            {
                ViewBag.FechaHoy = FechaHoy();

                var result = activoService.ObtenerActivoPorId(Id);
                return PartialView("_OBtenerActivoPorId", result);
            }
            catch (Exception)
            {
                return Redirect(Url.Action("ListarAmbientes"));
            }
        }

        [HttpGet]
        public ActionResult OBtenerEventoPorId(String Id)
        {
            var id = Int32.Parse(Id);
            try
            {
                var result = eventoEnsayoService.ObtenerDetalleHorasEventoPorIdEvento(id);
                return PartialView("_OBtenerEventoPorId", result);
            }
            catch (Exception)
            {
                return PartialView("_OBtenerEventoPorId");
            }
        }

        [HttpGet]
        public ActionResult ModificarAmbiente(Int32 Idmod, String nombre, String aforo, String color)
        {
            try
            {
                if (String.IsNullOrEmpty(aforo))
                {
                    aforo = "0";
                }

                ViewBag.msg = "M1";

                Ambiente amb = new Ambiente { Id = Idmod, Nombre = nombre.ToUpper(), Aforo = Int32.Parse(aforo), Color = color, FechaRegistro = DateTime.Today };

                ambienteService.ModificarAmbiente(amb);

            }
            catch (Exception)
            {
                ViewBag.msg = "M4";
                return PartialView("_ModificarAmbiente");
            }

            return PartialView("_ModificarAmbiente");
        }

        [HttpGet]
        public ActionResult ModificarActivo(Int32 Idmod, String nombre, String cantidad)
        {
            try
            {
                if (String.IsNullOrEmpty(cantidad))
                {
                    cantidad = "0";
                }

                ViewBag.msg = "M1";

                Activo amb = new Activo { Id = Idmod, Nombre = nombre.ToUpper(), Cantidad = Int32.Parse(cantidad), FechaRegistro = DateTime.Today };

                activoService.ModificarActivo(amb);

            }
            catch (Exception)
            {
                ViewBag.msg = "M4";
                return PartialView("_ModificarActivo");
            }

            return PartialView("_ModificarActivo");
        }

        [HttpGet]
        public ActionResult ReporteActividadesCulturales()
        {
            ViewBag.FechaHoy = FechaHoy();

            var result = eventoEnsayoService.ObtenerDetalleHorasEventoPorFecha(DateTime.Today, DateTime.Today.AddDays(5));
            
            var salas = ambienteService.ObtenerAmbientePorCriterio("");
            
            var contsalas = 0;

            var matriz = new String[salas.Count(), 6];
            var matriz2 = new String[salas.Count(), 6];

            foreach (var item in salas)
            {
                matriz[contsalas, 0] = item.Nombre;
                matriz2[contsalas, 0] = item.Nombre;
                contsalas++;
            }

            var nombredias = new String[5];

            for (int i = 0; i < 5; i++)
            {
                nombredias[i] = OBtenerNombreDia(DateTime.Today, i);
            }

            ViewBag.nombredias = nombredias;
            ViewBag.contdias = nombredias.Count();

            foreach (var item in result)
            {
                for (int i = 0; i < salas.Count(); i++)
                {
                    if (item.EventoEnsayo.Ambiente.Nombre == matriz[i, 0])
                    {
                        if (item.FechaInicio.Day == DateTime.Today.AddDays(0).Day)
                        {
                            matriz[i, 1] = matriz[i, 1] + "<b>Actividad:  " + item.EventoEnsayo.NombreActividad + " </b> <br />Encargado: " + item.EventoEnsayo.InstitucionEncargada + " <br /> Hora Inicio: " + item.HoraInicioMostrar + " <br /> Hora Fin: " + item.HoraFinMostrar + "<br /> ";
                            matriz2[i, 1] = matriz2[i, 1] + "Actividad:  " + item.EventoEnsayo.NombreActividad + " \n Encargado: " + item.EventoEnsayo.InstitucionEncargada + " \n Hora Inicio: " + item.HoraInicioMostrar + " \n Hora Fin: " + item.HoraFinMostrar + "\n ";
                        }
                        else if (item.FechaInicio.Day == DateTime.Today.AddDays(1).Day)
                        {
                            matriz[i, 2] = matriz[i, 2] + "<b>Actividad:  " + item.EventoEnsayo.NombreActividad + " </b> <br />Encargado: " + item.EventoEnsayo.InstitucionEncargada + " <br /> Hora Inicio: " + item.HoraInicioMostrar + " <br /> Hora Fin: " + item.HoraFinMostrar + "<br /> ";
                            matriz2[i, 2] = matriz2[i, 2] + "Actividad:  " + item.EventoEnsayo.NombreActividad + " \n Encargado: " + item.EventoEnsayo.InstitucionEncargada + " \n Hora Inicio: " + item.HoraInicioMostrar + " \n Hora Fin: " + item.HoraFinMostrar + "\n ";
                        }
                        else if (item.FechaInicio.Day == DateTime.Today.AddDays(2).Day)
                        {
                            matriz[i, 3] = matriz[i, 3] + "<b>Actividad:  " + item.EventoEnsayo.NombreActividad + " </b> <br />Encargado: " + item.EventoEnsayo.InstitucionEncargada + " <br /> Hora Inicio: " + item.HoraInicioMostrar + " <br /> Hora Fin: " + item.HoraFinMostrar + "<br /> ";
                            matriz2[i, 3] = matriz2[i, 3] + "Actividad:  " + item.EventoEnsayo.NombreActividad + " \n Encargado: " + item.EventoEnsayo.InstitucionEncargada + " \n Hora Inicio: " + item.HoraInicioMostrar + " \n Hora Fin: " + item.HoraFinMostrar + "\n ";
                        }
                        else if (item.FechaInicio.Day == DateTime.Today.AddDays(3).Day)
                        {
                            matriz[i, 4] = matriz[i, 4] + "<b>Actividad:  " + item.EventoEnsayo.NombreActividad + " </b> <br />Encargado: " + item.EventoEnsayo.InstitucionEncargada + " <br /> Hora Inicio: " + item.HoraInicioMostrar + " <br /> Hora Fin: " + item.HoraFinMostrar + "<br /> ";
                            matriz2[i, 4] = matriz2[i, 4] + "Actividad:  " + item.EventoEnsayo.NombreActividad + " \n Encargado: " + item.EventoEnsayo.InstitucionEncargada + " \n Hora Inicio: " + item.HoraInicioMostrar + " \n Hora Fin: " + item.HoraFinMostrar + "\n ";
                        }
                        else if (item.FechaInicio.Day == DateTime.Today.AddDays(4).Day)
                        {
                            matriz[i, 5] = matriz[i, 5] + "<b>Actividad:  " + item.EventoEnsayo.NombreActividad + " </b> <br />Encargado: " + item.EventoEnsayo.InstitucionEncargada + " <br /> Hora Inicio: " + item.HoraInicioMostrar + " <br /> Hora Fin: " + item.HoraFinMostrar + "<br /> ";
                            matriz2[i, 5] = matriz2[i, 5] + "Actividad:  " + item.EventoEnsayo.NombreActividad + "\n Encargado: " + item.EventoEnsayo.InstitucionEncargada + " \n Hora Inicio: " + item.HoraInicioMostrar + " \n Hora Fin: " + item.HoraFinMostrar + "\n ";
                        }
                    }
                }
            }

            ViewBag.detalle = matriz;
            ViewBag.salas = salas.Count();
            ViewBag.nombresalas = salas;

            return View(result);
        }

        [HttpGet]
        public ActionResult BuscarEventoReporte(String fechabuscar, String fechafinbuscar, String salas)
        {
            String[] sala = salas.Split(',');

            var Fechainicial = DateTime.Parse(fechabuscar);
            var Fechafinal = DateTime.Parse(fechafinbuscar);

            var dias = Int32.Parse((Fechafinal - Fechainicial).TotalDays + "") + 1;

            var result = eventoEnsayoService.ObtenerDetalleHorasEventoPorFecha(Fechainicial, Fechafinal.AddHours(23.59));

            var ambientes = ambienteService.ObtenerAmbientePorCriterio("");

            var contsalas = 0;

            if (dias > 6)
            {
                dias = 6;
            }

            var nombredias = new String[dias];
            
            for (int i = 0; i < dias; i++)
            {
                nombredias[i] = OBtenerNombreDia(Fechainicial, i);
            }

            ViewBag.nombredias = nombredias;
            ViewBag.contdias = nombredias.Count();

            var matriz = new String[sala.Count(), dias + 1];

            foreach (var item in ambientes)
            {
                for (int i = 0; i < sala.Count(); i++)
                {
                    if (item.Id == Int32.Parse(sala[i]))
                    {
                        matriz[contsalas, 0] = item.Nombre;
                        contsalas++;
                        break;
                    }
                }
            }

            foreach (var item in result)
            {
                for (int i = 0; i < sala.Count(); i++)
                {
                    if (item.EventoEnsayo.Ambiente.Nombre == matriz[i, 0])
                    {
                        var requerimientos = "";
                        var contreq = item.EventoEnsayo.DetalleRequerimientos.Count;

                        foreach (var req in item.EventoEnsayo.DetalleRequerimientos)
                        {
                            requerimientos = requerimientos + "<br />" + req.Activo.Nombre + ": " + req.Cantidad;
                        }
                        for (int j = 0; j < dias; j++)
                        {
                            if (item.FechaInicio.Day == DateTime.Parse(fechabuscar).AddDays(j).Day)
                            {
                                if (item.EventoEnsayo.Evento)
                                {
                                    if (contreq > 0)
                                    {
                                        matriz[i, j + 1] = matriz[i, j + 1] + "<b>ACTIVIDAD: " + item.EventoEnsayo.NombreActividad + "</b> <br />ENCARGADO: " + item.EventoEnsayo.InstitucionEncargada + " <br />" + item.HoraInicioMostrar + " - " + item.HoraFinMostrar + "<br />REQUERIMIENTOS: <br />" + requerimientos + "<br /><br />";
                                    }
                                    else
                                    {
                                        matriz[i, j + 1] = matriz[i, j + 1] + "<b>ACTIVIDAD: " + item.EventoEnsayo.NombreActividad + "</b> <br />ENCARGADO: " + item.EventoEnsayo.InstitucionEncargada + " <br />" + item.HoraInicioMostrar + " - " + item.HoraFinMostrar + "<br /><br />";
                                    }
                                }
                                else
                                {
                                    if (contreq > 0)
                                    {
                                        matriz[i, j + 1] = matriz[i, j + 1] + "<b>ENSAYO: " + item.EventoEnsayo.NombreActividad + "</b> <br />ENCARGADO: " + item.EventoEnsayo.InstitucionEncargada + " <br />" + item.HoraInicioMostrar + " - " + item.HoraFinMostrar + "<br />REQUERIMIENTOS:" + requerimientos + "<br /><br />";
                                    }
                                    else
                                    {
                                        matriz[i, j + 1] = matriz[i, j + 1] + "<b>ENSAYO: " + item.EventoEnsayo.NombreActividad + "</b> <br />ENCARGADO: " + item.EventoEnsayo.InstitucionEncargada + " <br />" + item.HoraInicioMostrar + " - " + item.HoraFinMostrar + "<br /><br />";
                                    }

                                }

                            }
                        }
                    }
                }
            }

            ViewBag.detalle = matriz;
            ViewBag.salas = sala.Count();
            ViewBag.fechabuscar = fechabuscar;
            

            return PartialView("_BuscarEventoReporte");
        }

        [HttpPost]
        public ActionResult GenerateDocument(String FechaIni, String FechaFin, String[] salas, String Formato)
        {
            if (Formato == "Excel")
            {
                var Fechainicial = DateTime.Parse(FechaIni);
                var Fechafinal = DateTime.Parse(FechaFin);

                var dias = Int32.Parse((Fechafinal - Fechainicial).TotalDays + "") + 1;

                var result = eventoEnsayoService.ObtenerDetalleHorasEventoPorFecha(Fechainicial, Fechafinal.AddHours(23.59));

                var ambientes = ambienteService.ObtenerAmbientePorCriterio("");

                var contsalas = 0;

                if (dias > 31)
                {
                    dias = 31;
                }

                var matriz = new String[salas.Count(), dias + 1];

                foreach (var item in ambientes)
                {
                    for (int i = 0; i < salas.Count(); i++)
                    {
                        if (item.Id == Int32.Parse(salas[i]))
                        {
                            matriz[contsalas, 0] = item.Nombre;
                            contsalas++;
                            break;
                        }
                    }
                }

                foreach (var item in result)
                {
                    for (int i = 0; i < salas.Count(); i++)
                    {
                        if (item.EventoEnsayo.Ambiente.Nombre == matriz[i, 0])
                        {
                            var requerimientos = "";
                            var contreq = item.EventoEnsayo.DetalleRequerimientos.Count;

                            foreach (var req in item.EventoEnsayo.DetalleRequerimientos)
                            {
                                requerimientos = requerimientos + "\n" + req.Activo.Nombre + ": " + req.Cantidad;
                            }
                            for (int j = 0; j < dias; j++)
                            {
                                if (item.FechaInicio.Day == DateTime.Parse(FechaIni).AddDays(j).Day)
                                {
                                    if (item.EventoEnsayo.Evento)
                                    {
                                        if (contreq > 0)
                                        {
                                            matriz[i, j + 1] = matriz[i, j + 1] + "ACTIVIDAD: " + item.EventoEnsayo.NombreActividad + "\nENCARGADO: " + item.EventoEnsayo.InstitucionEncargada + " \n" + item.HoraInicioMostrar + " - " + item.HoraFinMostrar + "\nREQUERIMIENTOS:" + requerimientos + "\n\n";
                                        }
                                        else
                                        {
                                            matriz[i, j + 1] = matriz[i, j + 1] + "ACTIVIDAD: " + item.EventoEnsayo.NombreActividad + "\nENCARGADO: " + item.EventoEnsayo.InstitucionEncargada + " \n" + item.HoraInicioMostrar + " - " + item.HoraFinMostrar + "\n\n";
                                        }
                                    }
                                    else
                                    {
                                        if (contreq > 0)
                                        {
                                            matriz[i, j + 1] = matriz[i, j + 1] + "ENSAYO: " + item.EventoEnsayo.NombreActividad + "\nENCARGADO: " + item.EventoEnsayo.InstitucionEncargada + " \n" + item.HoraInicioMostrar + " - " + item.HoraFinMostrar + "\nREQUERIMIENTOS:" + requerimientos + "\n\n";
                                        }
                                        else
                                        {
                                            matriz[i, j + 1] = matriz[i, j + 1] + "ENSAYO: " + item.EventoEnsayo.NombreActividad + "\nENCARGADO: " + item.EventoEnsayo.InstitucionEncargada + " \n" + item.HoraInicioMostrar + " - " + item.HoraFinMostrar + "\n\n";
                                        }
                                        
                                    }
                                    
                                }
                            }
                        }
                    }
                }

                using (ExcelEngine excelEngine = new ExcelEngine())
                {
                    excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2013;
                    
                    IWorkbook workbook = excelEngine.Excel.Workbooks.Create(1);

                    IWorksheet worksheet = workbook.Worksheets[0];
                    worksheet.Name = "DDC-Cajamarca";
                    worksheet.Range["B1:" + OBtenerNombreCelda(dias+1) + "1"].ColumnWidth = 21;
                    
                    for (int i = 0; i < contsalas; i++)
                    {
                        for (int j = 0; j < dias + 1; j++)
                        {
                            worksheet.Range[OBtenerNombreCelda(j + 1) + (i + 2)].Text = matriz[i, j];
                            worksheet.Range[OBtenerNombreCelda(j + 1) + (i + 2)].CellStyle.Font.Size = 8;
                            worksheet.Range[OBtenerNombreCelda(j + 1) + (i + 2)].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                            worksheet.Range[OBtenerNombreCelda(j + 1) + (i + 2)].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;
                        }

                        worksheet.Range["A" + (i + 2)].CellStyle.Font.Bold = true;
                        worksheet.Range["A" + (i + 2) + ":" + OBtenerNombreCelda(dias + 1) + "" + (i + 2)].BorderAround(ExcelLineStyle.Medium);
                        worksheet.Range["A" + (i + 2) + ":" + OBtenerNombreCelda(dias + 1) + "" + (i + 2)].BorderInside(ExcelLineStyle.Medium);
                        
                    }
                    
                    worksheet.Range["A1"].Text = "Sala";
                    worksheet.Range["A1"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                    worksheet.Range["A1"].BorderAround(ExcelLineStyle.Medium);
                    worksheet.Range["A1"].CellStyle.Font.Bold = true;

                    for (int i = 0; i < dias; i++)
                    {
                        worksheet.Range[OBtenerNombreCelda(i + 2) + "1"].Text = OBtenerNombreDia(DateTime.Parse(FechaIni), i);
                        worksheet.Range[OBtenerNombreCelda(i + 2) + "1"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                        worksheet.Range[OBtenerNombreCelda(i + 2) + "1"].BorderAround(ExcelLineStyle.Medium);
                        worksheet.Range[OBtenerNombreCelda(i + 2) + "1"].CellStyle.Font.Bold = true;
                    }
                    
                    for (int i = 0; i < contsalas; i++)
                    {
                        worksheet.Range["A" + (i + 2)].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;
                        worksheet.Range["A" + (i + 2)].WrapText = true;
                        worksheet.Range["B" + (i + 2)+ ":" + OBtenerNombreCelda(dias + 1) + (i + 2)].CellStyle.VerticalAlignment = ExcelVAlign.VAlignTop;
                    }

                    worksheet.Range["B2"].FreezePanes();
                    worksheet.PageSetup.PrintTitleColumns = "$1:$1";

                    worksheet.PageSetup.Orientation = ExcelPageOrientation.Landscape;
                    worksheet.PageSetup.LeftMargin = 0.2519685;
                    worksheet.PageSetup.RightMargin = 0.2519685;
                    worksheet.PageSetup.TopMargin = 0.2519685;
                    worksheet.PageSetup.BottomMargin = 0.2519685;
                    worksheet.PageSetup.HeaderMargin = 0.2992126;
                    worksheet.PageSetup.FooterMargin = 0.2992126;

                    //Save the workbook to disk in xlsx format.
                    workbook.SaveAs("ReporteActividades"+DateTime.Today.Day+"-"+DateTime.Today.Month + "-"+ DateTime.Today.Year + ".xlsx", HttpContext.ApplicationInstance.Response, ExcelDownloadType.Open);
                }
            }

            return View();
        }

        public class EventoCalendar
        {
            public string title { get; set; }
            public string start { get; set; }
            public string end { get; set; }
            public bool allDay { get; set; }
            public string color { get; set; }
            public string description { get; set; }
            public int data { get; set; }
        };

        //public JsonResult DataEventosJSON()
        //{
        //    var Eventos = eventoEnsayoService.ObtenerDetalleHorasEventoPorCriterio(0, false);

        //    //var tamb = Eventos.LongCount();

        //    //var contador = 0;

        //    //var titulo = new String[tamb];
        //    //var idEvento = new Int32[tamb];
        //    //var inicio = new DateTime[tamb];
        //    //var fin = new DateTime[tamb];
        //    //var tododia = new Boolean[tamb];
        //    //var color = new String[tamb];
        //    //var descripcion = new String[tamb];

        //    //foreach (var item in Eventos)
        //    //{
        //    //    var detallerequerimientos = "";

        //    //    foreach (var itemreq in item.EventoEnsayo.DetalleRequerimientos)
        //    //    {
        //    //        detallerequerimientos = detallerequerimientos + " " + itemreq.Activo.Nombre + " - " + itemreq.Cantidad + " <br />";
        //    //    }

        //    //    idEvento[contador] = item.Id;

        //    //    if (item.EventoEnsayo.Evento)
        //    //    {
        //    //        titulo[contador] = item.EventoEnsayo.Ambiente.Nombre + ": " + item.EventoEnsayo.NombreActividad + " - " + item.EventoEnsayo.InstitucionEncargada;
        //    //    }
        //    //    else
        //    //    {
        //    //        titulo[contador] = item.EventoEnsayo.Ambiente.Nombre + ": ENSAYO - " + item.EventoEnsayo.NombreActividad + " - " + item.EventoEnsayo.InstitucionEncargada;
        //    //    }

        //    //    if (item.FechaFin.Date != item.FechaInicio.Date)
        //    //    {
        //    //        inicio[contador] = new DateTime(item.FechaInicio.Year, item.FechaInicio.Month, item.FechaInicio.Day, item.FechaInicio.Hour, item.FechaInicio.Minute, item.FechaInicio.Millisecond);
        //    //        fin[contador] = new DateTime(item.FechaFin.Year, item.FechaFin.Month, item.FechaFin.Day + 1, item.FechaFin.Hour, item.FechaFin.Minute, item.FechaFin.Millisecond);
        //    //    }
        //    //    else
        //    //    {
        //    //        inicio[contador] = new DateTime(item.FechaInicio.Year, item.FechaInicio.Month, item.FechaInicio.Day, item.FechaInicio.Hour, item.FechaInicio.Minute, item.FechaInicio.Millisecond);
        //    //        fin[contador] = new DateTime(item.FechaFin.Year, item.FechaFin.Month, item.FechaFin.Day, item.FechaFin.Hour, item.FechaFin.Minute, item.FechaFin.Millisecond);
        //    //    }

        //    //    tododia[contador] = item.EventoEnsayo.TodoDia;
        //    //    color[contador] = item.EventoEnsayo.Ambiente.ColorNombre;
        //    //    descripcion[contador] = "<b>Requerimientos:</b> <br />" + detallerequerimientos + "<b>Información Adicional:</b> <br />" + item.EventoEnsayo.InformacionAdicional;

        //    //    contador++;
        //    //}

        //    List<EventoCalendar> datos = new List<EventoCalendar>();

        //    foreach (var item in Eventos)
        //    {
        //        var titulo = "";
        //        var inicio = "";
        //        var fin = "";

        //        if (item.EventoEnsayo.Evento)
        //        {
        //            titulo = item.EventoEnsayo.Ambiente.Nombre + ": " + item.EventoEnsayo.NombreActividad + " - " + item.EventoEnsayo.InstitucionEncargada;
        //        }
        //        else
        //        {
        //            titulo = item.EventoEnsayo.Ambiente.Nombre + ": ENSAYO - " + item.EventoEnsayo.NombreActividad + " - " + item.EventoEnsayo.InstitucionEncargada;
        //        }
        //        if (item.FechaFin.Date != item.FechaInicio.Date)
        //        {
        //            if (item.FechaInicio.Day < 9)
        //            {
        //                inicio = item.FechaInicio.Year + "-" + item.FechaInicio.Month + "-0" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;
        //                fin = item.FechaFin.Year + "-" + item.FechaFin.Month + "-0" + (item.FechaFin.AddDays(1).Day) + "T" + item.FechaFin.TimeOfDay;
        //            }
        //            else if (item.FechaInicio.Day == 9)
        //            {
        //                inicio = item.FechaInicio.Year + "-" + item.FechaInicio.Month + "-0" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;
        //                fin = item.FechaFin.Year + "-" + item.FechaFin.Month + "-" + (item.FechaFin.AddDays(1).Day + 1) + "T" + item.FechaFin.TimeOfDay;
        //            }
        //            else
        //            {
        //                inicio = item.FechaInicio.Year + "-" + item.FechaInicio.Month + "-" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;
        //                fin = item.FechaFin.Year + "-" + item.FechaFin.Month + "-" + (item.FechaFin.AddDays(1).Day + 1) + "T" + item.FechaFin.TimeOfDay;
        //            }

                    
        //            //inicio = item.FechaInicio.Year, item.FechaInicio.Month, item.FechaInicio.Day, item.FechaInicio.Hour, item.FechaInicio.Minute, item.FechaInicio.Millisecond;
        //            //fin = item.FechaFin.Year, item.FechaFin.Month, item.FechaFin.Day + 1, item.FechaFin.Hour, item.FechaFin.Minute, item.FechaFin.Millisecond;
        //        }
        //        else
        //        {
        //            if (item.FechaInicio.Day < 10)
        //            {
        //                inicio = item.FechaInicio.Year + "-" + item.FechaInicio.Month + "-0" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;
        //                fin = item.FechaFin.Year + "-" + item.FechaFin.Month + "-0" + item.FechaFin.Day + "T" + item.FechaFin.TimeOfDay;
        //            }
        //            else if (item.FechaInicio.Day == 9)
        //            {
        //                inicio = item.FechaInicio.Year + "-" + item.FechaInicio.Month + "-0" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;
        //                fin = item.FechaFin.Year + "-" + item.FechaFin.Month + "-" + item.FechaFin.Day + "T" + item.FechaFin.TimeOfDay;
        //            }
        //            else
        //            {
        //                inicio = item.FechaInicio.Year + "-" + item.FechaInicio.Month + "-" + item.FechaInicio.Day + "T" + item.FechaInicio.TimeOfDay;
        //                fin = item.FechaFin.Year + "-" + item.FechaFin.Month + "-" + item.FechaFin.Day + "T" + item.FechaFin.TimeOfDay;

        //            }
        //            //inicio = new DateTime(item.FechaInicio.Year, item.FechaInicio.Month, item.FechaInicio.Day, item.FechaInicio.Hour, item.FechaInicio.Minute, item.FechaInicio.Millisecond);
        //            //fin = new DateTime(item.FechaFin.Year, item.FechaFin.Month, item.FechaFin.Day, item.FechaFin.Hour, item.FechaFin.Minute, item.FechaFin.Millisecond);
        //        }

        //        var detallerequerimientos = "";

        //        foreach (var itemreq in item.EventoEnsayo.DetalleRequerimientos)
        //        {
        //            detallerequerimientos = detallerequerimientos + " " + itemreq.Activo.Nombre + " - " + itemreq.Cantidad + " <br />";
        //        }

        //        EventoCalendar x = new EventoCalendar {
        //            title = titulo,
        //            start = inicio,
        //            end = fin,
        //            allDay = item.EventoEnsayo.TodoDia,
        //            color = item.EventoEnsayo.Ambiente.ColorNombre,
        //            description = "<b>Requerimientos:</b> <br />" + detallerequerimientos + "<b>Información Adicional:</b> <br />" + item.EventoEnsayo.InformacionAdicional,
        //            id = item.IdEventoEnsayo
        //        };
        //        datos.Add(x);
        //    }

        //    return Json(datos, JsonRequestBehavior.AllowGet);
        //}

        private string DataEventosAutocomplete(DateTime Fechaini, DateTime FechaFin)
        {
            var eventos = eventoEnsayoService.ObtenerDetalleHorasEventoPorFecha(Fechaini, FechaFin);

            var eventosarray = "";

            foreach (var item in eventos)
            {
                eventosarray = eventosarray + "'" + item.EventoEnsayo.NombreActividad + "'" + ",";
            }

            eventosarray = "[" + eventosarray + "'" + "'" + "]";

            eventosarray = eventosarray.Replace("'", char.ConvertFromUtf32(34));

            return eventosarray;
        }

        private string OBtenerNombreCelda(Int32 celda)
        {
            var nombrecelda = "";

            switch (celda)
            {
                case 1:
                    nombrecelda = "A";
                    break;
                case 2:
                    nombrecelda = "B";
                    break;
                case 3:
                    nombrecelda = "C";
                    break;
                case 4:
                    nombrecelda = "D";
                    break;
                case 5:
                    nombrecelda = "E";
                    break;
                case 6:
                    nombrecelda = "F";
                    break;
                case 7:
                    nombrecelda = "G";
                    break;
                case 8:
                    nombrecelda = "H";
                    break;
                case 9:
                    nombrecelda = "I";
                    break;
                case 10:
                    nombrecelda = "J";
                    break;
                case 11:
                    nombrecelda = "K";
                    break;
                case 12:
                    nombrecelda = "L";
                    break;
                case 13:
                    nombrecelda = "M";
                    break;
                case 14:
                    nombrecelda = "N";
                    break;
                case 15:
                    nombrecelda = "O";
                    break;
                case 16:
                    nombrecelda = "P";
                    break;
                case 17:
                    nombrecelda = "Q";
                    break;
                case 18:
                    nombrecelda = "R";
                    break;
                case 19:
                    nombrecelda = "S";
                    break;
                case 20:
                    nombrecelda = "T";
                    break;
                case 21:
                    nombrecelda = "U";
                    break;
                case 22:
                    nombrecelda = "V";
                    break;
                case 23:
                    nombrecelda = "W";
                    break;
                case 24:
                    nombrecelda = "X";
                    break;
                case 25:
                    nombrecelda = "Y";
                    break;
                case 26:
                    nombrecelda = "Z";
                    break;
                case 27:
                    nombrecelda = "AA";
                    break;
                case 28:
                    nombrecelda = "AB";
                    break;
                case 29:
                    nombrecelda = "AC";
                    break;
                case 30:
                    nombrecelda = "AD";
                    break;
                case 31:
                    nombrecelda = "AE";
                    break;
                case 32:
                    nombrecelda = "AF";
                    break;
                default:
                    nombrecelda = "AG";
                    break;
            }

            return nombrecelda;
        }

        private string OBtenerNombreDia(DateTime fecha, Int32 diaextra)
        {
            var dia = fecha.AddDays(diaextra).DayOfWeek;
            var diaespañol = "";
            fecha = fecha.AddDays(diaextra);

            switch (dia)
            {
                case DayOfWeek.Sunday:
                    diaespañol = "Domingo";
                    break;
                case DayOfWeek.Monday:
                    diaespañol = "Lunes";
                    break;
                case DayOfWeek.Tuesday:
                    diaespañol = "Martes";
                    break;
                case DayOfWeek.Wednesday:
                    diaespañol = "Miercoles";
                    break;
                case DayOfWeek.Thursday:
                    diaespañol = "Jueves";
                    break;
                case DayOfWeek.Friday:
                    diaespañol = "Viernes";
                    break;
                case DayOfWeek.Saturday:
                    diaespañol = "Sabado";
                    break;
                default:
                    diaespañol = "";
                    break;
            }

            return diaespañol + " " + fecha.Day + " /" + fecha.Month + " /" + fecha.Year;
        }

        private string FechaHoy()
        {
            var fecha = "";

            if (DateTime.Now.Month < 10)
            {
                if (DateTime.Now.Day < 10)
                {
                    fecha = "0" + DateTime.Now.Day + "/0" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                }
                else
                {
                    fecha = DateTime.Now.Day + "/0" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                }

            }
            else
            {
                if (DateTime.Now.Day < 10)
                {
                    fecha = "0" + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                }
                else
                {
                    fecha = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                }
            }

            return fecha;
        }
    }
}