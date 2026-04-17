# Generická třída Barva<T> (Java)

>  **Tip pro Programování:** I když píšete cvičné projekty, zvykněte si názvy proměnných, tříd a metod psát v angličtině. Budete pak mít podstatně jednodušší orientaci v kódu, až budete řešit chyby přes zahraniční IT diskuze a návody.


Tento projekt ilustruje použití generik (Generics) v jazyce Java. Třída `ColorRepresenter<T>` umožňuje reprezentovat barvu pomocí libovolného datového typu – například jako řetězec (String), objekt `java.awt.Color` nebo celočíselnou RGB hodnotu (Integer).

## Klíčové koncepty

### Generika (Generics)
Generika umožňují psát třídy, rozhraní a metody, které pracují s datovými typy jako s parametry. To znamená, že jedna třída může sloužit pro různé typy objektů, aniž bychom museli psát samostatnou verzi pro každý z nich (vyhneme se tak duplicitě kódu).

### Typová bezpečnost (Type Safety)
Hlavním přínosem generik je, že chyby v typech odhalí kompilátor už při překladu, nikoliv až za běhu programu (runtime). Odstraňují potřebu explicitního přetypování (casting), což činí kód bezpečnějším a čitelnějším.

### Typový parametr (Type Parameter)
V zápisu `ColorRepresenter<T>` je `T` tzv. zástupný symbol pro typ. Při vytváření instance (např. `new ColorRepresenter<String>("Žlutá")`) se tento symbol nahradí konkrétním typem.

## Zdrojové soubory

### ColorRepresenter.java
Generická třída, která uchovává hodnotu barvy libovolného typu.

```java
/**
 * T je typový parametr — při použití bude nahrazen konkrétním typem.
 */
class ColorRepresenter<T> {
    private T color;

    public ColorRepresenter(T color) {
        this.color = color;
    }

    public void setColor(T color) {
        this.color = color;
    }

    public T getColor() {
        return this.color;
    }
}
```

### Main.java
Demonstrace použití generické třídy s různými datovými typy.

```java
import java.awt.Color;

public class Main {
    public static void main(String[] args) {
        // Reprezentace pomocí řetězce (String)
        ColorRepresenter<String> c1 = new ColorRepresenter<>("Žlutá");
        System.out.println("Textová barva: " + c1.getColor());

        // Reprezentace pomocí objektu java.awt.Color
        ColorRepresenter<Color> c2 = new ColorRepresenter<>(Color.RED);
        System.out.println("Objekt barvy: " + c2.getColor());

        // Reprezentace pomocí celého čísla (Integer - RGB)
        ColorRepresenter<Integer> c3 = new ColorRepresenter<>(0xFF00FF);
        System.out.println("RGB hodnota: " + c3.getColor());
    }
}
```

> [!NOTE]
> Operátor `<>` (tzv. diamond operator) v kódu `new ColorRepresenter<>()` umožňuje kompilátoru automaticky odvodit typový parametr z deklarace proměnné, čímž zkracuje zápis.

[Zpět na přehled](../../README.md)


[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../README.md)
