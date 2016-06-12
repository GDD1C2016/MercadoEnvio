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

        public static string DeleteVisibilidad(Visibilidad visibilidadSeleccionada)
        {
            return DataManagers.DataManagerVisibilidad.DeleteVisibilidad(visibilidadSeleccionada);
        }

        public static void SaveNewVisibilidad(Visibilidad newVisibilidad)
        {
            DataManagers.DataManagerVisibilidad.SaveNewVisibilidad(newVisibilidad);
        }

        public static void UpdateVisibilidad(Visibilidad visibilidad)
        {
            DataManagers.DataManagerVisibilidad.UpdateVisibilidad(visibilidad);
        }

        public static Visibilidad GetVisibilidadByDescription(string descripcion)
        {
            return DataManagers.DataManagerVisibilidad.GetVisibilidadByDescripcion(descripcion);
        }
    }
}
