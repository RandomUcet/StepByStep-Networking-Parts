# Třída Automobil (OOP a metody)

Tato stránka představuje praktickou ukázku tvorby vlastní třídy v C#. Třída `Automobil` demonstruje základní principy objektově orientovaného programování, jako je zapouzdření (encapsulation), použití konstruktorů, vlastností (properties) a stavových metod.

## Vysvětlení konceptů
*   **Vlastnosti (Properties):** Namísto toho, aby byly interní proměnné volně přístupné komukoliv (public), jsou nastaveny jako soukromé (`private`). K jejich čtení a bezpečné úpravě zvenčí slouží "Vlastnosti". K rychlému vytvoření vlastnosti v prostředí Visual Studio stačí napsat `prop` a dvakrát stisknout klávesu `TAB`.
*   **Konstruktory:** Metody, které se spustí automaticky ve chvíli, kdy vzniká nový objekt (např. `Automobil mojeAuto = new Automobil();`). V našem kódu vidíme *přetížení konstruktorů* – jeden vytváří auto podle námi dodaných parametrů a druhý vytvoří výchozí "bílé auto".
*   **Obslužné metody:** Představují chování objektu. Namísto přímé změny proměnné (např. `palivo += 10`) máme chytrou metodu `Natankuj()`, která kontroluje, zda se do nádrže požadovaný objem vůbec vejde. Pokud byste chtěli vytvářet události (např. zareagovat na to, že došel benzín), ve Visual Studiu můžete vygenerovat kostru obslužné metody pro Event stisknutím kláves `+=` a následným stiskem `TAB`.

## Zdrojový kód třídy

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto
{
    class Automobil
    {
        // Privátní atributy (stav objektu)
        private string barva;
        private int obsahM;
        private int rychlost;
        private int spotreba;
        private int mnozstviPaliva;
        private int maxObsahNadrze;
        private bool beziMotor;

        // Konstruktor s parametry
        public Automobil(string barva, int obsah, int rychlost, int spotreba, int maxObsahNadrze)
        {
            this.barva = barva;
            this.obsahM = obsah;
            this.rychlost = rychlost;
            this.spotreba = spotreba;
            this.maxObsahNadrze = maxObsahNadrze;
            mnozstviPaliva = 0;
            beziMotor = false;
        }

        // Výchozí bezparametrický konstruktor
        public Automobil()
        {
            this.barva = "bila";
            this.obsahM = 2000;
            this.rychlost = 150;
            this.spotreba = 7;
            this.maxObsahNadrze = 40;
            mnozstviPaliva = 0;
            beziMotor = false;
        }

        // Vlastnost (Property) pro zjištění stavu motoru (pouze pro čtení)
        public bool BeziMotor
        {
            get { return beziMotor; }
        }

        public void nastartuj()
        {
            beziMotor = true;
        }

        public void vypni()
        {
            beziMotor = false;
        }

        // Chytrá stavová metoda pro tankování (hlídá přetečení nádrže)
        public void Natankuj(int litry)
        {
            if (maxObsahNadrze - mnozstviPaliva > litry)
            {
                mnozstviPaliva += litry;
            }
            else
            {
                mnozstviPaliva = maxObsahNadrze;
                Console.WriteLine("Stojan byl vypnut");
                int nedotankovano = litry - (maxObsahNadrze - mnozstviPaliva);
                Console.WriteLine("Bylo natankováno maximum do plné nádrže.");
            }
        }

        // Vlastnosti (Properties) - zapouzdření (Encapsulation)
        public int MnozstviPaliva
        {
            get { return mnozstviPaliva; }
        }

        public string Barva
        {
            get { return barva; }
            set 
            { 
                Console.WriteLine("Máš povolení k změně barvy a/n ?");
                string odpoved = Console.ReadLine();
                if (odpoved == "a")  barva = value; 
            }
        }

        public int ObsahM
        {
            get { return obsahM; }
        }

        public int Rychlost
        {
            get { return rychlost; }
        }

        public int Spotreba
        {
            get { return spotreba; }
        }
    }
}
```

---


---
*Užitečný odkaz pro řešení problémů ve Windows Forms: [StackOverflow - This visible is not working in Windows Forms](https://stackoverflow.com/questions/3742709/this-visible-is-not-working-in-windows-forms)*

[<kbd> ⮞ Zpět na úvodní stránku </kbd>](README.md)