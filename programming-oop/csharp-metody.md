# Metody v C#

>  **Tip pro Programování:** I když píšete cvičné projekty, zvykněte si názvy proměnných, tříd a metod psát v angličtině. Budete pak mít podstatně jednodušší orientaci v kódu, až budete řešit chyby přes zahraniční IT diskuze a návody.

Metoda (často nazývána funkce) je pojmenovaný blok kódu, který můžeme zavolat (spustit) vícekrát. Zabraňuje to zbytečnému opakování kódu (princip DRY - Don't Repeat Yourself) a činí program přehlednějším a modulárnějším.

## 1. Definice metody

Každá metoda se skládá ze signatury a těla (kódu uvnitř složených závorek `{}`).

```csharp
// Přístupový_modifikátor (static) Návratový_typ NázevMetody(Vstupní_parametry)
public static void Pozdrav(string jmeno)
{
    Console.WriteLine("Ahoj, " + jmeno);
}
```

*   **public / private:** Kdo může metodu vidět. `public` znamená kdokoliv, `private` jen třída, ve které metoda vznikla.
*   **static:** Znamená, že k zavolání metody nepotřebujeme vytvářet instanci (objekt) třídy. Užitečné v jednoduchých programech.
*   **Návratový typ:** Datový typ hodnoty, kterou metoda "vyplivne" zpět (např. `int`, `string`, `bool`). Pokud metoda nic nevrací, použijeme klíčové slovo **`void`**.

## 2. Metody vracející hodnotu (`return`)

Pokud metoda nemá návratový typ `void`, musí někde ve svém těle zavolat příkaz `return`, kterým pošle vypočítanou hodnotu zpět tam, odkud byla zavolána.

```csharp
// Tato metoda vrací celé číslo (int) a přijímá dvě celá čísla jako parametry.
public static int Secti(int a, int b)
{
    int vysledek = a + b;
    return vysledek; // Vrací vysledek zpět
}

static void Main(string[] args)
{
    // Volání metody
    int soucet = Secti(5, 10);
    Console.WriteLine("Výsledek je: " + soucet);
}
```

## 3. Přetěžování metod (Method Overloading)

V C# můžete mít více metod **se stejným názvem**, pokud se liší v parametrech (v jejich počtu, nebo datovém typu). Tomuto se říká *přetěžování*. Kompilátor podle toho, co do metody vložíte za hodnoty pozná, kterou verzi má spustit.

```csharp
// Verze 1: Přijímá číslo
private static int[] NactiCisla(int UkoncovaciCislo) 
{
    int[] poleCisel = new int[20];
    int cislo = Convert.ToInt32(Console.ReadLine());
    // Logika...
    return poleCisel;
}

// Verze 2: Přijímá text (řetězec) - STEJNÝ NÁZEV METODY
private static int[] NactiCisla(string UkoncovaciRetezec) 
{
    int[] poleCisel = new int[20];
    string text = Console.ReadLine();
    // Logika...
    return poleCisel;
}

static void Main(string[] args)
{
    int[] metoda1 = NactiCisla(0);       // Spustí se Verze 1
    int[] metoda2 = NactiCisla("Konec"); // Spustí se Verze 2
}
```

## 4. Proč používat metody?

Představte si, že potřebujete najít minimální a maximální hodnotu ze sady čísel. Namísto psaní smyčky dvakrát (jednou pro sudá čísla, jednou pro lichá), vytvoříte jednu obecnou metodu:

```csharp
private static int[] MinMax(int zbytekPocitani, int[] sadaCisel) 
{
    int[] minMax = { int.MinValue, int.MaxValue }; 
    
    for(int i = 0; i < sadaCisel.Length && sadaCisel[i] != 0; i++) 
    {
        // Díky parametru 'zbytekPocitani' je metoda univerzální
        if (sadaCisel[i] % 2 == zbytekPocitani)
        {
            if (minMax[0] < sadaCisel[i]) minMax[0] = sadaCisel[i];
            if (minMax[1] > sadaCisel[i]) minMax[1] = sadaCisel[i];
        }
    }
    return minMax; // Metoda vrací dvouprvkové pole
}
```

A zavoláte ji z hlavní části programu s různými parametry:

```csharp
int[] minMaxSuda = MinMax(0, pole); // 0 je zbytek po dělení 2 u sudých
int[] minMaxLicha = MinMax(1, pole); // 1 je zbytek po dělení 2 u lichých
```

Kód se stane kratším, čitelnějším a snadněji opravitelným.

---



---
*Užitečný odkaz pro řešení problémů ve Windows Forms: [StackOverflow - This visible is not working in Windows Forms](https://stackoverflow.com/questions/3742709/this-visible-is-not-working-in-windows-forms)*

[<kbd> ⮞ Zpět na úvodní stránku </kbd>](README.md)