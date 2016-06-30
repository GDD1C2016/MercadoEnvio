using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
using MercadoEnvio.Properties;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.Facturas
{
    public partial class MainFacturas : Form
    {
        #region variablesPaginador
        private int _currentPage = 1;
        int _pagesCount = 1;
        private const int PageRows = 12;
        BindingList<Factura> _baselist;
        BindingList<Factura> _templist;
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
            DgFacturas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdFactura", HeaderText = Resources.IdFactura, Name = "IdFactura" });
            DgFacturas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdPublicacion", HeaderText = Resources.IdPublicacion, Name = "IdPublicacion" });
            DgFacturas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Fecha", HeaderText = Resources.Fecha, Name = "Fecha" });
            DgFacturas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Total", HeaderText = Resources.Total, Name = "Total" });

            _baselist = FillDataforGrid();
            _pagesCount = Convert.ToInt32(Math.Ceiling(_baselist.Count * 1.0 / PageRows));

            _currentPage = 1;
            RefreshPagination();
            RebindGridForPageChange();
            #endregion

            #region armadoComboDetalles
            const string detalleTodos = "--Todos--";
            const string detalleEnvio = "Comisión por Envío";
            const string detallePublicacion = "Comisión por Publicación";
            const string detalleVenta = "Comisión por Venta";

            List<string> detalles = new List<string> {detalleTodos, detalleEnvio, detallePublicacion, detalleVenta};

            ComboDetalles.DataSource = detalles;            
            ComboDetalles.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion
        }

        private BindingList<Factura> FillDataforGrid()
        {
            BindingList<Factura> list = new BindingList<Factura>(ComprasServices.GetFacturas(Usuario.IdUsuario));
            return list;
        }

        #region MetodosPaginador
        private void RebindGridForPageChange()
        {
            int datasourcestartIndex = (_currentPage - 1) * PageRows;
            _templist = new BindingList<Factura>();
            for (int i = datasourcestartIndex; i < datasourcestartIndex + PageRows; i++)
            {
                if (i >= _baselist.Count)
                    break;

                _templist.Add(_baselist[i]);
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = _templist;

            DgFacturas.DataSource = bs;
            DgFacturas.Refresh();
        }

        private void RefreshPagination()
        {
            ToolStripButton[] items = new ToolStripButton[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripButton4, toolStripButton5 };

            //pageStartIndex contains the first button number of pagination
            int pageStartIndex = 1;

            if (_pagesCount > 5 && _currentPage > 2)
                pageStartIndex = _currentPage - 2;

            if (_pagesCount > 5 && _currentPage > _pagesCount - 2)
                pageStartIndex = _pagesCount - 4;

            for (int i = pageStartIndex; i < pageStartIndex + 5; i++)
            {
                if (i > _pagesCount)
                {
                    items[i - pageStartIndex].Visible = false;
                }
                else
                {
                    //Changing the page numbers
                    items[i - pageStartIndex].Text = i.ToString(CultureInfo.InvariantCulture);

                    //Setting the appearance of the page number buttons
                    if (i == _currentPage)
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
            if (_currentPage == 1)
                btnBackward.Enabled = btnFirst.Enabled = false;
            else
                btnBackward.Enabled = btnFirst.Enabled = true;

            if (_currentPage == _pagesCount)
                btnForward.Enabled = btnLast.Enabled = false;

            else
                btnForward.Enabled = btnLast.Enabled = true;
        }

        private void ToolStripButtonClick(object sender, EventArgs e)
        {
            ToolStripButton toolStripButton = ((ToolStripButton)sender);

            //Determining the current page
            if (toolStripButton == btnBackward)
                _currentPage--;
            else if (toolStripButton == btnForward)
                _currentPage++;
            else if (toolStripButton == btnLast)
                _currentPage = _pagesCount;
            else if (toolStripButton == btnFirst)
                _currentPage = 1;
            else
                _currentPage = Convert.ToInt32(toolStripButton.Text, CultureInfo.InvariantCulture);

            if (_currentPage < 1)
                _currentPage = 1;
            else if (_currentPage > _pagesCount)
                _currentPage = _pagesCount;

            RebindGridForPageChange();
            RefreshPagination();
        }
        #endregion

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            BindingList<Factura> dataSource = new BindingList<Factura>();
            BindingSource bs = new BindingSource {DataSource = dataSource};

            DgFacturas.DataSource = bs;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            DateTime filtroFechaDesde = DatePickerFechaDesde.Value;
            DateTime filtroFechaHasta = DatePickerFechaHasta.Value;

            decimal filtroImporteDesde = string.IsNullOrEmpty(TxtImporteDesde.Text) ? 0 : Convert.ToDecimal(TxtImporteDesde.Text);
            decimal filtroImporteHasta = string.IsNullOrEmpty(TxtImporteHasta.Text) ? 0 : Convert.ToDecimal(TxtImporteHasta.Text);
            string filtroDetallesFactura = ((string)ComboDetalles.SelectedItem).Equals("--Todos--", StringComparison.CurrentCultureIgnoreCase) ? String.Empty : ((string)ComboDetalles.SelectedItem); 
            string filtroDirigidaA = TxtDirigidaA.Text;

            List<Factura> listAux = new List<Factura>(ComprasServices.FindFacturas(filtroFechaDesde,filtroFechaHasta,filtroImporteDesde,filtroImporteHasta,filtroDetallesFactura,filtroDirigidaA));

            BindingList<Factura> dataSource = new BindingList<Factura>(listAux);
            BindingSource bs = new BindingSource {DataSource = dataSource};

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
