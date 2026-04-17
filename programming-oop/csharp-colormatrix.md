# C# Aplikace: ColorMatrix (Filtry obrázků)

>  **Tip pro Programování:** I když píšete cvičné projekty, zvykněte si názvy proměnných, tříd a metod psát v angličtině. Budete pak mít podstatně jednodušší orientaci v kódu, až budete řešit chyby přes zahraniční IT diskuze a návody.


Tento tutoriál ukazuje, jak pracovat s objektem `ColorMatrix` v C# (knihovna `System.Drawing.Imaging`) a jak dynamicky upravovat barvy obrázků pomocí posuvníků (ScrollBars).

## Přehled projektu

Aplikace načte libovolný obrázek a pomocí šestnácti posuvníků umožňuje upravovat jednotlivé barevné složky (červená, zelená, modrá) a jejich vzájemný vliv, včetně celkové světelnosti a průhlednosti (alfa kanál). 

Klíčovým prvkem je matematická matice 5x5, přes kterou se původní barvy pixelů transformují na nové.

## Kompletní kód aplikace

```csharp
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ColorMatrixApp
{
    public partial class Form1 : Form
    {
        // Uchováváme původní nenačnutý obrázek pro výpočty
        private Bitmap originalImage;

        public Form1()
        {
            InitializeComponent();
            InitializeScrollBars();
        }

        // Tuto metodu zavolej (nebo vlož do tlačítka), když chceš načíst obrázek
        public void LoadImage(string filePath)
        {
            if (originalImage != null)
            {
                originalImage.Dispose();
            }
            
            originalImage = new Bitmap(filePath);
            ApplyColorMatrix(); // Aplikuje výchozí hodnoty na nový obrázek
        }

        private void InitializeScrollBars()
        {
            // Propojení všech 16 scrollbarů
            VScrollBar[] scrollBars = {
                vScrollBar1, vScrollBar2, vScrollBar3, vScrollBar4,   // Červená
                vScrollBar5, vScrollBar6, vScrollBar7, vScrollBar8,   // Zelená
                vScrollBar9, vScrollBar10, vScrollBar11, vScrollBar12,// Modrá
                vScrollBar13, vScrollBar14, vScrollBar15, vScrollBar16// Světelnost
            };

            foreach (var sb in scrollBars)
            {
                // Nastavení rozsahu (VScrollBar vyžaduje Maximum o něco vyšší kvůli vlastnosti LargeChange)
                sb.Minimum = -200;
                sb.Maximum = 209; 
                
                // Připojení eventu pro detekci změny
                sb.ValueChanged += ScrollBars_ValueChanged;
            }

            // --- VÝCHOZÍ NASTAVENÍ MATICE (Identita) ---
            // Aby se obrázek zobrazil normálně, musí být červená na červené, zelená na zelené atd. na 100%
            vScrollBar1.Value = 100;  // Red (R -> R)
            vScrollBar6.Value = 100;  // Green (G -> G)
            vScrollBar11.Value = 100; // Blue (B -> B)
            
            // Ostatní necháme na 0 (včetně světelnosti vScrollBar13 až 16)
        }

        private void ScrollBars_ValueChanged(object sender, EventArgs e)
        {
            // Přepočítá obrázek při každém hnutí scrollbarem
            if (originalImage != null)
            {
                ApplyColorMatrix();
            }
        }

        private void ApplyColorMatrix()
        {
            // Čtení hodnot ze scrollbarů (děleno 100 pro získání float -2.0 až 2.0)

            // 1. Vliv ČERVENÉ složky (R, G, B, Alpha)
            float rr = vScrollBar1.Value / 100f;
            float rg = vScrollBar2.Value / 100f;
            float rb = vScrollBar3.Value / 100f;
            float ra = vScrollBar4.Value / 100f;

            // 2. Vliv ZELENÉ složky (R, G, B, Alpha)
            float gr = vScrollBar5.Value / 100f;
            float gg = vScrollBar6.Value / 100f;
            float gb = vScrollBar7.Value / 100f;
            float ga = vScrollBar8.Value / 100f;

            // 3. Vliv MODRÉ složky (R, G, B, Alpha)
            float br = vScrollBar9.Value / 100f;
            float bg = vScrollBar10.Value / 100f;
            float bb = vScrollBar11.Value / 100f;
            float ba = vScrollBar12.Value / 100f;

            // 4. SVĚTELNOST a posun barev (Translations - R, G, B, Alpha)
            float tr = vScrollBar13.Value / 100f;
            float tg = vScrollBar14.Value / 100f;
            float tb = vScrollBar15.Value / 100f;
            float ta = vScrollBar16.Value / 100f;

            // Definice 5x5 ColorMatrix
            float[][] matrixItems = {
                new float[] { rr, rg, rb, ra, 0 }, // 1. řádek: Vliv původní červené
                new float[] { gr, gg, gb, ga, 0 }, // 2. řádek: Vliv původní zelené
                new float[] { br, bg, bb, ba, 0 }, // 3. řádek: Vliv původní modré
                new float[] {  0,  0,  0,  1, 0 }, // 4. řádek: Hlavní Alfa kanál (pevně 1)
                new float[] { tr, tg, tb, ta, 1 }  // 5. řádek: Translations (Světelnost)
            };

            ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

            using (ImageAttributes imageAttributes = new ImageAttributes())
            {
                imageAttributes.SetColorMatrix(
                    colorMatrix,
                    ColorMatrixFlag.Default,
                    ColorAdjustType.Bitmap);

                // Vytvoříme prázdné plátno o velikosti originálu
                Bitmap newImage = new Bitmap(originalImage.Width, originalImage.Height);

                using (Graphics graphics = Graphics.FromImage(newImage))
                {
                    // Vykreslí originál přes náš filtr (ColorMatrix)
                    graphics.DrawImage(
                        originalImage,
                        new Rectangle(0, 0, newImage.Width, newImage.Height),
                        0, 0, originalImage.Width, originalImage.Height,
                        GraphicsUnit.Pixel,
                        imageAttributes);
                }

                // Prevence memory leaku z předchozí vygenerované bitmapy
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                }

                // Aktualizace UI
                pictureBox1.Image = newImage;
            }
        }
    }
}
```

