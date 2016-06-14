using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercadoEnvio.Entidades;

namespace MercadoEnvio.Servicios
{
    public class CalificacionesServices
    {
        public static List<Calificacion> GetUltimas(int cantidad)
        {
            return DataManagers.DataManagerCalificacion.GetUltimas(cantidad);
        }
    }
}
