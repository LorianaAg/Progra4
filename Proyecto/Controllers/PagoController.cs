using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class PagoController : Controller
    {

        clsUsuario ObjUsuario = new clsUsuario();

        // GET: Pago
        public ActionResult Index(string id)
        {
            var datos = ObjUsuario.ConsultaUsuarioIdentificacion(id);

            ViewBag.Identificacion = id;
            ViewBag.Nombre = datos.Nombre + " " + datos.Apellido1;
            ViewBag.Telefono = datos.Telefono;
            ViewBag.Saldo = (int)datos.Saldo;
                       
            return View();
        }
    }
}