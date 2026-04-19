# Konfigurace klienta Mozilla Thunderbird

>  **Tip pro Síťové služby:** Pokud vám některá síťová služba (např. FTP server nebo Mail server) odmítá komunikovat, na 90 % se jedná o chybu brány Firewall. Vždy zkontrolujte příchozí a odchozí pravidla pro daný port (např. 21 pro FTP).


Tento dokument popisuje nastavení poštovního klienta Mozilla Thunderbird pro práci s lokálním serverem Kerio Connect v izolovaném prostředí.

## Podrobný postup nastavení

### 1. Úplná instalace aplikace
Před začátkem instalace klienta se ujistěte, že je Firewall ve Windows prozatím vypnutý, abychom otestovali čistou průchodnost zpráv (Povolíme ho zpět až na konci celého cvičení).
Spusťte instalátor Thunderbirdu, během průvodce vyberte možnost **Úplná instalace** (nikoliv Vlastní). Následně klienta spusťte.

### 2. Vytvoření nového poštovního účtu
Zvolte možnost "Vytvořit nový účet" → "E-mail". Vyplňte své jméno, celou e-mailovou adresu a odpovídající heslo podle toho, **jak jste jej vytvořili v administraci Kerio Connect na serveru**.

### 3. Ruční a rozšířené nastavení
Protože se jedná o lokální server bez veřejných záznamů DNS, Thunderbird nedokáže nastavení detekovat automaticky. Klikněte na tlačítko **"Ruční nastavení"** (Manual Config). Poté následně zvolte **Rozšířené nastavení**.

> [!WARNING]
> Thunderbird vás s největší pravděpodobností požádá o připojení na profil a upozorní vás varováním o zabezpečení. To proto, že komunikace v tomto laboratorním prostředí není šifrovaná SSL/TLS certifikátem. Klikněte na **"Schválit bezpečnostní výjimku"**.

### 4. Konfigurace příchozí pošty (POP3 nebo IMAP)
Můžete si vybrat, jakým protokolem chcete e-maily přijímat. Nastavte příchozí server podle vaší preference:

**Varianta A: IMAP (Doporučeno pro většinu nasazení)**
- **Protokol:** `IMAP`
- **Server:** IP adresa serveru Kerio (např. `192.168.0.1`) nebo `localhost` (pokud jste na stejném PC).
- **Port:** `143`
- **Zabezpečení:** `Žádné` (None)
- **Autentizace:** `Normální heslo`

**Varianta B: POP3**
- **Protokol:** `POP3`
- **Server:** IP adresa serveru nebo `localhost`.
- **Port:** `110`
- **Zabezpečení:** `Žádné` (None)
- **Autentizace:** `Normální heslo`

### 5. Konfigurace odchozí pošty (SMTP)
Nastavte odchozí server následovně:
- **Server:** IP adresa serveru nebo `localhost`.
- **Port:** `25`
- **Zabezpečení:** `Žádné` (None)
- **Uživatelské jméno:** Musí být vaše celá e-mailová adresa (přesně podle nastavení v Kerio).

### 6. Testování e-mailů s vypnutým Firewallem
Nyní zkuste odeslat svůj první testovací e-mail. Napište novou zprávu a odešlete ji uživateli 2.
1. Pokud vám **vyskočí okno hlásící chybu SMTP**, nepanikařte. Jednoduše klikněte na tlačítko **Zrušit** a následně dejte **Odeslat znovu**. E-mail by se po tomto triku měl odeslat a s úspěchem dorazit.

### 7. Zapnutí Firewallu (Finální krok)
Pokud se podařilo e-maily odesílat, test je hotový a je načase počítače zabezpečit.
1. Přejděte zpět do operačního systému a **zapněte Windows Firewall** (na klientském i na serverovém PC).
2. Spusťte nástroj **Windows Defender Firewall s pokročilým zabezpečením** (`wf.msc`).
3. Vytvořte **Nové pravidlo pro porty** jak pro *Příchozí*, tak pro *Odchozí* komunikaci.
4. Povolte protokol **TCP** a zadejte tuto posloupnost portů: `25, 143, 993, 587`.
Nyní bude email přes síť perfektně a plně komunikovat i při zapnutém Firewallu na obou stranách.

---

## Užitečné materiály a odkazy

*   [Nápověda pro Mozilla Thunderbird](https://support.mozilla.org/cs/products/thunderbird) - Oficiální znalostní báze pro různé dotazy k užívání poštovního klienta, řešení chybových hlášek, případně přidávání adresářů.
*   [YouTube průvodce Thunderbirdem](https://www.youtube.com/results?search_query=thunderbird+email+setup+pop3+imap) - Názorné ukázky rozhraní s příklady jak vyplňovat konfigurace, v případě že hledáte videonávody či další postupy obohacené o fotografie z reálných programů.

[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../../README.md)
