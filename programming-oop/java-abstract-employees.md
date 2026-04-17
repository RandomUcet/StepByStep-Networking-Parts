# Abstraktní třídy — Zaměstnanci (Java)

>  **Tip pro Programování:** I když píšete cvičné projekty, zvykněte si názvy proměnných, tříd a metod psát v angličtině. Budete pak mít podstatně jednodušší orientaci v kódu, až budete řešit chyby přes zahraniční IT diskuze a návody.


Tento projekt demonstruje dědičnost a polymorfní chování pomocí abstraktní základní třídy `Employee` (Zaměstnanec). Každý podtyp zaměstnance implementuje svou vlastní verzi metody `work()` (pracovat).

## Klíčové koncepty

### Abstraktní třída (Abstract Class)
Abstraktní třída je třída, ze které nelze vytvořit přímou instanci (objekt). Slouží jako šablona pro ostatní třídy. Může obsahovat jak konkrétní metody s implementací, tak abstraktní metody bez těla, které **musí** být implementovány v potomcích.

### Dědičnost (Inheritance)
V Javě se dědičnost realizuje pomocí klíčového slova `extends`. Potomek přebírá všechny (ne-soukromé) atributy a metody svého rodiče, což podporuje znovupoužitelnost kódu.

### Polymorfismus (Polymorphism)
Polymorfismus (mnohotvárnost) umožňuje přistupovat k různým objektům jednotným způsobem. V tomto příkladu můžeme mít pole typu `Employee[]`, které obsahuje objekty tříd `Director` i `Secretary`. Když zavoláme metodu `work()`, Java automaticky rozhodne, která konkrétní implementace se má spustit, podle skutečného typu objektu za běhu programu.

### Překrývání metod (@Override)
Anotace `@Override` informuje kompilátor, že metoda v potomkovi má nahradit (překrýt) metodu definovanou v rodičovské třídě. Je to užitečný nástroj pro kontrolu chyb při psaní kódu.

## Zdrojové soubory

### Employee.java
Abstraktní základní třída pro všechny typy zaměstnanců.

```java
public abstract class Employee {
    protected String name;
    protected int age;

    public Employee(String name, int age) {
        this.name = name;
        this.age = age;
    }

    /**
     * Abstraktní metoda — nemá tělo. 
     * Každý konkrétní potomek MUSÍ tuto metodu implementovat.
     */
    public abstract void work();

    /**
     * Společná implementace pro všechny podtřídy.
     */
    public void sayHello() {
        System.out.println("Ahoj, jmenuji se " + name + " a je mi " + age + " let.");
    }

    public String getName() { return name; }
    public void setName(String name) { this.name = name; }
    public int getAge() { return age; }
    public void setAge(int age) { this.age = age; }
}
```

### Director.java
Ředitel (Director) spravuje pole ostatních zaměstnanců.

```java
public class Director extends Employee {
    private Employee[] employees;

    public Director(String name, int age, Employee[] employees) {
        super(name, age); // Volání konstruktoru rodičovské třídy
        this.employees = employees;
    }

    @Override
    public void work() {
        System.out.println("Právě řídím tyto zaměstnance: ");
        for (int i = 0; i < employees.length; i++) {
            if (i != 0) System.out.print(", ");
            System.out.print(employees[i].getName());
        }
        System.out.println();
    }
}
```

### Secretary.java
Sekretářka (Secretary) má svou specifickou implementaci práce.

```java
public class Secretary extends Employee {

    public Secretary(String name, int age) {
        super(name, age);
    }

    @Override
    public void work() {
        System.out.println("Připravuji reporty a plánuji schůzky.");
    }
}
```

> [!NOTE]
> Klíčové slovo `super` v konstruktoru potomka slouží k předání parametrů konstruktoru rodičovské třídy. Musí to být vždy první příkaz v konstruktoru potomka.

[Zpět na přehled](../../README.md)


[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../README.md)
