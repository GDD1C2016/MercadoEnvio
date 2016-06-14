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
                var publicacion = new Publicacion
                {
                    IdPublicacion = Convert.ToInt32(row["IdPublicacion"]),
                    Descripcion = Convert.ToString(row["Descripcion"]),
                    Stock = Convert.ToInt32(row["Stock"]),
                    FechaInicio = Convert.ToDateTime(row["FechaInicio"]),
                    FechaVencimiento = Convert.ToDateTime(row["FechaVencimiento"]),
                    Precio = Convert.ToDecimal(row["Precio"]),
                    PrecioReserva = Convert.ToDecimal(row["Precio"]),
                    IdRubro = Convert.ToInt32(row["IdRubro"]),
                    IdUsuario = Convert.ToInt32(row["IdUsuario"]),
                    IdEstado = Convert.ToInt32(row["IdEstado"]),
                    Envio = Convert.ToBoolean(row["Envio"]),
                };

                publicacion.Visibilidad = GetVisibilidadPublicacion(publicacion.IdPublicacion, db);
                publicacion.TipoPublicacion = GetTipoPublicacion(publicacion.IdPublicacion, db);

                publicaciones.Add(publicacion);
            }

            return publicaciones;
        }

        private static Visibilidad GetVisibilidadPublicacion(int idPublicacion, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idPublicacionParameter = new SqlParameter("@IdPublicacion", SqlDbType.Decimal);
            idPublicacionParameter.Value = idPublicacion;

            parameters.Add(idPublicacionParameter);

            DataTable res = db.GetDataAsTable("SP_GetVisibilidadPublicacion", parameters);
            Visibilidad visibilidad = new Visibilidad();
            foreach (DataRow row in res.Rows)
            {
                visibilidad.IdVisibilidad = Convert.ToInt32(row["IdVisibilidad"]);
                visibilidad.Descripcion = Convert.ToString(row["Descripcion"]);
                visibilidad.Precio = Convert.ToDecimal(row["Precio"]);
                visibilidad.Porcentaje = Convert.ToDecimal(row["Porcentaje"]);
                visibilidad.EnvioPorcentaje = Convert.ToDecimal(row["EnvioPorcentaje"]);
            }

            return visibilidad;
        }

        private static TipoPublicacion GetTipoPublicacion(int idPublicacion, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idPublicacionParameter = new SqlParameter("@IdPublicacion", SqlDbType.Decimal);
            idPublicacionParameter.Value = idPublicacion;

            parameters.Add(idPublicacionParameter);

            DataTable res = db.GetDataAsTable("SP_GetTipoPublicacion", parameters);
            TipoPublicacion tipoPublicacion = new TipoPublicacion();
            foreach (DataRow row in res.Rows)
            {
                tipoPublicacion.IdTipo = Convert.ToInt32(row["IdTipo"]);
                tipoPublicacion.Descripcion = Convert.ToString(row["Descripcion"]);
                tipoPublicacion.Envio = Convert.ToBoolean(row["Envio"]);
            }

            return tipoPublicacion;
        }

        public static List<Publicacion> FindPublicaciones(string filtroDescripcion, List<Rubro> rubrosFiltro)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);
            SqlParameter filtroDescripcionParameter;

            List<SqlParameter> parameters = new List<SqlParameter>();

            filtroDescripcionParameter = new SqlParameter("@FiltroDescripcion", SqlDbType.NVarChar);
            filtroDescripcionParameter.Value = filtroDescripcion.Trim();

            parameters.Add(filtroDescripcionParameter);
            //TODO CREAR EL SP FINDPUBLICACIONES Y VER COMO MANDAR LA LISTA DE ID DE RUBROS PARA FILTRAR
            using (db.Connection)
            {
                DataTable res = db.GetDataAsTable("SP_FindPublicaciones", parameters);
                List<Publicacion> listPublicaciones = new List<Publicacion>();

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
                        PrecioReserva = Convert.ToDecimal(row["Precio"]),
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
                            Descripcion = Convert.ToString(row["DescripcionTipoPublicacion"])
                        }
                    };

                    listPublicaciones.Add(publicacion);
                }

                return listPublicaciones;
            }
        }
    }
}
