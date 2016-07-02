using System;
using System.Windows.Forms;
using MercadoEnvio.Helpers;
using MercadoEnvio.Properties;
using MercadoEnvio.Servicios;
using MainMenu = MercadoEnvio.Menu.MainMenu;

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
            EncryptHelper encryptHelper = new EncryptHelper();
            string password = encryptHelper.Sha256Encrypt(TxtPassword.Text);
            string userName = TxtUsername.Text;

            Entidades.Login login = UsuariosService.LoginUser(userName, password);

            if (login.LoginSuccess)
            {
                LabelErrorLogin.Text = string.Empty;
                LabelCantIntentos.Text = string.Empty;

                if (login.Usuario.Roles.Count > 1)
                {
                    var seleccionRol = new MainSeleccionRol {Usuario = login.Usuario};
                    seleccionRol.ShowDialog();
                }
                else
                {
                    //ActualizacionServices.ConfigurarFechas();
                    //ActualizacionServices.CerrarSubastas(); //TODO
                    var menuDialog = new MainMenu {Usuario = login.Usuario};
                    menuDialog.ShowDialog();
                }
            }
            else
            {
                LabelErrorLogin.Text = login.ErrorMessage;

                if (login.Usuario != null && !login.Usuario.Activo)
                    LabelCantIntentos.Text = string.Empty;
                else
                    if (login.Usuario != null)
                        LabelCantIntentos.Text = Resources.IntentosRestantes + (3 - login.Usuario.CantIntFallidos);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            #region ValidarFechaConfig
            FechaHelper fechaHelper = new FechaHelper();

            if (!fechaHelper.ConfigDateIsValid())
            {
                MessageBox.Show(Resources.ErrorFechaSistema, Resources.MercadoEnvio, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
           
            #endregion
        }
    }
}
