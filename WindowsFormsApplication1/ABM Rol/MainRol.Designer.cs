namespace MercadoEnvio.ABM_Rol
{
    partial class MainRol
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ComboEstado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboFuncionalidad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtFiltroNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DgRoles = new System.Windows.Forms.DataGridView();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnBorrar = new System.Windows.Forms.Button();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ComboEstado);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ComboFuncionalidad);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtFiltroNombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(634, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            // 
            // ComboEstado
            // 
            this.ComboEstado.FormattingEnabled = true;
            this.ComboEstado.Location = new System.Drawing.Point(260, 26);
            this.ComboEstado.Name = "ComboEstado";
            this.ComboEstado.Size = new System.Drawing.Size(76, 21);
            this.ComboEstado.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Estado";
            // 
            // ComboFuncionalidad
            // 
            this.ComboFuncionalidad.FormattingEnabled = true;
            this.ComboFuncionalidad.Location = new System.Drawing.Point(431, 26);
            this.ComboFuncionalidad.Name = "ComboFuncionalidad";
            this.ComboFuncionalidad.Size = new System.Drawing.Size(191, 21);
            this.ComboFuncionalidad.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Funcionalidad";
            // 
            // TxtFiltroNombre
            // 
            this.TxtFiltroNombre.Location = new System.Drawing.Point(53, 26);
            this.TxtFiltroNombre.Name = "TxtFiltroNombre";
            this.TxtFiltroNombre.Size = new System.Drawing.Size(145, 20);
            this.TxtFiltroNombre.TabIndex = 1;
            this.TxtFiltroNombre.TextChanged += new System.EventHandler(this.TxtFiltroNombre_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // DgRoles
            // 
            this.DgRoles.AllowUserToAddRows = false;
            this.DgRoles.AllowUserToDeleteRows = false;
            this.DgRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgRoles.Location = new System.Drawing.Point(12, 100);
            this.DgRoles.Name = "DgRoles";
            this.DgRoles.ReadOnly = true;
            this.DgRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgRoles.Size = new System.Drawing.Size(610, 311);
            this.DgRoles.TabIndex = 1;
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Location = new System.Drawing.Point(13, 71);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(185, 23);
            this.BtnLimpiar.TabIndex = 2;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(431, 71);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(191, 23);
            this.BtnBuscar.TabIndex = 3;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(13, 426);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(185, 23);
            this.BtnAgregar.TabIndex = 4;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            // 
            // BtnBorrar
            // 
            this.BtnBorrar.Location = new System.Drawing.Point(431, 426);
            this.BtnBorrar.Name = "BtnBorrar";
            this.BtnBorrar.Size = new System.Drawing.Size(191, 23);
            this.BtnBorrar.TabIndex = 5;
            this.BtnBorrar.Text = "Borrar";
            this.BtnBorrar.UseVisualStyleBackColor = true;
            this.BtnBorrar.Click += new System.EventHandler(this.BtnBorrar_Click);
            // 
            // BtnEditar
            // 
            this.BtnEditar.Location = new System.Drawing.Point(221, 426);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(190, 23);
            this.BtnEditar.TabIndex = 6;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.UseVisualStyleBackColor = true;
            // 
            // MainRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 461);
            this.Controls.Add(this.BtnEditar);
            this.Controls.Add(this.DgRoles);
            this.Controls.Add(this.BtnBorrar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(650, 500);
            this.MinimumSize = new System.Drawing.Size(650, 500);
            this.Name = "MainRol";
            this.Text = "ABM de Rol";
            this.Load += new System.EventHandler(this.MainRol_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgRoles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtFiltroNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgRoles;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button BtnBorrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRolDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox ComboFuncionalidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboEstado;
        private System.Windows.Forms.Button BtnEditar;
    }
}