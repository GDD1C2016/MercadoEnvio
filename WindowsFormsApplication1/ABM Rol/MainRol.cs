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
            #region armadoDeGrillaFuncionalidad

            BindingList<Rol> dataSource = new BindingList<Rol>(RolerServices.GetAllData());
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;

            DgRoles.AutoGenerateColumns = false;
            DgRoles.ColumnCount = 2;

            DgRoles.Columns[0].HeaderText = "Rol";
            DgRoles.Columns[0].Name = "Descripcion";
            DgRoles.Columns[0].DataPropertyName = "Descripcion";

            DgRoles.Columns[1].HeaderText = "Estado";
            DgRoles.Columns[1].Name = "Estado";
            DgRoles.Columns[1].DataPropertyName = "Estado";

            DgRoles.DataSource = bs;
            #endregion
            
            //DgRoles.DataSource = RolerServices.GetAllData();
            #region armadoCombo
            Funcionalidad funcionalidadTodos = new Funcionalidad { Descripcion = "--Todas--", IdFuncionalidad = 0 };
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>(RolerServices.GetAllFuncionalidades());
            funcionalidades.Add(funcionalidadTodos);
            funcionalidades = funcionalidades.OrderBy(x => x.IdFuncionalidad).ToList();

            ComboFuncionalidad.DataSource = funcionalidades;
            ComboFuncionalidad.DisplayMember = "Descripcion";
            ComboFuncionalidad.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion
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

            BindingList<Rol> dataSource = new BindingList<Rol>(RolerServices.FindRoles(filtroNombre, filtroFuncionalidad, filtroEstado));
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;

            DgRoles.DataSource = bs;
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            BindingList<Rol> dataSource = new BindingList<Rol>();
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;

            DgRoles.DataSource = bs;
        }
    }
}
