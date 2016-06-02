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
        public static Entidades.Login Login(string user, string password)
        {
            DataBaseHelper db = null;
            object res;
            SqlParameter userParameter;
            SqlParameter passwordParameter;
            List<SqlParameter> parameters = new List<SqlParameter>();
            Entidades.Login login = new Entidades.Login();
            Usuario usuarioEntidad = new Usuario();

            try
            {
                userParameter = new SqlParameter("@Usuario", SqlDbType.NVarChar);
                userParameter.Value = user;

                passwordParameter = new SqlParameter("@Password", SqlDbType.NVarChar);
                passwordParameter.Value = password;

                parameters.Add(userParameter);
                parameters.Add(passwordParameter);

                db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);
                db.Connection.Open();

                DataTable resAux = db.GetDataAsTable("SP_Login", parameters);
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
                        ResetearContadorUsuario(user,db);

                        usuarioEntidad.CantIntFallidos = 0;
                        login.Usuario = usuarioEntidad;
                        login.LoginSuccess = true;
                    }
                    else
                    {
                        res = IncrementarContadorUsuario(user, db);

                        usuarioEntidad.CantIntFallidos = (int)res;
                        login.Usuario = usuarioEntidad;
                        login.LoginSuccess = false;
                        login.ErrorMessage = Resources.ContraseñaIncorrecta;

                        if (usuarioEntidad.CantIntFallidos >= 3)
                        {
                            BloquearUsuario(user, db);
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

        private static void BloquearUsuario(string user, DataBaseHelper db)
        {
            List<SqlParameter> paramUsuario = new List<SqlParameter>();
            SqlParameter usuario;
            usuario = new SqlParameter("@Usuario", SqlDbType.NVarChar);
            usuario.Value = user;
            paramUsuario.Add(usuario);

            db.ExectInstruction(DataBaseHelper.ExecutionType.NonQuery, "SP_BloqUser", paramUsuario);
        }

        private static object IncrementarContadorUsuario(string user, DataBaseHelper db)
        {
            List<SqlParameter> paramUsuario = new List<SqlParameter>();
            SqlParameter usuario;
            usuario = new SqlParameter("@Usuario", SqlDbType.NVarChar);
            usuario.Value = user;
            paramUsuario.Add(usuario);

            return db.ExectInstruction(DataBaseHelper.ExecutionType.Scalar, "SP_IncrementCountLogin", paramUsuario);
        }

        private static void ResetearContadorUsuario(string user, DataBaseHelper db)
        {
            List<SqlParameter> paramUsuario = new List<SqlParameter>();
            SqlParameter usuario;
            usuario = new SqlParameter("@Usuario", SqlDbType.NVarChar);
            usuario.Value = user;
            paramUsuario.Add(usuario);

            db.ExectInstruction(DataBaseHelper.ExecutionType.NonQuery, "SP_ResetCountLogin", paramUsuario);
        }
    }
}
