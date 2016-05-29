using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercadoEnvio.Entidades;

namespace MercadoEnvio.Servicios
{
    public class RolerServices
    {
        public static DataTable GetAllData()
        {
            return DataManagers.DataManagerRoles.GetAllData();
        }

        public static List<Funcionalidad> GetAllFuncionalidades()
        {
            return DataManagers.DataManagerRoles.GetAllFuncionalidades();
        }
    }
}
