namespace Hitori_Visual
{
    partial class frmHitori
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHitori));
            this.pbxTablero = new System.Windows.Forms.PictureBox();
            this.gbxContenedor = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxElementos = new System.Windows.Forms.GroupBox();
            this.nudrange = new System.Windows.Forms.NumericUpDown();
            this.nudCount = new System.Windows.Forms.NumericUpDown();
            this.lblRangodeNumeros = new System.Windows.Forms.Label();
            this.lblDimension = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTablero)).BeginInit();
            this.gbxContenedor.SuspendLayout();
            this.gbxElementos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudrange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxTablero
            // 
            this.pbxTablero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxTablero.Location = new System.Drawing.Point(12, 12);
            this.pbxTablero.Name = "pbxTablero";
            this.pbxTablero.Size = new System.Drawing.Size(420, 420);
            this.pbxTablero.TabIndex = 0;
            this.pbxTablero.TabStop = false;
            this.pbxTablero.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxTablero_Paint);
            this.pbxTablero.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbxTablero_MouseClick);
            // 
            // gbxContenedor
            // 
            this.gbxContenedor.Controls.Add(this.btnSalir);
            this.gbxContenedor.Controls.Add(this.btnCargar);
            this.gbxContenedor.Controls.Add(this.btnRestart);
            this.gbxContenedor.Controls.Add(this.btnSalvar);
            this.gbxContenedor.Controls.Add(this.label1);
            this.gbxContenedor.Location = new System.Drawing.Point(446, 235);
            this.gbxContenedor.Name = "gbxContenedor";
            this.gbxContenedor.Size = new System.Drawing.Size(180, 197);
            this.gbxContenedor.TabIndex = 1;
            this.gbxContenedor.TabStop = false;
            this.gbxContenedor.Text = "Eventos";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(33, 154);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(115, 23);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir del Juego";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(33, 71);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(115, 23);
            this.btnCargar.TabIndex = 5;
            this.btnCargar.Text = "Cargar Juego";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(33, 29);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(115, 23);
            this.btnRestart.TabIndex = 4;
            this.btnRestart.Text = "Reiniciar Juego";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(33, 113);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(115, 23);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "Salvar Juego";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, -97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rango";
            // 
            // gbxElementos
            // 
            this.gbxElementos.Controls.Add(this.nudrange);
            this.gbxElementos.Controls.Add(this.nudCount);
            this.gbxElementos.Controls.Add(this.lblRangodeNumeros);
            this.gbxElementos.Controls.Add(this.lblDimension);
            this.gbxElementos.Controls.Add(this.btnNuevo);
            this.gbxElementos.Location = new System.Drawing.Point(446, 12);
            this.gbxElementos.Name = "gbxElementos";
            this.gbxElementos.Size = new System.Drawing.Size(180, 157);
            this.gbxElementos.TabIndex = 2;
            this.gbxElementos.TabStop = false;
            this.gbxElementos.Text = "Opciones del tablero";
            // 
            // nudrange
            // 
            this.nudrange.Location = new System.Drawing.Point(106, 73);
            this.nudrange.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudrange.Name = "nudrange";
            this.nudrange.Size = new System.Drawing.Size(53, 20);
            this.nudrange.TabIndex = 1;
            this.nudrange.UseWaitCursor = true;
            this.nudrange.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nudCount
            // 
            this.nudCount.Location = new System.Drawing.Point(106, 31);
            this.nudCount.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudCount.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudCount.Name = "nudCount";
            this.nudCount.Size = new System.Drawing.Size(53, 20);
            this.nudCount.TabIndex = 1;
            this.nudCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblRangodeNumeros
            // 
            this.lblRangodeNumeros.AutoSize = true;
            this.lblRangodeNumeros.Location = new System.Drawing.Point(19, 75);
            this.lblRangodeNumeros.Name = "lblRangodeNumeros";
            this.lblRangodeNumeros.Size = new System.Drawing.Size(39, 13);
            this.lblRangodeNumeros.TabIndex = 0;
            this.lblRangodeNumeros.Text = "Rango";
            // 
            // lblDimension
            // 
            this.lblDimension.AutoSize = true;
            this.lblDimension.Location = new System.Drawing.Point(19, 33);
            this.lblDimension.Name = "lblDimension";
            this.lblDimension.Size = new System.Drawing.Size(56, 13);
            this.lblDimension.TabIndex = 0;
            this.lblDimension.Text = "Dimensión";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(33, 119);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(115, 23);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo Juego";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevoJuego_Click);
            // 
            // frmHitori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(640, 448);
            this.Controls.Add(this.gbxElementos);
            this.Controls.Add(this.gbxContenedor);
            this.Controls.Add(this.pbxTablero);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmHitori";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hitori";
            ((System.ComponentModel.ISupportInitialize)(this.pbxTablero)).EndInit();
            this.gbxContenedor.ResumeLayout(false);
            this.gbxContenedor.PerformLayout();
            this.gbxElementos.ResumeLayout(false);
            this.gbxElementos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudrange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxTablero;
        private System.Windows.Forms.GroupBox gbxContenedor;
        private System.Windows.Forms.GroupBox gbxElementos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRangodeNumeros;
        private System.Windows.Forms.Label lblDimension;
        private System.Windows.Forms.NumericUpDown nudrange;
        private System.Windows.Forms.NumericUpDown nudCount;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnSalir;
    }
}

