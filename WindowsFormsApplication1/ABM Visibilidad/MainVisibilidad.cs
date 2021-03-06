﻿using System;
using System.ComponentModel;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
using MercadoEnvio.Properties;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.ABM_Visibilidad
{
    public partial class MainVisibilidad : Form
    {
        public Usuario Usuario { get; set; }

        public MainVisibilidad()
        {
            InitializeComponent();
        }

        private void MainVisibilidad_Load(object sender, EventArgs e)
        {
            #region armadoDeGrillaVisibilidad
            BindingList<Visibilidad> dataSource = new BindingList<Visibilidad>(VisibilidadesServices.GetAllData());
            BindingSource bs = new BindingSource {DataSource = dataSource};

            DgVisibilidad.AutoGenerateColumns = false;
            DgVisibilidad.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Descripcion", HeaderText = Resources.Descripcion, Name = "Descripcion" });
            DgVisibilidad.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Precio", HeaderText = Resources.Precio, Name = "Precio" });
            DgVisibilidad.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Porcentaje", HeaderText = Resources.Porcentaje, Name = "Porcentaje" });
            DgVisibilidad.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EnvioPorcentaje", HeaderText = Resources.PorcentajeEnvio, Name = "EnvioPorcentaje" });

            DgVisibilidad.DataSource = bs;
            #endregion
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            BindingList<Visibilidad> dataSource = new BindingList<Visibilidad>();
            BindingSource bs = new BindingSource {DataSource = dataSource};

            DgVisibilidad.DataSource = bs;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string filtroDescripcion = TxtFiltroDescripcion.Text;

            BindingList<Visibilidad> dataSource = new BindingList<Visibilidad>(VisibilidadesServices.FindVisibilidades(filtroDescripcion));
            BindingSource bs = new BindingSource {DataSource = dataSource};

            DgVisibilidad.DataSource = bs;
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            Visibilidad visibilidadSeleccionada = new Visibilidad();

            if (DgVisibilidad.SelectedRows.Count > 0)
            {
                BindingSource bs = DgVisibilidad.DataSource as BindingSource;
                if (bs != null)
                    visibilidadSeleccionada = (Visibilidad)bs.List[bs.Position];
            }

            string message = VisibilidadesServices.DeleteVisibilidad(visibilidadSeleccionada);

            if (string.IsNullOrEmpty(message))
            {
                BindingList<Visibilidad> dataSource = new BindingList<Visibilidad>(VisibilidadesServices.FindVisibilidades(string.Empty));
                BindingSource bs = new BindingSource {DataSource = dataSource};

                DgVisibilidad.DataSource = bs;

                MessageBox.Show(Resources.VisibilidadBorrada, Resources.MercadoEnvio, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show(message, Resources.ErrorBorrado, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            var altaVisibilidad = new AltaVisibilidad(new Visibilidad());
            altaVisibilidad.ShowDialog();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Visibilidad visibilidadSeleccionada = new Visibilidad();

            if (DgVisibilidad.SelectedRows.Count > 0)
            {
                BindingSource bs = DgVisibilidad.DataSource as BindingSource;
                if (bs != null)
                    visibilidadSeleccionada = (Visibilidad)bs.List[bs.Position];

                var altaVisibilidad = new AltaVisibilidad(visibilidadSeleccionada) { Text = Resources.EdicionVisibilidad };
                altaVisibilidad.ShowDialog();
            }
        }
    }
}
