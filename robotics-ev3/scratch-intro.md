# EV3 Classroom (Scratch) – Úvod do programování robotů

>  **Tip pro Robotiku EV3:** Než začnete testovat složitější programy na podlaze (např. s gyroskopem), zkontrolujte baterii v kostce EV3. Slabá baterie naprosto běžně způsobuje zdánlivě náhodné odpojování senzorů a nebo celkově slabý tah motorů.

LEGO plně přešlo ze svého starého prostředí (EV3 Lab s ikonkami) na moderní **EV3 Classroom**. Tato aplikace je založena výhradně na jazyce Scratch. Je to grafické programování pomocí barevných spojovacích bloků. Jde o ideální první krok k pochopení programovací logiky dříve, než přejdete na MicroPython (textový kód).

## 1. Stažení a instalace EV3 Classroom

Nemusíte používat webový Scratch a složitě ho párovat. LEGO vydalo ucelenou samostatnou aplikaci určenou přímo pro výuku na počítačích a tabletech.

**Kde aplikaci získat:**
1. Ve Windows otevřete aplikaci **Microsoft Store** a vyhledejte *EV3 Classroom*. Nebo využijte [oficiální stránky LEGO Education Software](https://education.lego.com/en-us/downloads/mindstorms-ev3/software/).
2. Aplikaci nainstalujte a spusťte. 
3. Hned po startu vám aplikace nabídne rozsáhlé výukové lekce, kde naleznete interaktivní návody včetně videí.

## 2. Připojení kostky (Párování)

Abyste mohli z počítače posílat do robota vytvořené bloky kódu, musíte kostku propojit s aplikací.

*   **USB Kabelem:** Nejspolehlivější a nejrychlejší metoda. Prostě zapojte standardní USB-Mini kabel dodávaný v krabici (Port "PC" na kostce do USB v počítači). Zelená ikona kostky vpravo nahoře v aplikaci se ihned rozsvítí.
*   **Přes Bluetooth (Bezdrátově):**
    1. Na EV3 kostce přejděte v menu (ikona klíče) do nastavení Bluetooth a povolte: *Bluetooth*, *Visibility* (Viditelnost).
    2. V aplikaci EV3 Classroom klikněte vpravo nahoře na "Connect" (Připojit) a vyberte záložku Bluetooth. Vaše kostka by se zde měla objevit.
    3. Pokud připojujete robota poprvé, kostka vás požádá o heslo (standardně 1234), které potvrdíte prostředním tlačítkem. Na počítači toto heslo opiště do Windows vyskakovacího okna.

## 3. Seznámení s rozhraním a Základní bloky

Levý sloupec v aplikaci EV3 Classroom obsahuje barevné palety bloků. Všechny do sebe zapadají jako puzzle. Pokud do sebe tvarově nepasují, děláte syntaktickou chybu!

### Základní palety pro EV3:
*   **Motors (Modré):** Ovládání samostatných motorů. Ideální na různé jeřáby, kleště a ramena (např. *Roztoč motor A o 90 stupňů*).
*   **Movement (Růžové):** Synchronizovaný pohyb pro jezdící roboty. Využívá dva motory zaráz, aby robot jel rovně nebo plynule zatáčel (např. *Jeď rovně 2 otáčky kola s motory B a C*).
*   **Sensors (Světle modré okrouhlé bloky):** Vrací data z okolí. Nepropojují se pod sebe, ale vkládají se do děr v jiných blocích (např. "Hodnota ze senzoru v Portu 3").
*   **Control (Oranžové):** Cykly, podmínky a pauzy. Najdete tu bloky jako *Opakuj navždy*, *Opakuj 10krát* nebo *Když - Tak* (If-Else).

## 4. Váš první program: Jezdi do čtverce

Nejlepší pro test je robot typu "Driving Base" (s motory v portech B a C). Zkuste v editoru postavit tuto strukturu, aby robot vykreslil na zemi přesný čtverec:

1. Z palety **Events (Žlutá)** vezměte úvodní blok `Při startu programu`.
2. Z palety **Control (Oranžová)** vezměte blok `Opakuj X krát` a změňte hodnotu na 4. (Tím vytvoříte cyklus).
3. Do vnitřku této oranžové "kapsy" vložte z palety **Movement (Růžová)** blok `Jeď vpřed na 2 otáčky`.
4. Pod něj (stále dovnitř oranžové kapsy) vložte růžový blok `Otoč se vpravo o 0.5 otáčky` (Zde budete muset chvíli ladit desetinná místa, než najdete hodnotu odpovídající přesnému úhlu 90 stupňů rotace vašeho fyzického robota na daném povrchu).
5. Klikněte na žluté tlačítko Play (Stáhnout a Spustit) v pravém dolním rohu aplikace.

## Řešení problémů (FAQ)

**Scratch se nechce připojit k LEGO kostce přes Bluetooth.**
Ve Windows 10/11 se někdy rozbije párovací služba. Otevřete systémové nastavení Windows -> Bluetooth a jiná zařízení. Najděte "EV3" a dejte "Odebrat zařízení". Následně vyzkoušejte nové párování v aplikaci EV3 Classroom od začátku. Také se přesvědčte, že máte v kostce zapnutou "Visibility" (Bez ní kostka Bluetooth sice vysílá, ale odmítá nová párování).

**Skript se spustí, program běží a nic se neděje.**
Zkontrolujte panel **Port View** (ikonka kostky vpravo nahoře). Mnoho chyb vzniká tím, že v softwaru ovládáte např. motor A, ale v reálu máte kabel píchnutý do portu B. Paleta *Movement* standardně pracuje s porty B a C.

## Užitečné materiály a odkazy

*   [Robofest EV3 Scratch Workshop (PDF)](https://www.robofest.net/images/2122/LegoEV3ScratchGameWorkshop2022.pdf) - Skvělá a detailní anglická prezentace. Od naprostých základů prostředí až po složitější logické hry, využití proměnných a přesnou manipulaci s motory a senzory v EV3 Scratch.
*   [Oficiální Scratch EV3](https://scratch.mit.edu/ev3) - Pokud si přece jen chcete zkusit propojit EV3 přímo přes webový prohlížeč s původním platformou Scratch, zde najdete oficiální návod a rozšíření.
*   [EV3Lessons (Classroom)](https://ev3lessons.com/en/Lessons.html) - Globální komunita s vynikajícími lekcemi přesně roztříděnými pro prostředí EV3 Classroom (od začátečníků až po experty v soutěžích First Lego League).

---

[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../README.md)