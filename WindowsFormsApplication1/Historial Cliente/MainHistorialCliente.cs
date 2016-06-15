using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.Historial_Cliente
{
    public partial class MainHistorialCliente : Form
    {
        #region variablesPaginador
        private int CurrentPage = 1;
        int PagesCount = 1;
        int pageRows = 12;
        BindingList<Compra> Baselist = null;
        BindingList<Compra> Templist = null;
        #endregion

        Usuario Usuario { get; set; }

        public MainHistorialCliente()
        {
            InitializeComponent();
        }

        private void MainHistorialCliente_Load(object sender, EventArgs e)
        {
            #region armadoDeGrillaCompras

            DgCompras.AutoGenerateColumns = false;
            DgCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdCompra", HeaderText = "IdCompra", Name = "IdCompra" });
            DgCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DescripcionPublicacion", HeaderText = "Descripción", Name = "DescripcionPublicacion" });
            DgCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Vendedor", HeaderText = "Vendedor", Name = "Vendedor" });
            DgCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Fecha", HeaderText = "Fecha", Name = "Fecha" });
            DgCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TipoPublicacion", HeaderText = "Tipo de Publicación", Name = "TipoPublicacion" });
            DgCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cantidad", HeaderText = "Cantidad", Name = "Cantidad" });

            Baselist = FillDataforGrid();
            PagesCount = Convert.ToInt32(Math.Ceiling(Baselist.Count * 1.0 / pageRows));

            CurrentPage = 1;
            RefreshPagination();
            RebindGridForPageChange();
            #endregion

            #region cargaDatosUsuario
            LabelUsuarioTxt.Text = Usuario.UserName;
            LabelReputacionTxt.Text = Usuario.Reputacion.ToString();
            LabelFaltantesTxt.Text = ComprasServices.GetPendientesCalificar().Count.ToString();
            #endregion

            #region cargaDeEstrellas
            Label1EstrellaTxt.Text = CalificacionesServices.GetCantidadDeEstrellasDadas(1,Usuario.IdUsuario).ToString();
            Label2EstrellasTxt.Text = CalificacionesServices.GetCantidadDeEstrellasDadas(2, Usuario.IdUsuario).ToString();
            Label3EstrellasTxt.Text = CalificacionesServices.GetCantidadDeEstrellasDadas(3, Usuario.IdUsuario).ToString();
            Label4EstrellasTxt.Text = CalificacionesServices.GetCantidadDeEstrellasDadas(4, Usuario.IdUsuario).ToString();
            Label5EstrellasTxt.Text = CalificacionesServices.GetCantidadDeEstrellasDadas(5, Usuario.IdUsuario).ToString();
            #endregion
        }

        private BindingList<Compra> FillDataforGrid()
        {
            List<Compra> listAux = new List<Compra>(ComprasServices.GetAllData());
            BindingList<Compra> list = new BindingList<Compra>(listAux);
            return list;
        }
        #region MetodosPaginador
        private void RebindGridForPageChange()
        {
            int datasourcestartIndex = (CurrentPage - 1) * pageRows;
            Templist = new BindingList<Compra>();
            for (int i = datasourcestartIndex; i < datasourcestartIndex + pageRows; i++)
            {
                if (i >= Baselist.Count)
                    break;

                Templist.Add(Baselist[i]);
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = Templist;
            DgCompras.DataSource = bs;
            DgCompras.Refresh();
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

    }
}
