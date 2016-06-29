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
        private int _currentPage = 1;
        private int _pagesCount = 1;
        private const int PageRows = 12;
        private BindingList<Publicacion> _baselist;
        private BindingList<Publicacion> _templist;
        #endregion

        public Rubro RubroSeleccionado { get; set; }
        public List<Rubro> RubrosFiltro { get; set; }
        public Usuario Usuario { get; set; }

        public MainPublicacion()
        {
            InitializeComponent();
            RubrosFiltro = new List<Rubro>();
        }

        private void MainPublicacion_Load(object sender, EventArgs e)
        {
            #region armadoDeGrillaPublicaciones
            DgPublicaciones.AutoGenerateColumns = false;
            DgPublicaciones.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdPublicacion", HeaderText = Resources.CodigoPublicacion, Name = "CodigoPublicacion" });
            DgPublicaciones.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Descripcion", HeaderText = Resources.Descripcion, Name = "Descripcion" });
            DgPublicaciones.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Stock", HeaderText = Resources.Stock, Name = "Stock" });
            DgPublicaciones.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FechaInicio", HeaderText = Resources.FechaInicio, Name = "FechaInicio" });
            DgPublicaciones.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FechaVencimiento", HeaderText = Resources.FechaVencimiento, Name = "FechaVencimiento" });
            DgPublicaciones.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Precio", HeaderText = Resources.Precio, Name = "Precio" });

            _baselist = FillDataforGrid();
            _pagesCount = Convert.ToInt32(Math.Ceiling(_baselist.Count * 1.0 / PageRows));

            _currentPage = 1;
            RefreshPagination();
            RebindGridForPageChange();
            #endregion

            #region validarUsuario
            BtnComprar.Enabled = ValidarUsuario();
            #endregion
        }

        private bool ValidarUsuario()
        {
            return !Usuario.UserName.Equals("admin", StringComparison.CurrentCultureIgnoreCase);
        }

        private BindingList<Publicacion> FillDataforGrid()
        {
            List<Publicacion> listAux = new List<Publicacion>(PublicacionesServices.GetAllData());
            BindingList<Publicacion> list = new BindingList<Publicacion>(listAux);
            return list;
        }

        #region metodosPaginador
        private void RebindGridForPageChange()
        {
            int datasourcestartIndex = (_currentPage - 1) * PageRows;
            _templist = new BindingList<Publicacion>();
            for (int i = datasourcestartIndex; i < datasourcestartIndex + PageRows; i++)
            {
                if (i >= _baselist.Count)
                    break;

                _templist.Add(_baselist[i]);
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = _templist;

            DgPublicaciones.DataSource = bs;
            DgPublicaciones.Refresh();
        }

        private void RefreshPagination()
        {
            ToolStripButton[] items = new ToolStripButton[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripButton4, toolStripButton5 };

            var pageStartIndex = 1;

            if (_pagesCount > 5 && _currentPage > 2)
                pageStartIndex = _currentPage - 2;

            if (_pagesCount > 5 && _currentPage > _pagesCount - 2)
                pageStartIndex = _pagesCount - 4;

            for (var i = pageStartIndex; i < pageStartIndex + 5; i++)
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

        private void BtnSeleccionarRubro_Click(object sender, EventArgs e)
        {
            var mainRubro = new MainRubro {FormPublicacion = this};
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
            string filtroDescripcion = TxtFiltroDescripcion.Text;
            List<Publicacion> listAux = new List<Publicacion>(PublicacionesServices.FindPublicaciones(filtroDescripcion, RubrosFiltro));

            BindingList<Publicacion> dataSource = new BindingList<Publicacion>(listAux);
            BindingSource bs = new BindingSource {DataSource = dataSource};

            DgPublicaciones.DataSource = bs;
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            BindingList<Publicacion> dataSource = new BindingList<Publicacion>();
            BindingSource bs = new BindingSource {DataSource = dataSource};

            DgPublicaciones.DataSource = bs;

            RubrosFiltro.Clear();
            TxtFiltroRubro.Text = string.Empty;
            TxtFiltroDescripcion.Text = string.Empty;
        }

        private void BtnComprar_Click(object sender, EventArgs e)
        {
            Publicacion publicacionSeleccionada = new Publicacion();

            if (DgPublicaciones.SelectedRows.Count > 0)
            {
                BindingSource bs = (BindingSource) DgPublicaciones.DataSource;
                if (bs != null)
                {
                    publicacionSeleccionada = (Publicacion) bs[DgPublicaciones.SelectedRows[0].Index];
                }
            }

            var comprarDialog = new ComprarDialog
            {
                UsuarioActivo = Usuario,
                PublicacionSeleccionada = publicacionSeleccionada
            };

            comprarDialog.Text = publicacionSeleccionada.TipoPublicacion.Descripcion.Equals("Subasta",
                StringComparison.CurrentCultureIgnoreCase) ? Resources.Ofertar : Resources.Comprar;
            
            var res = comprarDialog.ShowDialog();

            if (res.Equals(DialogResult.OK))
            {
                List<Publicacion> listAux = new List<Publicacion>(PublicacionesServices.GetAllData());

                BindingList<Publicacion> dataSource = new BindingList<Publicacion>(listAux);
                BindingSource bs = new BindingSource {DataSource = dataSource};

                DgPublicaciones.DataSource = bs;
            }
        }

        private void DgPublicaciones_SelectionChanged(object sender, EventArgs e)
        {
            Publicacion publicacionSeleccionada = new Publicacion();

            if (DgPublicaciones.SelectedRows.Count > 0)
            {
                BindingSource bs = (BindingSource)DgPublicaciones.DataSource;
                if (bs != null)
                {
                    publicacionSeleccionada = (Publicacion)bs[DgPublicaciones.SelectedRows[0].Index];
                    BtnComprar.Enabled = !publicacionSeleccionada.EstadoDescripcion.Equals("Pausada", StringComparison.CurrentCultureIgnoreCase) && ValidarUsuario();
                }
            }
        }
    }
}
