using System;
using System.Collections.Generic;
using MercadoEnvio.Entidades;

namespace MercadoEnvio.Servicios
{
    public class ComprasServices
    {
        public static List<Compra> GetComprasPendientesDeCalificacion(int idUsuario)
        {
            return DataManagers.DataManagerCompras.GetComprasPendientesDeCalificacion(idUsuario);
        }

        public static List<Factura> GetFacturas(int idUsuario)
        {
            return DataManagers.DataManagerCompras.GetFacturas(idUsuario);
        }

        public static List<Factura> FindFacturas(DateTime filtroFechaDesde, DateTime filtroFechaHasta, decimal filtroImporteDesde, decimal filtroImporteHasta, string filtroDetallesFactura, string filtroDirigidaA, int idUsuario)
        {
            return DataManagers.DataManagerCompras.FindFacturas(filtroFechaDesde,filtroFechaHasta, filtroImporteDesde, filtroImporteHasta, filtroDetallesFactura, filtroDirigidaA, idUsuario);
        }

        public static List<string> FindDetallesFactura()
        {
            return DataManagers.DataManagerCompras.FindDetallesFactura();
        }

        public static List<Compra> GetComprasOfertas(int idUsuario)
        {
            return DataManagers.DataManagerCompras.GetComprasOfertas(idUsuario);
        }
    }
}
