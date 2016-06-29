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

        public GenerarPublicacion()
        {
            InitializeComponent();
        }

        private void GenerarPublicacion_Load(object sender, EventArgs e)
        {
            const string fmt = "000000000000000000";

            if (Publicacion.IdPublicacion != 0)
                label4.Text = Publicacion.IdPublicacion.ToString(fmt);

            if (Publicacion.IdPublicacion != 0)
                label9.Text = Publicacion.NombreUsuario;
            else
                if (Usuario.IdUsuario != 0)
                    if (Usuario.Roles.Exists(x => x.Descripcion == "Cliente"))
                    {
                        label9.Text = Usuario.UserName;
                    }

            #region armadoComboEstado
            List<Publicacion> publicaciones = new List<Publicacion>(PublicacionesServices.GetEstados(Publicacion));
            publicaciones = publicaciones.OrderBy(x => x.EstadoDescripcion).ToList();

            ComboEstado.DataSource = publicaciones;
            ComboEstado.DisplayMember = "EstadoDescripcion";
            ComboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion

            #region armadoComboTipoPublicacion
            const string tipoSubasta = "Subasta";
            const string tipoCompraDirecta = "Compra directa";

            List<string> tipos = new List<string> { tipoSubasta, tipoCompraDirecta };
            tipos = tipos.OrderBy(x => x).ToList();

            ComboEstado.DataSource = tipos;
            ComboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion

            #region armadoComboRubro
            List<Rubro> rubros = new List<Rubro>(RubrosServices.GetAllData());
            rubros = rubros.OrderBy(x => x.DescripcionLarga).ToList();

            ComboEstado.DataSource = rubros;
            ComboEstado.DisplayMember = "DescripcionLarga";
            ComboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion

            #region armadoComboVisibilidad
            List<Visibilidad> tiposVisibilidad = new List<Visibilidad>(VisibilidadServices.GetAllData());
            tiposVisibilidad = tiposVisibilidad.OrderBy(x => x.Descripcion).ToList();

            ComboEstado.DataSource = tiposVisibilidad;
            ComboEstado.DisplayMember = "Descripcion";
            ComboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion
        }
    }
}
