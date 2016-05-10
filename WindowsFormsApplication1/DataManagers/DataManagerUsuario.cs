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
            object res;
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
                db.Connection.Open();

                res = db.ExectInstruction(DataBaseHelper.ExecutionType.Scalar, "SP_Login", parameters);
                if ((int) res == 1)
                {
                    login.LoginSuccess = true;
                    db.ExectInstruction(DataBaseHelper.ExecutionType.NonQuery, "SP_ResetCountLogin", new List<SqlParameter>());
                }
                else
                {
                    login.LoginSuccess = false;
                    db.ExectInstruction(DataBaseHelper.ExecutionType.NonQuery, "SP_IncrementCountLogin", new List<SqlParameter>());
                }
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
