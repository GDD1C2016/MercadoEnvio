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
using MercadoEnvio.Facturas;
using MercadoEnvio.Generar_Publicación;
using MercadoEnvio.Historial_Cliente;
using MercadoEnvio.Listado_Estadistico;
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
            List<Rol> roles = new List<Rol>(RolesServices.GetAllData());
            
            #region habilitacionSeccionABM
            Rol rolAdmin = roles.Find(x => x.Descripcion.Equals(Resources.Administrativo, StringComparison.CurrentCultureIgnoreCase));
            
            bool condABM = Usuario.Roles.Any(x=>x.IdRol == rolAdmin.IdRol);
            GroupBoxABM.Enabled = condABM;
            #endregion

            #region habilitacionSecciones

            if (Usuario.RolActivo != null)
            {
                BtnPublicacion.Enabled = Usuario.RolActivo.Funcionalidades.Any(x=>x.Descripcion.Equals(BtnPublicacion.Text,StringComparison.CurrentCultureIgnoreCase));
                BtnPublicar.Enabled = Usuario.RolActivo.Funcionalidades.Any(x=>x.Descripcion.Equals(BtnPublicar.Text,StringComparison.CurrentCultureIgnoreCase));
                BtnCalificar.Enabled = Usuario.RolActivo.Funcionalidades.Any(x=>x.Descripcion.Equals(BtnCalificar.Text,StringComparison.CurrentCultureIgnoreCase));
                BtnHistorial.Enabled = Usuario.RolActivo.Funcionalidades.Any(x=>x.Descripcion.Equals(BtnHistorial.Text,StringComparison.CurrentCultureIgnoreCase));
                BtnFactura.Enabled = Usuario.RolActivo.Funcionalidades.Any(x=>x.Descripcion.Equals(BtnFactura.Text,StringComparison.CurrentCultureIgnoreCase));
                BtnListado.Enabled = Usuario.RolActivo.Funcionalidades.Any(x=>x.Descripcion.Equals(BtnListado.Text,StringComparison.CurrentCultureIgnoreCase));
            }
            else
            {
                BtnPublicacion.Enabled = Usuario.Roles.First().Funcionalidades.Any(x => x.Descripcion.Equals(BtnPublicacion.Text, StringComparison.CurrentCultureIgnoreCase));
                BtnPublicar.Enabled = Usuario.Roles.First().Funcionalidades.Any(x => x.Descripcion.Equals(BtnPublicar.Text, StringComparison.CurrentCultureIgnoreCase));
                BtnCalificar.Enabled = Usuario.Roles.First().Funcionalidades.Any(x => x.Descripcion.Equals(BtnCalificar.Text, StringComparison.CurrentCultureIgnoreCase));
                BtnHistorial.Enabled = Usuario.Roles.First().Funcionalidades.Any(x => x.Descripcion.Equals(BtnHistorial.Text, StringComparison.CurrentCultureIgnoreCase));
                BtnFactura.Enabled = Usuario.Roles.First().Funcionalidades.Any(x => x.Descripcion.Equals(BtnFactura.Text, StringComparison.CurrentCultureIgnoreCase));
                BtnListado.Enabled = Usuario.Roles.First().Funcionalidades.Any(x => x.Descripcion.Equals(BtnListado.Text, StringComparison.CurrentCultureIgnoreCase));
            }
            #endregion
        }

        private void BtnPublicacion_Click(object sender, EventArgs e)
        {
            var publicacionDialog = new MainPublicacion {Usuario = Usuario};
            publicacionDialog.ShowDialog();
        }

        private void BtnPublicar_Click(object sender, EventArgs e)
        {
            var generarPublicacionDialog = new GenerarPublicacion {Usuario = Usuario};
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
            var facturasDialog = new MainFacturas {Usuario = Usuario};
            facturasDialog.ShowDialog();
        }

        private void BtnListado_Click(object sender, EventArgs e)
        {
            var listadoDialog = new MainListado {Usuario = Usuario};
            listadoDialog.ShowDialog();
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

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
