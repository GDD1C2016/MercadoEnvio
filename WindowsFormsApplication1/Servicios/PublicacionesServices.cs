using System;
using System.Collections.Generic;
using MercadoEnvio.Entidades;

namespace MercadoEnvio.Servicios
{
    public class PublicacionesServices
    {
        public static List<Publicacion> GetAllData()
        {
            return DataManagers.DataManagerPublicaciones.GetAllData();
        }

        public static List<Publicacion> FindPublicaciones(string filtroDescripcion, List<Rubro> rubrosFiltro)
        {
            return DataManagers.DataManagerPublicaciones.FindPublicaciones(filtroDescripcion, rubrosFiltro);
        }

        public static int Ofertar(Publicacion publicacionSeleccionada, Usuario usuarioActivo, string monto)
        {
            return DataManagers.DataManagerPublicaciones.Ofertar(publicacionSeleccionada, usuarioActivo, monto);
        }

        public static int Comprar(Publicacion publicacionSeleccionada, Usuario usuarioActivo, string cantidad, bool envio)
        {
            return DataManagers.DataManagerPublicaciones.Comprar(publicacionSeleccionada, usuarioActivo, cantidad, envio);
        }

        public static List<EstadoPublicacion> GetEstados(string descripcionEstado)
        {
            return DataManagers.DataManagerPublicaciones.GetEstados(descripcionEstado);
        }

        public static Publicacion GetPublicacion(int idPublicacion, int idUsuario)
        {
            return DataManagers.DataManagerPublicaciones.GetPublicacion(idPublicacion, idUsuario);
        }

        public static void UpdatePublicacion(string idPublicacion, string descripcion, string stock, DateTime fechaInicio, DateTime fechaVencimiento, string precio, string precioReserva, int idRubro, int idEstado, int idTipo, bool envio, int idVisibilidad)
        {
            DataManagers.DataManagerPublicaciones.UpdatePublicacion(idPublicacion, descripcion, stock, fechaInicio, fechaVencimiento, precio, precioReserva, idRubro, idEstado, idTipo, envio, idVisibilidad);
        }

        public static int InsertPublicacion(string descripcion, string stock, DateTime fechaInicio, DateTime fechaVencimiento, string precio, string precioReserva, int idRubro, int idUsuario, int idEstado, int idTipo, bool envio, int idVisibilidad)
        {
            return DataManagers.DataManagerPublicaciones.InsertPublicacion(descripcion, stock, fechaInicio, fechaVencimiento, precio, precioReserva, idRubro, idUsuario, idEstado, idTipo, envio, idVisibilidad);
        }
    }
}
