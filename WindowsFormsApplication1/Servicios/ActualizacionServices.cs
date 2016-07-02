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
    }
}
