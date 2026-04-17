# Sledování čáry (EV3 Line Follower)

>  **Tip pro Robotiku EV3:** Než začnete testovat složitější programy na podlaze (např. s gyroskopem), zkontrolujte baterii v kostce EV3. Slabá baterie naprosto běžně způsobuje zdánlivě náhodné odpojování senzorů a nebo celkově slabý tah motorů.

Sestavte robota, který sleduje černou čáru na bílém podkladu pomocí EV3 Barevného senzoru (Color Sensor 45506). Jde o naprosto klasický a nejdůležitější projekt pro pochopení principů zpětnovazebního řízení a PID regulace.

## 1. Oficiální stavební instrukce (Driving Base)

Pro sledování čáry je nejlepší využít univerzální podvozek (Driving Base) ze sady **LEGO MINDSTORMS Education EV3 Core Set (45544)**. Pokud byste stavěli podvozek od nuly, musíte řešit těžiště a správný převod. Mnohem lepší je vyjít z oficiálního modelu.

**Kde najít přesný návod ke stavbě:**
1. Otevřete oficiální stránku LEGO Education: [Building Instructions pro EV3](https://education.lego.com/en-us/product-resources/mindstorms-ev3/downloads/building-instructions/)
2. V sekci **Core Set Models** vyhledejte model **Driving Base**.
3. Stáhněte si PDF dokument.
4. Následně si ve stejné sekci stáhněte rozšiřující PDF s názvem **Color Sensor Down** (Barevný senzor směřující dolů).
5. Podle těchto dvou PDF sestavte základního robota.

## 2. Hardwarové zapojení a příprava

*   **Motory:** Levé kolo (Large Motor 45502) zapojte do **Portu B**, pravé kolo do **Portu C**. Toto je průmyslový standard pro EV3.
*   **Senzor:** Barevný senzor (Color Sensor) zapojte kabelem do **Portu 3**. Senzor musí směřovat přesně kolmo dolů, cca 1–1,5 cm nad povrch podložky.
*   **Dráha:** Použijte ideálně bílý papír nebo banner a nalepte na něj černou izolační pásku (šířka cca 2-3 cm). Vyhněte se na začátku pravoúhlým zatáčkám.

## 3. Výběr softwarového prostředí

Abyste mohli robota naprogramovat, potřebujete aplikaci. Doporučujeme dvě cesty:
*   **EV3 Classroom:** (Doporučeno pro začátečníky) Aplikace založená na blocích typu Scratch. Ke stažení na Microsoft Store nebo přes [oficiální stránky LEGO Education](https://education.lego.com/en-us/downloads/mindstorms-ev3/software/).
*   **MicroPython / ev3dev:** (Pro pokročilé) Návody a image na MicroSD kartu najdete na [ev3dev.org](https://www.ev3dev.org/projects/). Skvělé pro programování v klasickém kódu (Python).

## 4. Logika a programování v EV3 Classroom

Aby robot dokázal sledovat čáru hladce, nesmí fungovat jen stylem zapnuto/vypnuto, ale musí používat alespoň proporcionální řízení (P-regulátor).

### Fáze 1: Kalibrace odraženého světla
Barevný senzor v režimu "Odražené světlo" (Reflected Light) vrací hodnoty od 0 do 100.
1. Postavte senzor nad čistě černou pásku. Přečtěte si na displeji EV3 kostky hodnotu (např. 10).
2. Postavte senzor nad bílou plochu a přečtěte hodnotu (např. 70).
3. Spočítejte střed (Threshold / Práh): `(10 + 70) / 2 = 40`. Hodnota 40 je hranice pásky, kterou chceme, aby senzor ideálně viděl (robot jede po hraně).

### Fáze 2: Výpočet chyby (Error) a Proporcionální řízení
V programu vytvořte nekonečnou smyčku (cyklus "Opakuj stále"). Uvnitř cyklu:
1. Přečti aktuální hodnotu ze senzoru (např. senzor vidí 50 - moc bílé).
2. Spočítej chybu: `Chyba = Senzor - Práh` (50 - 40 = 10).
3. Vynásob chybu konstantou (Kp), např. `0.8`. Výsledek je "Korekce".
4. Spusť motory (blok pro pohyb s řízením výkonu každého motoru zvlášť).
   * Výkon levého motoru = `Základní rychlost (např. 30) + Korekce`
   * Výkon pravého motoru = `Základní rychlost (např. 30) - Korekce`

Tento matematický vzorec zaručí, že čím více robot z čáry sjede, tím razantněji jedno kolo zrychlí a druhé zpomalí, aby se vrátil zpět. Pokud jede přesně po hraně (senzor hlásí 40, chyba je 0), oba motory pojedou rovně rychlostí 30.

## Řešení problémů (FAQ)

**Senzor nečte rozdíl mezi černou a bílou (hodnoty se téměř nemění).**
Zkontrolujte, zda máte senzor v softwaru nastavený na "Odražené světlo" (Reflected Light Intensity), a ne na měření barev (Color mode). Zkontrolujte také, že je senzor nízko nad zemí (cca 1 cm).

**Robot se na rovince silně klepe (osciluje zleva doprava).**
Vaše konstanta (Kp) pro násobení chyby je příliš vysoká. Robot reaguje přehnaně. Snižte násobitel (např. z 1.5 na 0.8).

---

[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../README.md)
