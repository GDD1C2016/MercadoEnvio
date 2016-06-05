using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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
            DataBaseHelper db = null;
            object res;
            SqlParameter userNameParameter;
            List<SqlParameter> parameters = new List<SqlParameter>();
            Entidades.Login login = new Entidades.Login();
            Usuario usuarioEntidad = new Usuario();

            try
            {
                userNameParameter = new SqlParameter("@UserName", SqlDbType.NVarChar);
                userNameParameter.Value = userName;

                parameters.Add(userNameParameter);

                db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);
                db.Connection.Open();

                DataTable resAux = db.GetDataAsTable("SP_GetUsuarioByUserName", parameters);
                foreach (DataRow row in resAux.Rows)
                {
                    usuarioEntidad.IdUsuario = Convert.ToInt32(row["IdUsuario"]);
                    usuarioEntidad.UserName = Convert.ToString(row["UserName"]);
                    usuarioEntidad.Password = Convert.ToString(row["PassEncr"]);
                    usuarioEntidad.CantIntFallidos = Convert.ToByte(row["CantIntFallidos"]);
                    usuarioEntidad.Activo = Convert.ToBoolean(row["Activo"]);
                }

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
                        ResetearContadorUsuario(userName,db);

                        usuarioEntidad.CantIntFallidos = 0;
                        login.Usuario = usuarioEntidad;
                        login.LoginSuccess = true;
                    }
                    else
                    {
                        res = IncrementarContadorUsuario(userName, db);

                        usuarioEntidad.CantIntFallidos = (int)res;
                        login.Usuario = usuarioEntidad;
                        login.LoginSuccess = false;
                        login.ErrorMessage = Resources.ContraseñaIncorrecta;

                        if (usuarioEntidad.CantIntFallidos >= 3)
                        {
                            BloquearUsuario(userName, db);
                        }
                    }
                }
                return login;
            }
            catch (Exception ex)
            {
                throw new Exception(Resources.Error + ex.Message);
            }
            finally
            {
                db.EndConnection();
            }
        }

        private static void BloquearUsuario(string userName, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter userNameParameter;
            userNameParameter = new SqlParameter("@Usuario", SqlDbType.NVarChar);
            userNameParameter.Value = userName;
            parameters.Add(userNameParameter);

            db.ExectInstruction(DataBaseHelper.ExecutionType.NonQuery, "SP_BloqUser", parameters);
        }

        private static object IncrementarContadorUsuario(string userName, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter userNameParameter;
            userNameParameter = new SqlParameter("@Usuario", SqlDbType.NVarChar);
            userNameParameter.Value = userName;
            parameters.Add(userNameParameter);

            return db.ExectInstruction(DataBaseHelper.ExecutionType.Scalar, "SP_IncrementCountLogin", parameters);
        }

        private static void ResetearContadorUsuario(string userName, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter userNameParameter;
            userNameParameter = new SqlParameter("@Usuario", SqlDbType.NVarChar);
            userNameParameter.Value = userName;
            parameters.Add(userNameParameter);

            db.ExectInstruction(DataBaseHelper.ExecutionType.NonQuery, "SP_ResetCountLogin", parameters);
        }
    }
}
