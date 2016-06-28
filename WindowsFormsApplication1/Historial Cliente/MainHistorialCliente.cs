using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
using MercadoEnvio.Properties;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.Historial_Cliente
{
    public partial class MainHistorialCliente : Form
    {
        #region variablesPaginador
        private int _currentPage = 1;
        private int _pagesCount = 1;
        private const int PageRows = 12;
        private BindingList<Compra> _baselist;
        private BindingList<Compra> _templist;
        #endregion

        public Usuario Usuario { get; set; }

        public MainHistorialCliente()
        {
            InitializeComponent();
        }

        private void MainHistorialCliente_Load(object sender, EventArgs e)
        {
            #region armadoDeGrillaCompras
            DgCompras.AutoGenerateColumns = false;
            DgCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdCompra", HeaderText = Resources.IdCompra, Name = "IdCompra" });
            DgCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DescripcionPublicacion", HeaderText = Resources.Descripcion, Name = "DescripcionPublicacion" });
            DgCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Vendedor", HeaderText = Resources.Vendedor, Name = "Vendedor" });
            DgCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Fecha", HeaderText = Resources.Fecha, Name = "Fecha" });
            DgCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TipoPublicacion", HeaderText = Resources.TipoPublicacion, Name = "TipoPublicacion" });
            DgCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cantidad", HeaderText = Resources.Cantidad, Name = "Cantidad" });

            _baselist = FillDataforGrid();
            _pagesCount = Convert.ToInt32(Math.Ceiling(_baselist.Count * 1.0 / PageRows));

            _currentPage = 1;
            RefreshPagination();
            RebindGridForPageChange();
            #endregion

            #region cargaDatosUsuario
            LabelUsuarioTxt.Text = Usuario.UserName;
            LabelReputacionTxt.Text = Usuario.Reputacion.ToString(CultureInfo.CurrentCulture);
            LabelFaltantesTxt.Text = ComprasServices.GetComprasPendientesDeCalificacion(Usuario.IdUsuario).Count.ToString();
            #endregion

            #region cargaDeEstrellas
            Label1EstrellaTxt.Text = CalificacionesServices.GetCantidadCalificacionesDadas(1,Usuario.IdUsuario).ToString();
            Label2EstrellasTxt.Text = CalificacionesServices.GetCantidadCalificacionesDadas(2, Usuario.IdUsuario).ToString();
            Label3EstrellasTxt.Text = CalificacionesServices.GetCantidadCalificacionesDadas(3, Usuario.IdUsuario).ToString();
            Label4EstrellasTxt.Text = CalificacionesServices.GetCantidadCalificacionesDadas(4, Usuario.IdUsuario).ToString();
            Label5EstrellasTxt.Text = CalificacionesServices.GetCantidadCalificacionesDadas(5, Usuario.IdUsuario).ToString();
            #endregion
        }

        private BindingList<Compra> FillDataforGrid()
        {
            List<Compra> listAux = new List<Compra>(ComprasServices.GetComprasPendientesDeCalificacion(Usuario.IdUsuario));
            BindingList<Compra> list = new BindingList<Compra>(listAux);
            return list;
        }

        #region MetodosPaginador
        private void RebindGridForPageChange()
        {
            int datasourcestartIndex = (_currentPage - 1) * PageRows;
            _templist = new BindingList<Compra>();
            for (int i = datasourcestartIndex; i < datasourcestartIndex + PageRows; i++)
            {
                if (i >= _baselist.Count)
                    break;

                _templist.Add(_baselist[i]);
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = _templist;
            DgCompras.DataSource = bs;
            DgCompras.Refresh();
        }

        private void RefreshPagination()
        {
            ToolStripButton[] items = new ToolStripButton[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripButton4, toolStripButton5 };

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
                    items[i - pageStartIndex].Text = i.ToString(CultureInfo.InvariantCulture);

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
    }
}
