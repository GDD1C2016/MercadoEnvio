using System.Collections.Generic;
using MercadoEnvio.Entidades;

namespace MercadoEnvio.Servicios
{
    public class RubrosServices
    {
        public static List<Rubro> GetAllData()
        {
            return DataManagers.DataManagerRubros.GetAllData();
        }

        public static List<Rubro> FindRubros(string filtroDescripcionCorta, string filtroDescripcionLarga)
        {
            return DataManagers.DataManagerRubros.FindRubros(filtroDescripcionCorta, filtroDescripcionLarga);
        }

        public static bool SaveNewRubro(Rubro rubro)
        {
            return DataManagers.DataManagerRubros.SaveNewRubro(rubro);
        }
    }
}
