using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
using MercadoEnvio.Properties;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.Listado_Estadistico
{
    public partial class MainListado : Form
    {
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
            List<string> tipos = new List<string>
            {
                Resources.TipoListadoVendedoresProductosNoVendidos,
                Resources.TipoListadoClientesMasProductos,
                Resources.TipoListadoVendedoresMasFacturas,
                Resources.TipoListadoVendedoresMasMonto
            };
            ComboTipo.DataSource = tipos;
            ComboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion

            #region cargarComboVisibilidades
            LabelRubro.Visible = true;
            LabelRubro.Text = "Visibilidad";
            ComboRubro.Visible = true;
            
            Visibilidad visibilidadTodos = new Visibilidad(){IdVisibilidad = 0, Descripcion = "--Todos--"};
            List<Visibilidad> visibilidades = new List<Visibilidad>();
            visibilidades.Add(visibilidadTodos);

            visibilidades.AddRange(VisibilidadServices.GetAllData());

            ComboRubro.DataSource = visibilidades;
            ComboRubro.DisplayMember = "Descripcion";
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

                if (tipoSeleccionado == null) return;

                if (tipoSeleccionado.Equals(Resources.TipoListadoVendedoresProductosNoVendidos, StringComparison.CurrentCultureIgnoreCase))
                {
                    var listadoDialog = new ListadoNoVendidos
                    {
                        Trimestre = (int) ComboTrimestres.SelectedItem,
                        Anio = Convert.ToInt32(TxtAnio.Text),
                        IdVisibilidad = ((Visibilidad)ComboRubro.SelectedItem).IdVisibilidad
                    };
                    listadoDialog.ShowDialog();
                }
                else if (tipoSeleccionado.Equals(Resources.TipoListadoClientesMasProductos, StringComparison.CurrentCultureIgnoreCase))
                {
                    var listadoDialog = new ListadoComprados
                    {
                        Trimestre = (int) ComboTrimestres.SelectedItem,
                        Anio = Convert.ToInt32(TxtAnio.Text),
                        Rubro = (Rubro) ComboRubro.SelectedItem
                    };
                    listadoDialog.ShowDialog();
                }
                else if (tipoSeleccionado.Equals(Resources.TipoListadoVendedoresMasFacturas, StringComparison.CurrentCultureIgnoreCase))
                {
                    var listadoDialog = new ListadoFacturas
                    {
                        Trimestre = (int) ComboTrimestres.SelectedItem,
                        Anio = Convert.ToInt32(TxtAnio.Text)
                    };
                    listadoDialog.ShowDialog();
                }
                else if (tipoSeleccionado.Equals(Resources.TipoListadoVendedoresMasMonto, StringComparison.CurrentCultureIgnoreCase))
                {
                    var listadoDialog = new ListadoMontos
                    {
                        Trimestre = (int) ComboTrimestres.SelectedItem,
                        Anio = Convert.ToInt32(TxtAnio.Text)
                    };
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

            if (tipoSeleccionado == null) return;
            
            if (tipoSeleccionado.Equals(Resources.TipoListadoClientesMasProductos,StringComparison.CurrentCultureIgnoreCase))
            {
                LabelRubro.Visible = true;
                ComboRubro.Visible = true;
                LabelRubro.Text = "Rubro";

                #region cargarComboRubro

                Rubro rubroTodos = new Rubro(){DescripcionCorta = "--Todos--", IdRubro = 0};
                List<Rubro> rubros = new List<Rubro>();
                rubros.Add(rubroTodos);
                rubros.AddRange(RubrosServices.GetAllData());
                ComboRubro.DataSource = rubros;
                ComboRubro.DisplayMember = "DescripcionCorta";
                ComboRubro.DropDownStyle = ComboBoxStyle.DropDownList;
                #endregion
            }
            else
            {
                LabelRubro.Visible = false;
                ComboRubro.Visible = false;
            }

            if (tipoSeleccionado.Equals(Resources.TipoListadoVendedoresProductosNoVendidos,StringComparison.CurrentCultureIgnoreCase))
            {
                LabelRubro.Visible = true;
                LabelRubro.Text = "Visibilidad";
                ComboRubro.Visible = true;

                #region cargarComboVisibilidades
                Visibilidad visibilidadTodos = new Visibilidad() { IdVisibilidad = 0, Descripcion = "--Todos--" };
                List<Visibilidad> visibilidades = new List<Visibilidad>();
                visibilidades.Add(visibilidadTodos);
                visibilidades.AddRange(VisibilidadServices.GetAllData());

                ComboRubro.DataSource = visibilidades;
                ComboRubro.DisplayMember = "Descripcion";
                ComboRubro.DropDownStyle = ComboBoxStyle.DropDownList;
                #endregion
            }
        }
    }
}
