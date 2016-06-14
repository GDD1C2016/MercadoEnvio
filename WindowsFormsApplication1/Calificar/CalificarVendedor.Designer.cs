namespace MercadoEnvio.Calificar
{
    partial class CalificarVendedor
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
            this.LabelVendedor = new System.Windows.Forms.Label();
            this.LabelVendedorText = new System.Windows.Forms.Label();
            this.LabelArticulo = new System.Windows.Forms.Label();
            this.LabelArticuloText = new System.Windows.Forms.Label();
            this.LabelCalificar = new System.Windows.Forms.Label();
            this.ComboEstrellas = new System.Windows.Forms.ComboBox();
            this.LabelObservaciones = new System.Windows.Forms.Label();
            this.RichTextBoxObservaciones = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelVendedor
            // 
            this.LabelVendedor.AutoSize = true;
            this.LabelVendedor.Location = new System.Drawing.Point(12, 9);
            this.LabelVendedor.Name = "LabelVendedor";
            this.LabelVendedor.Size = new System.Drawing.Size(53, 13);
            this.LabelVendedor.TabIndex = 0;
            this.LabelVendedor.Text = "Vendedor";
            // 
            // LabelVendedorText
            // 
            this.LabelVendedorText.AutoSize = true;
            this.LabelVendedorText.Location = new System.Drawing.Point(82, 9);
            this.LabelVendedorText.Name = "LabelVendedorText";
            this.LabelVendedorText.Size = new System.Drawing.Size(0, 13);
            this.LabelVendedorText.TabIndex = 1;
            // 
            // LabelArticulo
            // 
            this.LabelArticulo.AutoSize = true;
            this.LabelArticulo.Location = new System.Drawing.Point(12, 41);
            this.LabelArticulo.Name = "LabelArticulo";
            this.LabelArticulo.Size = new System.Drawing.Size(42, 13);
            this.LabelArticulo.TabIndex = 2;
            this.LabelArticulo.Text = "Articulo";
            // 
            // LabelArticuloText
            // 
            this.LabelArticuloText.AutoSize = true;
            this.LabelArticuloText.Location = new System.Drawing.Point(82, 41);
            this.LabelArticuloText.Name = "LabelArticuloText";
            this.LabelArticuloText.Size = new System.Drawing.Size(0, 13);
            this.LabelArticuloText.TabIndex = 3;
            // 
            // LabelCalificar
            // 
            this.LabelCalificar.AutoSize = true;
            this.LabelCalificar.Location = new System.Drawing.Point(226, 9);
            this.LabelCalificar.Name = "LabelCalificar";
            this.LabelCalificar.Size = new System.Drawing.Size(44, 13);
            this.LabelCalificar.TabIndex = 4;
            this.LabelCalificar.Text = "Calificar";
            // 
            // ComboEstrellas
            // 
            this.ComboEstrellas.FormattingEnabled = true;
            this.ComboEstrellas.Location = new System.Drawing.Point(276, 6);
            this.ComboEstrellas.Name = "ComboEstrellas";
            this.ComboEstrellas.Size = new System.Drawing.Size(77, 21);
            this.ComboEstrellas.TabIndex = 5;
            // 
            // LabelObservaciones
            // 
            this.LabelObservaciones.AutoSize = true;
            this.LabelObservaciones.Location = new System.Drawing.Point(12, 81);
            this.LabelObservaciones.Name = "LabelObservaciones";
            this.LabelObservaciones.Size = new System.Drawing.Size(78, 13);
            this.LabelObservaciones.TabIndex = 7;
            this.LabelObservaciones.Text = "Observaciones";
            // 
            // RichTextBoxObservaciones
            // 
            this.RichTextBoxObservaciones.Location = new System.Drawing.Point(96, 78);
            this.RichTextBoxObservaciones.MaxLength = 255;
            this.RichTextBoxObservaciones.Name = "RichTextBoxObservaciones";
            this.RichTextBoxObservaciones.Size = new System.Drawing.Size(376, 79);
            this.RichTextBoxObservaciones.TabIndex = 8;
            this.RichTextBoxObservaciones.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnCancelar);
            this.groupBox2.Controls.Add(this.BtnAceptar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(484, 55);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Acciones";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(276, 20);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(141, 23);
            this.BtnCancelar.TabIndex = 1;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(85, 20);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(142, 23);
            this.BtnAceptar.TabIndex = 0;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // CalificarVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.RichTextBoxObservaciones);
            this.Controls.Add(this.LabelObservaciones);
            this.Controls.Add(this.ComboEstrellas);
            this.Controls.Add(this.LabelCalificar);
            this.Controls.Add(this.LabelArticuloText);
            this.Controls.Add(this.LabelArticulo);
            this.Controls.Add(this.LabelVendedorText);
            this.Controls.Add(this.LabelVendedor);
            this.MaximumSize = new System.Drawing.Size(500, 250);
            this.MinimumSize = new System.Drawing.Size(500, 250);
            this.Name = "CalificarVendedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calificar";
            this.Load += new System.EventHandler(this.CalificarVendedor_Load);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelVendedor;
        private System.Windows.Forms.Label LabelVendedorText;
        private System.Windows.Forms.Label LabelArticulo;
        private System.Windows.Forms.Label LabelArticuloText;
        private System.Windows.Forms.Label LabelCalificar;
        private System.Windows.Forms.ComboBox ComboEstrellas;
        private System.Windows.Forms.Label LabelObservaciones;
        private System.Windows.Forms.RichTextBox RichTextBoxObservaciones;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
    }
}