using System;
using System.ComponentModel;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
using MercadoEnvio.Properties;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.Listado_Estadistico
{
    public partial class ListadoComprados : Form
    {
        public int Trimestre { get; set; }
        public int Anio { get; set; }
        public Rubro Rubro { get; set; }
        public ListadoComprados()
        {
            InitializeComponent();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ListadoComprados_Load(object sender, EventArgs e)
        {
            LabelRubro.Text = Resources.ResultadosRubro + Rubro.DescripcionCorta;

            #region armadoDeGrillaClientes
            BindingList<Cliente> dataSource = new BindingList<Cliente>(ListadosServices.GetListadoClientesProductosComprados(Trimestre, Anio, Rubro));
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;

            DgClientes.AutoGenerateColumns = false;
            DgClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdUsuario", HeaderText = Resources.IdUsuario, Name = "IdUsuario" });
            DgClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NombreUsuario", HeaderText = Resources.Nombre, Name = "NombreUsuario" });
            DgClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CantidadProductosComprados", HeaderText = Resources.Cantidad, Name = "Cantidad" });
            DgClientes.Columns.Add(new DataGridViewTextBoxColumn{DataPropertyName = "RubroDescripcion", HeaderText = Resources.Rubro, Name = "RubroDescripcion"});

            DgClientes.DataSource = bs;
            #endregion
        }
    }
}
