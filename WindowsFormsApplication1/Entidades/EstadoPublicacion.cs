namespace MercadoEnvio.Entidades
{
    public class EstadoPublicacion
    {
        #region attributes
        private int _idEstado;
        private string _descripcion;
        #endregion

        #region properties
        public int IdEstado
        {
            get { return _idEstado; }
            set { _idEstado = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        #endregion
    }
}
