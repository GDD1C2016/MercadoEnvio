using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MercadoEnvio.Entidades;

namespace MercadoEnvio.Servicios
{
    public class UsuarioService
    {
        public static Entidades.Login LoginUser(string user, string passWord)
        {
            Entidades.Login login = DataManagers.DataManagerUsuario.Login(user, passWord);
            return login;
        }
    }
}
