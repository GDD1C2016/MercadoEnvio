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
        private static int TotalRecords = 0;
        private static int PageSize = 10;
        
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
            TotalRecords = bs.List.Count;

            bindingPaginador.BindingSource = sourcePaginador;
            sourcePaginador.CurrentChanged += new EventHandler(sourcePaginador_CurrentChanged);
            sourcePaginador.DataSource = new PageOffsetList();

            DgPublicaciones.AutoGenerateColumns = false;
            //DgPublicaciones.ColumnCount = 7;

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

            DgPublicaciones.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Index" });

            DgPublicaciones.DataSource = bs;
            #endregion
        }

        private void sourcePaginador_CurrentChanged(object sender, EventArgs e)
        {
            int offset = (int)sourcePaginador.Current;
            var records = new List<Record>();
            for (int i = offset; i < offset + PageSize && i < TotalRecords; i++)
                records.Add(new Record { Index = i });
            DgPublicaciones.DataSource = records;
        }

        class Record
        {
            public int Index { get; set; }
        }

        class PageOffsetList : IListSource
        {
            public bool ContainsListCollection { get; protected set; }

            public System.Collections.IList GetList()
            {
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < TotalRecords; offset += PageSize)
                    pageOffsets.Add(offset);
                return pageOffsets;
            }
        }
    }
}
