using System;

namespace MercadoEnvio.Entidades
{
    public class Cliente : Usuario
    {
        #region attributes

        private string _apellido;
        private string _nombre;
        private string _tipoDoc;
        private int _numeroDoc;
        private DateTime _fechaNacimiento;
        private int _cantidadProductosComprados;

        #endregion

        #region properties

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string TipoDoc
        {
            get { return _tipoDoc; }
            set { _tipoDoc = value; }
        }

        public int NumeroDoc
        {
            get { return _numeroDoc; }
            set { _numeroDoc = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        public int CantidadProductosComprados
        {
            get { return _cantidadProductosComprados; }
            set { _cantidadProductosComprados = value; }
        }

        #endregion
    }
}
