namespace BDcreadorCSVoleDB
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btVerAnalisis = new System.Windows.Forms.Button();
            this.btBDguardar = new System.Windows.Forms.Button();
            this.cbBDtabla = new System.Windows.Forms.ComboBox();
            this.btBDverTABLA = new System.Windows.Forms.Button();
            this.btBDcargar = new System.Windows.Forms.Button();
            this.btBDcrear = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbNumPilotos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNumAutomoviles = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNumAjustadores = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialogBD = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogBD = new System.Windows.Forms.SaveFileDialog();
            this.tbNumChoques = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.tbMaxChoquesPorDia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbMaxDiasSinChoque = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btVerAnalisis);
            this.groupBox1.Controls.Add(this.btBDguardar);
            this.groupBox1.Controls.Add(this.cbBDtabla);
            this.groupBox1.Controls.Add(this.btBDverTABLA);
            this.groupBox1.Controls.Add(this.btBDcargar);
            this.groupBox1.Controls.Add(this.btBDcrear);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(853, 183);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Base de Datos";
            // 
            // btVerAnalisis
            // 
            this.btVerAnalisis.Enabled = false;
            this.btVerAnalisis.Location = new System.Drawing.Point(6, 135);
            this.btVerAnalisis.Name = "btVerAnalisis";
            this.btVerAnalisis.Size = new System.Drawing.Size(282, 42);
            this.btVerAnalisis.TabIndex = 5;
            this.btVerAnalisis.Text = "Analizar";
            this.btVerAnalisis.UseVisualStyleBackColor = true;
            this.btVerAnalisis.Click += new System.EventHandler(this.btVerAnalisis_Click);
            // 
            // btBDguardar
            // 
            this.btBDguardar.Enabled = false;
            this.btBDguardar.Location = new System.Drawing.Point(102, 39);
            this.btBDguardar.Name = "btBDguardar";
            this.btBDguardar.Size = new System.Drawing.Size(90, 42);
            this.btBDguardar.TabIndex = 4;
            this.btBDguardar.Text = "Guardar";
            this.btBDguardar.UseVisualStyleBackColor = true;
            this.btBDguardar.Click += new System.EventHandler(this.btBDguardar_Click);
            // 
            // cbBDtabla
            // 
            this.cbBDtabla.DropDownWidth = 200;
            this.cbBDtabla.FormattingEnabled = true;
            this.cbBDtabla.Location = new System.Drawing.Point(6, 92);
            this.cbBDtabla.Name = "cbBDtabla";
            this.cbBDtabla.Size = new System.Drawing.Size(156, 28);
            this.cbBDtabla.TabIndex = 1;
            // 
            // btBDverTABLA
            // 
            this.btBDverTABLA.Enabled = false;
            this.btBDverTABLA.Location = new System.Drawing.Point(168, 92);
            this.btBDverTABLA.Name = "btBDverTABLA";
            this.btBDverTABLA.Size = new System.Drawing.Size(120, 37);
            this.btBDverTABLA.TabIndex = 3;
            this.btBDverTABLA.Text = "Ver Tabla";
            this.btBDverTABLA.UseVisualStyleBackColor = true;
            this.btBDverTABLA.Click += new System.EventHandler(this.btBDverTABLA_Click);
            // 
            // btBDcargar
            // 
            this.btBDcargar.Location = new System.Drawing.Point(198, 39);
            this.btBDcargar.Name = "btBDcargar";
            this.btBDcargar.Size = new System.Drawing.Size(90, 42);
            this.btBDcargar.TabIndex = 2;
            this.btBDcargar.Text = "Cargar";
            this.btBDcargar.UseVisualStyleBackColor = true;
            this.btBDcargar.Click += new System.EventHandler(this.btBDcargar_Click);
            // 
            // btBDcrear
            // 
            this.btBDcrear.Location = new System.Drawing.Point(6, 39);
            this.btBDcrear.Name = "btBDcrear";
            this.btBDcrear.Size = new System.Drawing.Size(90, 42);
            this.btBDcrear.TabIndex = 1;
            this.btBDcrear.Text = "Crear";
            this.btBDcrear.UseVisualStyleBackColor = true;
            this.btBDcrear.Click += new System.EventHandler(this.btBDcrear_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbNumPilotos);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbNumAutomoviles);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbNumAjustadores);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(324, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 147);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Por Aseguradora";
            // 
            // tbNumPilotos
            // 
            this.tbNumPilotos.Location = new System.Drawing.Point(117, 99);
            this.tbNumPilotos.Name = "tbNumPilotos";
            this.tbNumPilotos.Size = new System.Drawing.Size(101, 26);
            this.tbNumPilotos.TabIndex = 6;
            this.tbNumPilotos.Text = "20";
            this.tbNumPilotos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pilotos";
            // 
            // tbNumAutomoviles
            // 
            this.tbNumAutomoviles.Location = new System.Drawing.Point(117, 67);
            this.tbNumAutomoviles.Name = "tbNumAutomoviles";
            this.tbNumAutomoviles.Size = new System.Drawing.Size(101, 26);
            this.tbNumAutomoviles.TabIndex = 4;
            this.tbNumAutomoviles.Text = "10";
            this.tbNumAutomoviles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Automoviles";
            // 
            // tbNumAjustadores
            // 
            this.tbNumAjustadores.Location = new System.Drawing.Point(117, 35);
            this.tbNumAjustadores.Name = "tbNumAjustadores";
            this.tbNumAjustadores.Size = new System.Drawing.Size(101, 26);
            this.tbNumAjustadores.TabIndex = 2;
            this.tbNumAjustadores.Text = "3";
            this.tbNumAjustadores.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ajustadores";
            // 
            // openFileDialogBD
            // 
            this.openFileDialogBD.FileName = "openFileDialog1";
            this.openFileDialogBD.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogBD_FileOk);
            // 
            // saveFileDialogBD
            // 
            this.saveFileDialogBD.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialogBD_FileOk);
            // 
            // tbNumChoques
            // 
            this.tbNumChoques.Location = new System.Drawing.Point(693, 74);
            this.tbNumChoques.Name = "tbNumChoques";
            this.tbNumChoques.Size = new System.Drawing.Size(149, 26);
            this.tbNumChoques.TabIndex = 10;
            this.tbNumChoques.Text = "60000";
            this.tbNumChoques.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(614, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Choques";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(614, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Inicio";
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicial.Location = new System.Drawing.Point(693, 42);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(149, 26);
            this.dtpFechaInicial.TabIndex = 12;
            this.dtpFechaInicial.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // tbMaxChoquesPorDia
            // 
            this.tbMaxChoquesPorDia.Location = new System.Drawing.Point(780, 112);
            this.tbMaxChoquesPorDia.Name = "tbMaxChoquesPorDia";
            this.tbMaxChoquesPorDia.Size = new System.Drawing.Size(62, 26);
            this.tbMaxChoquesPorDia.TabIndex = 8;
            this.tbMaxChoquesPorDia.Text = "10";
            this.tbMaxChoquesPorDia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(614, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Max Choques / Dia";
            // 
            // tbMaxDiasSinChoque
            // 
            this.tbMaxDiasSinChoque.Location = new System.Drawing.Point(780, 145);
            this.tbMaxDiasSinChoque.Name = "tbMaxDiasSinChoque";
            this.tbMaxDiasSinChoque.Size = new System.Drawing.Size(62, 26);
            this.tbMaxDiasSinChoque.TabIndex = 14;
            this.tbMaxDiasSinChoque.Text = "3";
            this.tbMaxDiasSinChoque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(614, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Max Dias sin Choque";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 209);
            this.Controls.Add(this.tbMaxDiasSinChoque);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbMaxChoquesPorDia);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpFechaInicial);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbNumChoques);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPrincipal";
            this.ShowIcon = false;
            this.Text = "BD choques automovilisticos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbBDtabla;
        private System.Windows.Forms.Button btBDverTABLA;
        private System.Windows.Forms.Button btBDcargar;
        private System.Windows.Forms.Button btBDcrear;
        private System.Windows.Forms.OpenFileDialog openFileDialogBD;
        private System.Windows.Forms.Button btBDguardar;
        private System.Windows.Forms.SaveFileDialog saveFileDialogBD;
        private System.Windows.Forms.Button btVerAnalisis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNumAjustadores;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbNumPilotos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNumAutomoviles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNumChoques;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.TextBox tbMaxChoquesPorDia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbMaxDiasSinChoque;
        private System.Windows.Forms.Label label7;
    }
}

