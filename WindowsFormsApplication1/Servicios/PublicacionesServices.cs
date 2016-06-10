//using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using MercadoEnvio.Entidades;

namespace MercadoEnvio.Servicios
{
    public class PublicacionesServices
    {
        public static List<Publicacion> GetAllData()
        {
            return DataManagers.DataManagerPublicaciones.GetAllData();
        }

        public static List<Publicacion> FindPublicaciones(string filtroDescripcion, List<Rubro> rubrosFiltro)
        {
            return DataManagers.DataManagerPublicaciones.FindPublicaciones(filtroDescripcion, rubrosFiltro);
        }
    }
}
