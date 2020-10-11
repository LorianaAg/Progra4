using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsUsuarioRol
    {
        public List<ConsultarUsuarioRolResult> ConsultarUsuarioRol()
        {

            try
            {
                DatosDataContext db = new DatosDataContext();
                List<ConsultarUsuarioRolResult> datos = db.ConsultarUsuarioRol().ToList();
                return datos;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ConsultaUsuarioRolResult ConsultaUsuarioRol(int IdUsuarioRol)
        {

            try
            {
                DatosDataContext db = new DatosDataContext();
                ConsultaUsuarioRolResult dato = db.ConsultaUsuarioRol(IdUsuarioRol).FirstOrDefault();
                return dato;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool EliminaUsuarioRol(int IdUsuario)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.EliminaUsuarioRol(IdUsuario);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ActualizaUsuarioRol(int IdUsuario, int IdRol)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.ActualizaUsuarioRol(IdUsuario, IdRol);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IngresarUsuarioRol(int IdUsuario, int IdRol)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.IngresarUsuarioRol(IdUsuario, IdRol);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
