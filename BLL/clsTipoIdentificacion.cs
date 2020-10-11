using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsTipoIdentificacion
    {
        public List<ConsultarTipoIdentificacionResult> ConsultarTipoIdentificacion()
        {

            try
            {
                DatosDataContext db = new DatosDataContext();
                List<ConsultarTipoIdentificacionResult> datos = db.ConsultarTipoIdentificacion().ToList();
                return datos;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public ConsultaTipoIdentificacionResult ConsultaTipoIdentificacion(int IdTipoIdentificacion)
        {

            try
            {
                DatosDataContext db = new DatosDataContext();
                ConsultaTipoIdentificacionResult datos = db.ConsultaTipoIdentificacion(IdTipoIdentificacion).FirstOrDefault();
                return datos;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public bool EliminaTipoIdentificacion(int IdTipoIdentificacion)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.EliminaTipoIdentificacion(IdTipoIdentificacion);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ActualizaTipoIdentificacion(int IdTipoIdentificacion, string Descripcion, bool Estado)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.ActualizaTipoIdentificacion(IdTipoIdentificacion, Descripcion, Estado);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IngresarTipoIdentificacion(string Descripcion, bool Estado)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.IngresarTipoIdentificacion(Descripcion, Estado);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
