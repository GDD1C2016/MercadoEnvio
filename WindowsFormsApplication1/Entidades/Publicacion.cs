using System;

namespace MercadoEnvio.Entidades
{
    public class Publicacion
    {
        #region attributes
        private int _idPublicacion;
        private string _descripcion;
        private int _stock;
        private DateTime _fechaInicio;
        private DateTime _fechaVencimiento;
        private decimal _precio;
        private decimal _precioReserva;
        private int _idRubro;
        private string _rubroDescripcionCorta;
        private string _rubroDescripcionLarga;
        private int _idUsuario;
        private string _nombreUsuario;
        private int _idEstado;
        private string _estadoDescripcion;
        private bool _envio;
        private TipoPublicacion _tipoPublicacion;
        private Visibilidad _visibilidad;
        #endregion

        #region properties
        public int IdPublicacion
        {
            get { return _idPublicacion; }
            set { _idPublicacion = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        public DateTime FechaInicio
        {
            get { return _fechaInicio; }
            set { _fechaInicio = value; }
        }

        public DateTime FechaVencimiento
        {
            get { return _fechaVencimiento; }
            set { _fechaVencimiento = value; }
        }

        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public decimal PrecioReserva
        {
            get { return _precioReserva; }
            set { _precioReserva = value; }
        }

        public int IdRubro
        {
            get { return _idRubro; }
            set { _idRubro = value; }
        }

        public string RubroDescripcionCorta
        {
            get { return _rubroDescripcionCorta; }
            set { _rubroDescripcionCorta = value; }
        }

        public string RubroDescripcionLarga
        {
            get { return _rubroDescripcionLarga; }
            set { _rubroDescripcionLarga = value; }
        }

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public string NombreUsuario
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = value; }
        }

        public int IdEstado
        {
            get { return _idEstado; }
            set { _idEstado = value; }
        }

        public string EstadoDescripcion
        {
            get { return _estadoDescripcion; }
            set { _estadoDescripcion = value; }
        }

        public TipoPublicacion TipoPublicacion
        {
            get { return _tipoPublicacion; }
            set { _tipoPublicacion = value; }
        }

        public Visibilidad Visibilidad
        {
            get { return _visibilidad; }
            set { _visibilidad = value; }
        }

        public bool Envio
        {
            get { return _envio; }
            set { _envio = value; }
        }
        #endregion
    }
}
