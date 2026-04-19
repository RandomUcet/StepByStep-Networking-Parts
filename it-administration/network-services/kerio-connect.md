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

### 3. Příprava systému a firewallu
Než začneme instalovat poštovní server, musíme vypnout případné bezpečnostní programy, které by instalaci narušovaly.
1. Úplně **vypněte McAfee antivirus** (nebo jakýkoliv jiný nainstalovaný antivirus) na serveru.
2. Následně **vypněte Windows Firewall** jak na serveru, tak i na klientském počítači. Pravidla vytvoříme až na konci návodu.

### 4. Úplná instalace (Complete)
Spusťte instalátor Kerio Connect. Během průvodce nevybírejte vlastní instalaci, ale rovnou klikněte na **Úplná instalace** (Complete). Vytvořte administrátorský účet (např. jméno `Admin` a heslo `123456`).

### 5. Konfigurace domény
V kroku nastavení domény změňte výchozí `localhost` na `skola.localhost`. Dokončete průvodce a nechte službu spustit.

> [!NOTE]
> Tato doména bude součástí vašich e-mailových adres, například: `uzivatel@skola.localhost`.

### 6. Sledování stavu (Engine Monitor)
Kerio běží jako systémová služba. Vyhledejte v nabídce Start položku "Kerio" a spusťte **"Engine Monitor"**. Ten se zobrazí v systémové liště (u hodin), odkud jej můžete otevřít a zadat heslo správce.

### 7. Ověření služeb
V administračním rozhraní přejděte do "Konfigurace" → "Služby". Ujistěte se, že všechny klíčové služby (SMTP, POP3, IMAP) svítí zeleně.

### 8. Povolení Open Relay
Přejděte do "Konfigurace" → "SMTP server". Zde zaškrtněte volbu **"Open relay"** a potvrďte tlačítkem "Apply".

> [!IMPORTANT]
> Bez povolení Open Relay nebude možné v tomto testovacím prostředí odesílat poštu mezi lokálními uživateli. Tato funkce je v reálném internetu nebezpečná a nesmí být nikdy povolena veřejně!

### 9. Nastavení fronty zpráv (Message Queue)
V záložce "Message Queue Options" nastavte interval odesílání chybových zpráv na 1 minutu. Získáte tak rychlejší zpětnou vazbu při ladění doručování zpráv.

### 10. Vytvoření uživatelských účtů
Přejděte do "Nastavení domény" → "Uživatelské účty" → "Přidat". 
* Vytvořte minimálně dva testovací uživatele pro ověření vzájemné komunikace.
* **Důležité:** U obou uživatelů zvolte možnost **Ověření: Interní databáze uživatelů** a teprve poté nastavte jejich hesla.
* V záložce **Kvóta** (Quota) nebo v nastavení omezte velikost poštovní schránky na **1 GB** (dle firemních předpisů).

### 11. Finální nastavení Firewallu
Poté, co vyzkoušíte komunikaci mezi klienty a ověříte si, že server s vypnutým firewallem funguje (viz návod k Thunderbirdu), **musíme Windows Firewall na obou zařízeních opět zapnout**.
Ve "Windows Defender Firewall s pokročilým zabezpečením" (`wf.msc`) vytvořte na serveru i klientu nová pravidla.
1. Otevřete **Příchozí pravidla** -> **Nové pravidlo** -> **Port**.
2. Zvolte **TCP** a napište tyto porty: `25, 143, 993, 587`. 
3. Povolte připojení, nechte zaškrtnuté všechny sítě a pravidlo pojmenujte např. "Kerio Mail".
4. Stejný postup zopakujte v záložce **Odchozí pravidla**. Od této chvíle bude e-mail fungovat i při zabezpečeném počítači.

---

## Užitečné materiály a odkazy

*   [Videotutoriál: Kerio Connect Installation (YouTube)](https://www.youtube.com/results?search_query=kerio+connect+installation) - Pokud preferujete vizuální ukázku instalace, doporučujeme vyhledat na YouTube videonávody obsahující přesné kroky instalace a základního nastavení.
*   [Oficiální GFI/Kerio dokumentace](https://manuals.gfi.com/en/kerio/connect/content/home.htm) - Přehledný oficiální manuál k aktuálním verzím systému Kerio Connect. Může být nápomocný při řešení složitějších problémů s porty a licencováním.

## Troubleshooting — Řešení potíží

#### Kerio Connect nestartuje nebo Engine Monitor nic nezobrazuje.
> [!NOTE]
> Zkontrolujte, zda běží služba "Kerio Connect" ve správci služeb Windows (services.msc). Ujistěte se také, že firewall neblokuje porty 25 (SMTP) a 4040 (vzdálená správa).

#### E-maily se nedaří odeslat — chyba protokolu SMTP.
> [!WARNING]
> Pravděpodobně nemáte povolen "Open Relay" v nastavení SMTP serveru. Kerio pak odmítá přeposílat zprávy od neautorizovaných uživatelů.

[Zpět na přehled](../../README.md)


[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../../README.md)
