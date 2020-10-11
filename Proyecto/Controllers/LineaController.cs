using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Windows.Shapes;
using BLL;
using DAL;
using Proyecto.Models;

namespace Proyecto.Controllers
{

    [Authorize]
    [AuthorizeRole(Role.Administrador, Role.Gerente, Role.Supervisor)]
    public class LineaController : Controller
    {
        clsLinea ObjLinea = new clsLinea();
        clsEmpresa ObjEmpresa = new clsEmpresa();
        clsConsulta ObjConsulta = new clsConsulta();
        clsTarifa ObjTarifa = new clsTarifa();
        clsLineaTarifa ObjLineaTarifa = new clsLineaTarifa();


        // GET: Linea
        
        public ActionResult Index()
        {
            try
            {
                Session["Empresa"] = 1;
                var datos = ObjLinea.ConsultarLinea(Convert.ToInt32(Session["Empresa"].ToString()));
                List<Linea> ListaLineas = new List<Linea>();

                foreach (var item in datos)
                {
                    Linea linea = new Linea();
                    linea.IdEmpresa = item.IdEmpresa;
                    linea.IdLinea = item.IdLinea;
                    linea.Descripcion = item.Descripcion;
                    linea.CodigoCTP = item.CodigoCTP;
                    linea.Provincia = (char)item.Provincia;
                    linea.Canton = item.Canton;
                    linea.Distrito = item.Distrito;
                    linea.Estado = item.Estado;
                    linea.ProvinciaDesc = item.ProvinciaDesc;
                    linea.CantonDesc = item.CantonDesc;
                    linea.DistritoDesc = item.DistritoDesc;
                    //linea.DescripcionT = item.DescripcionTarifa;

                    ListaLineas.Add(linea);
                }

                return View(ListaLineas);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar las lineas");

            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                Session["Empresa"] = 1;
                var dato = ObjLinea.ConsultaLinea(Convert.ToInt32(Session["Empresa"].ToString()), id);
                Linea linea = new Linea();
                linea.IdEmpresa = dato.IdEmpresa;
                linea.IdLinea = dato.IdLinea;
                linea.Descripcion = dato.Descripcion;
                linea.CodigoCTP = dato.CodigoCTP;
                linea.Provincia = (char)dato.Provincia;
                linea.Canton = dato.Canton;
                linea.Distrito = dato.Distrito;
                linea.DescripcionT = dato.DescripcionTarifa;
                linea.Estado = dato.Estado;

                ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();
                ViewBag.Provincias = ObjConsulta.ListaProvincias(); 
                ViewBag.Cantones = ObjConsulta.ListaCantones(linea.Provincia);
                ViewBag.Distritos = ObjConsulta.ListaDistritos(linea.Provincia, linea.Canton);
                ViewBag.Tarifas = ObjTarifa.ConsultarTarifa();


                return View(linea);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la linea");

            }
        }
        [HttpPost]

        public ActionResult Editar(Linea linea)
        {
            try            {
                Session["Empresa"] = 1;

                if (ObjLinea.ActualizaLinea(Convert.ToInt32(Session["Empresa"].ToString()), linea.IdLinea, linea.Descripcion, linea.CodigoCTP, linea.Provincia, linea.Canton, linea.Distrito, linea.Estado))
                {
                    ObjLineaTarifa.ActualizaLineaTarifa(linea.IdLinea, linea.IdTarifa);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();
                    ViewBag.Provincias = ObjConsulta.ListaProvincias();
                    ViewBag.Cantones = ObjConsulta.ListaCantones(linea.Provincia);
                    ViewBag.Distritos = ObjConsulta.ListaDistritos(linea.Provincia, linea.Canton);
                    ViewBag.Tarifas = ObjTarifa.ConsultarTarifa();

                    return View();
                }

            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la linea");

            }
        }

        public ActionResult Crear()
        {
            try
            {

                ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();
                ViewBag.Tarifas = ObjTarifa.ConsultarTarifa();
                ViewBag.Provincias = ObjConsulta.ListaProvincias();
                return View();
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la linea");

            }
        }

        [HttpPost]

        public ActionResult Crear(Linea linea)
        {
            try
            {
                Session["Empresa"] = 1;


                if (ObjLinea.IngresaLinea(Convert.ToInt32(Session["Empresa"].ToString()), linea.Descripcion, linea.CodigoCTP, linea.Provincia, linea.Canton, linea.Distrito, linea.Estado))
                {
                    int TarifaLocal = ObjTarifa.ConsultaLineaCodigo(linea.CodigoCTP).IdLinea;
                    ObjLineaTarifa.IngresaLineaTarifa(TarifaLocal, linea.IdTarifa);

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();
                    ViewBag.Provincias = ObjConsulta.ListaProvincias();
                    ViewBag.Cantones = ObjConsulta.ListaCantones(linea.Provincia);
                    ViewBag.Distritos = ObjConsulta.ListaDistritos(linea.Provincia, linea.Canton);
                    ViewBag.Tarifas = ObjTarifa.ConsultarTarifa();

                    return View();
                }

            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la linea");

            }
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                Session["Empresa"] = 1;
                var dato = ObjLinea.ConsultaLinea(Convert.ToInt32(Session["Empresa"].ToString()), id);
                Linea linea = new Linea();
                linea.IdEmpresa = dato.IdEmpresa;
                linea.IdLinea = dato.IdLinea;
                linea.Descripcion = dato.Descripcion;
                linea.CodigoCTP = dato.CodigoCTP;
                linea.Provincia = (char)dato.Provincia;
                linea.Canton = dato.Canton;
                linea.Distrito = dato.Distrito;
                linea.Estado = dato.Estado;
                linea.DescripcionT = dato.DescripcionTarifa;

                ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();


                return View(linea);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la linea");

            }
        }

        [HttpPost]

        public ActionResult Eliminar(Linea linea)
        {
            try
            {
                Session["Empresa"] = 1;

                ObjLineaTarifa.EliminaLineaTarifa(linea.IdLinea);
                if (ObjLinea.EliminaLinea(Convert.ToInt32(Session["Empresa"].ToString()), linea.IdLinea))
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
                return new HttpNotFoundResult("Error al consultar la linea");

            }

        }        

            /// <summary>
            /// Cargar Cantones hacia la pantalla
            /// </summary>
            /// <param name="provincia"></param>
            /// <returns></returns>
            [HttpPost]
            public JsonResult CargaCantones(char provincia)
            {
                List<CantonesResult> cantones = ObjConsulta.ListaCantones(provincia);
                return Json(cantones, JsonRequestBehavior.AllowGet);
            }
            /// <summary>
            /// Cargar Distritos hacia la pantalla
            /// </summary>
            /// <param name="provincia"></param>
            /// <param name="canton"></param>
            /// <returns></returns>
            [HttpPost]
            public JsonResult CargaDistritos(char provincia, string canton)
            {
                List<DistritosResult> distritos = ObjConsulta.ListaDistritos(provincia, canton);
                return Json(distritos, JsonRequestBehavior.AllowGet);

            }
        }
}