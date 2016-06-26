using System.Collections.Generic;
using MercadoEnvio.Entidades;

namespace MercadoEnvio.Servicios
{
    public class CalificacionesServices
    {
        public static List<Calificacion> GetUltimas(int idUsuario, int cantidad)
        {
            return DataManagers.DataManagerCalificacion.GetUltimas(idUsuario, cantidad);
        }

        public static int GetCantidadCalificacionesDadas(int cantidadDeEstrellas, int idUsuario)
        {
            return DataManagers.DataManagerCalificacion.GetCantidadCalificacionesDadas(cantidadDeEstrellas, idUsuario);
        }

        public static void InsertNewCalificacion(Calificacion calificacion)
        {
            DataManagers.DataManagerCalificacion.InsertNewCalificacion(calificacion);
        }
    }
}
