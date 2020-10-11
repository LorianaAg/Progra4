using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsLineaUnidad
    {
        public List<ConsultarLineaUnidadResult> ConsultarLineaUnidad()
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                List<ConsultarLineaUnidadResult> datos = db.ConsultarLineaUnidad().ToList();
                return datos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ConsultaLineaUnidadResult ConsultaLineaUnidad(int IdLineaUnidad)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                ConsultaLineaUnidadResult datos = db.ConsultaLineaUnidad(IdLineaUnidad).FirstOrDefault();
                return datos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminaLineaUnidad(int IdUnidad)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.EliminaLineaUnidad(IdUnidad);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool ActualizaLineaUnidad(int IdUnidad, int IdLinea)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.ActualizaLineaUnidad(IdUnidad, IdLinea);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool IngresaLineaUnidad(int IdUnidad, int IdLinea)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.IngresarLineaUnidad(IdUnidad, IdLinea);
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

