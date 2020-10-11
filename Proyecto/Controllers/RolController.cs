using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DAL;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    [Authorize]
    [AuthorizeRole(Role.Administrador, Role.Gerente, Role.Supervisor)]
    public class RolController : Controller
    {
        clsRol ObjRol = new clsRol();

        // GET: Rol
        public ActionResult Index()
        {
            try
            {
                var datos = ObjRol.ConsultarRol();
                List<Rol> ListaRoles = new List<Rol>();

                foreach (var item in datos)
                {
                    Rol rol = new Rol();
                    rol.IdRol = item.IdRol;
                    rol.Descripcion = item.Descripcion;
                    rol.Estado = item.Estado;

                    ListaRoles.Add(rol);
                }

                return View(ListaRoles);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar los roles");
            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                var dato = ObjRol.ConsultaRol(id);
                Rol rol = new Rol();
                rol.IdRol = dato.IdRol;
                rol.Descripcion = dato.Descripcion;
                rol.Estado = dato.Estado;

                return View(rol);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el rol");

            }
        }

        [HttpPost]

        public ActionResult Editar(Rol rol)
        {
            try
            {
                if (ObjRol.ActualizaRol(rol.IdRol, rol.Descripcion, rol.Estado))
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
                return new HttpNotFoundResult("Error al consultar el rol");

            }
        }

        public ActionResult Crear()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el rol");

            }
        }

        [HttpPost]

        public ActionResult Crear(Rol rol)
        {
            try
            {
                if (ObjRol.IngresarRol(rol.Descripcion,rol.Estado))
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
                return new HttpNotFoundResult("Error al consultar el rol");

            }
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                var dato = ObjRol.ConsultaRol(id);
                Rol rol = new Rol();
                rol.IdRol = dato.IdRol;
                rol.Descripcion = dato.Descripcion;
                rol.Estado = dato.Estado;

                return View(rol);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el rol");

            }
        }

        [HttpPost]

        public ActionResult Eliminar(Rol rol)
        {
            try
            {
                if (ObjRol.EliminaRol(rol.IdRol))
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
                return new HttpNotFoundResult("Error al consultar el rol");

            }
        }
    }
}