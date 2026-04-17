# Konfigurace Cerberus FTP Serveru

>  **Tip pro Síťové služby:** Pokud vám některá síťová služba (např. FTP server nebo Mail server) odmítá komunikovat, na 90 % se jedná o chybu brány Firewall. Vždy zkontrolujte příchozí a odchozí pravidla pro daný port (např. 21 pro FTP).


Cerberus FTP Server představuje moderní alternativu pro přenos souborů, která na rozdíl od starších řešení nativně podporuje zabezpečené protokoly jako FTPS a SFTP. Tento návod se zaměřuje na bezpečnou instalaci a konfiguraci uživatelů.

## Podrobný postup konfigurace

### 1. Instalace serveru
Po spuštění instalátoru postupujte podle pokynů na obrazovce. Během průvodce nastavením zvolte typ licence "Personal Use" (pro studijní účely).

> [!NOTE]
> Během instalace bude na disku C: automaticky vytvořen adresář `ftproot`. Ten slouží jako výchozí úložiště pro všechny uživatelské soubory.

### 2. Správa uživatelů a zabezpečení
V konfiguračním rozhraní definujte uživatelské jméno a heslo. V dolní části okna (v záložce oprávnění) zaškrtněte všechna dostupná políčka, aby měl uživatel plnou kontrolu nad svými soubory. Pokud se během procesu objeví dialogové okno s dotazem na pokročilé nastavení, klikněte na "No" a pokračujte v základním průvodci.

> [!IMPORTANT]
> Cerberus podporuje FTPS (SSL/TLS). Pro zajištění bezpečnosti a šifrování dat vždy upřednostňujte tento protokol před standardním FTP.

### 3. Konfigurace klienta (Total Commander)
Spusťte Total Commander a v horním panelu zvolte "Síť" → "Protokol FTP - Připojit". Klikněte na "Nové připojení" a vyplňte údaje o serveru.

> [!WARNING]
> Pro úspěšné navázání šifrovaného spojení musí být v nastavení Total Commanderu zaškrtnuta volba **SSL/TLS**. Pokud toto neuděláte, spojení může být serverem odmítnuto nebo bude probíhat nešifrovaně.

### 4. Řešení problémů s knihovnami OpenSSL
Pokud se setkáte s chybou "Knihovny OpenSSL nebyly nalezeny" (OpenSSL library not found), pravděpodobně používáte verzi Total Commanderu bez těchto komponent.

> [!TIP]
> Použijte verzi Total Commanderu přímo z instalačního média, které již tyto binární soubory obsahuje, nebo si doinstalujte balíček OpenSSL pro Windows.

## Troubleshooting — Řešení potíží

#### Chyba "OpenSSL library not found" při pokusu o SSL/TLS připojení.
> [!NOTE]
> Stáhněte a nainstalujte knihovny `libeay32.dll` a `ssleay32.dll` (nebo jejich moderní ekvivalenty) do adresáře s Total Commanderem.

#### Chyba certifikátu při připojování přes FTPS.
> [!WARNING]
> Cerberus standardně generuje "self-signed" (vlastnoručně podepsaný) certifikát. Total Commander se vás zeptá, zda tomuto certifikátu důvěřujete. V lokálním laboratorním prostředí potvrďte volbou **"Vždy důvěřovat"** (Accept Always).

[Zpět na přehled](../../README.md)


[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../../README.md)
