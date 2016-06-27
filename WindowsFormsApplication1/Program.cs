using System.Windows.Forms;
using MercadoEnvio.ABM_Rol;
using MercadoEnvio.ABM_Rubro;
using MercadoEnvio.ABM_Usuario;
using MercadoEnvio.ABM_Visibilidad;
using MercadoEnvio.Calificar;
using MercadoEnvio.ComprarOfertar;
using MercadoEnvio.Entidades;
using MercadoEnvio.Listado_Estadistico;
using MercadoEnvio.Login;
using MercadoEnvio.Menu;
using MainMenu = MercadoEnvio.Menu.MainMenu;

namespace MercadoEnvio
{
    static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Main());
            Application.Run(new MainListado());
        }
    }
}
