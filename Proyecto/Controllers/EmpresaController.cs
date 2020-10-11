using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using BLL;
using DAL;
using Proyecto.Models;

namespace Proyecto.Controllers
{ 
    [Authorize]
    [AuthorizeRole(Role.Administrador, Role.Gerente, Role.Supervisor)]
    public class EmpresaController : Controller
    {
        clsEmpresa ObjEmpresa = new clsEmpresa();
        clsTipoIdentificacion ObjTipoIdentificacion = new clsTipoIdentificacion();


        // GET: Empresa
        public ActionResult Index()
        {
            try
            {
                var datos = ObjEmpresa.ConsultarEmpresa();
                List<Empresa> ListaEmpresas = new List<Empresa>();

                foreach (var item in datos)
                {
                    Empresa empresa = new Empresa();
                    empresa.IdEmpresa = item.IdEmpresa;
                    empresa.Descripcion = item.Descripcion;
                    empresa.IdTipoIdentificacion = item.IdTipoIdentificacion;
                    empresa.Identificacion = item.Identificacion;
                    empresa.Telefono = item.Telefono;
                    empresa.Contacto = item.Contacto;
                    empresa.Estado = item.Estado;

                    ListaEmpresas.Add(empresa);
                }

                return View(ListaEmpresas);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar las empresas");

            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                var dato = ObjEmpresa.ConsultaEmpresa(id);
                Empresa empresa = new Empresa();
                empresa.IdEmpresa = dato.IdEmpresa;
                empresa.Descripcion = dato.Descripcion;
                empresa.IdTipoIdentificacion = dato.IdTipoIdentificacion;
                empresa.Identificacion = dato.Identificacion;
                empresa.Telefono = dato.Telefono;
                empresa.Contacto = dato.Contacto;
                empresa.Estado = dato.Estado;

                ViewBag.TipoIdentificaciones = ObjTipoIdentificacion.ConsultarTipoIdentificacion();

                return View(empresa);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la empresa");

            }
        }
        [HttpPost]

        public ActionResult Editar(Empresa empresa)
        {
            try
            {
                if (ObjEmpresa.ActualizaEmpresa(empresa.IdEmpresa, empresa.Descripcion, empresa.IdTipoIdentificacion, empresa.Identificacion, empresa.Telefono, empresa.Contacto, empresa.Estado))
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
                return new HttpNotFoundResult("Error al consultar la empresa");

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
                return new HttpNotFoundResult("Error al consultar la empresa");

            }
        }

        [HttpPost]

        public ActionResult Crear(Empresa empresa)
        {
            try
            {
                if (ObjEmpresa.IngresarEmpresa(empresa.Descripcion, empresa.IdTipoIdentificacion, empresa.Identificacion, empresa.Telefono, empresa.Contacto, empresa.Estado))
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
                return new HttpNotFoundResult("Error al consultar la empresa");

            }
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                var dato = ObjEmpresa.ConsultaEmpresa(id);
                Empresa empresa = new Empresa();
                empresa.IdEmpresa = dato.IdEmpresa;
                empresa.Descripcion = dato.Descripcion;
                empresa.IdTipoIdentificacion = dato.IdTipoIdentificacion;
                empresa.Identificacion = dato.Identificacion;
                empresa.Telefono = dato.Telefono;
                empresa.Contacto = dato.Contacto;
                empresa.Estado = dato.Estado;

                ViewBag.TipoIdentificaciones = ObjTipoIdentificacion.ConsultarTipoIdentificacion();

                return View(empresa);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la empresa");

            }
        }

        [HttpPost]

        public ActionResult Eliminar(Empresa empresa)
        {
            try
            {
                if (ObjEmpresa.EliminaEmpresa(empresa.IdEmpresa))
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
                return new HttpNotFoundResult("Error al consultar la empresa");

            }

        }
    }
}