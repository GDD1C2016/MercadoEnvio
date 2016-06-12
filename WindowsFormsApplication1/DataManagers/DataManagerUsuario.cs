using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MercadoEnvio.Helpers;
using System.Configuration;
using MercadoEnvio.Entidades;
using MercadoEnvio.Properties;

namespace MercadoEnvio.DataManagers
{
    public class DataManagerUsuario
    {
        public static Entidades.Login Login(string userName, string password)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                Usuario usuario = GetUsuarioByUserName(userName, db);

                Entidades.Login login = new Entidades.Login();
                if (usuario.IdUsuario == 0)
                {
                    login.LoginSuccess = false;
                    login.ErrorMessage = Resources.UsuarioNoExiste;
                }
                else
                {
                    if (!usuario.Activo)
                    {
                        if (usuario.CantIntFallidos >= 3)
                        {
                            login.Usuario = usuario;
                            login.LoginSuccess = false;
                            login.ErrorMessage = Resources.UsuarioBloqueado + Resources.ContactarAdministrador;
                        }
                        else
                        {
                            login.Usuario = usuario;
                            login.LoginSuccess = false;
                            login.ErrorMessage = Resources.UsuarioDeshabilitado + "\n" + Resources.ContactarAdministrador;
                        }
                    }
                    else if (usuario.Password.Equals(password))
                    {
                        ResetCountLogin(userName, db);

                        usuario.CantIntFallidos = 0;
                        login.Usuario = usuario;
                        login.LoginSuccess = true;
                    }
                    else
                    {
                        usuario.CantIntFallidos = (int)IncrementCountLogin(userName, db);

                        login.Usuario = usuario;
                        login.LoginSuccess = false;
                        login.ErrorMessage = Resources.ContraseñaIncorrecta;

                        if (usuario.CantIntFallidos >= 3)
                            BloqUser(userName, db);
                    }
                }

                db.EndConnection();

                return login;
            }
        }

        private static Usuario GetUsuarioByUserName(string userName, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter userNameParameter = new SqlParameter("@UserName", SqlDbType.NVarChar);
            userNameParameter.Value = userName;

            parameters.Add(userNameParameter);

            DataTable res = db.GetDataAsTable("SP_GetUsuarioByUserName", parameters);
            Usuario usuario = new Usuario();
            foreach (DataRow row in res.Rows)
            {
                usuario.IdUsuario = Convert.ToInt32(row["IdUsuario"]);
                usuario.UserName = Convert.ToString(row["UserName"]);
                usuario.Password = Convert.ToString(row["PassEncr"]);
                usuario.CantIntFallidos = Convert.ToByte(row["CantIntFallidos"]);
                usuario.Activo = Convert.ToBoolean(row["Activo"]);
            }

            return usuario;
        }

        private static void BloqUser(string userName, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter userNameParameter = new SqlParameter("@UserName", SqlDbType.NVarChar);
            userNameParameter.Value = userName;

            parameters.Add(userNameParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "SP_BloqUser", parameters);
        }

        private static object IncrementCountLogin(string userName, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter userNameParameter = new SqlParameter("@UserName", SqlDbType.NVarChar);
            userNameParameter.Value = userName;

            parameters.Add(userNameParameter);

            return db.ExecInstruction(DataBaseHelper.ExecutionType.Scalar, "SP_IncrementCountLogin", parameters);
        }

        private static void ResetCountLogin(string userName, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter userNameParameter = new SqlParameter("@UserName", SqlDbType.NVarChar);
            userNameParameter.Value = userName;

            parameters.Add(userNameParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "SP_ResetCountLogin", parameters);
        }
    }
}
