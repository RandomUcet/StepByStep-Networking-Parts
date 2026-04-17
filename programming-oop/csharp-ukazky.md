# Praktické C# Ukázky (Základy a Konzole)

>  **Tip pro Programování:** I když píšete cvičné projekty, zvykněte si názvy proměnných, tříd a metod psát v angličtině. Budete pak mít podstatně jednodušší orientaci v kódu, až budete řešit chyby přes zahraniční IT diskuze a návody.

Tato stránka obsahuje sbírku praktických menších programů (jako je Kalkulačka nebo generování vánočního stromku) napsaných v čistém C# jako konzolové aplikace. Jsou ideální pro trénování syntaxe, práce s poli a chápání podmínek.

## 1. Generátor Vánočního Stromku (Kreslení v konzoli)

Tento program využívá vícerozměrná pole a spoustu zanořených cyklů i podmínek. Využívá třídu `Random`, pomocí které na stromek náhodně rozmisťuje ozdoby (znaky `%`). Aplikace se také sama obarví do červené barvy a dynamicky reaguje na uživatelem zadanou velikost stromku.

```csharp
using System;
using System.Threading;

namespace Vesele_Vanoce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            start: // Návěští pro návrat v případě špatného zadání (tzv. goto)
            Console.Title = "Veselé Vánoce";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Veselé Vánoce\n");
            
            Console.WriteLine("Vyberte si velikost stromku (číslo větší než 10):");
            int velikostStromku = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            
            if (velikostStromku % 2 == 0) velikostStromku++; // Úprava na liché číslo pro hezký střed
            
            if (velikostStromku <= 10)
            {
                Console.WriteLine("Zadána příliš malá velikost, zadejte ji prosím znovu.");
                Thread.Sleep(2000); // Program usne na 2 vteřiny
                Console.Clear();
                goto start; // Skočí zpět na začátek
            }    

            int stred = velikostStromku / 2;
            int mezi = 0;
            // Dvojrozměrné pole pro uložení "pixelů" stromku v konzoli
            string[,] pole = new string[velikostStromku, (velikostStromku / 2) + 6];
            
            for (int i = 0; i < velikostStromku; i++)
            {
                for (int j = 0; j < velikostStromku; j++)
                {
                    // Vykreslení špičky
                    if (stred - mezi <= j && j <= stred + mezi && i < velikostStromku / 2 && i == 0)
                        pole[j, i] = "*";
                    
                    // Vykreslení těla a ozdob
                    else if (stred - mezi <= j && j <= stred + mezi && i < velikostStromku / 2 && i != 0)
                    {
                        if (random.Next(1000) % 13 == 0)
                            pole[i, j] = "%"; // Ozdoba
                        else
                            pole[i, j] = "#"; // Větvička
                    }
                    
                    // Vykreslení kmene
                    else if (i > 2 - velikostStromku / 2 && stred - 1 <= j && j <= stred + 1 && i != 0)
                        pole[i, j] = "0"; // Kmen
                    else
                        pole[j, i] = ""; // Volný vzduch kolem
                }
                mezi++;
            }
            
            Console.ReadLine(); // Čeká na Enter pro ukončení
        }
    }
}
```

## 2. Kalkulačka s rozvětveným menu

Základní program pro použití metody `switch` (přepínače), která je ideální pro tvorbu menu.

```csharp
using System;

class Kalkulacka
{
    static void Main()
    {
        Console.WriteLine("--- JEDNODUCHÁ KALKULAČKA ---");
        Console.Write("Zadej první číslo: ");
        double cislo1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Zadej operaci (+, -, *, /): ");
        string operace = Console.ReadLine();

        Console.Write("Zadej druhé číslo: ");
        double cislo2 = Convert.ToDouble(Console.ReadLine());

        double vysledek = 0;

        switch (operace)
        {
            case "+":
                vysledek = cislo1 + cislo2;
                break;
            case "-":
                vysledek = cislo1 - cislo2;
                break;
            case "*":
                vysledek = cislo1 * cislo2;
                break;
            case "/":
                if (cislo2 != 0)
                {
                    vysledek = cislo1 / cislo2;
                }
                else
                {
                    Console.WriteLine("Chyba: Nulou nelze dělit!");
                    return; // Násilné ukončení programu
                }
                break;
            default:
                Console.WriteLine("Neznámá operace!");
                return;
        }

        Console.WriteLine($"Výsledek: {cislo1} {operace} {cislo2} = {vysledek}");
        Console.ReadLine();
    }
}
```

---

[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../README.md)