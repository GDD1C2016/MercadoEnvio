﻿using System;
using System.Runtime.Versioning;
using MercadoEnvio.Properties;

//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace MercadoEnvio.Entidades
{
    public class Funcionalidad
    {
        #region attributes
        private int _idFuncionalidad;
        private string _descripcion;
        #endregion

        #region properties
        public int IdFuncionalidad
        {
            get { return _idFuncionalidad; }
            set { _idFuncionalidad = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        #endregion

        #region methods
        public bool IsLoginSeguridad()
        {
            return Descripcion.Equals(Resources.LoginSeguridad, StringComparison.CurrentCultureIgnoreCase);
        }
        #endregion
    }
}
