using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
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

            Funcionalidad funcionalidadTodos = new Funcionalidad { Descripcion = "--Todas--", IdFuncionalidad = 0 };
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>(RolerServices.GetAllFuncionalidades());
            funcionalidades.Add(funcionalidadTodos);
            funcionalidades = funcionalidades.OrderBy(x => x.IdFuncionalidad).ToList();

            ComboFuncionalidad.DataSource = funcionalidades;
            ComboFuncionalidad.DisplayMember = "Descripcion";
            ComboFuncionalidad.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string filtroNombre = string.Empty;
            int filtroFuncionalidad;
            string filtroEstado = string.Empty;

            filtroNombre = TxtFiltroNombre.Text;
            filtroFuncionalidad = ((Funcionalidad) ComboFuncionalidad.SelectedItem).IdFuncionalidad;
            filtroEstado = TxtFiltroEstado.Text;

            DgRoles.DataSource = RolerServices.FindRoles(filtroNombre, filtroFuncionalidad, filtroEstado);
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            DgRoles.DataSource = new List<Rol>();
        }
    }
}
