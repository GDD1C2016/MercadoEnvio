using System;
using System.Collections.Generic;
using MercadoEnvio.Entidades;
using MercadoEnvio.Helpers;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MercadoEnvio.DataManagers
{
    public class DataManagerCalificacion
    {
        public static List<Calificacion> GetUltimas(int idUsuario, int cantidad)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                List<Calificacion> listaCalificaciones = GetUltimas(idUsuario, cantidad, db);

                db.EndConnection();

                return listaCalificaciones;
            }
        }

        private static List<Calificacion> GetUltimas(int idUsuario, int cantidad, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idUsuarioParameter = new SqlParameter("@IdUsuario", SqlDbType.Int);
            idUsuarioParameter.Value = idUsuario;

            SqlParameter cantidadParameter = new SqlParameter("@Cantidad", SqlDbType.Int);
            cantidadParameter.Value = cantidad;

            parameters.Add(idUsuarioParameter);
            parameters.Add(cantidadParameter);

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetUltimasCalificaciones", parameters);
            List<Calificacion> calificaciones = new List<Calificacion>();
            foreach (DataRow row in res.Rows)
            {
                var calificacion = new Calificacion
                {
                    CantEstrellas = Convert.ToDecimal(row["CantEstrellas"]),
                    DescripcionCompra = Convert.ToString(row["DescripcionPublicacion"]),
                    IdCalificacion = Convert.ToDecimal(row["IdCalificacion"]),
                    IdCompra = Convert.ToInt32(row["IdCompra"]),
                    Observaciones = Convert.ToString(row["Descripcion"])
                };

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

        private static void InsertNewCalificacion(Calificacion calificacion, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idCompraParameter = new SqlParameter("@IdCompra", SqlDbType.Int);
            idCompraParameter.Value = calificacion.IdCompra;

            SqlParameter cantEstrellasParameter = new SqlParameter("@CantEstrellas", SqlDbType.Int);
            cantEstrellasParameter.Value = calificacion.CantEstrellas;

            SqlParameter descripcionParameter = new SqlParameter("@Descripcion", SqlDbType.Int);
            descripcionParameter.Value = calificacion.Observaciones;

            parameters.Add(idCompraParameter);
            parameters.Add(cantEstrellasParameter);
            parameters.Add(descripcionParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "MASTERDBA.SP_InsertNewCalificacion", parameters);
        }

        public static int GetCantidadCalificacionesDadas(int cantidadEstrellas, int idUsuario)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                var cantidad = GetCantidadCalificacionesDadas(cantidadEstrellas,idUsuario, db);

                db.EndConnection();

                return cantidad;
            }
        }

        private static int GetCantidadCalificacionesDadas(int cantidadEstrellas, int idUsuario, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter cantidadEstrellasParameter = new SqlParameter("@CantidadEstrellas", SqlDbType.Int);
            cantidadEstrellasParameter.Value = cantidadEstrellas;

            SqlParameter idUsuarioParameter = new SqlParameter("@IdUsuario", SqlDbType.Int);
            idUsuarioParameter.Value = idUsuario;
            
            parameters.Add(cantidadEstrellasParameter);
            parameters.Add(idUsuarioParameter);

            return (int)db.ExecInstruction(DataBaseHelper.ExecutionType.Scalar, "MASTERDBA.SP_GetCantidadCalificacionesDadas", parameters);
        }
    }
}
