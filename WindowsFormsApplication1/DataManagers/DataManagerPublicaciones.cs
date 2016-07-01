using System;
using System.Collections.Generic;
using MercadoEnvio.Entidades;
using MercadoEnvio.Helpers;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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

                List<Publicacion> publicaciones = FindPublicaciones(String.Empty, 0, db);

                db.EndConnection();

                return publicaciones;
            }
        }

        public static List<Publicacion> FindPublicaciones(string filtroDescripcion, List<Rubro> rubrosFiltro)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                List<Publicacion> publicaciones = FindPublicaciones(filtroDescripcion, rubrosFiltro, db);

                db.EndConnection();

                return publicaciones.OrderByDescending(x => x.Visibilidad.Precio).ToList();
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
                    RubroDescripcionCorta = Convert.ToString(row["RubroDescripcionCorta"]),
                    RubroDescripcionLarga = Convert.ToString(row["RubroDescripcionLarga"]),
                    IdUsuario = Convert.ToInt32(row["IdUsuario"]),
                    NombreUsuario = Convert.ToString(row["NombreUsuario"]),
                    EstadoPublicacion = new EstadoPublicacion
                    {
                        IdEstado = Convert.ToInt32(row["IdEstado"]),
                        Descripcion = Convert.ToString(row["EstadoDescripcion"])
                    },
                    Envio = Convert.ToBoolean(row["Envio"]),
                    TipoPublicacion = new TipoPublicacion
                    {
                        IdTipo = Convert.ToInt32(row["IdTipo"]),
                        Descripcion = Convert.ToString(row["TipoDescripcion"]),
                        Envio = Convert.ToBoolean(row["TipoEnvio"]),
                    },
                    Visibilidad = new Visibilidad
                    {
                        IdVisibilidad = Convert.ToInt32(row["IdVisibilidad"]),
                        Descripcion = Convert.ToString(row["VisibilidadDescripcion"]),
                        Precio = Convert.ToDecimal(row["VisibilidadPrecio"]),
                        Porcentaje = Convert.ToDecimal(row["Porcentaje"]),
                        EnvioPorcentaje = Convert.ToDecimal(row["EnvioPorcentaje"])
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

        public static List<EstadoPublicacion> GetEstados(string descripcionEstado)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                List<EstadoPublicacion> estados = GetEstados(descripcionEstado, db);

                db.EndConnection();

                return estados;
            }
        }

        private static List<EstadoPublicacion> GetEstados(string descripcionEstado, DataBaseHelper db)
        {
            List<EstadoPublicacion> estados = new List<EstadoPublicacion>();
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter descripcionParameter = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
            descripcionParameter.Value = descripcionEstado;

            parameters.Add(descripcionParameter);

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetEstados", parameters);
            foreach (DataRow row in res.Rows)
            {
                var estado = new EstadoPublicacion
                {
                    IdEstado = Convert.ToInt32(row["IdEstado"]),
                    Descripcion = Convert.ToString(row["Descripcion"])
                };

                estados.Add(estado);
            }

            return estados;
        }

        public static Publicacion GetPublicacion(int idPublicacion, int idUsuario)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                Publicacion publicacion = GetPublicacion(idPublicacion, idUsuario, db);

                db.EndConnection();

                return publicacion;
            }
        }

        private static Publicacion GetPublicacion(int idPublicacion, int idUsuario, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idPublicacionParameter = new SqlParameter("@IdPublicacion", SqlDbType.Int);
            idPublicacionParameter.Value = idPublicacion;

            SqlParameter idUsuarioParameter = new SqlParameter("@IdUsuario", SqlDbType.Int);
            idUsuarioParameter.Value = idUsuario;

            parameters.Add(idPublicacionParameter);
            parameters.Add(idUsuarioParameter);

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetPublicacion", parameters);
            Publicacion publicacion = null;
            foreach (DataRow row in res.Rows)
            {
                publicacion = new Publicacion
                {
                    IdPublicacion = Convert.ToInt32(row["IdPublicacion"]),
                    Descripcion = Convert.ToString(row["Descripcion"]),
                    Stock = Convert.ToInt32(row["Stock"]),
                    FechaInicio = Convert.ToDateTime(row["FechaInicio"]),
                    FechaVencimiento = Convert.ToDateTime(row["FechaVencimiento"]),
                    Precio = Convert.ToDecimal(row["Precio"]),
                    PrecioReserva = row["PrecioReserva"] == DBNull.Value ? 0 : Convert.ToDecimal(row["PrecioReserva"]),
                    IdRubro = Convert.ToInt32(row["IdRubro"]),
                    RubroDescripcionCorta = Convert.ToString(row["RubroDescripcionCorta"]),
                    RubroDescripcionLarga = Convert.ToString(row["RubroDescripcionLarga"]),
                    IdUsuario = Convert.ToInt32(row["IdUsuario"]),
                    NombreUsuario = Convert.ToString(row["NombreUsuario"]),
                    EstadoPublicacion = new EstadoPublicacion
                    {
                        IdEstado = Convert.ToInt32(row["IdEstado"]),
                        Descripcion = Convert.ToString(row["EstadoDescripcion"])
                    },
                    Envio = Convert.ToBoolean(row["Envio"]),
                    TipoPublicacion = new TipoPublicacion
                    {
                        IdTipo = Convert.ToInt32(row["IdTipo"]),
                        Descripcion = Convert.ToString(row["TipoDescripcion"]),
                        Envio = Convert.ToBoolean(row["TipoEnvio"]),
                    },
                    Visibilidad = new Visibilidad
                    {
                        IdVisibilidad = Convert.ToInt32(row["IdVisibilidad"]),
                        Descripcion = Convert.ToString(row["VisibilidadDescripcion"]),
                        Precio = Convert.ToDecimal(row["VisibilidadPrecio"]),
                        Porcentaje = Convert.ToDecimal(row["Porcentaje"]),
                        EnvioPorcentaje = Convert.ToDecimal(row["EnvioPorcentaje"])
                    }
                };
            }

            return publicacion;
        }

        public static void UpdatePublicacion(string idPublicacion, string descripcion, string stock, DateTime fechaInicio, DateTime fechaVencimiento, string precio, string precioReserva, int idRubro, int idUsuario, int idEstado, int idTipo, bool envio, int idVisibilidad)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                UpdatePublicacion(idPublicacion, descripcion, stock, fechaInicio, fechaVencimiento, precio, precioReserva, idRubro, idUsuario, idEstado, idTipo, envio, idVisibilidad, db);

                db.EndConnection();
            }
        }

        private static void UpdatePublicacion(string idPublicacion, string descripcion, string stock, DateTime fechaInicio, DateTime fechaVencimiento, string precio, string precioReserva, int idRubro, int idUsuario, int idEstado, int idTipo, bool envio, int idVisibilidad, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idPublicacionParameter = new SqlParameter("@IdPublicacion", SqlDbType.Decimal);
            idPublicacionParameter.Value = Convert.ToDecimal(idPublicacion.Trim());

            SqlParameter descripcionParameter = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
            descripcionParameter.Value = descripcion.Trim();

            SqlParameter stockParameter = new SqlParameter("@Stock", SqlDbType.Decimal);
            stockParameter.Value = Convert.ToDecimal(stock.Trim());

            SqlParameter fechaInicioParameter = new SqlParameter("@FechaInicio", SqlDbType.DateTime);
            fechaInicioParameter.Value = fechaInicio;

            SqlParameter fechaVencimientoParameter = new SqlParameter("@FechaVencimiento", SqlDbType.DateTime);
            fechaVencimientoParameter.Value = fechaVencimiento;

            SqlParameter precioParameter = new SqlParameter("@Precio", SqlDbType.Decimal);
            precioParameter.Value = Convert.ToDecimal(precio.Trim());

            SqlParameter precioReservaParameter = new SqlParameter("@PrecioReserva", SqlDbType.Decimal);
            precioReservaParameter.Value = Convert.ToDecimal(precioReserva.Trim());

            SqlParameter idRubroParameter = new SqlParameter("@IdRubro", SqlDbType.Int);
            idRubroParameter.Value = idRubro;

            SqlParameter idUsuarioParameter = new SqlParameter("@IdUsuario", SqlDbType.Int);
            idUsuarioParameter.Value = idUsuario;

            SqlParameter idEstadoParameter = new SqlParameter("@IdEstado", SqlDbType.Int);
            idEstadoParameter.Value = idEstado;

            SqlParameter idTipoParameter = new SqlParameter("@IdTipo", SqlDbType.Int);
            idTipoParameter.Value = idTipo;

            SqlParameter envioParameter = new SqlParameter("@Envio", SqlDbType.Bit);
            envioParameter.Value = envio;

            SqlParameter idVisibilidadParameter = new SqlParameter("@IdVisibilidad", SqlDbType.Int);
            idVisibilidadParameter.Value = idVisibilidad;

            parameters.Add(idPublicacionParameter);
            parameters.Add(descripcionParameter);
            parameters.Add(stockParameter);
            parameters.Add(fechaInicioParameter);
            parameters.Add(fechaVencimientoParameter);
            parameters.Add(precioParameter);
            parameters.Add(precioReservaParameter);
            parameters.Add(idRubroParameter);
            parameters.Add(idUsuarioParameter);
            parameters.Add(idEstadoParameter);
            parameters.Add(idTipoParameter);
            parameters.Add(envioParameter);
            parameters.Add(idVisibilidadParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "MASTERDBA.SP_UpdatePublicacion", parameters);
        }

        public static void InsertPublicacion(string descripcion, string stock, DateTime fechaInicio, DateTime fechaVencimiento, string precio, string precioReserva, int idRubro, int idUsuario, int idEstado, int idTipo, bool envio, int idVisibilidad)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                InsertPublicacion(descripcion, stock, fechaInicio, fechaVencimiento, precio, precioReserva, idRubro, idUsuario, idEstado, idTipo, envio, idVisibilidad, db);

                db.EndConnection();
            }
        }

        private static void InsertPublicacion(string descripcion, string stock, DateTime fechaInicio, DateTime fechaVencimiento, string precio, string precioReserva, int idRubro, int idUsuario, int idEstado, int idTipo, bool envio, int idVisibilidad, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter descripcionParameter = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
            descripcionParameter.Value = descripcion.Trim();

            SqlParameter stockParameter = new SqlParameter("@Stock", SqlDbType.Decimal);
            stockParameter.Value = Convert.ToDecimal(stock.Trim());

            SqlParameter fechaInicioParameter = new SqlParameter("@FechaInicio", SqlDbType.DateTime);
            fechaInicioParameter.Value = fechaInicio;

            SqlParameter fechaVencimientoParameter = new SqlParameter("@FechaVencimiento", SqlDbType.DateTime);
            fechaVencimientoParameter.Value = fechaVencimiento;

            SqlParameter precioParameter = new SqlParameter("@Precio", SqlDbType.Decimal);
            precioParameter.Value = Convert.ToDecimal(precio.Trim());

            SqlParameter precioReservaParameter = new SqlParameter("@PrecioReserva", SqlDbType.Decimal);
            precioReservaParameter.Value = Convert.ToDecimal(precioReserva.Trim());

            SqlParameter idRubroParameter = new SqlParameter("@IdRubro", SqlDbType.Int);
            idRubroParameter.Value = idRubro;

            SqlParameter idUsuarioParameter = new SqlParameter("@IdUsuario", SqlDbType.Int);
            idUsuarioParameter.Value = idUsuario;

            SqlParameter idEstadoParameter = new SqlParameter("@IdEstado", SqlDbType.Int);
            idEstadoParameter.Value = idEstado;

            SqlParameter idTipoParameter = new SqlParameter("@IdTipo", SqlDbType.Int);
            idTipoParameter.Value = idTipo;

            SqlParameter envioParameter = new SqlParameter("@Envio", SqlDbType.Bit);
            envioParameter.Value = envio;

            SqlParameter idVisibilidadParameter = new SqlParameter("@IdVisibilidad", SqlDbType.Int);
            idVisibilidadParameter.Value = idVisibilidad;

            parameters.Add(descripcionParameter);
            parameters.Add(stockParameter);
            parameters.Add(fechaInicioParameter);
            parameters.Add(fechaVencimientoParameter);
            parameters.Add(precioParameter);
            parameters.Add(precioReservaParameter);
            parameters.Add(idRubroParameter);
            parameters.Add(idUsuarioParameter);
            parameters.Add(idEstadoParameter);
            parameters.Add(idTipoParameter);
            parameters.Add(envioParameter);
            parameters.Add(idVisibilidadParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "MASTERDBA.SP_InsertPublicacion", parameters);
        }
    }
}
