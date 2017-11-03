using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ddcCajamarca.Services.Directorio.Interfaces;
using ddcCajamarca.Services.ActividadesCulturales.Interfaces;
using ddcCajamarca.Models;

namespace ddcCajamarca.Web.Controllers
{
    public class MenuController : Controller
    {
        public IPersonaService personaService { get; set; }
        public IEventoEnsayoService eventoEnsayoService { get; set; }

        public MenuController(IPersonaService personaService, IEventoEnsayoService eventoEnsayoService)
        {
            this.personaService = personaService;
            this.eventoEnsayoService = eventoEnsayoService;
        }

        public ActionResult TopNavbar()
        {
            var cumple = personaService.ObtenerPersonaPorFechaNacimiento();
            var eventos = eventoEnsayoService.ObtenerEventoEnsayoPorCriterioYFechas("", DateTime.Today, DateTime.Today);

            ViewBag.result = cumple;
            ViewBag.resulteventos = eventos;

            ViewBag.contnot = cumple.Count() + eventos.Count();

            return PartialView("~/Views/Shared/_TopNavbar.cshtml");
        }
    }
}