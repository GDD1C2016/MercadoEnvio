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
//using MercadoEnvio.Properties;

namespace MercadoEnvio.DataManagers
{
    public class DataManagerRoles
    {
        public static List<Rol> GetAllData()
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);
            List<Rol> listRoles = new List<Rol>();

            using (db.Connection)
            {
                db.BeginTransaction();

                DataTable res = db.GetDataAsTable("SP_GetRoles");

                foreach (DataRow row in res.Rows)
                {
                    var rol = new Rol
                    {
                        IdRol = Convert.ToInt32(row["IdRol"]),
                        Descripcion = Convert.ToString(row["Descripcion"]),
                        Activo = Convert.ToBoolean(row["Activo"]),
                    };

                    rol.Funcionalidades = GetFuncionalidadesRol(rol.IdRol, db);

                    listRoles.Add(rol);
                }

                db.EndConnection();

                return listRoles;
            }
        }

        private static List<Funcionalidad> GetFuncionalidadesRol(int idRol, DataBaseHelper db)
        {
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            List<Funcionalidad> funcionalidadesAux = new List<Funcionalidad>(GetAllFuncionalidades());

            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idRolParameter = new SqlParameter("@IdRol", SqlDbType.Int);
            idRolParameter.Value = idRol;

            parameters.Add(idRolParameter);

            DataTable res = db.GetDataAsTable("SP_GetRolFuncionalidades", parameters);

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
            List<Funcionalidad> listFuncionalidades = new List<Funcionalidad>();

            using (db.Connection)
            {
                db.BeginTransaction();

                DataTable res = db.GetDataAsTable("SP_GetFuncionalidades");

                foreach (DataRow row in res.Rows)
                {
                    var funcionalidad = new Funcionalidad
                    {
                        IdFuncionalidad = Convert.ToInt32(row["IdFuncionalidad"]),
                        Descripcion = Convert.ToString(row["Descripcion"]),
                    };

                    listFuncionalidades.Add(funcionalidad);
                }

                db.EndConnection();

                return listFuncionalidades;
            }
        }

        public static List<Rol> FindRoles(string filtroNombre, int filtroFuncionalidad, string filtroEstado)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);
            List<SqlParameter> parameters = new List<SqlParameter>();
            Estado estado = new Estado { Descripcion = filtroEstado };
            List<Rol> roles = new List<Rol>();

            using (db.Connection)
            {
                db.BeginTransaction();

                SqlParameter nombreParameter = new SqlParameter("@FiltroNombre", SqlDbType.NVarChar);
                nombreParameter.Value = filtroNombre.Trim();

                SqlParameter funcionalidadParameter = new SqlParameter("@FiltroFuncionalidad", SqlDbType.Int);
                funcionalidadParameter.Value = filtroFuncionalidad;

                SqlParameter estadoParameter = new SqlParameter("@FiltroEstado", SqlDbType.Bit);

                if (estado.EstadoValido())
                    estadoParameter.Value = estado.Valor;
                else
                    estadoParameter.Value = null;

                parameters.Add(nombreParameter);
                parameters.Add(funcionalidadParameter);
                parameters.Add(estadoParameter);

                DataTable res = db.GetDataAsTable("SP_FindRoles", parameters);

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

        public static void SaveNewRol(Rol newRol)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<Rol> roles = new List<Rol>();

            using (db.Connection)
            {
                db.BeginTransaction();

                SqlParameter descripcionParameter = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
                descripcionParameter.Value = newRol.Descripcion.Trim();

                SqlParameter activoParameter = new SqlParameter("@Activo", SqlDbType.Bit);
                activoParameter.Value = newRol.Activo;

                parameters.Add(descripcionParameter);
                parameters.Add(activoParameter);

                DataTable res = db.GetDataAsTable("SP_InsertRol", parameters);

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

                newRol.IdRol = roles.Find(x => x.Descripcion == newRol.Descripcion).IdRol;

                parameters.Clear();

                foreach (Funcionalidad funcionalidad in newRol.Funcionalidades)
                {
                    var idFuncionalidadParameter = new SqlParameter("@IdFuncionalidad", SqlDbType.Int);
                    idFuncionalidadParameter.Value = funcionalidad.IdFuncionalidad;

                    var idRolParameter = new SqlParameter("@IdRol", SqlDbType.Int);
                    idRolParameter.Value = newRol.IdRol;

                    var activaParameter = new SqlParameter("@Activa", SqlDbType.Bit);
                    activaParameter.Value = true;

                    parameters.Add(idRolParameter);
                    parameters.Add(idFuncionalidadParameter);
                    parameters.Add(activaParameter);

                    db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "SP_InsertRolFuncionalidad", parameters);
                }
            
                db.EndConnection();
            }
        }
    }
}
