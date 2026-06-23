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
using System.Text.RegularExpressions;

namespace Werehouse_Rental_Information_System
{
    public partial class FormPenyewa : Form
    {
        string connectionString = "server=localhost;port=3306;database=db_penyewaan_gudang;uid=root;password=;SslMode=None;";
        bool isEditMode = false;

        public FormPenyewa()
        {
            InitializeComponent();

            rbPerorangan.CheckedChanged += RbPerorangan_CheckedChanged;
            rbPerusahaan.CheckedChanged += RbPerusahaan_CheckedChanged;
        }

        private void FormPenyewa_Load(object sender, EventArgs e)
        {
            cbStatus.Items.Clear();
            cbStatus.Items.Add("aktif");
            cbStatus.Items.Add("non-aktif");
            cbStatus.SelectedIndex = 0;
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            SetupDataGridView();
            LoadDataPenyewa();
            ResetForm();
            ToggleMode();
        }

        private void RbPerorangan_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPerorangan.Checked)
            {
                ToggleMode();
            }
        }

        private void RbPerusahaan_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPerusahaan.Checked)
            {
                ToggleMode();
            }
        }

        private void SetupDataGridView()
        {
            dgvPenyewa.Columns.Clear();
            dgvPenyewa.Columns.Add("id_penyewa", "ID");
            dgvPenyewa.Columns.Add("jenis", "Jenis");
            dgvPenyewa.Columns.Add("nama_display", "Nama / PIC");
            dgvPenyewa.Columns.Add("no_identitas", "No. Identitas");
            dgvPenyewa.Columns.Add("no_hp", "No. HP");
            dgvPenyewa.Columns.Add("status", "Status");
            dgvPenyewa.Columns.Add("email", "Email");
            dgvPenyewa.Columns["email"].Visible = false;  // Sembunyikan

            dgvPenyewa.Columns.Add("alamat", "Alamat");
            dgvPenyewa.Columns["alamat"].Visible = false;  // Sembunyikan

            dgvPenyewa.Columns.Add("npwp", "NPWP");
            dgvPenyewa.Columns["npwp"].Visible = false;

            // Tombol Edit & Hapus
            var btnEdit = new DataGridViewButtonColumn { Name = "Edit", HeaderText = "Aksi", Text = "✏️", UseColumnTextForButtonValue = true };
            var btnHapus = new DataGridViewButtonColumn { Name = "Hapus", HeaderText = "", Text = "🗑️", UseColumnTextForButtonValue = true };
            dgvPenyewa.Columns.Add(btnEdit);
            dgvPenyewa.Columns.Add(btnHapus);

            dgvPenyewa.ReadOnly = true;
            dgvPenyewa.AllowUserToAddRows = false;
            dgvPenyewa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPenyewa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ToggleMode()
        {

            if (rbPerorangan.Checked)
            {
                panelPerorangan.Visible = true;
                panelPerusahaan.Visible = false;
                ClearCompanyFields();
            }
            else if (rbPerusahaan.Checked)
            {
                panelPerorangan.Visible = false;
                panelPerusahaan.Visible = true;
                ClearPersonFields();
            }
        }
        
        private void ClearCompanyFields() { txtNamaPerusahaan.Clear(); txtNamaPIC.Clear(); txtNoNIB.Clear(); txtNPWP.Clear(); }
        private void ClearPersonFields() { txtNamaLengkap.Clear(); txtNoKTP.Clear(); }

        private void LoadDataPenyewa()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT id_penyewa, jenis_penyewa, nama_perusahaan, nama_penyewa, 
                        no_identitas, no_hp, email, alamat, npwp, status 
                 FROM penyewa ORDER BY nama_penyewa ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvPenyewa.Rows.Clear();

                        foreach (DataRow row in dt.Rows)
                        {
                            string jenis = row["jenis_penyewa"].ToString();
                            string namaDisplay = jenis == "perorangan"
                                ? row["nama_penyewa"].ToString()
                                : $"{row["nama_perusahaan"]} (PIC: {row["nama_penyewa"]})";

                            dgvPenyewa.Rows.Add(
                                row["id_penyewa"].ToString(),
                                jenis,
                                namaDisplay,
                                row["no_identitas"].ToString(),
                                row["no_hp"].ToString(),
                                row["status"].ToString(),
                                row["email"].ToString(),      
                                row["alamat"].ToString(),   
                                row["npwp"].ToString()
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load  " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            txtNamaLengkap.Clear(); txtNoKTP.Clear();
            txtNamaPerusahaan.Clear(); txtNamaPIC.Clear(); txtNoNIB.Clear(); txtNPWP.Clear();
            txtNoHP.Clear(); txtEmail.Clear(); txtAlamat.Clear();
            cbStatus.SelectedIndex = 0;
            
            rbPerorangan.Checked = true;
            rbPerusahaan.Checked = false;

            isEditMode = false;
            btnSimpan.Enabled = true;
            btnEdit.Enabled = false;
            txtNamaLengkap.Focus();
        }

        private bool ValidateInput()
        {
            if (rbPerorangan.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtNamaLengkap.Text)) { MessageBox.Show("Nama lengkap wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                if (string.IsNullOrWhiteSpace(txtNoKTP.Text)) { MessageBox.Show("No. KTP wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                if (!Regex.IsMatch(txtNoKTP.Text.Trim(), @"^\d{16}$")) { MessageBox.Show("No. KTP harus 16 digit angka!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtNamaPerusahaan.Text)) { MessageBox.Show("Nama perusahaan wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                if (string.IsNullOrWhiteSpace(txtNamaPIC.Text)) { MessageBox.Show("Nama PIC wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                if (string.IsNullOrWhiteSpace(txtNoNIB.Text)) { MessageBox.Show("No. NIB/NPWP wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            }

            if (string.IsNullOrWhiteSpace(txtNoHP.Text)) { MessageBox.Show("No. HP wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (!Regex.IsMatch(txtNoHP.Text.Trim(), @"^\d{10,}$")) { MessageBox.Show("No. HP minimal 10 digit!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (cbStatus.SelectedItem == null) { MessageBox.Show("Status harus dipilih!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }

            return true;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Cek duplikat identitas
                    string checkQuery = "SELECT COUNT(*) FROM penyewa WHERE no_identitas = @id";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@id", rbPerorangan.Checked ? txtNoKTP.Text.Trim() : txtNoNIB.Text.Trim());
                        if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show("No. Identitas sudah terdaftar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string query = @"INSERT INTO penyewa 
                                    (jenis_penyewa, nama_penyewa, no_identitas, nama_perusahaan, npwp, no_hp, email, alamat, status) 
                                    VALUES (@jenis, @nama, @identitas, @perusahaan, @npwp, @hp, @email, @alamat, @status)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@jenis", rbPerorangan.Checked ? "perorangan" : "perusahaan");
                        cmd.Parameters.AddWithValue("@nama", rbPerorangan.Checked ? txtNamaLengkap.Text.Trim() : txtNamaPIC.Text.Trim());
                        cmd.Parameters.AddWithValue("@identitas", rbPerorangan.Checked ? txtNoKTP.Text.Trim() : txtNoNIB.Text.Trim());
                        cmd.Parameters.AddWithValue("@perusahaan", rbPerusahaan.Checked ? (object)txtNamaPerusahaan.Text.Trim() : DBNull.Value);
                        cmd.Parameters.AddWithValue("@npwp", rbPerusahaan.Checked && !string.IsNullOrWhiteSpace(txtNPWP.Text) ? (object)txtNPWP.Text.Trim() : DBNull.Value);
                        cmd.Parameters.AddWithValue("@hp", txtNoHP.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text.Trim());
                        cmd.Parameters.AddWithValue("@status", cbStatus.SelectedItem.ToString());

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Data penyewa berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetForm();
                            LoadDataPenyewa();
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error simpan  " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdPenyewa?.Text)) { MessageBox.Show("Pilih data yang ingin diedit!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!ValidateInput()) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE penyewa 
                                    SET jenis_penyewa = @jenis, nama_penyewa = @nama, no_identitas = @identitas, 
                                        nama_perusahaan = @perusahaan, npwp = @npwp, no_hp = @hp, email = @email, 
                                        alamat = @alamat, status = @status 
                                    WHERE id_penyewa = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", txtIdPenyewa.Text.Trim());
                        cmd.Parameters.AddWithValue("@jenis", rbPerorangan.Checked ? "perorangan" : "perusahaan");
                        cmd.Parameters.AddWithValue("@nama", rbPerorangan.Checked ? txtNamaLengkap.Text.Trim() : txtNamaPIC.Text.Trim());
                        cmd.Parameters.AddWithValue("@identitas", rbPerorangan.Checked ? txtNoKTP.Text.Trim() : txtNoNIB.Text.Trim());
                        cmd.Parameters.AddWithValue("@perusahaan", rbPerusahaan.Checked ? (object)txtNamaPerusahaan.Text.Trim() : DBNull.Value);
                        cmd.Parameters.AddWithValue("@npwp", rbPerusahaan.Checked && !string.IsNullOrWhiteSpace(txtNPWP.Text) ? (object)txtNPWP.Text.Trim() : DBNull.Value);
                        cmd.Parameters.AddWithValue("@hp", txtNoHP.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text.Trim());
                        cmd.Parameters.AddWithValue("@status", cbStatus.SelectedItem.ToString());

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Data berhasil diupdate!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetForm();
                            LoadDataPenyewa();
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error update data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdPenyewa?.Text)) { MessageBox.Show("Pilih data yang ingin dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    // Cek kontrak aktif
                    using (MySqlCommand checkCmd = new MySqlCommand("SELECT COUNT(*) FROM kontrak WHERE id_penyewa = @id AND status = 'Aktif'", conn))
                    {
                        checkCmd.Parameters.AddWithValue("@id", txtIdPenyewa.Text.Trim());
                        if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show("Penyewa masih memiliki kontrak aktif. Tidak bisa dihapus!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    if (MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (MySqlCommand delCmd = new MySqlCommand("DELETE FROM penyewa WHERE id_penyewa = @id", conn))
                        {
                            delCmd.Parameters.AddWithValue("@id", txtIdPenyewa.Text.Trim());
                            if (delCmd.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ResetForm();
                                LoadDataPenyewa();
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error hapus data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void dgvPenyewa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvPenyewa.Rows[e.RowIndex];

            if (e.ColumnIndex == dgvPenyewa.Columns["Edit"].Index)
            {
                LoadToForm(row);
                isEditMode = true; btnSimpan.Enabled = false; btnEdit.Enabled = true;
            }
            else if (e.ColumnIndex == dgvPenyewa.Columns["Hapus"].Index)
            {
                txtIdPenyewa.Text = row.Cells["id_penyewa"].Value?.ToString();
                btnHapus.PerformClick();
            }
            else
            {
                LoadToForm(row);
                isEditMode = false; btnSimpan.Enabled = true; btnEdit.Enabled = true;
            }
        }

        private void LoadToForm(DataGridViewRow row)
        {
            txtIdPenyewa.Text = row.Cells["id_penyewa"].Value?.ToString();
            string jenis = row.Cells["jenis"].Value?.ToString();
            if (jenis == "perorangan")
            {
                rbPerorangan.Checked = true;
                txtNamaLengkap.Text = row.Cells["nama_display"].Value?.ToString();
                txtNoKTP.Text = row.Cells["no_identitas"].Value?.ToString();
            }
            else
            {
                rbPerusahaan.Checked = true;
                // Parsing "PT. X (PIC: Y)"
                string display = row.Cells["nama_display"].Value?.ToString() ?? "";
                int picStart = display.IndexOf("(PIC:");
                txtNamaPerusahaan.Text = picStart > 0 ? display.Substring(0, picStart).Trim() : display;
                txtNamaPIC.Text = picStart > 0 ? display.Substring(picStart + 5, display.Length - picStart - 6).Trim() : "";
                txtNoNIB.Text = row.Cells["no_identitas"].Value?.ToString();
            }
            txtNoHP.Text = row.Cells["no_hp"].Value?.ToString();
            cbStatus.SelectedItem = row.Cells["status"].Value?.ToString();

            txtEmail.Text = row.Cells["email"].Value?.ToString();  
            txtAlamat.Text = row.Cells["alamat"].Value?.ToString();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            string keyword = txtCari.Text.Trim();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT id_penyewa, jenis_penyewa, nama_perusahaan, nama_penyewa, 
                                    no_identitas, no_hp, email, alamat, npwp, status 
                             FROM penyewa 
                             WHERE nama_penyewa LIKE @kw 
                                OR nama_perusahaan LIKE @kw 
                                OR no_identitas LIKE @kw 
                                OR no_hp LIKE @kw
                             ORDER BY nama_penyewa ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvPenyewa.Rows.Clear();

                            foreach (DataRow row in dt.Rows)
                            {
                                string jenis = row["jenis_penyewa"].ToString();
                                string namaDisplay = jenis == "perorangan"
                                    ? row["nama_penyewa"].ToString()
                                    : $"{row["nama_perusahaan"]} (PIC: {row["nama_penyewa"]})";

                                dgvPenyewa.Rows.Add(
                                    row["id_penyewa"].ToString(),
                                    jenis,
                                    namaDisplay,
                                    row["no_identitas"].ToString(),
                                    row["no_hp"].ToString(),
                                    row["status"].ToString()
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cari data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}