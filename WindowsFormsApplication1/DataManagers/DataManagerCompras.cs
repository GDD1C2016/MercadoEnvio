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

        public static List<Factura> GetFacturas()
        {
            List<Factura> facturas = new List<Factura>();
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                facturas = GetFacturas(db);

                db.EndConnection();

                return facturas;
            }
        }

        private static List<Factura> GetFacturas(DataBaseHelper db)
        {
            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetFacturas"); //TODO HACER SP
            List<Factura> facturas = new List<Factura>();
            foreach (DataRow row in res.Rows)
            {
                var factura = new Factura();
                factura.IdFactura = Convert.ToInt32(row["IdFactura"]);
                factura.IdPublicacion = Convert.ToInt32(row["IdPublicacion"]);
                factura.IdFormaDePago = Convert.ToInt32(row["IdFormaDePago"]);
                factura.Total = Convert.ToDecimal(row["Total"]);
                factura.Fecha = Convert.ToDateTime(row["Fecha"]);

                facturas.Add(factura);
            }

            return facturas;
        }

        public static List<Factura> FindFacturas(DateTime filtroFechaDesde, DateTime filtroFechaHasta, decimal filtroImporteDesde, decimal filtroImporteHasta, string filtroDetallesFactura, string filtroDirigidaA)
        {
            List<Factura> facturas = new List<Factura>();
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                facturas = FindFacturas(filtroFechaDesde, filtroFechaHasta, filtroImporteDesde, filtroImporteHasta, filtroDetallesFactura, filtroDirigidaA, db);

                db.EndConnection();

                return facturas;
            }
        }

        private static List<Factura> FindFacturas(DateTime filtroFechaDesde, DateTime filtroFechaHasta, decimal filtroImporteDesde, decimal filtroImporteHasta, string filtroDetallesFactura, string filtroDirigidaA, DataBaseHelper db)
        {
            DataTable res = db.GetDataAsTable("MASTERDBA.SP_FindFacturas"); //TODO HACER SP Y PARAMETROS!!
            List<Factura> facturas = new List<Factura>();
            foreach (DataRow row in res.Rows)
            {
                var factura = new Factura();
                factura.IdFactura = Convert.ToInt32(row["IdFactura"]);
                factura.IdPublicacion = Convert.ToInt32(row["IdPublicacion"]);
                factura.IdFormaDePago = Convert.ToInt32(row["IdFormaDePago"]);
                factura.Total = Convert.ToDecimal(row["Total"]);
                factura.Fecha = Convert.ToDateTime(row["Fecha"]);

                facturas.Add(factura);
            }

            return facturas;
        }
    }
}
