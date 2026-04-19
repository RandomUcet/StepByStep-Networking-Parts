# Základy C# a Algoritmy

>  **Tip pro Programování:** I když píšete cvičné projekty, zvykněte si názvy proměnných, tříd a metod psát v angličtině. Budete pak mít podstatně jednodušší orientaci v kódu, až budete řešit chyby přes zahraniční IT diskuze a návody.

Tento dokument shrnuje naprosté základy programování v jazyce C# a tvorby algoritmů. Pochopení těchto konceptů je klíčové před přechodem k objektově orientovanému programování (OOP) a složitějším aplikacím.

## 1. Algoritmy a vývojové diagramy

**Algoritmus** je přesný návod či postup, kterým lze vyřešit daný typ úlohy. Má své vlastnosti, jako je konečnost, determinovanost a univerzálnost. Než začnete psát jakýkoli kód, je dobré si ho představit (nebo nakreslit) jako **vývojový diagram**.

Základní prvky vývojových diagramů:
*   **Ovál:** Začátek a konec algoritmu.
*   **Obdélník:** Zpracování dat (běžná operace, jako například matematický výpočet).
*   **Kosočtverec:** Podmínka (otázka, ze které vedou dvě cesty: ANO a NE).
*   **Kosodélník:** Vstup nebo výstup (např. "Načti číslo od uživatele" nebo "Vypiš výsledek").

## 2. Struktura programu v C#

Každý program v C# (v režimu konzolové aplikace .NET Framework) má pevnou strukturu, ze které se odvíjí:

```csharp
using System; // Připojení základních knihoven (pro práci s konzolí apod.)

namespace MujPrvniProjekt // Název prostoru jmen, sdružuje logicky související kód
{
    internal class Program // Třída (vše v C# musí být součástí nějaké třídy)
    {
        // Hlavní metoda Main - zde začíná běh celého programu
        static void Main(string[] args)
        {
            Console.WriteLine("Ahoj Světe!"); // Výpis do konzole
            Console.ReadLine(); // Čekání na stisk klávesy Enter
        }
    }
}
```

## 3. Proměnné a datové typy

Proměnná je "krabička" v paměti počítače, do které si ukládáme hodnoty. Každá proměnná musí mít určený datový typ, který říká, co se v ní smí uchovávat.

**Základní datové typy:**
*   `int` - Celá čísla (např. 5, -10, 1000).
*   `double` - Desetinná čísla (např. 3.14). Pozor, v kódu se píše tečka, ale do konzole se často zadává s čárkou (dle české lokalizace Windows).
*   `char` - Jeden znak (např. 'A', 'z', '@'). Zapisuje se do jednoduchých uvozovek.
*   `string` - Textový řetězec (např. "Ahoj"). Zapisuje se do dvojitých uvozovek.
*   `bool` - Logická hodnota (může být pouze `true` nebo `false`).

Příklad deklarace a přiřazení:
```csharp
int vek = 18;
string jmeno = "Pavel";
bool jePlnolety = true;
```

## 4. Větvení programu (Podmínky)

Podmínky (reprezentované kosočtvercem ve vývojových diagramech) umožňují programu se rozhodovat. Nejpoužívanější je konstrukce `if` / `else`.

```csharp
int cislo = 10;

if (cislo > 0)
{
    Console.WriteLine("Číslo je kladné.");
}
else if (cislo < 0)
{
    Console.WriteLine("Číslo je záporné.");
}
else
{
    Console.WriteLine("Číslo je nula.");
}
```

## 5. Základní interakce s uživatelem

Pro konzolové aplikace používáme třídu `Console` ze jmenného prostoru `System`:

*   `Console.WriteLine("Text");` – Vypíše text a odřádkuje.
*   `Console.Write("Text");` – Vypíše text a neodřádkuje (zůstane na stejném řádku).
*   `Console.ReadLine();` – Načte celý řádek textu, který uživatel napsal, dokud nezmáčkne Enter.

### Čtení čísel a konverze (Parsování)
`Console.ReadLine()` vrací **vždy** datový typ `string` (text). Pokud chceme od uživatele číslo, musíme text "přeložit" (konvertovat).

```csharp
Console.WriteLine("Zadej svůj věk:");
string vstup = Console.ReadLine();
int zadanyVek = Convert.ToInt32(vstup); // Konverze textu na celé číslo

// Kratší zápis:
// int zadanyVek = Convert.ToInt32(Console.ReadLine());
```

---



---
*Užitečný odkaz pro řešení problémů ve Windows Forms: [StackOverflow - This visible is not working in Windows Forms](https://stackoverflow.com/questions/3742709/this-visible-is-not-working-in-windows-forms)*

[<kbd> ⮞ Zpět na úvodní stránku </kbd>](README.md)