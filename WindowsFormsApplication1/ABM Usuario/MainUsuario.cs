using System;
using System.Collections.Generic;
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
        public Usuario Usuario { get; set; }

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

            #region armadoDeGrillaUsuarios
            BindingList<Cliente> dataSource = new BindingList<Cliente>();
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;

            DgUsuarios.AutoGenerateColumns = false;
            DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = Resources.Nombre, Name = "Nombre" });
            DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Apellido", HeaderText = Resources.Apellido, Name = "Apellido" });
            DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = Resources.Email, Name = "Email" });
            DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NumeroDoc", HeaderText = Resources.NoDoc, Name = "NumeroDoc" });

            DgUsuarios.DataSource = bs;
            #endregion

        }

        private void ComboTipoDeUsuario_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Rol rolSeleccionado = ((Rol)ComboTipoDeUsuario.SelectedItem);

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
            Rol rolSeleccionado = ((Rol)ComboTipoDeUsuario.SelectedItem);

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
                DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RazonSocial", HeaderText = Resources.RazonSocial, Name = "RazonSocial" });
                DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cuit", HeaderText = Resources.CUIT, Name = "Cuit" });
                DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = Resources.Email, Name = "Email" });
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
                DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = Resources.Nombre, Name = "Nombre" });
                DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Apellido", HeaderText = Resources.Apellido, Name = "Apellido" });
                DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = Resources.Email, Name = "Email" });
                DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NumeroDoc", HeaderText = Resources.NoDoc, Name = "NumeroDoc" });
                #endregion

                DgUsuarios.DataSource = bs;
            }
        }

        private void TxtFiltroDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            Usuario usuarioSeleccionado = new Usuario();

            if (DgUsuarios.SelectedRows.Count > 0)
            {
                BindingSource bs = DgUsuarios.DataSource as BindingSource;
                if (bs != null)
                    usuarioSeleccionado = (Usuario)bs.List[bs.Position];
            }

            if (usuarioSeleccionado.Activo)
            {
                UsuarioService.DeleteUsuario(usuarioSeleccionado);

                Rol rolSeleccionado = ((Rol)ComboTipoDeUsuario.SelectedItem);

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
                    DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RazonSocial", HeaderText = Resources.RazonSocial, Name = "RazonSocial" });
                    DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cuit", HeaderText = Resources.CUIT, Name = "Cuit" });
                    DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = Resources.Email, Name = "Email" });
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
                    DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = Resources.Nombre, Name = "Nombre" });
                    DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Apellido", HeaderText = Resources.Apellido, Name = "Apellido" });
                    DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = Resources.Email, Name = "Email" });
                    DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NumeroDoc", HeaderText = Resources.NoDoc, Name = "NumeroDoc" });
                    #endregion

                    DgUsuarios.DataSource = bs;
                }

                MessageBox.Show(Resources.UsuarioBorrado, Resources.MercadoEnvio, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show(Resources.ErrorUsuarioBorrado, Resources.ErrorBorrado, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Rol rolSeleccionado = ((Rol)ComboTipoDeUsuario.SelectedItem);

            if (rolSeleccionado.Descripcion.Equals("Empresa", StringComparison.CurrentCultureIgnoreCase))
            {
                Empresa empresaSeleccionada = new Empresa();

                if (DgUsuarios.SelectedRows.Count > 0)
                {
                    BindingSource bs = DgUsuarios.DataSource as BindingSource;
                    if (bs != null)
                        empresaSeleccionada = (Empresa)bs.List[bs.Position];
                }

                var altaUsuario = new AltaUsuario(empresaSeleccionada);
                altaUsuario.Text = Resources.EdicionUsuario;
                var result = altaUsuario.ShowDialog();

                if (result.Equals(DialogResult.OK))
                {
                    string filtroRazonSocial = TxtFiltroNombre.Text.Trim();
                    string filtroCuit = TxtFiltroCuit.Text.Trim();
                    string filtroEmail = TxtFiltroEmail.Text;

                    BindingList<Empresa> dataSource =
                        new BindingList<Empresa>(UsuarioService.FindEmpresas(filtroRazonSocial, filtroCuit, filtroEmail));
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dataSource;

                    DgUsuarios.Columns.Clear();

                    #region rearmadoDeGrilla

                    DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "RazonSocial",
                        HeaderText = Resources.RazonSocial,
                        Name = "RazonSocial"
                    });
                    DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Cuit",
                        HeaderText = Resources.CUIT,
                        Name = "Cuit"
                    });
                    DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Email",
                        HeaderText = Resources.Email,
                        Name = "Email"
                    });

                    #endregion

                    DgUsuarios.DataSource = bs;
                }
            }
            else
            {
                Cliente clienteSeleccionado = new Cliente();

                if (DgUsuarios.SelectedRows.Count > 0)
                {
                    BindingSource bs = DgUsuarios.DataSource as BindingSource;
                    if (bs != null)
                        clienteSeleccionado = (Cliente)bs.List[bs.Position];
                }

                var altaUsuario = new AltaUsuario(clienteSeleccionado);
                altaUsuario.Text = Resources.EdicionUsuario;
                var result = altaUsuario.ShowDialog();

                if (result.Equals(DialogResult.OK))
                {
                    string filtroNombre = TxtFiltroNombre.Text.Trim();
                    string filtroDni = TxtFiltroDNI.Text.Trim();
                    string filtroApellido = TxtFiltroApellido.Text.Trim();
                    string filtroEmail = TxtFiltroEmail.Text.Trim();

                    BindingList<Cliente> dataSource =
                        new BindingList<Cliente>(UsuarioService.FindClientes(filtroNombre, filtroApellido, filtroDni,
                            filtroEmail));
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dataSource;

                    #region rearmadoDeGrilla

                    DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Nombre",
                        HeaderText = Resources.Nombre,
                        Name = "Nombre"
                    });
                    DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Apellido",
                        HeaderText = Resources.Apellido,
                        Name = "Apellido"
                    });
                    DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Email",
                        HeaderText = Resources.Email,
                        Name = "Email"
                    });
                    DgUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "NumeroDoc",
                        HeaderText = Resources.NoDoc,
                        Name = "NumeroDoc"
                    });

                    #endregion

                    DgUsuarios.DataSource = bs;
                }
            }
        }
    }
}
