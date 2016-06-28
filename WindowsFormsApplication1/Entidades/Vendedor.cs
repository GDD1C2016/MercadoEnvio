using System.Runtime.InteropServices;
using System.Xml.Schema;

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
        private string _nombreUsuario;
        private int _idFactura;
        private string _visibilidadDescripcion;

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

        public string NombreUsuario
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = value; }
        }

        public int IdFactura
        {
            get { return _idFactura; }
            set { _idFactura = value; }
        }

        public string VisibilidadDescripcion
        {
            get { return _visibilidadDescripcion; }
            set { _visibilidadDescripcion = value; }
        }

        #endregion
    }
}
