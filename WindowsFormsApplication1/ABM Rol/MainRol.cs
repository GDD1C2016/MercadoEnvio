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
            #region armadoDeGrillaRol
            BindingList<Rol> dataSource = new BindingList<Rol>(RolesServices.GetAllData());
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

            #region armadoComboEstado
            Estado estadoTodos = new Estado { Descripcion = "--Todos--" };
            Estado estadoHabilitado = new Estado { Valor = true };
            Estado estadoDeshabilitado = new Estado { Valor = false };
            List<Estado> estados = new List<Estado>();
            estados.Add(estadoTodos);
            estados.Add(estadoHabilitado);
            estados.Add(estadoDeshabilitado);

            ComboEstado.DataSource = estados;
            ComboEstado.DisplayMember = "Descripcion";
            ComboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion

            #region armadoComboFuncionalidad
            Funcionalidad funcionalidadTodas = new Funcionalidad { IdFuncionalidad = 0, Descripcion = "--Todas--" };
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>(RolesServices.GetAllFuncionalidades());
            funcionalidades.Add(funcionalidadTodas);
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
            filtroEstado = ((Estado) ComboEstado.SelectedItem).Descripcion;

            BindingList<Rol> dataSource = new BindingList<Rol>(RolesServices.FindRoles(filtroNombre, filtroFuncionalidad, filtroEstado));
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

        private void TxtFiltroNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
