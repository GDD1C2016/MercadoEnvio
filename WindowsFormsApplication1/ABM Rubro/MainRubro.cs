using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.ABM_Rubro
{
    public partial class MainRubro : Form
    {
        public MainRubro(bool vieneDeMainPublicacion)
        {
            InitializeComponent();

            if (vieneDeMainPublicacion)
            {
                BtnEditar.Visible = false;
                BtnBorrar.Visible = false;
                BtnAgregar.Visible = false;
                BtnSeleccionarRubro.Visible = true;
            }
        }

        private void MainRubro_Load(object sender, EventArgs e)
        {
            #region ArmadoGrillaRubros
            DgRubros.AutoGenerateColumns = false;
            BindingList<Rubro> dataSource = new BindingList<Rubro>(RubrosServices.GetAllData());
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;

            DgRubros.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DescripcionCorta", HeaderText = "Descripción Corta", Name = "DescripcionCorta" });
            DgRubros.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DescripcionLarga", HeaderText = "Descripción Larga", Name = "DescripcionLarga" });
            DgRubros.DataSource = bs;

            #endregion
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            BindingList<Rubro> dataSource = new BindingList<Rubro>();
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;

            DgRubros.DataSource = bs;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string filtroDescripcionCorta = string.Empty;
            string filtroDescripcionLarga = string.Empty;

            filtroDescripcionCorta = TxtFiltroDescripcionCorta.Text;
            filtroDescripcionLarga = TxtFiltroDescripcionLarga.Text;

            BindingList<Rubro> dataSource = new BindingList<Rubro>(RubrosServices.FindRubros(filtroDescripcionCorta,filtroDescripcionLarga));
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;

            DgRubros.DataSource = bs;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            var altaRubro = new AltaRubro(new Rubro());
            altaRubro.ShowDialog();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Rubro rubroSeleccionado = new Rubro();

            if (DgRubros.SelectedRows.Count > 0)
            {
                BindingSource bs = new BindingSource();
                bs = DgRubros.DataSource as BindingSource;
                rubroSeleccionado = (Rubro)bs.List[bs.Position];
            }

            var altaRubro = new AltaRubro(rubroSeleccionado);
            altaRubro.ShowDialog();
        }

        private void BtnSeleccionarRubro_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
