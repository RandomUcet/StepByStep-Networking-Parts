# Instalace a sdílení PDF Creatoru

> **Tip pro Síťové služby:** Pokud se tiskárna v síti neobjevuje, zkontrolujte, zda máte v Centru síťových připojení a sdílení u serveru zapnuté "Sdílení souborů a tiskáren". Často toto základní nastavení Windows blokuje sdílení zařízení do sítě.

Tento návod popisuje, jak nainstalovat PDF Creator jako síťovou virtuální tiskárnu. Centrální počítač (Windows Server nebo vyhrazené PC) bude přijímat tiskové úlohy od ostatních klientských stanic a převádět je do formátu PDF.

## 1. Instalace na Windows Server (Centrální tiskový uzel)

Počítač, který běží neustále a zpracovává požadavky, bude tvořit tiskový server.

1. Spusťte instalační program PDF Creatoru na Windows Serveru (nebo centrálním PC).
2. Hned na první obrazovce průvodce pečlivě vyhledejte a zaškrtněte položku **Expert settings** (Expertní nastavení). Klikněte na tlačítko Další.
3. V okně pro výběr typu instalace přepněte z výchozí volby na **Server installation** (Serverová instalace). Toto je kritický krok, aby aplikace fungovala jako služba pro ostatní zařízení v síti.
4. Dokončete standardně zbytek instalace odklikáním potvrzovacích tlačítek (Další, Souhlasím s podmínkami, Instalovat).
5. Tímto se ve Windows vytvořila nová virtuální tiskárna s názvem `PDFCreator`, která běží ve speciálním serverovém režimu a čeká na tiskové úlohy.

## 2. Sdílení tiskárny do sítě a nastavení oprávnění

Aby PDF tiskárna fungovala centralizovaně a bezpečně (podle certifikačních zadání), nesmí na ni tisknout "Everyone" (Kdokoli) a měla by být spravovatelná přes nástroj Správa tisku.

1. Na Windows Serveru přejděte do nabídky Start a otevřete **Nástroje pro správu** (Administrative Tools) -> **Správa tisku** (Print Management). *(Pokud Správu tisku nemáte, musíte nejprve v Server Manageru doinstalovat roli Print and Document Services).*
2. V levém panelu rozbalte `Print Servers -> [Váš Server] -> Printers`.
3. V seznamu tiskáren najděte tu s názvem `PDFCreator`. Klikněte na ni pravým tlačítkem myši a zvolte **Vlastnosti tiskárny** (Properties).
4. V novém okně se přepněte nahoře na kartu **Sdílení** (Sharing). Zaškrtněte políčko **Sdílet tuto tiskárnu** a rovněž zaškrtněte i možnost publikace v Active Directory (List in the directory).
5. Dále se přepněte na kartu **Zabezpečení** (Security). 
6. Z bezpečnostních důvodů **odstraňte skupinu Everyone** ze seznamu oprávnění. Místo ní přes tlačítko Přidat vložte konkrétní skupiny, například `Domain Users` (těm ponechte jen čtení a povolení k samotnému Tisku) a `Print Operators` (pro správu tiskárny a celých tiskových úloh, kterým povolte práva "Manage Printers" a "Manage Documents"). 
7. Vše potvrďte tlačítkem **OK**. Následně v programu PDFCreator nezapomeňte nakonfigurovat výstupní složku, kam se budou ukládat výsledné PDF soubory po tisku.

## 3. Připojení na klientské stanici (Bez instalace)

Aby mohl uživatel na jiném klientském počítači (např. běžný PC s Windows 10) tisknout na tuto PDF tiskárnu, **není vůbec potřeba na klientskou stanici PDF Creator instalovat**. Klientský systém si ovladače stáhne sám napřímo přes síť.

1. Na klientské stanici rovnou otevřete **Průzkumníka souborů (Tento počítač)**.
2. Do adresního řádku úplně nahoře napište IP adresu (nebo síťový název) vašeho Windows Serveru ve formátu `\\192.168.0.1` (nebo např. `\\SERVER01`) a stiskněte klávesu Enter.
3. Ve složce, která se načte, byste měli vidět sdílené položky serveru, včetně naší nasdílené tiskárny `PDFCreator`.
4. Klikněte na ikonu tiskárny pravým tlačítkem myši a zvolte možnost **Připojit** (Connect). Klientský systém Windows si v tuto chvíli automaticky stáhne nezbytné komunikační ovladače ze serveru a tiskárnu přidá do systému.

Od této chvíle mohou uživatelé na klientské stanici otevřít jakýkoliv dokument (z Wordu, webovou stránku, obrázek), stisknout funkci Tisk a v nabídce dostupných tiskáren vybrat náš nasdílený síťový PDF Creator. Výsledné PDF se následně zpracuje přes server.

---
[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../../README.md)