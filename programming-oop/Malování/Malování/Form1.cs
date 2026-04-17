namespace Malování
{
    public partial class Form1 : Form
    {
        Graphics grafika;
        bool pohybKursoru = false;
        Pen pero;
        int poziceX;
        int poziceY;
        public Form1()
        {
            InitializeComponent();
            grafika = pozadi.CreateGraphics();
            pero = new Pen(Color.Black, 5); //cislo pet urcuje sirku pera 
        }

        private void cerna_Click(object sender, EventArgs e)
        {
            PictureBox barva = (PictureBox)sender;
            pero.Color = barva.BackColor;
        }

        private void pozadi_MouseDown(object sender, MouseEventArgs e)
        {
            pohybKursoru = true;
            poziceX = e.X;
            poziceY = e.Y;
        }

        private void pozadi_MouseUp(object sender, MouseEventArgs e)
        {
            pohybKursoru = false;
            poziceX = 0;
            poziceY = 0;

        }

        private void pozadi_MouseMove(object sender, MouseEventArgs e)
        {
            if (pohybKursoru == true)
            {
                grafika.DrawLine(pero, new Point(poziceX, poziceY), e.Location);
                poziceX = e.X;
                poziceY = e.Y;
            }
        }
    }
}