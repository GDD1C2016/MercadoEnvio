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

        public GenerarPublicacion()
        {
            InitializeComponent();
        }

        private void GenerarPublicacion_Load(object sender, EventArgs e)
        {
            const string fmt = "000000000000000000";

            if (Publicacion.IdPublicacion != 0)
                label4.Text = Publicacion.IdPublicacion.ToString(fmt);

            //#region armadoComboEstado
            //List<Publicacion> publicaciones = new List<Publicacion>(PublicacionesServices.GetEstados(Publicacion.));
            //publicaciones = publicaciones.OrderBy(x => x.IdEstado).ToList();

            //ComboEstado.DataSource = publicaciones;
            //ComboEstado.DisplayMember = "EstadoDescripcion";
            //ComboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            //#endregion
        }
    }
}
