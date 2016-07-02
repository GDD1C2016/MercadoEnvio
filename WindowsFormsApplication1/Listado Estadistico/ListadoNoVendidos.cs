using System;
using System.ComponentModel;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
using MercadoEnvio.Properties;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.Listado_Estadistico
{
    public partial class ListadoNoVendidos : Form
    {
        public int Trimestre { get; set; }
        public int Anio { get; set; }
        public int IdVisibilidad { get; set; }

        public ListadoNoVendidos()
        {
            InitializeComponent();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ListadoNoVendidos_Load(object sender, EventArgs e)
        {
            #region armadoDeGrillaVendedores
            BindingList<Vendedor> dataSource = new BindingList<Vendedor>(ListadosServices.GetListadoVendedoresProductosNoVendidos(Trimestre,Anio,IdVisibilidad));
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;

            DgVendedores.AutoGenerateColumns = false;
            DgVendedores.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdUsuario", HeaderText = Resources.IdUsuario, Name = "IdUsuario" });
            DgVendedores.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NombreUsuario", HeaderText = Resources.NombreUsuario, Name = "NombreUsuario" });
            DgVendedores.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cantidad", HeaderText = Resources.Cantidad, Name = "Cantidad" });
            DgVendedores.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "VisibilidadDescripcion", HeaderText = Resources.Visibilidad, Name = "VisibilidadDescripcion" });
            DgVendedores.DataSource = bs;
            #endregion
        }
    }
}
