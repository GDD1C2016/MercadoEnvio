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
using MercadoEnvio.Properties;

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
            ArmarFormularioSegunTipo(PublicacionSeleccionada);
            LlenarFormularioSegunTipo(PublicacionSeleccionada);
        }

        private void ArmarFormularioSegunTipo(Publicacion publicacion)
        {
            if (publicacion.Descripcion.Contains("Compra"))
            {
                LabelCantidad.Text = Resources.Cantidad;
                LabelCantidad.Visible = true;
                CheckBoxEnvio.Visible = true;
                GroupBoxDetalles.Text = Resources.DetallesDeCompra;
                this.Text = Resources.Compra;
                LabelPrecioReservaNum.Visible = false;
                LabelPrecioReservaText.Visible = false;
                TxtCantidad.Visible = true;
                TxtOfertar.Visible = false;
            }
            else
            {
                LabelCantidad.Text = Resources.Ofertar;
                LabelCantidad.Visible = true;
                CheckBoxEnvio.Visible = false;
                GroupBoxDetalles.Text = Resources.DetallesSubasta;
                this.Text = Resources.Subasta;
                LabelPrecioReservaNum.Visible = true;
                LabelPrecioReservaText.Visible = true;
                TxtCantidad.Visible = false;
                TxtOfertar.Visible = true;
            }
        }

        private void LlenarFormularioSegunTipo(Publicacion publicacion)
        {
            if (publicacion.Descripcion.Contains("Compra"))
            {
                
            }
            else
            {
                LabelPrecioReservaNum.Text = publicacion.PrecioReserva.ToString();
            }
        }
    }
}
