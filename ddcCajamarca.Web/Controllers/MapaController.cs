using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ddcCajamarca.Web.Controllers
{
    public class MapaController : Controller
    {
        // GET: Mapa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GoogleMaps()
        {
            return View();
        }
    }
}