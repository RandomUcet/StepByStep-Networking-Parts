# Trezor — Události a delegáty (C#)

>  **Tip pro Programování:** I když píšete cvičné projekty, zvykněte si názvy proměnných, tříd a metod psát v angličtině. Budete pak mít podstatně jednodušší orientaci v kódu, až budete řešit chyby přes zahraniční IT diskuze a návody.


Tento projekt demonstruje klíčové koncepty objektově orientovaného programování (OOP) v jazyce C#, konkrétně dědičnost, delegáty a události. Třída `Trezor` (Safe) dědí od základní třídy `Skrin` (Cabinet) a vyvolává událost `Napadeni` (Attack), pokud je zadáno nesprávné heslo.

## Klíčové koncepty

### Dědičnost (Inheritance)
Dědičnost umožňuje jedné třídě (potomkovi) převzít vlastnosti a metody jiné třídy (předka). V C# se k tomu používá operátor `:`. Třída `Trezor` tak automaticky získává přístup k rozměrům a výpočtu objemu ze třídy `Skrin`.

### Delegáti (Delegates)
Delegát je v C# typově bezpečný objekt, který ukazuje na metodu. Lze si ho představit jako moderní a bezpečnou alternativu k ukazatelům na funkce z jazyka C. Definice `delegate void Del1()` říká, že jakákoliv metoda přiřazená k tomuto delegátu nesmí mít žádné parametry a nesmí vracet žádnou hodnotu.

### Události (Events)
Událost je mechanismus, který umožňuje třídě informovat ostatní třídy o tom, že se něco stalo. Události jsou postaveny na delegátech a implementují vzor Observer (Pozorovatel). Klíčové slovo `event` zajišťuje, že událost může být z vnějšku třídy pouze "přihlášena" (`+=`) nebo "odhlášena" (`-=`), ale nemůže být přímo vyvolána nikým jiným než vlastníkem.

### Vlastnosti (Properties)
Vlastnosti umožňují kontrolovaný přístup k soukromým polím třídy. Pomocí bloků `get` a `set` můžeme definovat logiku pro čtení a zápis, například zajistit, aby vlastnost byla přístupná pouze pro čtení (read-only).

## Zdrojové soubory

### Cabinet.cs
Základní třída pro skříň s rozměry a výpočtem objemu.

```csharp
using System;

namespace Systemy
{
    class Skrin
    {
        protected int vyska;
        protected int sirka;
        protected int hloubka;

        public Skrin(int vyska, int sirka, int hloubka)
        {
            this.vyska = vyska;
            this.sirka = sirka;
            this.hloubka = hloubka;
        }

        public int Vyska { get { return vyska; } }
        public int Sirka  { get { return sirka; } }
        public int Hloubka { get { return hloubka; } }

        public int VypocitejObjem()
        {
            return this.vyska * this.sirka * this.hloubka;
        }
    }
}
```

### Safe.cs
Dědí ze třídy Skrin, přidává logiku hesla a událost Napadeni.

```csharp
using System;

namespace Systemy
{
    // Definice delegáta pro událost
    delegate void Del1();

    class Trezor : Skrin    // Dědičnost: Trezor JE skříní
    {
        // Událost vyvolaná při špatném hesle
        public event Del1 Napadeni;
        
        private string heslo;
        private bool odemceno;

        // Výchozí konstruktor volá konstruktor předka pomocí base()
        public Trezor() : base(5, 3, 2)
        {
            this.odemceno = false;
            this.heslo = "letadlo";
        }

        // Přetížený konstruktor s vlastním heslem
        public Trezor(string heslo) : base(5, 3, 2)
        {
            this.odemceno = false;
            this.heslo = heslo;
        }

        public bool Odemceno
        {
            get { return odemceno; }
        }

        public void Odemkni(string vstup)
        {
            if (vstup == heslo)
            {
                odemceno = true;
            }
            else
            {
                // Vyvolání události - zavolá všechny přihlášené handlery
                if (Napadeni != null)
                {
                    Napadeni();
                }
            }
        }
    }
}
```

### Program.cs
Hlavní vstupní bod programu – vytvoří trezor, přihlásí obslužné metody k události a testuje zadávání hesla.

```csharp
using System;

namespace Systemy
{
    class Program
    {
        static void Main(string[] args)
        {
            Trezor model1236 = new Trezor("BezpecneHeslo123");

            // Přihlášení metod k události Napadeni (multicast delegát)
            model1236.Napadeni += new Del1(SpustitAlarm);
            model1236.Napadeni += new Del1(PrivolatPolicii);

            string vstup = null;
            do
            {
                Console.Write("Zadejte heslo k trezoru: ");
                vstup = Console.ReadLine();
                model1236.Odemkni(vstup);
            }
            while (!model1236.Odemceno);

            Console.WriteLine("Trezor byl úspěšně odemčen.");
            Console.WriteLine("Objem trezoru je: " + model1236.VypocitejObjem());
            Console.ReadKey();
        }

        static void SpustitAlarm()
        {
            Console.WriteLine("ALARM AKTIVOVÁN!");
            Console.Beep(440, 1000);
        }

        static void PrivolatPolicii()
        {
            Console.WriteLine("Vysílám hlídku policie na místo...");
        }
    }
}
```

> [!IMPORTANT]
> Nezapomeňte před vyvoláním události v C# vždy zkontrolovat, zda není `null` (tj. zda je k ní přihlášen alespoň jeden odběratel), abyste předešli výjimce `NullReferenceException`. V novějších verzích C# lze použít zkrácený zápis `Napadeni?.Invoke();`.

[Zpět na přehled](../../README.md)


[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../README.md)
