using System;
using System.ComponentModel;
using System.Windows.Forms;
using MercadoEnvio.ComprarOfertar;
using MercadoEnvio.Entidades;
using MercadoEnvio.Properties;
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
            BtnSeleccionarRubro.Enabled = FormPublicacion != null;
            #region ArmadoGrillaRubros
            DgRubros.AutoGenerateColumns = false;
            BindingList<Rubro> dataSource = new BindingList<Rubro>(RubrosServices.GetAllData());
            BindingSource bs = new BindingSource {DataSource = dataSource};

            DgRubros.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DescripcionCorta", HeaderText = Resources.DescripcionCorta, Name = "DescripcionCorta" });
            DgRubros.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DescripcionLarga", HeaderText = Resources.DescripcionLarga, Name = "DescripcionLarga" });
            DgRubros.DataSource = bs;
            #endregion
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            BindingList<Rubro> dataSource = new BindingList<Rubro>();
            BindingSource bs = new BindingSource {DataSource = dataSource};

            DgRubros.DataSource = bs;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string filtroDescripcionCorta = TxtFiltroDescripcionCorta.Text;
            string filtroDescripcionLarga = TxtFiltroDescripcionLarga.Text;

            BindingList<Rubro> dataSource = new BindingList<Rubro>(RubrosServices.FindRubros(filtroDescripcionCorta,filtroDescripcionLarga));
            BindingSource bs = new BindingSource { DataSource = dataSource };

            DgRubros.DataSource = bs;
        }

        private void BtnSeleccionarRubro_Click(object sender, EventArgs e)
        {
            Rubro rubroSeleccionado = new Rubro();

            if (DgRubros.SelectedRows.Count > 0)
            {
                BindingSource bs = DgRubros.DataSource as BindingSource;

                if (bs != null)
                    rubroSeleccionado = (Rubro)bs.List[bs.Position];
            }

            FormPublicacion.RubroSeleccionado = rubroSeleccionado;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
