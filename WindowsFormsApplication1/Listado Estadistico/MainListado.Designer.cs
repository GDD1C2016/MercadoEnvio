namespace MercadoEnvio.Listado_Estadistico
{
    partial class MainListado
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
            this.ComboTipo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboTrimestres = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtAnio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnGenerar = new System.Windows.Forms.Button();
            this.LabelRubro = new System.Windows.Forms.Label();
            this.ComboRubro = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ComboRubro);
            this.groupBox1.Controls.Add(this.LabelRubro);
            this.groupBox1.Controls.Add(this.ComboTipo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ComboTrimestres);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtAnio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parametros";
            // 
            // ComboTipo
            // 
            this.ComboTipo.FormattingEnabled = true;
            this.ComboTipo.Location = new System.Drawing.Point(125, 87);
            this.ComboTipo.Name = "ComboTipo";
            this.ComboTipo.Size = new System.Drawing.Size(303, 21);
            this.ComboTipo.TabIndex = 5;
            this.ComboTipo.SelectionChangeCommitted += new System.EventHandler(this.ComboTipo_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo de Listado";
            // 
            // ComboTrimestres
            // 
            this.ComboTrimestres.FormattingEnabled = true;
            this.ComboTrimestres.Location = new System.Drawing.Point(125, 54);
            this.ComboTrimestres.Name = "ComboTrimestres";
            this.ComboTrimestres.Size = new System.Drawing.Size(55, 21);
            this.ComboTrimestres.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleccione el trimestre";
            // 
            // TxtAnio
            // 
            this.TxtAnio.Location = new System.Drawing.Point(125, 25);
            this.TxtAnio.MaxLength = 4;
            this.TxtAnio.Name = "TxtAnio";
            this.TxtAnio.Size = new System.Drawing.Size(55, 20);
            this.TxtAnio.TabIndex = 1;
            this.TxtAnio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAnio_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese el año";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnCancelar);
            this.groupBox2.Controls.Add(this.BtnGenerar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 53);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Acciones";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(234, 18);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(194, 23);
            this.BtnCancelar.TabIndex = 1;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // BtnGenerar
            // 
            this.BtnGenerar.Location = new System.Drawing.Point(12, 18);
            this.BtnGenerar.Name = "BtnGenerar";
            this.BtnGenerar.Size = new System.Drawing.Size(194, 23);
            this.BtnGenerar.TabIndex = 0;
            this.BtnGenerar.Text = "Generar";
            this.BtnGenerar.UseVisualStyleBackColor = true;
            this.BtnGenerar.Click += new System.EventHandler(this.BtnGenerar_Click);
            // 
            // LabelRubro
            // 
            this.LabelRubro.AutoSize = true;
            this.LabelRubro.Location = new System.Drawing.Point(186, 28);
            this.LabelRubro.Name = "LabelRubro";
            this.LabelRubro.Size = new System.Drawing.Size(92, 13);
            this.LabelRubro.TabIndex = 6;
            this.LabelRubro.Text = "Seleccione Rubro";
            this.LabelRubro.Visible = false;
            // 
            // ComboRubro
            // 
            this.ComboRubro.FormattingEnabled = true;
            this.ComboRubro.Location = new System.Drawing.Point(284, 25);
            this.ComboRubro.Name = "ComboRubro";
            this.ComboRubro.Size = new System.Drawing.Size(144, 21);
            this.ComboRubro.TabIndex = 7;
            this.ComboRubro.Visible = false;
            // 
            // MainListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 173);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(456, 212);
            this.MinimumSize = new System.Drawing.Size(456, 212);
            this.Name = "MainListado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parametros de Listado";
            this.Load += new System.EventHandler(this.MainListado_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ComboTipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboTrimestres;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtAnio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnGenerar;
        private System.Windows.Forms.ComboBox ComboRubro;
        private System.Windows.Forms.Label LabelRubro;
    }
}