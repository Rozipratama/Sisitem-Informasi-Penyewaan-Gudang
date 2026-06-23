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
    public partial class FormPilihKontrak : Form
    {
        public FormPilihKontrak()
        {
            InitializeComponent();
        }

        private void FormPilihKontrak_Load(object sender, EventArgs e)
        {
            LoadKontrakAktif();
        }

        private string connectionString;
        public string SelectedNoKontrak { get; private set; }

        public FormPilihKontrak(string connString)
        {
            InitializeComponent();
            connectionString = connString;
        }

        private void LoadKontrakAktif()
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
                                            k.tgl_selesai,
                                            k.total_harga
                                     FROM kontrak k
                                     JOIN penyewa p ON k.id_penyewa = p.id_penyewa
                                     JOIN gudang g ON k.kode_gudang = g.kode_gudang
                                     WHERE k.status = 'Aktif'
                                     ORDER BY k.no_kontrak DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvKontrak.DataSource = dt;
                        dgvKontrak.Columns["no_kontrak"].HeaderText = "No. Kontrak";
                        dgvKontrak.Columns["penyewa"].HeaderText = "Penyewa";
                        dgvKontrak.Columns["nama_gudang"].HeaderText = "Gudang";
                        dgvKontrak.Columns["tgl_selesai"].HeaderText = "Jatuh Tempo";
                        dgvKontrak.Columns["total_harga"].HeaderText = "Total";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvKontrak_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKontrak.Rows[e.RowIndex];
                SelectedNoKontrak = row.Cells["no_kontrak"].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
