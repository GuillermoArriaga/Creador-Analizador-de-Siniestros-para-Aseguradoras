namespace BDcreadorCSVoleDB
{
    partial class frmAnalisis
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btAnalisis = new System.Windows.Forms.Button();
            this.cbAnalisisElemento = new System.Windows.Forms.ComboBox();
            this.tbFechaFin = new System.Windows.Forms.TextBox();
            this.tbFechaIni = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbAnalisisTipo = new System.Windows.Forms.ComboBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tbPrima = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btAnalisis
            // 
            this.btAnalisis.Location = new System.Drawing.Point(12, 12);
            this.btAnalisis.Name = "btAnalisis";
            this.btAnalisis.Size = new System.Drawing.Size(120, 37);
            this.btAnalisis.TabIndex = 24;
            this.btAnalisis.Text = "Análisis";
            this.btAnalisis.UseVisualStyleBackColor = true;
            this.btAnalisis.Click += new System.EventHandler(this.btAnalisis_Click);
            // 
            // cbAnalisisElemento
            // 
            this.cbAnalisisElemento.DropDownWidth = 300;
            this.cbAnalisisElemento.FormattingEnabled = true;
            this.cbAnalisisElemento.Location = new System.Drawing.Point(385, 17);
            this.cbAnalisisElemento.Name = "cbAnalisisElemento";
            this.cbAnalisisElemento.Size = new System.Drawing.Size(192, 28);
            this.cbAnalisisElemento.TabIndex = 31;
            // 
            // tbFechaFin
            // 
            this.tbFechaFin.Location = new System.Drawing.Point(756, 17);
            this.tbFechaFin.Name = "tbFechaFin";
            this.tbFechaFin.Size = new System.Drawing.Size(108, 26);
            this.tbFechaFin.TabIndex = 30;
            this.tbFechaFin.Text = "31/12/2000";
            this.tbFechaFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbFechaIni
            // 
            this.tbFechaIni.Location = new System.Drawing.Point(618, 17);
            this.tbFechaIni.Name = "tbFechaIni";
            this.tbFechaIni.Size = new System.Drawing.Size(110, 26);
            this.tbFechaIni.TabIndex = 29;
            this.tbFechaIni.Text = "01/01/2000";
            this.tbFechaIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(732, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 20);
            this.label10.TabIndex = 28;
            this.label10.Text = "al";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(582, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 20);
            this.label9.TabIndex = 27;
            this.label9.Text = "del";
            // 
            // cbAnalisisTipo
            // 
            this.cbAnalisisTipo.DropDownWidth = 300;
            this.cbAnalisisTipo.FormattingEnabled = true;
            this.cbAnalisisTipo.Location = new System.Drawing.Point(199, 17);
            this.cbAnalisisTipo.Name = "cbAnalisisTipo";
            this.cbAnalisisTipo.Size = new System.Drawing.Size(180, 28);
            this.cbAnalisisTipo.TabIndex = 26;
            this.cbAnalisisTipo.SelectedIndexChanged += new System.EventHandler(this.cbAnalisisTipo_SelectedIndexChanged);
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(12, 54);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(853, 478);
            this.chart.TabIndex = 25;
            this.chart.Text = "chart1";
            this.chart.Click += new System.EventHandler(this.chart_Click);
            // 
            // tbPrima
            // 
            this.tbPrima.Location = new System.Drawing.Point(138, 19);
            this.tbPrima.Name = "tbPrima";
            this.tbPrima.Size = new System.Drawing.Size(55, 26);
            this.tbPrima.TabIndex = 32;
            this.tbPrima.Text = "0.1";
            this.tbPrima.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(599, 42);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 28;
            this.dgv.Size = new System.Drawing.Size(12, 10);
            this.dgv.TabIndex = 33;
            this.dgv.Visible = false;
            // 
            // frmAnalisis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 544);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.tbPrima);
            this.Controls.Add(this.btAnalisis);
            this.Controls.Add(this.cbAnalisisElemento);
            this.Controls.Add(this.tbFechaFin);
            this.Controls.Add(this.tbFechaIni);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbAnalisisTipo);
            this.Controls.Add(this.chart);
            this.Name = "frmAnalisis";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Herramienta de Análisis de Información";
            this.Load += new System.EventHandler(this.frmAnalisis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAnalisis;
        private System.Windows.Forms.ComboBox cbAnalisisElemento;
        private System.Windows.Forms.TextBox tbFechaFin;
        private System.Windows.Forms.TextBox tbFechaIni;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbAnalisisTipo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.TextBox tbPrima;
        private System.Windows.Forms.DataGridView dgv;
    }
}