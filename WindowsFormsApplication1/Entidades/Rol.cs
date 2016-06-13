using System;
using System.Collections.Generic;

namespace MercadoEnvio.Entidades
{
    public class Rol
    {
        #region attributes
        private int _idRol;
        private string _descripcion;
        private bool _activo;
        private string _estado;
        private List<Funcionalidad> _funcionalidades;
        #endregion

        #region properties
        public int IdRol
        {
            get { return _idRol; }
            set { _idRol = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
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

        public List<Funcionalidad> Funcionalidades
        {
            get { return _funcionalidades; }
            set { _funcionalidades = value; }
        }
        #endregion

        #region constructor
        public Rol()
        {
            Funcionalidades = new List<Funcionalidad>();
        }
        #endregion

        #region methods
        public bool IsClienteOEmpresa()
        {
            return Descripcion.Equals("Cliente", StringComparison.CurrentCultureIgnoreCase) || Descripcion.Equals("Empresa", StringComparison.CurrentCultureIgnoreCase);
        }
        #endregion
    }
}
