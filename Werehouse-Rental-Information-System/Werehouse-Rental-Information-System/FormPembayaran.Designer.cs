namespace Werehouse_Rental_Information_System
{
    partial class FormPembayaran
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
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoKontrak = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvPembayaran = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPenyewa = new System.Windows.Forms.TextBox();
            this.txtGudang = new System.Windows.Forms.TextBox();
            this.txtSisaTagihan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTotalBayar = new System.Windows.Forms.TextBox();
            this.txtDenda = new System.Windows.Forms.TextBox();
            this.txtNominal = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpTanggalBayar = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.txtKeterangan = new System.Windows.Forms.TextBox();
            this.cbMetode = new System.Windows.Forms.ComboBox();
            this.btnPilihKontrak = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dtpJatuhTempo = new System.Windows.Forms.DateTimePicker();
            this.lblInfoDenda = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPembayaran)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(26, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "No Kontrak";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(47, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Medussa WereHouse - Pembayaran";
            // 
            // txtNoKontrak
            // 
            this.txtNoKontrak.Location = new System.Drawing.Point(148, 61);
            this.txtNoKontrak.Name = "txtNoKontrak";
            this.txtNoKontrak.Size = new System.Drawing.Size(550, 22);
            this.txtNoKontrak.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(31, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(182, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Riwayat Pembayaran";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.dgvPembayaran);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(51, 451);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1675, 317);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // dgvPembayaran
            // 
            this.dgvPembayaran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPembayaran.Location = new System.Drawing.Point(34, 69);
            this.dgvPembayaran.Name = "dgvPembayaran";
            this.dgvPembayaran.RowTemplate.Height = 24;
            this.dgvPembayaran.Size = new System.Drawing.Size(1591, 222);
            this.dgvPembayaran.TabIndex = 21;
            this.dgvPembayaran.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPembayaran_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Penyewa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Transaksi Pembayaran";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnHapus);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnSimpan);
            this.groupBox1.Controls.Add(this.btnPilihKontrak);
            this.groupBox1.Controls.Add(this.grpInput);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(51, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1675, 363);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpJatuhTempo);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtSisaTagihan);
            this.groupBox3.Controls.Add(this.txtGudang);
            this.groupBox3.Controls.Add(this.txtPenyewa);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtNoKontrak);
            this.groupBox3.Location = new System.Drawing.Point(34, 104);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(724, 219);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            // 
            // txtPenyewa
            // 
            this.txtPenyewa.Location = new System.Drawing.Point(148, 89);
            this.txtPenyewa.Name = "txtPenyewa";
            this.txtPenyewa.Size = new System.Drawing.Size(550, 22);
            this.txtPenyewa.TabIndex = 23;
            // 
            // txtGudang
            // 
            this.txtGudang.Location = new System.Drawing.Point(148, 117);
            this.txtGudang.Name = "txtGudang";
            this.txtGudang.Size = new System.Drawing.Size(550, 22);
            this.txtGudang.TabIndex = 24;
            // 
            // txtSisaTagihan
            // 
            this.txtSisaTagihan.Location = new System.Drawing.Point(148, 173);
            this.txtSisaTagihan.Name = "txtSisaTagihan";
            this.txtSisaTagihan.Size = new System.Drawing.Size(550, 22);
            this.txtSisaTagihan.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Detail Kontrak";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "Gudang";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Jatuh Tempo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 20);
            this.label7.TabIndex = 30;
            this.label7.Text = "Sisa Tagihan";
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.lblInfoDenda);
            this.grpInput.Controls.Add(this.cbMetode);
            this.grpInput.Controls.Add(this.label16);
            this.grpInput.Controls.Add(this.txtKeterangan);
            this.grpInput.Controls.Add(this.dtpTanggalBayar);
            this.grpInput.Controls.Add(this.label10);
            this.grpInput.Controls.Add(this.label11);
            this.grpInput.Controls.Add(this.label12);
            this.grpInput.Controls.Add(this.label13);
            this.grpInput.Controls.Add(this.txtTotalBayar);
            this.grpInput.Controls.Add(this.txtDenda);
            this.grpInput.Controls.Add(this.txtNominal);
            this.grpInput.Controls.Add(this.label14);
            this.grpInput.Controls.Add(this.label15);
            this.grpInput.Location = new System.Drawing.Point(799, 18);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(826, 281);
            this.grpInput.TabIndex = 31;
            this.grpInput.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(26, 209);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(177, 20);
            this.label10.TabIndex = 30;
            this.label10.Text = "Metode Pembayaran";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(26, 147);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 20);
            this.label11.TabIndex = 29;
            this.label11.Text = "Total Bayar";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(26, 119);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 20);
            this.label12.TabIndex = 28;
            this.label12.Text = "Denda";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(158, 20);
            this.label13.TabIndex = 27;
            this.label13.Text = "Input Pembayaran";
            // 
            // txtTotalBayar
            // 
            this.txtTotalBayar.Location = new System.Drawing.Point(233, 145);
            this.txtTotalBayar.Name = "txtTotalBayar";
            this.txtTotalBayar.Size = new System.Drawing.Size(550, 22);
            this.txtTotalBayar.TabIndex = 25;
            // 
            // txtDenda
            // 
            this.txtDenda.Location = new System.Drawing.Point(233, 117);
            this.txtDenda.Name = "txtDenda";
            this.txtDenda.Size = new System.Drawing.Size(550, 22);
            this.txtDenda.TabIndex = 24;
            // 
            // txtNominal
            // 
            this.txtNominal.Location = new System.Drawing.Point(233, 89);
            this.txtNominal.Name = "txtNominal";
            this.txtNominal.Size = new System.Drawing.Size(550, 22);
            this.txtNominal.TabIndex = 23;
            this.txtNominal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNominal_KeyPress);
            this.txtNominal.Leave += new System.EventHandler(this.txtNominal_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(26, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 20);
            this.label14.TabIndex = 12;
            this.label14.Text = "Nominal";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(26, 61);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(129, 20);
            this.label15.TabIndex = 22;
            this.label15.Text = "Tanggal Bayar";
            // 
            // dtpTanggalBayar
            // 
            this.dtpTanggalBayar.Location = new System.Drawing.Point(233, 61);
            this.dtpTanggalBayar.Name = "dtpTanggalBayar";
            this.dtpTanggalBayar.Size = new System.Drawing.Size(225, 22);
            this.dtpTanggalBayar.TabIndex = 31;
            this.dtpTanggalBayar.ValueChanged += new System.EventHandler(this.dtpTanggalBayar_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(26, 237);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 20);
            this.label16.TabIndex = 33;
            this.label16.Text = "Keterangan";
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.Location = new System.Drawing.Point(233, 235);
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(550, 22);
            this.txtKeterangan.TabIndex = 32;
            // 
            // cbMetode
            // 
            this.cbMetode.FormattingEnabled = true;
            this.cbMetode.Location = new System.Drawing.Point(233, 205);
            this.cbMetode.Name = "cbMetode";
            this.cbMetode.Size = new System.Drawing.Size(550, 24);
            this.cbMetode.TabIndex = 34;
            // 
            // btnPilihKontrak
            // 
            this.btnPilihKontrak.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPilihKontrak.Location = new System.Drawing.Point(35, 68);
            this.btnPilihKontrak.Name = "btnPilihKontrak";
            this.btnPilihKontrak.Size = new System.Drawing.Size(132, 30);
            this.btnPilihKontrak.TabIndex = 35;
            this.btnPilihKontrak.Text = "Pilih Kontrak";
            this.btnPilihKontrak.UseVisualStyleBackColor = true;
            this.btnPilihKontrak.Click += new System.EventHandler(this.btnPilihKontrak_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(1323, 314);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(132, 30);
            this.btnReset.TabIndex = 37;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapus.Location = new System.Drawing.Point(1157, 314);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(132, 30);
            this.btnHapus.TabIndex = 38;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(986, 314);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(132, 30);
            this.btnEdit.TabIndex = 39;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.Location = new System.Drawing.Point(799, 314);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(132, 30);
            this.btnSimpan.TabIndex = 36;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1493, 314);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 30);
            this.button2.TabIndex = 40;
            this.button2.Text = "Cetak";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dtpJatuhTempo
            // 
            this.dtpJatuhTempo.Location = new System.Drawing.Point(148, 147);
            this.dtpJatuhTempo.Name = "dtpJatuhTempo";
            this.dtpJatuhTempo.Size = new System.Drawing.Size(225, 22);
            this.dtpJatuhTempo.TabIndex = 35;
            // 
            // lblInfoDenda
            // 
            this.lblInfoDenda.AutoSize = true;
            this.lblInfoDenda.BackColor = System.Drawing.Color.Red;
            this.lblInfoDenda.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoDenda.Location = new System.Drawing.Point(229, 177);
            this.lblInfoDenda.Name = "lblInfoDenda";
            this.lblInfoDenda.Size = new System.Drawing.Size(98, 20);
            this.lblInfoDenda.TabIndex = 35;
            this.lblInfoDenda.Text = "Info Denda";
            // 
            // FormPembayaran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1765, 790);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPembayaran";
            this.Text = "FormPembayaran";
            this.Load += new System.EventHandler(this.FormPembayaran_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPembayaran)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoKontrak;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvPembayaran;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.ComboBox cbMetode;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtKeterangan;
        private System.Windows.Forms.DateTimePicker dtpTanggalBayar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTotalBayar;
        private System.Windows.Forms.TextBox txtDenda;
        private System.Windows.Forms.TextBox txtNominal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSisaTagihan;
        private System.Windows.Forms.TextBox txtGudang;
        private System.Windows.Forms.TextBox txtPenyewa;
        private System.Windows.Forms.Button btnPilihKontrak;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.DateTimePicker dtpJatuhTempo;
        private System.Windows.Forms.Label lblInfoDenda;
    }
}