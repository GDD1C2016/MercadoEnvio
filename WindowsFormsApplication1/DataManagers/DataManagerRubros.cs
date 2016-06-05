using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

                return listRubros;
            }
        }
    }
}
