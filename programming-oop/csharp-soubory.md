# Práce se soubory v C#

>  **Tip pro Programování:** I když píšete cvičné projekty, zvykněte si názvy proměnných, tříd a metod psát v angličtině. Budete pak mít podstatně jednodušší orientaci v kódu, až budete řešit chyby přes zahraniční IT diskuze a návody.

Práce se soubory a složkami (tzv. Vstupní/Výstupní operace, zkráceně I/O) je základem pro každou aplikaci, která si potřebuje pamatovat data po svém vypnutí (ukládání stavu, načítání logů, čtení textových podkladů).

Pro práci se soubory v C# musíme do hlavičky souboru přidat důležitý jmenný prostor (namespace):
```csharp
using System.IO;
```

Tím získáme přístup k výkonným třídám jako `File`, `Directory`, `StreamReader` a `StreamWriter`.

## 1. Zápis do textového souboru

K zápisu běžného textu je nejlepší využít objekt `StreamWriter`. Tento nástroj si můžeme představit jako tužku, kterou otevřeme soubor a píšeme do něj řádky.

```csharp
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Cesta k souboru (pokud zadáme jen název, vytvoří se ve stejné složce jako .exe soubor)
        string cesta = "zapis.txt";

        // Blok 'using' zajistí bezpečné zavření souboru, i kdyby program nečekaně spadl
        using (StreamWriter zapisovac = new StreamWriter(cesta, append: true))
        {
            zapisovac.WriteLine("Tento řádek zapisujeme do souboru.");
            zapisovac.WriteLine("Datum zápisu: " + DateTime.Now);
        } // Zde se StreamWriter automaticky ukončí a soubor se bezpečně uloží

        Console.WriteLine("Zápis byl úspěšný.");
    }
}
```

> **Důležitý parametr `append`:** Pokud jej v konstruktoru StreamWriteru nastavíte na `true`, text se připíše na konec existujícího souboru. Pokud na `false` (nebo nevyplníte), obsah souboru se s každým spuštěním přemaže úplně od nuly.

## 2. Čtení z textového souboru

K načítání existujících textů slouží `StreamReader`. Dokáže číst data znak po znaku, blok po bloku, nebo nejčastěji čte rovnou celé řádky.

```csharp
using System.IO;
using System;

class Program
{
    static void Main(string[] args)
    {
        string cesta = "zapis.txt";

        // Než zkusíme číst, je dobré ověřit, že soubor fyzicky existuje, aby program nespadl
        if (File.Exists(cesta))
        {
            using (StreamReader ctenar = new StreamReader(cesta))
            {
                string radek;
                // Čte řádky ve smyčce, dokud nenarazí na prázdno (null = konec souboru)
                while ((radek = ctenar.ReadLine()) != null)
                {
                    Console.WriteLine(radek); // Vypíše přečtený řádek do konzole
                }
            }
        }
        else
        {
            Console.WriteLine("Soubor nebyl nalezen!");
        }
    }
}
```

## 3. Zkratky pomocí třídy `File`

Pokud nepotřebujete postupně číst obrovské gigabajtové logy řádek po řádku, má pro vás C# připravené zjednodušující "zkratky" z třídy `File`, které nepotřebují `StreamReader/Writer`.

### Rychlý zápis a přečtení celého souboru
```csharp
string cesta = "rychla_data.txt";

// Uložení jednoho dlouhého textu (přepíše celý soubor)
File.WriteAllText(cesta, "Tohle je bleskový zápis.");

// Přečtení celého obsahu do jedné proměnné zaráz
string precteno = File.ReadAllText(cesta);
Console.WriteLine(precteno);
```

### Práce s polem řádků
```csharp
string cesta = "seznam_jmen.txt";

// Uložení pole řetězců (každý prvek pole bude na novém řádku v txt souboru)
string[] lide = { "Karel", "Pavel", "Lucie" };
File.WriteAllLines(cesta, lide);

// Zpětné načtení - vygeneruje z textového souboru pole Stringů
string[] nactenaJmena = File.ReadAllLines(cesta);
```

## 4. Práce se složkami

Pomocí statické třídy `Directory` můžete jednoduše ověřovat existenci složek a případně si je před tvorbou samotných souborů nachystat.

```csharp
string slozka = @"C:\MojeAplikace\Data"; // Zavináč před Stringem znamená, že zpětná lomítka nejsou brána jako Escape znaky

// Ověření, zda složka existuje
if (!Directory.Exists(slozka))
{
    // Pokud ne, složku vytvoříme
    Directory.CreateDirectory(slozka);
    Console.WriteLine("Složka úspěšně vytvořena.");
}
```

---

[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../README.md)