using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ddcCajamarca.Services.Directorio.Interfaces;
using ddcCajamarca.Services.ActividadesCulturales.Interfaces;
using ddcCajamarca.Services.Seguridad.Interfaces;
using ddcCajamarca.Models;
using System.Web.Security;

namespace ddcCajamarca.Web.Controllers
{
    public class MenuController : Controller
    {
        public IPersonaService personaService { get; set; }
        public IEventoEnsayoService eventoEnsayoService { get; set; }
        public IPerfilUsuarioService perfilUsuarioService { get; set; }

        public MenuController(IPersonaService personaService, IEventoEnsayoService eventoEnsayoService,
            IPerfilUsuarioService perfilUsuarioService)
        {
            this.personaService = personaService;
            this.eventoEnsayoService = eventoEnsayoService;
            this.perfilUsuarioService = perfilUsuarioService;
        }

        public ActionResult Navigation()
        {
            var u = Membership.GetUser(User.Identity.Name);

            var usuario = perfilUsuarioService.ObtenerPerfilUsuarioPorNombre(User.Identity.Name);
            
            foreach (var item in usuario.webpages_UsersInRoles)
            {
                ViewBag.Rol = item.webpages_Roles.RoleName;
            }

            usuario.Imagen = "~" + usuario.Imagen;

            ViewBag.usuario = usuario;


            return PartialView("~/Views/Shared/_Navigation.cshtml");
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