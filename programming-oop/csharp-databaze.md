# C# Databázová aplikace (SQLite CRUD)

>  **Tip pro Programování:** I když píšete cvičné projekty, zvykněte si názvy proměnných, tříd a metod psát v angličtině. Budete pak mít podstatně jednodušší orientaci v kódu, až budete řešit chyby přes zahraniční IT diskuze a návody.


Tento projekt ukazuje základy práce s lokální databází SQLite v prostředí Windows Forms. Aplikace demonstruje architekturu s oddělenou databázovou vrstvou (třída `REPOZITORY`) a načítání dat do prvků `DataGridView`.

## Přehled projektu

Aplikace umí:
- Zobrazovat data z databázových tabulek (`obchod`, `lokace`).
- Přidávat nové záznamy do tabulek pomocí SQL příkazu `INSERT INTO`.
- Pracovat s objekty `SQLiteConnection`, `SQLiteCommand` a `SQLiteDataAdapter`.

## Struktura kódu

### 1. Repozitářová vrstva (`REPOZITORY.cs`)

Veškerá logika komunikace s databází je extrahována do statických metod. Zde dochází k otevření spojení s lokální `.db` databází.

```csharp
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace HushkysDatabaze
{
    internal class REPOZITORY
    {
        // Načtení dat z tabulky "obchod"
        public static object ReadFromTableObchod()
        {
            DataGridView dataGridView = new DataGridView();
            string query = "SELECT * FROM obchod";
            
            // Relativní cesta k databázi (očekává databaze.db ve stejné složce jako spustitelný soubor)
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=databaze.db"))
            {
                conn.Open();
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView.DataSource = dt;
                }
            }
            return dataGridView.DataSource;
        }

        // Přidání dat do tabulky "obchod"
        public static void AddToTableObchod(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4)
        {
            string query = "INSERT INTO obchod (nazev_obchodu, pocet_zamestnancu, rok_zalozeni, lokace_id) " + 
                           "VALUES (@nazev_obchodu, @pocet_zamestnancu, @rok_zalozeni, @lokace_id)";
                           
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=databaze.db"))
            {
                conn.Open();
                try
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        // Parametrizované dotazy zabraňují SQL Injection
                        cmd.Parameters.AddWithValue("@nazev_obchodu", textBox1.Text);
                        cmd.Parameters.AddWithValue("@pocet_zamestnancu", textBox2.Text);
                        cmd.Parameters.AddWithValue("@rok_zalozeni", textBox3.Text);
                        cmd.Parameters.AddWithValue("@lokace_id", textBox4.Text);
                        
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Záznam byl úspěšně přidán.");
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Chyba při ukládání: " + ex.Message);
                }
            }
        }
    }
}
```

### 2. Prezentační vrstva (`Form1.cs`)

Hlavní okno pouze volá metody z repozitáře a přiřazuje vrácená data komponentám `DataGridView`.

```csharp
namespace HushkysDatabaze
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Tlačítko pro načtení dat
        private void button1_Click(object sender, EventArgs e)
        {
            // Připojí Data Source vrácený z repozitáře přímo do vizuální komponenty
            dataGridView1.DataSource = REPOZITORY.ReadFromTableObchod();
            dataGridView2.DataSource = REPOZITORY.ReadFromTableLokace();
        }

        // Tlačítko pro zobrazení formuláře pro přidávání dat
        private void button2_Click(object sender, EventArgs e)
        {
            AddToDatabaseForm form = new AddToDatabaseForm();
            form.ShowDialog();
        }
    }
}
```

## Důležité koncepty

- **Parametrizované SQL dotazy (`@parametr`)**: Používají se k ochraně aplikace před útoky typu SQL Injection. Hodnoty z `TextBox` komponent nejsou spojovány s SQL dotazem přímo pomocí operátoru `+`, ale jsou předávány jako bezpečné parametry.
- **`using` bloky**: Spojení s databází (`SQLiteConnection`) nebo paměťové prostředky (`SQLiteDataAdapter`) pracují s unmanaged prostředky. Klíčové slovo `using` garantuje okamžité a bezpečné uvolnění (tzv. `Dispose`) a uzavření spojení ve chvíli, kdy kód opustí blok.
- **Oddělení logiky (Repository Pattern)**: Všechny databázové dotazy jsou uzavřeny v samostatné třídě `REPOZITORY`. Tím je zamezeno míchání SQL kódu s logikou UI formulářů.

[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../README.md)
