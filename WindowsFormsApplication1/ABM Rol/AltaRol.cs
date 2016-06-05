using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
using MercadoEnvio.Servicios;
using MercadoEnvio.Properties;

namespace MercadoEnvio.ABM_Rol
{
    public partial class AltaRol : Form
    {
        public AltaRol(Rol rol)
        {
            InitializeComponent();
            
            TxtNombre.Text = rol.Descripcion;

            #region armadoDeGrillaFuncionalidad
            BindingList<Funcionalidad> dataSource = new BindingList<Funcionalidad>(rol.Funcionalidades);
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;

            DgFuncionalidades.AutoGenerateColumns = false;
            DgFuncionalidades.ColumnCount = 1;

            DgFuncionalidades.Columns[0].HeaderText = "Funcionalidad";
            DgFuncionalidades.Columns[0].Name = "Descripcion";
            DgFuncionalidades.Columns[0].DataPropertyName = "Descripcion";

            DgFuncionalidades.DataSource = bs;
            #endregion

            #region armadoComboEstado
            Estado estadoHabilitado = new Estado { Valor = true };
            Estado estadoDeshabilitado = new Estado { Valor = false };
            List<Estado> estados = new List<Estado>();
            estados.Add(estadoHabilitado);
            estados.Add(estadoDeshabilitado);

            ComboEstado.DataSource = estados;
            ComboEstado.DisplayMember = "Descripcion";
            ComboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboEstado.SelectedItem = rol.Activo;
            #endregion
        }

        private void AltaRol_Load(object sender, EventArgs e)
        {
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>(RolesServices.GetAllFuncionalidades());
            ComboFuncionalidad.DataSource = funcionalidades;
            ComboFuncionalidad.DisplayMember = "Descripcion";
            ComboFuncionalidad.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            List<string> errors = new List<string>(ValidarDatosRol());

            if (errors.Count > 0)
            {
                var message = string.Join(Environment.NewLine, errors);
                MessageBox.Show(message, Resources.ErrorGuardado, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Rol newRol = new Rol
                {
                    Descripcion = TxtNombre.Text.Trim(),
                    Activo = ((Estado) ComboEstado.SelectedItem).Valor,
                    Funcionalidades = GetFuncionalidadesFromDg()
                };
                
                if (RolesServices.SaveNewRol(newRol))
                    MessageBox.Show(Resources.UsuarioCreado);
                else
                    MessageBox.Show(Resources.ErrorGuardado);
            }
        }

        private List<Funcionalidad> GetFuncionalidadesFromDg()
        {
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();

            BindingSource bs = new BindingSource();
            bs = DgFuncionalidades.DataSource as BindingSource;

            foreach (Funcionalidad funcionalidad in bs.List)
            {
                funcionalidades.Add(funcionalidad);
            }

            return funcionalidades;
        }

        private List<string> ValidarDatosRol()
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrEmpty(TxtNombre.Text))
                errors.Add(Resources.ErrorDescripcionVacia);

            BindingSource bs = new BindingSource();
            bs = DgFuncionalidades.DataSource as BindingSource;

            if(bs.List.Count == 0)
                errors.Add(Resources.ErrorRolSinFuncionalidad);

            return errors;
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            Funcionalidad funcionalidadSeleccionada = new Funcionalidad();
            funcionalidadSeleccionada = (Funcionalidad) ComboFuncionalidad.SelectedItem;

            BindingSource bs = new BindingSource();
            bs = DgFuncionalidades.DataSource as BindingSource;

            bool canAdd = bs.List.Cast<Funcionalidad>().All(funcionalidad => funcionalidad.IdFuncionalidad != funcionalidadSeleccionada.IdFuncionalidad);

            if (canAdd)
            {
                bs.Add(funcionalidadSeleccionada);
            }
            else
            {
                MessageBox.Show(Resources.ErrorAgregarFuncionalidad, Resources.Advertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            if (DgFuncionalidades.SelectedRows.Count > 0)
            {
                BindingSource bs = new BindingSource();
                bs = DgFuncionalidades.DataSource as BindingSource;
                bs.RemoveAt(DgFuncionalidades.SelectedRows[0].Index);
            }
        }
    }
}
