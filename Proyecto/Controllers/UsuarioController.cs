using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DAL;
using Proyecto.Models;
using Proyecto.Tools;

namespace Proyecto.Controllers
{ 
    
    public class UsuarioController : Controller
    {
        clsUsuario ObjUsuario = new clsUsuario();
        clsTipoIdentificacion ObjTipoIdentificacion = new clsTipoIdentificacion();
        clsRol ObjRol = new clsRol();
        clsUsuarioRol ObjUsuarioRol = new clsUsuarioRol();
        clsDeposito ObjDeposito = new clsDeposito();

        // GET: Usuario
        [Authorize]
        [AuthorizeRole(Role.Administrador, Role.Gerente)]
        public ActionResult Index()
        {
            try
            {
                var datos = ObjUsuario.ConsultarUsuario();
                List<Usuario> ListaUsuarios = new List<Usuario>();

                foreach (var item in datos)
                {
                    Usuario usuario = new Usuario();
                    usuario.IdUsuario = item.IdUsuario;
                    usuario.Nombre = item.Nombre;
                    usuario.Nombre2 = item.Nombre2;
                    usuario.Apellido1 = item.Apellido1;
                    usuario.Apellido2 = item.Apellido2;
                    usuario.IdTipoIdentificacion = item.IdTipoIdentificacion;
                    usuario.Identificacion = item.Identificacion;
                    usuario.Saldo = (decimal)item.Saldo;
                    usuario.Telefono = item.Telefono;
                    usuario.Correo = item.Correo;
                    usuario.Clave = item.Clave;
                    usuario.Estado = item.Estado;
                    usuario.DescrRol = item.DescrRol;

                    ListaUsuarios.Add(usuario);
                }

                return View(ListaUsuarios);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar los usuarios");

            }
        }

        [Authorize]
        [AuthorizeRole(Role.Administrador, Role.Gerente)]
        public ActionResult Editar(int id)
        {
            try
            {
                var SecretKey = ConfigurationManager.AppSettings["SecretKey"];

                var dato = ObjUsuario.ConsultaUsuario(id);
                Usuario usuario = new Usuario();
                usuario.IdUsuario = dato.IdUsuario;
                usuario.Nombre = dato.Nombre;
                usuario.Nombre2 = dato.Nombre2;
                usuario.Apellido1 = dato.Apellido1;
                usuario.Apellido2 = dato.Apellido2;
                usuario.IdTipoIdentificacion = dato.IdTipoIdentificacion;
                usuario.Identificacion = dato.Identificacion;
                usuario.Saldo = (decimal)dato.Saldo;
                usuario.Telefono = dato.Telefono;
                usuario.Correo = dato.Correo;
                usuario.Clave = dato.Clave;
                usuario.Estado = dato.Estado;
                usuario.DescrRol = dato.DescrRol;

                ViewBag.UsuarioRoles = ObjRol.ConsultarRol();
                ViewBag.TipoIdentificaciones = ObjTipoIdentificacion.ConsultarTipoIdentificacion();
                
                return View(usuario);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el usuario");
            }
        }
        [HttpPost]
        [Authorize]
        [AuthorizeRole(Role.Administrador, Role.Gerente)]

        public ActionResult Editar(Usuario usuario)
        {
            try
            {
                var SecretKey = ConfigurationManager.AppSettings["SecretKey"];

                usuario.Clave = Seguridad.EncryptString(SecretKey, usuario.Clave);

                if (ObjUsuario.ActualizaUsuario(usuario.IdUsuario, usuario.Nombre, usuario.Nombre2, usuario.Apellido1, usuario.Apellido2, usuario.IdTipoIdentificacion, usuario.Identificacion, usuario.Saldo, usuario.Telefono, usuario.Correo, usuario.Clave, usuario.Estado))
                {
                    ObjUsuarioRol.ActualizaUsuarioRol(usuario.IdUsuario, usuario.IdRol);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.UsuarioRoles = ObjRol.ConsultarRol();
                    ViewBag.TipoIdentificaciones = ObjTipoIdentificacion.ConsultarTipoIdentificacion();
                    return View();
                }

            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el usuario");

            }
        }

        [Authorize]
        [AuthorizeRole(Role.Administrador, Role.Gerente)]
        public ActionResult Crear()
        {
            try
            {

                ViewBag.UsuarioRoles = ObjRol.ConsultarRol();
                ViewBag.TipoIdentificaciones = ObjTipoIdentificacion.ConsultarTipoIdentificacion();
                return View();
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el usuario");

            }
        }

