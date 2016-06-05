using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercadoEnvio.Entidades;

namespace MercadoEnvio.Servicios
{
    public class RubrosServices
    {
        public static List<Rubro> GetAllData()
        {
            return DataManagers.DataManagerRubros.GetAllData();
        }
    }
}
