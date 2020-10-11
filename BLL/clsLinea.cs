using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsLinea
    {
        public List<ConsultarLineaResult> ConsultarLinea(int IdEmpresa)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                List<ConsultarLineaResult> datos = db.ConsultarLinea(IdEmpresa).ToList();
                return datos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ConsultaLineaResult ConsultaLinea(int IdEmpresa, int IdLinea)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                ConsultaLineaResult datos = db.ConsultaLinea(IdEmpresa, IdLinea).FirstOrDefault();
                return datos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminaLinea(int IdEmpresa, int IdLinea)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.EliminaLinea(IdEmpresa, IdLinea);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool ActualizaLinea(int IdEmpresa, int IdLinea, string Descripcion, string CodigoCTP, char Provincia, string Canton, string Distrito, bool Estado)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.ActualizaLinea(IdEmpresa, IdLinea, Descripcion, CodigoCTP, Provincia, Canton, Distrito, Estado);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool IngresaLinea(int IdEmpresa, string Descripcion, string CodigoCTP, char Provincia, string Canton, string Distrito, bool Estado)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.IngresarLinea(IdEmpresa, Descripcion, CodigoCTP, Provincia, Canton, Distrito, Estado);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public ConsultaUnidadPlacaResult ConsultaUnidadPlaca(string Placa)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                ConsultaUnidadPlacaResult datos = db.ConsultaUnidadPlaca(Placa).FirstOrDefault();
                return datos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
