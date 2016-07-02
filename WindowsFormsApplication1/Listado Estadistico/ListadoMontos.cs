using System;
using System.ComponentModel;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
using MercadoEnvio.Properties;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.Listado_Estadistico
{
    public partial class ListadoMontos : Form
    {
        public int Trimestre { get; set; }
        public int Anio { get; set; }
        public ListadoMontos()
        {
            InitializeComponent();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ListadoMontos_Load(object sender, EventArgs e)
        {
            #region armadoDeGrillaVendedores
            BindingList<Vendedor> dataSource = new BindingList<Vendedor>(ListadosServices.GetListadoVendedoresMontos(Trimestre, Anio));
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;

            DgVendedores.AutoGenerateColumns = false;
            DgVendedores.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdUsuario", HeaderText = Resources.IdUsuario, Name = "IdUsuario" });
            DgVendedores.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NombreUsuario", HeaderText = Resources.NombreUsuario, Name = "NombreUsuario" });
            DgVendedores.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdFactura", HeaderText = Resources.IdFactura, Name = "IdFactura" });
            DgVendedores.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MontoFacturado", HeaderText = Resources.MontoFacturado, Name = "MontoFacturado" });

            DgVendedores.DataSource = bs;
            #endregion
        }
    }
}
