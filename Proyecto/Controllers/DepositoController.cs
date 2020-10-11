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
    public class DepositoController : Controller
    {
        clsDeposito ObjDeposito = new clsDeposito();
        clsUsuario ObjUsuario = new clsUsuario();

        // GET: Deposito
        public ActionResult Index()
        {
            try
            {
                var datos = ObjDeposito.ConsultarDeposito();
                List<Deposito> ListaDepositos = new List<Deposito>();

                foreach (var item in datos)
                {
                    Deposito deposito = new Deposito();
                    deposito.IdDeposito = item.IdDeposito;
                    deposito.IdUsuario = (int)item.IdUsuario;
                    deposito.NombreUsuario = item.Nombre;
                    deposito.Telefono = item.Telefono;
                    deposito.Monto = item.Monto;
                    deposito.Fecha = item.Fecha;
                    deposito.Estado = item.Estado;                    
                    

                    ListaDepositos.Add(deposito);
                }

                return View(ListaDepositos);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar los depositos");

            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                var dato = ObjDeposito.ConsultaDeposito(id);
                Deposito deposito = new Deposito();
                deposito.IdDeposito = dato.IdDeposito;
                deposito.IdUsuario = (int)dato.IdUsuario;
                deposito.Telefono = dato.Telefono;
                deposito.Monto = dato.Monto;
                deposito.Fecha = dato.Fecha;
                deposito.Estado = dato.Estado;

                ViewBag.Usuarios = ObjUsuario.ConsultarUsuario();

                return View(deposito);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el deposito");

            }
        }

        [HttpPost]

        public ActionResult Editar(Deposito deposito)
        {
            try
            {
                if (ObjDeposito.ActualizaDeposito(deposito.IdDeposito, deposito.IdUsuario, deposito.Telefono, deposito.Monto, deposito.Fecha, deposito.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Usuarios = ObjUsuario.ConsultarUsuario();

                    return View();
                }

            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el deposito");

            }
        }

        public ActionResult Crear()
        {
            try
            {
                ViewBag.Usuarios = ObjUsuario.ConsultarUsuario();

                return View();
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el deposito");

            }
        }

        [HttpPost]

        public ActionResult Crear(Deposito deposito)
        {
            try
            {
                if (ObjDeposito.IngresarDeposito(deposito.IdUsuario, deposito.Telefono, deposito.Monto, deposito.Fecha, deposito.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Usuarios = ObjUsuario.ConsultarUsuario();

                    return View();
                }

            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el deposito");

            }
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                var dato = ObjDeposito.ConsultaDeposito(id);
                Deposito deposito = new Deposito();
                deposito.IdDeposito = dato.IdDeposito;
                deposito.IdUsuario = (int)dato.IdUsuario;
                deposito.NombreUsuario = dato.Nombre;
                deposito.Telefono = dato.Telefono;
                deposito.Monto = dato.Monto;
                deposito.Fecha = dato.Fecha;
                deposito.Estado = dato.Estado;

                ViewBag.Usuarios = ObjUsuario.ConsultarUsuario();

                return View(deposito);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el deposito");

            }
        }

        [HttpPost]

        public ActionResult Eliminar(Deposito deposito)
        {
            try
            {
                if (ObjDeposito.EliminaDeposito(deposito.IdDeposito))
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
                return new HttpNotFoundResult("Error al consultar el deposito");

            }

        }
    }
}