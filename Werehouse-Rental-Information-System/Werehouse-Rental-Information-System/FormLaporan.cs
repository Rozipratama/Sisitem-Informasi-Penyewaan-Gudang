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
using Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Werehouse_Rental_Information_System
{
    public partial class FormLaporan : Form
    {
        string connectionString = "server=localhost;port=3306;database=db_penyewaan_gudang;uid=root;password=;SslMode=None;";

        public FormLaporan()
        {
            InitializeComponent();
        }

        private void FormLaporan_Load(object sender, EventArgs e)
        {
            SetupComboBoxJenisLaporan();
            SetupDataGridView();
            
            dtpDari.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpSampai.Value = DateTime.Now;
        }

        private void SetupComboBoxJenisLaporan()
        {
            cbJenisLaporan.Items.Clear();
            cbJenisLaporan.Items.Add("Laporan Pembayaran");
            cbJenisLaporan.Items.Add("Laporan Kontrak");
            cbJenisLaporan.Items.Add("Laporan Pendapatan per Gudang");
            cbJenisLaporan.Items.Add("Laporan Penyewa Aktif");
            cbJenisLaporan.SelectedIndex = 0;
            cbJenisLaporan.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void SetupDataGridView()
        {
            dgvLaporan.Columns.Clear();
            dgvLaporan.ReadOnly = true;
            dgvLaporan.AllowUserToAddRows = false;
            dgvLaporan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLaporan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            string jenisLaporan = cbJenisLaporan.SelectedItem.ToString();
            DateTime tglDari = dtpDari.Value.Date;
            DateTime tglSampai = dtpSampai.Value.Date;

            if (tglSampai < tglDari)
            {
                MessageBox.Show("Tanggal 'Sampai' tidak boleh lebih kecil dari 'Dari'!",
                    "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            switch (jenisLaporan)
            {
                case "Laporan Pembayaran":
                    LoadLaporanPembayaran(tglDari, tglSampai);
                    break;
                case "Laporan Kontrak":
                    LoadLaporanKontrak(tglDari, tglSampai);
                    break;
                case "Laporan Pendapatan per Gudang":
                    LoadLaporanPendapatanGudang(tglDari, tglSampai);
                    break;
                case "Laporan Penyewa Aktif":
                    LoadLaporanPenyewaAktif();
                    break;
            }
        }

        private void LoadLaporanPembayaran(DateTime tglDari, DateTime tglSampai)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"SELECT pb.id_pembayaran, pb.tgl_bayar, pb.no_kontrak,
                                    CONCAT(p.nama_penyewa, 
                                        CASE WHEN p.jenis_penyewa = 'perusahaan' 
                                        THEN CONCAT(' - ', p.nama_perusahaan) ELSE '' END) as penyewa,
                                    g.nama_gudang,
                                    pb.nominal, pb.denda, pb.total_bayar, pb.metode
                             FROM pembayaran pb
                             JOIN kontrak k ON pb.no_kontrak = k.no_kontrak
                             JOIN penyewa p ON k.id_penyewa = p.id_penyewa
                             JOIN gudang g ON k.kode_gudang = g.kode_gudang
                             WHERE pb.tgl_bayar BETWEEN @dari AND @sampai
                             ORDER BY pb.tgl_bayar DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@dari", tglDari);
                        cmd.Parameters.AddWithValue("@sampai", tglSampai);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            System.Data.DataTable dt = new System.Data.DataTable();
                            adapter.Fill(dt);  // ✅ Data diambil dari database

                            // ✅ Setup kolom DataGridView (HANYA SEKALI)
                            dgvLaporan.Columns.Clear();
                            dgvLaporan.Columns.Add("no", "No");
                            dgvLaporan.Columns.Add("tgl_bayar", "Tgl Bayar");
                            dgvLaporan.Columns.Add("no_kontrak", "No. Kontrak");
                            dgvLaporan.Columns.Add("penyewa", "Penyewa");
                            dgvLaporan.Columns.Add("nama_gudang", "Gudang");
                            dgvLaporan.Columns.Add("nominal", "Nominal");
                            dgvLaporan.Columns.Add("denda", "Denda");
                            dgvLaporan.Columns.Add("total_bayar", "Total Bayar");
                            dgvLaporan.Columns.Add("metode", "Metode");

                            int no = 1;
                            decimal totalPendapatan = 0;
                            decimal totalDenda = 0;

                            foreach (DataRow row in dt.Rows)
                            {
                                decimal nominal = Convert.ToDecimal(row["nominal"]);
                                decimal denda = Convert.ToDecimal(row["denda"]);
                                decimal total = Convert.ToDecimal(row["total_bayar"]);

                                dgvLaporan.Rows.Add(
                                    no++,
                                    Convert.ToDateTime(row["tgl_bayar"]).ToString("dd/MM/yyyy"),
                                    row["no_kontrak"].ToString(),
                                    row["penyewa"].ToString(),
                                    row["nama_gudang"].ToString(),
                                    "Rp " + nominal.ToString("N0"),
                                    "Rp " + denda.ToString("N0"),
                                    "Rp " + total.ToString("N0"),
                                    row["metode"].ToString()
                                );

                                totalPendapatan += total;
                                totalDenda += denda;
                            }

                            // ✅ Tampilkan summary
                            lblSummary.Text = $"LAPORAN PEMBAYARAN\n" +
                                            $"Periode: {tglDari.ToString("dd/MM/yyyy")} - {tglSampai.ToString("dd/MM/yyyy")}\n\n" +
                                            $"Total Transaksi : {dt.Rows.Count}\n" +
                                            $"Total Pendapatan: Rp {totalPendapatan.ToString("N0")}\n" +
                                            $"Total Denda     : Rp {totalDenda.ToString("N0")}\n" +
                                            $"Rata-rata       : Rp {(dt.Rows.Count > 0 ? totalPendapatan / dt.Rows.Count : 0).ToString("N0")}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load laporan: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLaporanKontrak(DateTime tglDari, DateTime tglSampai)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"SELECT k.no_kontrak, 
                                            CONCAT(p.nama_penyewa, 
                                                CASE WHEN p.jenis_penyewa = 'perusahaan' 
                                                THEN CONCAT(' - ', p.nama_perusahaan) ELSE '' END) as penyewa,
                                            g.nama_gudang,
                                            k.tgl_mulai, k.tgl_selesai, k.total_harga, k.status
                                     FROM kontrak k
                                     JOIN penyewa p ON k.id_penyewa = p.id_penyewa
                                     JOIN gudang g ON k.kode_gudang = g.kode_gudang
                                     WHERE k.tgl_mulai BETWEEN @dari AND @sampai
                                     ORDER BY k.no_kontrak DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@dari", tglDari);
                        cmd.Parameters.AddWithValue("@sampai", tglSampai);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            System.Data.DataTable dt = new System.Data.DataTable();
                            adapter.Fill(dt);

                            dgvLaporan.Columns.Clear();
                            dgvLaporan.Columns.Add("no", "No");
                            dgvLaporan.Columns.Add("no_kontrak", "No. Kontrak");
                            dgvLaporan.Columns.Add("penyewa", "Penyewa");
                            dgvLaporan.Columns.Add("nama_gudang", "Gudang");
                            dgvLaporan.Columns.Add("tgl_mulai", "Tgl Mulai");
                            dgvLaporan.Columns.Add("tgl_selesai", "Tgl Selesai");
                            dgvLaporan.Columns.Add("total_harga", "Total Harga");
                            dgvLaporan.Columns.Add("status", "Status");

                            int no = 1;
                            decimal totalNilai = 0;

                            foreach (DataRow row in dt.Rows)
                            {
                                decimal total = Convert.ToDecimal(row["total_harga"]);

                                dgvLaporan.Rows.Add(
                                    no++,
                                    row["no_kontrak"].ToString(),
                                    row["penyewa"].ToString(),
                                    row["nama_gudang"].ToString(),
                                    Convert.ToDateTime(row["tgl_mulai"]).ToString("dd/MM/yyyy"),
                                    Convert.ToDateTime(row["tgl_selesai"]).ToString("dd/MM/yyyy"),
                                    "Rp " + total.ToString("N0"),
                                    row["status"].ToString()
                                );

                                totalNilai += total;
                            }

                            lblSummary.Text = $"LAPORAN KONTRAK\n" +
                                            $"Periode: {tglDari.ToString("dd/MM/yyyy")} - {tglSampai.ToString("dd/MM/yyyy")}\n\n" +
                                            $"Total Kontrak  : {dt.Rows.Count}\n" +
                                            $"Total Nilai    : Rp {totalNilai.ToString("N0")}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load laporan: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLaporanPendapatanGudang(DateTime tglDari, DateTime tglSampai)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"SELECT g.nama_gudang, g.lokasi,
                                            COUNT(pb.id_pembayaran) as jumlah_transaksi,
                                            COALESCE(SUM(pb.total_bayar), 0) as total_pendapatan
                                     FROM gudang g
                                     LEFT JOIN kontrak k ON g.kode_gudang = k.kode_gudang
                                     LEFT JOIN pembayaran pb ON k.no_kontrak = pb.no_kontrak
                                     WHERE pb.tgl_bayar BETWEEN @dari AND @sampai
                                     GROUP BY g.kode_gudang, g.nama_gudang, g.lokasi
                                     ORDER BY total_pendapatan DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@dari", tglDari);
                        cmd.Parameters.AddWithValue("@sampai", tglSampai);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            System.Data.DataTable dt = new System.Data.DataTable();
                            adapter.Fill(dt);

                            dgvLaporan.Columns.Clear();
                            dgvLaporan.Columns.Add("no", "No");
                            dgvLaporan.Columns.Add("nama_gudang", "Nama Gudang");
                            dgvLaporan.Columns.Add("lokasi", "Lokasi");
                            dgvLaporan.Columns.Add("jumlah_transaksi", "Jml Transaksi");
                            dgvLaporan.Columns.Add("total_pendapatan", "Total Pendapatan");

                            int no = 1;
                            decimal grandTotal = 0;

                            foreach (DataRow row in dt.Rows)
                            {
                                decimal total = Convert.ToDecimal(row["total_pendapatan"]);

                                dgvLaporan.Rows.Add(
                                    no++,
                                    row["nama_gudang"].ToString(),
                                    row["lokasi"].ToString(),
                                    row["jumlah_transaksi"].ToString(),
                                    "Rp " + total.ToString("N0")
                                );

                                grandTotal += total;
                            }

                            lblSummary.Text = $"LAPORAN PENDAPATAN PER GUDANG\n" +
                                            $"Periode: {tglDari.ToString("dd/MM/yyyy")} - {tglSampai.ToString("dd/MM/yyyy")}\n\n" +
                                            $"Total Gudang   : {dt.Rows.Count}\n" +
                                            $"Grand Total    : Rp {grandTotal.ToString("N0")}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load laporan: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLaporanPenyewaAktif()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"SELECT p.id_penyewa,
                                            CONCAT(p.nama_penyewa, 
                                                CASE WHEN p.jenis_penyewa = 'perusahaan' 
                                                THEN CONCAT(' - ', p.nama_perusahaan) ELSE '' END) as penyewa,
                                            p.no_hp, p.email,
                                            COUNT(k.no_kontrak) as jumlah_kontrak,
                                            GROUP_CONCAT(DISTINCT g.nama_gudang SEPARATOR ', ') as gudang_disewa
                                     FROM penyewa p
                                     LEFT JOIN kontrak k ON p.id_penyewa = k.id_penyewa AND k.status = 'Aktif'
                                     LEFT JOIN gudang g ON k.kode_gudang = g.kode_gudang
                                     WHERE p.status = 'aktif'
                                     GROUP BY p.id_penyewa, p.nama_penyewa, p.jenis_penyewa, p.nama_perusahaan, p.no_hp, p.email
                                     HAVING jumlah_kontrak > 0
                                     ORDER BY jumlah_kontrak DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        System.Data.DataTable dt = new System.Data.DataTable();
                        adapter.Fill(dt);

                        dgvLaporan.Columns.Clear();
                        dgvLaporan.Columns.Add("no", "No");
                        dgvLaporan.Columns.Add("penyewa", "Penyewa");
                        dgvLaporan.Columns.Add("no_hp", "No. HP");
                        dgvLaporan.Columns.Add("email", "Email");
                        dgvLaporan.Columns.Add("jumlah_kontrak", "Jml Kontrak");
                        dgvLaporan.Columns.Add("gudang_disewa", "Gudang Disewa");

                        int no = 1;

                        foreach (DataRow row in dt.Rows)
                        {
                            dgvLaporan.Rows.Add(
                                no++,
                                row["penyewa"].ToString(),
                                row["no_hp"].ToString(),
                                row["email"].ToString(),
                                row["jumlah_kontrak"].ToString(),
                                row["gudang_disewa"].ToString()
                            );
                        }

                        lblSummary.Text = $"LAPORAN PENYEWA AKTIF\n" +
                                        $"Per: {DateTime.Now.ToString("dd/MM/yyyy")}\n\n" +
                                        $"Total Penyewa Aktif: {dt.Rows.Count}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load laporan: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if(dgvLaporan.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data untuk diekspor!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Buat aplikasi Excel
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = false;

                Workbook workbook = excelApp.Workbooks.Add();
                Worksheet worksheet = (Worksheet)workbook.Sheets[1];

                // Copy header
                for (int i = 0; i < dgvLaporan.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dgvLaporan.Columns[i].HeaderText;
                    worksheet.Cells[1, i + 1].Font.Bold = true;
                    worksheet.Cells[1, i + 1].Interior.Color = Color.LightBlue.ToArgb();
                }

                // Copy data
                for (int i = 0; i < dgvLaporan.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvLaporan.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dgvLaporan.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                // Auto-fit columns
                worksheet.Columns.AutoFit();

                // Save file
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel Files|*.xlsx";
                saveDialog.Title = "Simpan Laporan Excel";
                saveDialog.FileName = $"Laporan_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Laporan berhasil diekspor ke Excel!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Cleanup
                workbook.Close(false);
                excelApp.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                worksheet = null;
                workbook = null;
                excelApp = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error export Excel: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            if (dgvLaporan.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data untuk dicetak!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Simple print - bisa dikembangkan dengan Crystal Reports atau RDLC
            MessageBox.Show("Fitur cetak sedang dalam pengembangan.\nGunakan Export Excel untuk sementara.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCloce_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
