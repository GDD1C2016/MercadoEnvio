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
        private int _idUsuario;
        private string _userName;
        private string _password;
        private int _cantIntFallidos;
        private bool _activo;
        private string _estado;
        private bool _loginSuccess;
        #endregion

        #region properties
        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
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

        public int CantIntFallidos
        {
            get { return _cantIntFallidos; }
            set { _cantIntFallidos = value; }
        }

        public bool Activo
        {
            get { return _activo; }
            
            set
            {
                Estado estado = new Estado { Valor = value };
                
                _activo = value;
                _estado = estado.Descripcion;
            }
        }

        public string Estado
        {
            get { return _estado; }
        }

        public bool LoginSuccess
        {
            get { return _loginSuccess; }
            set { _loginSuccess = value; }
        }
        #endregion
    }
}
