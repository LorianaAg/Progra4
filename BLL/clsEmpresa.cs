using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BLL
{
    public class clsEmpresa
    {
         public List<ConsultarEmpresaResult> ConsultarEmpresa() 
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                List<ConsultarEmpresaResult> datos = db.ConsultarEmpresa().ToList();
                return datos;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public ConsultaEmpresaResult ConsultaEmpresa(int IdEmpresa)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                ConsultaEmpresaResult datos = db.ConsultaEmpresa(IdEmpresa).FirstOrDefault();
                return datos;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminaEmpresa(int IdEmpresa)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.EliminaEmpresa(IdEmpresa);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ActualizaEmpresa(int IdEmpresa, string Descripcion, int IdTipoIdentificacion, string Identificacion, string Telefono, string Contacto, bool Estado)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.ActualizaEmpresa(IdEmpresa, Descripcion, IdTipoIdentificacion, Identificacion, Telefono, Contacto, Estado);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IngresarEmpresa(string Descripcion, int IdTipoIdentificacion, string Identificacion, string Telefono, string Contacto, bool Estado)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.IngresarEmpresa(Descripcion, IdTipoIdentificacion, Identificacion, Telefono, Contacto, Estado);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
   
