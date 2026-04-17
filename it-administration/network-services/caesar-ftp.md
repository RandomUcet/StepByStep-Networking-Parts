# Instalace a konfigurace CaesarFTP Serveru

>  **Tip pro Síťové služby:** Pokud vám některá síťová služba (např. FTP server nebo Mail server) odmítá komunikovat, na 90 % se jedná o chybu brány Firewall. Vždy zkontrolujte příchozí a odchozí pravidla pro daný port (např. 21 pro FTP).


Tato příručka detailně popisuje proces nastavení FTP serveru pomocí aplikace CaesarFTP v prostředí Windows. Zaměřuje se na vytvoření bezpečné adresářové struktury, správu uživatelů a definování přístupových práv.

## Podrobný postup konfigurace

### 1. Příprava adresářové struktury
Před spuštěním samotného serveru je nutné připravit složky, ke kterým budou mít uživatelé přístup. Na lokálním disku C: vytvořte hlavní složku `FTP` a v ní dvě podsložky: `Upload` (pro nahrávání souborů) a `Download` (pro stahování souborů).


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Struktura složek**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


> [!NOTE]
> Tato struktura bude sloužit jako kořenový adresář (root) pro vaše uživatele. Uživatelé uvidí pouze obsah těchto složek, nikoliv zbytek vašeho pevného disku.

### 2. Správa uživatelských účtů
Spusťte aplikaci CaesarFTP a v horním panelu klikněte na ikonu panáčka (User Management). Pro vytvoření nového uživatele klikněte na tlačítko "Add User" v levém dolním rohu. Zadejte uživatelské jméno a silné heslo.


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Správa uživatelů**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


> [!IMPORTANT]
> Přístupové údaje si pečlivě uschovejte, budete je potřebovat pro konfiguraci FTP klienta (např. Total Commander).

### 3. Definice přístupových práv k souborům
Po vytvoření uživatele přepněte na záložku "File Access Rights". Zde musíte explicitně určit, které složky smí uživatel používat. V dolní části zaškrtněte požadovaná oprávnění: Read, Write, Append, SubDir Access a List. Následně přetáhněte složky `Upload` a `Download` do hlavního pole.


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Přístupová práva**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


> [!WARNING]
> Bez přidělení práv a přetažení složek se uživatel sice přihlásí, ale uvidí prázdný seznam adresářů.

### 4. Systémové nastavení a automatické spouštění
V záložce "Settings" otevřete "Edit Server Options". Zde doporučujeme zaškrtnout volbu "Launch on system start", aby byl FTP server dostupný ihned po startu operačního systému.

### 5. Konfigurace firewallu
FTP protokol standardně využívá TCP port 21 pro řídicí spojení. Ujistěte se, že Windows Firewall nebo váš antivirus tento port neblokuje.

> [!IMPORTANT]
> Přidejte výjimku pro aplikaci `CaesarFTP.exe` nebo povolte příchozí provoz na portu **21/TCP**.

## Troubleshooting — Řešení potíží

#### Klient se nemůže připojit — hlášení "Connection refused" nebo vypršení limitu.
> [!NOTE]
> Zkontrolujte, zda je CaesarFTP server ve stavu "Running". Ověřte, zda se nepřipojujete na špatnou IP adresu. Pokud testujete lokálně, použijte adresu `127.0.0.1`.

#### Uživatel vidí po přihlášení prázdný adresář.
> [!WARNING]
> Pravděpodobně jste zapomněli přetáhnout složky do pole "File Access Rights" v nastavení uživatele. Opravte nastavení a restartujte server.

[Zpět na přehled](../../README.md)


[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../../README.md)
