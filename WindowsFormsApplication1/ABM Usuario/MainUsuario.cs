using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
using MercadoEnvio.Properties;
using MercadoEnvio.Servicios;
using System.ComponentModel;
using System.Globalization;

namespace MercadoEnvio.ABM_Usuario
{
    public partial class MainUsuario : Form
    {
        public MainUsuario()
        {
            InitializeComponent();
        }

        private void MainUsuario_Load(object sender, EventArgs e)
        {
            #region armadoComboRol
            List<Rol> roles = new List<Rol>(RolesServices.GetAllData());
            roles = roles.FindAll(x => x.Descripcion != "Administrativo");
            ComboTipoDeUsuario.DataSource = roles;
            ComboTipoDeUsuario.DisplayMember = "Descripcion";
            ComboTipoDeUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion

            #region armadoDeGrillaVisibilidad
            BindingList<Cliente> dataSource = new BindingList<Cliente>();
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;

            DgUsuarios.AutoGenerateColumns = false;
            DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Nombre", Name = "Nombre" });
            DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Apellido", HeaderText = "Apellido", Name = "Apellido" });
            DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email", Name = "Email" });
            DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NumeroDoc", HeaderText = "Número Documento", Name = "NumeroDoc" });

            DgUsuarios.DataSource = bs;
            #endregion

        }

        private void ComboTipoDeUsuario_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Rol rolSeleccionado = new Rol();
            rolSeleccionado = ((Rol) ComboTipoDeUsuario.SelectedItem);

            ReorganizarPantallaDeAcuerdoARol(rolSeleccionado);
        }

        private void ReorganizarPantallaDeAcuerdoARol(Rol rol)
        {
            if (rol.Descripcion.Equals("Empresa", StringComparison.CurrentCultureIgnoreCase))
            {
                LabelNombre.Text = Resources.RazonSocial;
                LabelDNI.Text = Resources.CUIT;
                LabelApellido.Visible = false;
                TxtFiltroApellido.Visible = false;
                TxtFiltroDNI.Visible = false;
                TxtFiltroCuit.Visible = true;
            }
            else
            {
                LabelNombre.Text = Resources.Nombre;
                LabelDNI.Text = Resources.DNI;
                LabelApellido.Visible = true;
                TxtFiltroApellido.Visible = true;
                TxtFiltroDNI.Visible = true;
                TxtFiltroCuit.Visible = false;
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            BindingList<Usuario> dataSource = new BindingList<Usuario>();
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;

            DgUsuarios.DataSource = bs;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Rol rolSeleccionado = new Rol();
            rolSeleccionado = ((Rol)ComboTipoDeUsuario.SelectedItem);

            if (rolSeleccionado.Descripcion.Equals("Empresa", StringComparison.CurrentCultureIgnoreCase))
            {
                string filtroRazonSocial = TxtFiltroNombre.Text.Trim();
                string filtroCuit = TxtFiltroCuit.Text.Trim();
                string filtroEmail = TxtFiltroEmail.Text;

                BindingList<Empresa> dataSource = new BindingList<Empresa>(UsuarioService.FindEmpresas(filtroRazonSocial, filtroCuit, filtroEmail));
                BindingSource bs = new BindingSource();
                bs.DataSource = dataSource;

                DgUsuarios.Columns.Clear();

                #region rearmadoDeGrilla
                DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RazonSocial", HeaderText = "Razón Social", Name = "RazonSocial" });
                DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cuit", HeaderText = "CUIT", Name = "Cuit" });
                DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email", Name = "Email" });
                #endregion

                DgUsuarios.DataSource = bs;
            }
            else
            {
                string filtroNombre = TxtFiltroNombre.Text.Trim();
                string filtroDni = TxtFiltroDNI.Text.Trim();
                string filtroApellido = TxtFiltroApellido.Text.Trim();
                string filtroEmail = TxtFiltroEmail.Text.Trim();

                BindingList<Cliente> dataSource = new BindingList<Cliente>(UsuarioService.FindClientes(filtroNombre, filtroApellido, filtroDni, filtroEmail));
                BindingSource bs = new BindingSource();
                bs.DataSource = dataSource;

                #region rearmadoDeGrilla
                DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Nombre", Name = "Nombre" });
                DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Apellido", HeaderText = "Apellido", Name = "Apellido" });
                DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email", Name = "Email" });
                DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NumeroDoc", HeaderText = "Número Documento", Name = "NumeroDoc" });
                #endregion

                DgUsuarios.DataSource = bs;
            }
        }

        private void TxtFiltroDNI_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
