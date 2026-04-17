using System;
using System.Collections.Generic;
using System.Data;

using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HushkysDatabaze
{
    internal class REPOZITORY
    {
        
        public static object ReadFromTableObchod()
        {
            DataGridView dataGridView = new DataGridView();
            string query = "SELECT * FROM obchod";
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=databaze.db"))
            {
                conn.Open();
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView.DataSource = dt;
                }
            }
                return dataGridView.DataSource;
        }
        public static object ReadFromTableLokace()
        {
            DataGridView dataGridView = new DataGridView();
            string query = "SELECT * FROM lokace";
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=databaze.db"))
            {
                conn.Open();
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView.DataSource = dt;
                }
            }
            return dataGridView.DataSource;
        }

        public static void AddToTableObchod(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4)
        {
            Form1 form = new Form1();
            DataGridView dataGridView = form.dataGridView10;
            string query1 = "SELECT * FROM obchod";
            string query = "INSERT INTO obchod (nazev_obchodu, pocet_zamestnancu, rok_zalozeni, lokace_id) " + "VALUES (@nazev_obchodu, @pocet_zamestnancu, @rok_zalozeni, @lokace_id)"; ;
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=databaze.db"))
            {
                conn.Open();
                try
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nazev_obchodu", textBox1);
                        cmd.Parameters.AddWithValue("@pocet_zamestnancu", textBox2);
                        cmd.Parameters.AddWithValue("@rok_zalozeni", textBox3);
                        cmd.Parameters.AddWithValue("@lokace_id", textBox4);
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("nice");
                        }
                        using (SQLiteDataAdapter da = new SQLiteDataAdapter(query1, conn))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            form.dataGridView10.DataSource = dt;
                            
                        }
                    } conn.Close();
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        public static void AddToTableLokace(TextBox textBox1, TextBox textBox2)
        {
            DataGridView dataGridView = new DataGridView();

            string query = "INSERT INTO lokace (nazev_lokace, pocet_stromu_v_lokaci) " + "VALUES (@nazev_lokace, @pocet_stromu_v_lokaci)"; ;
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=databaze.db"))
            {
                conn.Open();
                try
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nazev_lokace", textBox1);
                        cmd.Parameters.AddWithValue("@pocet_stromu_v_lokaci", textBox2);
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("nice");
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}
