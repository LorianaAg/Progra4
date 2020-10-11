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
    public class UnidadController : Controller
    {
        clsUnidad ObjUnidad = new clsUnidad();
        clsTipoPlaca ObjTipoPlaca = new clsTipoPlaca();
        clsLinea ObjLinea = new clsLinea();
        clsLineaUnidad ObjLineaUnidad = new clsLineaUnidad();

        // GET: Unidad
        public ActionResult Index()
        {
            try
            {
                var datos = ObjUnidad.ConsultarUnidad();
                List<Unidad> ListaUnidades = new List<Unidad>();

                foreach (var item in datos)
                {
                    Unidad unidad = new Unidad();
                    unidad.IdUnidad = item.IdUnidad;
                    unidad.Descripcion = item.Descripcion;
                    unidad.IdTipoPlaca = item.IdTipoPlaca;
                    unidad.Placa = item.Placa;
                    unidad.Estado = item.Estado;
                    unidad.IdLinea = item.IdLinea;
                    unidad.DescripcionLinea = item.DescripcionLinea;



                    ListaUnidades.Add(unidad);
                }

                return View(ListaUnidades);
            
            }
            catch (Exception)
            {

                return new HttpNotFoundResult("Error al consultar las unidades");
            }
        }

        public ActionResult Editar(int id)
        {
            Session["Empresa"] = 1;

            try
            {
                var dato = ObjUnidad.ConsultaUnidad(id);
                Unidad unidad = new Unidad();
                unidad.IdUnidad = dato.IdUnidad;
                unidad.Descripcion = dato.Descripcion;
                unidad.IdTipoPlaca = dato.IdTipoPlaca;
                unidad.Placa = dato.Placa;
                unidad.Estado = dato.Estado;
                unidad.TipoPlacaDesc = dato.TipoPlacaDesc;
                unidad.IdLinea = dato.IdLinea;
                unidad.DescripcionLinea = dato.DescripcionLinea;

                ViewBag.TiposPlacas = ObjTipoPlaca.ConsultarTipoPlaca();
                ViewBag.Lineas = ObjLinea.ConsultarLinea(Convert.ToInt32(Session["Empresa"].ToString()));


                return View(unidad);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la unidad");

            }
        }

        [HttpPost]

        public ActionResult Editar(Unidad unidad)
        {
            try
            {
                if (ObjUnidad.ActualizaUnidad(unidad.IdUnidad, unidad.Descripcion, unidad.IdTipoPlaca, unidad.Placa, unidad.Estado))
                {
                    ObjLineaUnidad.ActualizaLineaUnidad(unidad.IdUnidad, unidad.IdLinea);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Lineas = ObjLinea.ConsultarLinea(Convert.ToInt32(Session["Empresa"].ToString()));
                    ViewBag.TiposPlacas = ObjTipoPlaca.ConsultarTipoPlaca();

                    return View();
                }

            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la unidad");

            }
        }

        public ActionResult Crear()
        {
            try
            {
                Session["Empresa"] = 1;
                ViewBag.TiposPlacas = ObjTipoPlaca.ConsultarTipoPlaca();
                ViewBag.Lineas = ObjLinea.ConsultarLinea(Convert.ToInt32(Session["Empresa"].ToString()));

                return View();
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la unidad");

            }
        }

        [HttpPost]

        public ActionResult Crear(Unidad unidad)
        {
            try
            {
                if (ObjUnidad.IngresarUnidad(unidad.Descripcion, unidad.IdTipoPlaca, unidad.Placa, unidad.Estado))
                {
                    int idUnidadLocal = ObjLinea.ConsultaUnidadPlaca(unidad.Placa).IdUnidad;
                    ObjLineaUnidad.IngresaLineaUnidad(idUnidadLocal, unidad.IdLinea);

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.TiposPlacas = ObjTipoPlaca.ConsultarTipoPlaca();
                    ViewBag.Lineas = ObjLinea.ConsultarLinea(Convert.ToInt32(Session["Empresa"].ToString()));
                    return View();
                }

            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la unidad");

            }
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                var dato = ObjUnidad.ConsultaUnidad(id);
                Unidad unidad = new Unidad();
                unidad.IdUnidad = dato.IdUnidad;
                unidad.Descripcion = dato.Descripcion;
                unidad.IdTipoPlaca = dato.IdTipoPlaca;
                unidad.Placa = dato.Placa;
                unidad.Estado = dato.Estado;
                unidad.IdLinea = dato.IdLinea;
                unidad.DescripcionLinea = dato.DescripcionLinea;


                ViewBag.TiposPlacas = ObjTipoPlaca.ConsultarTipoPlaca();


                return View(unidad);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la unidad");

            }
        }

        [HttpPost]

        public ActionResult Eliminar(Unidad unidad)
        {
            try
            {
                ObjLineaUnidad.EliminaLineaUnidad(unidad.IdUnidad);

                if (ObjUnidad.EliminaUnidad(unidad.IdUnidad))
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
                return new HttpNotFoundResult("Error al consultar la unidad");

            }
        }
    }
}