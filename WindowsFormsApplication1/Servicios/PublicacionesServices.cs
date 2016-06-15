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
    }
}
