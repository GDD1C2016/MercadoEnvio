using System;
using System.Collections.Generic;
using System.Linq;
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
            Calificacion calificacion = new Calificacion
            {
                CantEstrellas = (int)ComboEstrellas.SelectedItem,
                Observaciones = RichTextBoxObservaciones.Text,
                IdCompra = CompraSeleccionada.IdCompra
            };

            CalificacionesServices.InsertNewCalificacion(calificacion);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
