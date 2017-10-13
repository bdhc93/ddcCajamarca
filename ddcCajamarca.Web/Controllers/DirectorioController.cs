using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ddcCajamarca.Services.Directorio.Interfaces;
using ddcCajamarca.Models;
using System.Drawing;

namespace ddcCajamarca.Web.Controllers
{
    public class DirectorioController : Controller
    {
        public IPersonaService personaService { get; set; }
        public IOrganizacionService organizacionService { get; set; }
        public IProfesionService profesionService { get; set; }
        public IOcupacionCulturalService ocupacionCulturalService { get; set; }

        public DirectorioController(IPersonaService personaService, IOrganizacionService organizacionService,
            IProfesionService profesionService, IOcupacionCulturalService ocupacionCulturalService)
        {
            this.personaService = personaService;
            this.organizacionService = organizacionService;
            this.profesionService = profesionService;
            this.ocupacionCulturalService = ocupacionCulturalService;
        }

        [HttpGet]
        public ActionResult ListarPersonas(String NA, String Fun)
        {
            var result = personaService.ObtenerPersonaPorCriterio("");

            foreach (var item in result)
            {
                item.Imagen = ".." + item.Imagen;
            }

            if (!String.IsNullOrEmpty(Fun))
            {
                ViewBag.dato = NA;
                ViewBag.save = Fun;
            }
            else
            {
                ViewBag.dato = "";
                ViewBag.save = false;
            }
            ViewBag.Coincidencias = result.Count();
            ViewBag.Organizacion = organizacionService.ObtenerOrganizacionPorCriterio("",false);
            ViewBag.Ocupacion = ocupacionCulturalService.ObtenerOcupacionCulturalPorCriterio("", false);
            ViewBag.Profesion = profesionService.ObtenerProfesionPorCriterio("", false);

            return View(result);
        }

        [HttpGet]
        public ActionResult ListarPersonas2(String NA, String Fun)
        {
            var result = personaService.ObtenerPersonaPorCriterio("");

            foreach (var item in result)
            {
                item.Imagen = ".." + item.Imagen;
            }

            if (!String.IsNullOrEmpty(Fun))
            {
                ViewBag.dato = NA;
                ViewBag.save = Fun;
            }
            else
            {
                ViewBag.dato = "";
                ViewBag.save = false;
            }

            ViewBag.Organizacion = organizacionService.ObtenerOrganizacionPorCriterio("", true);
            ViewBag.Ocupacion = ocupacionCulturalService.ObtenerOcupacionCulturalPorCriterio("", true);
            ViewBag.Profesion = profesionService.ObtenerProfesionPorCriterio("", true);

            return View(result);
        }

