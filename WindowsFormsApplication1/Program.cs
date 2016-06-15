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
            //Application.Run(new AltaRol(new Rol()));
            //Application.Run(new MainRol());
            //Application.Run(new MainPublicacion());
            //Application.Run(new MainRubro());
            //Application.Run(new MainVisibilidad());
            //Application.Run(new MainUsuario());
            //Application.Run(new AltaUsuario(new Usuario()));
            //Application.Run(new CalificarVendedor());
            //Application.Run(new MainMenu());
            Application.Run(new MainListado());
        }
    }
}
