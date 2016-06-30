using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MercadoEnvio.ABM_Rol;
using MercadoEnvio.ABM_Rubro;
using MercadoEnvio.ABM_Usuario;
using MercadoEnvio.ABM_Visibilidad;
using MercadoEnvio.Calificar;
using MercadoEnvio.ComprarOfertar;
using MercadoEnvio.Entidades;
using MercadoEnvio.Generar_Publicación;
using MercadoEnvio.Historial_Cliente;
using MercadoEnvio.Properties;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.Menu
{
    public partial class MainMenu : Form
    {
        public Usuario Usuario { get; set; }

        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            #region habilitacionSeccionABM
            List<Rol> roles = new List<Rol>(RolesServices.GetAllData());
            Rol rolAdmin = roles.Find(x => x.Descripcion.Equals(Resources.Administrativo, StringComparison.CurrentCultureIgnoreCase));
            
            bool condABM = Usuario.Roles.Any(x=>x.IdRol == rolAdmin.IdRol);
            GroupBoxABM.Enabled = condABM;
            #endregion
        }

        private void BtnPublicacion_Click(object sender, EventArgs e)
        {
            var publicacionDialog = new MainPublicacion {Usuario = Usuario};
            publicacionDialog.ShowDialog();
        }

        private void BtnPublicar_Click(object sender, EventArgs e)
        {
            var generarPublicacionDialog = new GenerarPublicacion();
            generarPublicacionDialog.ShowDialog();
        }

        private void BtnCalificar_Click(object sender, EventArgs e)
        {
            var calificacionesDialog = new MainCalificaciones {Usuario = Usuario};
            calificacionesDialog.ShowDialog();
        }

        private void BtnHistorial_Click(object sender, EventArgs e)
        {
            var historialDialog = new MainHistorialCliente {Usuario = Usuario};
            historialDialog.ShowDialog();
        }

        private void BtnFactura_Click(object sender, EventArgs e)
        {

        }

        private void BtnListado_Click(object sender, EventArgs e)
        {
        
        }

        private void BtnRol_Click(object sender, EventArgs e)
        {
            var rolDialog = new MainRol {Usuario = Usuario};
            rolDialog.ShowDialog();
        }

        private void BtnRubro_Click(object sender, EventArgs e)
        {
            var rubroDialog = new MainRubro {Usuario = Usuario};
            rubroDialog.ShowDialog();
        }

        private void BtnUsuario_Click(object sender, EventArgs e)
        {
            var usuarioDialog = new MainUsuario {Usuario = Usuario};
            usuarioDialog.ShowDialog();
        }

        private void BtnVisibilidad_Click(object sender, EventArgs e)
        {
            var visibilidadDialog = new MainVisibilidad {Usuario = Usuario};
            visibilidadDialog.ShowDialog();
        }
    }
}
