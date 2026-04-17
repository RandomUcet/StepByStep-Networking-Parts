# Poštovní server Kerio Connect

>  **Tip pro Síťové služby:** Pokud vám některá síťová služba (např. FTP server nebo Mail server) odmítá komunikovat, na 90 % se jedná o chybu brány Firewall. Vždy zkontrolujte příchozí a odchozí pravidla pro daný port (např. 21 pro FTP).


Tento návod vás provede instalací a konfigurací serveru Kerio Connect v lokálním laboratorním prostředí. Zaměřuje se na správné nastavení domény, uživatelských účtů a pravidel pro odesílání pošty.

## Podrobný postup konfigurace

### 1. Příprava před instalací
Zkopírujte instalační balíčky Kerio Connect a Mozilla Thunderbird z média na plochu. Doporučujeme jako první nainstalovat Thunderbird, aby byl připraven pro následné testování.

### 2. Izolace síťového prostředí
Ve VirtualBoxu přejděte do "Nastavení" → "Síť" a u příslušného adaptéru zvolte "Vnitřní síť" (Internal Network).

> [!WARNING]
> Po tomto kroku server ztratí přístup k internetu. Veškerá komunikace bude probíhat pouze v rámci této izolované sítě, což je pro testování poštovního serveru ideální.

### 3. Vlastní instalace (Custom)
Spusťte instalátor Kerio Connect. Během průvodce zvolte typ instalace **"Custom"**. Vytvořte administrátorský účet (např. jméno `Admin` a heslo `123456`).

### 4. Konfigurace domény
V kroku nastavení domény změňte výchozí `localhost` na `skola.localhost`. Dokončete průvodce a nechte službu spustit.

> [!NOTE]
> Tato doména bude součástí vašich e-mailových adres, například: `uzivatel@skola.localhost`.

### 5. Sledování stavu (Engine Monitor)
Kerio běží jako systémová služba. Vyhledejte v nabídce Start položku "Kerio" a spusťte **"Engine Monitor"**. Ten se zobrazí v systémové liště (u hodin), odkud jej můžete otevřít a zadat heslo správce.

### 6. Ověření služeb
V administračním rozhraní přejděte do "Konfigurace" → "Služby". Ujistěte se, že všechny klíčové služby (SMTP, POP3, IMAP) svítí zeleně.

### 7. Povolení Open Relay
Přejděte do "Konfigurace" → "SMTP server". Zde zaškrtněte volbu **"Open relay"** a potvrďte tlačítkem "Apply".

> [!IMPORTANT]
> Bez povolení Open Relay nebude možné v tomto testovacím prostředí odesílat poštu mezi lokálními uživateli. Tato funkce je v reálném internetu nebezpečná a nesmí být nikdy povolena veřejně!

### 8. Nastavení fronty zpráv (Message Queue)
V záložce "Message Queue Options" nastavte interval odesílání chybových zpráv na 1 minutu. Získáte tak rychlejší zpětnou vazbu při ladění doručování zpráv.

### 9. Vytvoření uživatelských účtů
Přejděte do "Nastavení domény" → "Uživatelské účty" → "Přidat". Vytvořte minimálně dva testovací uživatele pro ověření vzájemné komunikace.

### 10. Konfigurace stahování a protokolů (POP3 / IMAP)
U každého uživatele přejděte na záložku "Konfigurace" → "POP3 stahování" → "Přidat". Jako server zadejte `localhost` a vyplňte odpovídající jméno uživatele. 

Pokud plánujete využívat i modernější protokol **IMAP**, ujistěte se znovu, že je služba IMAP povolena (viz krok 6). Na rozdíl od POP3, který zprávy ze serveru zpravidla odstraňuje, IMAP udržuje e-maily na serveru a pouze je synchronizuje s klientem, což je vhodnější při použití více zařízení.

## Troubleshooting — Řešení potíží

#### Kerio Connect nestartuje nebo Engine Monitor nic nezobrazuje.
> [!NOTE]
> Zkontrolujte, zda běží služba "Kerio Connect" ve správci služeb Windows (services.msc). Ujistěte se také, že firewall neblokuje porty 25 (SMTP) a 4040 (vzdálená správa).

#### E-maily se nedaří odeslat — chyba protokolu SMTP.
> [!WARNING]
> Pravděpodobně nemáte povolen "Open Relay" v nastavení SMTP serveru. Kerio pak odmítá přeposílat zprávy od neautorizovaných uživatelů.

[Zpět na přehled](../../README.md)


[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../../README.md)
