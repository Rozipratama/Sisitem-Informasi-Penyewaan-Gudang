using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;

namespace Werehouse_Rental_Information_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }
    }
    public class Koneksi
    {
        private static string connStr = "server=localhost;user=root;password=;database=penyewahan_gudang;";
        public static MySqlConnection conn = new MySqlConnection(connStr);

        public static void Open()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public static void Close()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }

    public class DBHelper
    {
        public static DataTable GetData(string query, params MySqlParameter[] parameters)
        {
            DataTable dt = new DataTable();

            try
            {
                Koneksi.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, Koneksi.conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Koneksi.Close();
            }

            return dt;
        }

        public static void PrintDataTable(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                Debug.WriteLine("Data kosong");
                return;
            }

            int[] colWidths = new int[dt.Columns.Count];

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                colWidths[i] = dt.Columns[i].ColumnName.Length;

                foreach (DataRow row in dt.Rows)
                {
                    int len = row[i].ToString().Length;
                    if (len > colWidths[i])
                        colWidths[i] = len;
                }
            }

            Debug.WriteLine("\n");

            string header = "| ";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                header += dt.Columns[i].ColumnName.PadRight(colWidths[i]) + " | ";
            }
            Debug.WriteLine(header);

            Debug.WriteLine(new string('-', header.Length));

            foreach (DataRow row in dt.Rows)
            {
                string line = "| ";
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    line += row[i].ToString().PadRight(colWidths[i]) + " | ";
                }
                Debug.WriteLine(line);
            }
        }

        public static int Execute(string query, MySqlParameter[] parameters = null)
        {
            int result = 0;

            try
            {
                Koneksi.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, Koneksi.conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Koneksi.Close();
            }

            return result;
        }

        public static void RunAndPrintQuery(string query)
        {
            string q = query.Trim().ToLower();

            if (q.StartsWith("select") || q.StartsWith("desc") || q.StartsWith("show"))
            {
                DataTable dt = GetData(query);
                PrintDataTable(dt);
            }
            else
            {
                int result = Execute(query);
                Debug.WriteLine("\nQuery berhasil, affected rows: " + result);
            }
        }
    }
}
