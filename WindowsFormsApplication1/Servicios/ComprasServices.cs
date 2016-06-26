using System.Collections.Generic;
using MercadoEnvio.Entidades;

namespace MercadoEnvio.Servicios
{
    public class ComprasServices
    {
        public static List<Publicacion> GetPendientesCalificar()
        {
            return DataManagers.DataManagerPublicaciones.GetPendientesCalificar();
        }

        public static List<Compra> GetComprasPendientesDeCalificacion(int idUsuario)
        {
            return DataManagers.DataManagerCompras.GetComprasPendientesDeCalificacion(idUsuario);
        }
    }
}
