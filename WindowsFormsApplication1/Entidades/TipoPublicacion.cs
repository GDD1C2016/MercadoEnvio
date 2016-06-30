namespace MercadoEnvio.Entidades
{
    public class TipoPublicacion
    {
        #region attributes
        private int _idTipo;
        private string _descripcion;
        private bool _envio;
        #endregion

        #region properties
        public int IdTipo
        {
            get { return _idTipo; }
            set { _idTipo = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public bool Envio
        {
            get { return _envio; }
            set { _envio = value; }
        }
        #endregion
    }
}
