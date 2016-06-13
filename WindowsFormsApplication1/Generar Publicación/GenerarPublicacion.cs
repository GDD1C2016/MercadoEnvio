using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MercadoEnvio.Entidades;

namespace MercadoEnvio.Generar_Publicación
{
    public partial class GenerarPublicacion : Form
    {
        #region properties
        public Publicacion Publicacion { get; set; }
        #endregion

        public GenerarPublicacion(Usuario usuario, Publicacion publicacion)
        {
            InitializeComponent();

            Publicacion = publicacion;
        }

        private void GenerarPublicacion_Load(object sender, EventArgs e)
        {
            string fmt = "000000000000000000";

            if (Publicacion.IdPublicacion != 0)
                label4.Text = Publicacion.IdPublicacion.ToString(fmt);
        }
    }
}
