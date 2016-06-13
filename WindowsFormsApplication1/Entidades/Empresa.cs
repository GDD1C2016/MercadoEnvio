namespace MercadoEnvio.Entidades
{
    public class Empresa : Usuario
    {
        #region attributes

        private string _razonSocial;
        private string _ciudad;
        private string _cuit;
        private string _contacto;
        private string _rubro;

        #endregion

        #region properties

        public string RazonSocial
        {
            get { return _razonSocial; }
            set { _razonSocial = value; }
        }

        public string Ciudad
        {
            get { return _ciudad; }
            set { _ciudad = value; }
        }

        public string Cuit
        {
            get { return _cuit; }
            set { _cuit = value; }
        }

        public string Contacto
        {
            get { return _contacto; }
            set { _contacto = value; }
        }

        public string Rubro
        {
            get { return _rubro; }
            set { _rubro = value; }
        }

        #endregion
    }
}
