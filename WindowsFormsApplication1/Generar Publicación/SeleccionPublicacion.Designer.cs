namespace MercadoEnvio.Generar_Publicación
{
    partial class SeleccionPublicacion
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
            this.textBoxCodPublicacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxCodPublicacion
            // 
            this.textBoxCodPublicacion.Location = new System.Drawing.Point(12, 53);
            this.textBoxCodPublicacion.Name = "textBoxCodPublicacion";
            this.textBoxCodPublicacion.Size = new System.Drawing.Size(267, 20);
            this.textBoxCodPublicacion.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Ingrese el código de la publicación que desea editar:";
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(58, 98);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(175, 23);
            this.BtnBuscar.TabIndex = 25;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // SeleccionPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 133);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCodPublicacion);
            this.Name = "SeleccionPublicacion";
            this.Text = "Selección de Publicación";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCodPublicacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnBuscar;
    }
}