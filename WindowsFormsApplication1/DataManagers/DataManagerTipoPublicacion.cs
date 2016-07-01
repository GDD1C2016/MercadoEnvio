using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MercadoEnvio.Entidades;
using MercadoEnvio.Helpers;

namespace MercadoEnvio.DataManagers
{
    internal class DataManagerTipoPublicacion
    {
        public static List<TipoPublicacion> GetAllData()
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                List<TipoPublicacion> publicaciones = new List<TipoPublicacion>(GetTiposPublicacion(db));

                db.EndConnection();

                return publicaciones;
            }
        }

        private static List<TipoPublicacion> GetTiposPublicacion(DataBaseHelper db)
        {
            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetTiposPublicacion");
            List<TipoPublicacion> tipos = new List<TipoPublicacion>();
            foreach (DataRow row in res.Rows)
            {
                var tipo = new TipoPublicacion
                {
                    IdTipo = Convert.ToInt32(row["IdTipo"]),
                    Descripcion = Convert.ToString(row["Descripcion"]),
                    Envio = Convert.ToBoolean(row["Envio"])
                };

                tipos.Add(tipo);
            }
            return tipos;
        }
    }
}
