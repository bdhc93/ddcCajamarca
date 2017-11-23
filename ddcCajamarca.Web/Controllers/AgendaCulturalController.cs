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
            //ViewBag.Activos = activoService.ObtenerActivoPorCriterio("");

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

            var tamb = Eventos.LongCount();

            var contador = 0;

            var titulo = new String[tamb];
            var idEvento = new Int32[tamb];
            var inicio = new DateTime[tamb];
            var fin = new DateTime[tamb];
            var tododia = new Boolean[tamb];
            var color = new String[tamb];
            var descripcion = new String[tamb];

            foreach (var item in Eventos)
            {
                var detallerequerimientos = "";

                foreach (var itemreq in item.EventoEnsayo.DetalleRequerimientos)
                {
                    detallerequerimientos = detallerequerimientos + " " + itemreq.Activo.Nombre + " - " + itemreq.Cantidad + " <br />";
                }

                idEvento[contador] = item.Id;

                if (item.EventoEnsayo.Evento)
                {
                    titulo[contador] = item.EventoEnsayo.Ambiente.Nombre + ": " + item.EventoEnsayo.NombreActividad + " - " + item.EventoEnsayo.InstitucionEncargada;
                }
                else
                {
                    titulo[contador] = item.EventoEnsayo.Ambiente.Nombre + ": ENSAYO - " + item.EventoEnsayo.NombreActividad + " - " + item.EventoEnsayo.InstitucionEncargada;
                }

                if (item.FechaFin.Date != item.FechaInicio.Date)
                {
                    inicio[contador] = new DateTime(item.FechaInicio.Year, item.FechaInicio.Month, item.FechaInicio.Day, item.FechaInicio.Hour, item.FechaInicio.Minute, item.FechaInicio.Millisecond);
                    fin[contador] = new DateTime(item.FechaFin.Year, item.FechaFin.Month, item.FechaFin.Day + 1, item.FechaFin.Hour, item.FechaFin.Minute, item.FechaFin.Millisecond);
                }
                else
                {
                    inicio[contador] = new DateTime(item.FechaInicio.Year, item.FechaInicio.Month, item.FechaInicio.Day, item.FechaInicio.Hour, item.FechaInicio.Minute, item.FechaInicio.Millisecond);
                    fin[contador] = new DateTime(item.FechaFin.Year, item.FechaFin.Month, item.FechaFin.Day, item.FechaFin.Hour, item.FechaFin.Minute, item.FechaFin.Millisecond);
                }

                tododia[contador] = item.EventoEnsayo.TodoDia;
                color[contador] = item.EventoEnsayo.Ambiente.ColorNombre;
                descripcion[contador] = "<b>Requerimientos:</b> <br />" + detallerequerimientos + "<b>Información Adicional:</b> <br />" + item.EventoEnsayo.InformacionAdicional;

                contador++;
            }

            ViewBag.titulo = titulo;
            ViewBag.IdEvento = idEvento;
            ViewBag.inicio = inicio;
            ViewBag.fin = fin;
            ViewBag.tododia = tododia;
            ViewBag.color = color;
            ViewBag.descripcion = descripcion;

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

                var tamb = Eventos.LongCount();

                var contador = 0;

                var titulo = new String[tamb];
                var idEvento = new Int32[tamb];
                var inicio = new DateTime[tamb];
                var fin = new DateTime[tamb];
                var tododia = new Boolean[tamb];
                var color = new String[tamb];
                var descripcion = new String[tamb];

                foreach (var item in Eventos)
                {
                    var detallerequerimientos = "";

                    foreach (var itemreq in item.EventoEnsayo.DetalleRequerimientos)
                    {
                        detallerequerimientos = detallerequerimientos + " " + itemreq.Activo.Nombre + " - " + itemreq.Cantidad + " <br />";
                    }

                    idEvento[contador] = item.Id;

                    if (item.EventoEnsayo.Evento)
                    {
                        titulo[contador] = item.EventoEnsayo.Ambiente.Nombre + ": " + item.EventoEnsayo.NombreActividad + " - " + item.EventoEnsayo.InstitucionEncargada;
                    }
                    else
                    {
                        titulo[contador] = item.EventoEnsayo.Ambiente.Nombre + ": ENSAYO - " + item.EventoEnsayo.NombreActividad + " - " + item.EventoEnsayo.InstitucionEncargada;
                    }

                    if (item.FechaFin.Date != item.FechaInicio.Date)
                    {
                        inicio[contador] = new DateTime(item.FechaInicio.Year, item.FechaInicio.Month, item.FechaInicio.Day, item.FechaInicio.Hour, item.FechaInicio.Minute, item.FechaInicio.Millisecond);
                        fin[contador] = new DateTime(item.FechaFin.Year, item.FechaFin.Month, item.FechaFin.Day + 1, item.FechaFin.Hour, item.FechaFin.Minute, item.FechaFin.Millisecond);
                    }
                    else
                    {
                        inicio[contador] = new DateTime(item.FechaInicio.Year, item.FechaInicio.Month, item.FechaInicio.Day, item.FechaInicio.Hour, item.FechaInicio.Minute, item.FechaInicio.Millisecond);
                        fin[contador] = new DateTime(item.FechaFin.Year, item.FechaFin.Month, item.FechaFin.Day, item.FechaFin.Hour, item.FechaFin.Minute, item.FechaFin.Millisecond);
                    }

                    tododia[contador] = item.EventoEnsayo.TodoDia;
                    color[contador] = item.EventoEnsayo.Ambiente.ColorNombre;
                    descripcion[contador] = "<b>Requerimientos:</b> <br />" + detallerequerimientos + "<b>Información Adicional:</b> <br />" + item.EventoEnsayo.InformacionAdicional;

                    contador++;
                }

                ViewBag.IdEvento = idEvento;
                ViewBag.titulo = titulo;
                ViewBag.inicio = inicio;
                ViewBag.fin = fin;
                ViewBag.tododia = tododia;
                ViewBag.color = color;
                ViewBag.descripcion = descripcion;

                return PartialView("_MostrarCalendario");
            }
            else
            {
                var Eventos = eventoEnsayoService.ObtenerDetalleHorasEventoPorCriterio(0, false);

                var tamb = Eventos.LongCount();

                var contador = 0;

                var titulo = new String[tamb];
                var idEvento = new Int32[tamb];
                var inicio = new DateTime[tamb];
                var fin = new DateTime[tamb];
                var tododia = new Boolean[tamb];
                var color = new String[tamb];
                var descripcion = new String[tamb];

                foreach (var item in Eventos)
                {
                    var detallerequerimientos = "";

                    foreach (var itemreq in item.EventoEnsayo.DetalleRequerimientos)
                    {
                        detallerequerimientos = detallerequerimientos + " " + itemreq.Activo.Nombre + " - " + itemreq.Cantidad + " <br />";
                    }

                    idEvento[contador] = item.Id;

                    if (item.EventoEnsayo.Evento)
                    {
                        titulo[contador] = item.EventoEnsayo.Ambiente.Nombre + ": " + item.EventoEnsayo.NombreActividad + " - " + item.EventoEnsayo.InstitucionEncargada;
                    }
                    else
                    {
                        titulo[contador] = item.EventoEnsayo.Ambiente.Nombre + ": ENSAYO - " + item.EventoEnsayo.NombreActividad + " - " + item.EventoEnsayo.InstitucionEncargada;
                    }

                    if (item.FechaFin.Date != item.FechaInicio.Date)
                    {
                        inicio[contador] = new DateTime(item.FechaInicio.Year, item.FechaInicio.Month, item.FechaInicio.Day, item.FechaInicio.Hour, item.FechaInicio.Minute, item.FechaInicio.Millisecond);
                        fin[contador] = new DateTime(item.FechaFin.Year, item.FechaFin.Month, item.FechaFin.Day + 1, item.FechaFin.Hour, item.FechaFin.Minute, item.FechaFin.Millisecond);
                    }
                    else
                    {
                        inicio[contador] = new DateTime(item.FechaInicio.Year, item.FechaInicio.Month, item.FechaInicio.Day, item.FechaInicio.Hour, item.FechaInicio.Minute, item.FechaInicio.Millisecond);
                        fin[contador] = new DateTime(item.FechaFin.Year, item.FechaFin.Month, item.FechaFin.Day, item.FechaFin.Hour, item.FechaFin.Minute, item.FechaFin.Millisecond);
                    }

                    tododia[contador] = item.EventoEnsayo.TodoDia;
                    color[contador] = item.EventoEnsayo.Ambiente.ColorNombre;
                    descripcion[contador] = "<b>Requerimientos:</b> <br />" + detallerequerimientos + "<b>Información Adicional:</b> <br />" + item.EventoEnsayo.InformacionAdicional;

                    contador++;
                }

                ViewBag.IdEvento = idEvento;
                ViewBag.titulo = titulo;
                ViewBag.inicio = inicio;
                ViewBag.fin = fin;
                ViewBag.tododia = tododia;
                ViewBag.color = color;
                ViewBag.descripcion = descripcion;

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

                //color = ObtenerCodigoColor(color);

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
        public ActionResult OBtenerEventoPorId(Int32 Id)
        {
            try
            {
                var result = eventoEnsayoService.ObtenerDetalleHorasEventoPorIdEvento(Id);
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
                //color = ObtenerCodigoColor(color);

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

            foreach (var item in result)
            {
                for (int i = 0; i < salas.Count(); i++)
                {
                    if (item.EventoEnsayo.Ambiente.Nombre == matriz[i, 0])
                    {
                        if (item.FechaInicio.Day == DateTime.Today.AddDays(0).Day)
                        {
                            //dia1.Add(item);
                            matriz[i, 1] = matriz[i, 1] + "<b>Actividad:  " + item.EventoEnsayo.NombreActividad + " </b> <br />Encargado: " + item.EventoEnsayo.InstitucionEncargada + " <br /> Hora Inicio: " + item.HoraInicioMostrar + " <br /> Hora Fin: " + item.HoraFinMostrar + "<br /> ";
                            matriz2[i, 1] = matriz2[i, 1] + "Actividad:  " + item.EventoEnsayo.NombreActividad + " \n Encargado: " + item.EventoEnsayo.InstitucionEncargada + " \n Hora Inicio: " + item.HoraInicioMostrar + " \n Hora Fin: " + item.HoraFinMostrar + "\n ";
                        }
                        else if (item.FechaInicio.Day == DateTime.Today.AddDays(1).Day)
                        {
                            //dia2.Add(item);
                            matriz[i, 2] = matriz[i, 2] + "<b>Actividad:  " + item.EventoEnsayo.NombreActividad + " </b> <br />Encargado: " + item.EventoEnsayo.InstitucionEncargada + " <br /> Hora Inicio: " + item.HoraInicioMostrar + " <br /> Hora Fin: " + item.HoraFinMostrar + "<br /> ";
                            matriz2[i, 2] = matriz2[i, 2] + "Actividad:  " + item.EventoEnsayo.NombreActividad + " \n Encargado: " + item.EventoEnsayo.InstitucionEncargada + " \n Hora Inicio: " + item.HoraInicioMostrar + " \n Hora Fin: " + item.HoraFinMostrar + "\n ";
                        }
                        else if (item.FechaInicio.Day == DateTime.Today.AddDays(2).Day)
                        {
                            //dia3.Add(item);
                            matriz[i, 3] = matriz[i, 3] + "<b>Actividad:  " + item.EventoEnsayo.NombreActividad + " </b> <br />Encargado: " + item.EventoEnsayo.InstitucionEncargada + " <br /> Hora Inicio: " + item.HoraInicioMostrar + " <br /> Hora Fin: " + item.HoraFinMostrar + "<br /> ";
                            matriz2[i, 3] = matriz2[i, 3] + "Actividad:  " + item.EventoEnsayo.NombreActividad + " \n Encargado: " + item.EventoEnsayo.InstitucionEncargada + " \n Hora Inicio: " + item.HoraInicioMostrar + " \n Hora Fin: " + item.HoraFinMostrar + "\n ";
                        }
                        else if (item.FechaInicio.Day == DateTime.Today.AddDays(3).Day)
                        {
                            //dia4.Add(item);
                            matriz[i, 4] = matriz[i, 4] + "<b>Actividad:  " + item.EventoEnsayo.NombreActividad + " </b> <br />Encargado: " + item.EventoEnsayo.InstitucionEncargada + " <br /> Hora Inicio: " + item.HoraInicioMostrar + " <br /> Hora Fin: " + item.HoraFinMostrar + "<br /> ";
                            matriz2[i, 4] = matriz2[i, 4] + "Actividad:  " + item.EventoEnsayo.NombreActividad + " \n Encargado: " + item.EventoEnsayo.InstitucionEncargada + " \n Hora Inicio: " + item.HoraInicioMostrar + " \n Hora Fin: " + item.HoraFinMostrar + "\n ";
                        }
                        else if (item.FechaInicio.Day == DateTime.Today.AddDays(4).Day)
                        {
                            //dia5.Add(item);
                            matriz[i, 5] = matriz[i, 5] + "<b>Actividad:  " + item.EventoEnsayo.NombreActividad + " </b> <br />Encargado: " + item.EventoEnsayo.InstitucionEncargada + " <br /> Hora Inicio: " + item.HoraInicioMostrar + " <br /> Hora Fin: " + item.HoraFinMostrar + "<br /> ";
                            matriz2[i, 5] = matriz2[i, 5] + "Actividad:  " + item.EventoEnsayo.NombreActividad + "\n Encargado: " + item.EventoEnsayo.InstitucionEncargada + " \n Hora Inicio: " + item.HoraInicioMostrar + " \n Hora Fin: " + item.HoraFinMostrar + "\n ";
                        }
                    }
                }
            }
            

            //using (ExcelEngine excelEngine = new ExcelEngine())
            //{
            //    //Set the default application version as Excel 2016.
            //    excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2013;

            //    //Create a workbook with a worksheet.
            //    IWorkbook workbook = excelEngine.Excel.Workbooks.Create(1);

            //    //Access first worksheet from the workbook instance.
            //    IWorksheet worksheet = workbook.Worksheets[0];

            //    worksheet.Range["B1:F1"].ColumnWidth = 40;

            //    //worksheet.Range["A1:C1"].AutofitColumns();

            //    //worksheet.Range["A2:A5"].AutofitRows();

            //    //Insert sample text into cell “A1”.
            //    //worksheet.Range["A1"].Text = "Hello " + "\n" + " World";

            //    worksheet.Range["A1"].Text = matriz2[9, 0];
            //    worksheet.Range["B1"].Text = matriz2[9, 1];
            //    worksheet.Range["C1"].Text = matriz2[9, 2];
            //    worksheet.Range["D1"].Text = matriz2[9, 3];
            //    worksheet.Range["E1"].Text = matriz2[9, 4];
            //    worksheet.Range["F1"].Text = matriz2[9, 5];

            //    worksheet.Range["A1"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;

            //    worksheet.Range["B1:F1"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignTop;

            //    //Save the workbook to disk in xlsx format.
            //    workbook.SaveAs("Sample.xlsx", HttpContext.ApplicationInstance.Response, ExcelDownloadType.Open);
            //}

            ViewBag.detalle = matriz;
            ViewBag.salas = salas.Count();
            ViewBag.nombresalas = salas;

            return View(result);
        }

        [HttpPost]
        public ActionResult GenerateDocument(String FechaIni, String FechaFin, String[] salas, String Formato)
        {
            if (Formato == "Excel")
            {
                var result = eventoEnsayoService.ObtenerDetalleHorasEventoPorFecha(DateTime.Parse(FechaIni), DateTime.Parse(FechaFin + " 23:59"));

                var ambientes = ambienteService.ObtenerAmbientePorCriterio("");

                var contsalas = 0;

                var matriz = new String[salas.Count(), 6];

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
                            if (item.FechaInicio.Day == DateTime.Parse(FechaIni).Day)
                            {
                                matriz[i, 1] = matriz[i, 1] + "Actividad: " + item.EventoEnsayo.NombreActividad + "\nEncargado: " + item.EventoEnsayo.InstitucionEncargada + " \nHora Inicio: " + item.HoraInicioMostrar + " \nHora Fin: " + item.HoraFinMostrar + "\n";
                            }
                            else if (item.FechaInicio.Day == DateTime.Parse(FechaIni).AddDays(1).Day)
                            {
                                matriz[i, 2] = matriz[i, 2] + "Actividad: " + item.EventoEnsayo.NombreActividad + "\nEncargado: " + item.EventoEnsayo.InstitucionEncargada + " \nHora Inicio: " + item.HoraInicioMostrar + " \nHora Fin: " + item.HoraFinMostrar + "\n";
                            }
                            else if (item.FechaInicio.Day == DateTime.Parse(FechaIni).AddDays(2).Day)
                            {
                                matriz[i, 3] = matriz[i, 3] + "Actividad: " + item.EventoEnsayo.NombreActividad + "\nEncargado: " + item.EventoEnsayo.InstitucionEncargada + " \nHora Inicio: " + item.HoraInicioMostrar + " \nHora Fin: " + item.HoraFinMostrar + "\n";
                            }
                            else if (item.FechaInicio.Day == DateTime.Parse(FechaIni).AddDays(3).Day)
                            {
                                matriz[i, 4] = matriz[i, 4] + "Actividad: " + item.EventoEnsayo.NombreActividad + "\nEncargado: " + item.EventoEnsayo.InstitucionEncargada + " \nHora Inicio: " + item.HoraInicioMostrar + " \nHora Fin: " + item.HoraFinMostrar + "\n";
                            }
                            else if (item.FechaInicio.Day == DateTime.Parse(FechaIni).AddDays(4).Day)
                            {
                                matriz[i, 5] = matriz[i, 5] + "Actividad: " + item.EventoEnsayo.NombreActividad + "\nEncargado: " + item.EventoEnsayo.InstitucionEncargada + " \nHora Inicio: " + item.HoraInicioMostrar + " \nHora Fin: " + item.HoraFinMostrar + "\n";
                            }
                        }
                    }
                }

                using (ExcelEngine excelEngine = new ExcelEngine())
                {
                    excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2013;
                    
                    IWorkbook workbook = excelEngine.Excel.Workbooks.Create(1);
                    
                    IWorksheet worksheet = workbook.Worksheets[0];

                    worksheet.Range["B1:F1"].ColumnWidth = 40;

                    //worksheet.Range["A1:C1"].AutofitColumns();

                    //worksheet.Range["A2:A5"].AutofitRows();

                    //Insert sample text into cell “A1”.
                    //worksheet.Range["A1"].Text = "Hello " + "\n" + " World";

                    for (int i = 0; i < contsalas; i++)
                    {
                        worksheet.Range["A" + (i + 2)].Text = matriz[i, 0];
                        worksheet.Range["B" + (i + 2)].Text = matriz[i, 1];
                        worksheet.Range["C" + (i + 2)].Text = matriz[i, 2];
                        worksheet.Range["D" + (i + 2)].Text = matriz[i, 3];
                        worksheet.Range["E" + (i + 2)].Text = matriz[i, 4];
                        worksheet.Range["F" + (i + 2)].Text = matriz[i, 5];
                        worksheet.Range["A" + (i + 2) + ":I" + (i + 2)].BorderAround(ExcelLineStyle.Medium);
                        worksheet.Range["A" + (i + 2) + ":I" + (i + 2)].BorderInside(ExcelLineStyle.Medium);
                    }

                    worksheet.Range["A1"].Text = "Sala";
                    worksheet.Range["B1"].Text = OBtenerNombreDia(DateTime.Parse(FechaIni), 0);
                    worksheet.Range["C1"].Text = OBtenerNombreDia(DateTime.Parse(FechaIni), 1);
                    worksheet.Range["D1"].Text = OBtenerNombreDia(DateTime.Parse(FechaIni), 2);
                    worksheet.Range["E1"].Text = OBtenerNombreDia(DateTime.Parse(FechaIni), 3);
                    worksheet.Range["F1"].Text = OBtenerNombreDia(DateTime.Parse(FechaIni), 4);

                    worksheet.Range["A1"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                    worksheet.Range["B1"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                    worksheet.Range["C1"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                    worksheet.Range["D1"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                    worksheet.Range["E1"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                    worksheet.Range["F1"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;

                    worksheet.Range["A1"].BorderAround(ExcelLineStyle.Medium);
                    worksheet.Range["B1"].BorderAround(ExcelLineStyle.Medium);
                    worksheet.Range["C1"].BorderAround(ExcelLineStyle.Medium);
                    worksheet.Range["D1"].BorderAround(ExcelLineStyle.Medium);
                    worksheet.Range["E1"].BorderAround(ExcelLineStyle.Medium);
                    worksheet.Range["F1"].BorderAround(ExcelLineStyle.Medium);

                    for (int i = 0; i < contsalas; i++)
                    {
                        worksheet.Range["A" + (i + 2)].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;
                        worksheet.Range["A" + (i + 2)].WrapText = true;
                        worksheet.Range["B" + (i + 2)+ ":F1" + (i + 1)].CellStyle.VerticalAlignment = ExcelVAlign.VAlignTop;
                    }
                    
                    worksheet.PageSetup.Orientation = ExcelPageOrientation.Landscape;

                    //Save the workbook to disk in xlsx format.
                    workbook.SaveAs("ReporteActividades"+DateTime.Today.Day+"-"+DateTime.Today.Month + "-"+ DateTime.Today.Year + ".xlsx", HttpContext.ApplicationInstance.Response, ExcelDownloadType.Open);
                }



                ////Create an instance of ExcelEngine.
                //using (ExcelEngine excelEngine = new ExcelEngine())
                //{
                //    //Set the default application version as Excel 2016.
                //    excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2013;

                //    //Create a workbook with a worksheet.
                //    IWorkbook workbook = excelEngine.Excel.Workbooks.Create(1);

                //    //Access first worksheet from the workbook instance.
                //    IWorksheet worksheet = workbook.Worksheets[0];

                //    //Insert sample text into cell “A1”.
                //    worksheet.Range["A1"].Text = "Hello " + "\n" + " World";

                //    //Save the workbook to disk in xlsx format.
                //    workbook.SaveAs("Sample.xlsx", HttpContext.ApplicationInstance.Response, ExcelDownloadType.Open);
                //}
            }

            return View();
        }

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

        private string OBtenerNombreDia(DateTime fecha, Int32 diaextra)
        {
            var dia = fecha.AddDays(diaextra).DayOfWeek;
            var diaespañol = "";

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