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
            this.Close();
        }

        private void ListadoNoVendidos_Load(object sender, EventArgs e)
        {
            #region armadoDeGrillaVendedores
            BindingList<Vendedor> dataSource = new BindingList<Vendedor>(ListadoServices.GetListadoVendedoresProductosNoVendidos(Trimestre,Anio,IdVisibilidad));
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;

            DgVendedores.AutoGenerateColumns = false;
            DgVendedores.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdUsuario", HeaderText = "IdUsuario", Name = "IdUsuario" });
            DgVendedores.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Descripcion", HeaderText = "Descripcion", Name = "Descripcion" });
            DgVendedores.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "VisibilidadDescripcion", HeaderText = "Visibilidad", Name = "VisibilidadDescripcion" });
            DgVendedores.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Documento", HeaderText = "Documento", Name = "Documento" });
            DgVendedores.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cantidad", HeaderText = "Cantidad", Name = "Cantidad" });

            DgVendedores.DataSource = bs;
            #endregion
        }
    }
}
