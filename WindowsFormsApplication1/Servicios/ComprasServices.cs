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

        public static List<Factura> GetFacturas()
        {
            return DataManagers.DataManagerCompras.GetFacturas();
        }

        public static List<Factura> FindFacturas(DateTime filtroFechaDesde, DateTime filtroFechaHasta, decimal filtroImporteDesde, decimal filtroImporteHasta, string filtroDetallesFactura, string filtroDirigidaA)
        {
            return DataManagers.DataManagerCompras.FindFacturas(filtroFechaDesde,filtroFechaHasta, filtroImporteDesde, filtroImporteHasta, filtroDetallesFactura, filtroDirigidaA);
        }
    }
}
