using System.Collections.Generic;
using MercadoEnvio.Entidades;

namespace MercadoEnvio.Servicios
{
    class TiposPublicacionServices
    {
        public static List<TipoPublicacion> GetAllData()
        {
            return DataManagers.DataManagerTipoPublicacion.GetAllData();
        }
    }
}
