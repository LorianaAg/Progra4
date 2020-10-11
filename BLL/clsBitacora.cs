using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public static class clsBitacora
    {
        public static bool IngresarBitacora(string Controlador, string Accion,string Error,int Tipo,DateTime Fecha,int IdUsuario)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.IngresarBitacora(Controlador, Accion, Error, Tipo, Fecha, IdUsuario);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
