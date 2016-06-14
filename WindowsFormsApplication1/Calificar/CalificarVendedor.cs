using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.Calificar
{
    public partial class CalificarVendedor : Form
    {
        public Publicacion PublicacionSeleccionada { get; set; }
        public CalificarVendedor()
        {
            InitializeComponent();
        }

        private void CalificarVendedor_Load(object sender, EventArgs e)
        {
            #region cargarDatosVendedor
            LabelArticuloText.Text = PublicacionSeleccionada.Descripcion;
            //LabelVendedorText.Text = PublicacionesServices.GetVendedorById(PublicacionSeleccionada.IdUsuario); //TODO HACER METODO PARA OBTENER EL NOMBRE DEL VENDEDOR
            #endregion

            #region llenadoComboEstrellas
            List<int> valores = new List<int>(Enumerable.Range(1, 5));
            ComboEstrellas.DataSource = valores;
            ComboEstrellas.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}
