using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoEnvio.Entidades
{
    public class Compra
    {
        #region attributes
        private int _idCompra;
        private int _idPublicacion;
        private DateTime _fecha;
        private decimal _cantidad;
        private bool _estado;
        private int _idUsuario;
        private string _tipoPublicacion;
        private string _descripcionPublicacion;
        private string _vendedor;
        #endregion

        #region properties
        public int IdCompra
        {
            get { return _idCompra; }
            set { _idCompra = value; }
        }

        public int IdPublicacion
        {
            get { return _idPublicacion; }
            set { _idPublicacion = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public decimal Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public string TipoPublicacion
        {
            get { return _tipoPublicacion; }
            set { _tipoPublicacion = value; }
        }

        public string DescripcionPublicacion
        {
            get{return _descripcionPublicacion;}
            set { _descripcionPublicacion = value; }
        }

        public string Vendedor
        {
            get { return _vendedor; }
            set { _vendedor = value; }
        }
        #endregion
    }
}
