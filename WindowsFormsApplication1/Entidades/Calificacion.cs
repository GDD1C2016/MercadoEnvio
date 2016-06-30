namespace MercadoEnvio.Entidades
{
    public class Calificacion
    {
        #region attributes
        private decimal _idCalificacion;
        private string _observaciones;
        private decimal _cantEstrellas;
        private int _idCompra;
        private string _descripcionCompra;
        #endregion

        #region properties
        public int IdCompra
        {
            get { return _idCompra; }
            set { _idCompra = value; }
        }

        public decimal IdCalificacion
        {
            get { return _idCalificacion; }
            set { _idCalificacion = value; }
        }

        public string DescripcionCompra
        {
            get { return _descripcionCompra;}
            set { _descripcionCompra = value; }
        }

        public decimal CantEstrellas
        {
            get { return _cantEstrellas; }
            set { _cantEstrellas = value; }
        }

        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }
        #endregion
    }
}
