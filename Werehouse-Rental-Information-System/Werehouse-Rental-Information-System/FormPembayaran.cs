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
    public partial class FormPembayaran : Form
    {
        string connectionString = "server=localhost;port=3306;database=db_penyewaan_gudang;uid=root;password=;SslMode=None;";
        string selectedNoKontrak = "";
        bool isEditMode = false;

        public FormPembayaran()
        {
            InitializeComponent();
        }

        private void FormPembayaran_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            SetupComboBoxMetode();
            LoadDataPembayaran();
            ResetForm();
        }

        private void SetupDataGridView()
        {
            dgvPembayaran.Columns.Clear();
            dgvPembayaran.Columns.Add("id_pembayaran", "ID");
            dgvPembayaran.Columns.Add("no_kontrak", "No. Kontrak");
            dgvPembayaran.Columns.Add("penyewa", "Penyewa");
            dgvPembayaran.Columns.Add("tgl_bayar", "Tgl Bayar");
            dgvPembayaran.Columns.Add("nominal", "Nominal");
            dgvPembayaran.Columns.Add("denda", "Denda");
            dgvPembayaran.Columns.Add("total_bayar", "Total Bayar");
            dgvPembayaran.Columns.Add("metode", "Metode");

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
            dgvPembayaran.Columns.Add(btnEdit);
            dgvPembayaran.Columns.Add(btnHapus);

            dgvPembayaran.ReadOnly = true;
            dgvPembayaran.AllowUserToAddRows = false;
            dgvPembayaran.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPembayaran.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void SetupComboBoxMetode()
        {
            cbMetode.Items.Clear();
            cbMetode.Items.Add("Tunai");
            cbMetode.Items.Add("Transfer");
            cbMetode.Items.Add("QRIS");
            cbMetode.Items.Add("Virtual Account");
            cbMetode.SelectedIndex = 0;
            cbMetode.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnPilihKontrak_Click(object sender, EventArgs e)
        {
            FormPilihKontrak frm = new FormPilihKontrak(connectionString);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                selectedNoKontrak = frm.SelectedNoKontrak;
                LoadDetailKontrak(selectedNoKontrak);
            }
        }

        private void LoadDetailKontrak(string noKontrak)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"SELECT k.no_kontrak, k.tgl_selesai, k.total_harga,
                                    p.nama_penyewa, p.jenis_penyewa, p.nama_perusahaan,
                                    g.nama_gudang
                             FROM kontrak k
                             JOIN penyewa p ON k.id_penyewa = p.id_penyewa
                             JOIN gudang g ON k.kode_gudang = g.kode_gudang
                             WHERE k.no_kontrak = @no AND k.status = 'Aktif'";
                    
                    string kontrakNo = "";
                    DateTime tglSelesai = DateTime.MinValue;
                    decimal totalHarga = 0;
                    string namaPenyewa = "";
                    string jenisPenyewa = "";
                    string namaPerusahaan = "";
                    string namaGudang = "";
                    bool dataFound = false;

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@no", noKontrak);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // ✅ Simpan ke variabel
                                kontrakNo = reader["no_kontrak"].ToString();
                                tglSelesai = Convert.ToDateTime(reader["tgl_selesai"]);
                                totalHarga = Convert.ToDecimal(reader["total_harga"]);
                                namaPenyewa = reader["nama_penyewa"].ToString();
                                jenisPenyewa = reader["jenis_penyewa"].ToString();
                                namaPerusahaan = reader["nama_perusahaan"].ToString();
                                namaGudang = reader["nama_gudang"].ToString();
                                dataFound = true;
                            }
                        }
                    }

                    // ✅ Isi form jika data ditemukan
                    if (dataFound)
                    {
                        txtNoKontrak.Text = kontrakNo;
                        txtPenyewa.Text = jenisPenyewa == "perusahaan"
                            ? $"{namaPerusahaan} (PIC: {namaPenyewa})"
                            : namaPenyewa;
                        txtGudang.Text = namaGudang;
                        dtpJatuhTempo.Value = tglSelesai;

                        decimal sudahDibayar = GetTotalSudahDibayar(noKontrak);
                        decimal sisa = totalHarga - sudahDibayar;

                        txtSisaTagihan.Text = "Rp " + sisa.ToString("N0");
                        txtNominal.Text = "Rp " + sisa.ToString("N0");

                        grpInput.Enabled = true;
                        btnSimpan.Enabled = true;

                        HitungDenda();
                    }
                    else
                    {
                        MessageBox.Show("Kontrak tidak ditemukan atau sudah tidak aktif!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load kontrak: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal GetTotalSudahDibayar(string noKontrak)
        {
            try
            {
                // Pakai connection terpisah agar tidak bentrok dengan reader lain
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COALESCE(SUM(total_bayar), 0) FROM pembayaran WHERE no_kontrak = @no";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@no", noKontrak);
                        return Convert.ToDecimal(cmd.ExecuteScalar());
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        private void dtpTanggalBayar_ValueChanged(object sender, EventArgs e)
        {
            HitungDenda();
        }

        private void txtNominal_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNominal.Text))
            {
                try
                {
                    string angka = txtNominal.Text.Replace("Rp ", "").Replace(".", "");
                    decimal nominal = Convert.ToDecimal(angka);
                    txtNominal.Text = "Rp " + nominal.ToString("N0");
                    HitungTotalBayar();
                }
                catch { }
            }
        }

        private void HitungDenda()
        {
            if (string.IsNullOrWhiteSpace(txtNoKontrak.Text)) return;

            DateTime tglJatuhTempo = dtpJatuhTempo.Value.Date;
            DateTime tglBayar = dtpTanggalBayar.Value.Date;

            if (tglBayar > tglJatuhTempo)
            {
                int telatHari = (tglBayar - tglJatuhTempo).Days;
                decimal dendaPerHari = 5000;
                decimal totalDenda = telatHari * dendaPerHari;

                txtDenda.Text = "Rp " + totalDenda.ToString("N0");
                lblInfoDenda.Text = $"Terlambat {telatHari} hari x Rp 5.000";
                lblInfoDenda.ForeColor = Color.Red;
            }
            else
            {
                txtDenda.Text = "Rp 0";
                lblInfoDenda.Text = "✓ Pembayaran tepat waktu";
                lblInfoDenda.ForeColor = Color.Green;
            }

            HitungTotalBayar();
        }

        private void HitungTotalBayar()
        {
            try
            {
                decimal nominal = Convert.ToDecimal(txtNominal.Text.Replace("Rp ", "").Replace(".", ""));
                decimal denda = Convert.ToDecimal(txtDenda.Text.Replace("Rp ", "").Replace(".", ""));
                decimal total = nominal + denda;

                txtTotalBayar.Text = "Rp " + total.ToString("N0");
            }
            catch { }
        }

        private void LoadDataPembayaran()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    
                    bool hasDenda = false;
                    bool hasTotalBayar = false;

                    string checkQuery = @"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS 
                                 WHERE TABLE_SCHEMA = 'db_penyewaan_gudang' 
                                 AND TABLE_NAME = 'pembayaran' 
                                 AND COLUMN_NAME IN ('denda', 'total_bayar')";

                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    using (MySqlDataReader reader = checkCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string colName = reader["COLUMN_NAME"].ToString();
                            if (colName == "denda") hasDenda = true;
                            if (colName == "total_bayar") hasTotalBayar = true;
                        }
                        reader.Close();
                    }

                    string query = "";
                    if (hasDenda && hasTotalBayar)
                    {
                        query = @"SELECT pb.id_pembayaran, pb.no_kontrak,  
                                CONCAT(p.nama_penyewa, 
                                    CASE WHEN p.jenis_penyewa = 'perusahaan' 
                                    THEN CONCAT(' - ', p.nama_perusahaan) ELSE '' END) as penyewa,
                                pb.tgl_bayar, pb.nominal, pb.denda, pb.total_bayar, pb.metode
                         FROM pembayaran pb
                         JOIN kontrak k ON pb.no_kontrak = k.no_kontrak
                         JOIN penyewa p ON k.id_penyewa = p.id_penyewa
                         ORDER BY pb.tgl_bayar DESC";
                    }
                    else
                    {
                        query = @"SELECT pb.id_pembayaran, pb.no_kontrak,  
                                CONCAT(p.nama_penyewa, 
                                    CASE WHEN p.jenis_penyewa = 'perusahaan' 
                                    THEN CONCAT(' - ', p.nama_perusahaan) ELSE '' END) as penyewa,
                                pb.tgl_bayar, pb.nominal, 
                                0 as denda, 
                                pb.nominal as total_bayar, 
                                pb.metode
                         FROM pembayaran pb
                         JOIN kontrak k ON pb.no_kontrak = k.no_kontrak
                         JOIN penyewa p ON k.id_penyewa = p.id_penyewa
                         ORDER BY pb.tgl_bayar DESC";
                    }

                    DataTable dt = new DataTable();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }

                    dgvPembayaran.Rows.Clear();

                    foreach (DataRow row in dt.Rows)
                    {
                        dgvPembayaran.Rows.Add(
                            row["id_pembayaran"].ToString(), 
                            row["no_kontrak"].ToString(),
                            row["penyewa"].ToString(),
                            Convert.ToDateTime(row["tgl_bayar"]).ToString("dd/MM/yyyy"),
                            "Rp " + Convert.ToDecimal(row["nominal"]).ToString("N0"),
                            "Rp " + Convert.ToDecimal(row["denda"]).ToString("N0"),
                            "Rp " + Convert.ToDecimal(row["total_bayar"]).ToString("N0"),
                            row["metode"].ToString()
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load pembayaran: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            selectedNoKontrak = "";
            txtNoKontrak.Clear();
            txtPenyewa.Clear();
            txtGudang.Clear();
            txtSisaTagihan.Clear();

            dtpTanggalBayar.Value = DateTime.Now;
            txtNominal.Clear();
            txtDenda.Text = "Rp 0";
            txtTotalBayar.Clear();
            cbMetode.SelectedIndex = 0;
            txtKeterangan.Clear();

            grpInput.Enabled = false;
            btnSimpan.Enabled = false;
            btnEdit.Enabled = false;

            lblInfoDenda.Text = "";
            
            isEditMode = false;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "";

                    if (isEditMode)
                    {
                        // ✅ MODE EDIT - UPDATE DATA
                        query = @"UPDATE pembayaran 
                         SET nominal = @nominal, 
                             denda = @denda, 
                             total_bayar = @total, 
                             metode = @metode, 
                             keterangan = @ket 
                         WHERE no_kontrak = @kontrak AND tgl_bayar = @tgl";
                    }
                    else
                    {
                        // ✅ MODE TAMBAH - INSERT DATA
                        query = @"INSERT INTO pembayaran 
                        (no_kontrak, tgl_bayar, nominal, denda, total_bayar, metode, keterangan) 
                        VALUES (@kontrak, @tgl, @nominal, @denda, @total, @metode, @ket)";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@kontrak", txtNoKontrak.Text.Trim());
                        cmd.Parameters.AddWithValue("@tgl", dtpTanggalBayar.Value.Date);
                        cmd.Parameters.AddWithValue("@nominal", Convert.ToDecimal(txtNominal.Text.Replace("Rp ", "").Replace(".", "")));
                        cmd.Parameters.AddWithValue("@denda", Convert.ToDecimal(txtDenda.Text.Replace("Rp ", "").Replace(".", "")));
                        cmd.Parameters.AddWithValue("@total", Convert.ToDecimal(txtTotalBayar.Text.Replace("Rp ", "").Replace(".", "")));
                        cmd.Parameters.AddWithValue("@metode", cbMetode.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@ket", txtKeterangan.Text.Trim());

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            string pesan = isEditMode ? "diperbarui" : "disimpan";
                            MessageBox.Show($"Pembayaran berhasil {pesan}!", "Sukses",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (!isEditMode)
                            {
                                CekStatusKontrak(conn, txtNoKontrak.Text.Trim());
                            }

                            ResetForm();
                            LoadDataPembayaran();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error simpan pembayaran: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CekStatusKontrak(MySqlConnection conn, string noKontrak)
        {
            string query = @"SELECT k.total_harga, COALESCE(SUM(pb.total_bayar), 0) as sudah_bayar
                            FROM kontrak k
                            LEFT JOIN pembayaran pb ON k.no_kontrak = pb.no_kontrak
                            WHERE k.no_kontrak = @no
                            GROUP BY k.total_harga";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@no", noKontrak);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        decimal total = Convert.ToDecimal(reader["total_harga"]);
                        decimal sudahBayar = Convert.ToDecimal(reader["sudah_bayar"]);

                        if (sudahBayar >= total)
                        {
                            using (MySqlCommand updateCmd = new MySqlCommand(
                                "UPDATE kontrak SET status = 'Selesai' WHERE no_kontrak = @no", conn))
                            {
                                updateCmd.Parameters.AddWithValue("@no", noKontrak);
                                updateCmd.ExecuteNonQuery();
                            }
                            MessageBox.Show("🎉 Kontrak ini sudah LUNAS!", "Info",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtNoKontrak.Text))
            {
                MessageBox.Show("Pilih kontrak terlebih dahulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNominal.Text) || txtNominal.Text == "Rp 0")
            {
                MessageBox.Show("Nominal pembayaran harus diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cbMetode.SelectedIndex < 0)
            {
                MessageBox.Show("Pilih metode pembayaran!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }



        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNoKontrak.Text))
            {
                MessageBox.Show("Pilih data pembayaran yang ingin diedit dari tabel!",
                    "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Load data pembayaran untuk edit
            LoadDataPembayaranUntukEdit(txtNoKontrak.Text, dtpTanggalBayar.Value.Date);

            isEditMode = true;
            btnSimpan.Enabled = false;
            btnEdit.Enabled = true;
            grpInput.Enabled = true;

            MessageBox.Show("Silakan edit data, lalu klik 💾 Simpan", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNoKontrak.Text))
            {
                MessageBox.Show("Pilih data pembayaran yang ingin dihapus!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Yakin ingin menghapus pembayaran ini?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM pembayaran WHERE no_kontrak = @no AND tgl_bayar = @tgl";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@no", txtNoKontrak.Text.Trim());
                            cmd.Parameters.AddWithValue("@tgl", dtpTanggalBayar.Value.Date);

                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Pembayaran berhasil dihapus!", "Sukses",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ResetForm();
                                LoadDataPembayaran();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error hapus pembayaran: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void dgvPembayaran_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvPembayaran.Rows[e.RowIndex];

            if (e.ColumnIndex == dgvPembayaran.Columns["Edit"].Index)
            {
                txtNoKontrak.Text = row.Cells["no_kontrak"].Value.ToString();
                LoadDetailKontrak(txtNoKontrak.Text);
                
                LoadDataPembayaranUntukEdit(
                    row.Cells["no_kontrak"].Value.ToString(),
                    Convert.ToDateTime(row.Cells["tgl_bayar"].Value)
                );

                isEditMode = true;
                btnSimpan.Enabled = false;
                btnEdit.Enabled = true;
                grpInput.Enabled = true;
            }
            else if (e.ColumnIndex == dgvPembayaran.Columns["Hapus"].Index)
            {
                txtNoKontrak.Text = row.Cells["no_kontrak"].Value.ToString();
                dtpTanggalBayar.Value = Convert.ToDateTime(row.Cells["tgl_bayar"].Value);
                btnHapus.PerformClick();
            }
        }

        private void txtNominal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void LoadDataPembayaranUntukEdit(string noKontrak, DateTime tglBayar)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT * FROM pembayaran 
                            WHERE no_kontrak = @no AND tgl_bayar = @tgl";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@no", noKontrak);
                        cmd.Parameters.AddWithValue("@tgl", tglBayar);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                dtpTanggalBayar.Value = Convert.ToDateTime(reader["tgl_bayar"]);
                                txtNominal.Text = "Rp " + Convert.ToDecimal(reader["nominal"]).ToString("N0");
                                txtDenda.Text = "Rp " + Convert.ToDecimal(reader["denda"]).ToString("N0");
                                txtTotalBayar.Text = "Rp " + Convert.ToDecimal(reader["total_bayar"]).ToString("N0");
                                cbMetode.SelectedItem = reader["metode"].ToString();
                                txtKeterangan.Text = reader["keterangan"].ToString();

                                // Update label info denda
                                HitungDenda();
                            }
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
    }
}