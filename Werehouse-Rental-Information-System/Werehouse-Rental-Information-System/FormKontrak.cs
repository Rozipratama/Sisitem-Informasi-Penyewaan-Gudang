using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;

namespace Werehouse_Rental_Information_System
{
    public partial class FormKontrak : Form
    {
        string connectionString = "server=localhost;port=3306;database=db_penyewaan_gudang;uid=root;password=;SslMode=None;";
        bool isEditMode = false;

        public FormKontrak()
        {
            InitializeComponent();
        }

        private void FormKontrak_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadComboPenyewa();
            LoadComboGudang();
            GenerateNoKontrak();
            LoadDataKontrak();
            ResetForm();

            txtDetailNama.ReadOnly = true;
            txtDetailNama.BackColor = Color.FromArgb(240, 240, 240);  // Abu-abu terang
            txtDetailNama.BorderStyle = BorderStyle.FixedSingle;

            txtDetailUkuran.ReadOnly = true;
            txtDetailUkuran.BackColor = Color.FromArgb(240, 240, 240);

            txtDetailLokasi.ReadOnly = true;
            txtDetailLokasi.BackColor = Color.FromArgb(240, 240, 240);

            txtDetailHarga.ReadOnly = true;
            txtDetailHarga.BackColor = Color.FromArgb(240, 240, 240);
            txtDetailHarga.ForeColor = Color.Blue;  // Harga warna biru

            txtTotalHarga.ReadOnly = true;
            txtTotalHarga.BackColor = Color.FromArgb(200, 255, 200);  // Hijau terang
            txtTotalHarga.ForeColor = Color.Green;  // Hijau
            txtTotalHarga.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
        }

        private void SetupDataGridView()
        {
            dgvKontrak.Columns.Clear();
            dgvKontrak.Columns.Add("no_kontrak", "No. Kontrak");
            dgvKontrak.Columns.Add("nama_penyewa", "Penyewa");
            dgvKontrak.Columns.Add("nama_gudang", "Gudang");
            dgvKontrak.Columns.Add("tgl_mulai", "Tanggal Mulai");
            dgvKontrak.Columns.Add("tgl_selesai", "Tanggal Selesai");
            dgvKontrak.Columns.Add("total_harga", "Total Harga");
            dgvKontrak.Columns.Add("status", "Status");

            var btnEdit = new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "Aksi",
                Text = "✏️",
                UseColumnTextForButtonValue = true
            };
            var btnHapus = new DataGridViewButtonColumn
            {
                Name = "Hapus",
                HeaderText = "",
                Text = "🗑️",
                UseColumnTextForButtonValue = true
            };
            dgvKontrak.Columns.Add(btnEdit);
            dgvKontrak.Columns.Add(btnHapus);

