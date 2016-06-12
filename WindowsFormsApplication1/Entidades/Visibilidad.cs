namespace MercadoEnvio.Entidades
{
    public class Visibilidad
    {
        #region attributes
        private int _idVisibilidad;
        private string _descripcion;
        private decimal _precio;
        private decimal _porcentaje;
        private decimal _envioPorcentaje;
        private bool _activa;
        private string _estado;
        #endregion

        #region properties
        public int IdVisibilidad
        {
            get { return _idVisibilidad; }
            set { _idVisibilidad = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public decimal Porcentaje
        {
            get { return _porcentaje; }
            set { _porcentaje = value; }
        }

        public decimal EnvioPorcentaje
        {
            get { return _envioPorcentaje; }
            set { _envioPorcentaje = value; }
        }

        public string Estado
        {
            get { return _estado; }
        }

        public bool Activa
        {
            get { return _activa; }

            set
            {
                Estado estado = new Estado { Valor = value };

                _activa = value;
                _estado = estado.Descripcion;
            }
        }
        #endregion
    }
}
