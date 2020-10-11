using BLL;
using DAL;
using Proyecto.Models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    [Authorize]
    public class CarnetController : Controller
    {
        clsUsuario ObjUsuario = new clsUsuario();

        // GET: Carnet
        public ActionResult Index()
        {
            var datos = ObjUsuario.ConsultaUsuarioIdentificacion(Session["Identificacion"].ToString());
            ViewBag.Identificacion = datos.Identificacion;
            ViewBag.Nombre = datos.Nombre + " " + datos.Apellido1;
            ViewBag.Telefono = datos.Telefono;
            ViewBag.Saldo = (int)datos.Saldo;           

            var URLCarnet = ConfigurationManager.AppSettings["URLCarnet"];
            ViewBag.Identificacion = URLCarnet + Session["Identificacion"].ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(URLCarnet + Session["Identificacion"].ToString(), QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            //System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            //imgBarCode.Height = 150;
            //imgBarCode.Width = 150;
            using (Bitmap bitMap = qrCode.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    ViewBag.imageBytes = ms.ToArray();
                    //imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                }
            }

            return View();
        }
    }
}