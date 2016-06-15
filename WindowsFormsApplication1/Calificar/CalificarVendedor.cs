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
        public Compra CompraSeleccionada { get; set; }
        public CalificarVendedor()
        {
            InitializeComponent();
        }

        private void CalificarVendedor_Load(object sender, EventArgs e)
        {
            #region cargarDatosVendedor
            LabelArticuloText.Text = CompraSeleccionada.DescripcionPublicacion;
            LabelVendedorText.Text = CompraSeleccionada.Vendedor;
            #endregion

            #region llenadoComboEstrellas
            List<int> valores = new List<int>(Enumerable.Range(1, 5));
            ComboEstrellas.DataSource = valores;
            ComboEstrellas.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Calificacion calificacion = new Calificacion();
            calificacion.CantEstrellas = ((int) ComboEstrellas.SelectedItem);
            calificacion.Observaciones = RichTextBoxObservaciones.Text;
            calificacion.IdCompra = CompraSeleccionada.IdCompra;

            CalificacionesServices.InsertNewCalificacion(calificacion);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
