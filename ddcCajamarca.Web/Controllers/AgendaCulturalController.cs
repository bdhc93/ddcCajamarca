using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ddcCajamarca.Web.Controllers
{
    public class AgendaCulturalController : Controller
    {
        [HttpGet]
        public ActionResult Calendario()
        {
            if (DateTime.Now.Month < 10)
            {
                if (DateTime.Now.Day < 10)
                {
                    ViewBag.FechaHoy = "0" + DateTime.Now.Day + "-0" + DateTime.Now.Month + "-" + DateTime.Now.Year;
                }
                else
                {
                    ViewBag.FechaHoy = DateTime.Now.Day + "-0" + DateTime.Now.Month + "-" + DateTime.Now.Year;
                }

            }
            else
            {
                if (DateTime.Now.Day < 10)
                {
                    ViewBag.FechaHoy = "0" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
                }
                else
                {
                    ViewBag.FechaHoy = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
                }

            }


            return View();
        }

        [HttpGet]
        public ActionResult NuevoRegistro()
        {
            

            return View();
        }
    }
}