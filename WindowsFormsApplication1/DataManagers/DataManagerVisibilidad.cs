using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercadoEnvio.Entidades;
using MercadoEnvio.Helpers;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MercadoEnvio.Properties;

namespace MercadoEnvio.DataManagers
{
    public class DataManagerVisibilidad
    {
        public static List<Visibilidad> GetAllData()
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                List<Visibilidad> visibilidades = new List<Visibilidad>(GetVisibilidades(db));

                db.EndConnection();

                return visibilidades;
            }
        }

        private static List<Visibilidad> GetVisibilidades(DataBaseHelper db)
        {
            DataTable res = db.GetDataAsTable("SP_GetVisibilidades");
            List<Visibilidad> visibilidades = new List<Visibilidad>();
            foreach (DataRow row in res.Rows)
            {
                var visibilidad = new Visibilidad
                {
                    IdVisibilidad = Convert.ToInt32(row["IdVisibilidad"]),
                    Descripcion = Convert.ToString(row["Descripcion"]),
                    EnvioPorcentaje = Convert.ToDecimal(row["EnvioPorcentaje"]),
                    Porcentaje = Convert.ToDecimal(row["Porcentaje"]),
                    Precio = Convert.ToDecimal(row["Precio"])
                };
                
                visibilidades.Add(visibilidad);
            }
            return visibilidades;
        }

        public static List<Visibilidad> FindVisibilidades(string filtroDescripcion)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                List<Visibilidad> visibilidades = new List<Visibilidad>(FindVisibilidades(filtroDescripcion, db));

                db.EndConnection();

                return visibilidades;
            }
        }

        private static List<Visibilidad> FindVisibilidades(string filtroDescripcion, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter descripcionParameter = new SqlParameter("@FiltroDescripcion", SqlDbType.NVarChar);
            descripcionParameter.Value = filtroDescripcion.Trim();

            parameters.Add(descripcionParameter);
            
            DataTable res = db.GetDataAsTable("SP_FindVisibilidades", parameters);
            List<Visibilidad> visibilidades = new List<Visibilidad>();
            foreach (DataRow row in res.Rows)
            {
                var visibilidad = new Visibilidad
                {
                    IdVisibilidad = Convert.ToInt32(row["IdVisibilidad"]),
                    Descripcion = Convert.ToString(row["Descripcion"]),
                    EnvioPorcentaje = Convert.ToDecimal(row["EnvioPorcentaje"]),
                    Porcentaje = Convert.ToDecimal(row["Porcentaje"]),
                    Precio = Convert.ToDecimal(row["Precio"])
                };

                visibilidades.Add(visibilidad);
            }

            return visibilidades;
        }

        public static string DeleteVisibilidad(Visibilidad visibilidad)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                List<string> publicaciones = DeletePublicacionesVisibilidad(visibilidad.IdVisibilidad, db);
                if (publicaciones.Count > 0)
                {
                    return Resources.ErrorRolBorrado + "\n" + string.Join(Environment.NewLine, publicaciones);
                }

                DeleteVisibilidad(visibilidad.IdVisibilidad, db);

                db.EndConnection();

                return string.Empty;
            }
        }

        private static List<string> DeletePublicacionesVisibilidad(int idVisibilidad, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter visibilidadPublicacionIdVisibilidadParameter = new SqlParameter("@IdVisibilidad", SqlDbType.Int);
            visibilidadPublicacionIdVisibilidadParameter.Value = idVisibilidad;

            parameters.Add(visibilidadPublicacionIdVisibilidadParameter);

            DataTable res = db.GetDataAsTable("SP_DeleteVisibilidadesPublicacion", parameters);
            List<string> publicaciones = new List<string>();
            foreach (DataRow row in res.Rows)
            {
                var publicacion = new Publicacion
                {
                    IdPublicacion = Convert.ToInt32(row["IdPublicacion"]),
                    Descripcion = Convert.ToString(row["Descripcion"]),
                };

                publicaciones.Add("Publicación: " + publicacion.Descripcion);
            }

            return publicaciones;
        }

        private static void DeleteVisibilidad(int idVisibilidad, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter visibilidadIdVisibilidadParameter = new SqlParameter("@IdVisibilidad", SqlDbType.Int);
            visibilidadIdVisibilidadParameter.Value = idVisibilidad;

            parameters.Add(visibilidadIdVisibilidadParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "SP_DeleteVisibilidad", parameters);
        }
    }
}
