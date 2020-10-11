using BLL;
using Proyecto.Models;
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
    public class TipoIdentificacionController : Controller
    {
        clsTipoIdentificacion ObjTipoIdentificacion = new clsTipoIdentificacion();

        // GET: TipoIdentificacion
        public ActionResult Index()
        {
            try
            {
                var datos = ObjTipoIdentificacion.ConsultarTipoIdentificacion();
                List<TipoIdentificacion> ListaTipoIdentificacion = new List<TipoIdentificacion>();

                foreach(var item in datos)
                {
                    TipoIdentificacion tipoIdentificacion = new TipoIdentificacion();
                    tipoIdentificacion.IdTipoIdentificacion = item.IdTipoIdentificacion;
                    tipoIdentificacion.Descripcion = item.Descripcion;
                    tipoIdentificacion.Estado = item.Estado;

                    ListaTipoIdentificacion.Add(tipoIdentificacion);
                }

                return View(ListaTipoIdentificacion);
            }
            catch (Exception)
            {
                return new HttpNotFoundResult("Error al consultar los tipo de identificacion");

            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                var dato = ObjTipoIdentificacion.ConsultaTipoIdentificacion(id);
                TipoIdentificacion tipoIdentificacion = new TipoIdentificacion();
                tipoIdentificacion.IdTipoIdentificacion = dato.IdTipoIdentificacion;
                tipoIdentificacion.Descripcion = dato.Descripcion;
                tipoIdentificacion.Estado = dato.Estado;

                ViewBag.TipoIdentificaciones = ObjTipoIdentificacion.ConsultarTipoIdentificacion();

                return View(tipoIdentificacion);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el tipo de identificacion");

            }
        }

        [HttpPost]

        public ActionResult Editar(TipoIdentificacion tipoIdentificacion)
        {
            try
            {
                if (ObjTipoIdentificacion.ActualizaTipoIdentificacion(tipoIdentificacion.IdTipoIdentificacion, tipoIdentificacion.Descripcion, tipoIdentificacion.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.TipoIdentificaciones = ObjTipoIdentificacion.ConsultarTipoIdentificacion();
                    return View();
                }

            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el tipo de identificacion");

            }
        }

        public ActionResult Crear()
        {
            try
            {
                ViewBag.TipoIdentificaciones = ObjTipoIdentificacion.ConsultarTipoIdentificacion();
                return View();
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el tipo de identificacion");

            }
        }

        [HttpPost]

        public ActionResult Crear(TipoIdentificacion tipoIdentificacion)
        {
            try
            {
                if (ObjTipoIdentificacion.IngresarTipoIdentificacion(tipoIdentificacion.Descripcion, tipoIdentificacion.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.TipoIdentificaciones = ObjTipoIdentificacion.ConsultarTipoIdentificacion();
                    return View();
                }

            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el tipo de identificacion");

            }
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                var dato = ObjTipoIdentificacion.ConsultaTipoIdentificacion(id);
                TipoIdentificacion tipoIdentificacion = new TipoIdentificacion();
                tipoIdentificacion.IdTipoIdentificacion = dato.IdTipoIdentificacion;
                tipoIdentificacion.Descripcion = dato.Descripcion;
                tipoIdentificacion.Estado = dato.Estado;

                ViewBag.TipoIdentificaciones = ObjTipoIdentificacion.ConsultarTipoIdentificacion();

                return View(tipoIdentificacion);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el tipo de identificacion");

            }
        }

        [HttpPost]

        public ActionResult Eliminar(TipoIdentificacion tipoIdentificacion)
        {
            try
            {
                if (ObjTipoIdentificacion.EliminaTipoIdentificacion(tipoIdentificacion.IdTipoIdentificacion))
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
                return new HttpNotFoundResult("Error al consultar el tipo de identificacion");

            }

        }
    }
}