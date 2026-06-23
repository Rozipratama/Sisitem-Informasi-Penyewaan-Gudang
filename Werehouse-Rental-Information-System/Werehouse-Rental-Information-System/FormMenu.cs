using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Werehouse_Rental_Information_System
{
    public partial class FormMenu : Form
    {

        public string Username { get; set; }
        public string Role { get; set; }

        public FormMenu(string user, string role)
        {
            InitializeComponent();

            Username = user;
            Role = role;

            string RoleUser = "Admin"; // Ganti dengan variabel global dari FormLogin

            if (RoleUser == "User")
            {
                // User Biasa: Hanya boleh lihat Dashboard & Laporan
                btnGudang.Visible = false;
                btnPenyewa.Visible = false;
                btnKontrak.Visible = false;
                btnPembayaran.Visible = false;
                btnPengaturan.Visible = false;
            }
            else if (RoleUser == "Staff")
            {
                // Staff: Boleh kerja (Input data), tapi tidak boleh ubah setting sistem
                btnGudang.Visible = true;
                btnPenyewa.Visible = true;
                btnKontrak.Visible = true;
                btnPembayaran.Visible = true;
                btnPengaturan.Visible = false; // Staff tidak boleh masuk Pengaturan
            }
            else // Admin
            {
                // Admin: Semua tombol tampil
                btnGudang.Visible = true;
                btnPengaturan.Visible = true;
                // ... tombol lain true ...
            }
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            lblUser.Text = $"👤 {Username} | Role: {Role}";

            lblUser.Width = 400;

            AturHakAkses(Role);
        }

        private void AturHakAkses(string role)
        {
            btnGudang.Visible = true;
            btnPenyewa.Visible = true;
            btnKontrak.Visible = true;
            btnPembayaran.Visible = true;
            btnPengaturan.Visible = true;
            btnDashBoard.Visible = true;
            btnLaporan.Visible = true;

            if (role == "User")
            {
                btnGudang.Visible = false;
                btnPenyewa.Visible = false;
                btnKontrak.Visible = false;
                btnPembayaran.Visible = false;
                btnPengaturan.Visible = false;
            }
            else if (role == "Staf")
            {
                btnGudang.Visible = true;
                btnPenyewa.Visible = true;
                btnKontrak.Visible = true;
                btnPembayaran.Visible = true;
                btnPengaturan.Visible = false;
            }
        }
        private void ShowFormInPanel(Form form)
        {
            panelUtama.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            if (panelUtama.BackColor == Color.Transparent)
                form.BackColor = Color.White;
            else
                form.BackColor = panelUtama.BackColor;

            panelUtama.Controls.Add(form);
            form.Show();
            form.BringToFront();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new FormDashBoard());
        }

        private void btnGudang_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new FormGudang());
        }

        private void btnPenyewa_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new FormPenyewa());
        }

        private void btnKontrak_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new FormKontrak());
        }

        private void btnPembayaran_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new FormPembayaran());
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new FormLaporan());
        }

        private void btnPengaturan_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new FormPangaturan());
        }
        
        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {
            // Sidebar
            panelMenu.Dock = DockStyle.Left;

            btnDashBoard.Anchor = AnchorStyles.Left;
            btnGudang.Anchor = AnchorStyles.Left;
            btnPenyewa.Anchor = AnchorStyles.Left;
            btnKontrak.Anchor = AnchorStyles.Left;
            btnPembayaran.Anchor = AnchorStyles.Left;
            btnLaporan.Anchor = AnchorStyles.Left;

            // Tombol Quit di bawah
            btnQuit.Dock = DockStyle.Bottom;

        }
        
        private void btnQuit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Apakah Anda yakin ingin keluar aplikasi?",
                "Konfirmasi Keluar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void panelUtama_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
