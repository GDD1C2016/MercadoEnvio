using System;
using System.Windows.Forms;
using MercadoEnvio.Helpers;
using MercadoEnvio.Properties;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.Login
{
    public partial class Main : Form
    {
        private int errorCount = 0;
        
        public Main()
        {
            InitializeComponent();
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            EncryptHelper encryptHelper = new EncryptHelper();
            string passWord = encryptHelper.Sha256Encrypt(TxtPassword.Text);
            string user = TxtUsername.Text;

            Entidades.Login login = UsuarioService.LoginUser(user, passWord);

            if (login.LoginSuccess)
            {
                MessageBox.Show("Exito!");
            }
            else
            {
                LabelErrorLogin.Text = login.ErrorMessage;
                
                if (login.Usuario != null && login.Usuario.Estado.Equals("B"))
                {
                    LabelCantIntentos.Text = Resources.UsuarioBloqueado;

                }
                else
                {
                    if(login.Usuario != null)
                    LabelCantIntentos.Text = Resources.IntentosRestantes + (3 - login.Usuario.CantIntentos);
                }
            }
        }
    }
}
