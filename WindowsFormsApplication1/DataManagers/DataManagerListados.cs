using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter trimestreParameter = new SqlParameter("@NroTrimestre", SqlDbType.Int);
            trimestreParameter.Value = trimestre;

            SqlParameter anioParameter = new SqlParameter("@Año", SqlDbType.Int);
            anioParameter.Value = anio;

            parameters.Add(trimestreParameter);
            parameters.Add(anioParameter);

            DataTable res = db.GetDataAsTable("GetListadoVendedoresMontos", parameters);
            List<Vendedor> vendedores = new List<Vendedor>();
            foreach (DataRow row in res.Rows)
            {
                var vendedor = new Vendedor
                {
                    MontoFacturado = Convert.ToInt32(row["MontoFacturado"]),
                    Documento = Convert.ToString(row["Documento"]),
                    IdUsuario = Convert.ToInt32(row["IdUsuario"])
                    // TODO Agregar NombreUsuario
                };

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
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter trimestreParameter = new SqlParameter("@NroTrimestre", SqlDbType.Int);
            trimestreParameter.Value = trimestre;

            SqlParameter anioParameter = new SqlParameter("@Año", SqlDbType.Int);
            anioParameter.Value = anio;

            parameters.Add(trimestreParameter);
            parameters.Add(anioParameter);

            DataTable res = db.GetDataAsTable("GetListadoVendedoresFacturas", parameters);
            List<Vendedor> vendedores = new List<Vendedor>();
            foreach (DataRow row in res.Rows)
            {
                var vendedor = new Vendedor
                {
                    Cantidad = Convert.ToInt32(row["Cantidad"]),
                    IdUsuario = Convert.ToInt32(row["IdUsuario"])
                    // TODO Agregar NombreUsuario
                };

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

        private static List<Cliente> GetListadoClientesProductosComprados(int trimestre, int anio, Rubro rubro, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter trimestreParameter = new SqlParameter("@NroTrimestre", SqlDbType.Int);
            trimestreParameter.Value = trimestre;

            SqlParameter anioParameter = new SqlParameter("@Año", SqlDbType.Int);
            anioParameter.Value = anio;

            SqlParameter rubroParameter = new SqlParameter("@Rubro", SqlDbType.Int);
            rubroParameter.Value = rubro.IdRubro;

            parameters.Add(trimestreParameter);
            parameters.Add(anioParameter);
            parameters.Add(rubroParameter);

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetListadoClientesProductosComprados", parameters); // TODO HACER ESTE SP Y MANDAR PARAMETROS!
            List<Cliente> clientes = new List<Cliente>();
            foreach (DataRow row in res.Rows)
            {
                var cliente = new Cliente
                {
                    Nombre = Convert.ToString(row["Nombre"]),
                    Apellido = Convert.ToString(row["Apellido"]),
                    Email = Convert.ToString(row["Email"]),
                    IdUsuario = Convert.ToInt32(row["IdUsuario"]),
                    NumeroDoc = Convert.ToInt32(row["NumeroDoc"]),
                    CantidadProductosComprados = Convert.ToInt32(row["CantProdComprados"])
                };

                clientes.Add(cliente);
            }

            return clientes;
        }

        public static List<Vendedor> GetListadoVendedoresProductosNoVendidos(int trimestre, int anio) // TODO Agregar parámetro visibilidad
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
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter trimestreParameter = new SqlParameter("@NroTrimestre", SqlDbType.Int);
            trimestreParameter.Value = trimestre;

            SqlParameter anioParameter = new SqlParameter("@Año", SqlDbType.Int);
            anioParameter.Value = anio;

            parameters.Add(trimestreParameter);
            parameters.Add(anioParameter);

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetListadoVendedoresProductosNoVendidos", parameters); //TODO HACER ESTE SP Y MANDAR PARAMETROS!
            List<Vendedor> vendedores = new List<Vendedor>();
            foreach (DataRow row in res.Rows)
            {
                var vendedor = new Vendedor
                {
                    Cantidad = Convert.ToInt32(row["Cantidad"]),
                    Descripcion = Convert.ToString(row["Descripcion"]),
                    Documento = Convert.ToString(row["Documento"]),
                    IdUsuario = Convert.ToInt32(row["IdUsuario"])
                };

                vendedores.Add(vendedor);
            }

            return vendedores;
        }
    }
}
