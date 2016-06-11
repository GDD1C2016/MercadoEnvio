using System.Collections.Generic;
using MercadoEnvio.Entidades;

namespace MercadoEnvio.Servicios
{
    public class VisibilidadServices
    {
        public static List<Visibilidad> GetAllData()
        {
            return DataManagers.DataManagerVisibilidad.GetAllData();
        }

        public static List<Visibilidad> FindVisibilidades(string filtroDescripcion)
        {
            return DataManagers.DataManagerVisibilidad.FindVisibilidades(filtroDescripcion);
        }

        public static List<Visibilidad> DeleteVisibilidad(Visibilidad visibilidadSeleccionada)
        {
            return DataManagers.DataManagerVisibilidad.DeleteVisibilidad(visibilidadSeleccionada);
        }
    }
}