            dgvKontrak.ReadOnly = true;
            dgvKontrak.AllowUserToAddRows = false;
            dgvKontrak.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKontrak.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadComboPenyewa()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT id_penyewa, 
                                            CASE 
                                                WHEN jenis_penyewa = 'perorangan' THEN nama_penyewa
                                                WHEN jenis_penyewa = 'perusahaan' THEN CONCAT(nama_perusahaan, ' (PIC: ', nama_penyewa, ')')
                                            END as display_name
                                     FROM penyewa 
                                     WHERE status = 'aktif'
                                     ORDER BY display_name ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cbPenyewa.DataSource = dt;
                        cbPenyewa.DisplayMember = "display_name";
                        cbPenyewa.ValueMember = "id_penyewa";
                        cbPenyewa.SelectedIndex = -1;
                        cbPenyewa.DropDownStyle = ComboBoxStyle.DropDownList;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load penyewa: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboGudang()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT kode_gudang, nama_gudang, ukuran, lokasi, harga_sewa, status " +
                                   "FROM gudang WHERE status = 'tersedia' ORDER BY nama_gudang ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cbGudang.DataSource = dt;
                        cbGudang.DisplayMember = "nama_gudang";
                        cbGudang.ValueMember = "kode_gudang";
                        cbGudang.SelectedIndex = -1;
                        cbGudang.DropDownStyle = ComboBoxStyle.DropDownList;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load gudang: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateNoKontrak()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) as total FROM kontrak WHERE YEAR(tgl_mulai) = YEAR(CURDATE())";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        int total = Convert.ToInt32(cmd.ExecuteScalar());
                        string tahun = DateTime.Now.ToString("yy");
                        string noUrut = (total + 1).ToString("D3"); // 001, 002, dst
                        txtNoKontrak.Text = $"KTR-{tahun}-{noUrut}";
                        txtNoKontrak.ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                txtNoKontrak.Text = "KTR-" + DateTime.Now.ToString("yy") + "-001";
            }
        }

        private void cbGudang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGudang.SelectedIndex >= 0)
            {
                DataRowView row = (DataRowView)cbGudang.SelectedItem;
                
                txtDetailNama.Text = row["nama_gudang"].ToString();
                txtDetailUkuran.Text = row["ukuran"].ToString();
                txtDetailLokasi.Text = row["lokasi"].ToString();

                decimal harga = Convert.ToDecimal(row["harga_sewa"]);
                txtDetailHarga.Text = "Rp " + harga.ToString("N0"); 
                HitungTotalHarga();
            }
            else
            {
                txtDetailNama.Clear();
                txtDetailUkuran.Clear();
                txtDetailLokasi.Clear();
                txtDetailHarga.Clear();
                txtTotalHarga.Clear();
            }
        }

        private void dtpTanggalSelesai_ValueChanged(object sender, EventArgs e)
        {
            HitungLamaSewa();
            HitungTotalHarga();
        }

        private void HitungLamaSewa()
        {
            DateTime tglMulai = dtpTanggalMulai.Value;
            DateTime tglSelesai = dtpTanggalSelesai.Value;

            TimeSpan selisih = tglSelesai - tglMulai;
            int lamaBulan = (int)(selisih.TotalDays / 30);

            if (lamaBulan < 1) lamaBulan = 1;

            txtLamaSewa.Text = lamaBulan + " bulan";
        }


        private void HitungTotalHarga()
        {
            if (cbGudang.SelectedIndex < 0) return;

            try
            {
                DateTime tglMulai = dtpTanggalMulai.Value;
                DateTime tglSelesai = dtpTanggalSelesai.Value;

                TimeSpan selisih = tglSelesai - tglMulai;
                int lamaBulan = (int)(selisih.TotalDays / 30);

                if (lamaBulan < 1) lamaBulan = 1;

                DataRowView row = (DataRowView)cbGudang.SelectedItem;
                decimal hargaPerBulan = Convert.ToDecimal(row["harga_sewa"]);
                decimal totalHarga = hargaPerBulan * lamaBulan;

                txtTotalHarga.Text = "Rp " + totalHarga.ToString("N0");
            }
            catch { }
        }

        private void LoadDataKontrak()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT k.no_kontrak, 
                                            CONCAT(p.nama_penyewa, 
                                                CASE 
                                                    WHEN p.jenis_penyewa = 'perusahaan' THEN CONCAT(' - ', p.nama_perusahaan)
                                                    ELSE ''
                                                END) as nama_penyewa,
                                            g.nama_gudang,
                                            k.tgl_mulai,
                                            k.tgl_selesai,
                                            k.total_harga,
                                            k.status
                                     FROM kontrak k
                                     JOIN penyewa p ON k.id_penyewa = p.id_penyewa
                                     JOIN gudang g ON k.kode_gudang = g.kode_gudang
                                     ORDER BY k.no_kontrak DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvKontrak.Rows.Clear();

                        foreach (DataRow row in dt.Rows)
                        {
                            dgvKontrak.Rows.Add(
                                row["no_kontrak"].ToString(),
                                row["nama_penyewa"].ToString(),
                                row["nama_gudang"].ToString(),
                                Convert.ToDateTime(row["tgl_mulai"]).ToString("dd/MM/yyyy"),
                                Convert.ToDateTime(row["tgl_selesai"]).ToString("dd/MM/yyyy"),
                                "Rp " + Convert.ToDecimal(row["total_harga"]).ToString("N0"),
                                row["status"].ToString()
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load kontrak: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            GenerateNoKontrak();
            cbPenyewa.SelectedIndex = -1;
            cbGudang.SelectedIndex = -1;
            
            txtDetailNama.Clear();
            txtDetailUkuran.Clear();
            txtDetailLokasi.Clear();
            txtDetailHarga.Clear();

            dtpTanggalMulai.Value = DateTime.Now;
            dtpTanggalSelesai.Value = DateTime.Now.AddMonths(1);
            txtTotalHarga.Clear();
            cbStatus.SelectedItem = "Aktif";

            isEditMode = false;
            btnSimpan.Enabled = true;
            btnEdit.Enabled = false;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Cek apakah gudang masih tersedia
                    int kodeGudang = Convert.ToInt32(cbGudang.SelectedValue);
                    using (MySqlCommand checkCmd = new MySqlCommand(
                        "SELECT status FROM gudang WHERE kode_gudang = @kode", conn))
                    {
                        checkCmd.Parameters.AddWithValue("@kode", kodeGudang);
                        string status = checkCmd.ExecuteScalar()?.ToString();

                        if (status != "tersedia")
                        {
                            MessageBox.Show("Gudang sudah tidak tersedia!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Insert kontrak
                    string query = @"INSERT INTO kontrak 
                                    (no_kontrak, id_penyewa, kode_gudang, tgl_mulai, tgl_selesai, total_harga, status) 
                                    VALUES (@no, @penyewa, @gudang, @mulai, @selesai, @total, @status)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@no", txtNoKontrak.Text.Trim());
                        cmd.Parameters.AddWithValue("@penyewa", cbPenyewa.SelectedValue);
                        cmd.Parameters.AddWithValue("@gudang", kodeGudang);
                        cmd.Parameters.AddWithValue("@mulai", dtpTanggalMulai.Value.Date);
                        cmd.Parameters.AddWithValue("@selesai", dtpTanggalSelesai.Value.Date);
                        cmd.Parameters.AddWithValue("@total", Convert.ToDecimal(txtTotalHarga.Text.Replace("Rp ", "").Replace(".", "")));
                        cmd.Parameters.AddWithValue("@status", cbStatus.SelectedItem.ToString());

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            // Update status gudang jadi 'terisi'
                            using (MySqlCommand updateGudang = new MySqlCommand(
                                "UPDATE gudang SET status = 'terisi' WHERE kode_gudang = @kode", conn))
                            {
                                updateGudang.Parameters.AddWithValue("@kode", kodeGudang);
                                updateGudang.ExecuteNonQuery();
                            }

                            MessageBox.Show("Kontrak berhasil disimpan!", "Sukses",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Reload combo gudang (yang tersedia sudah berkurang)
                            LoadComboGudang();
                            ResetForm();
                            LoadDataKontrak();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error simpan kontrak: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (cbPenyewa.SelectedIndex < 0)
            {
                MessageBox.Show("Pilih penyewa!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cbGudang.SelectedIndex < 0)
            {
                MessageBox.Show("Pilih gudang!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpTanggalSelesai.Value <= dtpTanggalMulai.Value)
            {
                MessageBox.Show("Tanggal selesai harus lebih besar dari tanggal mulai!",
                    "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTotalHarga.Text))
            {
                MessageBox.Show("Total harga belum dihitung!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNoKontrak.Text))
            {
                MessageBox.Show("Pilih kontrak yang ingin diedit!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNoKontrak.Text))
            {
                MessageBox.Show("Pilih kontrak yang ingin dihapus!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Cek apakah masih ada pembayaran
                    using (MySqlCommand checkCmd = new MySqlCommand(
                        "SELECT COUNT(*) FROM pembayaran WHERE no_kontrak = @no", conn))
                    {
                        checkCmd.Parameters.AddWithValue("@no", txtNoKontrak.Text.Trim());
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Kontrak tidak bisa dihapus karena masih ada pembayaran!",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    if (MessageBox.Show("Yakin ingin menghapus kontrak ini?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Dapatkan kode gudang sebelum hapus
                        int kodeGudang = 0;
                        using (MySqlCommand getGudang = new MySqlCommand(
                            "SELECT kode_gudang FROM kontrak WHERE no_kontrak = @no", conn))
                        {
                            getGudang.Parameters.AddWithValue("@no", txtNoKontrak.Text.Trim());
                            kodeGudang = Convert.ToInt32(getGudang.ExecuteScalar());
                        }

                        // Hapus kontrak
                        using (MySqlCommand delCmd = new MySqlCommand(
                            "DELETE FROM kontrak WHERE no_kontrak = @no", conn))
                        {
                            delCmd.Parameters.AddWithValue("@no", txtNoKontrak.Text.Trim());
                            if (delCmd.ExecuteNonQuery() > 0)
                            {
                                // Update status gudang jadi 'tersedia' lagi
                                using (MySqlCommand updateGudang = new MySqlCommand(
                                    "UPDATE gudang SET status = 'tersedia' WHERE kode_gudang = @kode", conn))
                                {
                                    updateGudang.Parameters.AddWithValue("@kode", kodeGudang);
                                    updateGudang.ExecuteNonQuery();
                                }

                                MessageBox.Show("Kontrak berhasil dihapus!", "Sukses",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                LoadComboGudang();
                                ResetForm();
                                LoadDataKontrak();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error hapus kontrak: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void dgvKontrak_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cbGudang.SelectedIndex >= 0)
            {
                DataRowView row = (DataRowView)cbGudang.SelectedItem;
                
                txtDetailNama.Text = row["nama_gudang"].ToString();
                txtDetailUkuran.Text = row["ukuran"].ToString();
                txtDetailLokasi.Text = row["lokasi"].ToString();

                decimal harga = Convert.ToDecimal(row["harga_sewa"]);
                txtDetailHarga.Text = "Rp " + harga.ToString("N0");
                
                HitungTotalHarga();
            }
        }
    }
}
