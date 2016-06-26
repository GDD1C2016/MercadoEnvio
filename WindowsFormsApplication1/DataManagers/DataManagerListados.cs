using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MercadoEnvio.Entidades;
using MercadoEnvio.Helpers;

namespace MercadoEnvio.DataManagers
{
    public class DataManagerListados
    {

        public static List<Vendedor> GetListadoVendedoresMontos(int trimestre, int anio)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                List<Vendedor> listaVendedores = GetListadoVendedoresMontos(trimestre, anio, db);

                db.EndConnection();

                return listaVendedores;
            }
        }

        private static List<Vendedor> GetListadoVendedoresMontos(int trimestre, int anio, DataBaseHelper db)
        {
            DataTable res = db.GetDataAsTable("GetListadoVendedoresMontos"); //TODO HACER ESTE SP Y MANDAR PARAMETROS!
            List<Vendedor> vendedores = new List<Vendedor>();
            foreach (DataRow row in res.Rows)
            {
                var vendedor = new Vendedor();
                vendedor.MontoFacturado = Convert.ToInt32(row["MontoFacturado"]);
                vendedor.Descripcion = Convert.ToString(row["Descripcion"]);
                vendedor.Documento = Convert.ToString(row["Documento"]);
                vendedor.IdUsuario = Convert.ToInt32(row["IdUsuario"]);

                vendedores.Add(vendedor);
            }

            return vendedores;
        }

        public static List<Vendedor> GetListadoVendedoresFacturas(int trimestre, int anio)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                List<Vendedor> listaVendedores = GetListadoVendedoresFacturas(trimestre, anio, db);

                db.EndConnection();

                return listaVendedores;
            }
        }

        private static List<Vendedor> GetListadoVendedoresFacturas(int trimestre, int anio, DataBaseHelper db)
        {
            DataTable res = db.GetDataAsTable("GetListadoVendedoresFacturas"); //TODO HACER ESTE SP Y MANDAR PARAMETROS!
            List<Vendedor> vendedores = new List<Vendedor>();
            foreach (DataRow row in res.Rows)
            {
                var vendedor = new Vendedor();
                vendedor.Cantidad = Convert.ToInt32(row["Cantidad"]);
                vendedor.Descripcion = Convert.ToString(row["Descripcion"]);
                vendedor.Documento = Convert.ToString(row["Documento"]);
                vendedor.IdUsuario = Convert.ToInt32(row["IdUsuario"]);

                vendedores.Add(vendedor);
            }

            return vendedores;
        }

        public static List<Cliente> GetListadoClientesProductosComprados(int trimestre, int anio, Rubro rubro)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                List<Cliente> clientes = GetListadoClientesProductosComprados(trimestre, anio, rubro, db);

                db.EndConnection();

                return clientes;
            }
        }

        private static List<Cliente> GetListadoClientesProductosComprados(int trimestre, int anio, Rubro rubro,DataBaseHelper db)
        {
            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetListadoClientesProductosComprados"); //TODO HACER ESTE SP Y MANDAR PARAMETROS!
            List<Cliente> clientes = new List<Cliente>();
            foreach (DataRow row in res.Rows)
            {
                var cliente = new Cliente();
                cliente.Nombre = Convert.ToString(row["Nombre"]);
                cliente.Apellido = Convert.ToString(row["Apellido"]);
                cliente.Email = Convert.ToString(row["Email"]);
                cliente.IdUsuario = Convert.ToInt32(row["IdUsuario"]);
                cliente.NumeroDoc = Convert.ToInt32(row["NumeroDoc"]);
                cliente.CantidadProductosComprados = Convert.ToInt32(row["CantProdComprados"]);

                clientes.Add(cliente);
            }

            return clientes;
        }

        public static List<Vendedor> GetListadoVendedoresProductosNoVendidos(int trimestre, int anio)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                List<Vendedor> listaVendedores = GetListadoVendedoresProductosNoVendidos(trimestre, anio, db);

                db.EndConnection();

                return listaVendedores;
            }
        }

        private static List<Vendedor> GetListadoVendedoresProductosNoVendidos(int trimestre, int anio, DataBaseHelper db)
        {
            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetListadoVendedoresProductosNoVendidos"); //TODO HACER ESTE SP Y MANDAR PARAMETROS!
            List<Vendedor> vendedores = new List<Vendedor>();
            foreach (DataRow row in res.Rows)
            {
                var vendedor = new Vendedor();
                vendedor.Cantidad = Convert.ToInt32(row["Cantidad"]);
                vendedor.Descripcion = Convert.ToString(row["Descripcion"]);
                vendedor.Documento = Convert.ToString(row["Documento"]);
                vendedor.IdUsuario = Convert.ToInt32(row["IdUsuario"]);

                vendedores.Add(vendedor);
            }

            return vendedores;
        }
    }
}
