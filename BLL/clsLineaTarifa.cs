using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsLineaTarifa
    {
        public List<ConsultarLineaTarifaResult> ConsultarLineaTarifa()
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                List<ConsultarLineaTarifaResult> datos = db.ConsultarLineaTarifa().ToList();
                return datos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ConsultaLineaTarifaResult ConsultaLineaTarifa(int IdLineaTarifa)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                ConsultaLineaTarifaResult datos = db.ConsultaLineaTarifa(IdLineaTarifa).FirstOrDefault();
                return datos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminaLineaTarifa(int IdLinea)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.EliminaLineaTarifa(IdLinea);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool ActualizaLineaTarifa(int IdLinea, int IdTarifa)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.ActualizaLineaTarifa(IdLinea, IdTarifa);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool IngresaLineaTarifa(int IdLinea, int IdTarifa)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.IngresarLineaTarifa(IdLinea, IdTarifa);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