        [HttpGet]
        public ActionResult ListarExtras(String Tp)
        {
            if (DateTime.Now.Month < 10)
            {
                if (DateTime.Now.Day < 10)
                {
                    ViewBag.FechaHoy = DateTime.Now.Year + "-0" + DateTime.Now.Month + "-0" + DateTime.Now.Day;
                }
                else
                {
                    ViewBag.FechaHoy = DateTime.Now.Year + "-0" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                }

            }
            else
            {
                if (DateTime.Now.Day < 10)
                {
                    ViewBag.FechaHoy = DateTime.Now.Year + "-" + DateTime.Now.Month + "-0" + DateTime.Now.Day;
                }
                else
                {
                    ViewBag.FechaHoy = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                }

            }

            if (!String.IsNullOrEmpty(Tp))
            {
                ViewBag.ToasMS = Tp;
            }
            else
            {
                ViewBag.ToasMS = "";
            }
            

            if (Tp == "G1")
            {
                ViewBag.msgini = "G1";

                var result = ocupacionCulturalService.ObtenerOcupacionCulturalPorCriterio("", false);
                ViewBag.Coincidencias = result.Count();

                ViewBag.Ocupacion = result;
            }
            else if (Tp == "G2")
            {
                ViewBag.msgini = "G2";

                var result = profesionService.ObtenerProfesionPorCriterio("", false);
                ViewBag.Coincidencias = result.Count();

                ViewBag.Ocupacion = result;
            }
            else if (Tp == "G3")
            {
                ViewBag.msgini = "G3";

                var result = organizacionService.ObtenerOrganizacionPorCriterio("", false);
                ViewBag.Coincidencias = result.Count();

                ViewBag.Ocupacion = result;
            }
            else if (Tp == "M1")
            {
                ViewBag.msgini = "M1";

                var result = ocupacionCulturalService.ObtenerOcupacionCulturalPorCriterio("", false);
                ViewBag.Coincidencias = result.Count();

                ViewBag.Ocupacion = result;
            }
            else if (Tp == "M2")
            {
                ViewBag.msgini = "M2";

                var result = profesionService.ObtenerProfesionPorCriterio("", false);
                ViewBag.Coincidencias = result.Count();

                ViewBag.Ocupacion = result;
            }
            else if (Tp == "M3")
            {
                ViewBag.msgini = "M3";

                var result = organizacionService.ObtenerOrganizacionPorCriterio("", false);
                ViewBag.Coincidencias = result.Count();

                ViewBag.Ocupacion = result;
            }
            else
            {
                ViewBag.msgini = "G4";

                var result = ocupacionCulturalService.ObtenerOcupacionCulturalPorCriterio("", false);
                ViewBag.Coincidencias = result.Count();

                ViewBag.Ocupacion = result;
            }
            
            return View();
        }

        [HttpGet]
        public ActionResult NuevaPersona()
        {
            ViewBag.Organizacion = organizacionService.ObtenerOrganizacionPorCriterio("", false);
            ViewBag.Ocupacion = ocupacionCulturalService.ObtenerOcupacionCulturalPorCriterio("", false);
            ViewBag.Profesion = profesionService.ObtenerProfesionPorCriterio("", false);

            if (DateTime.Now.Month<10)
            {
                if (DateTime.Now.Day<10)
                {
                    ViewBag.FechaHoy = DateTime.Now.Year + "-0" + DateTime.Now.Month + "-0" + DateTime.Now.Day;
                }
                else
                {
                    ViewBag.FechaHoy = DateTime.Now.Year + "-0" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                }
                
            }
            else
            {
                if (DateTime.Now.Day < 10)
                {
                    ViewBag.FechaHoy = DateTime.Now.Year + "-" + DateTime.Now.Month + "-0" + DateTime.Now.Day;
                }
                else
                {
                    ViewBag.FechaHoy = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                }
                
            }

            var personas = personaService.ObtenerPersonaPorCriterio("");

            var personasarray = "";

            foreach (var item in personas)
            {
                personasarray = personasarray + "'" + item.NombreMostrar + "'" + ",";
            }

            personasarray = "[" + personasarray + "'" + "'" + "]";

            personasarray = personasarray.Replace("'", char.ConvertFromUtf32(34));
            
            ViewBag.Personas = personasarray;

            return View();
        }

        [HttpPost]
        public ActionResult NuevaPersona(Persona model, HttpPostedFileBase file, String cropweight, String cropwidth, String cropx, String cropy)
        {
            if (file != null && file.ContentType.Remove(5) == "image")
            {
                string ruta = Server.MapPath("~/PerfilImg");

                if (!Directory.Exists(ruta))
                    Directory.CreateDirectory(ruta);

                string archivo = String.Format("{0}\\{1}", ruta, model.Telefono + "-" + model.NombreApellidos + "." + file.ContentType.Remove(0, 6));
                //string archivo = "C:/inetpub/wwwroot/DDCCajamarca/PerfilImg/" + model.Telefono + " -" + model.NombreApellidos;

                cropweight = cropweight.Replace(".", ",");
                cropwidth = cropwidth.Replace(".", ",");
                cropx = cropx.Replace(".", ",");
                cropy = cropy.Replace(".", ",");

                Decimal Convcropweight = Decimal.Parse(cropweight);
                Decimal Convcropcropwidth = Decimal.Parse(cropwidth);
                Decimal Convcropx = Decimal.Parse(cropx);
                Decimal Convcropy = Decimal.Parse(cropy);

                Rectangle cropRect = new Rectangle(Decimal.ToInt32(Convcropx), Decimal.ToInt32(Convcropy), Decimal.ToInt32(Convcropcropwidth), Decimal.ToInt32(Convcropweight));

                Bitmap src = Image.FromStream(file.InputStream) as Bitmap;

                Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);
                
                using (Graphics g = Graphics.FromImage(target))
                {
                    g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height),
                        cropRect,
                        GraphicsUnit.Pixel);
                }

