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
        public MainRubro()
        {
            InitializeComponent();
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

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
