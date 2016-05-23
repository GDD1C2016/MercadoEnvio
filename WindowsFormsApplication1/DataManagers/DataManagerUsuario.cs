using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MercadoEnvio.Helpers;
using System.Configuration;
using MercadoEnvio.Entidades;

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
            Usuario usuarioEntidad = new Usuario();

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

                DataTable resAux = db.GetDataAsTable("SP_Login", parameters);
                foreach (DataRow row in resAux.Rows)
                {
                    usuarioEntidad.IdUsuario = Convert.ToInt32(row["IdUsuario"]);
                    usuarioEntidad.CantIntentos = Convert.ToByte(row["CantIntentos"]);
                    usuarioEntidad.Estado = Convert.ToString(row["Estado"]);
                    usuarioEntidad.Password = Convert.ToString(row["PassEncr"]);
                    usuarioEntidad.UserName = Convert.ToString(row["UserName"]);
                }

                if (usuarioEntidad.IdUsuario == 0)
                {
                    login.LoginSuccess = false;
                    login.ErrorMessage = "El usuario no existe";
                }
                else
                {
                    if(usuarioEntidad.Estado != "H")
                    {
                        login.LoginSuccess = false;
                        login.ErrorMessage = "Usuario bloqueado. Contacte al administrador";
                    }
                    else if (usuarioEntidad.Password.Equals(passWord))
                    {
                        ResetearContadorUsuario(user,db);

                        usuarioEntidad.CantIntentos = 0;
                        login.Usuario = usuarioEntidad;
                        login.LoginSuccess = true;
                    }
                    else
                    {
                        res = IncrementarContadorUsuario(user, db);
                        
                        login.LoginSuccess = false;
                        usuarioEntidad.CantIntentos = (byte)res;
                        login.ErrorMessage = "Contraseña Incorrecta";

                        if (usuarioEntidad.CantIntentos >= 3)
                        {
                            BloquearUsuario(user, db);
                        }
                        login.Usuario = usuarioEntidad;
                    }
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