                target = new Bitmap(target,new Size(125,125));

                target.Save(archivo);

                model.Imagen = "/PerfilImg/" + model.Telefono + "-" + model.NombreApellidos + "." + file.ContentType.Remove(0, 6);
                //model.Imagen = "/PerfilImg/" + model.Telefono + "-" + model.NombreApellidos + "." + file.FileName;
            }
            else
            {
                model.Imagen = "/PerfilImg/SinImagen.jpg";
            }

            if (model.IdOcupacionCultural == 0)
            {
                model.IdOcupacionCultural = 1;
            }

            if (model.IdProfesion == 0)
            {
                model.IdProfesion = 1;
            }

            if (model.IdOrganizacion == 0)
            {
                model.IdOrganizacion = 1;
            }

            if (!String.IsNullOrEmpty(model.NombreArtistico))
            {
                model.NombreArtistico = model.NombreArtistico.ToUpper();
            }
            if (!String.IsNullOrEmpty(model.Direccion))
            {
                model.Direccion = model.Direccion.ToUpper();
            }
            if (!String.IsNullOrEmpty(model.Email))
            {
                model.Email = model.Email.ToUpper();
            }
            if (!String.IsNullOrEmpty(model.RedesSociales))
            {
                model.RedesSociales = model.RedesSociales.ToUpper();
            }
            
            model.NombreApellidos = model.NombreApellidos.ToUpper();

            personaService.GuardarPersona(model);

            return Redirect(Url.Action("ListarPersonas", new { NA = model.NombreApellidos, Fun = "PS" }));
        }

        [HttpGet]
        public ActionResult Eliminar(Int32 idper)
        {
            try
            {
                var per = personaService.ObtenerPersonaPorId(idper);

                personaService.EliminarPersona(idper);

                ViewBag.MSG = "1";

                //if (per.Imagen != "/PerfilImg/SinImagen.jpg")
                //{
                //    System.IO.FileInfo img = new System.IO.FileInfo(@"\PerfilImg\SinImagen.jpg");
                //}
            }
            catch (Exception)
            {
                ViewBag.MSG = "2";
            }

            return PartialView();
        }

        [HttpGet]
        public ActionResult Editar(Int32 idper)
        {
            ViewBag.Organizacion = organizacionService.ObtenerOrganizacionPorCriterio("", true);
            ViewBag.Ocupacion = ocupacionCulturalService.ObtenerOcupacionCulturalPorCriterio("", true);
            ViewBag.Profesion = profesionService.ObtenerProfesionPorCriterio("", true);
            if (DateTime.Now.Month < 10)
            {
                if (DateTime.Now.Day < 10)
                {
                    ViewBag.FechaHoy = DateTime.Now.Year + "-0" + DateTime.Now.Month + "-0" + DateTime.Now.Day;
                }
                else
                {
                    ViewBag.FechaHoy = DateTime.Now.Year + "-0" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                }

            }
            else
            {
                if (DateTime.Now.Day < 10)
                {
                    ViewBag.FechaHoy = DateTime.Now.Year + "-" + DateTime.Now.Month + "-0" + DateTime.Now.Day;
                }
                else
                {
                    ViewBag.FechaHoy = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                }

            }

            var personas = personaService.ObtenerPersonaPorCriterio("");

            var personasarray = "";

            foreach (var item in personas)
            {
                personasarray = personasarray + "'" + item.NombreMostrar + "'" + ",";
            }

            personasarray = "[" + personasarray + "'" + "'" + "]";

            personasarray = personasarray.Replace("'", char.ConvertFromUtf32(34));

            ViewBag.Personas = personasarray;

            var result = personaService.ObtenerPersonaPorId(idper);

            result.ImagenTemp = result.Imagen;

            result.Imagen = ".." + result.Imagen;

            return View(result);
        }

        [HttpPost]
        public ActionResult Editar(Persona model, HttpPostedFileBase file, String cropweight, String cropwidth, String cropx, String cropy)
        {
            if (file != null && file.ContentType.Remove(5) == "image")
            {
                string ruta = Server.MapPath("~/PerfilImg");

                if (!Directory.Exists(ruta))
                    Directory.CreateDirectory(ruta);

                string archivo = String.Format("{0}\\{1}", ruta, model.Telefono + "-" + model.NombreApellidos + "." + file.ContentType.Remove(0, 6));

                cropweight = cropweight.Replace(".", ",");
                cropwidth = cropwidth.Replace(".", ",");
                cropx = cropx.Replace(".", ",");
                cropy = cropy.Replace(".", ",");

                Decimal Convcropweight = Decimal.Parse(cropweight);
                Decimal Convcropcropwidth = Decimal.Parse(cropwidth);
                Decimal Convcropx = Decimal.Parse(cropx);
                Decimal Convcropy = Decimal.Parse(cropy);

                Rectangle cropRect = new Rectangle(Decimal.ToInt32(Convcropx), Decimal.ToInt32(Convcropy), Decimal.ToInt32(Convcropcropwidth), Decimal.ToInt32(Convcropweight));

                Bitmap src = Image.FromStream(file.InputStream) as Bitmap;

                Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);

                using (Graphics g = Graphics.FromImage(target))
                {
                    g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height),
                        cropRect,
                        GraphicsUnit.Pixel);
                }

                target = new Bitmap(target, new Size(125, 125));

                target.Save(archivo);

                model.Imagen = "/PerfilImg/" + model.Telefono + "-" + model.NombreApellidos + "." + file.ContentType.Remove(0, 6);


            } else
            {
                model.Imagen = model.ImagenTemp;
            }

            if (model.IdOcupacionCultural == 0)
            {
                model.IdOcupacionCultural = 1;
            }

            if (model.IdProfesion == 0)
            {
                model.IdProfesion = 1;
            }

            if (model.IdOrganizacion == 0)
            {
                model.IdOrganizacion = 1;
            }

            if (!String.IsNullOrEmpty(model.NombreArtistico))
            {
                model.NombreArtistico = model.NombreArtistico.ToUpper();
            }
            if (!String.IsNullOrEmpty(model.Direccion))
            {
                model.Direccion = model.Direccion.ToUpper();
            }
            if (!String.IsNullOrEmpty(model.Email))
            {
                model.Email = model.Email.ToUpper();
            }
            if (!String.IsNullOrEmpty(model.RedesSociales))
            {
                model.RedesSociales = model.RedesSociales.ToUpper();
            }

            model.NombreApellidos = model.NombreApellidos.ToUpper();

            personaService.ModificarPersona(model);

            return Redirect(Url.Action("ListarPersonas", new { NA = model.NombreApellidos, Fun = "PE" }));
        }

        [HttpGet]
        public ActionResult Buscar(String criterio, Int32 IdOrBS, Int32 IdOcBS, Int32 IdPrBS)
        {
            var result = personaService.ObtenerPersonaPorFiltro(criterio, IdOrBS, IdOcBS, IdPrBS);

            foreach (var item in result)
            {
                item.Imagen = ".." + item.Imagen;
            }

            ViewBag.Coincidencias = result.Count();

            return PartialView("_Listar", result);
        }

        [HttpGet]
        public ActionResult BuscarExtra(String criterio, String idopcion)
        {
            if (idopcion == "Ocupación Cultural")
            {
                var result = ocupacionCulturalService.ObtenerOcupacionCulturalPorCriterio(criterio, false);
                ViewBag.lista = "L1";
                ViewBag.Coincidencias = result.Count();

                return PartialView("_ListarExtras", result);
            }
            else if (idopcion == "Profesión")
            {
                var result = profesionService.ObtenerProfesionPorCriterio(criterio, false);
                ViewBag.lista = "L2";
                ViewBag.Coincidencias = result.Count();

                return PartialView("_ListarExtras", result);
            }
            else if (idopcion == "Organización")
            {
                var result = organizacionService.ObtenerOrganizacionPorCriterio(criterio, false);
                ViewBag.lista = "L3";
                ViewBag.Coincidencias = result.Count();

                return PartialView("_ListarExtras", result);
            }

            ViewBag.Coincidencias = "0";

            return PartialView("_ListarExtras");
        }

        [HttpGet]
        public ActionResult EliminarExtra(Int32 idelim, String idopcion)
        {
            try
            {
                if (idopcion == "G1" || idopcion == "G4" || idopcion == "M1")
                {
                    ViewBag.MSG = "E1";

                    ocupacionCulturalService.EliminarOcupacionCultural(idelim);
                }
                else if (idopcion == "G2" || idopcion == "M2")
                {
                    ViewBag.MSG = "E1";

                    profesionService.EliminarProfesion(idelim);
                }
                else if (idopcion == "G3" || idopcion == "M3")
                {
                    ViewBag.MSG = "E1";

                    organizacionService.EliminarOrganizacion(idelim);
                }
            }
            catch (Exception)
            {
                ViewBag.MSG = "E2";
            }

            return PartialView();
        }

        [HttpGet]
        public ActionResult GuardarExtra(String Nombre, String idnuevoopc, String direccion)
        {
            try
            {
                if (idnuevoopc == "Ocupación Cultural")
                {
                    ViewBag.msg = "G1";
                    OcupacionCultural ocu = new OcupacionCultural { Nombre = Nombre.ToUpper(), FechaRegistro=DateTime.Today };
                    ocupacionCulturalService.GuardarOcupacionCultural(ocu);
                }
                else if (idnuevoopc == "Profesión")
                {
                    ViewBag.msg = "G2";
                    Profesion pro = new Profesion { Nombre = Nombre.ToUpper(), FechaRegistro = DateTime.Today };
                    profesionService.GuardarProfesion(pro);
                }
                else if (idnuevoopc == "Organización")
                {
                    ViewBag.msg = "G3";
                    Organizacion org = new Organizacion { Nombre = Nombre.ToUpper(), FechaRegistro = DateTime.Today, Direccion = direccion };
                    organizacionService.GuardarOrganizacion(org);
                }
                
            }
            catch (Exception)
            {
                ViewBag.msg = "G4";
                return PartialView("_GuardarExtra");
            }

            return PartialView("_GuardarExtra");
        }

        [HttpGet]
        public ActionResult GuardarOcupacionPersona(String Nombre, String idnuevoopc)
        {
            try
            {
                ViewBag.msg = "G1";
                OcupacionCultural ocu = new OcupacionCultural { Nombre = Nombre.ToUpper(), FechaRegistro = DateTime.Today };
                ocupacionCulturalService.GuardarOcupacionCultural(ocu);

            }
            catch (Exception)
            {
                ViewBag.Ocupacion = ocupacionCulturalService.ObtenerOcupacionCulturalPorCriterio("", false);
                ViewBag.msg = "G4";
                return PartialView("_GuardarOcupacionPersona");
            }

            ViewBag.Ocupacion = ocupacionCulturalService.ObtenerOcupacionCulturalPorCriterio("", false);
            return PartialView("_GuardarOcupacionPersona");
        }

        [HttpGet]
        public ActionResult GuardarProfesionPersona(String Nombre, String idnuevoopc)
        {
            try
            {
                ViewBag.msg = "G2";
                Profesion pro = new Profesion { Nombre = Nombre.ToUpper(), FechaRegistro = DateTime.Today };
                profesionService.GuardarProfesion(pro);

            }
            catch (Exception)
            {
                ViewBag.Profesion = profesionService.ObtenerProfesionPorCriterio("", true);
                ViewBag.msg = "G4";
                return PartialView("_GuardarProfesionPersona");
            }

            ViewBag.Profesion = profesionService.ObtenerProfesionPorCriterio("", true);
            return PartialView("_GuardarProfesionPersona");
        }

        [HttpGet]
        public ActionResult GuardarOrganizacionPersona(String Nombre, String idnuevoopc, String direccion)
        {
            try
            {
                ViewBag.msg = "G3";
                Organizacion org = new Organizacion { Nombre = Nombre.ToUpper(), FechaRegistro = DateTime.Today, Direccion = direccion };
                organizacionService.GuardarOrganizacion(org);

            }
            catch (Exception)
            {
                ViewBag.Organizacion = organizacionService.ObtenerOrganizacionPorCriterio("", true);
                ViewBag.msg = "G4";
                return PartialView("_GuardarOrganizacionPersona");
            }

            ViewBag.Organizacion = organizacionService.ObtenerOrganizacionPorCriterio("", true);
            return PartialView("_GuardarOrganizacionPersona");
        }

        [HttpGet]
        public ActionResult OBtenerExtraPorId(Int32 Id, String tipo)
        {
            if (DateTime.Now.Month < 10)
            {
                if (DateTime.Now.Day < 10)
                {
                    ViewBag.FechaHoy = DateTime.Now.Year + "-0" + DateTime.Now.Month + "-0" + DateTime.Now.Day;
                }
                else
                {
                    ViewBag.FechaHoy = DateTime.Now.Year + "-0" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                }

            }
            else
            {
                if (DateTime.Now.Day < 10)
                {
                    ViewBag.FechaHoy = DateTime.Now.Year + "-" + DateTime.Now.Month + "-0" + DateTime.Now.Day;
                }
                else
                {
                    ViewBag.FechaHoy = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                }

            }

            if (tipo == "Ocupación Cultural")
            {
                var result = ocupacionCulturalService.ObtenerComercialPorId(Id);
                ViewBag.ModTipo = "M1";
                return PartialView("_OBtenerExtraPorId", result);
            }
            else if (tipo == "Profesión")
            {
                var result = profesionService.ObtenerProfesionPorId(Id);
                ViewBag.ModTipo = "M2";
                return PartialView("_OBtenerExtraPorId", result);
            }
            else if (tipo == "Organización")
            {
                var result = organizacionService.ObtenerOrganizacionPorId(Id);
                ViewBag.ModTipo = "M3";
                return PartialView("_OBtenerExtraPorId", result);
            }
            return PartialView("_OBtenerExtraPorId");
        }

        [HttpGet]
        public ActionResult ModificarExtra(Int32 Idm, String Nombre, String idnuevoopc, String direccion)
        {
            try
            {
                if (idnuevoopc == "G1" || idnuevoopc == "G4")
                {
                    ViewBag.msg = "M1";
                    OcupacionCultural ocu = new OcupacionCultural { Id = Idm, Nombre = Nombre.ToUpper(), FechaRegistro = DateTime.Today };
                    ocupacionCulturalService.ModificarOcupacionCultural(ocu);
                }
                else if (idnuevoopc == "G2")
                {
                    ViewBag.msg = "M2";
                    Profesion pro = new Profesion { Id = Idm, Nombre = Nombre.ToUpper(), FechaRegistro = DateTime.Today };
                    profesionService.ModificarProfesion(pro);
                }
                else if (idnuevoopc == "G3")
                {
                    ViewBag.msg = "M3";
                    Organizacion org = new Organizacion { Id = Idm, Nombre = Nombre.ToUpper(), FechaRegistro = DateTime.Today, Direccion = direccion.ToUpper() };
                    organizacionService.ModificarOrganizacion(org);
                }

            }
            catch (Exception)
            {
                ViewBag.msg = "M4";
                return PartialView("_ModificarExtra");
            }

            return PartialView("_ModificarExtra");
        }
    }
}