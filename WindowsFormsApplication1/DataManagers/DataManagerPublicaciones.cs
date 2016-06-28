using System;
using System.Collections.Generic;
using MercadoEnvio.Entidades;
using MercadoEnvio.Helpers;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MercadoEnvio.DataManagers
{
    public class DataManagerPublicaciones
    {
        public static List<Publicacion> GetAllData()
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                List<Publicacion> publicaciones = GetPublicaciones(db);

                db.EndConnection();

                return publicaciones;
            }
        }

        private static List<Publicacion> GetPublicaciones(DataBaseHelper db)
        {
            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetPublicaciones");
            List<Publicacion> publicaciones = new List<Publicacion>();
            foreach (DataRow row in res.Rows)
            {
                var publicacion = new Publicacion
                {
                    IdPublicacion = Convert.ToInt32(row["IdPublicacion"]),
                    Descripcion = Convert.ToString(row["Descripcion"]),
                    Stock = Convert.ToInt32(row["Stock"]),
                    FechaInicio = Convert.ToDateTime(row["FechaInicio"]),
                    FechaVencimiento = Convert.ToDateTime(row["FechaVencimiento"]),
                    Precio = Convert.ToDecimal(row["Precio"]),
                    PrecioReserva = row["PrecioReserva"] == DBNull.Value ? 0 : Convert.ToDecimal(row["PrecioReserva"]),
                    IdRubro = Convert.ToInt32(row["IdRubro"]),
                    IdUsuario = Convert.ToInt32(row["IdUsuario"]),
                    IdEstado = Convert.ToInt32(row["IdEstado"]),
                    Envio = Convert.ToBoolean(row["Envio"]),
                    Visibilidad = new Visibilidad
                    {
                        IdVisibilidad = Convert.ToInt32(row["IdVisibilidad"]),
                        Descripcion = Convert.ToString(row["DescripcionVisibilidad"]),
                        Precio = Convert.ToDecimal(row["Precio"]),
                        Porcentaje = Convert.ToDecimal(row["Porcentaje"]),
                        EnvioPorcentaje = Convert.ToDecimal(row["EnvioPorcentaje"])
                    },
                    TipoPublicacion = new TipoPublicacion
                    {
                        IdTipo = Convert.ToInt32(row["IdTipo"]),
                        Descripcion = Convert.ToString(row["DescripcionTipoPublicacion"]),
                        Envio = Convert.ToBoolean(row["Envio"]),
                    }
                };


                publicaciones.Add(publicacion);
            }

            return publicaciones;
        }

        public static List<Publicacion> FindPublicaciones(string filtroDescripcion, List<Rubro> rubrosFiltro)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                List<Publicacion> publicaciones = FindPublicaciones(filtroDescripcion, rubrosFiltro, db);

                db.EndConnection();

                return publicaciones;
            }
        }

        private static List<Publicacion> FindPublicaciones(string filtroDescripcion, int idRubro, DataBaseHelper db)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter filtroDescripcionParameter = new SqlParameter("@FiltroDescripcion", SqlDbType.NVarChar);
            filtroDescripcionParameter.Value = filtroDescripcion.Trim();

            SqlParameter filtroIdRubroParameter = new SqlParameter("@FiltroIdRubro", SqlDbType.Int);
            filtroIdRubroParameter.Value = idRubro;

            parameters.Add(filtroDescripcionParameter);
            parameters.Add(filtroIdRubroParameter);

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_FindPublicaciones", parameters);
            foreach (DataRow row in res.Rows)
            {
                var publicacion = new Publicacion
                {
                    IdPublicacion = Convert.ToInt32(row["IdPublicacion"]),
                    Descripcion = Convert.ToString(row["Descripcion"]),
                    Stock = Convert.ToInt32(row["Stock"]),
                    FechaInicio = Convert.ToDateTime(row["FechaInicio"]),
                    FechaVencimiento = Convert.ToDateTime(row["FechaVencimiento"]),
                    Precio = Convert.ToDecimal(row["Precio"]),
                    PrecioReserva = row["PrecioReserva"] == DBNull.Value ? 0 : Convert.ToDecimal(row["PrecioReserva"]),
                    IdRubro = Convert.ToInt32(row["IdRubro"]),
                    IdUsuario = Convert.ToInt32(row["IdUsuario"]),
                    IdEstado = Convert.ToInt32(row["IdEstado"]),
                    Envio = Convert.ToBoolean(row["Envio"]),
                    Visibilidad = new Visibilidad
                    {
                        IdVisibilidad = Convert.ToInt32(row["IdVisibilidad"]),
                        Descripcion = Convert.ToString(row["DescripcionVisibilidad"]),
                        Precio = Convert.ToDecimal(row["Precio"]),
                        Porcentaje = Convert.ToDecimal(row["Porcentaje"]),
                        EnvioPorcentaje = Convert.ToDecimal(row["EnvioPorcentaje"])
                    },
                    TipoPublicacion = new TipoPublicacion
                    {
                        IdTipo = Convert.ToInt32(row["IdTipo"]),
                        Descripcion = Convert.ToString(row["DescripcionTipoPublicacion"]),
                        Envio = Convert.ToBoolean(row["Envio"]),
                    }
                };

                publicaciones.Add(publicacion);
            }

            return publicaciones;
        }

        private static List<Publicacion> FindPublicaciones(string filtroDescripcion, List<Rubro> rubrosFiltro, DataBaseHelper db)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();

            if (rubrosFiltro.Count > 0)
                foreach (Rubro rubro in rubrosFiltro)
                {
                    var publicacionesAux = FindPublicaciones(filtroDescripcion, rubro.IdRubro, db);

                    foreach (Publicacion publicacion in publicacionesAux)
                    {
                        if (!publicaciones.Exists(x => x.IdPublicacion == publicacion.IdPublicacion))
                            publicaciones.Add(publicacion);
                    }
                }
            else
                publicaciones = FindPublicaciones(filtroDescripcion, 0, db);

            return publicaciones;
        }

        public static int Ofertar(Publicacion publicacionSeleccionada, Usuario usuarioActivo, string monto)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                int nroOferta = Ofertar(publicacionSeleccionada, usuarioActivo, monto, db);

                db.EndConnection();

                return nroOferta;
            }
        }

        private static int Ofertar(Publicacion publicacionSeleccionada, Usuario usuarioActivo, string monto, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idPublicacionParameter = new SqlParameter("@IdPublicacion", SqlDbType.Int);
            idPublicacionParameter.Value = publicacionSeleccionada.IdPublicacion;

            SqlParameter fechaParameter = new SqlParameter("@Fecha", SqlDbType.DateTime);
            fechaParameter.Value = new FechaHelper().GetSystemDate();

            SqlParameter montoParameter = new SqlParameter("@Monto", SqlDbType.Decimal);
            montoParameter.Value = Convert.ToInt32(monto);

            SqlParameter idUsuarioParameter = new SqlParameter("@IdPublicacion", SqlDbType.Int);
            idUsuarioParameter.Value = usuarioActivo.IdUsuario;

            parameters.Add(idPublicacionParameter);
            parameters.Add(fechaParameter);
            parameters.Add(montoParameter);
            parameters.Add(idUsuarioParameter);

            return (int)db.ExecInstruction(DataBaseHelper.ExecutionType.Scalar, "MASTERDBA.SP_InsertOferta", parameters);
        }

        public static int Comprar(Publicacion publicacionSeleccionada, Usuario usuarioActivo, string cantidad, bool envio)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                int nroCompra = Comprar(publicacionSeleccionada, usuarioActivo, cantidad, envio, db);

                db.EndConnection();

                return nroCompra;
            }
        }

        private static int Comprar(Publicacion publicacionSeleccionada, Usuario usuarioActivo, string cantidad, bool envio, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idPublicacionParameter = new SqlParameter("@IdPublicacion", SqlDbType.Int);
            idPublicacionParameter.Value = publicacionSeleccionada.IdPublicacion;

            SqlParameter fechaParameter = new SqlParameter("@Fecha", SqlDbType.DateTime);
            fechaParameter.Value = new FechaHelper().GetSystemDate();

            SqlParameter cantidadParameter = new SqlParameter("@Cantidad", SqlDbType.Decimal);
            cantidadParameter.Value = Convert.ToInt32(cantidad);

            SqlParameter envioParameter = new SqlParameter("@Envio", SqlDbType.Bit);
            envioParameter.Value = envio;

            SqlParameter idUsuarioParameter = new SqlParameter("@IdUsuario", SqlDbType.Int);
            idUsuarioParameter.Value = usuarioActivo.IdUsuario;

            parameters.Add(idPublicacionParameter);
            parameters.Add(fechaParameter);
            parameters.Add(cantidadParameter);
            parameters.Add(envioParameter);
            parameters.Add(idUsuarioParameter);

            // Actualizar stock, englobar dentro de transacción
            return (int)db.ExecInstruction(DataBaseHelper.ExecutionType.Scalar, "MASTERDBA.SP_InsertCompra", parameters); // TODO Insertar factura
        }
    }
}
