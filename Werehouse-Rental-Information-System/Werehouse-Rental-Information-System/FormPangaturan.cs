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
    public partial class FormPangaturan : Form
    {
        string connectionString = "server=localhost;port=3306;database=db_penyewaan_gudang;uid=root;password=;SslMode=None;";
        private string currentUserEmail;

        public FormPangaturan(string email)
        {
            InitializeComponent();
            currentUserEmail = email;
        }

        private void FormPangaturan_Load(object sender, EventArgs e)
        {
            // 1. Tampilkan Email User yang sedang login
            txtEmail.Text = currentUserEmail;

            // 2. Load Role dari Database
            LoadUserRole();

            // 3. Setup PasswordChar (titik-titik) agar password tersembunyi
            txtPassLama.UseSystemPasswordChar = true;
            txtPassBaru.UseSystemPasswordChar = true;
            txtKonfirmasi.UseSystemPasswordChar = true;

            // 4. Pastikan textbox password kosong saat pertama buka
            ClearPasswordFields();
        }

        private void LoadUserRole()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT role FROM users WHERE email = @email";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", currentUserEmail);
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            txtRole.Text = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat role: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            string passLama = txtPassLama.Text.Trim();
            string passBaru = txtPassBaru.Text.Trim();
            string konfirmasi = txtKonfirmasi.Text.Trim();

            // Validasi Input Kosong
            if (string.IsNullOrEmpty(passLama) || string.IsNullOrEmpty(passBaru) || string.IsNullOrEmpty(konfirmasi))
            {
                MessageBox.Show("Semua kolom password harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validasi Password Baru Sama
            if (passBaru != konfirmasi)
            {
                MessageBox.Show("Password baru dan konfirmasi password tidak cocok!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Cek apakah Password Lama benar
                    string checkQuery = "SELECT password FROM users WHERE email = @email AND password = @pass";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@email", currentUserEmail);
                        checkCmd.Parameters.AddWithValue("@pass", passLama);

                        bool isPasswordCorrect = checkCmd.ExecuteScalar() != null;

                        if (!isPasswordCorrect)
                        {
                            MessageBox.Show("Password lama salah!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Update Password Baru
                    string updateQuery = "UPDATE users SET password = @newPass WHERE email = @email";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@newPass", passBaru);
                        updateCmd.Parameters.AddWithValue("@email", currentUserEmail);

                        if (updateCmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Password berhasil diganti! Silakan login ulang.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearPasswordFields(); // Kosongkan lagi setelah sukses
                        }
                        else
                        {
                            MessageBox.Show("Gagal menyimpan password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan sistem: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCloce_Click(object sender, EventArgs e)
        {
            ClearPasswordFields();
            txtPassLama.Focus();
        }

        private void ClearPasswordFields()
        {
            txtPassLama.Clear();
            txtPassBaru.Clear();
            txtKonfirmasi.Clear();
        }
    }
}