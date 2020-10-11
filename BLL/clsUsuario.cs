using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsUsuario
    {
        public List<ConsultarUsuarioResult> ConsultarUsuario()
        {

            try
            {
                DatosDataContext db = new DatosDataContext();
                List<ConsultarUsuarioResult> datos = db.ConsultarUsuario().ToList();
                return datos;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public ConsultaUsuarioResult ConsultaUsuario(int IdUsuario)
        {

            try
            {
                DatosDataContext db = new DatosDataContext();
                ConsultaUsuarioResult datos = db.ConsultaUsuario(IdUsuario).FirstOrDefault();
                return datos;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ValidaUsuarioResult ValidaUsuario(string Correo, string Clave)
        {

            try
            {
                DatosDataContext db = new DatosDataContext();
                ValidaUsuarioResult dato = db.ValidaUsuario(Correo, Clave).FirstOrDefault();
                return dato;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<UsuarioRolesResult> RolesUsuario(int IdUsuario)
        {

            try
            {
                DatosDataContext db = new DatosDataContext();
                List<UsuarioRolesResult> datos = db.UsuarioRoles(IdUsuario).ToList();
                return datos;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool EliminaUsuario(int IdUsuario)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.EliminaUsuario(IdUsuario);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        public bool ActualizaUsuario(int IdUsuario, string Nombre, string Nombre2, string Apellido1, string Apellido2, int IdTipoIdentificacion, string Identificacion, decimal Saldo, string Telefono, string Correo, string Clave, bool Estado)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.ActualizaUsuario(IdUsuario, Nombre, Nombre2, Apellido1,Apellido2,IdTipoIdentificacion, Identificacion, Saldo, Telefono, Correo, Clave, Estado);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IngresarUsuario(string Nombre, string Nombre2, string Apellido1, string Apellido2, int IdTipoIdentificacion, string Identificacion, decimal Saldo, string Telefono, string Correo, string Clave, bool Estado)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.IngresarUsuario(Nombre, Nombre2, Apellido1, Apellido2,  IdTipoIdentificacion, Identificacion, Saldo, Telefono, Correo, Clave, Estado);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ConsultaUsuarioCorreoResult ConsultaUsuarioCorreo(string Correo)
        {

            try
            {
                DatosDataContext db = new DatosDataContext();
                ConsultaUsuarioCorreoResult datos = db.ConsultaUsuarioCorreo(Correo).FirstOrDefault();
                return datos;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ConsultaUsuarioIdentificacionResult ConsultaUsuarioIdentificacion (string Identificacion)
        {

            try
            {
                DatosDataContext db = new DatosDataContext();
                ConsultaUsuarioIdentificacionResult datos = db.ConsultaUsuarioIdentificacion(Identificacion).FirstOrDefault();
                return datos;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public bool ActualizaSaldoUsuario (decimal Monto, int IdUsuario)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.ActualizaSaldoUsuario(Monto, IdUsuario);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
