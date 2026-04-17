using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace knihovna
{
    public partial class PujceniForm : Form
    {
        public PujceniForm()
        {
            InitializeComponent();
        }
        BindingList<Kniha> bb = new BindingList<Kniha>();
        BindingList<Kniha> ee = new BindingList<Kniha>();
        private void button1_Click(object sender, EventArgs e)
        {
            string[] exit = SQLClass.FindZakaznik(textBox4.Text, textBox3.Text, textBox5.Text);
            button1.Text = "Vyhledáno";
            textBox4.Text = exit[0];
            textBox3.Text = exit[1];
            textBox5.Text = exit[2];
            bb = SQLClass.FindKniha(-1,"", -1, -1, Convert.ToInt32(exit[2]));
            dataGridView2.DataSource = new BindingSource().DataSource = bb;
            if (dataGridView2.Columns.Contains("nazev"))
            {
                dataGridView2.Columns["nazev"].HeaderText = "Název";
            }
            if (dataGridView2.Columns.Contains("ZanrID"))
            {
                dataGridView2.Columns["ZanrID"].HeaderText = "IdŽánru";
            }
            if (dataGridView2.Columns.Contains("AutorID"))
            {
                dataGridView2.Columns["AutorID"].HeaderText = "IdAutora";
            }
            if (dataGridView2.Columns.Contains("ZakaznikID"))
            {
                dataGridView2.Columns["ZakaznikID"].HeaderText = "IdČlena";
            }
            if (dataGridView2.Columns.Contains("KnihaID"))
            {
                dataGridView2.Columns["KnihaID"].HeaderText = "IdKnihy";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dataGridView2.CurrentCell.RowIndex.ToString());
            SQLClass.KnihaZakaznikEdit(bb[(dataGridView2.CurrentCell.RowIndex)].KnihaID, -1);
            bb.RemoveAt(dataGridView2.CurrentCell.RowIndex);
            button2.Text = "Vráceno";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int AutorID = -1;
            int ZanrID = -1;
            AutorID = SQLClass.FindAutorByName(textBox6.Text);
            
            if (textBox7.Text.Length >2)
            {
                ZanrID = SQLClass.FindZanrByName(textBox7.Text);
            }

            int KnihaID = -1;
            if (textBox1.Text.Length>0)
            {
                KnihaID = Convert.ToInt32(textBox1.Text);
            }
            ee = SQLClass.FindKniha(KnihaID, textBox2.Text, AutorID, ZanrID, -2);
            dataGridView1.DataSource = new BindingSource().DataSource = ee;
            if (dataGridView1.Columns.Contains("nazev"))
            {
                dataGridView1.Columns["nazev"].HeaderText = "Název";
            }
            if (dataGridView1.Columns.Contains("ZanrID"))
            {
                dataGridView1.Columns["ZanrID"].HeaderText = "IdŽánru";
            }
            if (dataGridView1.Columns.Contains("AutorID"))
            {
                dataGridView1.Columns["AutorID"].HeaderText = "IdAutora";
            }
            if (dataGridView1.Columns.Contains("ZakaznikID"))
            {
                dataGridView1.Columns["ZakaznikID"].HeaderText = "IdČlena";
            }
            if (dataGridView1.Columns.Contains("KnihaID"))
            {
                dataGridView1.Columns["KnihaID"].HeaderText = "IdKnihy";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SQLClass.KnihaZakaznikEdit(ee[(dataGridView1.CurrentCell.RowIndex)].KnihaID, Convert.ToInt32(textBox5.Text));
            button4.Text = "Půjčeno";
        }
    }
}
