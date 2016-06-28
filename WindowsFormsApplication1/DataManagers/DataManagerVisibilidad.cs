using System;
using System.Collections.Generic;
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
            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetVisibilidades");
            List<Visibilidad> visibilidades = new List<Visibilidad>();
            foreach (DataRow row in res.Rows)
            {
                var visibilidad = new Visibilidad
                {
                    IdVisibilidad = Convert.ToInt32(row["IdVisibilidad"]),
                    Descripcion = Convert.ToString(row["Descripcion"]),
                    EnvioPorcentaje = Convert.ToDecimal(row["EnvioPorcentaje"]),
                    Porcentaje = Convert.ToDecimal(row["Porcentaje"]),
                    Precio = Convert.ToDecimal(row["Precio"]),
                    Activa = Convert.ToBoolean(row["Activa"]),
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

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_FindVisibilidades", parameters);
            List<Visibilidad> visibilidades = new List<Visibilidad>();
            foreach (DataRow row in res.Rows)
            {
                var visibilidad = new Visibilidad
                {
                    IdVisibilidad = Convert.ToInt32(row["IdVisibilidad"]),
                    Descripcion = Convert.ToString(row["Descripcion"]),
                    EnvioPorcentaje = Convert.ToDecimal(row["EnvioPorcentaje"]),
                    Porcentaje = Convert.ToDecimal(row["Porcentaje"]),
                    Precio = Convert.ToDecimal(row["Precio"]),
                    Activa = Convert.ToBoolean(row["Activa"]),
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
                    //return Resources.ErrorRolBorrado + "\n" + string.Join(Environment.NewLine, publicaciones); // TODO Arreglar error
                    return Resources.ErrorVisibilidadBorrada;
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

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetPublicacionesVisibilidad", parameters);
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

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "MASTERDBA.SP_DeleteVisibilidad", parameters);
        }

        public static void SaveNewVisibilidad(Visibilidad newVisibilidad)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                InsertVisibilidad(newVisibilidad, db);

                db.EndConnection();
            }
        }

        private static void InsertVisibilidad(Visibilidad newVisibilidad, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter descripcionParameter = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
            descripcionParameter.Value = newVisibilidad.Descripcion.Trim();

            SqlParameter activaParameter = new SqlParameter("@Activa", SqlDbType.Bit);
            activaParameter.Value = newVisibilidad.Activa;

            SqlParameter porcentajeParameter = new SqlParameter("@Porcentaje", SqlDbType.Decimal);
            porcentajeParameter.Value = newVisibilidad.Porcentaje;

            SqlParameter envioPorcentajeParameter = new SqlParameter("@EnvioPorcentaje", SqlDbType.Decimal);
            envioPorcentajeParameter.Value = newVisibilidad.EnvioPorcentaje;

            SqlParameter precioParameter = new SqlParameter("@Precio", SqlDbType.Decimal);
            precioParameter.Value = newVisibilidad.Precio;

            parameters.Add(descripcionParameter);
            parameters.Add(activaParameter);
            parameters.Add(porcentajeParameter);
            parameters.Add(envioPorcentajeParameter);
            parameters.Add(precioParameter);

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_InsertVisibilidad", parameters);
            foreach (DataRow row in res.Rows)
            {
                newVisibilidad.IdVisibilidad = Convert.ToInt32(row["IdVisibilidad"]);
            }
        }

        public static void UpdateVisibilidad(Visibilidad visibilidad)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                UpdateVisibilidad(visibilidad, db);

                db.EndConnection();
            }
        }

        public static void UpdateVisibilidad(Visibilidad visibilidad, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idVisibilidadParameter = new SqlParameter("@IdVisibilidad", SqlDbType.Int);
            idVisibilidadParameter.Value = visibilidad.IdVisibilidad;

            SqlParameter descripcionParameter = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
            descripcionParameter.Value = visibilidad.Descripcion.Trim();

            SqlParameter activaParameter = new SqlParameter("@Activa", SqlDbType.Bit);
            activaParameter.Value = visibilidad.Activa;

            SqlParameter porcentajeParameter = new SqlParameter("@Porcentaje", SqlDbType.Decimal);
            porcentajeParameter.Value = visibilidad.Porcentaje;

            SqlParameter envioPorcentajeParameter = new SqlParameter("@EnvioPorcentaje", SqlDbType.Decimal);
            envioPorcentajeParameter.Value = visibilidad.EnvioPorcentaje;

            SqlParameter precioParameter = new SqlParameter("@Precio", SqlDbType.Decimal);
            precioParameter.Value = visibilidad.Precio;

            parameters.Add(descripcionParameter);
            parameters.Add(activaParameter);
            parameters.Add(porcentajeParameter);
            parameters.Add(envioPorcentajeParameter);
            parameters.Add(precioParameter);
            parameters.Add(idVisibilidadParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "MASTERDBA.SP_UpdateVisibilidad", parameters);
        }

        public static Visibilidad GetVisibilidadByDescripcion(string descripcion)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                Visibilidad visibilidad = GetVisibilidadByDescripcion(descripcion, db);

                db.EndConnection();

                return visibilidad;
            }
        }

        private static Visibilidad GetVisibilidadByDescripcion(string descripcion, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter descripcionParameter = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
            descripcionParameter.Value = descripcion.Trim();

            parameters.Add(descripcionParameter);

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetVisibilidadByDescripcion", parameters);
            Visibilidad visibilidad = new Visibilidad();
            
            foreach (DataRow row in res.Rows)
            {
                visibilidad.IdVisibilidad = Convert.ToInt32(row["IdVisibilidad"]);
                visibilidad.Descripcion = Convert.ToString(row["Descripcion"]);
                visibilidad.Activa = Convert.ToBoolean(row["Activa"]);
                visibilidad.Precio = Convert.ToDecimal(row["Precio"]);
                visibilidad.Porcentaje = Convert.ToDecimal(row["Porcentaje"]);
                visibilidad.EnvioPorcentaje = Convert.ToDecimal(row["EnvioPorcentaje"]);
            }

            return visibilidad;
        }
    }
}
