using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

        public static void CerrarPublicaciones()
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                CerrarPublicaciones(db);

                db.EndConnection();
            }
        }

        private static void CerrarPublicaciones(DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter fechaParameter = new SqlParameter("@Fecha", SqlDbType.DateTime);
            fechaParameter.Value = new FechaHelper().GetSystemDate();

            parameters.Add(fechaParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "MASTERDBA.SP_CerrarPublicaciones", parameters);
        }
    }
}
