using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MercadoEnvio.Entidades;
using MercadoEnvio.Helpers;

namespace MercadoEnvio.DataManagers
{
    public class DataManagerRubros
    {
        public static List<Rubro> GetAllData()
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                DataTable res = db.GetDataAsTable("SP_GetRubros");
                List<Rubro> listRubros = new List<Rubro>();

                foreach (DataRow row in res.Rows)
                {
                    var rubro = new Rubro
                    {
                        IdRubro = Convert.ToInt32(row["IdRubro"]),
                        DescripcionCorta = Convert.ToString(row["DescripcionCorta"]),
                        DescripcionLarga = Convert.ToString(row["DescripcionLarga"]),
                    };

                    listRubros.Add(rubro);
                }

                db.EndConnection();

                return listRubros;
            }
        }

        public static List<Rubro> FindRubros(string filtroDescripcionCorta, string filtroDescripcionLarga)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            SqlParameter filtroDescripcionCortaParameter;
            SqlParameter filtroDescripcionLargaParameter;
            List<SqlParameter> parameters = new List<SqlParameter>();

            filtroDescripcionCortaParameter = new SqlParameter("@FiltroDescripcionCorta", SqlDbType.NVarChar);
            filtroDescripcionCortaParameter.Value = filtroDescripcionCorta.Trim();

            filtroDescripcionLargaParameter = new SqlParameter("@FiltroDescripcionLarga", SqlDbType.NVarChar);
            filtroDescripcionLargaParameter.Value = filtroDescripcionLarga.Trim();

            parameters.Add(filtroDescripcionCortaParameter);
            parameters.Add(filtroDescripcionLargaParameter);

            using (db.Connection)
            {
                DataTable res = db.GetDataAsTable("SP_FindRubros", parameters);
                List<Rubro> listRubros = new List<Rubro>();

                foreach (DataRow row in res.Rows)
                {
                    var rubro = new Rubro
                    {
                        IdRubro = Convert.ToInt32(row["IdRubro"]),
                        DescripcionCorta = Convert.ToString(row["DescripcionCorta"]),
                        DescripcionLarga = Convert.ToString(row["DescripcionLarga"]),
                    };

                    listRubros.Add(rubro);
                }

                return listRubros;
            }
        }

        public static bool SaveNewRubro(Rubro newRubro)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            SqlParameter descripcionCortaParameter;
            SqlParameter descripcionLargaParameter;
            List<SqlParameter> parameters = new List<SqlParameter>();

            descripcionCortaParameter = new SqlParameter("@DescripcionCorta", SqlDbType.NVarChar);
            descripcionCortaParameter.Value = newRubro.DescripcionCorta.Trim();

            descripcionLargaParameter = new SqlParameter("@DescripcionLarga", SqlDbType.NVarChar);
            descripcionLargaParameter.Value = newRubro.DescripcionLarga.Trim();

            parameters.Add(descripcionCortaParameter);
            parameters.Add(descripcionLargaParameter);

            using (db.Connection)
            {
                DataTable res = db.GetDataAsTable("SP_InsertRubro", parameters);
                List<Rubro> rubros = new List<Rubro>();

                foreach (DataRow row in res.Rows)
                {
                    var rubro = new Rubro
                    {
                        IdRubro = Convert.ToInt32(row["IdRubro"]),
                        DescripcionCorta = Convert.ToString(row["DescripcionCorta"]),
                        DescripcionLarga = Convert.ToString(row["DescripcionLarga"])
                    };

                    rubros.Add(rubro);

                    newRubro.IdRubro =
                        rubros.Find(
                            x =>
                                x.DescripcionCorta.Equals(newRubro.DescripcionCorta,
                                    StringComparison.CurrentCultureIgnoreCase) &&
                                x.DescripcionLarga.Equals(newRubro.DescripcionLarga,
                                    StringComparison.CurrentCultureIgnoreCase)).IdRubro;
                }

                parameters.Clear();

                return rubros.Count > 0;
            }
        }
    }
}
