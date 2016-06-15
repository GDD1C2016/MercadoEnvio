using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
using MercadoEnvio.Properties;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.Listado_Estadistico
{
    public partial class MainListado : Form
    {
        List<string> tipos = new List<string>();
        public MainListado()
        {
            InitializeComponent();
        }

        private void MainListado_Load(object sender, EventArgs e)
        {
            #region cargarComboTrimestre
            List<int> valores = new List<int>(Enumerable.Range(1, 4));
            ComboTrimestres.DataSource = valores;
            ComboTrimestres.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion

            #region cargarComboTipoListado
            tipos.Add(Resources.TipoListadoVendedoresProductosNoVendidos);
            tipos.Add(Resources.TipoListadoClientesMasProductos);
            tipos.Add(Resources.TipoListadoVendedoresMasFacturas);
            tipos.Add(Resources.TipoListadoVendedoresMasMonto);
            ComboTipo.DataSource = tipos;
            ComboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion

            #region cargarComboRubro
            List<Rubro> rubros = new List<Rubro>(RubrosServices.GetAllData());
            ComboRubro.DataSource = rubros;
            ComboRubro.DisplayMember = "DescripcionCorta";
            ComboRubro.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            List<string> errors = new List<string>(ValidarDatosListado());

            if (errors.Count > 0)
            {
                var message = string.Join(Environment.NewLine, errors);
                MessageBox.Show(message, Resources.ErrorDeDatos, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                string tipoSeleccionado = ComboTipo.SelectedItem as string;

                if (tipoSeleccionado.Equals(Resources.TipoListadoVendedoresProductosNoVendidos,StringComparison.CurrentCultureIgnoreCase))
                {
                    var listadoDialog = new ListadoNoVendidos();
                    listadoDialog.Trimestre = (int) ComboTrimestres.SelectedItem;
                    listadoDialog.Anio = Convert.ToInt32(TxtAnio.Text);
                    listadoDialog.ShowDialog();
                }
                else if (tipoSeleccionado.Equals(Resources.TipoListadoClientesMasProductos,StringComparison.CurrentCultureIgnoreCase))
                {
                    var listadoDialog = new ListadoComprados();
                    listadoDialog.Trimestre = (int)ComboTrimestres.SelectedItem;
                    listadoDialog.Anio = Convert.ToInt32(TxtAnio.Text);
                    listadoDialog.Rubro = (Rubro) ComboRubro.SelectedItem;
                    listadoDialog.ShowDialog();
                }
                else if (tipoSeleccionado.Equals(Resources.TipoListadoVendedoresMasFacturas,StringComparison.CurrentCultureIgnoreCase))
                {
                    var listadoDialog = new ListadoFacturas();
                    listadoDialog.Trimestre = (int)ComboTrimestres.SelectedItem;
                    listadoDialog.Anio = Convert.ToInt32(TxtAnio.Text);
                    listadoDialog.ShowDialog();
                }
                else if (tipoSeleccionado.Equals(Resources.TipoListadoVendedoresMasMonto,StringComparison.CurrentCultureIgnoreCase))
                {
                    var listadoDialog = new ListadoMontos();
                    listadoDialog.Trimestre = (int)ComboTrimestres.SelectedItem;
                    listadoDialog.Anio = Convert.ToInt32(TxtAnio.Text);
                    listadoDialog.ShowDialog();
                }
            }
        }

        private List<string> ValidarDatosListado()
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrEmpty(TxtAnio.Text))
                errors.Add(Resources.ErrorAnio);

            return errors;
        }

        private void TxtAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ComboTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string tipoSeleccionado = ComboTipo.SelectedItem as string;
            if (tipoSeleccionado.Equals(Resources.TipoListadoClientesMasProductos,StringComparison.CurrentCultureIgnoreCase))
            {
                LabelRubro.Visible = true;
                ComboRubro.Visible = true;
            }
            else
            {
                LabelRubro.Visible = false;
                ComboRubro.Visible = false;
            }
        }
    }
}
