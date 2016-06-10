using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
using MercadoEnvio.Properties;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.ABM_Rubro
{
    public partial class AltaRubro : Form
    {
        public AltaRubro(Rubro rubro)
        {
            InitializeComponent();

            TxtDescripcionCorta.Text = rubro.DescripcionCorta;
            TxtDescripcionLarga.Text = rubro.DescripcionLarga;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            List<string> errors = new List<string>(ValidarDatosRubro());

            if (errors.Count > 0)
            {
                var message = string.Join(Environment.NewLine, errors);
                MessageBox.Show(message, Resources.ErrorGuardado, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Rubro newRubro = new Rubro
                {
                    DescripcionCorta = TxtDescripcionCorta.Text.Trim(),
                    DescripcionLarga = TxtDescripcionLarga.Text.Trim()
                };

                if (RubrosServices.SaveNewRubro(newRubro))
                    MessageBox.Show(Resources.RubroCreado);
                else
                    MessageBox.Show(Resources.ErrorGuardado);
            }
        }

        private List<string> ValidarDatosRubro()
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrEmpty(TxtDescripcionCorta.Text))
                errors.Add(Resources.ErrorDescripcionCortaVacia);

            if(string.IsNullOrEmpty(TxtDescripcionLarga.Text))
                errors.Add(Resources.ErrorDescripcionLargaVacia);

            return errors;
        }
    }
}
