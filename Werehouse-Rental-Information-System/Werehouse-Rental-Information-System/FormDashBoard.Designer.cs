namespace Werehouse_Rental_Information_System
{
    partial class FormDashBoard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPeringatan = new System.Windows.Forms.DataGridView();
            this.Penyewa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.chartPendapatan = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblJatuhTempo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPendapatan = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGudangTersedia = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalGudang = new System.Windows.Forms.Label();
            this.chartOkupansi = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeringatan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPendapatan)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartOkupansi)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(35, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Medussa WereHouse - DashBoard";
            // 
            // dgvPeringatan
            // 
            this.dgvPeringatan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeringatan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Penyewa,
            this.Gudang,
            this.tempo,
            this.nominal,
            this.Status});
            this.dgvPeringatan.Location = new System.Drawing.Point(12, 54);
            this.dgvPeringatan.Name = "dgvPeringatan";
            this.dgvPeringatan.RowTemplate.Height = 24;
            this.dgvPeringatan.Size = new System.Drawing.Size(1675, 227);
            this.dgvPeringatan.TabIndex = 4;
            // 
            // Penyewa
            // 
            this.Penyewa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Penyewa.HeaderText = "Nama Penyewa";
            this.Penyewa.Name = "Penyewa";
            // 
            // Gudang
            // 
            this.Gudang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Gudang.HeaderText = "Nama Gudang";
            this.Gudang.Name = "Gudang";
            // 
            // tempo
            // 
            this.tempo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tempo.HeaderText = "Jatuh Tempo";
            this.tempo.Name = "tempo";
            // 
            // nominal
            // 
            this.nominal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nominal.HeaderText = "Nominal yang harus dibayar";
            this.nominal.Name = "nominal";
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.HeaderText = "Status Bayar";
            this.Status.Name = "Status";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(16, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(364, 40);
            this.label10.TabIndex = 14;
            this.label10.Text = "⚠️ PERINGATAN KONTRAK JATUH TEMPO \r\n\r\n";
            // 
            // chartPendapatan
            // 
            chartArea1.Name = "ChartArea1";
            this.chartPendapatan.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPendapatan.Legends.Add(legend1);
            this.chartPendapatan.Location = new System.Drawing.Point(907, 140);
            this.chartPendapatan.Name = "chartPendapatan";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartPendapatan.Series.Add(series1);
            this.chartPendapatan.Size = new System.Drawing.Size(781, 245);
            this.chartPendapatan.TabIndex = 14;
            this.chartPendapatan.Text = "Grafik Pendapatan";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.groupBox4);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.chartPendapatan);
            this.panel3.Controls.Add(this.chartOkupansi);
            this.panel3.Location = new System.Drawing.Point(39, 77);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1702, 410);
            this.panel3.TabIndex = 19;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.lblJatuhTempo);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Location = new System.Drawing.Point(1453, 67);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox4.Size = new System.Drawing.Size(234, 67);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Jatuh Tempo";
            // 
            // lblJatuhTempo
            // 
            this.lblJatuhTempo.AutoSize = true;
            this.lblJatuhTempo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJatuhTempo.Location = new System.Drawing.Point(13, 43);
            this.lblJatuhTempo.Name = "lblJatuhTempo";
            this.lblJatuhTempo.Size = new System.Drawing.Size(39, 20);
            this.lblJatuhTempo.TabIndex = 10;
            this.lblJatuhTempo.Text = "000";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblPendapatan);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(907, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(315, 67);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Pendapatan Bulan ini";
            // 
            // lblPendapatan
            // 
            this.lblPendapatan.AutoSize = true;
            this.lblPendapatan.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendapatan.Location = new System.Drawing.Point(13, 38);
            this.lblPendapatan.Name = "lblPendapatan";
            this.lblPendapatan.Size = new System.Drawing.Size(39, 20);
            this.lblPendapatan.TabIndex = 10;
            this.lblPendapatan.Text = "000";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblGudangTersedia);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(612, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(251, 67);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Gudang Tersedia";
            // 
            // lblGudangTersedia
            // 
            this.lblGudangTersedia.AutoSize = true;
            this.lblGudangTersedia.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGudangTersedia.Location = new System.Drawing.Point(13, 43);
            this.lblGudangTersedia.Name = "lblGudangTersedia";
            this.lblGudangTersedia.Size = new System.Drawing.Size(39, 20);
            this.lblGudangTersedia.TabIndex = 10;
            this.lblGudangTersedia.Text = "000";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(16, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(135, 20);
            this.label15.TabIndex = 15;
            this.label15.Text = "Statistik Utama";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.lblTotalGudang);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(12, 67);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox3.Size = new System.Drawing.Size(271, 67);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Total Gudang";
            // 
            // lblTotalGudang
            // 
            this.lblTotalGudang.AutoSize = true;
            this.lblTotalGudang.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalGudang.Location = new System.Drawing.Point(13, 43);
            this.lblTotalGudang.Name = "lblTotalGudang";
            this.lblTotalGudang.Size = new System.Drawing.Size(39, 20);
            this.lblTotalGudang.TabIndex = 10;
            this.lblTotalGudang.Text = "000";
            // 
            // chartOkupansi
            // 
            chartArea2.Name = "ChartArea1";
            this.chartOkupansi.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartOkupansi.Legends.Add(legend2);
            this.chartOkupansi.Location = new System.Drawing.Point(12, 140);
            this.chartOkupansi.Name = "chartOkupansi";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartOkupansi.Series.Add(series2);
            this.chartOkupansi.Size = new System.Drawing.Size(851, 245);
            this.chartOkupansi.TabIndex = 14;
            this.chartOkupansi.Text = "Okupansi Gudang";
            this.chartOkupansi.Click += new System.EventHandler(this.chartOkupansi_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Controls.Add(this.dgvPeringatan);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Location = new System.Drawing.Point(39, 545);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1702, 300);
            this.panel4.TabIndex = 20;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Lime;
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRefresh.Location = new System.Drawing.Point(39, 502);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(123, 37);
            this.btnRefresh.TabIndex = 21;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // FormDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1765, 883);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDashBoard";
            this.Text = "FormDashBoard";
            this.Load += new System.EventHandler(this.FormDashBoard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeringatan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPendapatan)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartOkupansi)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPeringatan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPendapatan;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalGudang;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOkupansi;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPendapatan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblGudangTersedia;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblJatuhTempo;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Penyewa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn tempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nominal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}