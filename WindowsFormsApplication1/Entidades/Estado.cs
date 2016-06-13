namespace MercadoEnvio.Entidades
{
    public class Estado
    {
        #region attributes
        private string _descripcion;
        private bool _valor;
        #endregion

        #region properties
        public string Descripcion
        {
            get { return _descripcion; }

            set
            {
                _descripcion = value;

                switch (value)
                {
                    case "Habilitado":
                        _valor = true;
                        break;
                    case "Deshabilitado":
                        _valor = false;
                        break;
                }
            }
        }

        public bool Valor
        {
            get { return _valor; }

            set
            {
                _valor = value;

                if (value)
                    _descripcion = "Habilitado";
                else
                    _descripcion = "Deshabilitado";
            }
        }
        #endregion

        #region methods
        public bool EstadoValido()
        {
            return Descripcion == "Habilitado" || Descripcion == "Deshabilitado";
        }
        #endregion
    }
}
