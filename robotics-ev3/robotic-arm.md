# Robotické rameno – Pick and Place (EV3)

>  **Tip pro Robotiku EV3:** Než začnete testovat složitější programy na podlaze (např. s gyroskopem), zkontrolujte baterii v kostce EV3. Slabá baterie naprosto běžně způsobuje zdánlivě náhodné odpojování senzorů a nebo celkově slabý tah motorů.

Sestavte a naprogramujte robotické rameno (Robot Arm H25) s EV3, které dokáže samo zvednout předmět z jednoho místa a přemístit ho na jiné. Jedná se o fantastický projekt pro pochopení kinematiky, úhlů motorů a souřadnicových systémů.

## 1. Oficiální stavební instrukce (Robot Arm H25)

Pro nejlepší funkčnost využijte oficiální model **Robot Arm H25** určený pro sadu **LEGO MINDSTORMS Education EV3 Core Set (45544)**.

**Kde najít přesný návod ke stavbě:**
1. Otevřete oficiální stránku LEGO Education: [Building Instructions pro EV3](https://education.lego.com/en-us/product-resources/mindstorms-ev3/downloads/building-instructions/)
2. V sekci **Core Set Models** vyhledejte model s názvem **Robot Arm H25**.
3. Stáhněte si PDF dokument.
4. Model je poměrně velký a robustní, dbejte na dobré ukotvení na stole. Konstrukce obsahuje velmi chytrý systém protizávaží pomocí pevných LEGO dílků vzadu, takže rameno nepřepadává.

## 2. Hardwarové zapojení a mechanika

Model využívá tři motory pro pohyb ve třech osách:
*   **Rotace podstavce:** Velký motor (Large Motor 45502) zapojený do **Portu A**. Tento motor otáčí celým ramenem kolem svislé osy (zleva doprava).
*   **Zdvih ramene:** Velký motor (Large Motor 45502) zapojený do **Portu B**. Zvedá rameno nahoru a dolů.
*   **Kleště (Grip):** Střední motor (Medium Motor 45503) zapojený do **Portu C**. Otevírá a zavírá čelisti kleští.
*   **Dotykový senzor:** V modelu je často zakomponován dotykový senzor (Port 1) pro určení výchozí pozice ramene (aby si motor "sáhl" na dno a věděl, kde je nula).

## 3. Logika programu: Kalibrace a Enkodéry

Programování ramene v softwaru **EV3 Classroom** vyžaduje pochopení enkodérů (měřičů natočení motoru). Nemůžete používat čas (např. "toč se 1 sekundu"), protože s vybitou baterií by se rameno otočilo méně. Musíte používat přesné stupně.

**A) Kalibrace na začátku programu:**
Než rameno začne něco přenášet, musí se "zorientovat".
1. Roztočte motor B dolů nízkou rychlostí (10 %).
2. Počkejte, dokud se nestiskne dotykový senzor.
3. Zastavte motor B.
4. V programu vynulujte čítač stupňů pro motor B (v EV3 Classroom slouží k tomuto resetovací bloky motorů). 
5. Toto je nyní "Nula" neboli "Podlaha".

**B) Získání přesných souřadnic cíle:**
Klíčový trik pro usnadnění práce: Nehádejte stupně!
1. V softwaru si zobrazte záložku **Port View** (živý náhled hodnot senzorů a motorů z připojené kostky).
2. Rukou opatrně posuňte rameno robota nad předmět, který chcete zvednout.
3. Podívejte se do Port View v softwaru a opište si úhel motoru A (např. -85°) a úhel motoru B (např. 120°). 
4. Tyto úhly následně zapište do svého programu jako cílové parametry do bloků "Roztoč motor na pozici...".

## 4. Algoritmus Pick and Place (Přenes a Polož)

Vytvořte sekvenci (ideálně si pro každý krok vytvořte vlastní "Můj blok" neboli funkci pro zpřehlednění kódu):

1. **Start:** Zkalibruj pozice a otevři kleště (Motor C na pozici 0).
2. **Přesun nad cíl:** Otoč Motor A na uloženou pozici X (nad předmět).
3. **Spuštění:** Spusť Motor B dolů na pozici Y (těsně nad předmět).
4. **Úchop:** Otoč Motor C pro zavření kleští (např. +150°). 
   * *Tip:* Aby se motor nesnažil marně mačkat dál, nastavte blok na zavření s výkonem např. 20 %, jinak se motor zasekne a program nepokročí dál.
5. **Zdvih:** Vytáhni Motor B zpět do bezpečné výšky (např. +300°).
6. **Otočení na místo B:** Otoč Motor A na cílovou pozici pro vyložení (např. +85°).
7. **Vyložení:** Spusť Motor B dolů, otevři kleště (Motor C na 0).
8. **Návrat:** Vrať se do domovské/bezpečné pozice.

## Řešení problémů (FAQ)

**Rameno se pohybuje nepřesně – pozice se pokaždé mění a časem ujíždí mimo stůl.**
Toto je nejčastější chyba. Ujistěte se, že používáte bloky pro pohyb na **konkrétní cílovou pozici** motoru (Move to Position / Run to Absolute Position), nikoliv bloky pro "Otoč se o..." (Run for Degrees). Pokud používáte relativní otáčení, každá malá nepřesnost se sčítá a pozice ujíždí. Absolutní pozice tento problém eliminuje.

**Kleště nedrží předměty a ty vypadávají.**
Předmět nesmí být příliš těžký (zkuste prázdnou plechovku, papírovou krabičku, nebo standardní přiložené kolečko LEGO pneumatiky z Core setu). Na čelisti kleští přidejte gumičky pro zvýšení tření.

---

[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../README.md)