namespace Werehouse_Rental_Information_System
{
    partial class FormGudang
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
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.txtLokasi = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbUkuran = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.txtHargaSewa = new System.Windows.Forms.TextBox();
            this.txtKeterangan = new System.Windows.Forms.TextBox();
            this.txtNamaGudang = new System.Windows.Forms.TextBox();
            this.txtKodeGudang = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpList = new System.Windows.Forms.GroupBox();
            this.dgvGudang = new System.Windows.Forms.DataGridView();
            this.btnCari = new System.Windows.Forms.Button();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.grpInput.SuspendLayout();
            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGudang)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(47, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Medussa WereHouse - Gudang";
            // 
            // grpInput
            // 
            this.grpInput.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.grpInput.Controls.Add(this.txtLokasi);
            this.grpInput.Controls.Add(this.label10);
            this.grpInput.Controls.Add(this.cbUkuran);
            this.grpInput.Controls.Add(this.label9);
            this.grpInput.Controls.Add(this.cbStatus);
            this.grpInput.Controls.Add(this.txtHargaSewa);
            this.grpInput.Controls.Add(this.txtKeterangan);
            this.grpInput.Controls.Add(this.txtNamaGudang);
            this.grpInput.Controls.Add(this.txtKodeGudang);
            this.grpInput.Controls.Add(this.btnReset);
            this.grpInput.Controls.Add(this.btnHapus);
            this.grpInput.Controls.Add(this.btnEdit);
            this.grpInput.Controls.Add(this.btnSimpan);
            this.grpInput.Controls.Add(this.label7);
            this.grpInput.Controls.Add(this.label6);
            this.grpInput.Controls.Add(this.label5);
            this.grpInput.Controls.Add(this.label4);
            this.grpInput.Controls.Add(this.label2);
            this.grpInput.Controls.Add(this.label3);
            this.grpInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpInput.Location = new System.Drawing.Point(51, 131);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(1674, 328);
            this.grpInput.TabIndex = 3;
            this.grpInput.TabStop = false;
            // 
            // txtLokasi
            // 
            this.txtLokasi.Location = new System.Drawing.Point(226, 161);
            this.txtLokasi.Name = "txtLokasi";
            this.txtLokasi.Size = new System.Drawing.Size(602, 22);
            this.txtLokasi.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(31, 161);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "Lokasi";
            // 
            // cbUkuran
            // 
            this.cbUkuran.FormattingEnabled = true;
            this.cbUkuran.Location = new System.Drawing.Point(226, 132);
            this.cbUkuran.Name = "cbUkuran";
            this.cbUkuran.Size = new System.Drawing.Size(602, 24);
            this.cbUkuran.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(30, 248);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Keterangan";
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(226, 218);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(602, 24);
            this.cbStatus.TabIndex = 19;
            // 
            // txtHargaSewa
            // 
            this.txtHargaSewa.Location = new System.Drawing.Point(226, 190);
            this.txtHargaSewa.Name = "txtHargaSewa";
            this.txtHargaSewa.Size = new System.Drawing.Size(602, 22);
            this.txtHargaSewa.TabIndex = 18;
            this.txtHargaSewa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHargaSewa_KeyPress);
            this.txtHargaSewa.Leave += new System.EventHandler(this.txtHargaSewa_Leave);
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.Location = new System.Drawing.Point(226, 248);
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(602, 22);
            this.txtKeterangan.TabIndex = 18;
            // 
            // txtNamaGudang
            // 
            this.txtNamaGudang.Location = new System.Drawing.Point(226, 106);
            this.txtNamaGudang.Name = "txtNamaGudang";
            this.txtNamaGudang.Size = new System.Drawing.Size(602, 22);
            this.txtNamaGudang.TabIndex = 18;
            // 
            // txtKodeGudang
            // 
            this.txtKodeGudang.Location = new System.Drawing.Point(226, 80);
            this.txtKodeGudang.Name = "txtKodeGudang";
            this.txtKodeGudang.Size = new System.Drawing.Size(602, 22);
            this.txtKodeGudang.TabIndex = 17;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(696, 283);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(132, 30);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapus.Location = new System.Drawing.Point(540, 283);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(132, 30);
            this.btnHapus.TabIndex = 5;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(382, 283);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(132, 30);
            this.btnEdit.TabIndex = 16;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.Location = new System.Drawing.Point(226, 283);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(132, 30);
            this.btnSimpan.TabIndex = 4;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(30, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Status ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Harga Sewa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Ukuran ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Nama Gudang";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Kode Gudang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Input Data Gudang";
            // 
            // grpList
            // 
            this.grpList.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.grpList.Controls.Add(this.dgvGudang);
            this.grpList.Controls.Add(this.btnCari);
            this.grpList.Controls.Add(this.txtCari);
            this.grpList.Controls.Add(this.label8);
            this.grpList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpList.Location = new System.Drawing.Point(51, 484);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(1674, 237);
            this.grpList.TabIndex = 4;
            this.grpList.TabStop = false;
            // 
            // dgvGudang
            // 
            this.dgvGudang.AllowUserToAddRows = false;
            this.dgvGudang.AllowUserToDeleteRows = false;
            this.dgvGudang.AllowUserToResizeColumns = false;
            this.dgvGudang.AllowUserToResizeRows = false;
            this.dgvGudang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGudang.Location = new System.Drawing.Point(34, 69);
            this.dgvGudang.Name = "dgvGudang";
            this.dgvGudang.RowTemplate.Height = 24;
            this.dgvGudang.Size = new System.Drawing.Size(1614, 150);
            this.dgvGudang.TabIndex = 21;
            this.dgvGudang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGudang_CellContentClick);
            // 
            // btnCari
            // 
            this.btnCari.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCari.Location = new System.Drawing.Point(1516, 17);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(132, 30);
            this.btnCari.TabIndex = 20;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // txtCari
            // 
            this.txtCari.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCari.Location = new System.Drawing.Point(1126, 19);
            this.txtCari.Multiline = true;
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(384, 30);
            this.txtCari.TabIndex = 20;
            this.txtCari.TextChanged += new System.EventHandler(this.txtCari_TextChanged);
            this.txtCari.Enter += new System.EventHandler(this.textBox5_Enter);
            this.txtCari.Leave += new System.EventHandler(this.textBox5_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(31, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Daftar Gudang";
            // 
            // FormGudang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1765, 790);
            this.Controls.Add(this.grpList);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormGudang";
            this.Text = "FormGudang";
            this.Load += new System.EventHandler(this.FormGudang_Load);
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.grpList.ResumeLayout(false);
            this.grpList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGudang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.TextBox txtHargaSewa;
        private System.Windows.Forms.TextBox txtNamaGudang;
        private System.Windows.Forms.TextBox txtKodeGudang;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvGudang;
        private System.Windows.Forms.ComboBox cbUkuran;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtKeterangan;
        private System.Windows.Forms.TextBox txtLokasi;
        private System.Windows.Forms.Label label10;
    }
}