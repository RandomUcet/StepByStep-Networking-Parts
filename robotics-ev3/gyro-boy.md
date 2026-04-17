# GYRO BOY – Balancující robot (EV3)

>  **Tip pro Robotiku EV3:** Než začnete testovat složitější programy na podlaze (např. s gyroskopem), zkontrolujte baterii v kostce EV3. Slabá baterie naprosto běžně způsobuje zdánlivě náhodné odpojování senzorů a nebo celkově slabý tah motorů.

Postavte dvoukolového robota GYRO BOY, který udržuje rovnováhu (balancuje) na místě a za jízdy pouze pomocí Gyroskopického senzoru (Gyro Sensor 45505). Jde o pokročilý projekt demonstrující mechaniku invertovaného kyvadla.

## 1. Oficiální stavební instrukce (Gyro Boy)

Robot vyžaduje precizní sestavení – jakákoli změna těžiště znamená, že bude padat a fyzika rovnováhy přestane fungovat. Je proto nutné striktně dodržet originální plánek od LEGO. Ke stavbě potřebujete základní sadu **LEGO MINDSTORMS Education EV3 Core Set (45544)**.

**Kde najít přesný návod ke stavbě:**
1. Otevřete oficiální stránku LEGO Education: [Building Instructions pro EV3](https://education.lego.com/en-us/product-resources/mindstorms-ev3/downloads/building-instructions/)
2. V sekci **Core Set Models** vyhledejte model s názvem **Gyro Boy**.
3. Stáhněte si PDF dokument (obsahuje přes 80 stran velmi detailního obrázkového návodu).
4. Robotovi pečlivě sestavte nohy, paže, připojte všechny kabely přesně tam, kam návod ukazuje. Zejména dbejte na to, abyste omylem nedali dílky na jinou stranu – symetrie je klíčem k balancování.

## 2. Hardwarové zapojení a důležité detaily

*   **Motory pro rovnováhu:** Dva velké motory (Large Motor 45502). Zapojte levý motor do **Portu D**, pravý motor do **Portu A** (podle původního návodu).
*   **Paže (Design):** Střední motor (Medium Motor 45503) je připojen do **Portu C**. S jeho pomocí hýbe Gyro Boy pažemi.
*   **Senzory:**
    *   **Gyroskop (Gyro Sensor 45505):** Patří do **Portu 2**. *Kriticky důležité:* Šipka na gyroskopu musí ukazovat přesně směrem, kterým se robot naklání (dopředu/dozadu). 
    *   **Ultrazvuk (Ultrasonic Sensor 45504):** Patří do **Portu 4** (slouží jako oči).
    *   **Barevný (Color Sensor 45506):** Patří do **Portu 3** (slouží pro ovládání směru jízdy barevnými destičkami).
    *   **Dotykový (Touch Sensor 45507):** Patří do **Portu 1** (vypíná a zapíná balancování).

## 3. Výběr softwarového prostředí a kód

Naprogramovat Gyro Boye "od nuly" vyžaduje pokročilou středoškolskou / vysokoškolskou matematiku (komplexní PID smyčky, filtrování dat, počítání integrálů z gyroskopu a enkodérů motorů zaráz). 

Pro rychlý úspěch a učení se doporučují následující cesty:

**A) Hotový projekt v MicroPython / ev3dev**
Komunita open-source systému ev3dev vytvořila perfektní kopii originálního programu v jazyce Python. 
1. Nainstalujte si na MicroSD kartu systém ev3dev podle návodu na [ev3dev.org](https://www.ev3dev.org/).
2. Najděte si ukázkový projekt přímo na jejich GitHubu nebo v sekci [ev3dev Python Projects](https://github.com/ev3dev/ev3dev-lang-python/tree/master/demo/gyro-boy). 
3. Kód zkopírujte, spusťte ve svém robotovi a můžete sledovat, jak perfektně funguje PID logika pro balancování napsaná v Pythonu.

**B) Původní blokový software (EV3 Lab / MINDSTORMS Home)**
Původní starý software LEGO MINDSTORMS EV3 Lab (ten s šedým pozadím) obsahoval projekt Gyro Boy s už předpřipraveným speciálním "balancovacím blokem". V novém EV3 Classroom bohužel tento speciální matematický blok chybí, proto je Gyro Boy v nejnovějším blokovém prostředí obtížně hratelný bez psaní vlastních matematických filtrů.

## 4. Spuštění a kalibrace – Největší chyták

Ať už spustíte Python nebo původní program, narazíte na stejný problém s gyroskopem: **Drift**. Gyroskop neustále čte malé odchylky i když se nehýbe, a tyto odchylky se sčítají.

**Jak správně odstartovat robota:**
1. Postavte Gyro Boye do dokovací stanice (malá podpěra pod něj, kterou jste si postavili z dílků podle návodu) nebo jej pevně chytněte oběma rukama, aby stál **absolutně svisle a bez pohnutí**.
2. Spusťte program.
3. *V tuto chvíli s ním nesmíte ani o milimetr pohnout!* Program si během prvních 2 až 3 sekund sahá na gyroskop a říká mu: "Tato poloha je nula (0 stupňů)".
4. Pokud se robot během kalibrace pohne, nastaví si svou "nulu" nakřivo a okamžitě po uvolnění začne neřízeně ujíždět dopředu nebo spadne dozadu.

## Řešení problémů (FAQ)

**Robot hned po spuštění spadne a ani se nepokusí balancovat.**
Prověřte orientaci gyroskopu (zda šipka ukazuje vpřed/vzad, a ne do boku). Zkontrolujte naprosto přesné obsazení portů (Levý motor D, Pravý A). Ujistěte se, že byl robot během kalibrace opravdu v klidu.

**Robot balancuje, ale po chvíli začne prudce couvat nebo ujíždět vpřed (driftuje).**
Máte na senzoru tzw. hardware drift. Zkuste za chodu vytáhnout kabel z gyroskopického senzoru a znovu ho zapojit. Tím dojde k jeho hardwarovému tvrdému restartu. Následně znovu spusťte program s dokonale nehybným robotem. Zkontrolujte také nabití baterie EV3 kostky – slabá baterie je častým důvodem špatných výpočtů a ztráty výkonu.

---

[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../README.md)