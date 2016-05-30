using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoEnvio.Entidades
{
    public class Rol
    {
        #region attributes
        private int _idRol;
        private string _descripcion;
        private string _estado;
        private List<Funcionalidad> _funcionalidades; 
        #endregion

        #region properties
        public int IdRol
        {
            get { return _idRol; }
            set { _idRol = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public List<Funcionalidad> Funcionalidades
        {
            get { return _funcionalidades; }
            set { _funcionalidades = value; }
        }
        #endregion

        #region constructor

        public Rol() 
        {
            Funcionalidades = new List<Funcionalidad>();
        }

        #endregion
    }
}
