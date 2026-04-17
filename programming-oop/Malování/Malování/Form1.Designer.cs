namespace Malování
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pozadi = new Panel();
            cervena = new PictureBox();
            cerna = new PictureBox();
            pozadi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cervena).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cerna).BeginInit();
            SuspendLayout();
            // 
            // pozadi
            // 
            pozadi.Controls.Add(cervena);
            pozadi.Controls.Add(cerna);
            pozadi.Dock = DockStyle.Fill;
            pozadi.Location = new Point(0, 0);
            pozadi.Name = "pozadi";
            pozadi.Size = new Size(803, 450);
            pozadi.TabIndex = 0;
            pozadi.MouseDown += pozadi_MouseDown;
            pozadi.MouseMove += pozadi_MouseMove;
            pozadi.MouseUp += pozadi_MouseUp;
            // 
            // cervena
            // 
            cervena.BackColor = Color.Red;
            cervena.Location = new Point(658, 418);
            cervena.Name = "cervena";
            cervena.Size = new Size(142, 32);
            cervena.TabIndex = 1;
            cervena.TabStop = false;
            cervena.Click += cerna_Click;
            // 
            // cerna
            // 
            cerna.BackColor = Color.Black;
            cerna.Location = new Point(658, 379);
            cerna.Name = "cerna";
            cerna.Size = new Size(142, 33);
            cerna.TabIndex = 0;
            cerna.TabStop = false;
            cerna.Click += cerna_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pozadi);
            Name = "Form1";
            Text = "Form1";
            pozadi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cervena).EndInit();
            ((System.ComponentModel.ISupportInitialize)cerna).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pozadi;
        private PictureBox cervena;
        private PictureBox cerna;
    }
}