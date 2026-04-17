# Výčtový typ (Enum) — Týdenní rozvrh (Java)

>  **Tip pro Programování:** I když píšete cvičné projekty, zvykněte si názvy proměnných, tříd a metod psát v angličtině. Budete pak mít podstatně jednodušší orientaci v kódu, až budete řešit chyby přes zahraniční IT diskuze a návody.


Tento projekt demonstruje použití výčtového typu `Enum` v jazyce Java pro reprezentaci týdenního rozvrhu. Java Enums nejsou jen prosté konstanty, ale plnohodnotné třídy s konstruktory a metodami.

## Klíčové koncepty

### Výčtový typ (Enum)
`Enum` je speciální druh třídy, který definuje pevnou sadu konstant. Používá se pro veličiny, u kterých známe všechny možné hodnoty předem (např. dny v týdnu, barvy semaforu, úrovně oprávnění).

### Konstruktor Enumu (Enum Constructor)
Enumy v Javě mohou mít pole (atributy) a konstruktory, které tyto atributy inicializují pro každou konstantu. Konstruktory enumů jsou **vždy privátní** — nelze tedy vytvořit novou instanci enumu jinde než v jeho definici.

### Metody Enumu (Enum Methods)
Protože je `Enum` třída, může obsahovat libovolné metody, které poskytují funkčnost na základě aktuální hodnoty konstanty. To umožňuje zapouzdřit logiku přímo k daným datům.

## Zdrojové soubory

### Day.java
Výčet reprezentující dny v týdnu s přidruženými údaji o rozvrhu.

```java
public enum Day {
    MONDAY("", ""),
    TUESDAY("09:20", "11:30"),
    WEDNESDAY("10:00", "14:00"),
    THURSDAY("", ""),
    FRIDAY("08:00", "12:00"),
    SATURDAY("", ""),
    SUNDAY("", "");

    private final String startTime;
    private final String endTime;

    // Konstruktory enumu jsou vždy automaticky privátní
    private Day(String start, String end) {
        this.startTime = start;
        this.endTime = end;
    }

    public String getSchedule() {
        if (startTime.isEmpty()) {
            return "Žádná výuka není naplánována.";
        }
        return "Od " + startTime + " do " + endTime;
    }
}
```

### ScheduleManager.java
Třída využívající Enum k zobrazení týdenního rozvrhu.

```java
public class ScheduleManager {
    public static void main(String[] args) {
        // Metoda values() vrací pole všech konstant daného enumu
        for (Day d : Day.values()) {
            System.out.println(d + ": " + d.getSchedule());
        }

        Day today = Day.TUESDAY;
        if (today == Day.TUESDAY) {
            System.out.println("Připomenutí: Trénink začíná v 09:20!");
        }
    }
}
```

> [!TIP]
> Pro porovnávání hodnot enumu je v Javě bezpečné používat operátor `==` místo metody `.equals()`, protože každá konstanta enumu je v paměti unikátní (singleton).

[Zpět na přehled](../../README.md)


[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../README.md)
