using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercadoEnvio.Entidades;

namespace MercadoEnvio.Servicios
{
    public class ComprasServices
    {
        public static List<Publicacion> GetPendientesCalificar()
        {
            return DataManagers.DataManagerPublicaciones.GetPendientesCalificar();
        }

        public static List<Compra> GetAllData()
        {
            return DataManagers.DataManagerCompras.GetAllData();
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
