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

namespace MercadoEnvio.Calificar
{
    public partial class MainCalificaciones : Form
    {
        public Usuario Usuario { get; set; }
        public MainCalificaciones()
        {
            InitializeComponent();
        }

        private void MainCalificaciones_Load(object sender, EventArgs e)
        {
            #region armadoDeGrillaUltimas5
            

            DgUltimas5.AutoGenerateColumns = false;
            DgUltimas5.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DescripcionCompra", HeaderText = "Articulo", Name = "DescripcionCompra" });
            DgUltimas5.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CantEstrellas", HeaderText = "Calificación", Name = "CantEstrellas" });
            DgUltimas5.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Observaciones", HeaderText = "Observación", Name = "Observaciones" });

            DgUltimas5.DataSource = GetUltimasCalificaciones();
            #endregion

            #region armadoDeGrillaPendientes
           
            DgPendientes.AutoGenerateColumns = false;
            DgPendientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdCompra", HeaderText = "IdCompra", Name = "IdCompra" });
            DgPendientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DescripcionPublicacion", HeaderText = "Descripción", Name = "DescripcionPublicacion" });
            DgPendientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Vendedor", HeaderText = "Vendedor", Name = "Vendedor" });
            DgPendientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Fecha", HeaderText = "Fecha", Name = "Fecha" });
            DgPendientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TipoPublicacion", HeaderText = "Tipo de Publicación", Name = "TipoPublicacion" });
            DgPendientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cantidad", HeaderText = "Cantidad", Name = "Cantidad" });

            DgPendientes.DataSource = GetPendientes();
            #endregion

            #region llenadoDatosUsuario

            LabelReputacionTxt.Text = Usuario.Reputacion.ToString();
            LabelUsuarioTxt.Text = Usuario.UserName;

            #endregion

        }

        private BindingSource GetPendientes()
        {
            List<Compra> listAux = new List<Compra>(ComprasServices.GetAllData());
            BindingList<Compra> list = new BindingList<Compra>(listAux);
            BindingSource bsPendientes = new BindingSource();
            bsPendientes.DataSource = list;
            return bsPendientes;
        }
        private BindingSource GetUltimasCalificaciones()
        {
            BindingList<Calificacion> dataSourceUltimas5 = new BindingList<Calificacion>(CalificacionesServices.GetUltimas(5));
            BindingSource bsUltimas5 = new BindingSource();
            bsUltimas5.DataSource = dataSourceUltimas5;

            return bsUltimas5;
        }

        private void BtnCalificar_Click(object sender, EventArgs e)
        {
            Compra compraSeleccionada = new Compra();

            if (DgPendientes.SelectedRows.Count > 0)
            {
                BindingSource bs = DgPendientes.DataSource as BindingSource;
                if (bs != null)
                    compraSeleccionada = (Compra)bs.List[bs.Position];
            }

            var calificarDialog = new CalificarVendedor();
            calificarDialog.CompraSeleccionada = compraSeleccionada;
            var result = calificarDialog.ShowDialog();

            if (result.Equals(DialogResult.OK))
            {
                DgUltimas5.DataSource = GetUltimasCalificaciones();
                DgPendientes.DataSource = GetPendientes();
            }
        }
    }
}
