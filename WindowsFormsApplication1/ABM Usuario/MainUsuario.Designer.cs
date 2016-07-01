namespace MercadoEnvio.ABM_Usuario
{
    partial class MainUsuario
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
            this.TxtFiltroCuit = new System.Windows.Forms.TextBox();
            this.ComboTipoDeUsuario = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtFiltroEmail = new System.Windows.Forms.TextBox();
            this.LabelEmail = new System.Windows.Forms.Label();
            this.TxtFiltroDNI = new System.Windows.Forms.TextBox();
            this.LabelDNI = new System.Windows.Forms.Label();
            this.TxtFiltroApellido = new System.Windows.Forms.TextBox();
            this.LabelApellido = new System.Windows.Forms.Label();
            this.TxtFiltroNombre = new System.Windows.Forms.TextBox();
            this.LabelNombre = new System.Windows.Forms.Label();
            this.DgUsuarios = new System.Windows.Forms.DataGridView();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnBorrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgUsuarios)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtFiltroCuit);
            this.groupBox1.Controls.Add(this.ComboTipoDeUsuario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtFiltroEmail);
            this.groupBox1.Controls.Add(this.LabelEmail);
            this.groupBox1.Controls.Add(this.TxtFiltroDNI);
            this.groupBox1.Controls.Add(this.LabelDNI);
            this.groupBox1.Controls.Add(this.TxtFiltroApellido);
            this.groupBox1.Controls.Add(this.LabelApellido);
            this.groupBox1.Controls.Add(this.TxtFiltroNombre);
            this.groupBox1.Controls.Add(this.LabelNombre);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(634, 113);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            // 
            // TxtFiltroCuit
            // 
            this.TxtFiltroCuit.Location = new System.Drawing.Point(411, 52);
            this.TxtFiltroCuit.Name = "TxtFiltroCuit";
            this.TxtFiltroCuit.Size = new System.Drawing.Size(211, 20);
            this.TxtFiltroCuit.TabIndex = 12;
            this.TxtFiltroCuit.Visible = false;
            // 
            // ComboTipoDeUsuario
            // 
            this.ComboTipoDeUsuario.FormattingEnabled = true;
            this.ComboTipoDeUsuario.Location = new System.Drawing.Point(75, 23);
            this.ComboTipoDeUsuario.Name = "ComboTipoDeUsuario";
            this.ComboTipoDeUsuario.Size = new System.Drawing.Size(121, 21);
            this.ComboTipoDeUsuario.TabIndex = 11;
            this.ComboTipoDeUsuario.SelectionChangeCommitted += new System.EventHandler(this.ComboTipoDeUsuario_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tipo";
            // 
            // TxtFiltroEmail
            // 
            this.TxtFiltroEmail.Location = new System.Drawing.Point(411, 84);
            this.TxtFiltroEmail.Name = "TxtFiltroEmail";
            this.TxtFiltroEmail.Size = new System.Drawing.Size(211, 20);
            this.TxtFiltroEmail.TabIndex = 9;
            // 
            // LabelEmail
            // 
            this.LabelEmail.AutoSize = true;
            this.LabelEmail.Location = new System.Drawing.Point(370, 87);
            this.LabelEmail.Name = "LabelEmail";
            this.LabelEmail.Size = new System.Drawing.Size(35, 13);
            this.LabelEmail.TabIndex = 8;
            this.LabelEmail.Text = "E-mail";
            // 
            // TxtFiltroDNI
            // 
            this.TxtFiltroDNI.Location = new System.Drawing.Point(411, 52);
            this.TxtFiltroDNI.Name = "TxtFiltroDNI";
            this.TxtFiltroDNI.Size = new System.Drawing.Size(211, 20);
            this.TxtFiltroDNI.TabIndex = 7;
            this.TxtFiltroDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFiltroDNI_KeyPress);
            // 
            // LabelDNI
            // 
            this.LabelDNI.AutoSize = true;
            this.LabelDNI.Location = new System.Drawing.Point(370, 55);
            this.LabelDNI.Name = "LabelDNI";
            this.LabelDNI.Size = new System.Drawing.Size(26, 13);
            this.LabelDNI.TabIndex = 6;
            this.LabelDNI.Text = "DNI";
            // 
            // TxtFiltroApellido
            // 
            this.TxtFiltroApellido.Location = new System.Drawing.Point(75, 84);
            this.TxtFiltroApellido.Name = "TxtFiltroApellido";
            this.TxtFiltroApellido.Size = new System.Drawing.Size(284, 20);
            this.TxtFiltroApellido.TabIndex = 5;
            // 
            // LabelApellido
            // 
            this.LabelApellido.AutoSize = true;
            this.LabelApellido.Location = new System.Drawing.Point(12, 87);
            this.LabelApellido.Name = "LabelApellido";
            this.LabelApellido.Size = new System.Drawing.Size(44, 13);
            this.LabelApellido.TabIndex = 4;
            this.LabelApellido.Text = "Apellido";
            // 
            // TxtFiltroNombre
            // 
            this.TxtFiltroNombre.Location = new System.Drawing.Point(75, 52);
            this.TxtFiltroNombre.Name = "TxtFiltroNombre";
            this.TxtFiltroNombre.Size = new System.Drawing.Size(284, 20);
            this.TxtFiltroNombre.TabIndex = 1;
            // 
            // LabelNombre
            // 
            this.LabelNombre.AutoSize = true;
            this.LabelNombre.Location = new System.Drawing.Point(12, 55);
            this.LabelNombre.Name = "LabelNombre";
            this.LabelNombre.Size = new System.Drawing.Size(44, 13);
            this.LabelNombre.TabIndex = 0;
            this.LabelNombre.Text = "Nombre";
            // 
            // DgUsuarios
            // 
            this.DgUsuarios.AllowUserToAddRows = false;
            this.DgUsuarios.AllowUserToDeleteRows = false;
            this.DgUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgUsuarios.Location = new System.Drawing.Point(12, 152);
            this.DgUsuarios.Name = "DgUsuarios";
            this.DgUsuarios.ReadOnly = true;
            this.DgUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgUsuarios.Size = new System.Drawing.Size(610, 335);
            this.DgUsuarios.TabIndex = 2;
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Location = new System.Drawing.Point(12, 119);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(185, 23);
            this.BtnLimpiar.TabIndex = 3;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(431, 119);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(191, 23);
            this.BtnBuscar.TabIndex = 4;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnEditar);
            this.groupBox2.Controls.Add(this.BtnAgregar);
            this.groupBox2.Controls.Add(this.BtnBorrar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 491);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(634, 55);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Acciones";
            // 
            // BtnEditar
            // 
            this.BtnEditar.Location = new System.Drawing.Point(6, 19);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(190, 23);
            this.BtnEditar.TabIndex = 6;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.UseVisualStyleBackColor = true;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(221, 19);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(185, 23);
            this.BtnAgregar.TabIndex = 4;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnBorrar
            // 
            this.BtnBorrar.Location = new System.Drawing.Point(431, 19);
            this.BtnBorrar.Name = "BtnBorrar";
            this.BtnBorrar.Size = new System.Drawing.Size(191, 23);
            this.BtnBorrar.TabIndex = 5;
            this.BtnBorrar.Text = "Borrar";
            this.BtnBorrar.UseVisualStyleBackColor = true;
            this.BtnBorrar.Click += new System.EventHandler(this.BtnBorrar_Click);
            // 
            // MainUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 546);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.DgUsuarios);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(650, 585);
            this.MinimumSize = new System.Drawing.Size(650, 585);
            this.Name = "MainUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM de Usuario";
            this.Load += new System.EventHandler(this.MainUsuario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgUsuarios)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtFiltroNombre;
        private System.Windows.Forms.Label LabelNombre;
        private System.Windows.Forms.TextBox TxtFiltroEmail;
        private System.Windows.Forms.Label LabelEmail;
        private System.Windows.Forms.TextBox TxtFiltroDNI;
        private System.Windows.Forms.Label LabelDNI;
        private System.Windows.Forms.TextBox TxtFiltroApellido;
        private System.Windows.Forms.Label LabelApellido;
        private System.Windows.Forms.ComboBox ComboTipoDeUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgUsuarios;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button BtnBorrar;
        private System.Windows.Forms.TextBox TxtFiltroCuit;
    }
}