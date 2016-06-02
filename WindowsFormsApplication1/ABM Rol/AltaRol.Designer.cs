namespace MercadoEnvio.ABM_Rol
{
    partial class AltaRol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaRol));
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSeleccionar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.DgFuncionalidades = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboFuncionalidad = new System.Windows.Forms.ComboBox();
            this.BtnQuitar = new System.Windows.Forms.Button();
            this.ComboEstado = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgFuncionalidades)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ComboEstado);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtNombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(654, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Campos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(452, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Estado";
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(75, 23);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(288, 20);
            this.TxtNombre.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Descripción";
            // 
            // BtnSeleccionar
            // 
            this.BtnSeleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSeleccionar.Location = new System.Drawing.Point(379, 125);
            this.BtnSeleccionar.Name = "BtnSeleccionar";
            this.BtnSeleccionar.Size = new System.Drawing.Size(263, 23);
            this.BtnSeleccionar.TabIndex = 5;
            this.BtnSeleccionar.Text = "Agregar Funcionalidad";
            this.BtnSeleccionar.UseVisualStyleBackColor = true;
            this.BtnSeleccionar.Click += new System.EventHandler(this.BtnSeleccionar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(104, 22);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(175, 23);
            this.BtnGuardar.TabIndex = 1;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(379, 22);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(202, 23);
            this.BtnCancelar.TabIndex = 2;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // DgFuncionalidades
            // 
            this.DgFuncionalidades.AllowUserToAddRows = false;
            this.DgFuncionalidades.AllowUserToDeleteRows = false;
            this.DgFuncionalidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgFuncionalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgFuncionalidades.Location = new System.Drawing.Point(12, 68);
            this.DgFuncionalidades.Name = "DgFuncionalidades";
            this.DgFuncionalidades.ReadOnly = true;
            this.DgFuncionalidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgFuncionalidades.Size = new System.Drawing.Size(358, 230);
            this.DgFuncionalidades.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnGuardar);
            this.groupBox2.Controls.Add(this.BtnCancelar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 304);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(654, 57);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Acciones";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Funcionalidad";
            // 
            // ComboFuncionalidad
            // 
            this.ComboFuncionalidad.Location = new System.Drawing.Point(455, 84);
            this.ComboFuncionalidad.Name = "ComboFuncionalidad";
            this.ComboFuncionalidad.Size = new System.Drawing.Size(187, 21);
            this.ComboFuncionalidad.TabIndex = 9;
            // 
            // BtnQuitar
            // 
            this.BtnQuitar.Location = new System.Drawing.Point(379, 155);
            this.BtnQuitar.Name = "BtnQuitar";
            this.BtnQuitar.Size = new System.Drawing.Size(263, 23);
            this.BtnQuitar.TabIndex = 10;
            this.BtnQuitar.Text = "Quitar Funcionalidad";
            this.BtnQuitar.UseVisualStyleBackColor = true;
            this.BtnQuitar.Click += new System.EventHandler(this.BtnQuitar_Click);
            // 
            // ComboEstado
            // 
            this.ComboEstado.FormattingEnabled = true;
            this.ComboEstado.Location = new System.Drawing.Point(498, 23);
            this.ComboEstado.Name = "ComboEstado";
            this.ComboEstado.Size = new System.Drawing.Size(76, 21);
            this.ComboEstado.TabIndex = 11;
            // 
            // AltaRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 361);
            this.Controls.Add(this.BtnQuitar);
            this.Controls.Add(this.ComboFuncionalidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.DgFuncionalidades);
            this.Controls.Add(this.BtnSeleccionar);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(670, 400);
            this.MinimumSize = new System.Drawing.Size(670, 400);
            this.Name = "AltaRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AltaRol";
            this.Load += new System.EventHandler(this.AltaRol_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgFuncionalidades)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnSeleccionar;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.DataGridView DgFuncionalidades;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboFuncionalidad;
        private System.Windows.Forms.Button BtnQuitar;
        private System.Windows.Forms.ComboBox ComboEstado;
    }
}