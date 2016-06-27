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
            this.Close();
        }

        private void ListadoComprados_Load(object sender, EventArgs e)
        {
            LabelRubro.Text = Resources.ResultadosRubro + Rubro.DescripcionCorta;

            #region armadoDeGrillaClientes
            BindingList<Cliente> dataSource = new BindingList<Cliente>(ListadoServices.GetListadoClientesProductosComprados(Trimestre, Anio, Rubro));
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;

            DgClientes.AutoGenerateColumns = false;
            DgClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdUsuario", HeaderText = "IdUsuario", Name = "IdUsuario" });
            DgClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NombreUsuario", HeaderText = Resources.Nombre, Name = "NombreUsuario" });
            DgClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CantidadProductosComprados", HeaderText = "Cantidad", Name = "Cantidad" });

            DgClientes.DataSource = bs;
            #endregion
        }
    }
}
