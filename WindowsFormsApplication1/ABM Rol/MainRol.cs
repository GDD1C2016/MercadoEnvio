using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.ABM_Rol
{
    public partial class MainRol : Form
    {
        public MainRol()
        {
            InitializeComponent();
        }

        private void MainRol_Load(object sender, EventArgs e)
        {
            DgRoles.DataSource = RolerServices.GetAllData();
            
            ComboFuncionalidad.DataSource = DataManagers.DataManagerRoles.GetAllFuncionalidades();
            ComboFuncionalidad.DisplayMember = "Descripcion";
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
        }
    }
}
