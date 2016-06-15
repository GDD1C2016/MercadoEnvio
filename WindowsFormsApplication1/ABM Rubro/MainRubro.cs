using System;
using System.ComponentModel;
using System.Windows.Forms;
using MercadoEnvio.ComprarOfertar;
using MercadoEnvio.Entidades;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.ABM_Rubro
{
    public partial class MainRubro : Form
    {
        public Usuario Usuario { get; set; }
        public MainPublicacion FormPublicacion { get; set; }
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

        private void BtnSeleccionarRubro_Click(object sender, EventArgs e)
        {
            Rubro rubroSeleccionado = new Rubro();

            if (DgRubros.SelectedRows.Count > 0)
            {
                BindingSource bs = new BindingSource();
                bs = DgRubros.DataSource as BindingSource;
                rubroSeleccionado = (Rubro)bs.List[bs.Position];
            }

            FormPublicacion.RubroSeleccionado = rubroSeleccionado;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
