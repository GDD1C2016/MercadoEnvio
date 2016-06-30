using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
using MercadoEnvio.Properties;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.Generar_Publicación
{
    public partial class GenerarPublicacion : Form
    {
        public Publicacion Publicacion { get; set; }

        public Usuario Usuario { get; set; }

        public Cliente Cliente { get; set; }

        public Empresa Empresa { get; set; }

        public GenerarPublicacion()
        {
            InitializeComponent();
        }

        private void GenerarPublicacion_Load(object sender, EventArgs e)
        {
            const string fmt = "000000000000000000";
            const string espacio = " ";

            #region armadoComboEstado
            List<Publicacion> publicaciones = new List<Publicacion>(PublicacionesServices.GetEstados(Publicacion));
            publicaciones = publicaciones.OrderBy(x => x.EstadoDescripcion).ToList();

            ComboEstado.DataSource = publicaciones;
            ComboEstado.DisplayMember = "EstadoDescripcion";
            ComboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion

            #region armadoComboTipoPublicacion
            List<TipoPublicacion> tipos = new List<TipoPublicacion>();
            tipos = tipos.OrderBy(x => x.Descripcion).ToList();

            ComboTipoPublicacion.DataSource = tipos;
            ComboEstado.DisplayMember = "Descripcion";
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
            List<Visibilidad> tiposVisibilidad = new List<Visibilidad>(VisibilidadServices.GetAllData());
            tiposVisibilidad = tiposVisibilidad.OrderBy(x => x.Descripcion).ToList();

            ComboVisibilidad.DataSource = tiposVisibilidad;
            ComboVisibilidad.DisplayMember = "Descripcion";
            ComboVisibilidad.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion

            if (Publicacion.IdPublicacion != 0)
            {
                label4.Text = Publicacion.IdPublicacion.ToString(fmt);
                label9.Text = Publicacion.NombreUsuario;
                RichTextBoxObservaciones.Text = Publicacion.Descripcion;
                ComboEstado.SelectedItem = Publicacion.EstadoDescripcion;
                ComboTipoPublicacion.SelectedItem = Publicacion.TipoPublicacion.Descripcion;
                ComboRubro.SelectedItem = Publicacion.RubroDescripcionLarga;
                ComboVisibilidad.SelectedItem = Publicacion.Visibilidad.Descripcion;
            }
            else if (
                Usuario.Roles.Exists(
                    x => x.Descripcion.Equals(Resources.Cliente, StringComparison.CurrentCultureIgnoreCase)))
            {
                Cliente = UsuarioService.GetClienteById(Usuario.IdUsuario);
                label9.Text = Cliente.Nombre + espacio + Cliente.Apellido;
            }
            else
            {
                Empresa = UsuarioService.GetEmpresaById(Usuario.IdUsuario);
                label9.Text = Empresa.RazonSocial;
            }
        }
    }
}
