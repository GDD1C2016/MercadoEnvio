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

        public static int CerrarPublicacion(int idPublicacion)
        {
            return DataManagers.DataManagerActualizacion.CerrarPublicacion(idPublicacion);
        }

        public static List<Publicacion> PublicacionesACerrar()
        {
            return DataManagers.DataManagerActualizacion.PublicacionesACerrar();
        }
    }
}
