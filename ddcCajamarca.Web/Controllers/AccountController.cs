using System;
using System.Web.Mvc;
using WebMatrix.WebData;
using System.Web.Security;
using ddcCajamarca.Web.Models;
using ddcCajamarca.Services.Seguridad.Interfaces;
using ddcCajamarca.Models;
using System.Web;
using System.IO;
using System.Drawing;
using System.Linq;

namespace ddcCajamarca.Web.Controllers
{
    public class AccountController : Controller
    {
        public Iwebpages_RolService webpages_RolService { get; set; }
        public IPerfilUsuarioService perfilUsuarioService { get; set; }

        public AccountController(Iwebpages_RolService webpages_RolService, IPerfilUsuarioService perfilUsuarioService)
        {
            this.webpages_RolService = webpages_RolService;
            this.perfilUsuarioService = perfilUsuarioService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(IOUsuario logindata, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                if (WebSecurity.Login(logindata.Usuario, logindata.Contrasenia))
                {
                    if (ReturnUrl != null)
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    var res = "Usuario o contraseña incorrectos";
                    return RedirectToAction("Login", "Account", new { error = res });
                }


            }
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin, Administrador")]
        public ActionResult RegistroUsuario()
        {
            ViewBag.Roles = webpages_RolService.ObtenerRolPorCriterio("");

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin, Administrador")]
        public ActionResult ListarUsuarios(String Tp)
        {
            var result = perfilUsuarioService.ObtenerPerfilUsuarioPorCriterio("");
            
            foreach (var item in result)
            {
                if (String.IsNullOrEmpty(item.Imagen))
                {
                    item.Imagen = "../PerfilImg/SinImagen.jpg";
                }
                else
                {
                    item.Imagen = "../" + item.Imagen;
                }
            }

            ViewBag.ToasMS = Tp;

            ViewBag.Coincidencias = result.Count();

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin, Administrador")]
        public ActionResult RegistroUsuario(IOUsuario registrardata, string role)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(registrardata.Usuario, registrardata.Contrasenia);
                    Roles.AddUserToRole(registrardata.Usuario, role);

                    ViewBag.Roles = webpages_RolService.ObtenerRolPorCriterio("");

                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException)
                {
                    ModelState.AddModelError("", "Error Usuario Registrado");
                    ViewBag.Roles = webpages_RolService.ObtenerRolPorCriterio("");
                    return View(registrardata);
                }
            }
            ViewBag.Roles = webpages_RolService.ObtenerRolPorCriterio("");
            ModelState.AddModelError("", "No se puede registrar el usuario");
            return View(registrardata);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Perfil()
        {
            var usuario = perfilUsuarioService.ObtenerPerfilUsuarioPorNombre(User.Identity.Name);

            foreach (var item in usuario.webpages_UsersInRoles)
            {
                ViewBag.Rol = item.webpages_Roles.RoleName;
            }

            if (String.IsNullOrEmpty(usuario.Imagen))
            {
                usuario.ImagenTemp = usuario.Imagen;
                usuario.Imagen = "../PerfilImg/SinImagen.jpg";
            }
            else
            {
                usuario.ImagenTemp = usuario.Imagen;
                usuario.Imagen = "../" + usuario.Imagen;
            }

            ViewBag.usuario = usuario;

            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult CambiarUsuarioContrasenia()
        {
            var usuario = perfilUsuarioService.ObtenerPerfilUsuarioPorNombre(User.Identity.Name);

            foreach (var item in usuario.webpages_UsersInRoles)
            {
                ViewBag.Rol = item.webpages_Roles.RoleName;
            }

            ViewBag.usuario = usuario;

            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult CambiarUsuarioContrasenia(String contrasenia, String oldpass)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var a = WebSecurity.ChangePassword(User.Identity.Name, oldpass, contrasenia);

                    if (a)
                    {
                        ViewBag.MS = "M1";
                        ViewBag.dato = User.Identity.Name;

                        var usuarios = perfilUsuarioService.ObtenerPerfilUsuarioPorNombre(User.Identity.Name);

                        foreach (var item in usuarios.webpages_UsersInRoles)
                        {
                            ViewBag.Rol = item.webpages_Roles.RoleName;
                        }

                        ViewBag.usuario = usuarios;

                        return View();
                    }
                    else
                    {
                        ViewBag.MS = "M2";
                        ViewBag.dato = "Contraseña actual Incorrecta";

                        var usuarios = perfilUsuarioService.ObtenerPerfilUsuarioPorNombre(User.Identity.Name);

                        foreach (var item in usuarios.webpages_UsersInRoles)
                        {
                            ViewBag.Rol = item.webpages_Roles.RoleName;
                        }

                        ViewBag.usuario = usuarios;

                        return View();
                        //return PartialView();
                    }
                }
                catch (Exception e)
                {
                    var res = "Error: " + e.Message + "";

                    var usuarios = perfilUsuarioService.ObtenerPerfilUsuarioPorNombre(User.Identity.Name);

                    foreach (var item in usuarios.webpages_UsersInRoles)
                    {
                        ViewBag.Rol = item.webpages_Roles.RoleName;
                    }

                    ViewBag.usuario = usuarios;

                    return View();
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Perfil(PerfilUsuario perfil, String RolSistema, HttpPostedFileBase file, String cropweight, String cropwidth, String cropx, String cropy)
        {
            try
            {
                if (file != null && file.ContentType.Remove(5) == "image")
                {
                    string ruta = Server.MapPath("~/PerfilImg");

                    if (!Directory.Exists(ruta))
                        Directory.CreateDirectory(ruta);

                    string archivo = String.Format("{0}\\{1}", ruta, perfil.Usuario + "-" + RolSistema + "." + file.ContentType.Remove(0, 6));
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

                    target = new Bitmap(target, new Size(125, 125));

                    target.Save(archivo);

                    perfil.Imagen = "/PerfilImg/" + perfil.Usuario + "-" + RolSistema + "." + file.ContentType.Remove(0, 6);
                    //model.Imagen = "/PerfilImg/" + model.Telefono + "-" + model.NombreApellidos + "." + file.FileName;
                }
                else
                {
                    perfil.Imagen = perfil.ImagenTemp;
                }

                if (String.IsNullOrEmpty(perfil.NombreApellidos))
                {
                    perfil.NombreApellidos = "";
                }
                if (String.IsNullOrEmpty(perfil.Email))
                {
                    perfil.Email = "";
                }

                perfil.NombreApellidos = perfil.NombreApellidos.ToUpper();
                perfil.Email = perfil.Email.ToUpper();

                perfilUsuarioService.ModificarPerfilUsuario(perfil);

                //if (String.IsNullOrEmpty(perfil.Imagen))
                //{
                //    perfil.ImagenTemp = perfil.Imagen;
                //    perfil.Imagen = "../PerfilImg/SinImagen.jpg";
                //}
                //else
                //{
                //    perfil.ImagenTemp = perfil.Imagen;
                //    perfil.Imagen = "../" + perfil.Imagen;
                //}

                ViewBag.usuario = perfil;
                ViewBag.Rol = RolSistema;
            }
            catch (Exception)
            {
                ViewBag.usuario = perfil;
                ViewBag.Rol = RolSistema;
            }
            

            return View();
        }
        
        [HttpGet]
        [Authorize]
        public ActionResult EliminarUsuario(Int32 id)
        {
            try
            {
                var usuario = perfilUsuarioService.ObtenerPerfilUsuarioPorId(id);
                //((SimpleMembershipProvider)Membership.Provider).DeleteUser(usuario.Usuario, true);
                Membership.Provider.DeleteUser(usuario.Usuario, true);

                ViewBag.msg = "E1";

                return PartialView("_Mensaje");
            }
            catch (Exception e)
            {
                ViewBag.msg = "E2";

                return PartialView("_Mensaje");
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult ObtenerUsuarioPorId(Int32 Id)
        {
            try
            {
                ViewBag.Roles = webpages_RolService.ObtenerRolPorCriterio("");
                var result = perfilUsuarioService.ObtenerPerfilUsuarioPorId(Id);
                
                return PartialView("_ObtenerUsuarioPorId", result);
            }
            catch (Exception)
            {
                return Redirect(Url.Action("ListarUsuarios"));
            }
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin, Administrador")]
        public ActionResult ModificarUsuario(Int32 Idmod, String usuario, String contrasenia, String role)
        {
            try
            {
                var roles = webpages_RolService.ObtenerRolPorCriterio("");
                
                //MembershipUser mu = Membership.GetUser(usuario);

                var token = WebSecurity.GeneratePasswordResetToken(usuario,1440);

                //mu.ChangePassword(mu.ResetPassword(), contrasenia);

                WebSecurity.ResetPassword(token, contrasenia);

                foreach (var item in roles)
                {
                    try
                    {
                        Roles.RemoveUserFromRole(usuario, item.RoleName);
                    }
                    catch (Exception)
                    {
                    }
                    
                }

                //Roles.RemoveUserFromRoles(usuario, rol);

                Roles.AddUserToRole(usuario, role);

                ViewBag.msg = "M1";
                return PartialView("_Mensaje");
            }
            catch (Exception e)
            {
                ViewBag.msg = "E1";
                return PartialView("_Mensaje");
            }
        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Login", "Account");
        }
    }
}