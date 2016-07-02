using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
using MercadoEnvio.Properties;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.ComprarOfertar
{
    public partial class ComprarDialog : Form
    {
        public Publicacion PublicacionSeleccionada { get; set; }
        public Usuario UsuarioActivo { get; set; }

        public ComprarDialog()
        {
            InitializeComponent();
        }

        private void ComprarDialog_Load(object sender, EventArgs e)
        {
            ArmarFormularioSegunTipo();
            LlenarFormularioSegunTipo();

            #region armadoDatosVendedor
            
            Cliente cliente = UsuariosService.GetClienteById(PublicacionSeleccionada.IdUsuario);

            LabelNombreTxt.Text = cliente.Nombre;
            LabelEmailTxt.Text = cliente.Email;
            LabelReputacionTxt.Text = Math.Round(cliente.Reputacion, 2, MidpointRounding.AwayFromZero).ToString();
            LabelTelefonoTxt.Text = cliente.Telefono;

            if (cliente.IdUsuario == 0)
            {
                Empresa empresa = new Empresa();
                empresa = UsuariosService.GetEmpresaById(PublicacionSeleccionada.IdUsuario);

                LabelNombreTxt.Text = empresa.RazonSocial;
                LabelEmailTxt.Text = empresa.Email;
                LabelReputacionTxt.Text = Math.Round(empresa.Reputacion, 2, MidpointRounding.AwayFromZero).ToString();
                LabelTelefonoTxt.Text = empresa.Telefono;
            }

            #endregion
        }

        private void ArmarFormularioSegunTipo()
        {
            CheckBoxEnvio.Enabled = PublicacionSeleccionada.Envio;
            if (PublicacionSeleccionada.TipoPublicacion.Descripcion.Equals(Resources.CompraInmediata, StringComparison.CurrentCultureIgnoreCase))
            {
                LabelCantidad.Text = Resources.Cantidad;
                LabelCantidad.Visible = true;
                CheckBoxEnvio.Visible = true;
                GroupBoxDetalles.Text = Resources.DetallesDeCompra;
                Text = Resources.Compra;
                LabelPrecioReservaNum.Visible = false;
                LabelPrecioReservaText.Visible = false;
                TxtCantidad.Visible = true;
                TxtOfertar.Visible = false;
            }
            else
            {
                LabelCantidad.Text = Resources.Monto;
                LabelCantidad.Visible = true;
                CheckBoxEnvio.Visible = false;
                GroupBoxDetalles.Text = Resources.DetallesSubasta;
                Text = Resources.Subasta;
                LabelPrecioReservaNum.Visible = true;
                LabelPrecioReservaText.Visible = true;
                TxtCantidad.Visible = false;
                TxtOfertar.Visible = true;
            }
        }

        private void LlenarFormularioSegunTipo()
        {
            if (PublicacionSeleccionada.TipoPublicacion.Descripcion.Equals(Resources.Compra, StringComparison.CurrentCultureIgnoreCase))
                CheckBoxEnvio.Checked = PublicacionSeleccionada.Envio;
            else
                LabelPrecioReservaNum.Text = PublicacionSeleccionada.PrecioReserva.ToString(CultureInfo.CurrentCulture);
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtOfertar_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != decimalSeparator))
                e.Handled = true;

            if ((e.KeyChar == decimalSeparator) && ((sender as TextBox).Text.IndexOf(decimalSeparator) > -1))
                e.Handled = true;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            List<string> errors = ValidarDatos();

            if (errors.Count > 0)
            {
                var message = string.Join(Environment.NewLine, errors);
                MessageBox.Show(message, Resources.ErrorEnLaOperacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                var numero = String.Empty;

                if (PublicacionSeleccionada.TipoPublicacion.Descripcion.Equals(Resources.Subasta,
                    StringComparison.CurrentCultureIgnoreCase))
                {
                    PublicacionesServices.Ofertar(PublicacionSeleccionada, UsuarioActivo, TxtOfertar.Text);
                    MessageBox.Show(Resources.NroOferta + numero, Resources.OperacionExitosa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    PublicacionesServices.Comprar(PublicacionSeleccionada, UsuarioActivo, TxtCantidad.Text, CheckBoxEnvio.Checked);
                    MessageBox.Show(Resources.NroCompra + numero, Resources.OperacionExitosa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DialogResult = DialogResult.OK;                    
                }
            }
        }

        private List<string> ValidarDatos()
        {
            List<string> errors = new List<string>();

            if (PublicacionSeleccionada.IdUsuario == UsuarioActivo.IdUsuario)
                errors.Add(Resources.ErrorUsuarioCompraSuPublicacion);

            if (PublicacionSeleccionada.TipoPublicacion.Descripcion.Equals(Resources.CompraInmediata, StringComparison.CurrentCultureIgnoreCase))
            {
                var cantidad = string.IsNullOrEmpty(TxtCantidad.Text) ? 0 : Convert.ToInt32(TxtCantidad.Text);

                if (cantidad > PublicacionSeleccionada.Stock)
                    errors.Add(Resources.ErrorStock);
            }
            else
            {
                var oferta = Convert.ToInt32(TxtOfertar.Text);

                if (oferta < PublicacionSeleccionada.Precio)
                    errors.Add(Resources.ErrorOferta);
            }
            return errors;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
