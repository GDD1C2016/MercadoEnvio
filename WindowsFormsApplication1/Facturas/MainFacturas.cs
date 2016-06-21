using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
using MercadoEnvio.Properties;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.Facturas
{
    public partial class MainFacturas : Form
    {
        #region variablesPaginador
        private int CurrentPage = 1;
        int PagesCount = 1;
        int PageRows = 12;
        BindingList<Factura> Baselist = null;
        BindingList<Factura> Templist = null;
        #endregion

        public Usuario Usuario { get; set; }

        public MainFacturas()
        {
            InitializeComponent();
        }

        private void MainFacturas_Load(object sender, EventArgs e)
        {
            #region armadoDeGrillaPublicaciones

            DgFacturas.AutoGenerateColumns = false;
            DgFacturas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdFactura", HeaderText = "IdFactura", Name = "IdFactura" });
            DgFacturas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdPublicacion", HeaderText = "IdPublicacion", Name = "IdPublicacion" });
            DgFacturas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Fecha", HeaderText = "Fecha", Name = "Fecha" });
            DgFacturas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Total", HeaderText = "Total", Name = "Total" });

            Baselist = FillDataforGrid();
            PagesCount = Convert.ToInt32(Math.Ceiling(Baselist.Count * 1.0 / PageRows));

            CurrentPage = 1;
            RefreshPagination();
            RebindGridForPageChange();
            #endregion
        }

        private BindingList<Factura> FillDataforGrid()
        {
            BindingList<Factura> list = new BindingList<Factura>(ComprasServices.GetFacturas());
            return list;
        }

        #region MetodosPaginador
        private void RebindGridForPageChange()
        {
            int datasourcestartIndex = (CurrentPage - 1) * PageRows;
            Templist = new BindingList<Factura>();
            for (int i = datasourcestartIndex; i < datasourcestartIndex + PageRows; i++)
            {
                if (i >= Baselist.Count)
                    break;

                Templist.Add(Baselist[i]);
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = Templist;

            DgFacturas.DataSource = bs;
            DgFacturas.Refresh();
        }

        private void RefreshPagination()
        {
            ToolStripButton[] items = new ToolStripButton[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripButton4, toolStripButton5 };

            //pageStartIndex contains the first button number of pagination
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

                    //Setting the appearance of the page number buttons
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

            //Enabling or disabling pagination first, last, previous, next buttons
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
            ToolStripButton toolStripButton = ((ToolStripButton)sender);

            //Determining the current page
            if (toolStripButton == btnBackward)
                CurrentPage--;
            else if (toolStripButton == btnForward)
                CurrentPage++;
            else if (toolStripButton == btnLast)
                CurrentPage = PagesCount;
            else if (toolStripButton == btnFirst)
                CurrentPage = 1;
            else
                CurrentPage = Convert.ToInt32(toolStripButton.Text, CultureInfo.InvariantCulture);

            if (CurrentPage < 1)
                CurrentPage = 1;
            else if (CurrentPage > PagesCount)
                CurrentPage = PagesCount;

            RebindGridForPageChange();
            RefreshPagination();
        }
        #endregion

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            BindingList<Factura> dataSource = new BindingList<Factura>();
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;

            DgFacturas.DataSource = bs;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            DateTime filtroFechaDesde = new DateTime();
            filtroFechaDesde = DatePickerFechaDesde.Value;

            DateTime filtroFechaHasta = new DateTime();
            filtroFechaHasta = DatePickerFechaHasta.Value;

            decimal filtroImporteDesde = Convert.ToDecimal(TxtImporteDesde.Text);
            decimal filtroImporteHasta = Convert.ToDecimal(TxtImporteHasta.Text);
            string filtroDetallesFactura = TxtDetalles.Text;
            string filtroDirigidaA = TxtDirigidaA.Text;

            List<Factura> listAux = new List<Factura>(ComprasServices.FindFacturas(filtroFechaDesde,filtroFechaHasta,filtroImporteDesde,filtroImporteHasta,filtroDetallesFactura,filtroDirigidaA));

            BindingList<Factura> dataSource = new BindingList<Factura>(listAux);
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;

            DgFacturas.DataSource = bs;
        }

        private void TxtImporteDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != decimalSeparator))
                e.Handled = true;

            if ((e.KeyChar == decimalSeparator) && ((sender as TextBox).Text.IndexOf(decimalSeparator) > -1))
                e.Handled = true;
        }
    }
}
