﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MercadoEnvio.Entidades;
using MainMenu = MercadoEnvio.Menu.MainMenu;

namespace MercadoEnvio.Login
{
    public partial class MainSeleccionRol : Form
    {
        public Usuario Usuario { get; set; } 

        public MainSeleccionRol()
        {
            InitializeComponent();
        }

        private void MainSeleccionRol_Load(object sender, EventArgs e)
        {
            #region cargadoComboRoles
            List<Rol> roles = new List<Rol>(Usuario.Roles);

            ComboRoles.DataSource = roles;
            ComboRoles.DisplayMember = "Descripcion";
            ComboRoles.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            Rol rolSeleccionado = (Rol) ComboRoles.SelectedItem;

            Usuario.RolActivo = rolSeleccionado;
            var menuDialog = new MainMenu {Usuario = Usuario};

            menuDialog.ShowDialog();
        }
    }
}