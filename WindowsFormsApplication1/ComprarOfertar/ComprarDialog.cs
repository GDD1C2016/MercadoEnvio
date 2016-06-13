using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MercadoEnvio.Entidades;

namespace MercadoEnvio.ComprarOfertar
{
    public partial class ComprarDialog : Form
    {
        public Publicacion PublicacionSeleccionada { get; set; }

        public ComprarDialog()
        {
            InitializeComponent();
        }

        private void ComprarDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
