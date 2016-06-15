using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoEnvio.Entidades
{
    public class Factura
    {
        #region attributes

        private decimal _idFactura;
        private decimal _idPublicacion;
        private DateTime _fecha;
        private decimal _total;
        private int _idFormaDePago;

        #endregion

        #region properties

        public decimal IdFactura
        {
            get { return _idFactura; }
            set { _idFactura = value; }
        }

        public decimal IdPublicacion
        {
            get { return _idPublicacion; }
            set { _idPublicacion = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }

        public int IdFormaDePago
        {
            get { return _idFormaDePago; }
            set { _idFormaDePago = value; }
        }

        #endregion
    }
}
