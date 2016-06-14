using System.Collections.Generic;

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
        private string _email;
        private string _telefono;
        private string _calle;
        private int _nroCalle;
        private int _piso;
        private string _departamento;
        private string _localidad;
        private string _codigoPostal;

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

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string Calle
        {
            get { return _calle; }
            set { _calle = value; }
        }

        public int NroCalle
        {
            get { return _nroCalle; }
            set { _nroCalle = value; }
        }

        public int Piso
        {
            get { return _piso; }
            set { _piso = value; }
        }

        public string Departamento
        {
            get { return _departamento; }
            set { _departamento = value; }
        }

        public string Localidad
        {
            get { return _localidad; }
            set { _localidad = value; }
        }

        public string CodigoPostal
        {
            get { return _codigoPostal; }
            set { _codigoPostal = value; }
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

        public List<Rol> Roles { get; set; }

        #endregion

        #region constructor
        public Usuario()
        {
            Roles = new List<Rol>();
        }
        #endregion
    }
}
