using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MercadoEnvio.Entidades;
using MercadoEnvio.Helpers;

namespace MercadoEnvio.DataManagers
{
    public class DataManagerActualizacion
    {
        public static void ConfigurarFechas()
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                ConfigurarFechas(db);

                db.EndConnection();
            }
        }

        private static void ConfigurarFechas(DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter fechaParameter = new SqlParameter("@Fecha", SqlDbType.DateTime);
            fechaParameter.Value = new FechaHelper().GetSystemDate();

            parameters.Add(fechaParameter);
            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "MASTERDBA.SP_ConfigurarFechas",parameters);
        }

        public static int CerrarPublicacion(int idPublicacion)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                int idCompra = CerrarPublicacion(idPublicacion, db); // Devuelve el número de compra de la oferta adjudicada si la publicación es una subasta

                db.EndConnection();

                return idCompra;
            }
        }

        private static int CerrarPublicacion(int idPublicacion, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idPublicacionParameter = new SqlParameter("@IdPublicacion", SqlDbType.Decimal);
            idPublicacionParameter.Value = idPublicacion;

            parameters.Add(idPublicacionParameter);

            return Convert.ToInt32(db.ExecInstruction(DataBaseHelper.ExecutionType.Scalar, "MASTERDBA.SP_CerrarPublicacion", parameters));
        }

        public static List<Publicacion> PublicacionesACerrar()
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                List<Publicacion> publicaciones = PublicacionesACerrar(db);

                db.EndConnection();

                return publicaciones;
            }
        }

        private static List<Publicacion> PublicacionesACerrar(DataBaseHelper db)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter fechaParameter = new SqlParameter("@Fecha", SqlDbType.DateTime);
            fechaParameter.Value = new FechaHelper().GetSystemDate();

            parameters.Add(fechaParameter);

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_PublicacionesACerrar", parameters);
            foreach (DataRow row in res.Rows)
            {
                var publicacion = new Publicacion
                {
                    IdPublicacion = Convert.ToInt32(row["IdPublicacion"]),
                };

                publicaciones.Add(publicacion);
            }

            return publicaciones;
        }
    }
}
