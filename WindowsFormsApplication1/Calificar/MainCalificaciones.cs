using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
using MercadoEnvio.Properties;
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
            DgUltimas5.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DescripcionCompra", HeaderText = Resources.Articulo, Name = "DescripcionCompra" });
            DgUltimas5.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CantEstrellas", HeaderText = Resources.Calificacion, Name = "CantEstrellas" });
            DgUltimas5.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Observaciones", HeaderText = Resources.Observacion, Name = "Observaciones" });

            DgUltimas5.DataSource = GetUltimasCalificaciones();
            #endregion

            #region armadoDeGrillaPendientes          
            DgPendientes.AutoGenerateColumns = false;
            DgPendientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdCompra", HeaderText = Resources.IdCompra, Name = "IdCompra" });
            DgPendientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DescripcionPublicacion", HeaderText = Resources.Descripcion, Name = "DescripcionPublicacion" });
            DgPendientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Vendedor", HeaderText = Resources.Vendedor, Name = "Vendedor" });
            DgPendientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Fecha", HeaderText = Resources.Fecha, Name = "Fecha" });
            DgPendientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TipoPublicacion", HeaderText = Resources.TipoPublicacion, Name = "TipoPublicacion" });
            DgPendientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cantidad", HeaderText = Resources.Cantidad, Name = "Cantidad" });

            DgPendientes.DataSource = GetPendientes();
            #endregion

            #region llenadoDatosUsuario
            LabelUsuarioTxt.Text = Usuario.UserName;
            #endregion
        }

        private BindingSource GetPendientes()
        {
            List<Compra> listAux = new List<Compra>(ComprasServices.GetComprasPendientesDeCalificacion(Usuario.IdUsuario));
            BindingList<Compra> list = new BindingList<Compra>(listAux);
            BindingSource bsPendientes = new BindingSource {DataSource = list};
            return bsPendientes;
        }

        private BindingSource GetUltimasCalificaciones()
        {
            BindingList<Calificacion> dataSourceUltimas5 = new BindingList<Calificacion>(CalificacionesServices.GetUltimas(Usuario.IdUsuario, 5));
            BindingSource bsUltimas5 = new BindingSource {DataSource = dataSourceUltimas5};

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

                var calificarDialog = new CalificarVendedor { CompraSeleccionada = compraSeleccionada };
                var result = calificarDialog.ShowDialog();

                if (result.Equals(DialogResult.OK))
                {
                    DgUltimas5.DataSource = GetUltimasCalificaciones();
                    DgPendientes.DataSource = GetPendientes();
                }
            }
        }
    }
}
