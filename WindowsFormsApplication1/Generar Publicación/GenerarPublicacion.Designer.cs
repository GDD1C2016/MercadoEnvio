namespace MercadoEnvio.Generar_Publicación
{
    partial class GenerarPublicacion
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
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RichTextBoxDescripcion = new System.Windows.Forms.RichTextBox();
            this.labelNomUsuario = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ComboVisibilidad = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ComboRubro = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ComboTipoPublicacion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelCodPublicacion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboEstado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPrecioReserva = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxPrecio = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxStock = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.DatePickerFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.DatePickerFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.checkBoxAceptaEnvio = new System.Windows.Forms.CheckBox();
            this.ButtonEditar = new System.Windows.Forms.Button();
            this.ButtonGenerar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnGuardar);
            this.groupBox2.Controls.Add(this.BtnCancelar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 304);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(654, 57);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Acciones";
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
            this.BtnCancelar.Size = new System.Drawing.Size(175, 23);
            this.BtnCancelar.TabIndex = 2;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RichTextBoxDescripcion);
            this.groupBox1.Controls.Add(this.labelNomUsuario);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.ComboVisibilidad);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.ComboRubro);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ComboTipoPublicacion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.labelCodPublicacion);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ComboEstado);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(654, 169);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información básica de la publicación";
            // 
            // RichTextBoxDescripcion
            // 
            this.RichTextBoxDescripcion.Location = new System.Drawing.Point(73, 81);
            this.RichTextBoxDescripcion.MaxLength = 255;
            this.RichTextBoxDescripcion.Name = "RichTextBoxDescripcion";
            this.RichTextBoxDescripcion.Size = new System.Drawing.Size(569, 44);
            this.RichTextBoxDescripcion.TabIndex = 22;
            this.RichTextBoxDescripcion.Text = "";
            // 
            // labelNomUsuario
            // 
            this.labelNomUsuario.AutoSize = true;
            this.labelNomUsuario.Location = new System.Drawing.Point(483, 134);
            this.labelNomUsuario.Name = "labelNomUsuario";
            this.labelNomUsuario.Size = new System.Drawing.Size(92, 13);
            this.labelNomUsuario.TabIndex = 21;
            this.labelNomUsuario.Text = "Nombre y Apellido";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(376, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Usuario responsable";
            // 
            // ComboVisibilidad
            // 
            this.ComboVisibilidad.FormattingEnabled = true;
            this.ComboVisibilidad.Location = new System.Drawing.Point(104, 131);
            this.ComboVisibilidad.Name = "ComboVisibilidad";
            this.ComboVisibilidad.Size = new System.Drawing.Size(175, 21);
            this.ComboVisibilidad.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Tipo de visibilidad";
            // 
            // ComboRubro
            // 
            this.ComboRubro.FormattingEnabled = true;
            this.ComboRubro.Location = new System.Drawing.Point(419, 52);
            this.ComboRubro.Name = "ComboRubro";
            this.ComboRubro.Size = new System.Drawing.Size(223, 21);
            this.ComboRubro.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(376, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Rubro";
            // 
            // ComboTipoPublicacion
            // 
            this.ComboTipoPublicacion.FormattingEnabled = true;
            this.ComboTipoPublicacion.Location = new System.Drawing.Point(113, 52);
            this.ComboTipoPublicacion.Name = "ComboTipoPublicacion";
            this.ComboTipoPublicacion.Size = new System.Drawing.Size(166, 21);
            this.ComboTipoPublicacion.TabIndex = 15;
            this.ComboTipoPublicacion.SelectionChangeCommitted += new System.EventHandler(this.ComboTipoPublicacion_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Descripción";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tipo de publicación";
            // 
            // labelCodPublicacion
            // 
            this.labelCodPublicacion.AutoSize = true;
            this.labelCodPublicacion.Location = new System.Drawing.Point(122, 26);
            this.labelCodPublicacion.Name = "labelCodPublicacion";
            this.labelCodPublicacion.Size = new System.Drawing.Size(115, 13);
            this.labelCodPublicacion.TabIndex = 13;
            this.labelCodPublicacion.Text = "000000000000000000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Código de publicación";
            // 
            // ComboEstado
            // 
            this.ComboEstado.FormattingEnabled = true;
            this.ComboEstado.Location = new System.Drawing.Point(506, 23);
            this.ComboEstado.Name = "ComboEstado";
            this.ComboEstado.Size = new System.Drawing.Size(136, 21);
            this.ComboEstado.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(459, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Estado";
            // 
            // textBoxPrecioReserva
            // 
            this.textBoxPrecioReserva.Location = new System.Drawing.Point(542, 215);
            this.textBoxPrecioReserva.Name = "textBoxPrecioReserva";
            this.textBoxPrecioReserva.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrecioReserva.TabIndex = 17;
            this.textBoxPrecioReserva.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(499, 189);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Precio";
            // 
            // textBoxPrecio
            // 
            this.textBoxPrecio.Location = new System.Drawing.Point(542, 186);
            this.textBoxPrecio.Name = "textBoxPrecio";
            this.textBoxPrecio.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrecio.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(277, 189);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Stock";
            // 
            // textBoxStock
            // 
            this.textBoxStock.Location = new System.Drawing.Point(318, 186);
            this.textBoxStock.Name = "textBoxStock";
            this.textBoxStock.Size = new System.Drawing.Size(100, 20);
            this.textBoxStock.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(446, 218);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Precio de reserva";
            this.label11.Visible = false;
            // 
            // DatePickerFechaInicio
            // 
            this.DatePickerFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DatePickerFechaInicio.Location = new System.Drawing.Point(124, 186);
            this.DatePickerFechaInicio.Name = "DatePickerFechaInicio";
            this.DatePickerFechaInicio.Size = new System.Drawing.Size(126, 20);
            this.DatePickerFechaInicio.TabIndex = 36;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 189);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 13);
            this.label13.TabIndex = 37;
            this.label13.Text = "Fecha de inicio";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 218);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 13);
            this.label14.TabIndex = 38;
            this.label14.Text = "Fecha de vencimiento";
            // 
            // DatePickerFechaVencimiento
            // 
            this.DatePickerFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DatePickerFechaVencimiento.Location = new System.Drawing.Point(124, 215);
            this.DatePickerFechaVencimiento.Name = "DatePickerFechaVencimiento";
            this.DatePickerFechaVencimiento.Size = new System.Drawing.Size(126, 20);
            this.DatePickerFechaVencimiento.TabIndex = 39;
            // 
            // checkBoxAceptaEnvio
            // 
            this.checkBoxAceptaEnvio.AutoSize = true;
            this.checkBoxAceptaEnvio.Location = new System.Drawing.Point(318, 217);
            this.checkBoxAceptaEnvio.Name = "checkBoxAceptaEnvio";
            this.checkBoxAceptaEnvio.Size = new System.Drawing.Size(91, 17);
            this.checkBoxAceptaEnvio.TabIndex = 40;
            this.checkBoxAceptaEnvio.Text = "Acepta envío";
            this.checkBoxAceptaEnvio.UseVisualStyleBackColor = true;
            // 
            // ButtonEditar
            // 
            this.ButtonEditar.Location = new System.Drawing.Point(9, 260);
            this.ButtonEditar.Name = "ButtonEditar";
            this.ButtonEditar.Size = new System.Drawing.Size(175, 23);
            this.ButtonEditar.TabIndex = 41;
            this.ButtonEditar.Text = "Editar publicación";
            this.ButtonEditar.UseVisualStyleBackColor = true;
            this.ButtonEditar.Visible = false;
            this.ButtonEditar.Click += new System.EventHandler(this.ButtonEditar_Click);
            // 
            // ButtonGenerar
            // 
            this.ButtonGenerar.Location = new System.Drawing.Point(9, 260);
            this.ButtonGenerar.Name = "ButtonGenerar";
            this.ButtonGenerar.Size = new System.Drawing.Size(175, 23);
            this.ButtonGenerar.TabIndex = 42;
            this.ButtonGenerar.Text = "Generar nueva publicación";
            this.ButtonGenerar.UseVisualStyleBackColor = true;
            this.ButtonGenerar.Click += new System.EventHandler(this.ButtonGenerar_Click);
            // 
            // GenerarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 361);
            this.Controls.Add(this.ButtonGenerar);
            this.Controls.Add(this.ButtonEditar);
            this.Controls.Add(this.checkBoxAceptaEnvio);
            this.Controls.Add(this.DatePickerFechaVencimiento);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.DatePickerFechaInicio);
            this.Controls.Add(this.textBoxStock);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxPrecio);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxPrecioReserva);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "GenerarPublicacion";
            this.Text = "Generar Publicación";
            this.Load += new System.EventHandler(this.GenerarPublicacion_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ComboEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCodPublicacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboTipoPublicacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ComboRubro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelNomUsuario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ComboVisibilidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxPrecioReserva;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxPrecio;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxStock;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker DatePickerFechaInicio;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker DatePickerFechaVencimiento;
        private System.Windows.Forms.CheckBox checkBoxAceptaEnvio;
        private System.Windows.Forms.RichTextBox RichTextBoxDescripcion;
        private System.Windows.Forms.Button ButtonEditar;
        private System.Windows.Forms.Button ButtonGenerar;
    }
}