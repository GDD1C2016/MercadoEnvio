using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "MASTERDBA.SP_ConfigurarFechas",new List<SqlParameter>());
        }

        public static void CerrarSubastas()
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                CerrarSubastas(db);

                db.EndConnection();
            }
        }

        private static void CerrarSubastas(DataBaseHelper db)
        {
            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "MASTERDBA.SP_CerrarSubastas", new List<SqlParameter>());
        }
    }
}
