# BRICK SORT3R – Třídička kostek LEGO (EV3)

>  **Tip pro Robotiku EV3:** Než začnete testovat složitější programy na podlaze (např. s gyroskopem), zkontrolujte baterii v kostce EV3. Slabá baterie naprosto běžně způsobuje zdánlivě náhodné odpojování senzorů a nebo celkově slabý tah motorů.

Sestavte a naprogramujte tovární linku BRICK SORT3R, která automaticky posouvá LEGO kostky na dopravníkovém pásu, přečte jejich barvu pomocí senzoru a rotujícím ramenem je zatřídí do správné přihrádky. Vynikající model pro výuku automatizace a práce s více barvami.

## 1. Oficiální stavební instrukce (Color Sorter)

Nezačínejte model od nuly, mechanismus rotujícího ramene vyžaduje přesné napojení ozubených kol, aby se rameno nepřetáčelo. Model využívá součástky výhradně ze základní sady **LEGO MINDSTORMS Education EV3 Core Set (45544)**.

**Kde najít přesný návod ke stavbě:**
1. Otevřete oficiální stránku LEGO Education: [Building Instructions pro EV3](https://education.lego.com/en-us/product-resources/mindstorms-ev3/downloads/building-instructions/)
2. V sekci **Core Set Models** vyhledejte model s názvem **Color Sorter**.
3. Stáhněte si PDF dokument s detailním ilustrovaným návodem a model sestavte.
4. Připravte si několik barevných LEGO dílků (ideálně červený, modrý, žlutý a zelený 2x4 nebo 2x2 klasické kostky).

## 2. Hardwarové zapojení a mechanika

Dle oficiálního schématu modelu Color Sorter se používají následující zapojení (vždy si ověřte podle svého návodu):
*   **Dopravníkový pás (Motor posuvu):** Velký motor (Large Motor 45502) obvykle v **Portu B** nebo **C**.
*   **Třídící rameno (Výhybka):** Střední motor (Medium Motor 45503) v **Portu A**. Tento motor využívá přesný převod na ozubené kolo k otočení ramene doleva, doprava, nebo rovně.
*   **Barevný senzor (Color Sensor 45506):** Patří do **Portu 3**. Dívá se shora přímo na pohybující se kostky na pásu.

## 3. Výběr softwarového prostředí

Pro tento projekt zcela dostačuje blokové programování, ideálně moderní **EV3 Classroom**.

*   Můžete postupovat podle základních lekcí integrovaných přímo do aplikace EV3 Classroom, nebo se podívat na komunitní weby jako [ev3lessons.com](https://ev3lessons.com/), které nabízí hotové materiály pro tyto výukové modely.
*   Projekt je také skvělým kandidátem pro přepis do jazyka Python (MicroPython na [ev3dev](https://www.ev3dev.org/)), kde si můžete vytvořit pole (List/Array) oblíbených barev a programově přes něj iterovat.

## 4. Logika programu a ID barev

Při programování v blocích nebudeme pracovat s odraženým světlem (jako u Sledování čáry), ale s režimem **Color Mode (Měření barvy)**. Senzor tak přímo vrací číselné ID barvy. 

| ID | Česky | Anglicky | Akce výhybky (Příklad) |
| :--- | :--- | :--- | :--- |
| **0** | Žádná | No Color | Pás jede, čeká se. |
| **2** | Modrá | Blue | Rameno se otočí doleva na -45°. |
| **3** | Zelená | Green | Rameno se otočí doleva na -90°. |
| **4** | Žlutá | Yellow | Rameno se otočí doprava na +45°. |
| **5** | Červená | Red | Rameno se otočí doprava na +90°. |

### Hlavní algoritmus (Nekonečná smyčka)
1.  **Start:** Spusť motor pásu pomalou rychlostí (např. 20 %).
2.  **Čekej:** Použijte blok "Čekej dokud" (Wait until). Čekej, dokud Senzor Barvy nevidí barvu > 0.
3.  **Zastav:** Jakmile je detekována barva, zastav motor pásu, aby kostka neodjela mimo dosah ramene.
4.  **Podmínky (If/Else Switch):**
    *   Pokud Barva = 2 (Modrá): Roztoč Střední motor o -45 stupňů (přepnutí výhybky).
    *   Pokud Barva = 5 (Červená): Roztoč Střední motor o +90 stupňů (přepnutí výhybky).
5.  **Posun:** Rozjeď motor pásu na 1 sekundu (kostka sjede do vybrané přihrádky po výhybce).
6.  **Návrat:** Vrať střední motor na výchozí pozici 0 stupňů a celý cyklus se opakuje.

## Řešení problémů (FAQ)

**Senzor hlásí nesprávné barvy nebo nic nevidí.**
Zkontrolujte okolní osvětlení místnosti. Přímé prudké sluneční světlo nebo naopak temné stíny mohou barevný senzor EV3 velmi snadno zmást. Pokud problém přetrvává, můžete kolem senzoru přistavět "stříšku" z pár LEGO kostek, která odruší vnější světlo. Dbejte na to, aby senzor těsně neléhal na kostku (ideální vzdálenost je cca 1-2 cm nad ní).

**Kostky se na pásu zasekávají nebo poskakují.**
Zkontrolujte zarovnání ozubených kol a pásů (tzv. "Caterpillar tracks"). Pás by neměl být ani příliš napnutý (motory se budou trápit), ani příliš volný (bude přeskakovat). Snižte rychlost motoru dopravníku (ideální je rychlost mezi 10–25 %).

---

[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../README.md)