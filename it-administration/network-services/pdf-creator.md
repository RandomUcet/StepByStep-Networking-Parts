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

## 2. Sdílení tiskárny do sítě

Nyní musíme naši novou virtuální tiskárnu nasdílet, aby ji viděly ostatní počítače (klienti) v lokální síti.

1. Na Windows Serveru přejděte do nabídky Start a otevřete **Ovládací panely**.
2. Najděte a otevřete sekci **Zařízení a tiskárny**.
3. V seznamu tiskáren najděte tu s názvem `PDFCreator`. Klikněte na ni pravým tlačítkem myši a z kontextové nabídky zvolte **Vlastnosti tiskárny** (pozor, nikoliv pouze "Vlastnosti" úplně dole, to by otevřelo jiné menu).
4. V novém okně se přepněte nahoře na kartu **Sdílení**.
5. Zaškrtněte políčko **Sdílet tuto tiskárnu**.
6. Název sdílené tiskárny můžete ponechat jednoduše jako `PDFCreator`. Vše potvrďte tlačítkem **OK** nebo **Použít**.

## 3. Připojení na klientské stanici (Bez instalace)

Aby mohl uživatel na jiném klientském počítači (např. běžný PC s Windows 10) tisknout na tuto PDF tiskárnu, **není vůbec potřeba na klientskou stanici PDF Creator instalovat**. Klientský systém si ovladače stáhne sám napřímo přes síť.

1. Na klientské stanici rovnou otevřete **Průzkumníka souborů (Tento počítač)**.
2. Do adresního řádku úplně nahoře napište IP adresu (nebo síťový název) vašeho Windows Serveru ve formátu `\\192.168.0.1` (nebo např. `\\SERVER01`) a stiskněte klávesu Enter.
3. Ve složce, která se načte, byste měli vidět sdílené položky serveru, včetně naší nasdílené tiskárny `PDFCreator`.
4. Klikněte na ikonu tiskárny pravým tlačítkem myši a zvolte možnost **Připojit** (Connect). Klientský systém Windows si v tuto chvíli automaticky stáhne nezbytné komunikační ovladače ze serveru a tiskárnu přidá do systému.

Od této chvíle mohou uživatelé na klientské stanici otevřít jakýkoliv dokument (z Wordu, webovou stránku, obrázek), stisknout funkci Tisk a v nabídce dostupných tiskáren vybrat náš nasdílený síťový PDF Creator. Výsledné PDF se následně zpracuje přes server.

---
[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../../README.md)