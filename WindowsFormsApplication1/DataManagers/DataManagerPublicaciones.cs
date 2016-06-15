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
                var publicacion = new Publicacion();

                publicacion.IdPublicacion = Convert.ToInt32(row["IdPublicacion"]);
                publicacion.Descripcion = Convert.ToString(row["Descripcion"]);
                publicacion.Stock = Convert.ToInt32(row["Stock"]);
                publicacion.FechaInicio = Convert.ToDateTime(row["FechaInicio"]);
                publicacion.FechaVencimiento = Convert.ToDateTime(row["FechaVencimiento"]);
                publicacion.Precio = Convert.ToDecimal(row["Precio"]);
                publicacion.PrecioReserva = row["PrecioReserva"] == DBNull.Value ? 0 : Convert.ToDecimal(row["PrecioReserva"]);
                publicacion.IdRubro = Convert.ToInt32(row["IdRubro"]);
                publicacion.IdUsuario = Convert.ToInt32(row["IdUsuario"]);
                publicacion.IdEstado = Convert.ToInt32(row["IdEstado"]);
                publicacion.Envio = Convert.ToBoolean(row["Envio"]);
                publicacion.Visibilidad = new Visibilidad
                {
                    IdVisibilidad = Convert.ToInt32(row["IdVisibilidad"]),
                    Descripcion = Convert.ToString(row["DescripcionVisibilidad"]),
                    Precio = Convert.ToDecimal(row["Precio"]),
                    Porcentaje = Convert.ToDecimal(row["Porcentaje"]),
                    EnvioPorcentaje = Convert.ToDecimal(row["EnvioPorcentaje"])
                };
                publicacion.TipoPublicacion = new TipoPublicacion
                {
                    IdTipo = Convert.ToInt32(row["IdTipo"]),
                    Descripcion = Convert.ToString(row["DescripcionTipoPublicacion"]),
                    Envio = Convert.ToBoolean(row["Envio"]),
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

        private static List<Publicacion> FindPublicaciones(string filtroDescripcion, List<Rubro> rubrosFiltro,
            DataBaseHelper db)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (rubrosFiltro.Count > 0)
            {
                foreach (Rubro rubro in rubrosFiltro)
                {
                    SqlParameter filtroDescripcionParameter = new SqlParameter("@FiltroDescripcion", SqlDbType.NVarChar);
                    filtroDescripcionParameter.Value = filtroDescripcion.Trim();

                    SqlParameter filtroIdRubroParameter = new SqlParameter("@FiltroIdRubro", SqlDbType.Int);
                    filtroIdRubroParameter.Value = rubro.IdRubro;

                    parameters.Add(filtroDescripcionParameter);
                    parameters.Add(filtroIdRubroParameter);

                    DataTable res = db.GetDataAsTable("MASTERDBA.SP_FindPublicaciones", parameters);
                    foreach (DataRow row in res.Rows)
                    {
                        var publicacion = new Publicacion();

                        publicacion.IdPublicacion = Convert.ToInt32(row["IdPublicacion"]);
                        publicacion.Descripcion = Convert.ToString(row["Descripcion"]);
                        publicacion.Stock = Convert.ToInt32(row["Stock"]);
                        publicacion.FechaInicio = Convert.ToDateTime(row["FechaInicio"]);
                        publicacion.FechaVencimiento = Convert.ToDateTime(row["FechaVencimiento"]);
                        publicacion.Precio = Convert.ToDecimal(row["Precio"]);
                        publicacion.PrecioReserva = row["PrecioReserva"] == DBNull.Value ? 0 : Convert.ToDecimal(row["PrecioReserva"]);
                        publicacion.IdRubro = Convert.ToInt32(row["IdRubro"]);
                        publicacion.IdUsuario = Convert.ToInt32(row["IdUsuario"]);
                        publicacion.IdEstado = Convert.ToInt32(row["IdEstado"]);
                        publicacion.Envio = Convert.ToBoolean(row["Envio"]);
                        publicacion.Visibilidad = new Visibilidad
                        {
                            IdVisibilidad = Convert.ToInt32(row["IdVisibilidad"]),
                            Descripcion = Convert.ToString(row["DescripcionVisibilidad"]),
                            Precio = Convert.ToDecimal(row["Precio"]),
                            Porcentaje = Convert.ToDecimal(row["Porcentaje"]),
                            EnvioPorcentaje = Convert.ToDecimal(row["EnvioPorcentaje"])
                        };
                        publicacion.TipoPublicacion = new TipoPublicacion
                        {
                            IdTipo = Convert.ToInt32(row["IdTipo"]),
                            Descripcion = Convert.ToString(row["DescripcionTipoPublicacion"]),
                            Envio = Convert.ToBoolean(row["Envio"]),
                        };

                        if (!publicaciones.Exists(x => x.IdPublicacion == publicacion.IdPublicacion))
                            publicaciones.Add(publicacion);

                        parameters.Clear();
                    }
                }
            }
            else
            {
                SqlParameter filtroDescripcionParameter = new SqlParameter("@FiltroDescripcion", SqlDbType.NVarChar);
                filtroDescripcionParameter.Value = filtroDescripcion.Trim();

                SqlParameter filtroIdRubroParameter = new SqlParameter("@FiltroIdRubro", SqlDbType.Int);
                filtroIdRubroParameter.Value = 0;

                parameters.Add(filtroDescripcionParameter);
                parameters.Add(filtroIdRubroParameter);

                DataTable res = db.GetDataAsTable("MASTERDBA.SP_FindPublicaciones", parameters);
                foreach (DataRow row in res.Rows)
                {
                    var publicacion = new Publicacion();

                    publicacion.IdPublicacion = Convert.ToInt32(row["IdPublicacion"]);
                    publicacion.Descripcion = Convert.ToString(row["Descripcion"]);
                    publicacion.Stock = Convert.ToInt32(row["Stock"]);
                    publicacion.FechaInicio = Convert.ToDateTime(row["FechaInicio"]);
                    publicacion.FechaVencimiento = Convert.ToDateTime(row["FechaVencimiento"]);
                    publicacion.Precio = Convert.ToDecimal(row["Precio"]);
                    publicacion.PrecioReserva = row["PrecioReserva"] == DBNull.Value ? 0 : Convert.ToDecimal(row["PrecioReserva"]);
                    publicacion.IdRubro = Convert.ToInt32(row["IdRubro"]);
                    publicacion.IdUsuario = Convert.ToInt32(row["IdUsuario"]);
                    publicacion.IdEstado = Convert.ToInt32(row["IdEstado"]);
                    publicacion.Envio = Convert.ToBoolean(row["Envio"]);
                    publicacion.Visibilidad = new Visibilidad
                    {
                        IdVisibilidad = Convert.ToInt32(row["IdVisibilidad"]),
                        Descripcion = Convert.ToString(row["DescripcionVisibilidad"]),
                        Precio = Convert.ToDecimal(row["Precio"]),
                        Porcentaje = Convert.ToDecimal(row["Porcentaje"]),
                        EnvioPorcentaje = Convert.ToDecimal(row["EnvioPorcentaje"])
                    };
                    publicacion.TipoPublicacion = new TipoPublicacion
                    {
                        IdTipo = Convert.ToInt32(row["IdTipo"]),
                        Descripcion = Convert.ToString(row["DescripcionTipoPublicacion"]),
                        Envio = Convert.ToBoolean(row["Envio"]),
                    };

                    publicaciones.Add(publicacion);

                    parameters.Clear();
                }
            }

            return publicaciones;
        }

        public static List<Publicacion> GetPendientesCalificar()
        {
            List<Publicacion> listaPublicaciones;
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                listaPublicaciones = GetPendientesCalificar(db);

                db.EndConnection();

                return listaPublicaciones;
            }
        }

        public static List<Publicacion> GetPendientesCalificar(DataBaseHelper db)
        {
            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetPendientesCalificar"); //TODO HACER ESTE SP Y VER SI VALE LA PENA LLENAR TODAS LAS PROPIEDADES
            List<Publicacion> publicaciones = new List<Publicacion>();
            foreach (DataRow row in res.Rows)
            {
                var publicacion = new Publicacion();

                publicacion.IdPublicacion = Convert.ToInt32(row["IdPublicacion"]);
                publicacion.Descripcion = Convert.ToString(row["Descripcion"]);
                publicacion.Stock = Convert.ToInt32(row["Stock"]);
                publicacion.FechaInicio = Convert.ToDateTime(row["FechaInicio"]);
                publicacion.FechaVencimiento = Convert.ToDateTime(row["FechaVencimiento"]);
                publicacion.Precio = Convert.ToDecimal(row["Precio"]);
                publicacion.PrecioReserva = row["PrecioReserva"] == DBNull.Value ? 0 : Convert.ToDecimal(row["PrecioReserva"]);
                publicacion.IdRubro = Convert.ToInt32(row["IdRubro"]);
                publicacion.IdUsuario = Convert.ToInt32(row["IdUsuario"]);
                publicacion.IdEstado = Convert.ToInt32(row["IdEstado"]);
                publicacion.Envio = Convert.ToBoolean(row["Envio"]);
                publicacion.Visibilidad = new Visibilidad
                {
                    IdVisibilidad = Convert.ToInt32(row["IdVisibilidad"]),
                    Descripcion = Convert.ToString(row["DescripcionVisibilidad"]),
                    Precio = Convert.ToDecimal(row["Precio"]),
                    Porcentaje = Convert.ToDecimal(row["Porcentaje"]),
                    EnvioPorcentaje = Convert.ToDecimal(row["EnvioPorcentaje"])
                };
                publicacion.TipoPublicacion = new TipoPublicacion
                {
                    IdTipo = Convert.ToInt32(row["IdTipo"]),
                    Descripcion = Convert.ToString(row["DescripcionTipoPublicacion"]),
                    Envio = Convert.ToBoolean(row["Envio"]),
                };

                publicaciones.Add(publicacion);
            }

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
            fechaParameter.Value = DateTime.Now; // TODO Recuperar del app.config

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
            fechaParameter.Value = DateTime.Now; // TODO Recuperar del app.config

            SqlParameter cantidadParameter = new SqlParameter("@Cantidad", SqlDbType.Decimal);
            cantidadParameter.Value = Convert.ToInt32(cantidad);

            SqlParameter envioParameter = new SqlParameter("@Envio", SqlDbType.Bit);
            envioParameter.Value = envio;

            SqlParameter idUsuarioParameter = new SqlParameter("@IdPublicacion", SqlDbType.Int);
            idUsuarioParameter.Value = usuarioActivo.IdUsuario;

            parameters.Add(idPublicacionParameter);
            parameters.Add(fechaParameter);
            parameters.Add(cantidadParameter);
            parameters.Add(envioParameter);
            parameters.Add(idUsuarioParameter);

            return (int)db.ExecInstruction(DataBaseHelper.ExecutionType.Scalar, "MASTERDBA.SP_InsertCompra", parameters); // TODO Insertar factura
        }
    }
}
