//using System;
using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using MercadoEnvio.Entidades;

namespace MercadoEnvio.Servicios
{
    public class RolesServices
    {
        public static List<Rol> GetAllData()
        {
            return DataManagers.DataManagerRoles.GetAllData();
        }

        public static List<Funcionalidad> GetAllFuncionalidades()
        {
            return DataManagers.DataManagerRoles.GetAllFuncionalidades();
        }

        public static List<Rol> FindRoles(string filtroNombre, int filtroFuncionalidad, string filtroEstado)
        {
            return DataManagers.DataManagerRoles.FindRoles(filtroNombre, filtroFuncionalidad, filtroEstado);
        }

        public static Rol GetRolByDescription(string descripcion)
        {
            return DataManagers.DataManagerRoles.GetRolByDescripcion(descripcion);
        }

        public static void SaveNewRol(Rol newRol)
        {
            DataManagers.DataManagerRoles.SaveNewRol(newRol);
        }

        public static string DeleteRol(Rol rol)
        {
            return DataManagers.DataManagerRoles.DeleteRol(rol);
        }

        public static void UpdateRol(Rol rol)
        {
            DataManagers.DataManagerRoles.UpdateRol(rol);
        }
    }
}
