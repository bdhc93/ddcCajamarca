using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public ActionResult Calendario()
        {
            ViewBag.FechaHoy = FechaHoy();

            ViewBag.Ambientes = ambienteService.ObtenerAmbientePorCriterio("");

            var Eventos = eventoEnsayoService.ObtenerEventoEnsayoPorCriterio("");

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

                foreach (var itemreq in item.DetalleRequerimientos)
                {
                    detallerequerimientos = detallerequerimientos + " " + itemreq.Activo.Nombre + " - " + itemreq.Cantidad + " <br />";
                }

                idEvento[contador] = item.Id;

                titulo[contador] = item.Ambiente.Nombre + ": " + item.NombreActividad + " - " + item.InstitucionEncargada;

                if (item.FechaFin.Date != item.FechaInicio.Date)
                {
                    tododia[contador] = item.TodoDia;
                    inicio[contador] = new DateTime(item.FechaInicio.Year, item.FechaInicio.Month, item.FechaInicio.Day, item.FechaInicio.Hour, item.FechaInicio.Minute, item.FechaInicio.Millisecond);
                    fin[contador] = new DateTime(item.FechaFin.Year, item.FechaFin.Month, item.FechaFin.Day + 1, item.FechaFin.Hour, item.FechaFin.Minute, item.FechaFin.Millisecond);
                    color[contador] = item.Ambiente.Color;
                    descripcion[contador] = "<b>Requerimientos:</b> <br />" + detallerequerimientos + "<b>Información Adicional:</b> <br />" + item.InformacionAdicional;
                }
                else
                {
                    tododia[contador] = item.TodoDia;
                    inicio[contador] = new DateTime(item.FechaInicio.Year, item.FechaInicio.Month, item.FechaInicio.Day, item.FechaInicio.Hour, item.FechaInicio.Minute, item.FechaInicio.Millisecond);
                    fin[contador] = new DateTime(item.FechaFin.Year, item.FechaFin.Month, item.FechaFin.Day, item.FechaFin.Hour, item.FechaFin.Minute, item.FechaFin.Millisecond);
                    color[contador] = item.Ambiente.Color;
                    descripcion[contador] = "<b>Requerimientos:</b> <br />" + detallerequerimientos + "<b>Información Adicional:</b> <br />" + item.InformacionAdicional;
                }
                
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
        public ActionResult NuevoRegistro(Int32 idAmbientes, String OpcionEvento, String FechaIni, String FechaFin, Boolean opcTodoDia, String HoraIni, String HoraFin)
        {
            ViewBag.FechaHoy = FechaHoy();

            ViewBag.FechaInicio = FechaIni;
            ViewBag.FechaFin = FechaFin;
            if (opcTodoDia)
            {
                ViewBag.opcTodoDia = "True";
                ViewBag.HoraInicio = "00:00";
                ViewBag.HoraFin = "23:59";
            }
            else
            {
                ViewBag.opcTodoDia = "False";
                ViewBag.HoraInicio = HoraIni;
                ViewBag.HoraFin = HoraFin;
            }            

            ViewBag.IdAmbiente = idAmbientes;
            ViewBag.Ambiente = ambienteService.ObtenerAmbientePorId(idAmbientes).NombreMostrar;
            ViewBag.Activos = activoService.ObtenerActivoPorCriterio("");

            return View();
        }

        [HttpPost]
        public ActionResult NuevoRegistro(EventoEnsayo evento, String arryreq, String FechaInicio, String FechaFin, Boolean opcTodoDia, String HoraIni, String HoraFin)
        {
            EventoEnsayo eventoguardar;

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
                    FechaRegistro = DateTime.Today
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
                    FechaRegistro = DateTime.Today
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
                eventoEnsayoService.GuardarEventoEnsayo(eventoguardar);
            }
            else
            {
                var dias = (eventoguardar.FechaFin.Day - eventoguardar.FechaInicio.Day)+1;


                if (evento.FechaInicio.Month == evento.FechaFin.Month)
                {
                    var fechainiguard = evento.FechaInicio;

                    for (int i = 0; i < dias; i++)
                    {
                        eventoguardar.FechaInicio = new DateTime(eventoguardar.FechaInicio.Year, eventoguardar.FechaInicio.Month, fechainiguard.Day+i, eventoguardar.FechaInicio.Hour, eventoguardar.FechaInicio.Minute, eventoguardar.FechaInicio.Millisecond);
                        eventoguardar.FechaFin = new DateTime(eventoguardar.FechaFin.Year, eventoguardar.FechaFin.Month, fechainiguard.Day+i, eventoguardar.FechaFin.Hour, eventoguardar.FechaFin.Minute, eventoguardar.FechaFin.Millisecond);
                        
                        eventoEnsayoService.GuardarEventoEnsayo(eventoguardar);
                    }
                }
            }

            

            return Redirect(Url.Action("Calendario"));
        }
        
        [HttpGet]
        public ActionResult MostrarCalendario(String idAmbiente)
        {
            var id = 0;

            if (!String.IsNullOrEmpty(idAmbiente))
            {
                id = Int32.Parse(idAmbiente);

                var Eventos = eventoEnsayoService.ObtenerEventoEnsayoPorIdAmbiente(id);

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

                    foreach (var itemreq in item.DetalleRequerimientos)
                    {
                        detallerequerimientos = detallerequerimientos + " " + itemreq.Activo.Nombre + " - " + itemreq.Cantidad + " <br />";
                    }

                    idEvento[contador] = item.Id;

                    titulo[contador] = item.Ambiente.Nombre + ": " + item.NombreActividad + " - " + item.InstitucionEncargada;

                    if (item.FechaFin.Date != item.FechaInicio.Date)
                    {
                        tododia[contador] = item.TodoDia;
                        inicio[contador] = new DateTime(item.FechaInicio.Year, item.FechaInicio.Month, item.FechaInicio.Day, item.FechaInicio.Hour, item.FechaInicio.Minute, item.FechaInicio.Millisecond);
                        fin[contador] = new DateTime(item.FechaFin.Year, item.FechaFin.Month, item.FechaFin.Day + 1, item.FechaFin.Hour, item.FechaFin.Minute, item.FechaFin.Millisecond);
                        color[contador] = item.Ambiente.Color;
                        descripcion[contador] = "<b>Requerimientos:</b> <br />" + detallerequerimientos + "<b>Información Adicional:</b> <br />" + item.InformacionAdicional;
                    }
                    else
                    {
                        tododia[contador] = item.TodoDia;
                        inicio[contador] = new DateTime(item.FechaInicio.Year, item.FechaInicio.Month, item.FechaInicio.Day, item.FechaInicio.Hour, item.FechaInicio.Minute, item.FechaInicio.Millisecond);
                        fin[contador] = new DateTime(item.FechaFin.Year, item.FechaFin.Month, item.FechaFin.Day, item.FechaFin.Hour, item.FechaFin.Minute, item.FechaFin.Millisecond);
                        color[contador] = item.Ambiente.Color;
                        descripcion[contador] = "<b>Requerimientos:</b> <br />" + detallerequerimientos + "<b>Información Adicional:</b> <br />" + item.InformacionAdicional;
                    }
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
                var Eventos = eventoEnsayoService.ObtenerEventoEnsayoPorCriterio("");

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

                    foreach (var itemreq in item.DetalleRequerimientos)
                    {
                        detallerequerimientos = detallerequerimientos + " " + itemreq.Activo.Nombre + " - " + itemreq.Cantidad + " <br />";
                    }

                    idEvento[contador] = item.Id;

                    titulo[contador] = item.Ambiente.Nombre + ": " + item.NombreActividad + " - " + item.InstitucionEncargada;

                    if (item.FechaFin.Date != item.FechaInicio.Date)
                    {
                        tododia[contador] = item.TodoDia;
                        inicio[contador] = new DateTime(item.FechaInicio.Year, item.FechaInicio.Month, item.FechaInicio.Day, item.FechaInicio.Hour, item.FechaInicio.Minute, item.FechaInicio.Millisecond);
                        fin[contador] = new DateTime(item.FechaFin.Year, item.FechaFin.Month, item.FechaFin.Day + 1, item.FechaFin.Hour, item.FechaFin.Minute, item.FechaFin.Millisecond);
                        color[contador] = item.Ambiente.Color;
                        descripcion[contador] = "<b>Requerimientos:</b> <br />" + detallerequerimientos + "<b>Información Adicional:</b> <br />" + item.InformacionAdicional;
                    }
                    else
                    {
                        tododia[contador] = item.TodoDia;
                        inicio[contador] = new DateTime(item.FechaInicio.Year, item.FechaInicio.Month, item.FechaInicio.Day, item.FechaInicio.Hour, item.FechaInicio.Minute, item.FechaInicio.Millisecond);
                        fin[contador] = new DateTime(item.FechaFin.Year, item.FechaFin.Month, item.FechaFin.Day, item.FechaFin.Hour, item.FechaFin.Minute, item.FechaFin.Millisecond);
                        color[contador] = item.Ambiente.Color;
                        descripcion[contador] = "<b>Requerimientos:</b> <br />" + detallerequerimientos + "<b>Información Adicional:</b> <br />" + item.InformacionAdicional;
                    }
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

            ViewBag.msgini = Tp;

            //if (Tp == "G1")
            //{
            //    ViewBag.msgini = "G1";

                
            //}
            //else if (Tp == "M1")
            //{
            //    ViewBag.msgini = "M1";

            //    var Amb = ambienteService.ObtenerAmbientePorCriterio("");

            //    ViewBag.Coincidencias = Amb.LongCount();

            //    ViewBag.Ambiente = Amb;
            //}
            //else
            //{
            //    ViewBag.msgini = "G4";

            //    var Amb = ambienteService.ObtenerAmbientePorCriterio("");

            //    ViewBag.Coincidencias = Amb.LongCount();

            //    ViewBag.Ambiente = Amb;
            //}

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

                color = ObtenerCodigoColor(color);

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
                ViewBag.Coincidencias =0;

                return PartialView("_BuscarAmbiente");
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
        public ActionResult ModificarAmbiente(Int32 Idmod, String nombre, String aforo, String color)
        {
            try
            {
                color = ObtenerCodigoColor(color);

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

        private static string ObtenerCodigoColor(string color)
        {
            if (color == "Azul")
            {
                color = "#2591F6";
            }
            else if (color == "Amarillo")
            {
                color = "#EAE54E";
            }
            else if (color == "Berenjena")
            {
                color = "#5D0560";
            }
            else if (color == "Celeste")
            {
                color = "#66C4E5";
            }
            else if (color == "Chicle")
            {
                color = "#F5D4F4";
            }
            else if (color == "Cielo")
            {
                color = "#27F8F5";
            }
            else if (color == "Ciruela")
            {
                color = "#A023A4";
            }
            else if (color == "Fresa")
            {
                color = "#F31ADE";
            }
            else if (color == "Limon")
            {
                color = "#F4DA18";
            }
            else if (color == "Orquidea")
            {
                color = "#8D7CCA";
            }
            else if (color == "Musgo")
            {
                color = "#337352";
            }
            else if (color == "Magenta")
            {
                color = "#C352D4";
            }
            else if (color == "Morado")
            {
                color = "#F00C82";
            }
            else if (color == "Naranja")
            {
                color = "#E79742";
            }
            else if (color == "Rosa")
            {
                color = "#EE79E3";
            }
            else if (color == "Rojo")
            {
                color = "#FF0000";
            }
            else if (color == "Rojo Oscuro")
            {
                color = "#8A0808";
            }
            else if (color == "Trebol")
            {
                color = "#397402";
            }
            else if (color == "Verde")
            {
                color = "#50B258";
            }
            else
            {
                color = "#2591F6";
            }

            return color;
        }

        private string FechaHoy()
        {
            var fecha = "";

            if (DateTime.Now.Month < 10)
            {
                if (DateTime.Now.Day < 10)
                {
                    fecha = "0" + DateTime.Now.Day + "-0" + DateTime.Now.Month + "-" + DateTime.Now.Year;
                }
                else
                {
                    fecha = DateTime.Now.Day + "-0" + DateTime.Now.Month + "-" + DateTime.Now.Year;
                }

            }
            else
            {
                if (DateTime.Now.Day < 10)
                {
                    fecha = "0" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
                }
                else
                {
                    fecha = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
                }
            }

            return fecha;
        }
    }
}