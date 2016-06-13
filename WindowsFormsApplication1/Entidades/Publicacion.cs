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
        private int _idUsuario;
        private int _idEstado;
        private int _idTipo;
        private bool _envio;
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

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public int IdEstado
        {
            get { return _idEstado; }
            set { _idEstado = value; }
        }

        public int IdTipo
        {
            get { return _idTipo; }
            set { _idTipo = value; }
        }

        public bool Envio
        {
            get { return _envio; }
            set { _envio = value; }
        }

        public Visibilidad Visibilidad
        {
            get { return _visibilidad; }
            set { _visibilidad = value; }
        }
        #endregion
    }
}
