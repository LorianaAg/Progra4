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
    public class TarifaController : Controller
    {
        clsTarifa ObjTarifa = new clsTarifa();

        // GET: Tarifa
        public ActionResult Index()
        {
            try
            {
                var datos = ObjTarifa.ConsultarTarifa();
                List<Tarifa> ListaTarifas = new List<Tarifa>();

                foreach (var item in datos)
                {
                    Tarifa tarifa = new Tarifa();
                    tarifa.IdTarifa = item.IdTarifa;
                    tarifa.Descripcion = item.Descripcion;
                    tarifa.Monto = item.Monto;
                    tarifa.Estado = item.Estado;

                    ListaTarifas.Add(tarifa);
                }

                return View(ListaTarifas);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar las tarifas");

            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                var dato = ObjTarifa.ConsultaTarifa(id);
                Tarifa tarifa = new Tarifa();
                tarifa.IdTarifa = dato.IdTarifa;
                tarifa.Descripcion = dato.Descripcion;
                tarifa.Monto = dato.Monto;
                tarifa.Estado = dato.Estado;

                return View(tarifa);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la tarifa");

            }
        }

        [HttpPost]

        public ActionResult Editar(Tarifa tarifa)
        {
            try
            {
                if (ObjTarifa.ActualizaTarifa(tarifa.IdTarifa, tarifa.Descripcion, tarifa.Monto, tarifa.Estado))               {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la tarifa");

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
                return new HttpNotFoundResult("Error al consultar la tarifa");

            }
        }

        [HttpPost]

        public ActionResult Crear(Tarifa tarifa)
        {
            try
            {
                if (ObjTarifa.IngresarTarifa(tarifa.Descripcion, tarifa.Monto, tarifa.Estado))
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
                return new HttpNotFoundResult("Error al consultar la tarifa");

            }
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                var dato = ObjTarifa.ConsultaTarifa(id);
                Tarifa tarifa = new Tarifa();
                tarifa.IdTarifa = dato.IdTarifa;
                tarifa.Descripcion = dato.Descripcion;
                tarifa.Monto = dato.Monto;
                tarifa.Estado = dato.Estado;

                return View(tarifa);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la tarifa");

            }
        }

        [HttpPost]

        public ActionResult Eliminar(Tarifa tarifa)
        {
            try
            {
                if (ObjTarifa.EliminaTarifa(tarifa.IdTarifa))
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
                return new HttpNotFoundResult("Error al consultar la tarifa");

            }

        }

    }
}