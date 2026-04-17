# C# Aplikace: Malování (Jednoduchý kreslící program)

>  **Tip pro Programování:** I když píšete cvičné projekty, zvykněte si názvy proměnných, tříd a metod psát v angličtině. Budete pak mít podstatně jednodušší orientaci v kódu, až budete řešit chyby přes zahraniční IT diskuze a návody.


Tento tutoriál ukazuje, jak vytvořit jednoduchý program pro kreslení podobný aplikaci MS Paint ve Windows Forms v jazyce C#.

## Přehled projektu

Aplikace využívá grafickou knihovnu `System.Drawing` a reaguje na události myši (`MouseDown`, `MouseUp`, `MouseMove`). Uživatel může kreslit plynulé čáry tažením myši po plátně (`PictureBox`). Nabízí také možnost měnit barvu štětce na základě výběru z jiných `PictureBox`ů představujících barevnou paletu.

## Struktura kódu

Hlavní logika se nachází ve třídě `Form1`:

```csharp
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Malování
{
    public partial class Form1 : Form
    {
        // Deklarace globálních proměnných pro grafiku a stav pera
        Graphics grafika;
        bool pohybKursoru = false; // Indikuje, zda aktuálně uživatel drží tlačítko a kreslí
        Pen pero;
        int poziceX; // Poslední známá X souřadnice myši
        int poziceY; // Poslední známá Y souřadnice myši
        
        public Form1()
        {
            InitializeComponent();
            // Vytvoření grafického objektu spojeného s PictureBoxem "pozadi"
            grafika = pozadi.CreateGraphics();
            
            // Inicializace pera - výchozí barva černá, tloušťka 5 pixelů
            pero = new Pen(Color.Black, 5); 
        }

        // Změna barvy pera po kliknutí na jakýkoli barevný PictureBox (paletu)
        private void cerna_Click(object sender, EventArgs e)
        {
            PictureBox barva = (PictureBox)sender;
            pero.Color = barva.BackColor; // Změní barvu pera na barvu pozadí kliknutého prvku
        }

        // Událost stisknutí tlačítka myši nad plátnem
        private void pozadi_MouseDown(object sender, MouseEventArgs e)
        {
            pohybKursoru = true; // Aktivujeme režim kreslení
            poziceX = e.X;       // Uložíme počáteční X souřadnici
            poziceY = e.Y;       // Uložíme počáteční Y souřadnici
        }

        // Událost uvolnění tlačítka myši
        private void pozadi_MouseUp(object sender, MouseEventArgs e)
        {
            pohybKursoru = false; // Deaktivujeme režim kreslení
            poziceX = 0;          // Reset souřadnic
            poziceY = 0;
        }

        // Událost pohybu myši nad plátnem
        private void pozadi_MouseMove(object sender, MouseEventArgs e)
        {
            // Pokud je myš stisknuta (pohybKursoru == true)
            if (pohybKursoru == true)
            {
                // Vykreslíme čáru z předchozí pozice do aktuální pozice
                grafika.DrawLine(pero, new Point(poziceX, poziceY), e.Location);
                
                // Aktualizujeme předchozí pozici na tu aktuální pro další tah
                poziceX = e.X;
                poziceY = e.Y;
            }
        }
    }
}
```

## Jak to funguje?

1. **Inicializace GDI+ (`Graphics`)**: V konstruktoru formuláře se vytvoří objekt `Graphics` spojený s prvkem `pozadi` (`PictureBox`). Objekt `Pen` definuje barvu a tloušťku čáry (5 pixelů).
2. **Začátek kreslení (`MouseDown`)**: Když uživatel stiskne levé tlačítko myši, zaznamenají se aktuální souřadnice (X, Y) do proměnných `poziceX` a `poziceY`. Boolean proměnná `pohybKursoru` se nastaví na `true`.
3. **Kreslení (`MouseMove`)**: Když uživatel hýbe myší, kontroluje se proměnná `pohybKursoru`. Pokud je `true`, GDI+ vykreslí krátkou čáru z uložené předchozí pozice do aktuální pozice myši (`e.Location`). Následně se okamžitě aktualizují proměnné `poziceX` a `poziceY` na stávající bod, čímž vzniká plynulá křivka.
4. **Konec kreslení (`MouseUp`)**: Po uvolnění tlačítka myši se proměnná `pohybKursoru` přepne zpět na `false`, což kreslení zastaví.
5. **Změna barvy (`Click`)**: Na událost kliknutí různých barevných bloků z palety (tlačítka napojená na `cerna_Click`) je navázána logika, která zjišťuje barvu daného bloku a mění podle ní barvu kreslícího pera.

[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../README.md)
