using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

                List<Rol> roles = GetRoles(db);

                db.EndConnection();

                return roles;
            }
        }

        private static List<Rol> GetRoles(DataBaseHelper db)
        {
            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetRoles");
            List<Rol> roles = new List<Rol>();
            foreach (DataRow row in res.Rows)
            {
                var rol = new Rol
                {
                    IdRol = Convert.ToInt32(row["IdRol"]),
                    Descripcion = Convert.ToString(row["Descripcion"]),
                    Activo = Convert.ToBoolean(row["Activo"]),
                };

                rol.Funcionalidades = GetRolFuncionalidades(rol.IdRol, db);

                roles.Add(rol);
            }

            return roles;
        }

        private static List<Funcionalidad> GetRolFuncionalidades(int idRol, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idRolParameter = new SqlParameter("@IdRol", SqlDbType.Int);
            idRolParameter.Value = idRol;

            parameters.Add(idRolParameter);

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetRolFuncionalidades", parameters);
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            List<Funcionalidad> funcionalidadesAux = new List<Funcionalidad>(GetFuncionalidades(db));
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

                List<Funcionalidad> funcionalidades = GetFuncionalidades(db);

                db.EndConnection();

                return funcionalidades;
            }
        }

        private static List<Funcionalidad> GetFuncionalidades(DataBaseHelper db)
        {
            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetFuncionalidades");
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

            return funcionalidades;
        }

        public static List<Rol> FindRoles(string filtroNombre, int filtroFuncionalidad, string filtroEstado)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                List<Rol> roles = FindRoles(filtroNombre, filtroFuncionalidad, filtroEstado, db);

                db.EndConnection();

                return roles;
            }
        }

        private static List<Rol> FindRoles(string filtroNombre, int filtroFuncionalidad, string filtroEstado, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

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

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_FindRoles", parameters);
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

            return roles;
        }

        public static Rol GetRolByDescripcion(string descripcion)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                Rol rol = GetRolByDescripcion(descripcion, db);

                db.EndConnection();

                return rol;
            }
        }

        private static Rol GetRolByDescripcion(string descripcion, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter descripcionParameter = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
            descripcionParameter.Value = descripcion.Trim();

            parameters.Add(descripcionParameter);

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetRolByDescripcion", parameters);
            Rol rol = new Rol();
            foreach (DataRow row in res.Rows)
            {
                rol.IdRol = Convert.ToInt32(row["IdRol"]);
                rol.Descripcion = Convert.ToString(row["Descripcion"]);
                rol.Activo = Convert.ToBoolean(row["Activo"]);
            }

            return rol;
        }

        public static void SaveNewRol(Rol newRol)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                InsertRol(newRol, db);
                newRol.Funcionalidades.Add(GetFuncionalidadByDescripcion(Resources.LoginSeguridad, db));

                foreach (Funcionalidad funcionalidad in newRol.Funcionalidades)
                {
                    InsertRolFuncionalidad(newRol.IdRol, funcionalidad.IdFuncionalidad, true, db);
                }

                db.EndConnection();
            }
        }

        private static void InsertRol(Rol newRol, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter descripcionParameter = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
            descripcionParameter.Value = newRol.Descripcion.Trim();

            SqlParameter activoParameter = new SqlParameter("@Activo", SqlDbType.Bit);
            activoParameter.Value = newRol.Activo;

            parameters.Add(descripcionParameter);
            parameters.Add(activoParameter);

            newRol.IdRol = Convert.ToInt32(db.ExecInstruction(DataBaseHelper.ExecutionType.Scalar, "MASTERDBA.SP_InsertRol", parameters));
        }

        private static Funcionalidad GetFuncionalidadByDescripcion(string descripcion, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter descripcionParameter = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
            descripcionParameter.Value = descripcion;

            parameters.Add(descripcionParameter);

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetFuncionalidadByDescripcion", parameters);
            Funcionalidad funcionalidad = new Funcionalidad();
            foreach (DataRow row in res.Rows)
            {
                funcionalidad.IdFuncionalidad = Convert.ToInt32(row["IdFuncionalidad"]);
                funcionalidad.Descripcion = Convert.ToString(row["Descripcion"]);
            }

            return funcionalidad;
        }

        private static void InsertRolFuncionalidad(int idRol, int idFuncionalidad, bool activa, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idRolParameter = new SqlParameter("@IdRol", SqlDbType.Int);
            idRolParameter.Value = idRol;

            SqlParameter idFuncionalidadParameter = new SqlParameter("@IdFuncionalidad", SqlDbType.Int);
            idFuncionalidadParameter.Value = idFuncionalidad;

            SqlParameter activaParameter = new SqlParameter("@Activa", SqlDbType.Bit);
            activaParameter.Value = activa;

            parameters.Add(idRolParameter);
            parameters.Add(idFuncionalidadParameter);
            parameters.Add(activaParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "MASTERDBA.SP_InsertRolFuncionalidad", parameters);
        }

        public static string DeleteRol(Rol rol)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                List<string> usuarios = DeleteUsuariosRol(rol.IdRol, db);
                if (usuarios.Count > 0)
                {
                    if (usuarios.Count <= 5)
                    {
                        db.EndConnection();

                        return Resources.ErrorRolBorrado1 + "\n" + string.Join(Environment.NewLine, usuarios);
                    }

                    db.EndConnection();

                    return Resources.ErrorRolBorrado2 + "\n Total: " + usuarios.Count.ToString();
                }

                DeleteRol(rol.IdRol, db);

                db.EndConnection();

                return string.Empty;
            }
        }

        private static List<string> DeleteUsuariosRol(int idRol, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter usuarioRolIdRolParameter = new SqlParameter("@IdRol", SqlDbType.Int);
            usuarioRolIdRolParameter.Value = idRol;

            parameters.Add(usuarioRolIdRolParameter);

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_DeleteUsuariosRol", parameters);
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

            return usuarios;
        }

        private static void DeleteRol(int idRol, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idRolParameter = new SqlParameter("@IdRol", SqlDbType.Int);
            idRolParameter.Value = idRol;

            parameters.Add(idRolParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "MASTERDBA.SP_DeleteRol", parameters);
        }

        public static void UpdateRol(Rol rol)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                UpdateRol(rol, db);

                List<Funcionalidad> funcionalidades = GetRolFuncionalidades(rol.IdRol, db);

                foreach (Funcionalidad funcionalidad in rol.Funcionalidades)
                {
                    if (!funcionalidades.Exists(x => x.IdFuncionalidad == funcionalidad.IdFuncionalidad))
                        InsertRolFuncionalidad(rol.IdRol, funcionalidad.IdFuncionalidad, true, db);
                }

                foreach (Funcionalidad funcionalidad in funcionalidades)
                {
                    if (!rol.Funcionalidades.Exists(x => x.IdFuncionalidad == funcionalidad.IdFuncionalidad))
                        DeleteRolFuncionalidad(rol.IdRol, funcionalidad.IdFuncionalidad, db);
                }

                db.EndConnection();
            }
        }

        private static void UpdateRol(Rol rol, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idRolParameter = new SqlParameter("@IdRol", SqlDbType.Int);
            idRolParameter.Value = rol.IdRol;

            SqlParameter descripcionParameter = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
            descripcionParameter.Value = rol.Descripcion.Trim();

            SqlParameter activoParameter = new SqlParameter("@Activo", SqlDbType.Bit);
            activoParameter.Value = rol.Activo;

            parameters.Add(idRolParameter);
            parameters.Add(descripcionParameter);
            parameters.Add(activoParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "MASTERDBA.SP_UpdateRol", parameters);
        }

        private static void DeleteRolFuncionalidad(int idRol, int idFuncionalidad, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idRolParameter = new SqlParameter("@IdRol", SqlDbType.Int);
            idRolParameter.Value = idRol;

            SqlParameter idFuncionalidadParameter = new SqlParameter("@IdFuncionalidad", SqlDbType.Int);
            idFuncionalidadParameter.Value = idFuncionalidad;

            parameters.Add(idRolParameter);
            parameters.Add(idFuncionalidadParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "MASTERDBA.SP_DeleteRolFuncionalidad", parameters);
        }
    }
}
