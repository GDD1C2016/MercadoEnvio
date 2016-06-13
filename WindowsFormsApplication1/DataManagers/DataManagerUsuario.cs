using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MercadoEnvio.Helpers;
using System.Configuration;
using MercadoEnvio.Entidades;
using MercadoEnvio.Properties;
using MercadoEnvio.Servicios;

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

        public static List<Cliente> FindClientes(string filtroNombre, string filtroApellido, string filtroDni, string filtroEmail)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                List<Cliente> usuarios = FindClientes(filtroNombre, filtroApellido, filtroDni, filtroEmail, db);

                db.EndConnection();

                return usuarios;
            }
        }

        private static List<Cliente> FindClientes(string filtroNombre, string filtroApellido, string filtroDni, string filtroEmail, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter nombreParameter = new SqlParameter("@FiltroNombre", SqlDbType.NVarChar);
            nombreParameter.Value = filtroNombre.Trim();

            SqlParameter apllidoParameter = new SqlParameter("@FiltroApellido", SqlDbType.NVarChar);
            apllidoParameter.Value = filtroApellido;

            SqlParameter emailParameter = new SqlParameter("@FiltroEmail", SqlDbType.NVarChar);
            emailParameter.Value = filtroEmail;

            SqlParameter dniParameter = new SqlParameter("@FiltroDni", SqlDbType.Decimal);
            dniParameter.Value = string.IsNullOrEmpty(filtroDni) ? 0 : Convert.ToDecimal(filtroDni);

            parameters.Add(nombreParameter);
            parameters.Add(apllidoParameter);
            parameters.Add(emailParameter);
            parameters.Add(dniParameter);

            DataTable res = db.GetDataAsTable("SP_FindClientes", parameters);
            List<Cliente> usuarios = new List<Cliente>();
            foreach (DataRow row in res.Rows)
            {
                var usuario = new Cliente
                {
                    IdUsuario = Convert.ToInt32(row["IdUsuario"]),
                    Nombre = Convert.ToString(row["Nombre"]),
                    Apellido = Convert.ToString(row["Apellido"]),
                    Calle = Convert.ToString(row["Calle"]),
                    NroCalle = Convert.ToInt32(row["NroCalle"]),
                    CodigoPostal = Convert.ToString(row["CodigoPostal"]),
                    Departamento = Convert.ToString(row["Departamento"]),
                    Email = Convert.ToString(row["Email"]),
                    FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"]),
                    Localidad = Convert.ToString(row["Localidad"]),
                    NumeroDoc = Convert.ToInt32(row["NroDoc"]),
                    Piso = Convert.ToInt32(row["Piso"]),
                    Telefono = Convert.ToString(row["Telefono"]),
                    TipoDoc = Convert.ToString(row["TipoDoc"]),
                    UserName = Convert.ToString(row["UserName"]),
                    Activo = Convert.ToBoolean(row["Activo"]),
                    Password = Convert.ToString(row["PasswordEnc"]),
                };

                usuario.Roles = GetRolesUsuario(usuario,db);

                usuarios.Add(usuario);
            }

            return usuarios;

        }

        private static List<Rol> GetRolesUsuario(Usuario usuario, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idUsuarioParameter = new SqlParameter("@IdUsuario", SqlDbType.Int);
            idUsuarioParameter.Value = usuario.IdUsuario;

            parameters.Add(idUsuarioParameter);

            DataTable res = db.GetDataAsTable("SP_GetRolesUsuario", parameters);
            List<Rol> roles = new List<Rol>();
            List<Rol> rolesAux = new List<Rol>(RolesServices.GetAllData());
            foreach (DataRow row in res.Rows)
            {
                var idRol = Convert.ToInt32(row["IdRol"]);

                roles.Add(rolesAux.Find(x => x.IdRol == idRol));
            }

            return roles;
        }

        public static List<Empresa> FindEmpresas(string filtroRazonSocial, string filtroCuit, string filtroEmail)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                List<Empresa> usuarios = FindEmpresas(filtroRazonSocial, filtroCuit, filtroEmail, db);

                db.EndConnection();

                return usuarios;
            }
        }

        private static List<Empresa> FindEmpresas(string filtroRazonSocial, string filtroCuit, string filtroEmail, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter razonSocialParameter = new SqlParameter("@FiltroRazonSocial", SqlDbType.NVarChar);
            razonSocialParameter.Value = filtroRazonSocial.Trim();

            SqlParameter cuitParameter = new SqlParameter("@FiltroCuit", SqlDbType.NVarChar);
            cuitParameter.Value = filtroCuit;

            SqlParameter emailParameter = new SqlParameter("@FiltroEmail", SqlDbType.NVarChar);
            emailParameter.Value = filtroEmail;

            parameters.Add(razonSocialParameter);
            parameters.Add(cuitParameter);
            parameters.Add(emailParameter);

            DataTable res = db.GetDataAsTable("SP_FindEmpresas", parameters);
            List<Empresa> usuarios = new List<Empresa>();
            foreach (DataRow row in res.Rows)
            {
                var usuario = new Empresa
                {
                    IdUsuario = Convert.ToInt32(row["IdUsuario"]),
                    UserName = Convert.ToString(row["UserName"]),
                    Activo = Convert.ToBoolean(row["Activo"]),
                    Password = Convert.ToString(row["PasswordEnc"]),
                    Calle = Convert.ToString(row["Calle"]),
                    Ciudad = Convert.ToString(row["Ciudad"]),
                    CodigoPostal = Convert.ToString(row["CodigoPostal"]),
                    Contacto = Convert.ToString(row["Contacto"]),
                    Cuit = Convert.ToString(row["Cuit"]),
                    Departamento = Convert.ToString(row["Departamento"]),
                    Email = Convert.ToString(row["Email"]),
                    Localidad = Convert.ToString(row["Localidad"]),
                    NroCalle = Convert.ToInt32(row["NroCalle"]),
                    Piso = Convert.ToInt32(row["Piso"]),
                    RazonSocial = Convert.ToString(row["RazonSocial"]),
                    Rubro = Convert.ToString(row["Rubro"]),
                    Telefono = Convert.ToString(row["Telefono"]),
                };

                usuario.Roles = GetRolesUsuario(usuario, db);

                usuarios.Add(usuario);
            }

            return usuarios;

        }

    }
}
