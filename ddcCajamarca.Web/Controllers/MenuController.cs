using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ddcCajamarca.Services.Directorio.Interfaces;
using ddcCajamarca.Models;

namespace ddcCajamarca.Web.Controllers
{
    public class MenuController : Controller
    {
        public IPersonaService personaService { get; set; }

        public MenuController(IPersonaService personaService)
        {
            this.personaService = personaService;
        }

        public ActionResult TopNavbar()
        {
            var result = personaService.ObtenerPersonaPorFechaNacimiento();
            
            ViewBag.result = result;

            ViewBag.contnot = result.Count();

            return PartialView("~/Views/Shared/_TopNavbar.cshtml");
        }
    }
}