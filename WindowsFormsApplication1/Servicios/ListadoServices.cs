﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercadoEnvio.Entidades;

namespace MercadoEnvio.Servicios
{
    public class ListadoServices
    {
        public static List<Vendedor> GetListadoVendedoresProductosNoVendidos(int trimestre, int anio)
        {
            return DataManagers.DataManagerListados.GetListadoVendedoresProductosNoVendidos(trimestre,anio);
        }

        public static List<Cliente> GetListadoClientesProductosComprados(int trimestre, int anio, Rubro rubro)
        {
            return DataManagers.DataManagerListados.GetListadoClientesProductosComprados(trimestre, anio, rubro);
        }

        public static List<Vendedor> GetListadoVendedoresFacturas(int trimestre, int anio)
        {
            return DataManagers.DataManagerListados.GetListadoVendedoresFacturas(trimestre, anio);
        }

        public static List<Vendedor> GetListadoVendedoresMontos(int trimestre, int anio)
        {
            return DataManagers.DataManagerListados.GetListadoVendedoresMontos(trimestre, anio);
        }
    }
}