namespace MercadoEnvio.Entidades
{
    public class Vendedor
    {
        #region attributes

        private int _idUsuario;
        private string _descripcion;
        private string _documento;
        private int _cantidad;
        private decimal _montoFacturado;

        #endregion

        #region properties

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public string Documento
        {
            get { return _documento; }
            set { _documento = value; }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public decimal MontoFacturado
        {
            get { return _montoFacturado; }
            set { _montoFacturado = value; }
        }
        #endregion
    }
}
