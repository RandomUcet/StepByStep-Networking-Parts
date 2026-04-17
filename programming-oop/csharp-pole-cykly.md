# Pole a cykly v C#

>  **Tip pro Programování:** I když píšete cvičné projekty, zvykněte si názvy proměnných, tříd a metod psát v angličtině. Budete pak mít podstatně jednodušší orientaci v kódu, až budete řešit chyby přes zahraniční IT diskuze a návody.

Cykly a pole jdou v programování ruku v ruce. Pokud potřebujete uložit 100 čísel, nebudete vytvářet 100 proměnných – vytvoříte jedno **Pole (Array)**. A pro procházení těchto dat nebudete psát kód 100x za sebou, ale použijete **Cyklus (Loop)**.

## 1. Cykly (Loops)

Cyklus slouží k opakování části kódu tak dlouho, dokud platí zadaná podmínka.

### A) Cyklus FOR
Nejpoužívanější cyklus. Přesně víme, kolikrát se má opakovat (máme řídící proměnnou, zpravidla pojmenovanou `i`).

```csharp
// i začíná na 0; cyklus běží dokud je i menší jak 5; i se po každém proběhnutí zvětší o 1 (i++)
for (int i = 0; i < 5; i++)
{
    Console.WriteLine("Opakování číslo: " + i);
}
```

### B) Cyklus WHILE
Používá se tam, kde **nevíme, kolikrát se cyklus provede**. Opakuje se tak dlouho, dokud je podmínka v závorce pravdivá (`true`).

```csharp
int cislo = 0;
while (cislo < 10)
{
    // Kód se bude opakovat, dokud neplatí podmínka cislo < 10
    cislo = Convert.ToInt32(Console.ReadLine()); 
}
```

### C) Cyklus DO-WHILE
Funguje stejně jako WHILE, s jedním zásadním rozdílem: Kód se provede **vždy minimálně jednou**, protože se podmínka testuje až na konci cyklu. Vhodné pro herní smyčky nebo vynucené menu.

```csharp
do 
{
    Console.WriteLine("Tento řádek se vypíše alespoň jednou.");
} while (false); // Cyklus ihned skončí, ale vnitřek se už jednou provedl
```

## 2. Jednorozměrné pole (Array)

Pole je statická datová struktura obsahující prvky **stejného datového typu**. Pole má svou pevnou velikost, která se po vytvoření nemůže zvětšit ani zmenšit.

Prvky se číslují (indexují) **vždy od nuly**.

```csharp
// Vytvoření pole celých čísel o velikosti 5 prvků (indexy 0 až 4)
int[] poleCisel = new int[5];

// Zápis hodnoty na určitý index
poleCisel[0] = 10;
poleCisel[4] = 99; // Zápis na poslední prvek pole
```

### Kombinace pole a cyklu FOR

Většinu času budeme k plnění a čtení pole využívat cyklus `for`. 
Pole má velmi užitečnou vlastnost `.Length`, která vrací celkový počet prvků v poli. Je to extrémně bezpečné a zabrání to chybě *IndexOutOfRangeException* (pokus o sáhnutí mimo pole).

```csharp
int[] cisla = new int[20];

// Plnění pole od uživatele
for (int i = 0; i < cisla.Length; i++) 
{
    Console.WriteLine("Zadej číslo:");
    cisla[i] = Convert.ToInt32(Console.ReadLine());
    
    if (cisla[i] == 0) // Násilné ukončení cyklu klíčovým slovem break
    {
        break; 
    }
}
```

## 3. Cyklus FOREACH

Je to moderní typ cyklu určený speciálně k pohodlnému čtení hodnot z polí a kolekcí. Výhodou je krátký a bezpečný zápis. Nevýhodou je, že s ním nemůžete hodnoty uvnitř pole měnit (je pouze pro čtení) a neznáte aktuální pozici (index).

```csharp
string[] jmena = { "Karel", "Petr", "Lucie" };

// V překladu: Pro každý string, který nazveme "jmeno", nacházející se v poli "jmena", proveď:
foreach (string jmeno in jmena)
{
    Console.WriteLine("Student: " + jmeno);
}
```

---

[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../README.md)