using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
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
            List<SqlParameter> parameters = new List<SqlParameter>();

            using (db.Connection)
            {
                db.BeginTransaction();

                SqlParameter userNameParameter = new SqlParameter("@UserName", SqlDbType.NVarChar);
                userNameParameter.Value = userName;

                parameters.Add(userNameParameter);

                DataTable res1 = db.GetDataAsTable("SP_GetUsuarioByUserName", parameters);

                Usuario usuarioEntidad = new Usuario();
                foreach (DataRow row in res1.Rows)
                {
                    usuarioEntidad.IdUsuario = Convert.ToInt32(row["IdUsuario"]);
                    usuarioEntidad.UserName = Convert.ToString(row["UserName"]);
                    usuarioEntidad.Password = Convert.ToString(row["PassEncr"]);
                    usuarioEntidad.CantIntFallidos = Convert.ToByte(row["CantIntFallidos"]);
                    usuarioEntidad.Activo = Convert.ToBoolean(row["Activo"]);
                }

                Entidades.Login login = new Entidades.Login();
                if (usuarioEntidad.IdUsuario == 0)
                {
                    login.LoginSuccess = false;
                    login.ErrorMessage = Resources.UsuarioNoExiste;
                }
                else
                {
                    if (!usuarioEntidad.Activo)
                    {
                        if (usuarioEntidad.CantIntFallidos >= 3)
                        {
                            login.Usuario = usuarioEntidad;
                            login.LoginSuccess = false;
                            login.ErrorMessage = Resources.UsuarioBloqueado + Resources.ContactarAdministrador;
                        }
                        else
                        {
                            login.Usuario = usuarioEntidad;
                            login.LoginSuccess = false;
                            login.ErrorMessage = Resources.UsuarioDeshabilitado + "\n" + Resources.ContactarAdministrador;
                        }
                    }
                    else if (usuarioEntidad.Password.Equals(password))
                    {
                        ResetearContadorUsuario(userName, db);

                        usuarioEntidad.CantIntFallidos = 0;
                        login.Usuario = usuarioEntidad;
                        login.LoginSuccess = true;
                    }
                    else
                    {
                        object res2 = IncrementarContadorUsuario(userName, db);

                        usuarioEntidad.CantIntFallidos = (int)res2;
                        login.Usuario = usuarioEntidad;
                        login.LoginSuccess = false;
                        login.ErrorMessage = Resources.ContraseñaIncorrecta;

                        if (usuarioEntidad.CantIntFallidos >= 3)
                        {
                            BloquearUsuario(userName, db);
                        }
                    }
                }

                db.EndConnection();

                return login;
            }
        }

        private static void BloquearUsuario(string userName, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter userNameParameter = new SqlParameter("@Usuario", SqlDbType.NVarChar);
            userNameParameter.Value = userName;

            parameters.Add(userNameParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "SP_BloqUser", parameters);
        }

        private static object IncrementarContadorUsuario(string userName, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter userNameParameter = new SqlParameter("@Usuario", SqlDbType.NVarChar);
            userNameParameter.Value = userName;

            parameters.Add(userNameParameter);

            return db.ExecInstruction(DataBaseHelper.ExecutionType.Scalar, "SP_IncrementCountLogin", parameters);
        }

        private static void ResetearContadorUsuario(string userName, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter userNameParameter = new SqlParameter("@Usuario", SqlDbType.NVarChar);
            userNameParameter.Value = userName;

            parameters.Add(userNameParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "SP_ResetCountLogin", parameters);
        }
    }
}
