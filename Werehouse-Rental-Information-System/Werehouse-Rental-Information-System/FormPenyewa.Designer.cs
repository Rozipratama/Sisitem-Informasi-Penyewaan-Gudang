namespace Werehouse_Rental_Information_System
{
    partial class FormPenyewa
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
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvPenyewa = new System.Windows.Forms.DataGridView();
            this.txtPenyewa = new System.Windows.Forms.TextBox();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNoHP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rbPerorangan = new System.Windows.Forms.RadioButton();
            this.rbPerusahaan = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNamaPerusahaan = new System.Windows.Forms.TextBox();
            this.txtNamaPIC = new System.Windows.Forms.TextBox();
            this.txtNoNIB = new System.Windows.Forms.TextBox();
            this.txtNPWP = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnCari = new System.Windows.Forms.Button();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.txtIdPenyewa = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.panelPerorangan = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtNoKTP = new System.Windows.Forms.TextBox();
            this.txtNamaLengkap = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.panelPerusahaan = new System.Windows.Forms.Panel();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPenyewa)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelPerorangan.SuspendLayout();
            this.panelPerusahaan.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(31, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Daftar Penyewa";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.btnCari);
            this.groupBox2.Controls.Add(this.txtCari);
            this.groupBox2.Controls.Add(this.dgvPenyewa);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(51, 517);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1677, 237);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // dgvPenyewa
            // 
            this.dgvPenyewa.AllowUserToAddRows = false;
            this.dgvPenyewa.AllowUserToDeleteRows = false;
            this.dgvPenyewa.AllowUserToResizeColumns = false;
            this.dgvPenyewa.AllowUserToResizeRows = false;
            this.dgvPenyewa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPenyewa.Location = new System.Drawing.Point(34, 69);
            this.dgvPenyewa.Name = "dgvPenyewa";
            this.dgvPenyewa.RowTemplate.Height = 24;
            this.dgvPenyewa.Size = new System.Drawing.Size(1591, 150);
            this.dgvPenyewa.TabIndex = 21;
            this.dgvPenyewa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPenyewa_CellContentClick);
            // 
            // txtPenyewa
            // 
            this.txtPenyewa.Location = new System.Drawing.Point(1035, 99);
            this.txtPenyewa.Name = "txtPenyewa";
            this.txtPenyewa.ReadOnly = true;
            this.txtPenyewa.Size = new System.Drawing.Size(550, 22);
            this.txtPenyewa.TabIndex = 18;
            // 
            // txtAlamat
            // 
            this.txtAlamat.Location = new System.Drawing.Point(1035, 183);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(550, 22);
            this.txtAlamat.TabIndex = 18;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(1035, 155);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(550, 22);
            this.txtEmail.TabIndex = 18;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(1453, 282);
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
            this.btnHapus.Location = new System.Drawing.Point(1287, 282);
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
            this.btnEdit.Location = new System.Drawing.Point(1116, 282);
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
            this.btnSimpan.Location = new System.Drawing.Point(926, 282);
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
            this.label7.Location = new System.Drawing.Point(922, 242);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 20);
            this.label7.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(922, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(922, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Alamat";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(922, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(922, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "No. HP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Input Data Penyewa";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.panelPerusahaan);
            this.groupBox1.Controls.Add(this.panelPerorangan);
            this.groupBox1.Controls.Add(this.cbStatus);
            this.groupBox1.Controls.Add(this.txtIdPenyewa);
            this.groupBox1.Controls.Add(this.rbPerusahaan);
            this.groupBox1.Controls.Add(this.rbPerorangan);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtPenyewa);
            this.groupBox1.Controls.Add(this.txtAlamat);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtNoHP);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnHapus);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnSimpan);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(51, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1677, 389);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // txtNoHP
            // 
            this.txtNoHP.Location = new System.Drawing.Point(1035, 127);
            this.txtNoHP.Name = "txtNoHP";
            this.txtNoHP.Size = new System.Drawing.Size(550, 22);
            this.txtNoHP.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(47, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Medussa WereHouse - Penyewa";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(31, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Jenis Penyewa :";
            // 
            // rbPerorangan
            // 
            this.rbPerorangan.AutoSize = true;
            this.rbPerorangan.Location = new System.Drawing.Point(193, 66);
            this.rbPerorangan.Name = "rbPerorangan";
            this.rbPerorangan.Size = new System.Drawing.Size(104, 21);
            this.rbPerorangan.TabIndex = 22;
            this.rbPerorangan.TabStop = true;
            this.rbPerorangan.Text = "Perorangan";
            this.rbPerorangan.UseVisualStyleBackColor = true;
            // 
            // rbPerusahaan
            // 
            this.rbPerusahaan.AutoSize = true;
            this.rbPerusahaan.Location = new System.Drawing.Point(322, 67);
            this.rbPerusahaan.Name = "rbPerusahaan";
            this.rbPerusahaan.Size = new System.Drawing.Size(106, 21);
            this.rbPerusahaan.TabIndex = 23;
            this.rbPerusahaan.TabStop = true;
            this.rbPerusahaan.Text = "Perusahaan";
            this.rbPerusahaan.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Perusahaan";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(2, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(141, 17);
            this.label14.TabIndex = 29;
            this.label14.Text = "Nama Perusahaan";
            // 
            // txtNamaPerusahaan
            // 
            this.txtNamaPerusahaan.Location = new System.Drawing.Point(158, 27);
            this.txtNamaPerusahaan.Name = "txtNamaPerusahaan";
            this.txtNamaPerusahaan.Size = new System.Drawing.Size(534, 22);
            this.txtNamaPerusahaan.TabIndex = 30;
            // 
            // txtNamaPIC
            // 
            this.txtNamaPIC.Location = new System.Drawing.Point(158, 55);
            this.txtNamaPIC.Name = "txtNamaPIC";
            this.txtNamaPIC.Size = new System.Drawing.Size(534, 22);
            this.txtNamaPIC.TabIndex = 31;
            // 
            // txtNoNIB
            // 
            this.txtNoNIB.Location = new System.Drawing.Point(158, 83);
            this.txtNoNIB.Name = "txtNoNIB";
            this.txtNoNIB.Size = new System.Drawing.Size(534, 22);
            this.txtNoNIB.TabIndex = 32;
            // 
            // txtNPWP
            // 
            this.txtNPWP.Location = new System.Drawing.Point(158, 111);
            this.txtNPWP.Name = "txtNPWP";
            this.txtNPWP.Size = new System.Drawing.Size(534, 22);
            this.txtNPWP.TabIndex = 33;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(5, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 17);
            this.label15.TabIndex = 34;
            this.label15.Text = "Nama PIC";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(5, 88);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 17);
            this.label16.TabIndex = 35;
            this.label16.Text = "No. NIB";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(5, 116);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 17);
            this.label17.TabIndex = 36;
            this.label17.Text = "No. NPWP";
            // 
            // btnCari
            // 
            this.btnCari.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCari.Location = new System.Drawing.Point(1488, 10);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(132, 30);
            this.btnCari.TabIndex = 22;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // txtCari
            // 
            this.txtCari.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCari.Location = new System.Drawing.Point(1098, 12);
            this.txtCari.Multiline = true;
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(384, 30);
            this.txtCari.TabIndex = 23;
            // 
            // txtIdPenyewa
            // 
            this.txtIdPenyewa.AutoSize = true;
            this.txtIdPenyewa.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdPenyewa.Location = new System.Drawing.Point(922, 101);
            this.txtIdPenyewa.Name = "txtIdPenyewa";
            this.txtIdPenyewa.Size = new System.Drawing.Size(103, 20);
            this.txtIdPenyewa.TabIndex = 26;
            this.txtIdPenyewa.Text = "Id Penyewa";
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(1035, 209);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(550, 24);
            this.cbStatus.TabIndex = 27;
            // 
            // panelPerorangan
            // 
            this.panelPerorangan.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelPerorangan.Controls.Add(this.label18);
            this.panelPerorangan.Controls.Add(this.label19);
            this.panelPerorangan.Controls.Add(this.txtNoKTP);
            this.panelPerorangan.Controls.Add(this.txtNamaLengkap);
            this.panelPerorangan.Controls.Add(this.label20);
            this.panelPerorangan.Location = new System.Drawing.Point(34, 99);
            this.panelPerorangan.Name = "panelPerorangan";
            this.panelPerorangan.Size = new System.Drawing.Size(726, 100);
            this.panelPerorangan.TabIndex = 30;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(6, 62);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 17);
            this.label18.TabIndex = 29;
            this.label18.Text = "No. KTP";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(6, 36);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(116, 17);
            this.label19.TabIndex = 28;
            this.label19.Text = "Nama Lengkap";
            // 
            // txtNoKTP
            // 
            this.txtNoKTP.Location = new System.Drawing.Point(159, 59);
            this.txtNoKTP.Name = "txtNoKTP";
            this.txtNoKTP.Size = new System.Drawing.Size(534, 22);
            this.txtNoKTP.TabIndex = 27;
            // 
            // txtNamaLengkap
            // 
            this.txtNamaLengkap.Location = new System.Drawing.Point(159, 31);
            this.txtNamaLengkap.Name = "txtNamaLengkap";
            this.txtNamaLengkap.Size = new System.Drawing.Size(534, 22);
            this.txtNamaLengkap.TabIndex = 26;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(3, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(93, 17);
            this.label20.TabIndex = 0;
            this.label20.Text = "Perorangan";
            // 
            // panelPerusahaan
            // 
            this.panelPerusahaan.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelPerusahaan.Controls.Add(this.label17);
            this.panelPerusahaan.Controls.Add(this.txtNamaPIC);
            this.panelPerusahaan.Controls.Add(this.label16);
            this.panelPerusahaan.Controls.Add(this.label11);
            this.panelPerusahaan.Controls.Add(this.label15);
            this.panelPerusahaan.Controls.Add(this.label14);
            this.panelPerusahaan.Controls.Add(this.txtNPWP);
            this.panelPerusahaan.Controls.Add(this.txtNamaPerusahaan);
            this.panelPerusahaan.Controls.Add(this.txtNoNIB);
            this.panelPerusahaan.Location = new System.Drawing.Point(35, 213);
            this.panelPerusahaan.Name = "panelPerusahaan";
            this.panelPerusahaan.Size = new System.Drawing.Size(725, 151);
            this.panelPerusahaan.TabIndex = 37;
            // 
            // FormPenyewa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1765, 790);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPenyewa";
            this.Text = "FormPenyewa";
            this.Load += new System.EventHandler(this.FormPenyewa_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPenyewa)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelPerorangan.ResumeLayout(false);
            this.panelPerorangan.PerformLayout();
            this.panelPerusahaan.ResumeLayout(false);
            this.panelPerusahaan.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPenyewa;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNoHP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPenyewa;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtNPWP;
        private System.Windows.Forms.TextBox txtNoNIB;
        private System.Windows.Forms.TextBox txtNamaPIC;
        private System.Windows.Forms.TextBox txtNamaPerusahaan;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rbPerusahaan;
        private System.Windows.Forms.RadioButton rbPerorangan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Label txtIdPenyewa;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Panel panelPerorangan;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtNoKTP;
        private System.Windows.Forms.TextBox txtNamaLengkap;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panelPerusahaan;
    }
}