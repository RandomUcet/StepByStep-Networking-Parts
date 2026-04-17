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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            SQLClass SQLClass = new SQLClass();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PujceniForm pujceniForm = new PujceniForm();
            pujceniForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProhlizecDatabaze showTableForm = new ProhlizecDatabaze();
            showTableForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NovaHodnota addNewForm = new NovaHodnota();
            addNewForm.Show();
        }
    }
}
