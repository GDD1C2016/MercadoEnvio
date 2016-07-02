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
            
            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetComprasOfertas", parameters); //TODO HACER SP
            List<Compra> compras = new List<Compra>();
            foreach (DataRow row in res.Rows)
            {
                var compra = new Compra
                {
                    IdCompra = Convert.ToInt32(row["IdCompra"]),
                    IdPublicacion = Convert.ToInt32(row["IdPublicacion"]),
                    Fecha = Convert.ToDateTime(row["Fecha"]),
                    Cantidad = Convert.ToDecimal(row["Cantidad"]),
                    IdUsuario = Convert.ToInt32(row["IdUsuario"]),
                    TipoPublicacion = Convert.ToString(row["TipoPublicacion"]),
                    DescripcionPublicacion = Convert.ToString(row["DescripcionPublicacion"]),
                    Vendedor = Convert.ToString(row["Vendedor"])
                };

                compras.Add(compra);
            }

            return compras;
        }

        public static List<Factura> GetFacturas(int idUsuario)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                List<Factura> facturas = GetFacturas(idUsuario, db);

                db.EndConnection();

                return facturas;
            }
        }

        private static List<Factura> GetFacturas(int idUsuario, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idUsuarioParameter = new SqlParameter("@IdUsuario", SqlDbType.Int);
            idUsuarioParameter.Value = idUsuario;

            parameters.Add(idUsuarioParameter);

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetFacturas", parameters);
            List<Factura> facturas = new List<Factura>();
            foreach (DataRow row in res.Rows)
            {
                var factura = new Factura
                {
                    IdFactura = Convert.ToInt32(row["IdFactura"]),
                    IdPublicacion = Convert.ToInt32(row["IdPublicacion"]),
                    IdFormaDePago = Convert.ToInt32(row["IdFormaPago"]),
                    Total = Convert.ToDecimal(row["Total"]),
                    Fecha = Convert.ToDateTime(row["Fecha"])
                };

                facturas.Add(factura);
            }

            return facturas;
        }

        public static List<string> FindDetallesFactura()
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                List<string> detalles = FindDetallesFactura(db);

                db.EndConnection();

                return detalles;
            }
        }

        private static List<string> FindDetallesFactura(DataBaseHelper db)
        {
            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetDetallesFactura");
            List<string> detalles = new List<string>();
            foreach (DataRow row in res.Rows)
            {
                var detalle = Convert.ToString(row["Detalle"]);

                detalles.Add(detalle);
            }

            return detalles;
        }

        public static List<Factura> FindFacturas(DateTime filtroFechaDesde, DateTime filtroFechaHasta, decimal filtroImporteDesde, decimal filtroImporteHasta, string filtroDetallesFactura, string filtroDirigidaA)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                List<Factura> facturas = FindFacturas(filtroFechaDesde, filtroFechaHasta, filtroImporteDesde, filtroImporteHasta, filtroDetallesFactura, filtroDirigidaA, db);

                db.EndConnection();

                return facturas;
            }
        }

        private static List<Factura> FindFacturas(DateTime filtroFechaDesde, DateTime filtroFechaHasta, decimal filtroImporteDesde, decimal filtroImporteHasta, string filtroDetallesFactura, string filtroDirigidaA, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter filtroFechaDesdeParameter = new SqlParameter("@FiltroFechaDesde", SqlDbType.DateTime);
            filtroFechaDesdeParameter.Value = filtroFechaDesde;

            SqlParameter filtroFechaHastaParameter = new SqlParameter("@FiltroFechaHasta", SqlDbType.DateTime);
            filtroFechaHastaParameter.Value = filtroFechaHasta;

            SqlParameter filtroImporteDesdeParameter = new SqlParameter("@FiltroImporteDesde", SqlDbType.Decimal);
            filtroImporteDesdeParameter.Value = filtroImporteDesde;

            SqlParameter filtroImporteHastaParameter = new SqlParameter("@FiltroImporteHasta", SqlDbType.Decimal);
            filtroImporteHastaParameter.Value = filtroImporteHasta;

            SqlParameter filtroDetallesFacturaParameter = new SqlParameter("@FiltroDetallesFactura", SqlDbType.NVarChar);
            filtroDetallesFacturaParameter.Value = filtroDetallesFactura;

            SqlParameter filtroDirigidaAParameter = new SqlParameter("@FiltroDirigidaA", SqlDbType.NVarChar);
            filtroDirigidaAParameter.Value = filtroDirigidaA;

            parameters.Add(filtroFechaDesdeParameter);
            parameters.Add(filtroFechaHastaParameter);
            parameters.Add(filtroImporteDesdeParameter);
            parameters.Add(filtroImporteHastaParameter);
            parameters.Add(filtroDetallesFacturaParameter);
            parameters.Add(filtroDirigidaAParameter);

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_FindFacturas", parameters);
            List<Factura> facturas = new List<Factura>();
            foreach (DataRow row in res.Rows)
            {
                var factura = new Factura
                {
                    IdFactura = Convert.ToInt32(row["IdFactura"]),
                    IdPublicacion = Convert.ToInt32(row["IdPublicacion"]),
                    IdFormaDePago = Convert.ToInt32(row["IdFormaPago"]),
                    Total = Convert.ToDecimal(row["Total"]),
                    Fecha = Convert.ToDateTime(row["Fecha"])
                };

                facturas.Add(factura);
            }

            return facturas;
        }
    }
}
