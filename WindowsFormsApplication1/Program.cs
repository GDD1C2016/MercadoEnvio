using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Windows.Forms;
using MercadoEnvio.ABM_Rol;
//using MercadoEnvio.ComprarOfertar;
using MercadoEnvio.Entidades;
//using MercadoEnvio.Login;

namespace MercadoEnvio
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Main());
            Application.Run(new AltaRol(new Rol()));
            //Application.Run(new MainRol());
            //Application.Run(new MainPublicacion());
        }
    }
}
