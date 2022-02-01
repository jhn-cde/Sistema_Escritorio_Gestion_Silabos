namespace CapaPresentacion
{
    partial class C_Silabo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSubirSilabo = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelLine = new System.Windows.Forms.Panel();
            this.panelResumen = new System.Windows.Forms.Panel();
            this.chartAvance2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelTemaUltimo = new System.Windows.Forms.Label();
            this.labelTemasRestantes = new System.Windows.Forms.Label();
            this.labelTemasCursados = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelReporte = new System.Windows.Forms.Label();
            this.chartAvance = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvSubirSilabo = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelResumen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAvance2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAvance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubirSilabo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnAtras);
            this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.btnEditar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.btnSubirSilabo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(666, 91);
            this.panel1.TabIndex = 4;
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.White;
            this.btnAtras.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAtras.FlatAppearance.BorderSize = 0;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtras.Location = new System.Drawing.Point(0, 0);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(80, 80);
            this.btnAtras.TabIndex = 15;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.BackColor = System.Drawing.Color.White;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.Black;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.Location = new System.Drawing.Point(418, 32);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(74, 27);
            this.btnAgregar.TabIndex = 14;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.White;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.Black;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.Location = new System.Drawing.Point(578, 32);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(74, 26);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.BackColor = System.Drawing.Color.White;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.Black;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.Location = new System.Drawing.Point(498, 32);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(74, 26);
            this.btnEditar.TabIndex = 12;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.White;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.diskette_24;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(197, 30);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 31);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSubirSilabo
            // 
            this.btnSubirSilabo.BackColor = System.Drawing.Color.White;
            this.btnSubirSilabo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubirSilabo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubirSilabo.Location = new System.Drawing.Point(94, 31);
            this.btnSubirSilabo.Name = "btnSubirSilabo";
            this.btnSubirSilabo.Size = new System.Drawing.Size(97, 30);
            this.btnSubirSilabo.TabIndex = 0;
            this.btnSubirSilabo.Text = "Subir Sílabo";
            this.btnSubirSilabo.UseVisualStyleBackColor = false;
            this.btnSubirSilabo.Click += new System.EventHandler(this.btnSubirSilabo_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panelLine);
            this.panel2.Controls.Add(this.panelResumen);
            this.panel2.Controls.Add(this.dgvSubirSilabo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(666, 383);
            this.panel2.TabIndex = 5;
            // 
            // panelLine
            // 
            this.panelLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLine.BackColor = System.Drawing.Color.Silver;
            this.panelLine.Location = new System.Drawing.Point(73, 208);
            this.panelLine.Name = "panelLine";
            this.panelLine.Size = new System.Drawing.Size(520, 1);
            this.panelLine.TabIndex = 5;
            // 
            // panelResumen
            // 
            this.panelResumen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelResumen.Controls.Add(this.chartAvance2);
            this.panelResumen.Controls.Add(this.labelTemaUltimo);
            this.panelResumen.Controls.Add(this.labelTemasRestantes);
            this.panelResumen.Controls.Add(this.labelTemasCursados);
            this.panelResumen.Controls.Add(this.label3);
            this.panelResumen.Controls.Add(this.label1);
            this.panelResumen.Controls.Add(this.label2);
            this.panelResumen.Controls.Add(this.labelReporte);
            this.panelResumen.Controls.Add(this.chartAvance);
            this.panelResumen.Location = new System.Drawing.Point(0, 220);
            this.panelResumen.Name = "panelResumen";
            this.panelResumen.Size = new System.Drawing.Size(666, 160);
            this.panelResumen.TabIndex = 1;
            // 
            // chartAvance2
            // 
            this.chartAvance2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.Title = "Fechas";
            chartArea1.AxisY.LabelStyle.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.Title = "Temas";
            chartArea1.Name = "ChartAvance";
            this.chartAvance2.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.DockedToChartArea = "ChartAvance";
            legend1.Name = "Legend1";
            this.chartAvance2.Legends.Add(legend1);
            this.chartAvance2.Location = new System.Drawing.Point(66, 0);
            this.chartAvance2.Name = "chartAvance2";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartAvance";
            series1.Color = System.Drawing.Color.Lime;
            series1.Legend = "Legend1";
            series1.Name = "Ideal";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartAvance";
            series2.Color = System.Drawing.Color.Blue;
            series2.Legend = "Legend1";
            series2.Name = "Real";
            this.chartAvance2.Series.Add(series1);
            this.chartAvance2.Series.Add(series2);
            this.chartAvance2.Size = new System.Drawing.Size(300, 160);
            this.chartAvance2.TabIndex = 8;
            this.chartAvance2.Text = "chart1";
            // 
            // labelTemaUltimo
            // 
            this.labelTemaUltimo.AutoSize = true;
            this.labelTemaUltimo.Location = new System.Drawing.Point(122, 95);
            this.labelTemaUltimo.Name = "labelTemaUltimo";
            this.labelTemaUltimo.Size = new System.Drawing.Size(43, 13);
            this.labelTemaUltimo.TabIndex = 7;
            this.labelTemaUltimo.Text = "Tema 1";
            // 
            // labelTemasRestantes
            // 
            this.labelTemasRestantes.AutoSize = true;
            this.labelTemasRestantes.Location = new System.Drawing.Point(122, 69);
            this.labelTemasRestantes.Name = "labelTemasRestantes";
            this.labelTemasRestantes.Size = new System.Drawing.Size(22, 13);
            this.labelTemasRestantes.TabIndex = 6;
            this.labelTemasRestantes.Text = "nro";
            // 
            // labelTemasCursados
            // 
            this.labelTemasCursados.AutoSize = true;
            this.labelTemasCursados.Location = new System.Drawing.Point(122, 44);
            this.labelTemasCursados.Name = "labelTemasCursados";
            this.labelTemasCursados.Size = new System.Drawing.Size(22, 13);
            this.labelTemasCursados.TabIndex = 5;
            this.labelTemasCursados.Text = "nro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ultimo Tema:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Temas Restantes:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Temas Avanzados:";
            // 
            // labelReporte
            // 
            this.labelReporte.AutoSize = true;
            this.labelReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReporte.Location = new System.Drawing.Point(0, 0);
            this.labelReporte.Name = "labelReporte";
            this.labelReporte.Size = new System.Drawing.Size(163, 20);
            this.labelReporte.TabIndex = 1;
            this.labelReporte.Text = "Reporte de Avance";
            // 
            // chartAvance
            // 
            this.chartAvance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.Title = "Nro Horas";
            chartArea2.AxisY.LabelStyle.Enabled = false;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.AxisY.Title = "Nro Temas";
            chartArea2.Name = "ChartAvance";
            this.chartAvance.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.DockedToChartArea = "ChartAvance";
            legend2.Name = "Legend1";
            this.chartAvance.Legends.Add(legend2);
            this.chartAvance.Location = new System.Drawing.Point(366, 0);
            this.chartAvance.Name = "chartAvance";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartAvance";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Lime;
            series3.Legend = "Legend1";
            series3.Name = "Ideal";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartAvance";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Blue;
            series4.Legend = "Legend1";
            series4.Name = "Real";
            this.chartAvance.Series.Add(series3);
            this.chartAvance.Series.Add(series4);
            this.chartAvance.Size = new System.Drawing.Size(300, 160);
            this.chartAvance.TabIndex = 0;
            this.chartAvance.Text = "chart1";
            // 
            // dgvSubirSilabo
            // 
            this.dgvSubirSilabo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSubirSilabo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubirSilabo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSubirSilabo.BackgroundColor = System.Drawing.Color.White;
            this.dgvSubirSilabo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSubirSilabo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubirSilabo.Location = new System.Drawing.Point(0, 95);
            this.dgvSubirSilabo.Name = "dgvSubirSilabo";
            this.dgvSubirSilabo.Size = new System.Drawing.Size(666, 100);
            this.dgvSubirSilabo.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Excel Files|*.xlsx";
            // 
            // C_Silabo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "C_Silabo";
            this.Size = new System.Drawing.Size(666, 383);
            this.Load += new System.EventHandler(this.C_Silabo_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelResumen.ResumeLayout(false);
            this.panelResumen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAvance2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAvance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubirSilabo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSubirSilabo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvSubirSilabo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Panel panelResumen;
        private System.Windows.Forms.Panel panelLine;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAvance;
        private System.Windows.Forms.Label labelTemaUltimo;
        private System.Windows.Forms.Label labelTemasRestantes;
        private System.Windows.Forms.Label labelTemasCursados;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelReporte;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAvance2;
    }
}
