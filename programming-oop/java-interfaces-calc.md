# Rozhraní (Interface) — Výpočty (Java)

>  **Tip pro Programování:** I když píšete cvičné projekty, zvykněte si názvy proměnných, tříd a metod psát v angličtině. Budete pak mít podstatně jednodušší orientaci v kódu, až budete řešit chyby přes zahraniční IT diskuze a návody.


Tento projekt demonstruje použití rozhraní (Interface) v jazyce Java pro definování kontraktu pro výpočetní operace. Ukazuje, jak lze oddělit definici operace od její konkrétní implementace.

## Klíčové koncepty

### Rozhraní (Interface)
Rozhraní v Javě definuje sadu metod, které musí třída implementovat, pokud se k tomuto rozhraní přihlásí. Můžeme si ho představit jako "smlouvu" nebo "předpis" – rozhraní říká, **co** má třída dělat, ale neříká, **jak** to má dělat. Všechny metody v rozhraní jsou automaticky veřejné (`public`) a abstraktní (`abstract`).

### Implementace (Implements)
Třída, která chce splnit požadavky rozhraní, používá klíčové slovo `implements`. Tím se zavazuje, že poskytne konkrétní kód (tělo) pro všechny metody definované v rozhraní.

### Polymorfismus pomocí rozhraní
Proměnná typu rozhraní může odkazovat na jakýkoliv objekt třídy, která toto rozhraní implementuje. To umožňuje psát velmi flexibilní kód, kde můžeme snadno vyměnit jednu implementaci za jinou, aniž bychom museli měnit zbytek aplikace.

## Zdrojové soubory

### ICalculation.java
Rozhraní definující kontrakt pro výpočet.

```java
public interface ICalculation {
    /**
     * Metoda pro provedení výpočtu se dvěma parametry.
     */
    int execute(int x, int y);
}
```

### Addition.java
Konkrétní implementace rozhraní pro sčítání dvou čísel.

```java
public class Addition implements ICalculation {
    @Override
    public int execute(int x, int y) {
        return x + y;
    }
}
```

### Subtraction.java
Konkrétní implementace rozhraní pro odčítání dvou čísel.

```java
public class Subtraction implements ICalculation {
    @Override
    public int execute(int x, int y) {
        return x - y;
    }
}
```

### Calculator.java
Použití polymorfismu pro spuštění různých výpočtů.

```java
public class Calculator {
    public static void main(String[] args) {
        // Použití proměnné typu rozhraní pro různé implementace
        ICalculation op1 = new Addition();
        ICalculation op2 = new Subtraction();

        System.out.println("Výsledek sčítání (10 + 5): " + op1.execute(10, 5));
        System.out.println("Výsledek odčítání (10 - 5): " + op2.execute(10, 5));
    }
}
```

> [!TIP]
> Rozhraní jsou základem pro tvorbu modulárního a testovatelného kódu. Pomocí nich můžete v testech snadno nahradit skutečné komponenty (např. databázi) tzv. "mock" objekty.

[Zpět na přehled](../../README.md)


[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../README.md)
