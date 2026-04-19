# Vytvoření editoru obrázků v C# - Kompletní tutoriál

>  **Tip pro Programování:** I když píšete cvičné projekty, zvykněte si názvy proměnných, tříd a metod psát v angličtině. Budete pak mít podstatně jednodušší orientaci v kódu, až budete řešit chyby přes zahraniční IT diskuze a návody.


Podrobný návod na vytvoření aplikace pro úpravu obrázků ve Visual Studio s využitím Windows Forms a knihovny System.Drawing.

---

## Obsah

1. [Úvod a přehled projektu](#úvod-a-přehled-projektu)
2. [Vytvoření projektu](#vytvoření-projektu)
3. [Třída BitovaMapa](#třída-bitovamapa)
4. [Hlavní formulář (Form1)](#hlavní-formulář-form1)
5. [Obrazové filtry](#obrazové-filtry)
6. [Třídění pixelů](#třídění-pixelů)
7. [Výřez obrázku](#výřez-obrázku)
8. [Zvětšení obrázku](#zvětšení-obrázku)
9. [ASCII Art generátor](#ascii-art-generátor)
10. [Mapa barev](#mapa-barev)
11. [Barevná matice](#barevná-matice)
12. [Puzzle hra](#puzzle-hra)
13. [Užitečné odkazy](#užitečné-odkazy)

---

## Úvod a přehled projektu

Tento tutoriál vás provede vytvořením kompletního editoru obrázků s následujícími funkcemi:

- Načítání a zobrazení obrázků
- Filtry: černobílý, odstíny šedi, reliéf, omalovánka
- Prolínání dvou obrázků
- Třídění pixelů podle světlosti
- Výřez části obrázku
- Zvětšení s interpolací
- Převod na ASCII art
- Interaktivní změna barev
- Puzzle hra

### Použité technologie

- **Visual Studio Community 2022** (nebo novější)
- **C# / .NET Framework 4.7.2+**
- **Windows Forms**
- **System.Drawing**

---

## Vytvoření projektu

### Krok 1: Nový projekt

1. Otevřete **Visual Studio**
2. Vyberte **Create a new project**
3. Zvolte **Windows Forms App (.NET Framework)**
4. Pojmenujte projekt `PhotoEditor`
5. Vyberte .NET Framework 4.7.2 nebo vyšší

### Krok 2: Struktura projektu

Vytvořte následující soubory:

```
PhotoEditor/
├── Program.cs
├── BitovaMapa.cs
├── Form1.cs (hlavní formulář)
├── Form2.cs (třídění pixelů)
├── Form3.cs (výřez)
├── Form4.cs (zvětšení - výběr)
├── Form5.cs (zvětšení - zobrazení)
├── Form6.cs (ASCII art)
├── ColorMap.cs (mapa barev)
├── ColorPanelForm.cs (panel barev)
├── matrix.cs (barevná matice)
└── hra.cs (puzzle)
```

---

## Třída BitovaMapa

Základní třída pro práci s bitmapovými obrázky.

### Definice třídy

```csharp
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhotoEditor
{
    internal class BitovaMapa
    {
        // Vlastnosti pro cestu a bitmapu
        public string CestaKBitmape { get; set; }
        public Bitmap Bitmapa { get; set; }

        // Konstanty pro výpočet světelnosti (standardní koeficienty)
        private const double svetlostR = 0.299;
        private const double svetlostG = 0.587;
        private const double svetlostB = 0.114;

        // Konstruktor s cestou k souboru
        public BitovaMapa(string cesta)
        {
            this.CestaKBitmape = cesta;
            this.Bitmapa = new Bitmap(cesta);
        }

        // Prázdný konstruktor
        public BitovaMapa()
        {
        }

        // Zobrazení bitmapy na formuláři
        public void zobrazitBitovouMapu(Point point, Form activeForm)
        {
            Graphics gr = activeForm.CreateGraphics();
            gr.DrawImage(this.Bitmapa, point.X, point.Y, 
                        activeForm.Width, activeForm.Height);
            gr.Dispose();
        }

        // Výpočet světelnosti pixelu
        public int svetelnost(Color pixel)
        {
            return Convert.ToInt32(
                svetlostR * pixel.R + 
                svetlostG * pixel.G + 
                svetlostB * pixel.B
            );
        }

        // Získání barvy pixelu na pozici
        public Color GetPixelColorAt(Point pozice)
        {
            if (Bitmapa != null && 
                pozice.X >= 0 && pozice.X < Bitmapa.Width && 
                pozice.Y >= 0 && pozice.Y < Bitmapa.Height)
            {
                return Bitmapa.GetPixel(pozice.X, pozice.Y);
            }
            return Color.Black;
        }
    }
}
```

### Vysvětlení kódu

| Komponenta | Popis |
|------------|-------|
| `svetlostR/G/B` | Standardní koeficienty pro výpočet vnímané světlosti (ITU-R BT.601) |
| `zobrazitBitovouMapu` | Vykreslí bitmapu na formulář pomocí GDI+ |
| `svetelnost` | Vrací hodnotu 0-255 reprezentující jas pixelu |

---

## Hlavní formulář (Form1)

### Návrh formuláře

1. Přidejte **MenuStrip** s následující strukturou:

```
Soubor
├── Otevřít
└── Zobrazit foto
Filtry
├── Černobílý
├── Pět odstínů šedi
├── Šedý
├── Reliéf
├── Omalovánka
└── Převod do jedné barvy
Nástroje
├── Prolnutí
├── Třídění
├── Výřez
├── Zvětšení
├── ASCII Art
├── Mapa barev
├── Barevná matice
└── Hra (Puzzle)
Barvy
├── Vybrat barvu
└── Barva do listu
```

### Inicializace

```csharp
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhotoEditor
{
    public partial class Form1 : Form
    {
        private BitovaMapa btm;
        private Color vybranaBarva = Color.Black;
        private bool jeKresleniAktivni = false;

        public Form1()
        {
            btm = new BitovaMapa();
            InitializeComponent();
        }
    }
}
```

### Otevření obrázku

```csharp
private void otevritToolStripMenuItem_Click(object sender, EventArgs e)
{
    string cesta;
    OpenFileDialog ofd = new OpenFileDialog();
    ofd.Title = "Otevřít obrázek";
    ofd.Filter = "Obrázky (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
    
    if (ofd.ShowDialog() == DialogResult.OK)
    {
        cesta = ofd.FileName;
        btm = new BitovaMapa(cesta);
        
        // Přizpůsobení velikosti okna
        this.Width = btm.Bitmapa.Width + 200;
        this.Height = btm.Bitmapa.Height + 60;
        
        // Zobrazení obrázku
        btm.zobrazitBitovouMapu(new Point(0, 0), this);
    }
}
```

---

## Obrazové filtry

### Černobílý filtr

Převede obrázek na čistě černobílý (bez odstínů šedi).

```csharp
private void cernobilyToolStripMenuItem_Click(object sender, EventArgs e)
{
    Bitmap original = btm.Bitmapa;
    Bitmap vysledek = new Bitmap(original.Width, original.Height);
    
    for (int i = 0; i < original.Width; i++)
    {
        for (int j = 0; j < original.Height; j++)
        {
            Color pixel = original.GetPixel(i, j);
            int svetelnost = btm.svetelnost(pixel);
            
            // Prahování na 50%
            if (svetelnost > 127)
                vysledek.SetPixel(i, j, Color.White);
            else
                vysledek.SetPixel(i, j, Color.Black);
        }
    }
    
    btm.Bitmapa = vysledek;
    btm.zobrazitBitovouMapu(new Point(0, 0), this);
}
```

### Odstíny šedi

Převede obrázek do stupňů šedi s využitím váženého průměru.

```csharp
private void sedyToolStripMenuItem_Click(object sender, EventArgs e)
{
    OpenFileDialog ofd = new OpenFileDialog();
    ofd.Filter = "Obrázky (*.jpg;*.jpeg)|*.jpg;*.jpeg";

    if (ofd.ShowDialog() == DialogResult.OK)
    {
        BitovaMapa btm = new BitovaMapa(ofd.FileName);
        Bitmap obrSedy = new Bitmap(btm.Bitmapa.Width, btm.Bitmapa.Height);

        for (int i = 0; i < btm.Bitmapa.Width; i++)
        {
            for (int j = 0; j < btm.Bitmapa.Height; j++)
            {
                Color pixel = btm.Bitmapa.GetPixel(i, j);
                
                // Vážený průměr (lidské oko je citlivější na zelenou)
                int prumer = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
                
                Color novaBarva = Color.FromArgb(prumer, prumer, prumer);
                obrSedy.SetPixel(i, j, novaBarva);
            }
        }

        // Zobrazení v novém okně
        Form frSedy = new Form();
        frSedy.Text = "Šedý obrázek";
        frSedy.Size = new Size(btm.Bitmapa.Width, btm.Bitmapa.Height);

        PictureBox pictureBox = new PictureBox();
        pictureBox.Dock = DockStyle.Fill;
        pictureBox.Image = obrSedy;

        frSedy.Controls.Add(pictureBox);
        frSedy.Show();
    }
}
```

### Reliéf

Vytvoří efekt reliéfu porovnáváním sousedních pixelů.

```csharp
private void reliefToolStripMenuItem_Click(object sender, EventArgs e)
{
    Bitmap original = new Bitmap(btm.Bitmapa);
    Bitmap reliefImage = new Bitmap(original.Width, original.Height);

    for (int x = 0; x < original.Width; x++)
    {
        for (int y = 0; y < original.Height; y++)
        {
            Color currentColor = original.GetPixel(x, y);
            Color surroundingColor;

            // Získání sousedního pixelu (vlevo nahoře)
            if (x > 0 && y > 0)
                surroundingColor = original.GetPixel(x - 1, y - 1);
            else
                surroundingColor = currentColor;

            // Výpočet rozdílu světelnosti
            int intensityDiff = Math.Abs(
                Svetelnost(currentColor) - Svetelnost(surroundingColor)
            );
            
            // Omezení na rozsah 0-255
            intensityDiff = Math.Min(255, Math.Max(0, intensityDiff));
            int newColorValue = 255 - intensityDiff;

            Color newColor = Color.FromArgb(newColorValue, newColorValue, newColorValue);
            reliefImage.SetPixel(x, y, newColor);
        }
    }
    
    btm.Bitmapa = reliefImage;
    btm.zobrazitBitovouMapu(new Point(0, 0), this);
}

private int Svetelnost(Color pixel)
{
    return (int)(0.3 * pixel.R + 0.59 * pixel.G + 0.11 * pixel.B);
}
```

### Omalovánka

Vytvoří obrys obrázku vhodný pro vybarvování.

```csharp
private Bitmap CreateOmalovanka(Bitmap originalImage)
{
    Bitmap omalovanka = new Bitmap(originalImage.Width, originalImage.Height);
    int threshold = 10; // Práh pro detekci hran

    for (int x = 1; x < originalImage.Width - 1; x++)
    {
        for (int y = 1; y < originalImage.Height - 1; y++)
        {
            Color pixel = originalImage.GetPixel(x, y);
            Color surroundingColor = originalImage.GetPixel(x - 1, y);

            int intensityDiff = Math.Abs(
                Svetelnost(pixel) - Svetelnost(surroundingColor)
            );
            intensityDiff = Math.Min(255, Math.Max(0, intensityDiff));

            Color newColor;
            
            if (intensityDiff > threshold)
            {
                // Obrys - černá
                newColor = Color.Black;
            }
            else
            {
                // Výplň - zesvětlená původní barva
                int lighteningFactor = 140;
                int red = Math.Min(255, pixel.R + lighteningFactor);
                int green = Math.Min(255, pixel.G + lighteningFactor);
                int blue = Math.Min(255, pixel.B + lighteningFactor);
                newColor = Color.FromArgb(red, green, blue);
            }

            omalovanka.SetPixel(x, y, newColor);
        }
    }

    return omalovanka;
}
```

### Prolnutí dvou obrázků

Kombinuje dva obrázky prokládáním pixelů.

```csharp
private void prolnutiToolStripMenuItem_Click(object sender, EventArgs e)
{
    OpenFileDialog ofd = new OpenFileDialog();
    ofd.Filter = "Obrázky (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

    // Výběr prvního obrázku
    if (ofd.ShowDialog() != DialogResult.OK) return;
    BitovaMapa btm1 = new BitovaMapa(ofd.FileName);

    // Výběr druhého obrázku
    if (ofd.ShowDialog() != DialogResult.OK) return;
    BitovaMapa btm2 = new BitovaMapa(ofd.FileName);

    // Výpočet rozměrů výsledku
    int sirkaVysledku = btm1.Bitmapa.Width + btm2.Bitmapa.Width;
    int vyskaVysledku = Math.Max(btm1.Bitmapa.Height, btm2.Bitmapa.Height);
    Bitmap vysledek = new Bitmap(sirkaVysledku, vyskaVysledku);

    // Prolnutí pixelů
    for (int i = 0; i < vysledek.Width; i++)
    {
        for (int j = 0; j < vysledek.Height; j++)
        {
            Color pixel;
            
            if (i % 2 == 0 && i < btm1.Bitmapa.Width)
            {
                // Sudé sloupce z prvního obrázku
                pixel = (j < btm1.Bitmapa.Height) 
                    ? btm1.Bitmapa.GetPixel(i, j) 
                    : Color.Black;
            }
            else if (i % 2 != 0 && i - 1 < btm2.Bitmapa.Width)
            {
                // Liché sloupce z druhého obrázku
                pixel = (j < btm2.Bitmapa.Height) 
                    ? btm2.Bitmapa.GetPixel(i - 1, j) 
                    : Color.Black;
            }
            else
            {
                pixel = Color.Black;
            }

            vysledek.SetPixel(i, j, pixel);
        }
    }

    // Zobrazení výsledku
    Form frProlnuti = new Form();
    frProlnuti.Text = "Prolnutí";
    frProlnuti.Size = new Size(sirkaVysledku, vyskaVysledku);

    PictureBox pictureBox = new PictureBox();
    pictureBox.Dock = DockStyle.Fill;
    pictureBox.Image = vysledek;

    frProlnuti.Controls.Add(pictureBox);
    frProlnuti.Show();
}
```

---

## Třídění pixelů

Vizualizace Bubble Sort algoritmu na pixelech obrázku.

### Form2.cs - Třídění

```csharp
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEditor
{
    public partial class Form2 : Form
    {
        Button button;
        Bitmap bitmap;
        bool sortingInProgress = false;

        public Form2(Bitmap loadedBitmap)
        {
            InitializeComponent();
            bitmap = loadedBitmap;
            InitializeButton();
        }

        private void InitializeButton()
        {
            button = new Button();
            button.Width = 100;
            button.Height = 30;
            button.Text = "Spustit třídění";
            button.Location = new Point(20, 20);
            button.Click += async (sender, e) => await SortBitmapAsync();
            Controls.Add(button);
        }

        private async Task SortBitmapAsync()
        {
            if (sortingInProgress) return;

            sortingInProgress = true;
            await Task.Run(() => SortBitmapWithVisualization(bitmap.Clone() as Bitmap));
            sortingInProgress = false;
        }

        private async Task SortBitmapWithVisualization(Bitmap bitmapToSort)
        {
            int width = bitmapToSort.Width;
            int height = bitmapToSort.Height;

            // Přímý přístup k pixelům pro rychlost
            BitmapData bitmapData = bitmapToSort.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite,
                bitmapToSort.PixelFormat
            );
            
            IntPtr ptr = bitmapData.Scan0;
            int bytes = Math.Abs(bitmapData.Stride) * height;
            byte[] rgbValues = new byte[bytes];
            Marshal.Copy(ptr, rgbValues, 0, bytes);

            bool swapped = true;
            while (swapped)
            {
                swapped = false;
                
                // Třídění pixelů svisle
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height - 1; y++)
                    {
                        int currentIndex = (y * bitmapData.Stride) + (x * 4);
                        int nextIndex = ((y + 1) * bitmapData.Stride) + (x * 4);

                        if (currentIndex < rgbValues.Length && nextIndex < rgbValues.Length)
                        {
                            Color currentPixel = Color.FromArgb(
                                rgbValues[currentIndex + 3],
                                rgbValues[currentIndex + 2],
                                rgbValues[currentIndex + 1],
                                rgbValues[currentIndex]
                            );
                            Color nextPixel = Color.FromArgb(
                                rgbValues[nextIndex + 3],
                                rgbValues[nextIndex + 2],
                                rgbValues[nextIndex + 1],
                                rgbValues[nextIndex]
                            );

                            if (IsDarker(currentPixel, nextPixel))
                            {
                                SwapPixels(rgbValues, currentIndex, nextIndex);
                                swapped = true;
                            }
                        }
                    }
                }

                // Aktualizace zobrazení
                Marshal.Copy(rgbValues, 0, ptr, bytes);
                bitmapToSort.UnlockBits(bitmapData);
                RefreshBitmap(bitmapToSort);
                
                bitmapData = bitmapToSort.LockBits(
                    new Rectangle(0, 0, width, height),
                    ImageLockMode.ReadWrite,
                    bitmapToSort.PixelFormat
                );
                ptr = bitmapData.Scan0;
                await Task.Delay(1); // Vizualizace
            }

            Marshal.Copy(rgbValues, 0, ptr, bytes);
            bitmapToSort.UnlockBits(bitmapData);
            RefreshBitmap(bitmapToSort);
        }

        private bool IsDarker(Color color1, Color color2)
        {
            int avg1 = (color1.R + color1.G + color1.B) / 3;
            int avg2 = (color2.R + color2.G + color2.B) / 3;
            return avg1 < avg2;
        }

        private void SwapPixels(byte[] rgbValues, int index1, int index2)
        {
            for (int i = 0; i < 4; i++)
            {
                byte temp = rgbValues[index1 + i];
                rgbValues[index1 + i] = rgbValues[index2 + i];
                rgbValues[index2 + i] = temp;
            }
        }

        private void RefreshBitmap(Bitmap bitmapToRefresh)
        {
            if (InvokeRequired)
            {
                Invoke((Action)(() => {
                    bitmap = bitmapToRefresh;
                    Refresh();
                }));
            }
            else
            {
                bitmap = bitmapToRefresh;
                Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImage(bitmap, new Point(20, 60));
        }
    }
}
```

---

## Výřez obrázku

Umožňuje vybrat a uložit část obrázku.

### Form3.cs - Výřez

```csharp
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhotoEditor
{
    public partial class Form3 : Form
    {
        private Bitmap btm;
        private Point startPoint;
        private Rectangle selectionRectangle;
        private bool isSelecting = false;

        public Form3()
        {
            InitializeComponent();
            this.MouseDown += Form3_MouseDown;
            this.MouseMove += Form3_MouseMove;
            this.Paint += Form3_Paint;
        }

        private void VyrezObrazek()
        {
            if (selectionRectangle.IsEmpty || btm == null)
            {
                MessageBox.Show("Vyberte oblast pro výřez.");
                return;
            }

            Bitmap vyrez = new Bitmap(selectionRectangle.Width, selectionRectangle.Height);

            using (Graphics g = Graphics.FromImage(vyrez))
            {
                g.DrawImage(btm, 
                    new Rectangle(0, 0, vyrez.Width, vyrez.Height),
                    selectionRectangle, 
                    GraphicsUnit.Pixel);
            }

            // Zobrazení výřezu v novém okně
            Form vyrezForm = new Form();
            vyrezForm.Text = "Výřez obrázku";
            vyrezForm.Size = new Size(vyrez.Width + 40, vyrez.Height + 40);
            
            PictureBox pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Image = vyrez;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Click += (s, e) => UlozitVyrez(vyrez);

            vyrezForm.Controls.Add(pictureBox);
            vyrezForm.ShowDialog();
        }

        private void UlozitVyrez(Bitmap vyrez)
        {
            using (SaveFileDialog save = new SaveFileDialog())
            {
                save.Filter = "PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    vyrez.Save(save.FileName);
                    MessageBox.Show("Obrázek uložen.", "Úspěch", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            if (isSelecting)
            {
                startPoint = e.Location;
            }
        }

        private void Form3_MouseMove(object sender, MouseEventArgs e)
        {
            if (isSelecting && e.Button == MouseButtons.Left)
            {
                int x = Math.Min(startPoint.X, e.X);
                int y = Math.Min(startPoint.Y, e.Y);
                int width = Math.Abs(startPoint.X - e.X);
                int height = Math.Abs(startPoint.Y - e.Y);
                
                selectionRectangle = new Rectangle(x, y, width, height);
                this.Refresh();
            }
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            if (!selectionRectangle.IsEmpty)
            {
                e.Graphics.DrawRectangle(Pens.Red, selectionRectangle);
            }
        }

        private void obrazekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Obrázky|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    btm = new Bitmap(ofd.FileName);
                    this.BackgroundImage = btm;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    this.ClientSize = new Size(btm.Width, btm.Height);
                }
            }
        }

        private void vyberMistoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isSelecting = true;
        }

        private void ukazatVyrezToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VyrezObrazek();
        }
    }
}
```

---

## Zvětšení obrázku

### Form4.cs - Výběr obrázku

```csharp
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhotoEditor
{
    public partial class Form4 : Form
    {
        private Bitmap selectedBitmap;

        public Form4()
        {
            InitializeComponent();
        }

        private void zvetseniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedBitmap != null)
            {
                Bitmap enlargedBitmap = EnlargeBitmap(selectedBitmap, 4);
                Form5 enlargedForm = new Form5(enlargedBitmap);
                enlargedForm.Show();
            }
            else
            {
                MessageBox.Show("Není načten žádný obrázek.", "Chyba", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Bitmap EnlargeBitmap(Bitmap originalBitmap, int scaleFactor)
        {
            int newWidth = originalBitmap.Width * scaleFactor;
            int newHeight = originalBitmap.Height * scaleFactor;
            Bitmap enlargedBitmap = new Bitmap(newWidth, newHeight);
            
            using (Graphics g = Graphics.FromImage(enlargedBitmap))
            {
                // Nearest Neighbor pro pixelový efekt
                g.InterpolationMode = System.Drawing.Drawing2D
                    .InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = System.Drawing.Drawing2D
                    .PixelOffsetMode.Half;
                g.DrawImage(originalBitmap, 0, 0, newWidth, newHeight);
            }
            
            return enlargedBitmap;
        }

        private void zobrazitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Obrázky|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedBitmap = new Bitmap(ofd.FileName);
                this.ClientSize = new Size(selectedBitmap.Width, selectedBitmap.Height);
                this.BackgroundImage = selectedBitmap;
            }
        }
    }
}
```

### Form5.cs - Zobrazení zvětšeného

```csharp
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhotoEditor
{
    public partial class Form5 : Form
    {
        private Bitmap image;

        public Form5(Bitmap image)
        {
            InitializeComponent();
            this.image = image;
            this.ClientSize = image.Size;
            this.BackgroundImage = image;
        }
    }
}
```

---

## ASCII Art generátor

Převádí obrázek na textovou reprezentaci.

### Form6.cs

```csharp
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PhotoEditor
{
    public partial class Form6 : Form
    {
        private Bitmap bitmap;

        public Form6()
        {
            InitializeComponent();
        }

        private void aSCIIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap == null)
            {
                MessageBox.Show("Nejprve načtěte obrázek.");
                return;
            }

            // Znaky seřazené od nejtmavšího po nejsvětlejší
            char[] asciiChars = { '@', '#', '8', '&', 'o', ':', '*', '.', ' ' };

            StringBuilder asciiArt = new StringBuilder();
            float ratio = (float)bitmap.Width / bitmap.Height;

            // Výpočet velikosti fontu
            int fontSize = (int)Math.Min(
                richTextBox1.Width / ratio / bitmap.Width,
                richTextBox1.Height / bitmap.Height
            );

            for (int y = 0; y < bitmap.Height; y += fontSize)
            {
                for (int x = 0; x < bitmap.Width; x += fontSize)
                {
                    // Průměrná barva bloku
                    Color avgColor = GetAverageColor(bitmap, x, y,
                        Math.Min(fontSize, bitmap.Width - x),
                        Math.Min(fontSize, bitmap.Height - y));

                    // Index znaku podle jasu
                    int brightness = (int)(avgColor.GetBrightness() * 
                        (asciiChars.Length - 1));
                    
                    // Přidání barevného znaku
                    richTextBox1.SelectionColor = avgColor;
                    asciiArt.Append(asciiChars[brightness]);
                    asciiArt.Append(asciiChars[brightness]); // Dvojité pro poměr
                }
                asciiArt.AppendLine();
            }

            richTextBox1.Font = new Font("Lucida Console", fontSize);
            richTextBox1.Text = asciiArt.ToString();
        }

        private Color GetAverageColor(Bitmap bitmap, int startX, int startY, 
            int width, int height)
        {
            int totalR = 0, totalG = 0, totalB = 0, count = 0;

            for (int y = startY; y < startY + height; y++)
            {
                for (int x = startX; x < startX + width; x++)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    totalR += pixel.R;
                    totalG += pixel.G;
                    totalB += pixel.B;
                    count++;
                }
            }

            if (count == 0) return Color.Black;

            return Color.FromArgb(
                totalR / count,
                totalG / count,
                totalB / count
            );
        }

        private void zobrazitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    bitmap = new Bitmap(ofd.FileName);
                    pictureBox1.Image = bitmap;
                }
            }
        }
    }
}
```

---

## Mapa barev

Umožňuje interaktivně měnit barvy v obrázku.

### ColorMap.cs

```csharp
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhotoEditor
{
    public partial class ColorMap : Form
    {
        private Bitmap originalBitmap;
        private Bitmap workingBitmap;
        private int tolerance = 25; // Tolerance pro podobné odstíny

        public ColorMap()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (originalBitmap == null)
            {
                MessageBox.Show("Není načten žádný obrázek.", "Chyba");
                return;
            }

            // Barva kliknutého pixelu
            Color clickedColor = originalBitmap.GetPixel(e.X, e.Y);

            // Výběr nové barvy
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    Color selectedColor = colorDialog.Color;

                    // Nahrazení všech podobných barev
                    for (int x = 0; x < originalBitmap.Width; x++)
                    {
                        for (int y = 0; y < originalBitmap.Height; y++)
                        {
                            Color pixelColor = originalBitmap.GetPixel(x, y);
                            
                            if (IsSimilarColor(pixelColor, clickedColor))
                            {
                                workingBitmap.SetPixel(x, y, selectedColor);
                            }
                        }
                    }

                    pictureBox1.Image = workingBitmap;
                }
            }
        }

        private bool IsSimilarColor(Color color1, Color color2)
        {
            return Math.Abs(color1.R - color2.R) <= tolerance &&
                   Math.Abs(color1.G - color2.G) <= tolerance &&
                   Math.Abs(color1.B - color2.B) <= tolerance;
        }

        private void obrazekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Obrázky (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    originalBitmap = new Bitmap(ofd.FileName);
                    workingBitmap = new Bitmap(originalBitmap);
                    pictureBox1.Image = workingBitmap;
                }
            }
        }
    }
}
```

---

## Barevná matice

Aplikuje barevnou matici pro úpravu RGB kanálů.

### matrix.cs

```csharp
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace PhotoEditor
{
    public partial class matrix : Form
    {
        public Bitmap originalBitmap;
        public Bitmap workingBitmap;

        private float redIntensity = 1.0f;
        private float greenIntensity = 1.0f;
        private float blueIntensity = 1.0f;
        private float alphaIntensity = 1.0f;

        public matrix()
        {
            InitializeComponent();
        }

        private void ApplyColorMatrix(float red, float green, float blue)
        {
            // Definice barevné matice 5x5
            ColorMatrix matrix = new ColorMatrix(new float[][] {
                new float[] { red, 0, 0, 0, 0 },      // Červená
                new float[] { 0, green, 0, 0, 0 },    // Zelená
                new float[] { 0, 0, blue, 0, 0 },     // Modrá
                new float[] { 0, 0, 0, alphaIntensity, 0 }, // Alpha
                new float[] { 0, 0, 0, 0, 1 }         // Offset
            });

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(matrix);

            using (Graphics g = Graphics.FromImage(workingBitmap))
            {
                g.DrawImage(originalBitmap,
                    new Rectangle(0, 0, workingBitmap.Width, workingBitmap.Height),
                    0, 0, workingBitmap.Width, workingBitmap.Height,
                    GraphicsUnit.Pixel, attributes);
            }

            pictureBox1.Image = workingBitmap;
            pictureBox1.Refresh();
        }

        private void vScrollBarRed_Scroll(object sender, ScrollEventArgs e)
        {
            redIntensity = (float)vScrollBarRed.Value / 100.0f;
            ApplyColorMatrix(redIntensity, greenIntensity, blueIntensity);
        }

        private void vScrollBarGreen_Scroll(object sender, ScrollEventArgs e)
        {
            greenIntensity = (float)vScrollBarGreen.Value / 100.0f;
            ApplyColorMatrix(redIntensity, greenIntensity, blueIntensity);
        }

        private void vScrollBarBlue_Scroll(object sender, ScrollEventArgs e)
        {
            blueIntensity = (float)vScrollBarBlue.Value / 100.0f;
            ApplyColorMatrix(redIntensity, greenIntensity, blueIntensity);
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Obrázky (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    originalBitmap = new Bitmap(ofd.FileName);
                    workingBitmap = new Bitmap(originalBitmap);
                    pictureBox1.Image = workingBitmap;
                }
            }
        }
    }
}
```

---

## Puzzle hra

Interaktivní hra s přeskupováním dílků obrázku.

### hra.cs

```csharp
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhotoEditor
{
    public partial class hra : Form
    {
        private Bitmap originalImage;
        private PictureBox[,] puzzlePieces;
        private int pieceSize = 110;
        private int rows = 4;
        private int cols = 4;
        private PictureBox selectedPiece = null;

        public hra()
        {
            InitializeComponent();
            InitializeCustomMenu();
        }

        private void InitializeCustomMenu()
        {
            ToolStripMenuItem sizeMenu = new ToolStripMenuItem("Velikost pole");
            string[] sizes = { "4x4", "8x8", "16x16", "24x24" };
            
            foreach (string size in sizes)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(size);
                item.Click += SizeMenuItem_Click;
                sizeMenu.DropDownItems.Add(item);
            }
            
            menuStrip1.Items.Add(sizeMenu);
        }

        private void SizeMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            string[] parts = item.Text.Split('x');
            rows = int.Parse(parts[0]);
            cols = int.Parse(parts[1]);
            
            // Odstranění starých dílků
            if (puzzlePieces != null)
            {
                foreach (PictureBox piece in puzzlePieces)
                {
                    Controls.Remove(piece);
                    piece.Dispose();
                }
            }
            
            SplitImage();
            ShufflePieces();
        }

        private void PuzzlePiece_Click(object sender, EventArgs e)
        {
            PictureBox clickedPiece = (PictureBox)sender;
            
            if (selectedPiece == null)
            {
                // Výběr prvního dílku
                selectedPiece = clickedPiece;
                selectedPiece.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                // Prohození dílků
                SwapPieces(selectedPiece, clickedPiece);
                selectedPiece.BorderStyle = BorderStyle.None;
                selectedPiece = null;
                
                CheckCompletion();
            }
        }

        private void SwapPieces(PictureBox piece1, PictureBox piece2)
        {
            Point location1 = piece1.Location;
            object tag1 = piece1.Tag;
            
            piece1.Location = piece2.Location;
            piece1.Tag = piece2.Tag;
            
            piece2.Location = location1;
            piece2.Tag = tag1;
        }

        private void CheckCompletion()
        {
            int correctCount = 0;
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (puzzlePieces[i, j].Tag != null && 
                        (int)puzzlePieces[i, j].Tag == correctCount)
                    {
                        correctCount++;
                    }
                }
            }
            
            if (correctCount == rows * cols)
            {
                MessageBox.Show("Puzzle bylo úspěšně složeno!", "Gratulujeme",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SplitImage()
        {
            puzzlePieces = new PictureBox[rows, cols];

            int pieceWidth = originalImage.Width / cols;
            int pieceHeight = originalImage.Height / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Rectangle rect = new Rectangle(
                        j * pieceWidth, i * pieceHeight,
                        pieceWidth, pieceHeight
                    );
                    
                    Bitmap pieceBitmap = originalImage.Clone(rect, 
                        originalImage.PixelFormat);
                    
                    puzzlePieces[i, j] = new PictureBox();
                    puzzlePieces[i, j].Image = pieceBitmap;
                    puzzlePieces[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    puzzlePieces[i, j].Tag = i * cols + j;
                    puzzlePieces[i, j].Size = new Size(pieceSize, pieceSize);
                    puzzlePieces[i, j].Location = new Point(j * pieceSize, i * pieceSize);
                    puzzlePieces[i, j].Click += PuzzlePiece_Click;
                    
                    Controls.Add(puzzlePieces[i, j]);
                }
            }
        }

        private void ShufflePieces()
        {
            Random rand = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int randomRow = rand.Next(0, rows);
                    int randomCol = rand.Next(0, cols);
                    
                    SwapPieces(puzzlePieces[i, j], puzzlePieces[randomRow, randomCol]);
                }
            }
        }

        private void obrazekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Obrázky|*.png;*.jpg;*.jpeg";
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                originalImage = new Bitmap(ofd.FileName);
                SplitImage();
                ShufflePieces();
            }
        }
    }
}
```

---

## Užitečné odkazy

### Oficiální dokumentace
- [Microsoft Docs: System.Drawing](https://docs.microsoft.com/en-us/dotnet/api/system.drawing) - Kompletní reference knihovny
- [Microsoft Learn: Windows Forms](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/) - Tutoriály a příklady

### Stack Overflow - Obrazové zpracování
- [Image Processing in C#](https://stackoverflow.com/questions/tagged/image-processing+c%23) - Kolekce řešení
- [Bitmap manipulation](https://stackoverflow.com/questions/4779027/faster-way-to-get-and-set-pixel-in-bitmap) - Optimalizace práce s pixely
- [ColorMatrix tutorial](https://stackoverflow.com/questions/15408607/how-to-use-colormatrix-to-set-opacity-of-an-image) - Použití barevné matice

### Reddit - C# a grafika
- [r/csharp - Image manipulation](https://www.reddit.com/r/csharp/search/?q=image%20manipulation) - Diskuze komunity
- [r/learnprogramming - GDI+](https://www.reddit.com/r/learnprogramming/search/?q=GDI%2B%20c%23) - Základy grafiky

### Tutoriály a příklady
- [CodeProject: Image Processing](https://www.codeproject.com/Articles/1989/Image-Processing-for-Dummies-with-C-and-GDI-Part-1) - Série článků pro začátečníky
- [C# Corner: Bitmap Operations](https://www.c-sharpcorner.com/article/image-processing-in-C-Sharp/) - Praktické ukázky
- [YouTube: C# Image Editor Tutorial](https://www.youtube.com/results?search_query=c%23+image+editor+tutorial+windows+forms) - Video návody

### Algoritmy a teorie
- [Wikipedia: Grayscale](https://en.wikipedia.org/wiki/Grayscale) - Teorie převodu do šedi
- [Wikipedia: Bubble Sort](https://en.wikipedia.org/wiki/Bubble_sort) - Algoritmus třídění
- [Wikipedia: ASCII Art](https://en.wikipedia.org/wiki/ASCII_art) - Historie a techniky

---

## Shrnutí

Tento tutoriál pokryl vytvoření kompletního editoru obrázků s následujícími funkcemi:

| Funkce | Klíčové koncepty |
|--------|------------------|
| Filtry | Manipulace s pixely, světelnost |
| Třídění | Bubble Sort, asynchronní operace |
| Výřez | Rectangle, Graphics.DrawImage |
| Zvětšení | Interpolace, škálování |
| ASCII | Mapování jasu na znaky |
| Mapa barev | Tolerance, nahrazování |
| Matice | ColorMatrix, ImageAttributes |
| Puzzle | PictureBox, události |

Projekt demonstruje praktické využití OOP principů, práci s grafikou a vytváření interaktivních aplikací ve Windows Forms.




---
*Užitečný odkaz pro řešení problémů ve Windows Forms: [StackOverflow - This visible is not working in Windows Forms](https://stackoverflow.com/questions/3742709/this-visible-is-not-working-in-windows-forms)*

[<kbd> ⮞ Zpět na úvodní stránku </kbd>](README.md)
