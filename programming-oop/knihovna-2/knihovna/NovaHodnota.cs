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
    public partial class NovaHodnota : Form
    {
        public NovaHodnota()
        {
            InitializeComponent();
            BindingList<Autor> autorList= SQLClass.ListAutor();
            foreach (Autor autor in autorList)
            {
                comboBox2.Items.Add(autor.jmeno + " " + autor.prijmeni);
            }
            BindingList<Zanr> zanrList = SQLClass.ListZanr();
            foreach (Zanr zanr in zanrList)
            {
                comboBox1.Items.Add(zanr.nazev);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLClass.NewKniha(textBox1.Text, comboBox1.SelectedIndex+1, comboBox2.SelectedIndex+1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLClass.NewAutor(textBox2.Text, textBox3.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLClass.NewZakaznik(textBox5.Text, textBox4.Text);
        }
    }
}