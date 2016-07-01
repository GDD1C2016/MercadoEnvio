using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
using MercadoEnvio.Helpers;
using MercadoEnvio.Properties;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.Generar_Publicación
{
    public partial class GenerarPublicacion : Form
    {
        FechaHelper _helper = new FechaHelper();

        public Usuario Usuario { get; set; }

        public GenerarPublicacion()
        {
            InitializeComponent();
        }

        private void GenerarPublicacion_Load(object sender, EventArgs e)
        {

            #region armadoComboTipoPublicacion
            List<TipoPublicacion> tipos = new List<TipoPublicacion>(TiposPublicacionServices.GetAllData());
            tipos = tipos.OrderBy(x => x.Descripcion).ToList();

            ComboTipoPublicacion.DataSource = tipos;
            ComboTipoPublicacion.DisplayMember = "Descripcion";
            ComboTipoPublicacion.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion

            #region armadoComboRubro
            List<Rubro> rubros = new List<Rubro>(RubrosServices.GetAllData());
            rubros = rubros.OrderBy(x => x.DescripcionLarga).ToList();

            ComboRubro.DataSource = rubros;
            ComboRubro.DisplayMember = "DescripcionLarga";
            ComboRubro.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion

            #region armadoComboVisibilidad
            List<Visibilidad> tiposVisibilidad = new List<Visibilidad>(VisibilidadesServices.GetAllData());
            tiposVisibilidad = tiposVisibilidad.OrderBy(x => x.Descripcion).ToList();

            ComboVisibilidad.DataSource = tiposVisibilidad;
            ComboVisibilidad.DisplayMember = "Descripcion";
            ComboVisibilidad.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion

            Publicacion publicacion = new Publicacion
            {
                EstadoPublicacion = { Descripcion = Resources.Borrador },
                TipoPublicacion = { Descripcion = Resources.CompraInmediata },
                RubroDescripcionLarga = ((Rubro)ComboRubro.SelectedItem).DescripcionLarga,
                Visibilidad = { Descripcion = ((Visibilidad)ComboVisibilidad.SelectedItem).Descripcion },
                FechaInicio = _helper.GetSystemDate(),
                FechaVencimiento = _helper.GetSystemDate()
            };

            InicializarPantalla(publicacion);
        }

        private void ComboTipoPublicacion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (((TipoPublicacion)(ComboTipoPublicacion.SelectedItem)).Descripcion.Equals(Resources.Subasta, StringComparison.CurrentCultureIgnoreCase))
            {
                label12.Visible = false;
                textBoxStock.Visible = false;
                checkBoxAceptaEnvio.Visible = false;
                label11.Visible = true;
                textBoxPrecioReserva.Visible = true;
            }
            else
            {
                label12.Visible = true;
                textBoxStock.Visible = true;
                checkBoxAceptaEnvio.Visible = true;
                label11.Visible = false;
                textBoxPrecioReserva.Visible = false;
            }
        }

        private void InicializarPantalla(Publicacion publicacion)
        {
            const string fmt = "000000000000000000";
            const string espacio = " ";

            #region armadoComboEstado
            List<EstadoPublicacion> estados = new List<EstadoPublicacion>(PublicacionesServices.GetEstados(publicacion.EstadoPublicacion.Descripcion));
            estados = estados.OrderBy(x => x.Descripcion).ToList();

            ComboEstado.DataSource = estados;
            ComboEstado.DisplayMember = "Descripcion";
            ComboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion

            if (Usuario.Roles.Exists(x => x.Descripcion.Equals(Resources.Cliente, StringComparison.CurrentCultureIgnoreCase)))
            {
                var cliente = UsuariosService.GetClienteById(Usuario.IdUsuario);
                labelNomUsuario.Text = cliente.Nombre + espacio + cliente.Apellido;
            }
            else
            {
                var empresa = UsuariosService.GetEmpresaById(Usuario.IdUsuario);
                labelNomUsuario.Text = empresa.RazonSocial;
            }

            labelCodPublicacion.Text = publicacion.IdPublicacion.ToString(fmt);
            RichTextBoxDescripcion.Text = publicacion.Descripcion;
            ComboEstado.SelectedItem = publicacion.EstadoPublicacion;
            ComboTipoPublicacion.SelectedItem = publicacion.TipoPublicacion;
            ComboRubro.SelectedIndex = ComboRubro.Items.IndexOf(publicacion.RubroDescripcionLarga);
            ComboVisibilidad.SelectedItem = publicacion.Visibilidad;
            DatePickerFechaInicio.Value = publicacion.FechaInicio;
            DatePickerFechaVencimiento.Value = publicacion.FechaVencimiento;
            textBoxStock.Text = publicacion.Stock.ToString();
            checkBoxAceptaEnvio.Checked = publicacion.Envio;
            textBoxPrecio.Text = publicacion.Precio.ToString(CultureInfo.CurrentCulture);
            textBoxPrecioReserva.Text = publicacion.PrecioReserva.ToString(CultureInfo.CurrentCulture);

            if (publicacion.IdPublicacion != 0)
            {
                ButtonGenerar.Visible = true;
                ButtonEditar.Visible = false;
            }
            else
            {
                ButtonGenerar.Visible = false;
                ButtonEditar.Visible = true;
            }
        }

        private void ButtonGenerar_Click(object sender, EventArgs e)
        {
            Publicacion publicacion = new Publicacion
            {
                EstadoPublicacion = { Descripcion = Resources.Borrador },
                TipoPublicacion = { Descripcion = Resources.CompraInmediata },
                RubroDescripcionLarga = ((Rubro)ComboRubro.SelectedItem).DescripcionLarga,
                Visibilidad = { Descripcion = ((Visibilidad)ComboVisibilidad.SelectedItem).Descripcion },
                FechaInicio = _helper.GetSystemDate(),
                FechaVencimiento = _helper.GetSystemDate()
            };

            InicializarPantalla(publicacion);
        }

        private void ButtonEditar_Click(object sender, EventArgs e)
        {
            var seleccionPublicacion = new SeleccionPublicacion {Usuario = Usuario};
            var result = seleccionPublicacion.ShowDialog();

            if (result.Equals(DialogResult.OK))
            {
                InicializarPantalla(seleccionPublicacion.Publicacion);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(labelCodPublicacion) != 0)
                PublicacionesServices.UpdatePublicacion(labelCodPublicacion.Text, RichTextBoxDescripcion.Text, textBoxStock.Text, DatePickerFechaInicio.Value, DatePickerFechaVencimiento.Value, textBoxPrecio.Text, textBoxPrecioReserva.Text, ((Rubro)ComboRubro.SelectedItem).IdRubro, Usuario.IdUsuario, ((EstadoPublicacion)ComboEstado.SelectedItem).IdEstado, ((TipoPublicacion)ComboTipoPublicacion.SelectedItem).IdTipo);
            else
                PublicacionesServices.InsertPublicacion(RichTextBoxDescripcion.Text, textBoxStock.Text, DatePickerFechaInicio.Value, DatePickerFechaVencimiento.Value, textBoxPrecio.Text, textBoxPrecioReserva.Text, ((Rubro)ComboRubro.SelectedItem).IdRubro, Usuario.IdUsuario, ((EstadoPublicacion)ComboEstado.SelectedItem).IdEstado, ((TipoPublicacion)ComboTipoPublicacion.SelectedItem).IdTipo);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
