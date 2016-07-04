using System.Collections.Generic;
using MercadoEnvio.Entidades;

namespace MercadoEnvio.Servicios
{
    public class ActualizacionServices
    {
        public static void ConfigurarFechas()
        {
            DataManagers.DataManagerActualizacion.ConfigurarFechas();
        }

        public static void CerrarPublicaciones()
        {
            DataManagers.DataManagerActualizacion.CerrarPublicaciones();
        }

        public static List<Publicacion> PublicacionesACerrar()
        {
            return DataManagers.DataManagerActualizacion.PublicacionesACerrar();
        }
    }
}