        [HttpPost]
        [Authorize]
        [AuthorizeRole(Role.Administrador, Role.Gerente)]

        public ActionResult Crear(Usuario usuario)
        {
            var SecretKey = ConfigurationManager.AppSettings["SecretKey"];
            try
            {
                usuario.Clave = Seguridad.EncryptString(SecretKey, usuario.Clave);

                if (ObjUsuario.IngresarUsuario(usuario.Nombre, usuario.Nombre2, usuario.Apellido1, usuario.Apellido2, usuario.IdTipoIdentificacion, usuario.Identificacion, usuario.Saldo, usuario.Telefono, usuario.Correo, usuario.Clave, usuario.Estado))
                {

                    int UsuarioLocal = ObjUsuario.ConsultaUsuarioCorreo(usuario.Correo).IdUsuario;

                    ObjUsuarioRol.IngresarUsuarioRol(UsuarioLocal, usuario.IdRol);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.UsuarioRoles = ObjRol.ConsultarRol();
                    ViewBag.TipoIdentificaciones = ObjTipoIdentificacion.ConsultarTipoIdentificacion();
                    return View();
                }

            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el usuario");

            }
        }

        [Authorize]
        [AuthorizeRole(Role.Administrador, Role.Gerente)]
        public ActionResult Eliminar(int id)
        {
            try
            {
                var dato = ObjUsuario.ConsultaUsuario(id);
                Usuario usuario = new Usuario();
                usuario.IdUsuario = dato.IdUsuario;
                usuario.Nombre = dato.Nombre;
                usuario.Nombre2 = dato.Nombre2;
                usuario.Apellido1 = dato.Apellido1;
                usuario.Apellido2 = dato.Apellido2;
                usuario.IdTipoIdentificacion = dato.IdTipoIdentificacion;
                usuario.Identificacion = dato.Identificacion;
                usuario.Saldo = (decimal)dato.Saldo;
                usuario.Telefono = dato.Telefono;
                usuario.Correo = dato.Correo;
                usuario.Clave = dato.Clave;
                usuario.Estado = dato.Estado;
                usuario.DescrRol = dato.DescrRol;

                ViewBag.UsuarioRoles = ObjRol.ConsultarRol();
                ViewBag.TipoIdentificaciones = ObjTipoIdentificacion.ConsultarTipoIdentificacion();

                return View(usuario);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el usuario");
            }
        }

        [HttpPost]
        [Authorize]
        [AuthorizeRole(Role.Administrador, Role.Gerente)]

        public ActionResult Eliminar(Usuario usuario)
        {
            try
            {
                ObjUsuarioRol.EliminaUsuarioRol(usuario.IdUsuario);
                if (ObjUsuario.EliminaUsuario(usuario.IdUsuario))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el usuario");
            }
        }
        [Authorize]
        [AuthorizeRole(Role.Administrador, Role.Gerente, Role.Supervisor, Role.Usuario)]
        public ActionResult ActualizarSaldo()
        {
            try
            {

                var UsuarioCorreo = User.Identity.Name;            
                var dato = ObjUsuario.ConsultaUsuarioCorreo(UsuarioCorreo);

                Usuario usuario = new Usuario();
                usuario.IdUsuario = dato.IdUsuario;
                usuario.Nombre = dato.Nombre;
                usuario.Apellido1 = dato.Apellido1;
                usuario.Identificacion = dato.Identificacion;
                usuario.Saldo = 0;
                usuario.Telefono = dato.Telefono;

                return View(usuario);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el usuario");
            }
        }

        [HttpPost]
        [Authorize]
        [AuthorizeRole(Role.Administrador, Role.Gerente, Role.Supervisor, Role.Usuario)]
        public ActionResult ActualizarSaldo(Usuario usuario)
        {
            try
            {

                if (ObjUsuario.ActualizaSaldoUsuario(usuario.Saldo, usuario.IdUsuario))
                {
                    ObjDeposito.IngresarDeposito(usuario.IdUsuario, usuario.Telefono, usuario.Saldo, DateTime.Now, "DR");
                    return RedirectToAction("Index");
                }
                else
                {                  
                    return View();
                }

            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el usuario");
            }
        }
    }
}