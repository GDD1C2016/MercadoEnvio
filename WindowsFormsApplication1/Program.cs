using System.Windows.Forms;
using MercadoEnvio.ABM_Rol;
using MercadoEnvio.ABM_Rubro;
using MercadoEnvio.ComprarOfertar;
using MercadoEnvio.Entidades;
using MercadoEnvio.Login;

namespace MercadoEnvio
{
    static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Main());
            //Application.Run(new AltaRol(new Rol()));
            Application.Run(new MainRol());
            //Application.Run(new MainPublicacion());
            //Application.Run(new MainRubro(false));
        }
    }
}
