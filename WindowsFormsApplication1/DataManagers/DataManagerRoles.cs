using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercadoEnvio.Entidades;
using MercadoEnvio.Helpers;

namespace MercadoEnvio.DataManagers
{
    public class DataManagerRoles
    {
        public static List<Rol> GetAllData()
        {
            DataBaseHelper db = null;
            db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                DataTable res = db.GetDataAsTable("SP_GetRoles");
                List<Rol> listRoles = new List<Rol>();
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

                return listRoles;
            }
        }

        private static List<Funcionalidad> GetFuncionalidadesRol(int idRol, DataBaseHelper db)
        {
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            List<Funcionalidad> funcionalidadesAux = new List<Funcionalidad>(GetAllFuncionalidades());
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter idRolParameter;

            idRolParameter = new SqlParameter("@IdRol", SqlDbType.Int);
            idRolParameter.Value = idRol;

            parameters.Add(idRolParameter);

            DataTable res = db.GetDataAsTable("SP_GetRolesFuncionalidades", parameters);
            foreach (DataRow row in res.Rows)
            {
                var idFuncionalidad = Convert.ToInt32(row["IdFuncionalidad"]);
                funcionalidades.Add(funcionalidadesAux.Find(x=>x.IdFuncionalidad == idFuncionalidad));
            }

            return funcionalidades;
        }

        public static List<Funcionalidad> GetAllFuncionalidades()
        {
            DataBaseHelper db = null;
            db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                DataTable resAux = db.GetDataAsTable("SP_GetFuncionalidades");
                List<Funcionalidad> listFuncionalidades = new List<Funcionalidad>();
                foreach (DataRow row in resAux.Rows)
                {
                    var funcionalidad = new Funcionalidad
                    {
                        IdFuncionalidad = Convert.ToInt32(row["IdFuncionalidad"]),
                        Descripcion = Convert.ToString(row["Descripcion"]),
                    };
                    listFuncionalidades.Add(funcionalidad);
                }

                return listFuncionalidades;
            }
        }

        public static List<Rol> FindRoles(string filtroNombre, int filtroFuncionalidad, string filtroEstado)
        {
            Estado estado = new Estado { Descripcion = filtroEstado };

            DataBaseHelper db = null;
            db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            SqlParameter nombreParameter;
            SqlParameter funcionalidadParameter;
            SqlParameter estadoParameter;
            List<SqlParameter> parameters = new List<SqlParameter>();

            nombreParameter = new SqlParameter("@FiltroNombre", SqlDbType.NVarChar);
            nombreParameter.Value = filtroNombre.Trim();

            funcionalidadParameter = new SqlParameter("@FiltroFuncionalidad", SqlDbType.Int);
            funcionalidadParameter.Value = filtroFuncionalidad;

            estadoParameter = new SqlParameter("@FiltroEstado", SqlDbType.Bit);

            if (estado.EstadoValido())
                estadoParameter.Value = estado.Valor;
            else
                estadoParameter.Value = null;

            parameters.Add(nombreParameter);
            parameters.Add(funcionalidadParameter);
            parameters.Add(estadoParameter);

            using (db.Connection)
            {
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

                return roles;
            }
        }

        public static void SaveNewRol(Rol newRol)
        {
            DataBaseHelper db = null;
            db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            SqlParameter descripcionParameter;
            SqlParameter funcionalidadParameter;
            SqlParameter estadoParameter;
            List<SqlParameter> parameters = new List<SqlParameter>();

            descripcionParameter = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
            descripcionParameter.Value = newRol.Descripcion.Trim();

            funcionalidadParameter = new SqlParameter("@Funcionalidad", SqlDbType.Int);
            //funcionalidadParameter.Value = newRol.f

            estadoParameter = new SqlParameter("@Estado", SqlDbType.Bit);
            estadoParameter.Value = newRol.Activo;

            parameters.Add(descripcionParameter);
            parameters.Add(funcionalidadParameter);
            parameters.Add(estadoParameter);
        }
    }
}
