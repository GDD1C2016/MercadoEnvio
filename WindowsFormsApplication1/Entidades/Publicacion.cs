using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoEnvio.Entidades
{
    public class Publicacion
    {
        #region attributes
        private int _idPublicacion;
        private int _codPublicacion;
        private string _descripcion;
        private int _stock;
        private DateTime _fechaInicio;
        private DateTime _fechaVencimiento;
        private decimal _precio;
        private int _idRubro;
        private int _idUsuario;
        private int _idEstado;
        private int _idTipo;
        #endregion

        #region properties
        public int IdPublicacion
        {
            get { return _idPublicacion; }
            set { _idPublicacion = value; }
        }

        public int CodigoPublicacion
        {
            get { return _codPublicacion; }
            set { _codPublicacion = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        public DateTime FechaInicio
        {
            get { return _fechaInicio; }
            set { _fechaInicio = value; }
        }

        public DateTime FechaVencimiento
        {
            get { return _fechaVencimiento; }
            set { _fechaVencimiento = value; }
        }

        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public int IdRubro
        {
            get { return _idRubro; }
            set { _idRubro = value; }
        }

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public int IdEstado
        {
            get { return _idEstado; }
            set { _idEstado = value; }
        }

        public int IdTipo
        {
            get { return _idTipo; }
            set { _idTipo = value; }
        }
        #endregion
    }
}
