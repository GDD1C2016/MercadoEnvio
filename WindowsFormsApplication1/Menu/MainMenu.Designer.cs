namespace MercadoEnvio.Menu
{
    partial class MainMenu
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
            this.BtnRol = new System.Windows.Forms.Button();
            this.GroupBoxABM = new System.Windows.Forms.GroupBox();
            this.BtnVisibilidad = new System.Windows.Forms.Button();
            this.BtnUsuario = new System.Windows.Forms.Button();
            this.BtnRubro = new System.Windows.Forms.Button();
            this.BtnCalificar = new System.Windows.Forms.Button();
            this.BtnPublicacion = new System.Windows.Forms.Button();
            this.BtnFactura = new System.Windows.Forms.Button();
            this.BtnPublicar = new System.Windows.Forms.Button();
            this.BtnHistorial = new System.Windows.Forms.Button();
            this.BtnListado = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.GroupBoxABM.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnRol
            // 
            this.BtnRol.Location = new System.Drawing.Point(12, 23);
            this.BtnRol.Name = "BtnRol";
            this.BtnRol.Size = new System.Drawing.Size(382, 23);
            this.BtnRol.TabIndex = 0;
            this.BtnRol.Text = "Rol";
            this.BtnRol.UseVisualStyleBackColor = true;
            this.BtnRol.Click += new System.EventHandler(this.BtnRol_Click);
            // 
            // GroupBoxABM
            // 
            this.GroupBoxABM.Controls.Add(this.BtnVisibilidad);
            this.GroupBoxABM.Controls.Add(this.BtnUsuario);
            this.GroupBoxABM.Controls.Add(this.BtnRubro);
            this.GroupBoxABM.Controls.Add(this.BtnRol);
            this.GroupBoxABM.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GroupBoxABM.Location = new System.Drawing.Point(0, 239);
            this.GroupBoxABM.Name = "GroupBoxABM";
            this.GroupBoxABM.Size = new System.Drawing.Size(406, 139);
            this.GroupBoxABM.TabIndex = 1;
            this.GroupBoxABM.TabStop = false;
            this.GroupBoxABM.Text = "ABM";
            // 
            // BtnVisibilidad
            // 
            this.BtnVisibilidad.Location = new System.Drawing.Point(12, 110);
            this.BtnVisibilidad.Name = "BtnVisibilidad";
            this.BtnVisibilidad.Size = new System.Drawing.Size(382, 23);
            this.BtnVisibilidad.TabIndex = 3;
            this.BtnVisibilidad.Text = "Visibilidad";
            this.BtnVisibilidad.UseVisualStyleBackColor = true;
            this.BtnVisibilidad.Click += new System.EventHandler(this.BtnVisibilidad_Click);
            // 
            // BtnUsuario
            // 
            this.BtnUsuario.Location = new System.Drawing.Point(12, 81);
            this.BtnUsuario.Name = "BtnUsuario";
            this.BtnUsuario.Size = new System.Drawing.Size(382, 23);
            this.BtnUsuario.TabIndex = 2;
            this.BtnUsuario.Text = "Usuario";
            this.BtnUsuario.UseVisualStyleBackColor = true;
            this.BtnUsuario.Click += new System.EventHandler(this.BtnUsuario_Click);
            // 
            // BtnRubro
            // 
            this.BtnRubro.Location = new System.Drawing.Point(12, 52);
            this.BtnRubro.Name = "BtnRubro";
            this.BtnRubro.Size = new System.Drawing.Size(382, 23);
            this.BtnRubro.TabIndex = 1;
            this.BtnRubro.Text = "Rubro";
            this.BtnRubro.UseVisualStyleBackColor = true;
            this.BtnRubro.Click += new System.EventHandler(this.BtnRubro_Click);
            // 
            // BtnCalificar
            // 
            this.BtnCalificar.Location = new System.Drawing.Point(12, 78);
            this.BtnCalificar.Name = "BtnCalificar";
            this.BtnCalificar.Size = new System.Drawing.Size(382, 23);
            this.BtnCalificar.TabIndex = 2;
            this.BtnCalificar.Text = "Calificar al Vendedor";
            this.BtnCalificar.UseVisualStyleBackColor = true;
            this.BtnCalificar.Click += new System.EventHandler(this.BtnCalificar_Click);
            // 
            // BtnPublicacion
            // 
            this.BtnPublicacion.Location = new System.Drawing.Point(12, 20);
            this.BtnPublicacion.Name = "BtnPublicacion";
            this.BtnPublicacion.Size = new System.Drawing.Size(382, 23);
            this.BtnPublicacion.TabIndex = 3;
            this.BtnPublicacion.Text = "Comprar/Ofertar";
            this.BtnPublicacion.UseVisualStyleBackColor = true;
            this.BtnPublicacion.Click += new System.EventHandler(this.BtnPublicacion_Click);
            // 
            // BtnFactura
            // 
            this.BtnFactura.Location = new System.Drawing.Point(12, 136);
            this.BtnFactura.Name = "BtnFactura";
            this.BtnFactura.Size = new System.Drawing.Size(382, 23);
            this.BtnFactura.TabIndex = 4;
            this.BtnFactura.Text = "Consulta de Facturas Realizadas al Vendedor";
            this.BtnFactura.UseVisualStyleBackColor = true;
            this.BtnFactura.Click += new System.EventHandler(this.BtnFactura_Click);
            // 
            // BtnPublicar
            // 
            this.BtnPublicar.Location = new System.Drawing.Point(12, 49);
            this.BtnPublicar.Name = "BtnPublicar";
            this.BtnPublicar.Size = new System.Drawing.Size(382, 23);
            this.BtnPublicar.TabIndex = 5;
            this.BtnPublicar.Text = "Generar Publicación";
            this.BtnPublicar.UseVisualStyleBackColor = true;
            this.BtnPublicar.Click += new System.EventHandler(this.BtnPublicar_Click);
            // 
            // BtnHistorial
            // 
            this.BtnHistorial.Location = new System.Drawing.Point(12, 107);
            this.BtnHistorial.Name = "BtnHistorial";
            this.BtnHistorial.Size = new System.Drawing.Size(382, 23);
            this.BtnHistorial.TabIndex = 6;
            this.BtnHistorial.Text = "Historial del Cliente";
            this.BtnHistorial.UseVisualStyleBackColor = true;
            this.BtnHistorial.Click += new System.EventHandler(this.BtnHistorial_Click);
            // 
            // BtnListado
            // 
            this.BtnListado.Location = new System.Drawing.Point(12, 165);
            this.BtnListado.Name = "BtnListado";
            this.BtnListado.Size = new System.Drawing.Size(382, 23);
            this.BtnListado.TabIndex = 7;
            this.BtnListado.Text = "Listado Estadístico";
            this.BtnListado.UseVisualStyleBackColor = true;
            this.BtnListado.Click += new System.EventHandler(this.BtnListado_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnCerrar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 45);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Location = new System.Drawing.Point(12, 13);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(382, 23);
            this.BtnCerrar.TabIndex = 0;
            this.BtnCerrar.Text = "Cerrar Sesión";
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnCalificar);
            this.groupBox2.Controls.Add(this.BtnPublicacion);
            this.groupBox2.Controls.Add(this.BtnListado);
            this.groupBox2.Controls.Add(this.BtnFactura);
            this.groupBox2.Controls.Add(this.BtnHistorial);
            this.groupBox2.Controls.Add(this.BtnPublicar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(406, 194);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opciones";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 378);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GroupBoxABM);
            this.MaximumSize = new System.Drawing.Size(422, 417);
            this.MinimumSize = new System.Drawing.Size(422, 417);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu MercadoEnvío";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.GroupBoxABM.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnRol;
        private System.Windows.Forms.GroupBox GroupBoxABM;
        private System.Windows.Forms.Button BtnVisibilidad;
        private System.Windows.Forms.Button BtnUsuario;
        private System.Windows.Forms.Button BtnRubro;
        private System.Windows.Forms.Button BtnCalificar;
        private System.Windows.Forms.Button BtnPublicacion;
        private System.Windows.Forms.Button BtnFactura;
        private System.Windows.Forms.Button BtnPublicar;
        private System.Windows.Forms.Button BtnHistorial;
        private System.Windows.Forms.Button BtnListado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}