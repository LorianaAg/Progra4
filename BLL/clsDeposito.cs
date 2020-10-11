using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsDeposito
    {
        public List<ConsultarDepositoResult> ConsultarDeposito()
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                List<ConsultarDepositoResult> datos = db.ConsultarDeposito().ToList();
                return datos;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public ConsultaDepositoResult ConsultaDeposito(int IdDeposito)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                ConsultaDepositoResult datos = db.ConsultaDeposito(IdDeposito).FirstOrDefault();
                return datos;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminaDeposito(int IdDeposito)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.EliminaDeposito(IdDeposito);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ActualizaDeposito(int IdDeposito, int IdUsuario, string Telefono, decimal Monto, DateTime Fecha, string Estado)
        {
            try 
            {
                DatosDataContext db = new DatosDataContext();
                db.ActualizaDeposito(IdDeposito, IdUsuario, Telefono, Monto, Fecha, Estado);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IngresarDeposito(int IdUsuario, string Telefono, decimal Monto, DateTime Fecha, string Estado)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.IngresarDeposito(IdUsuario, Telefono, Monto, Fecha, Estado);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
