using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoEnvio.Servicios
{
    public class ActualizacionServices
    {
        public static void ConfigurarFechas()
        {
            DataManagers.DataManagerActualizacion.ConfigurarFechas();
        }

        public static void CerrarSubastas()
        {
            DataManagers.DataManagerActualizacion.CerrarSubastas();
        }
    }
}
