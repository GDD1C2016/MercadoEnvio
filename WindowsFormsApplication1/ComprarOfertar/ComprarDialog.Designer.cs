namespace MercadoEnvio.ComprarOfertar
{
    partial class ComprarDialog
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
            this.GroupBoxDetalles = new System.Windows.Forms.GroupBox();
            this.TxtOfertar = new System.Windows.Forms.TextBox();
            this.LabelPrecioReservaNum = new System.Windows.Forms.Label();
            this.LabelPrecioReservaText = new System.Windows.Forms.Label();
            this.CheckBoxEnvio = new System.Windows.Forms.CheckBox();
            this.TxtCantidad = new System.Windows.Forms.TextBox();
            this.LabelCantidad = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LabelNombre = new System.Windows.Forms.Label();
            this.LabelEmail = new System.Windows.Forms.Label();
            this.LabelNombreTxt = new System.Windows.Forms.Label();
            this.LabelEmailTxt = new System.Windows.Forms.Label();
            this.LabelTelefono = new System.Windows.Forms.Label();
            this.LabelTelefonoTxt = new System.Windows.Forms.Label();
            this.LabelReputacion = new System.Windows.Forms.Label();
            this.LabelReputacionTxt = new System.Windows.Forms.Label();
            this.GroupBoxDetalles.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBoxDetalles
            // 
            this.GroupBoxDetalles.Controls.Add(this.TxtOfertar);
            this.GroupBoxDetalles.Controls.Add(this.LabelPrecioReservaNum);
            this.GroupBoxDetalles.Controls.Add(this.LabelPrecioReservaText);
            this.GroupBoxDetalles.Controls.Add(this.CheckBoxEnvio);
            this.GroupBoxDetalles.Controls.Add(this.TxtCantidad);
            this.GroupBoxDetalles.Controls.Add(this.LabelCantidad);
            this.GroupBoxDetalles.Location = new System.Drawing.Point(0, 92);
            this.GroupBoxDetalles.Name = "GroupBoxDetalles";
            this.GroupBoxDetalles.Size = new System.Drawing.Size(534, 58);
            this.GroupBoxDetalles.TabIndex = 2;
            this.GroupBoxDetalles.TabStop = false;
            this.GroupBoxDetalles.Text = "Detalles de la Compra";
            // 
            // TxtOfertar
            // 
            this.TxtOfertar.Location = new System.Drawing.Point(64, 23);
            this.TxtOfertar.Name = "TxtOfertar";
            this.TxtOfertar.Size = new System.Drawing.Size(130, 20);
            this.TxtOfertar.TabIndex = 6;
            this.TxtOfertar.Visible = false;
            this.TxtOfertar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtOfertar_KeyPress);
            // 
            // LabelPrecioReservaNum
            // 
            this.LabelPrecioReservaNum.AutoSize = true;
            this.LabelPrecioReservaNum.Location = new System.Drawing.Point(340, 26);
            this.LabelPrecioReservaNum.Name = "LabelPrecioReservaNum";
            this.LabelPrecioReservaNum.Size = new System.Drawing.Size(0, 13);
            this.LabelPrecioReservaNum.TabIndex = 5;
            this.LabelPrecioReservaNum.Visible = false;
            // 
            // LabelPrecioReservaText
            // 
            this.LabelPrecioReservaText.AutoSize = true;
            this.LabelPrecioReservaText.Location = new System.Drawing.Point(239, 26);
            this.LabelPrecioReservaText.Name = "LabelPrecioReservaText";
            this.LabelPrecioReservaText.Size = new System.Drawing.Size(95, 13);
            this.LabelPrecioReservaText.TabIndex = 4;
            this.LabelPrecioReservaText.Text = "Precio de Reserva";
            this.LabelPrecioReservaText.Visible = false;
            // 
            // CheckBoxEnvio
            // 
            this.CheckBoxEnvio.AutoSize = true;
            this.CheckBoxEnvio.Location = new System.Drawing.Point(242, 25);
            this.CheckBoxEnvio.Name = "CheckBoxEnvio";
            this.CheckBoxEnvio.Size = new System.Drawing.Size(77, 17);
            this.CheckBoxEnvio.TabIndex = 3;
            this.CheckBoxEnvio.Text = "Con Envío";
            this.CheckBoxEnvio.UseVisualStyleBackColor = true;
            this.CheckBoxEnvio.Visible = false;
            // 
            // TxtCantidad
            // 
            this.TxtCantidad.Location = new System.Drawing.Point(64, 23);
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.Size = new System.Drawing.Size(130, 20);
            this.TxtCantidad.TabIndex = 1;
            this.TxtCantidad.Visible = false;
            this.TxtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCantidad_KeyPress);
            // 
            // LabelCantidad
            // 
            this.LabelCantidad.AutoSize = true;
            this.LabelCantidad.Location = new System.Drawing.Point(9, 26);
            this.LabelCantidad.Name = "LabelCantidad";
            this.LabelCantidad.Size = new System.Drawing.Size(49, 13);
            this.LabelCantidad.TabIndex = 0;
            this.LabelCantidad.Text = "Cantidad";
            this.LabelCantidad.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnAceptar);
            this.groupBox2.Controls.Add(this.BtnCancelar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(534, 55);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Acciones";
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(12, 19);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(243, 23);
            this.BtnAceptar.TabIndex = 9;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(279, 19);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(243, 23);
            this.BtnCancelar.TabIndex = 8;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LabelReputacionTxt);
            this.groupBox1.Controls.Add(this.LabelReputacion);
            this.groupBox1.Controls.Add(this.LabelTelefonoTxt);
            this.groupBox1.Controls.Add(this.LabelTelefono);
            this.groupBox1.Controls.Add(this.LabelEmailTxt);
            this.groupBox1.Controls.Add(this.LabelNombreTxt);
            this.groupBox1.Controls.Add(this.LabelEmail);
            this.groupBox1.Controls.Add(this.LabelNombre);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 86);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalles Vendedor";
            // 
            // LabelNombre
            // 
            this.LabelNombre.AutoSize = true;
            this.LabelNombre.Location = new System.Drawing.Point(6, 27);
            this.LabelNombre.Name = "LabelNombre";
            this.LabelNombre.Size = new System.Drawing.Size(44, 13);
            this.LabelNombre.TabIndex = 0;
            this.LabelNombre.Text = "Nombre";
            // 
            // LabelEmail
            // 
            this.LabelEmail.AutoSize = true;
            this.LabelEmail.Location = new System.Drawing.Point(6, 55);
            this.LabelEmail.Name = "LabelEmail";
            this.LabelEmail.Size = new System.Drawing.Size(32, 13);
            this.LabelEmail.TabIndex = 1;
            this.LabelEmail.Text = "Email";
            // 
            // LabelNombreTxt
            // 
            this.LabelNombreTxt.AutoSize = true;
            this.LabelNombreTxt.Location = new System.Drawing.Point(56, 27);
            this.LabelNombreTxt.Name = "LabelNombreTxt";
            this.LabelNombreTxt.Size = new System.Drawing.Size(0, 13);
            this.LabelNombreTxt.TabIndex = 2;
            // 
            // LabelEmailTxt
            // 
            this.LabelEmailTxt.AutoSize = true;
            this.LabelEmailTxt.Location = new System.Drawing.Point(56, 55);
            this.LabelEmailTxt.Name = "LabelEmailTxt";
            this.LabelEmailTxt.Size = new System.Drawing.Size(0, 13);
            this.LabelEmailTxt.TabIndex = 3;
            // 
            // LabelTelefono
            // 
            this.LabelTelefono.AutoSize = true;
            this.LabelTelefono.Location = new System.Drawing.Point(180, 27);
            this.LabelTelefono.Name = "LabelTelefono";
            this.LabelTelefono.Size = new System.Drawing.Size(49, 13);
            this.LabelTelefono.TabIndex = 4;
            this.LabelTelefono.Text = "Telefono";
            // 
            // LabelTelefonoTxt
            // 
            this.LabelTelefonoTxt.AutoSize = true;
            this.LabelTelefonoTxt.Location = new System.Drawing.Point(235, 27);
            this.LabelTelefonoTxt.Name = "LabelTelefonoTxt";
            this.LabelTelefonoTxt.Size = new System.Drawing.Size(0, 13);
            this.LabelTelefonoTxt.TabIndex = 5;
            // 
            // LabelReputacion
            // 
            this.LabelReputacion.AutoSize = true;
            this.LabelReputacion.Location = new System.Drawing.Point(340, 27);
            this.LabelReputacion.Name = "LabelReputacion";
            this.LabelReputacion.Size = new System.Drawing.Size(62, 13);
            this.LabelReputacion.TabIndex = 6;
            this.LabelReputacion.Text = "Reputación";
            // 
            // LabelReputacionTxt
            // 
            this.LabelReputacionTxt.AutoSize = true;
            this.LabelReputacionTxt.Location = new System.Drawing.Point(408, 27);
            this.LabelReputacionTxt.Name = "LabelReputacionTxt";
            this.LabelReputacionTxt.Size = new System.Drawing.Size(0, 13);
            this.LabelReputacionTxt.TabIndex = 7;
            // 
            // ComprarDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 211);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GroupBoxDetalles);
            this.MaximumSize = new System.Drawing.Size(550, 250);
            this.MinimumSize = new System.Drawing.Size(550, 250);
            this.Name = "ComprarDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compra";
            this.Load += new System.EventHandler(this.ComprarDialog_Load);
            this.GroupBoxDetalles.ResumeLayout(false);
            this.GroupBoxDetalles.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxDetalles;
        private System.Windows.Forms.Label LabelPrecioReservaText;
        private System.Windows.Forms.CheckBox CheckBoxEnvio;
        private System.Windows.Forms.TextBox TxtCantidad;
        private System.Windows.Forms.Label LabelCantidad;
        private System.Windows.Forms.Label LabelPrecioReservaNum;
        private System.Windows.Forms.TextBox TxtOfertar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LabelReputacionTxt;
        private System.Windows.Forms.Label LabelReputacion;
        private System.Windows.Forms.Label LabelTelefonoTxt;
        private System.Windows.Forms.Label LabelTelefono;
        private System.Windows.Forms.Label LabelEmailTxt;
        private System.Windows.Forms.Label LabelNombreTxt;
        private System.Windows.Forms.Label LabelEmail;
        private System.Windows.Forms.Label LabelNombre;
    }
}