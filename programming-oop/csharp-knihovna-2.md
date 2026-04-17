# C# Knihovní Systém v2 (Pokročilá SQLite Integrace)

>  **Tip pro Programování:** I když píšete cvičné projekty, zvykněte si názvy proměnných, tříd a metod psát v angličtině. Budete pak mít podstatně jednodušší orientaci v kódu, až budete řešit chyby přes zahraniční IT diskuze a návody.


Tento projekt je druhou iterací aplikace pro správu knihovny. Přináší pokročilejší oddělení vrstev, centralizovanou manipulaci s databázovým připojením (`SQLClass`) a složitější vztahy mezi entitami (Kniha, Autor, Žánr, Zákazník).

## Přehled projektu

Systém umožňuje plnohodnotnou správu databáze knihovny:
- Centralizované spojení s lokální SQLite databází pomocí univerzální třídy.
- Modely pro objekty knihovny (Entity).
- Pokročilé formuláře pro výpůjčky (`PujceniForm`), prohlížení (`ProhlizecDatabaze`) a vkládání dat (`NovaHodnota`).

## Architektura kódu

### 1. Centrální správa spojení (`SQLClass.cs`)

Kód pro připojování je obalen do samostatné třídy, která se stará o řízení životního cyklu databázového připojení. Poskytuje statické metody pro otevření a uzavření databáze.

```csharp
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace knihovna
{
    internal class SQLClass
    {
        // Connection string a samotné spojení jsou udržovány jako statické vlastnosti
        public static string Cs { get; private set; }
        public static SQLiteConnection Connection { get; private set; }

        public SQLClass()
        {
            // Odkaz na databázi pomocí URI
            Cs = @"URI=file:databaze.db";
            Connection = new SQLiteConnection(Cs);
        }

        // Metoda pro centrální otevření spojení
        public static void Connect()
        {
            try
            {
                Connection.Open();
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("Nepodařilo se připojit k databázi: " + ex.Message); 
            }
        }

        // Metoda pro bezpečné ukončení spojení
        public static void Disconnect() 
        {
            try
            {
                Connection.Close();
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("Chyba při odpojování databáze: " + ex.Message); 
            }
        }
    }
}
```

Třída `SQLClass` by v reálné aplikaci sloužila k vykonávání CRUD operací (jako jsou metody pro zapůjčení a vrácení knih atd.). Tímto způsobem mohou různé formuláře volat `SQLClass.Connect()`, aniž by musely znát detaily o konfiguračním souboru nebo typu databáze.

### 2. Entitní třídy (Modely)

Objektově orientovaný přístup v tomto projektu mapuje tabulky databáze na konkrétní třídy v kódu. Typickým příkladem je třeba `Kniha.cs`, `Autor.cs` nebo `Zakaznik.cs`.

*Ukázka konceptu třídy `Kniha.cs`:*
```csharp
namespace knihovna
{
    public class Kniha
    {
        public int Id { get; set; }
        public string Nazev { get; set; }
        public int RokVydani { get; set; }
        public int AutorId { get; set; }
        public int ZanrId { get; set; }
        public bool Puceno { get; set; }
    }
}
```

### 3. Modulární formuláře

Uživatelské rozhraní není sbaleno v jednom obřím formuláři, ale je rozděleno do několika logických oken:
- **`Menu.cs`**: Hlavní rozcestník.
- **`PujceniForm.cs`**: Specializovaný pohled pro evidenci, kdo má jakou knihu vypůjčenou.
- **`ProhlizecDatabaze.cs`**: Tabulkové zobrazení všech entit (knihy, autoři atd.).
- **`NovaHodnota.cs`**: Formulář pro registraci nových knih, zákazníků a přidělování štítků.

## Proč oddělovat kód tímto způsobem?

- **Znovupoužitelnost (Reusability)**: Kód pro komunikaci s databází stačí napsat jednou a může být zavolán z jakéhokoliv okna.
- **Bezpečnost**: Connection string existuje pouze na jednom místě, což usnadňuje případnou migraci na jiný SQL server.
- **Čistota kódu**: Formuláře mají za úkol starat se pouze o překreslování obrazovky a odesílání uživatelských dat (UI vrstva), zatímco datové operace probíhají v logické vrstvě aplikace (Business a Data vrstva).

[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../README.md)
