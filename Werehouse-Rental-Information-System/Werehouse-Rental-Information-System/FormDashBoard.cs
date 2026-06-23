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
    public partial class FormDashBoard : Form
    {
        public FormDashBoard()
        {
            InitializeComponent();
        }

        private void LoadDashboardData()
        {
            string connString = "server=localhost;port=3306;database=db_penyewaan_gudang;uid=root;password=;SslMode=None;";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    // 1. Total Gudang
                    string query1 = "SELECT COUNT(*) FROM gudang";
                    MySqlCommand cmd1 = new MySqlCommand(query1, conn);
                    lblTotalGudang.Text = cmd1.ExecuteScalar().ToString();

                    // 2. Gudang Tersedia
                    string query2 = "SELECT COUNT(*) FROM gudang WHERE status = 'tersedia'";
                    MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                    lblGudangTersedia.Text = cmd2.ExecuteScalar().ToString();

                    // 3. Pendapatan Bulan Ini
                    string query3 = @"SELECT COALESCE(SUM(nominal), 0) FROM pembayaran 
                              WHERE MONTH(tgl_bayar) = MONTH(CURDATE()) 
                              AND YEAR(tgl_bayar) = YEAR(CURDATE())";
                    MySqlCommand cmd3 = new MySqlCommand(query3, conn);
                    decimal pendapatan = Convert.ToDecimal(cmd3.ExecuteScalar());
                    lblPendapatan.Text = "Rp " + pendapatan.ToString("N0");

                    // 4. Jatuh Tempo (7 hari ke depan)
                    string query4 = @"SELECT COUNT(*) FROM kontrak 
                              WHERE tgl_selesai BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL 7 DAY)
                              AND status = 'Aktif'";
                    MySqlCommand cmd4 = new MySqlCommand(query4, conn);
                    lblJatuhTempo.Text = cmd4.ExecuteScalar().ToString();

                    // 5. Load Tabel Peringatan
                    LoadTabelPeringatan(conn);

                    LoadChartOkupansi(conn);
                    LoadChartPendapatan(conn);

                    MessageBox.Show("Data dashboard berhasil dimuat!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error load dashboard: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadTabelPeringatan(MySqlConnection conn)
        {
            string query = @"SELECT 
                        p.nama_penyewa,
                        g.nama_gudang,
                        k.tgl_selesai,
                        k.total_harga,
                        CASE 
                            WHEN EXISTS (
                                SELECT 1 FROM pembayaran pb 
                                WHERE pb.no_kontrak = k.no_kontrak 
                                AND pb.tgl_bayar >= k.tgl_selesai
                            ) THEN 'Lunas'
                            ELSE 'Belum Bayar'
                        END as StatusBayar
                      FROM kontrak k
                      JOIN penyewa p ON k.id_penyewa = p.id_penyewa
                      JOIN gudang g ON k.kode_gudang = g.kode_gudang
                      WHERE k.tgl_selesai BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL 7 DAY)
                      AND k.status = 'Aktif'
                      ORDER BY k.tgl_selesai";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                dgvPeringatan.Rows.Clear();

                while (reader.Read())
                {
                    dgvPeringatan.Rows.Add(
                        reader["nama_penyewa"].ToString(),
                        reader["nama_gudang"].ToString(),
                        Convert.ToDateTime(reader["tgl_selesai"]).ToString("dd/MM/yyyy"),
                        "Rp " + Convert.ToDecimal(reader["total_harga"]).ToString("N0"),
                        reader["StatusBayar"].ToString()
                    );
                }
            }
        }


        private void SetupDataGridView()
        {
            // Cek apakah kolom sudah ada, agar tidak dobel saat refresh
            if (dgvPeringatan.Columns.Count == 0)
            {
                dgvPeringatan.Columns.Add("NamaPenyewa", "Nama Penyewa");
                dgvPeringatan.Columns.Add("NamaGudang", "Nama Gudang");
                dgvPeringatan.Columns.Add("TglSelesai", "Jatuh Tempo");
                dgvPeringatan.Columns.Add("Nominal", "Nominal yang harus dibayar");
                dgvPeringatan.Columns.Add("StatusBayar", "Status Bayar");

                dgvPeringatan.ReadOnly = true;
                dgvPeringatan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvPeringatan.AllowUserToAddRows = false;
            }
        }

        private void FormDashBoard_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadDashboardData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
            MessageBox.Show("Data berhasil di-refresh!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadChartOkupansi(MySqlConnection conn)
        {
            chartOkupansi.Series.Clear();
            chartOkupansi.Titles.Clear();

            string query = @"SELECT 
                                SUM(CASE WHEN status = 'terisi' THEN 1 ELSE 0 END) as Terisi,
                                SUM(CASE WHEN status = 'tersedia' THEN 1 ELSE 0 END) as Tersedia
                              FROM gudang";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    int terisi = Convert.ToInt32(reader["Terisi"]);
                    int tersedia = Convert.ToInt32(reader["Tersedia"]);

                    var series = chartOkupansi.Series.Add("Okupansi");
                    series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

                    series.Points.AddXY("Gudang Terisi", terisi);
                    series.Points.AddXY("Gudang Tersedia", tersedia);

                    series.Points[0].Color = Color.FromArgb(46, 204, 113); // Hijau
                    series.Points[1].Color = Color.FromArgb(230, 126, 34); // Orange

                    series.IsValueShownAsLabel = true;
                    series.Label = "#VALX\n#PERCENT{P0}";

                    chartOkupansi.Titles.Add("Persentase Okupansi Gudang");
                }
                // Reader otomatis ditutup di sini karena menggunakan 'using'
            }
        }

        private void LoadChartPendapatan(MySqlConnection conn)
        {
            chartPendapatan.Series.Clear();
            chartPendapatan.Titles.Clear();

            string query = @"SELECT 
                                DATE_FORMAT(tgl_bayar, '%M %Y') as Bulan,
                                SUM(nominal) as Total
                              FROM pembayaran 
                              WHERE tgl_bayar >= DATE_SUB(CURDATE(), INTERVAL 6 MONTH)
                              GROUP BY DATE_FORMAT(tgl_bayar, '%Y-%m'), Bulan
                              ORDER BY MIN(tgl_bayar)";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                var series = chartPendapatan.Series.Add("Pendapatan");
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                series.Color = Color.FromArgb(52, 152, 219); // Biru
                series.IsValueShownAsLabel = true;
                series.Label = "Rp #VALY{N0}";

                while (reader.Read())
                {
                    string bulan = reader["Bulan"].ToString();
                    decimal total = Convert.ToDecimal(reader["Total"]);
                    series.Points.AddXY(bulan, total);
                }

                chartPendapatan.ChartAreas[0].AxisX.Title = "Bulan";
                chartPendapatan.ChartAreas[0].AxisY.Title = "Pendapatan (Rp)";
                chartPendapatan.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
                chartPendapatan.Titles.Add("Pendapatan 6 Bulan Terakhir");

                // Reader otomatis ditutup di sini
            }
        }
        
        private void chartOkupansi_Click(object sender, EventArgs e)
        {

        }
    }
}