## Jak ColorMatrix funguje?

Třída `ColorMatrix` definuje matici 5x5. Každý pixel v původním obrázku je vynásoben touto maticí, aby se vypočítala jeho nová barva.

Matice je strukturována takto:

- **1. řádek**: Určuje, kolik z původní **červené** hodnoty přejde do výsledné (R, G, B, A).
- **2. řádek**: Určuje, kolik z původní **zelené** hodnoty přejde do výsledné (R, G, B, A).
- **3. řádek**: Určuje, kolik z původní **modré** hodnoty přejde do výsledné (R, G, B, A).
- **4. řádek**: Určuje, kolik z původního **alfa** kanálu přejde do výsledné (R, G, B, A).
- **5. řádek**: (Posun/Translace) Přidává absolutní hodnotu k (R, G, B, A). Slouží pro úpravu **světlosti**.

### Identita (Základní matice)

Když aplikujete identitní matici, obrázek zůstane nezměněn. Identitní matice vypadá takto:

| R | G | B | A | w |
|---|---|---|---|---|
| 1 | 0 | 0 | 0 | 0 | *(Červená ovlivňuje jen červenou)*
| 0 | 1 | 0 | 0 | 0 | *(Zelená ovlivňuje jen zelenou)*
| 0 | 0 | 1 | 0 | 0 | *(Modrá ovlivňuje jen modrou)*
| 0 | 0 | 0 | 1 | 0 | *(Alfa ovlivňuje jen alfu)*
| 0 | 0 | 0 | 0 | 1 | *(Žádný posun/zesvětlení)*

Pokud například v kódu nastavíte první hodnotu 5. řádku (`tr`) na `0.5f`, přidáte 50 % jasu do všech červených kanálů a vytvoříte celkově červenější (a jasnější) obrázek.

## Memory Management

Velmi důležitou částí kódu je správná správa paměti pomocí bloků `using`:
```csharp
using (ImageAttributes imageAttributes = new ImageAttributes())
using (Graphics graphics = Graphics.FromImage(newImage))
```
Tím zajistíme, že prostředky GDI+ jsou včas uvolněny. Stejně tak kód správně disponuje předchozí iterací obrázku (`pictureBox1.Image.Dispose()`), aby nedocházelo k takzvaným únikům paměti (memory leaks) při rychlém posouvání.

[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../README.md)
