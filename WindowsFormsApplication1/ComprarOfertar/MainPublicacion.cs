using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using MercadoEnvio.ABM_Rubro;
using MercadoEnvio.Entidades;
using MercadoEnvio.Servicios;
using System.Collections.Generic;
using System.Linq;
using MercadoEnvio.Properties;

namespace MercadoEnvio.ComprarOfertar
{
    public partial class MainPublicacion : Form
    {
        #region variablesPaginador
        private int CurrentPage = 1;
        int PagesCount = 1;
        int pageRows = 12;
        BindingList<Publicacion> Baselist = null;
        BindingList<Publicacion> Templist = null;
        #endregion

        public Rubro RubroSeleccionado { get; set; }
        public List<Rubro> RubrosFiltro { get; set; } 

        public MainPublicacion()
        {
            InitializeComponent();
            RubrosFiltro = new List<Rubro>();
        }

        private void MainPublicacion_Load(object sender, EventArgs e)
        {
            #region armadoDeGrillaPublicaciones
            
            DgPublicaciones.AutoGenerateColumns = false;
            DgPublicaciones.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdPublicacion", HeaderText = "Codigo Publicación", Name = "CodigoPublicacion" });
            DgPublicaciones.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Descripcion", HeaderText = "Descripción", Name = "Descripcion" });
            DgPublicaciones.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Stock", HeaderText = "Stock", Name = "Stock" });
            DgPublicaciones.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FechaInicio", HeaderText = "Fecha Inicio", Name = "FechaInicio" });
            DgPublicaciones.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FechaVencimiento", HeaderText = "Fecha Vencimiento", Name = "FechaVencimiento" });
            DgPublicaciones.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Precio", HeaderText = "Precio", Name = "Precio" });

            Baselist = FillDataforGrid();
            PagesCount = Convert.ToInt32(Math.Ceiling(Baselist.Count * 1.0 / pageRows));

            CurrentPage = 1;
            RefreshPagination();
            RebindGridForPageChange();
            #endregion
        }

        private BindingList<Publicacion> FillDataforGrid()
        {
            List<Publicacion> listAux = new List<Publicacion>(PublicacionesServices.GetAllData().OrderByDescending(x=>x.Visibilidad.Precio).ToList());
            BindingList<Publicacion> list = new BindingList<Publicacion>(listAux);
            return list;
        }

        #region MetodosPaginador
        private void RebindGridForPageChange()
        {
            int datasourcestartIndex = (CurrentPage - 1) * pageRows;
            Templist = new BindingList<Publicacion>();
            for (int i = datasourcestartIndex; i < datasourcestartIndex + pageRows; i++)
            {
                if (i >= Baselist.Count)
                    break;

                Templist.Add(Baselist[i]);
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = Templist;

            //DgPublicaciones.DataSource = Templist;
            DgPublicaciones.DataSource = bs;
            DgPublicaciones.Refresh();
        }

        private void RefreshPagination()
        {
            ToolStripButton[] items = new ToolStripButton[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripButton4, toolStripButton5 };

            //pageStartIndex contains the first button number of pagination.
            int pageStartIndex = 1;

            if (PagesCount > 5 && CurrentPage > 2)
                pageStartIndex = CurrentPage - 2;

            if (PagesCount > 5 && CurrentPage > PagesCount - 2)
                pageStartIndex = PagesCount - 4;

            for (int i = pageStartIndex; i < pageStartIndex + 5; i++)
            {
                if (i > PagesCount)
                {
                    items[i - pageStartIndex].Visible = false;
                }
                else
                {
                    //Changing the page numbers
                    items[i - pageStartIndex].Text = i.ToString(CultureInfo.InvariantCulture);

                    //Setting the Appearance of the page number buttons
                    if (i == CurrentPage)
                    {
                        items[i - pageStartIndex].BackColor = Color.Black;
                        items[i - pageStartIndex].ForeColor = Color.White;
                    }
                    else
                    {
                        items[i - pageStartIndex].BackColor = Color.White;
                        items[i - pageStartIndex].ForeColor = Color.Black;
                    }
                }
            }

            //Enabling or Disalbing pagination first, last, previous , next buttons
            if (CurrentPage == 1)
                btnBackward.Enabled = btnFirst.Enabled = false;
            else
                btnBackward.Enabled = btnFirst.Enabled = true;

            if (CurrentPage == PagesCount)
                btnForward.Enabled = btnLast.Enabled = false;

            else
                btnForward.Enabled = btnLast.Enabled = true;
        }

        private void ToolStripButtonClick(object sender, EventArgs e)
        {
            ToolStripButton ToolStripButton = ((ToolStripButton)sender);

            //Determining the current page
            if (ToolStripButton == btnBackward)
                CurrentPage--;
            else if (ToolStripButton == btnForward)
                CurrentPage++;
            else if (ToolStripButton == btnLast)
                CurrentPage = PagesCount;
            else if (ToolStripButton == btnFirst)
                CurrentPage = 1;
            else
                CurrentPage = Convert.ToInt32(ToolStripButton.Text, CultureInfo.InvariantCulture);

            if (CurrentPage < 1)
                CurrentPage = 1;
            else if (CurrentPage > PagesCount)
                CurrentPage = PagesCount;

            RebindGridForPageChange();
            RefreshPagination();

        }
        #endregion

        private void BtnSeleccionarRubro_Click(object sender, EventArgs e)
        {
            var mainRubro = new MainRubro();
            mainRubro.FormPublicacion = this;
            var res = mainRubro.ShowDialog();

            if (res.Equals(DialogResult.OK))
            {
                RubrosFiltro.Add(RubroSeleccionado);

                TxtFiltroRubro.Text = string.IsNullOrEmpty(TxtFiltroRubro.Text)
                    ? RubroSeleccionado.DescripcionCorta
                    : TxtFiltroRubro.Text + "; " + RubroSeleccionado.DescripcionCorta;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string filtroDescripcion = string.Empty;
            filtroDescripcion = TxtFiltroDescripcion.Text;
            List<Publicacion> listAux = new List<Publicacion>(PublicacionesServices.FindPublicaciones(filtroDescripcion, RubrosFiltro).OrderByDescending(x => x.Visibilidad.Precio).ToList());

            BindingList<Publicacion> dataSource = new BindingList<Publicacion>(listAux);
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;

            DgPublicaciones.DataSource = bs;
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            BindingList<Publicacion> dataSource = new BindingList<Publicacion>();
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;

            DgPublicaciones.DataSource = bs;
        }

        private void BtnComprar_Click(object sender, EventArgs e)
        {
            Publicacion publicacionSeleccionada = new Publicacion();

            if (DgPublicaciones.SelectedRows.Count > 0)
            {
                BindingSource bs = new BindingSource();
                bs = (BindingSource) DgPublicaciones.DataSource;
                //BindingList<Publicacion> bs = DgPublicaciones.DataSource as BindingList<Publicacion>;
                if (bs != null)
                {
                    publicacionSeleccionada = (Publicacion) bs[DgPublicaciones.SelectedRows[0].Index];
                }
            }

            var comprarDialog = new ComprarDialog();
            comprarDialog.PublicacionSeleccionada = publicacionSeleccionada;
            var res = comprarDialog.ShowDialog();

            if (res.Equals(DialogResult.OK))
            {
                
            }
        }
    }
}
