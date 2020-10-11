using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsRol
    {
        public List<ConsultarRolResult> ConsultarRol()
        {

            try
            {
                DatosDataContext db = new DatosDataContext();
                List<ConsultarRolResult> datos = db.ConsultarRol().ToList();
                return datos;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public ConsultaRolResult ConsultaRol(int IdRol)
        {

            try
            {
                DatosDataContext db = new DatosDataContext();
                ConsultaRolResult datos = db.ConsultaRol(IdRol).FirstOrDefault();
                return datos;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public bool EliminaRol(int IdTarifa)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.EliminaRol(IdTarifa);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ActualizaRol(int IdRol, string Descripcion, bool Estado)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.ActualizaRol(IdRol, Descripcion, Estado);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IngresarRol(string Descripcion, bool Estado)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.IngresarRol(Descripcion, Estado);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
