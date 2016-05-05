using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoEnvio.Entidades
{
    public class Login
    {
        #region attributes
        private bool _loginSuccess;
        private bool _multiProfile;
        private int _idUsuario;
        private int _idRol;
        #endregion

        #region properties
        public bool LoginSuccess
        {
            get { return _loginSuccess; }
            set { _loginSuccess = value; }
        }

        public bool MultiProfile
        {
            get { return _multiProfile; }
            set { _multiProfile = value; }
        }

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public int IdRol
        {
            get { return _idRol; }
            set { _idRol = value; }
        }
        #endregion
    }
}
