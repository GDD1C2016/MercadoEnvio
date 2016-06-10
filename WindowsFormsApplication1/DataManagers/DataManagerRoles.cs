using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using MercadoEnvio.Entidades;
using MercadoEnvio.Helpers;
using MercadoEnvio.Properties;

namespace MercadoEnvio.DataManagers
{
    public class DataManagerRoles
    {
        public static List<Rol> GetAllData()
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                DataTable res = db.GetDataAsTable("SP_GetRoles");
                List<Rol> roles = new List<Rol>();
                foreach (DataRow row in res.Rows)
                {
                    var rol = new Rol
                    {
                        IdRol = Convert.ToInt32(row["IdRol"]),
                        Descripcion = Convert.ToString(row["Descripcion"]),
                        Activo = Convert.ToBoolean(row["Activo"]),
                    };

                    rol.Funcionalidades = GetFuncionalidadesRol(rol.IdRol, db);

                    roles.Add(rol);
                }

                db.EndConnection();

                return roles;
            }
        }

        private static List<Funcionalidad> GetFuncionalidadesRol(int idRol, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idRolParameter = new SqlParameter("@IdRol", SqlDbType.Int);
            idRolParameter.Value = idRol;

            parameters.Add(idRolParameter);

            DataTable res = db.GetDataAsTable("SP_GetRolFuncionalidades", parameters);
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            List<Funcionalidad> funcionalidadesAux = new List<Funcionalidad>(GetAllFuncionalidades());
            foreach (DataRow row in res.Rows)
            {
                var idFuncionalidad = Convert.ToInt32(row["IdFuncionalidad"]);

                funcionalidades.Add(funcionalidadesAux.Find(x => x.IdFuncionalidad == idFuncionalidad));
            }

            return funcionalidades;
        }

        public static List<Funcionalidad> GetAllFuncionalidades()
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                DataTable res = db.GetDataAsTable("SP_GetFuncionalidades");
                List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
                foreach (DataRow row in res.Rows)
                {
                    var funcionalidad = new Funcionalidad
                    {
                        IdFuncionalidad = Convert.ToInt32(row["IdFuncionalidad"]),
                        Descripcion = Convert.ToString(row["Descripcion"]),
                    };

                    funcionalidades.Add(funcionalidad);
                }

                db.EndConnection();

                return funcionalidades;
            }
        }

        public static List<Rol> FindRoles(string filtroNombre, int filtroFuncionalidad, string filtroEstado)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);
            List<SqlParameter> parameters = new List<SqlParameter>();

            using (db.Connection)
            {
                db.BeginTransaction();

                SqlParameter nombreParameter = new SqlParameter("@FiltroNombre", SqlDbType.NVarChar);
                nombreParameter.Value = filtroNombre.Trim();

                SqlParameter funcionalidadParameter = new SqlParameter("@FiltroFuncionalidad", SqlDbType.Int);
                funcionalidadParameter.Value = filtroFuncionalidad;

                SqlParameter estadoParameter = new SqlParameter("@FiltroEstado", SqlDbType.Bit);

                Estado estado = new Estado { Descripcion = filtroEstado };
                if (estado.EstadoValido())
                    estadoParameter.Value = estado.Valor;
                else
                    estadoParameter.Value = null;

                parameters.Add(nombreParameter);
                parameters.Add(funcionalidadParameter);
                parameters.Add(estadoParameter);

                DataTable res = db.GetDataAsTable("SP_FindRoles", parameters);
                List<Rol> roles = new List<Rol>();
                foreach (DataRow row in res.Rows)
                {
                    var rol = new Rol
                    {
                        IdRol = Convert.ToInt32(row["IdRol"]),
                        Descripcion = Convert.ToString(row["Descripcion"]),
                        Activo = Convert.ToBoolean(row["Activo"]),
                    };

                    roles.Add(rol);
                }

                db.EndConnection();

                return roles;
            }
        }

        public static Rol GetRolByDescription(string descripcion)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);
            List<SqlParameter> parameters = new List<SqlParameter>();

            using (db.Connection)
            {
                db.BeginTransaction();

                SqlParameter descripcionParameter = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
                descripcionParameter.Value = descripcion.Trim();

                parameters.Add(descripcionParameter);

                DataTable res = db.GetDataAsTable("SP_GetRolByDescripcion", parameters);
                Rol rol = new Rol();
                foreach (DataRow row in res.Rows)
                {
                    rol.IdRol = Convert.ToInt32(row["IdRol"]);
                    rol.Descripcion = Convert.ToString(row["Descripcion"]);
                    rol.Activo = Convert.ToBoolean(row["Activo"]);
                }

                db.EndConnection();

                return rol;
            }
        }

        public static void SaveNewRol(Rol newRol)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);
            List<SqlParameter> parameters = new List<SqlParameter>();

            using (db.Connection)
            {
                db.BeginTransaction();

                SqlParameter rolDescripcionParameter = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
                rolDescripcionParameter.Value = newRol.Descripcion.Trim();

                SqlParameter rolActivoParameter = new SqlParameter("@Activo", SqlDbType.Bit);
                rolActivoParameter.Value = newRol.Activo;

                parameters.Add(rolDescripcionParameter);
                parameters.Add(rolActivoParameter);

                DataTable res = db.GetDataAsTable("SP_InsertRol", parameters);
                foreach (DataRow row in res.Rows)
                {
                    newRol.IdRol = Convert.ToInt32(row["IdRol"]);
                }

                res.Clear();
                parameters.Clear();

                SqlParameter funcionalidadDescripcionParameter = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
                funcionalidadDescripcionParameter.Value = Resources.LoginSeguridad;

                parameters.Add(funcionalidadDescripcionParameter);

                res = db.GetDataAsTable("SP_GetFuncionalidadByDescripcion", parameters);
                foreach (DataRow row in res.Rows)
                {
                    var funcionalidad = new Funcionalidad()
                    {
                        IdFuncionalidad = Convert.ToInt32(row["IdFuncionalidad"]),
                        Descripcion = Convert.ToString(row["Descripcion"]),
                    };

                    newRol.Funcionalidades.Add(funcionalidad);
                }

                parameters.Clear();

                foreach (Funcionalidad funcionalidad in newRol.Funcionalidades)
                {
                    var idRolParameter = new SqlParameter("@IdRol", SqlDbType.Int);
                    idRolParameter.Value = newRol.IdRol;

                    var idFuncionalidadParameter = new SqlParameter("@IdFuncionalidad", SqlDbType.Int);
                    idFuncionalidadParameter.Value = funcionalidad.IdFuncionalidad;

                    var activaParameter = new SqlParameter("@Activa", SqlDbType.Bit);
                    activaParameter.Value = true;

                    parameters.Clear();

                    parameters.Add(idRolParameter);
                    parameters.Add(idFuncionalidadParameter);
                    parameters.Add(activaParameter);

                    db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "SP_InsertRolFuncionalidad", parameters);
                }

                db.EndConnection();
            }
        }

        public static string DeleteRol(Rol rol)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);
            List<SqlParameter> parameters = new List<SqlParameter>();

            using (db.Connection)
            {
                db.BeginTransaction();

                SqlParameter usuarioRolIdRolParameter = new SqlParameter("@IdRol", SqlDbType.Int);
                usuarioRolIdRolParameter.Value = rol.IdRol;

                parameters.Add(usuarioRolIdRolParameter);

                DataTable res = db.GetDataAsTable("SP_DeleteUsuariosRol", parameters);
                List<string> usuarios = new List<string>();
                foreach (DataRow row in res.Rows)
                {
                    var usuario = new Usuario
                    {
                        IdUsuario = Convert.ToInt32(row["IdUsuario"]),
                        UserName = Convert.ToString(row["UserName"])
                    };

                    usuarios.Add("Username: " + usuario.UserName + " (Id " + usuario.IdUsuario.ToString() + ")");
                }

                if (usuarios.Count > 0)
                {
                    return Resources.ErrorRolBorrado + "\n" + string.Join(Environment.NewLine, usuarios);
                }

                parameters.Clear();

                SqlParameter rolIdRolParameter = new SqlParameter("@IdRol", SqlDbType.Int);
                rolIdRolParameter.Value = rol.IdRol;

                parameters.Add(rolIdRolParameter);

                db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "SP_DeleteRol", parameters);

                db.EndConnection();

                return string.Empty;
            }
        }

        public static void UpdateRol(Rol rol) // TODO Agregar lógica
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);
            List<SqlParameter> parameters = new List<SqlParameter>();

            using (db.Connection)
            {
                db.BeginTransaction();

                SqlParameter rolDescripcionParameter = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
                rolDescripcionParameter.Value = rol.Descripcion.Trim();

                SqlParameter rolActivoParameter = new SqlParameter("@Activo", SqlDbType.Bit);
                rolActivoParameter.Value = rol.Activo;

                parameters.Add(rolDescripcionParameter);
                parameters.Add(rolActivoParameter);

                DataTable res = db.GetDataAsTable("SP_InsertRol", parameters);
                foreach (DataRow row in res.Rows)
                {
                    rol.IdRol = Convert.ToInt32(row["IdRol"]);
                }

                res.Clear();
                parameters.Clear();

                SqlParameter funcionalidadDescripcionParameter = new SqlParameter("@Descripcion",
                    SqlDbType.NVarChar);
                funcionalidadDescripcionParameter.Value = Resources.LoginSeguridad;

                parameters.Add(funcionalidadDescripcionParameter);

                res = db.GetDataAsTable("SP_GetFuncionalidadByDescripcion", parameters);
                foreach (DataRow row in res.Rows)
                {
                    var funcionalidad = new Funcionalidad()
                    {
                        IdFuncionalidad = Convert.ToInt32(row["IdFuncionalidad"]),
                        Descripcion = Convert.ToString(row["Descripcion"]),
                    };

                    rol.Funcionalidades.Add(funcionalidad);
                }

                parameters.Clear();

                foreach (Funcionalidad funcionalidad in rol.Funcionalidades)
                {
                    var idRolParameter = new SqlParameter("@IdRol", SqlDbType.Int);
                    idRolParameter.Value = rol.IdRol;

                    var idFuncionalidadParameter = new SqlParameter("@IdFuncionalidad", SqlDbType.Int);
                    idFuncionalidadParameter.Value = funcionalidad.IdFuncionalidad;

                    var activaParameter = new SqlParameter("@Activa", SqlDbType.Bit);
                    activaParameter.Value = true;

                    parameters.Clear();

                    parameters.Add(idRolParameter);
                    parameters.Add(idFuncionalidadParameter);
                    parameters.Add(activaParameter);

                    db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "SP_InsertRolFuncionalidad",
                        parameters);
                }
            }
        }
    }
}
