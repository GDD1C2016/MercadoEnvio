using System;
using System.Windows.Forms;
using MercadoEnvio.Entidades;

namespace MercadoEnvio.Generar_Publicación
{
    public partial class GenerarPublicacion : Form
    {
        public Publicacion Publicacion { get; set; }

        public GenerarPublicacion(Usuario usuario, Publicacion publicacion)
        {
            InitializeComponent();

            Publicacion = publicacion;
        }

        private void GenerarPublicacion_Load(object sender, EventArgs e)
        {
            const string fmt = "000000000000000000";

            if (Publicacion.IdPublicacion != 0)
                label4.Text = Publicacion.IdPublicacion.ToString(fmt);
        }
    }
}
