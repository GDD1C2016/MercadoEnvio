using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MercadoEnvio.Helpers;
using System.Configuration;

namespace MercadoEnvio.DataManagers
{
    public class DataManagerUsuario
    {
        public static Entidades.Login Login(string user, string passWord)
        {
            DataBaseHelper db = null;
            DataTable res;
            SqlParameter userParameter;
            SqlParameter passWordParameter;
            List<SqlParameter> parameters = new List<SqlParameter>();
            Entidades.Login login = new Entidades.Login();

            try
            {
                userParameter = new SqlParameter("@Usuario", SqlDbType.NVarChar);
                userParameter.Value = user;

                passWordParameter = new SqlParameter("@Password", SqlDbType.NVarChar);
                passWordParameter.Value = passWord;

                parameters.Add(userParameter);
                parameters.Add(passWordParameter);

                db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);
                res = db.GetDataAsTable("[TABLA]", parameters);

                return login;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                db.EndConnection();
            }
        }
    }
}
