using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercadoEnvio.Entidades;
using MercadoEnvio.Helpers;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MercadoEnvio.DataManagers
{
    public class DataManagerCalificacion
    {
        public static List<Calificacion> GetUltimas(int cantidad)
        {
            List<Calificacion> listaCalificaciones = new List<Calificacion>();
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                listaCalificaciones = GetUltimas(cantidad,db);

                db.EndConnection();

                return listaCalificaciones;
            }
        }

        private static List<Calificacion> GetUltimas(int cantidad, DataBaseHelper db)
        {
            DataTable res = db.GetDataAsTable("SP_GetUltimasCalificaciones"); //TODO HACER ESTE SP
            List<Calificacion> calificaciones = new List<Calificacion>();
            foreach (DataRow row in res.Rows)
            {
                var calificacion = new Calificacion();
                calificacion.CantEstrellas = Convert.ToDecimal(row["CantEstrellas"]);
                calificacion.DescripcionCompra = Convert.ToString(row["DescripcionCompra"]);
                calificacion.IdCalificacion = Convert.ToDecimal(row["IdCalificacion"]);
                calificacion.IdCompra = Convert.ToInt32(row["IdCompra"]);
                calificacion.Observaciones = Convert.ToString(row["Observaciones"]);

                calificaciones.Add(calificacion);
            }

            return calificaciones;
        }

        public static void InsertNewCalificacion(Calificacion calificacion)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                InsertNewCalificacion(calificacion, db);

                db.EndConnection();
            }
        }

        public static void InsertNewCalificacion(Calificacion calificacion, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery,"SP_InsertNewCalificacion",parameters); //TODO HACER ESTE SP
        }

        public static int GetCantidadDeEstrellasDadas(int cantidadEstrellas, int idUsuario)
        {
            int cantidad = 0;
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                cantidad = GetCantidadDeEstrellasDadas(cantidadEstrellas,idUsuario, db);

                db.EndConnection();

                return cantidad;
            }
        }

        public static int GetCantidadDeEstrellasDadas(int cantidadEstrellas, int idUsuario, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            int cantidad = (int)db.ExecInstruction(DataBaseHelper.ExecutionType.Scalar, "SP_GetCantidadEstrellas", parameters);//TODO HACER ESTE SP
            return cantidad;
        }
    }
}
