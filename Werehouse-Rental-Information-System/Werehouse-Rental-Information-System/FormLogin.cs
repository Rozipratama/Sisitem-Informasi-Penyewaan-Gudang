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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        
        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (textusername.Text.Trim() == "" || textpassword.Text.Trim() == "")
            {
                MessageBox.Show("Username dan Password harus diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            string conString = "server=localhost;port=3306;database=db_penyewaan_gudang;uid=root;password=;SslMode=None;";
            string query = "SELECT username, role FROM user WHERE username = @user AND password = @pass LIMIT 1";

            using (MySqlConnection con = new MySqlConnection(conString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@user", textusername.Text.Trim());
                    cmd.Parameters.AddWithValue("@pass", textpassword.Text.Trim());

                    try
                    {
                        con.Open();

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string namaUser = reader["username"].ToString();
                                string roleUser = reader["role"].ToString();

                                MessageBox.Show($"Login Berhasil!\nSelamat datang, {namaUser}\nRole: {roleUser}",
                                    "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
                                FormMenu menu = new FormMenu(namaUser, roleUser);
                                this.Hide();
                                menu.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Username atau Password salah!", "Login Gagal",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textpassword.Clear();
                                textusername.Focus();
                            }
                        }
                    }
                    catch (MySqlException mysqlEx)
                    {
                        MessageBox.Show($"Error Database: {mysqlEx.Message}\nError Code: {mysqlEx.Number}",
                            "Error Koneksi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error Sistem",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
        private void FormLogin_Load(object sender, EventArgs e)
        {
            textpassword.PasswordChar = '*';
            chkShowPassword.Checked = false;
        }
        
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                textpassword.PasswordChar = '\0'; 
            }
            else
            {
                textpassword.PasswordChar = '*'; 
            }
        }
    }
}
