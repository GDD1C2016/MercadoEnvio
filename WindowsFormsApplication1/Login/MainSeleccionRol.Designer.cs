namespace MercadoEnvio.Login
{
    partial class MainSeleccionRol
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
            this.label1 = new System.Windows.Forms.Label();
            this.ComboRoles = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnSeleccionar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione el Rol con el que desea ingresar";
            // 
            // ComboRoles
            // 
            this.ComboRoles.FormattingEnabled = true;
            this.ComboRoles.Location = new System.Drawing.Point(233, 25);
            this.ComboRoles.Name = "ComboRoles";
            this.ComboRoles.Size = new System.Drawing.Size(166, 21);
            this.ComboRoles.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnSeleccionar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(445, 55);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Acciones";
            // 
            // BtnSeleccionar
            // 
            this.BtnSeleccionar.Location = new System.Drawing.Point(125, 19);
            this.BtnSeleccionar.Name = "BtnSeleccionar";
            this.BtnSeleccionar.Size = new System.Drawing.Size(205, 23);
            this.BtnSeleccionar.TabIndex = 0;
            this.BtnSeleccionar.Text = "Seleccionar";
            this.BtnSeleccionar.UseVisualStyleBackColor = true;
            this.BtnSeleccionar.Click += new System.EventHandler(this.BtnSeleccionar_Click);
            // 
            // MainSeleccionRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 127);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ComboRoles);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(461, 166);
            this.MinimumSize = new System.Drawing.Size(461, 166);
            this.Name = "MainSeleccionRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selección de Rol";
            this.Load += new System.EventHandler(this.MainSeleccionRol_Load);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboRoles;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnSeleccionar;
    }
}