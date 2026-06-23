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
    public partial class FormGudang : Form
    {
        string connectionString = "server=localhost;port=3306;database=db_penyewaan_gudang;uid=root;password=;SslMode=None;";
        bool isEditMode = false;

        public FormGudang()
        {
            InitializeComponent();
        }

        private void FormGudang_Load(object sender, EventArgs e)
        {
            SetupComboBox();
            SetupDataGridView();
            LoadDataGudang();
            ResetForm();
        }

        private void SetupComboBox()
        {
            cbUkuran.Items.Clear();
            cbUkuran.Items.Add("5x5 Meter");
            cbUkuran.Items.Add("10x10 Meter");
            cbUkuran.Items.Add("15x15 Meter");
            cbUkuran.Items.Add("20x20 Meter");
            cbUkuran.SelectedIndex = 0;

            cbStatus.Items.Clear();
            cbStatus.Items.Add("tersedia");
            cbStatus.Items.Add("terisi");
            cbStatus.SelectedIndex = 0;
        }

        private void SetupDataGridView()
        {
            dgvGudang.Columns.Clear();

            // Tambah kolom data dengan nama yang benar
            dgvGudang.Columns.Add("kode_gudang", "Kode");
            dgvGudang.Columns.Add("nama_gudang", "Nama Gudang");
            dgvGudang.Columns.Add("ukuran", "Ukuran");
            dgvGudang.Columns.Add("lokasi", "Lokasi");
            dgvGudang.Columns.Add("harga_sewa", "Harga Sewa");
            dgvGudang.Columns.Add("status", "Status");
            dgvGudang.Columns.Add("keterangan", "Keterangan");

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.Name = "Edit";
            btnEdit.Text = "✏️";
            btnEdit.HeaderText = "Aksi";
            btnEdit.UseColumnTextForButtonValue = true;
            dgvGudang.Columns.Add(btnEdit);

            DataGridViewButtonColumn btnHapus = new DataGridViewButtonColumn();
            btnHapus.Name = "Hapus";
            btnHapus.Text = "🗑️";
            btnHapus.HeaderText = "";
            btnHapus.UseColumnTextForButtonValue = true;
            dgvGudang.Columns.Add(btnHapus);

            // Setting
            dgvGudang.ReadOnly = true;
            dgvGudang.AllowUserToAddRows = false;
            dgvGudang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGudang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGudang.MultiSelect = false;
        }

        private void LoadDataGudang()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM gudang ORDER BY kode_gudang ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvGudang.Rows.Clear();

                        foreach (DataRow row in dt.Rows)
                        {
                            dgvGudang.Rows.Add(
                                row["kode_gudang"]?.ToString() ?? "",
                                row["nama_gudang"]?.ToString() ?? "",
                                row["ukuran"]?.ToString() ?? "",
                                row["lokasi"]?.ToString() ?? "",
                                "Rp " + Convert.ToDecimal(row["harga_sewa"] ?? 0).ToString("N0"),
                                row["status"]?.ToString() ?? "",
                                row["keterangan"]?.ToString() ?? ""
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            txtKodeGudang.Clear();
            txtNamaGudang.Clear();
            cbUkuran.SelectedIndex = 0;
            txtLokasi.Clear();
            txtHargaSewa.Clear();
            cbStatus.SelectedIndex = 0;
            txtKeterangan.Clear();

            isEditMode = false;
            btnSimpan.Enabled = true;
            btnEdit.Enabled = false;
            txtKodeGudang.ReadOnly = false;
            txtKodeGudang.Focus();
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (txtCari.Text == "")
            {
                txtCari.Text = "Cari Gudang";
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (txtCari.Text == "Cari Gudang")
            {
                txtCari.Text = "";
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKodeGudang.Text) ||
                string.IsNullOrWhiteSpace(txtNamaGudang.Text) ||
                string.IsNullOrWhiteSpace(cbUkuran.Text) ||
                string.IsNullOrWhiteSpace(txtLokasi.Text) ||
                string.IsNullOrWhiteSpace(txtHargaSewa.Text))
            {
                MessageBox.Show("Semua field wajib diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Cek apakah kode sudah ada
                    string checkQuery = "SELECT COUNT(*) FROM gudang WHERE kode_gudang = @kode";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@kode", txtKodeGudang.Text.Trim());
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Kode gudang sudah ada! Gunakan kode yang berbeda.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Insert data
                    string query = @"INSERT INTO gudang 
                                    (kode_gudang, nama_gudang, ukuran, lokasi, harga_sewa, status, keterangan) 
                                    VALUES 
                                    (@kode, @nama, @ukuran, @lokasi, @harga, @status, @keterangan)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@kode", txtKodeGudang.Text.Trim());
                        cmd.Parameters.AddWithValue("@nama", txtNamaGudang.Text.Trim());
                        cmd.Parameters.AddWithValue("@ukuran", cbUkuran.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@lokasi", txtLokasi.Text.Trim());
                        cmd.Parameters.AddWithValue("@harga", Convert.ToDecimal(txtHargaSewa.Text.Replace(".", "").Replace("Rp ", "")));
                        cmd.Parameters.AddWithValue("@status", cbStatus.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@keterangan", txtKeterangan.Text.Trim());

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Data gudang berhasil disimpan!", "Sukses",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetForm();
                            LoadDataGudang();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error simpan data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKodeGudang.Text))
            {
                MessageBox.Show("Pilih data yang ingin diedit!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"UPDATE gudang 
                                    SET nama_gudang = @nama, 
                                        ukuran = @ukuran, 
                                        lokasi = @lokasi, 
                                        harga_sewa = @harga, 
                                        status = @status, 
                                        keterangan = @keterangan 
                                    WHERE kode_gudang = @kode";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@kode", txtKodeGudang.Text.Trim());
                        cmd.Parameters.AddWithValue("@nama", txtNamaGudang.Text.Trim());
                        cmd.Parameters.AddWithValue("@ukuran", cbUkuran.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@lokasi", txtLokasi.Text.Trim());
                        cmd.Parameters.AddWithValue("@harga", Convert.ToDecimal(txtHargaSewa.Text.Replace(".", "").Replace("Rp ", "")));
                        cmd.Parameters.AddWithValue("@status", cbStatus.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@keterangan", txtKeterangan.Text.Trim());

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Data gudang berhasil diupdate!", "Sukses",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetForm();
                            LoadDataGudang();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error update data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKodeGudang.Text))
            {
                MessageBox.Show("Pilih data yang ingin dihapus!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cek apakah gudang sedang digunakan di kontrak
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM kontrak WHERE kode_gudang = @kode AND status = 'Aktif'";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@kode", txtKodeGudang.Text.Trim());
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Gudang tidak bisa dihapus karena masih ada kontrak aktif!",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Konfirmasi hapus
                    DialogResult result = MessageBox.Show(
                        $"Apakah Anda yakin ingin menghapus gudang {txtKodeGudang.Text}?",
                        "Konfirmasi Hapus",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string deleteQuery = "DELETE FROM gudang WHERE kode_gudang = @kode";
                        using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn))
                        {
                            deleteCmd.Parameters.AddWithValue("@kode", txtKodeGudang.Text.Trim());
                            int rowsAffected = deleteCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Data gudang berhasil dihapus!", "Sukses",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ResetForm();
                                LoadDataGudang();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error hapus data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void dgvGudang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvGudang.Rows[e.RowIndex];

            if (e.ColumnIndex == dgvGudang.Columns["Edit"].Index)
            {
                txtKodeGudang.Text = row.Cells["kode_gudang"].Value?.ToString() ?? "";
                txtNamaGudang.Text = row.Cells["nama_gudang"].Value?.ToString() ?? "";
                cbUkuran.SelectedItem = row.Cells["ukuran"].Value?.ToString();
                txtLokasi.Text = row.Cells["lokasi"].Value?.ToString() ?? "";

                string harga = row.Cells["harga_sewa"].Value?.ToString().Replace("Rp ", "").Replace(".", "") ?? "0";
                txtHargaSewa.Text = harga;

                cbStatus.SelectedItem = row.Cells["status"].Value?.ToString();
                txtKeterangan.Text = row.Cells["keterangan"].Value?.ToString() ?? "";

                isEditMode = true;
                btnSimpan.Enabled = false;
                btnEdit.Enabled = true;
                txtKodeGudang.ReadOnly = true;
            }
            else if (e.ColumnIndex == dgvGudang.Columns["Hapus"].Index)
            {
                txtKodeGudang.Text = row.Cells["kode_gudang"].Value?.ToString() ?? "";
                btnHapus.PerformClick();
            }
            else if (e.ColumnIndex >= 0 && e.ColumnIndex < dgvGudang.Columns.Count - 2)
            {
                txtKodeGudang.Text = row.Cells["kode_gudang"].Value?.ToString() ?? "";
                txtNamaGudang.Text = row.Cells["nama_gudang"].Value?.ToString() ?? "";
                cbUkuran.SelectedItem = row.Cells["ukuran"].Value?.ToString();
                txtLokasi.Text = row.Cells["lokasi"].Value?.ToString() ?? "";

                string harga = row.Cells["harga_sewa"].Value?.ToString().Replace("Rp ", "").Replace(".", "") ?? "0";
                txtHargaSewa.Text = harga;

                cbStatus.SelectedItem = row.Cells["status"].Value?.ToString();
                txtKeterangan.Text = row.Cells["keterangan"].Value?.ToString() ?? "";

                isEditMode = false;
                btnSimpan.Enabled = true;
                btnEdit.Enabled = true;
                txtKodeGudang.ReadOnly = true;
            }
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            CariGudang();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            CariGudang();
        }

        private void CariGudang()
        {
            string keyword = txtCari.Text.Trim();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"SELECT * FROM gudang 
                                    WHERE nama_gudang LIKE @keyword 
                                    OR lokasi LIKE @keyword 
                                    OR kode_gudang LIKE @keyword
                                    ORDER BY kode_gudang ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dgvGudang.Rows.Clear();

                            foreach (DataRow row in dt.Rows)
                            {
                                dgvGudang.Rows.Add(
                                    row["kode_gudang"].ToString(),
                                    row["nama_gudang"].ToString(),
                                    row["ukuran"].ToString(),
                                    row["lokasi"].ToString(),
                                    "Rp " + Convert.ToDecimal(row["harga_sewa"]).ToString("N0"),
                                    row["status"].ToString(),
                                    row["keterangan"].ToString()
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cari data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtHargaSewa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHargaSewa_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtHargaSewa.Text))
            {
                try
                {
                    decimal harga = Convert.ToDecimal(txtHargaSewa.Text);
                    txtHargaSewa.Text = "Rp " + harga.ToString("N0");
                }
                catch { }
            }
        }
    }
}
