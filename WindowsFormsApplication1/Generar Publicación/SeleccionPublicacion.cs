using System;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
using MercadoEnvio.Properties;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.Generar_Publicación
{
    public partial class SeleccionPublicacion : Form
    {
        public Publicacion Publicacion { get; set; }

        public SeleccionPublicacion()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            var publicacion = PublicacionesServices.GetPublicacion(Convert.ToInt32(textBoxCodPublicacion.Text.Trim()));

            if (publicacion != null)
            {
                Publicacion = publicacion;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(Resources.ErrorNoExisteCodPublicacion, Resources.MercadoEnvio, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
