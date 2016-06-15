using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using MercadoEnvio.Servicios;

namespace MercadoEnvio.Menu
{
    public partial class MainMenu : Form
    {
        Usuario Usuario { get; set; }

        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            #region habilitacionSeccionABM
            List<Rol> roles = new List<Rol>(RolesServices.GetAllData());
            Rol rolAdmin = new Rol();
            rolAdmin = roles.Find(x => x.Descripcion.Equals("Administrativo", StringComparison.CurrentCultureIgnoreCase));
            
            bool condABM = Usuario.Roles.Any(x=>x.IdRol == rolAdmin.IdRol);
            GroupBoxABM.Enabled = condABM;
            #endregion
        }

        private void BtnPublicacion_Click(object sender, EventArgs e)
        {
            var publicacionDialog = new MainPublicacion();
            publicacionDialog.Usuario = Usuario;
            var res = publicacionDialog.ShowDialog();
        }

        private void BtnPublicar_Click(object sender, EventArgs e)
        {
            var generarPublicacionDialog = new GenerarPublicacion(Usuario, new Publicacion());
            var res = generarPublicacionDialog.ShowDialog();
        }

        private void BtnCalificar_Click(object sender, EventArgs e)
        {
            var calificacionesDialog = new MainCalificaciones();
            calificacionesDialog.Usuario = Usuario;
            var res = calificacionesDialog.ShowDialog();
        }

        private void BtnHistorial_Click(object sender, EventArgs e)
        {
            var historialDialog = new MainHistorialCliente();
            historialDialog.Usuario = Usuario;
            var res = historialDialog.ShowDialog();
        }

        private void BtnFactura_Click(object sender, EventArgs e)
        {

        }

        private void BtnListado_Click(object sender, EventArgs e)
        {
        
        }

        private void BtnRol_Click(object sender, EventArgs e)
        {
            var rolDialog = new MainRol();
            rolDialog.Usuario = Usuario;
            var res = rolDialog.ShowDialog();
        }

        private void BtnRubro_Click(object sender, EventArgs e)
        {
            var rubroDialog = new MainRubro();
            rubroDialog.Usuario = Usuario;
            var res = rubroDialog.ShowDialog();
        }

        private void BtnUsuario_Click(object sender, EventArgs e)
        {
            var usuarioDialog = new MainUsuario();
            usuarioDialog.Usuario = Usuario;
            var res = usuarioDialog.ShowDialog();
        }

        private void BtnVisibilidad_Click(object sender, EventArgs e)
        {
            var visibilidadDialog = new MainVisibilidad();
            visibilidadDialog.Usuario = Usuario;
            var res = visibilidadDialog.ShowDialog();
        }
    }
}
