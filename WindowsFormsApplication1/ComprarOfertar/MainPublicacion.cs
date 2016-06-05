using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.ComprarOfertar
{
    public partial class MainPublicacion : Form
    {
        public MainPublicacion()
        {
            InitializeComponent();
        }

        private void MainPublicacion_Load(object sender, EventArgs e)
        {
            #region armadoDeGrillaPublicaciones
            BindingList<Publicacion> dataSource = new BindingList<Publicacion>(PublicacionesServices.GetAllData());
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;

            DgPublicaciones.AutoGenerateColumns = false;
            DgPublicaciones.ColumnCount = 6;

            DgPublicaciones.Columns[0].HeaderText = "Codigo Publicación";
            DgPublicaciones.Columns[0].Name = "CodigoPublicacion";
            DgPublicaciones.Columns[0].DataPropertyName = "CodigoPublicacion";

            DgPublicaciones.Columns[1].HeaderText = "Descripción";
            DgPublicaciones.Columns[1].Name = "Descripcion";
            DgPublicaciones.Columns[1].DataPropertyName = "Descripcion";

            DgPublicaciones.Columns[2].HeaderText = "Stock";
            DgPublicaciones.Columns[2].Name = "Stock";
            DgPublicaciones.Columns[2].DataPropertyName = "Stock";

            DgPublicaciones.Columns[3].HeaderText = "Fecha Inicio";
            DgPublicaciones.Columns[3].Name = "FechaInicio";
            DgPublicaciones.Columns[3].DataPropertyName = "FechaInicio";

            DgPublicaciones.Columns[4].HeaderText = "Fecha Vencimiento";
            DgPublicaciones.Columns[4].Name = "FechaVencimiento";
            DgPublicaciones.Columns[4].DataPropertyName = "FechaVencimiento";

            DgPublicaciones.Columns[5].HeaderText = "Precio";
            DgPublicaciones.Columns[5].Name = "Precio";
            DgPublicaciones.Columns[5].DataPropertyName = "Precio";

            DgPublicaciones.DataSource = bs;
            #endregion
        }
    }
}
