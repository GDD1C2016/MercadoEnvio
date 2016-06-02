using System;
using System.Windows.Forms;
using MercadoEnvio.Helpers;
using MercadoEnvio.Properties;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.Login
{
    public partial class Main : Form
    {
        //private int errorCount = 0;

        public Main()
        {
            InitializeComponent();
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            EncryptHelper encryptHelper = new EncryptHelper();
            string password = encryptHelper.Sha256Encrypt(TxtPassword.Text);
            string user = TxtUsername.Text;

            Entidades.Login login = UsuarioService.LoginUser(user, password);

            if (login.LoginSuccess)
            {
                LabelErrorLogin.Text = string.Empty;
                LabelCantIntentos.Text = string.Empty;
                MessageBox.Show("Ingreso exitoso");
            }
            else
            {
                LabelErrorLogin.Text = login.ErrorMessage;

                if (login.Usuario != null && !login.Usuario.Activo)
                {
                    LabelCantIntentos.Text = string.Empty;
                }
                else
                {
                    if (login.Usuario != null)
                        LabelCantIntentos.Text = Resources.IntentosRestantes + (3 - login.Usuario.CantIntFallidos);
                }
            }
        }
    }
}
