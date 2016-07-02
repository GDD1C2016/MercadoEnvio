using System;
using System.ComponentModel;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
using MercadoEnvio.Properties;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.Listado_Estadistico
{
    public partial class ListadoFacturas : Form
    {
        public int Trimestre { get; set; }
        public int Anio { get; set; }
        public ListadoFacturas()
        {
            InitializeComponent();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ListadoFacturas_Load(object sender, EventArgs e)
        {
            #region armadoDeGrillaVendedores
            BindingList<Vendedor> dataSource = new BindingList<Vendedor>(ListadosServices.GetListadoVendedoresFacturas(Trimestre, Anio));
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;

            DgVendedores.AutoGenerateColumns = false;
            DgVendedores.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdUsuario", HeaderText = Resources.IdUsuario, Name = "IdUsuario" });
            DgVendedores.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NombreUsuario", HeaderText = Resources.NombreUsuario, Name = "NombreUsuario" });
            DgVendedores.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cantidad", HeaderText = Resources.Cantidad, Name = "Cantidad" });
            DgVendedores.DataSource = bs;
            #endregion
        }
    }
}
