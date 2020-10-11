using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using BLL;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    [Authorize]
    [AuthorizeRole(Role.Administrador, Role.Gerente, Role.Supervisor)]
    public class TipoPlacaController : Controller
    {
        clsTipoPlaca ObjTipoPlaca = new clsTipoPlaca();
        
        // GET: TipoPlaca
        public ActionResult Index()
        {
            try
            {
                var datos = ObjTipoPlaca.ConsultarTipoPlaca();
                List<TipoPlaca> ListaTipoPlacas = new List<TipoPlaca>();

                foreach (var item in datos)
                {
                    TipoPlaca tipoPlaca = new TipoPlaca();
                    tipoPlaca.IdTipoPlaca = item.IdTipoPlaca;
                    tipoPlaca.DescripcionTP = item.Descripcion;
                    tipoPlaca.Estado = item.Estado;

                    ListaTipoPlacas.Add(tipoPlaca);
                }

                return View(ListaTipoPlacas);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar los tipos placas");

            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                var dato = ObjTipoPlaca.ConsultaTipoPlaca(id);
                TipoPlaca tipoPlaca = new TipoPlaca();
                tipoPlaca.IdTipoPlaca = dato.IdTipoPlaca;
                tipoPlaca.DescripcionTP = dato.Descripcion;
                tipoPlaca.Estado = dato.Estado;

                return View(tipoPlaca);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el tipo de placa");

            }
        }
        [HttpPost]

        public ActionResult Editar(TipoPlaca tipoPlaca)
        {
            try
            {
                if (ObjTipoPlaca.ActualizaTipoPlaca(tipoPlaca.IdTipoPlaca, tipoPlaca.DescripcionTP, tipoPlaca.Estado))
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
                return new HttpNotFoundResult("Error al consultar el tipo de placa");

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
                return new HttpNotFoundResult("Error al consultar el tipo de placa");

            }
        }

        [HttpPost]

        public ActionResult Crear(TipoPlaca tipoPlaca)
        {
            try
            {
                if (ObjTipoPlaca.IngresarTipoPlaca(tipoPlaca.DescripcionTP, tipoPlaca.Estado))
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
                return new HttpNotFoundResult("Error al consultar el tipo de placa");

            }
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                var dato = ObjTipoPlaca.ConsultaTipoPlaca(id);
                TipoPlaca tipoPlaca = new TipoPlaca();
                tipoPlaca.IdTipoPlaca = dato.IdTipoPlaca;
                tipoPlaca.DescripcionTP = dato.Descripcion;
                tipoPlaca.Estado = dato.Estado;

                ViewBag.Empresas = ObjTipoPlaca.ConsultarTipoPlaca();

                return View(tipoPlaca);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el tipo de placa");

            }
        }

        [HttpPost]

        public ActionResult Eliminar(TipoPlaca tipoPlaca)
        {
            try
            {

                if (ObjTipoPlaca.EliminaTipoPlaca(tipoPlaca.IdTipoPlaca))
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
                return new HttpNotFoundResult("Error al consultar el tipo de placa");

            }
        }
    }
}