using System;
using System.Collections.Generic;
using MercadoEnvio.Entidades;
using MercadoEnvio.Helpers;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MercadoEnvio.DataManagers
{
    public class DataManagerCompras
    {
        public static List<Compra> GetComprasPendientesDeCalificacion(int idUsuario)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                List<Compra> compras = GetComprasPendientesDeCalificacion(idUsuario, db);

                db.EndConnection();

                return compras;
            }
        }

        private static List<Compra> GetComprasPendientesDeCalificacion(int idUsuario, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idUsuarioParameter = new SqlParameter("@IdUsuario", SqlDbType.Int);
            idUsuarioParameter.Value = idUsuario;

            parameters.Add(idUsuarioParameter);
            
            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetCompras", parameters);
            List<Compra> compras = new List<Compra>();
            foreach (DataRow row in res.Rows)
            {
                var compra = new Compra();
                compra.IdCompra = Convert.ToInt32(row["IdCompra"]);
                compra.IdPublicacion = Convert.ToInt32(row["IdPublicacion"]);
                compra.Fecha = Convert.ToDateTime(row["Fecha"]);
                compra.Cantidad = Convert.ToDecimal(row["Cantidad"]);
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
