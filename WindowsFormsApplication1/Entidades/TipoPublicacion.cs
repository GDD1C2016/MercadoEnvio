using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace MercadoEnvio.Entidades
{
    public class TipoPublicacion
    {
        #region attributes
        private int _idTipo;
        private string _descripcion;
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
        #endregion
    }
}
