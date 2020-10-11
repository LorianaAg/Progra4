using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL;
using Proyecto.Models;
using Proyecto.Tools;

namespace Proyecto.Controllers
{
    public class LoginController : Controller
    {
        clsUsuario ObjUsuario = new clsUsuario();

        [AllowAnonymous] //Como EVeryone en BD. Permite a todos.
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Login login, string returnUrl)
        {
            var SecretKey = ConfigurationManager.AppSettings["SecretKey"];
            try
            {
                if (ModelState.IsValid)
                {
                        var ClaveSegura = Seguridad.EncryptString(SecretKey, login.Clave);
                        //var Claveoculta = Seguridad.DecryptString(SecretKey, ClaveSegura);
                        var datos = ObjUsuario.ValidaUsuario(login.Correo, ClaveSegura);
                    if (datos == null)
                    {
                        clsBitacora.IngresarBitacora("Login", "Login", "Usuario Invalido", 1, DateTime.Now, -1);
                        return View(login);
                    }
                    else
                    {
                        var ListaRoles = ObjUsuario.RolesUsuario(datos.IdUsuario);
                        var roles = String.Join(", ", ListaRoles.Select(x=> x.Rol));
                        //FormsAuthentication.SetAuthCookie(datos.Nombre + " " + datos.Apellido1 + " " + datos.Apellido2, login.Recuerdame);

                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, login.Correo, DateTime.Now, DateTime.Now.AddMinutes(30), login.Recuerdame, roles, FormsAuthentication.FormsCookiePath);
                        string hash = FormsAuthentication.Encrypt(ticket);
                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);

                        if (ticket.IsPersistent)
                        {
                            cookie.Expires = ticket.Expiration;
                        }
                        Response.Cookies.Add(cookie);

                        Session["Identificacion"] = datos.Identificacion;

                        if (Request.Browser.IsMobileDevice)
                        {
                            return RedirectToAction("Index", "Carnet");

                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }

                    }
                }
                else
                {
                    return View(login);
                }
            }
            catch (Exception)
            {

                throw;
            }      
        }

        //if (Session["Roles"].ToString().Contains("Administrador"))
        //{
       
        //}

        //if(User.IsInRole("Administrador");

        [Authorize]
        public ActionResult Salir()
        {
            Session.Remove("US");
            Session.RemoveAll();
            Response.Cache.SetCacheability(HttpCacheability.Private);
            Session.Clear();
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Cache.SetNoServerCaching();
            Request.Cookies.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}