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
            DataTable res = db.GetDataAsTable("SP_GetPublicaciones");
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
                publicacion.PrecioReserva = row["PrecioReserva"] == System.DBNull.Value ? 0 : Convert.ToDecimal(row["PrecioReserva"]);
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

                    DataTable res = db.GetDataAsTable("SP_FindPublicaciones", parameters);
                    foreach (DataRow row in res.Rows)
                    {
                        var publicacion = new Publicacion();

                        publicacion.IdPublicacion = Convert.ToInt32(row["IdPublicacion"]);
                        publicacion.Descripcion = Convert.ToString(row["Descripcion"]);
                        publicacion.Stock = Convert.ToInt32(row["Stock"]);
                        publicacion.FechaInicio = Convert.ToDateTime(row["FechaInicio"]);
                        publicacion.FechaVencimiento = Convert.ToDateTime(row["FechaVencimiento"]);
                        publicacion.Precio = Convert.ToDecimal(row["Precio"]);
                        publicacion.PrecioReserva = row["PrecioReserva"] == System.DBNull.Value ? 0 : Convert.ToDecimal(row["PrecioReserva"]);
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

                DataTable res = db.GetDataAsTable("SP_FindPublicaciones", parameters);
                foreach (DataRow row in res.Rows)
                {
                    var publicacion = new Publicacion();

                    publicacion.IdPublicacion = Convert.ToInt32(row["IdPublicacion"]);
                    publicacion.Descripcion = Convert.ToString(row["Descripcion"]);
                    publicacion.Stock = Convert.ToInt32(row["Stock"]);
                    publicacion.FechaInicio = Convert.ToDateTime(row["FechaInicio"]);
                    publicacion.FechaVencimiento = Convert.ToDateTime(row["FechaVencimiento"]);
                    publicacion.Precio = Convert.ToDecimal(row["Precio"]);
                    publicacion.PrecioReserva = row["PrecioReserva"] == System.DBNull.Value ? 0 : Convert.ToDecimal(row["PrecioReserva"]);
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
    }
}
