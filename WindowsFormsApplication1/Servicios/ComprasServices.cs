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
    }
}
