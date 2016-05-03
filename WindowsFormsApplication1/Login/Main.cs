using System;
using System.Windows.Forms;
using MercadoEnvio.Properties;

namespace MercadoEnvio.Login
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            LabelErrorLogin.Text = Resources.ErrorLogin;
        }
    }
}
