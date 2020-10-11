using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsTarifa
    {
        public List<ConsultarTarifaResult> ConsultarTarifa()
        {

            try
            {
                DatosDataContext db = new DatosDataContext();
                List<ConsultarTarifaResult> datos = db.ConsultarTarifa().ToList();
                return datos;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ConsultaTarifaResult ConsultaTarifa(int IdTarifa)
        {

            try
            {
                DatosDataContext db = new DatosDataContext();
                ConsultaTarifaResult datos = db.ConsultaTarifa(IdTarifa).FirstOrDefault();
                return datos;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool EliminaTarifa(int IdTarifa)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.EliminaTarifa(IdTarifa);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ActualizaTarifa(int IdTarifa, string Descripcion, decimal Monto, bool Estado)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.ActualizaTarifa(IdTarifa, Descripcion, Monto, Estado);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IngresarTarifa(string Descripcion, decimal Monto, bool Estado)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                db.IngresarTarifa(Descripcion, Monto, Estado);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ConsultaLineaCodigoResult ConsultaLineaCodigo(string Codigo)
        {

            try
            {
                DatosDataContext db = new DatosDataContext();
                ConsultaLineaCodigoResult datos = db.ConsultaLineaCodigo(Codigo).FirstOrDefault();
                return datos;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
