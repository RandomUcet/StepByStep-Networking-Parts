# Základní pojmy a výbava robota

>  **Tip pro Robotiku EV3:** Než začnete testovat složitější programy na podlaze (např. s gyroskopem), zkontrolujte baterii v kostce EV3. Slabá baterie naprosto běžně způsobuje zdánlivě náhodné odpojování senzorů a nebo celkově slabý tah motorů.

Tento dokument je stručným průvodcem teoretickými základy robotiky. Shrnujeme zde základní pojmy, se kterými se v tomto oboru nevyhnutelně potkáte, a také detailní přehled softwarové a hardwarové výbavy platformy LEGO MINDSTORMS EV3, která slouží jako vynikající odrazový můstek pro vzdělávání.

## 1. Základní pojmy v oblasti robotiky

Robotika je interdisciplinární obor, který kombinuje mechaniku, elektroniku a informatiku (programování). 

*   **Robot:** Stroj s vlastním pohonem, který je schopen provádět fyzické úkony podle vloženého programu. Robot se vyznačuje schopností reagovat na okolní prostředí (pomocí senzorů) a činit na jejich základě rozhodnutí.
*   **Autonomie:** Míra toho, nakolik dokáže robot plnit úkoly sám bez lidského zásahu. (Např. autíčko na dálkové ovládání není autonomní robot, robotický vysavač ano).
*   **Aktuátor (Pohon / Efektor):** Část robota zodpovědná za pohyb. Nejčastěji jde o elektrické motory, servomotory, ale mohou to být i hydraulické nebo pneumatické písty.
*   **Senzor (Snímač):** Převodník, který měří neelektrickou fyzikální veličinu z okolního světa (např. teplotu, vzdálenost, barvu) a převádí ji na elektrický signál, kterému rozumí procesor.
*   **Mikrokontrolér (Mozek / Řídící jednotka):** Počítač na jednom čipu. Přijímá data ze senzorů, zpracovává je podle naprogramovaného kódu a vysílá příkazy aktuátorům.
*   **Zpětnovazební smyčka (Feedback loop):** Koncept, kdy robot provede akci, ihned změří senzorikou výsledek této akce, a na jeho základě akci upraví (např. PID regulátor).

## 2. Hardwarová výbava robota (na příkladu EV3)

U vzdělávací sady LEGO MINDSTORMS EV3 je veškerý hardware striktně rozdělen na mozek, senzory a motory, se standardizovaným zapojením.

### Řídící jednotka (EV3 Brick)
Chytrá kostka (Brick) je mozkem celého systému. Má malý displej, sadu tlačítek, a zabudovaný reproduktor. 
Běží na operačním systému vycházejícím z Linuxu a obsahuje 4 vstupní porty pro senzory (číslované 1, 2, 3, 4) a 4 výstupní porty pro motory (písmena A, B, C, D).

### Senzory (Sensors) - Vstupy
*   **Dotykový senzor (Touch Sensor):** Detekuje stisk, uvolnění nebo "náraz". (Použití: Nalezení zdi, kalibrace výchozí pozice ramene).
*   **Barevný / Světelný senzor (Color Sensor):** Měří odrazivost okolního světla (pro čtení černé čáry), nebo přímo vrací číslo ID detekované barvy.
*   **Ultrazvukový senzor (Ultrasonic Sensor):** Funguje jako sonar u netopýrů – vysílá zvukové vlny a měří dobu jejich odrazu. Zjišťuje vzdálenost překážek v centimetrech.
*   **Gyroskopický senzor (Gyro Sensor):** Měří rotaci a úhel natočení. Extrémně důležitý u modelů, které musí balancovat, nebo se točit o přesný počet stupňů bez ohledu na klouzání kol na podlaze.

### Aktuátory - Výstupy
*   **Velký motor (Large Motor):** Robustní a silný, ale trochu pomalejší. Má zabudovaný enkodér (měří si vlastní rotaci v obřím rozlišení na jeden stupeň). Určen pro pohon pojezdových kol.
*   **Střední motor (Medium Motor):** Menší, slabší, ale velmi rychlý. Využívá se na vystřelovací mechanismy, pohyb ramen, hlavy a otevírání kleští.

## 3. Softwarová výbava robota (EV3)

Robot by bez softwaru byl jen hromada plastu a drátků. Pro komunikaci a programování se používá různá softwarová výbava odlišná podle zkušenosti uživatelů:

1. **Firmware v kostce:** Operační systém obsažený přímo v řídící jednotce. Lze jej aktualizovat, případně úplně nahradit (např. nahráním OS *ev3dev* přes MicroSD kartu, čímž EV3 získá plnohodnotný Debian Linux a podporu Pythonu).
2. **EV3 Classroom (Základní vývojové prostředí):** Oficiální aplikace postavená na Scratch blokovém systému. Nabízí velmi snadné spouštění po kliknutí, párování přes Bluetooth nebo kabel.
3. **C# / Python (Pokročilý vývoj):** EV3 není uzamčená hračka. Po instalaci neoficiálních prostředí a připojení na Wi-Fi k němu lze přistupovat vzdáleně z profesionálních textových editorů, jako je VS Code, a programovat roboty objektově a s komplexní matematikou.

---

[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../README.md)