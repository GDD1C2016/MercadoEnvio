using System.Windows.Forms;
using MercadoEnvio.ComprarOfertar;

namespace MercadoEnvio
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Main());
            //Application.Run(new AltaRol(new Rol()));
            //Application.Run(new MainRol());
            Application.Run(new MainPublicacion());
        }
    }
}
