using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsUnidad
    {
        public List<ConsultarUnidadResult> ConsultarUnidad()
        {

            try
            {
                DatosDataContext db = new DatosDataContext();
                List<ConsultarUnidadResult> datos = db.ConsultarUnidad().ToList();
                return datos;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ConsultaUnidadResult ConsultaUnidad(int IdUnidad)
        {
            try
            {

                DatosDataContext db = new DatosDataContext();
                ConsultaUnidadResult datos = db.ConsultaUnidad(IdUnidad).FirstOrDefault();
                return datos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminaUnidad(int IdUnidad)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.EliminaUnidad(IdUnidad);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ActualizaUnidad(int IdUnidad, string Descripcion,int IdTipoPlaca, string Placa, bool Estado)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.ActualizaUnidad(IdUnidad, Descripcion, IdTipoPlaca, Placa, Estado);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IngresarUnidad(string Descripcion, int IdTipoPlaca, string Placa, bool Estado)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.IngresarUnidad(Descripcion, IdTipoPlaca, Placa, Estado);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
