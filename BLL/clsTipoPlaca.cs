using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
   public class clsTipoPlaca
    {
       public List<ConsultarTipoPlacaResult> ConsultarTipoPlaca() 
        {

            try
            {
                DatosDataContext db = new DatosDataContext();
                List<ConsultarTipoPlacaResult> datos = db.ConsultarTipoPlaca().ToList();
                return datos;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public ConsultaTipoPlacaResult ConsultaTipoPlaca(int IdTipoPlaca)
        {
            try
            {

                DatosDataContext db = new DatosDataContext();
                ConsultaTipoPlacaResult datos = db.ConsultaTipoPlaca(IdTipoPlaca).FirstOrDefault();
                return datos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminaTipoPlaca(int IdTipoPlaca)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.EliminaTipoPlaca(IdTipoPlaca);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ActualizaTipoPlaca(int IdTipoPlaca, string Descripcion, bool Estado)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.ActualizaTipoPlaca(IdTipoPlaca, Descripcion, Estado);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IngresarTipoPlaca(string Descripcion, bool Estado)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.IngresarTipoPlaca(Descripcion, Estado);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
 