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
    public partial class ProhlizecDatabaze : Form
    {
        public ProhlizecDatabaze()
        {
            InitializeComponent();
        }
        BindingList<Kniha> knihaDisplayList = new BindingList<Kniha>();
        BindingList<Zakaznik> zakaznikDisplayList = new BindingList<Zakaznik>();
        BindingList<Autor> autorDisplayList = new BindingList<Autor>();
        BindingList<Zanr> zanrDisplayList = new BindingList<Zanr>();
        
        private void button1_Click(object sender, EventArgs e)
        {
            zakaznikDisplayList = SQLClass.ListZakaznik();
            dataGridView1.DataSource = new BindingSource().DataSource = zakaznikDisplayList;
            if (dataGridView1.Columns.Contains("jmeno"))
            {
                dataGridView1.Columns["jmeno"].HeaderText = "Jméno";
            }
            if (dataGridView1.Columns.Contains("prijmeni"))
            {
                dataGridView1.Columns["prijmeni"].HeaderText = "Příjmení";
            }
            if (dataGridView1.Columns.Contains("ZakaznikID"))
            {
                dataGridView1.Columns["ZakaznikID"].HeaderText = "IdČlena";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            knihaDisplayList = SQLClass.FindKniha(-1, "", -1, -1, -1);
            dataGridView1.DataSource = new BindingSource().DataSource = knihaDisplayList;
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

        private void button3_Click(object sender, EventArgs e)
        {
            autorDisplayList = SQLClass.ListAutor();
            dataGridView1.DataSource = new BindingSource().DataSource = autorDisplayList;
            if (dataGridView1.Columns.Contains("jmeno"))
            {
                dataGridView1.Columns["jmeno"].HeaderText = "Jméno";
            }
            if (dataGridView1.Columns.Contains("prijmeni"))
            {
                dataGridView1.Columns["prijmeni"].HeaderText = "Příjmení";
            }
            if (dataGridView1.Columns.Contains("AutorID"))
            {
                dataGridView1.Columns["AutorID"].HeaderText = "IdAutora";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            zanrDisplayList = SQLClass.ListZanr();
            dataGridView1.DataSource = new BindingSource().DataSource = zanrDisplayList;
            if (dataGridView1.Columns.Contains("nazev"))
            {
                dataGridView1.Columns["nazev"].HeaderText = "Název";
            }
            if (dataGridView1.Columns.Contains("ZanrID"))
            {
                dataGridView1.Columns["ZanrID"].HeaderText = "IdŽánru";
            }
        }
    }
}
