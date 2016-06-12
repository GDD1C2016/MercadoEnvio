using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
using MercadoEnvio.Properties;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.ABM_Visibilidad
{
    public partial class AltaVisibilidad : Form
    {
        #region properties
        public Visibilidad Visibilidad { get; set; }
        #endregion

        public AltaVisibilidad(Visibilidad visibilidad)
        {
            InitializeComponent();

            Visibilidad = visibilidad;

            TxtDescripcion.Text = Visibilidad.Descripcion;
            TxtPrecio.Text = Visibilidad.Precio.ToString();
            TxtEnvioPorcentaje.Text = Visibilidad.EnvioPorcentaje.ToString();
            TxtPorcentaje.Text = Visibilidad.Porcentaje.ToString();

            #region armadoComboEstado
            Estado estadoHabilitado = new Estado { Valor = true };
            Estado estadoDeshabilitado = new Estado { Valor = false };
            List<Estado> estados = new List<Estado>();
            estados.Add(estadoHabilitado);
            estados.Add(estadoDeshabilitado);

            ComboEstado.DataSource = estados;
            ComboEstado.DisplayMember = "Descripcion";
            ComboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboEstado.SelectedItem = Visibilidad.Activa;
            #endregion

        }

        private void TxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != decimalSeparator))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == decimalSeparator) && ((sender as TextBox).Text.IndexOf(decimalSeparator) > -1))
            {
                e.Handled = true;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            List<string> errors = new List<string>(ValidarDatosVisibilidad());

            if (errors.Count > 0)
            {
                var message = string.Join(Environment.NewLine, errors);
                MessageBox.Show(message, Resources.ErrorGuardado, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var visibilidad = new Visibilidad
                {
                    Descripcion = TxtDescripcion.Text.Trim(),
                    Activa = ((Estado)ComboEstado.SelectedItem).Valor,
                    EnvioPorcentaje = Convert.ToDecimal(TxtEnvioPorcentaje.Text.Trim()),
                    Porcentaje = Convert.ToDecimal(TxtPorcentaje.Text.Trim()),
                    Precio = Convert.ToDecimal(TxtPrecio.Text.Trim()),
                };

                if (Visibilidad.IdVisibilidad == 0)
                {
                    VisibilidadServices.SaveNewVisibilidad(visibilidad);

                    MessageBox.Show(Resources.VisibilidadCreada, Resources.MercadoEnvio, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    visibilidad.IdVisibilidad = Visibilidad.IdVisibilidad;

                    VisibilidadServices.UpdateVisibilidad(visibilidad);

                    MessageBox.Show(Resources.VisibilidadActualizada, Resources.MercadoEnvio, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private List<string> ValidarDatosVisibilidad()
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrEmpty(TxtDescripcion.Text))
                errors.Add(Resources.ErrorDescripcionVacia);

            Visibilidad visibilidad = VisibilidadServices.GetVisibilidadByDescription(TxtDescripcion.Text);
            if (visibilidad.IdVisibilidad != 0 || visibilidad.IdVisibilidad != Visibilidad.IdVisibilidad)
                errors.Add(Resources.ErrorRolExistente);

            return errors;
        }

    }
}
