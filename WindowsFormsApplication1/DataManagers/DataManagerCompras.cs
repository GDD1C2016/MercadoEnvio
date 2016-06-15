using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercadoEnvio.Entidades;
using MercadoEnvio.Helpers;
using System.Configuration;
using System.Data;

namespace MercadoEnvio.DataManagers
{
    public class DataManagerCompras
    {
        public static List<Compra> GetAllData()
        {
            List<Compra> compras = new List<Compra>();
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                compras = GetAllData(db);

                db.EndConnection();

                return compras;
            }
        }

        private static List<Compra> GetAllData(DataBaseHelper db)
        {
            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetCompras"); //TODO HACER ESTE SP
            List<Compra> compras = new List<Compra>();
            foreach (DataRow row in res.Rows)
            {
                var compra = new Compra();
                compra.IdCompra = Convert.ToInt32(row["IdCompra"]);
                compra.IdPublicacion = Convert.ToInt32(row["IdPublicacion"]);
                compra.Fecha = Convert.ToDateTime(row["Fecha"]);
                compra.Cantidad = Convert.ToDecimal(row["Cantidad"]);
                compra.Estado = Convert.ToBoolean(row["Estado"]);
                compra.IdUsuario = Convert.ToInt32(row["IdUsuario"]);
                compra.TipoPublicacion = Convert.ToString(row["TipoPublicacion"]);
                compra.DescripcionPublicacion = Convert.ToString(row["DescripcionPublicacion"]);
                compra.Vendedor = Convert.ToString(row["Vendedor"]);
                
                compras.Add(compra);
            }

            return compras;
        }
    }
}
