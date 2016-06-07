//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using MercadoEnvio.Entidades;

namespace MercadoEnvio.Servicios
{
    public class UsuarioService
    {
        public static Entidades.Login LoginUser(string userName, string password)
        {
            Entidades.Login login = DataManagers.DataManagerUsuario.Login(userName, password);
            return login;
        }
    }
}
