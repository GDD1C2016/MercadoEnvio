using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoEnvio.Entidades
{
    public class Usuario
    {
        #region attributes
        private bool _loginSuccess;
        private int _idUsuario;
        private byte _cantIntentos;
        private string _userName;
        private string _password;
        private string _estado;
        #endregion

        #region properties
        public bool LoginSuccess
        {
            get { return _loginSuccess; }
            set { _loginSuccess = value; }
        }

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public byte CantIntentos
        {
            get { return _cantIntentos; }
            set { _cantIntentos = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        #endregion
    }
}
