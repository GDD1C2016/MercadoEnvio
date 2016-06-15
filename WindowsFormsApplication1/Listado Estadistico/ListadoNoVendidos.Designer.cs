namespace MercadoEnvio.Listado_Estadistico
{
    partial class ListadoNoVendidos
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnVolver = new System.Windows.Forms.Button();
            this.DgVendedores = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgVendedores)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnVolver);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 355);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(573, 53);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Acciones";
            // 
            // BtnVolver
            // 
            this.BtnVolver.Location = new System.Drawing.Point(12, 19);
            this.BtnVolver.Name = "BtnVolver";
            this.BtnVolver.Size = new System.Drawing.Size(549, 23);
            this.BtnVolver.TabIndex = 1;
            this.BtnVolver.Text = "Volver";
            this.BtnVolver.UseVisualStyleBackColor = true;
            this.BtnVolver.Click += new System.EventHandler(this.BtnVolver_Click);
            // 
            // DgVendedores
            // 
            this.DgVendedores.AllowUserToAddRows = false;
            this.DgVendedores.AllowUserToDeleteRows = false;
            this.DgVendedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgVendedores.Location = new System.Drawing.Point(12, 12);
            this.DgVendedores.Name = "DgVendedores";
            this.DgVendedores.ReadOnly = true;
            this.DgVendedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgVendedores.Size = new System.Drawing.Size(549, 337);
            this.DgVendedores.TabIndex = 3;
            // 
            // ListadoNoVendidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 408);
            this.Controls.Add(this.DgVendedores);
            this.Controls.Add(this.groupBox2);
            this.MaximumSize = new System.Drawing.Size(589, 447);
            this.MinimumSize = new System.Drawing.Size(589, 447);
            this.Name = "ListadoNoVendidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendedores con mayor cantidad de productos no vendidos";
            this.Load += new System.EventHandler(this.ListadoNoVendidos_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgVendedores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnVolver;
        private System.Windows.Forms.DataGridView DgVendedores;
    }
}