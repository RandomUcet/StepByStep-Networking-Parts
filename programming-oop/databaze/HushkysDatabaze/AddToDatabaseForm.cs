using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HushkysDatabaze
{
    public partial class AddToDatabaseForm : Form
    {
        public AddToDatabaseForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                REPOZITORY.AddToTableObchod(textBox1, textBox2, textBox3, textBox4);
            } else if (radioButton2.Checked == true)
            {
                REPOZITORY.AddToTableLokace(textBox1, textBox2);
            } else { MessageBox.Show("Vyber alespon jednu moznost!"); }
        }

        private void AddToDatabaseForm_Load(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Název obchodu";
            label2.Text = "Počet zaměstnanců";
            label3.Text = "Rok založení";
            label4.Text = "Lokace ID";
            textBox1.Show();
            textBox2.Show();
            textBox3.Show();
            textBox4.Show();
            label3.Show();
            label4.Show();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Název lokace";
            label2.Text = "Počet stromů v lokaci";
            textBox1.Show();
            textBox2.Show();
            textBox3.Hide();
            textBox4.Hide();
            label3.Hide();
            label4.Hide();
        }
    }
}
