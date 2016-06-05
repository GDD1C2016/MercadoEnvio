using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoEnvio.Entidades
{
    public class Rubro
    {
        #region attributes
        private int _idRubro;
        private string _descripcionCorta;
        private string _descripcionLarga;
        #endregion

        #region properties
        public int IdRubro
        {
            get { return _idRubro; }
            set { _idRubro = value; }
        }

        public string DescripcionCorta
        {
            get { return _descripcionCorta; }
            set { _descripcionCorta = value; }
        }

        public string DescripcionLarga
        {
            get { return _descripcionLarga; }
            set { _descripcionLarga = value; }
        }
        #endregion
    }
}
