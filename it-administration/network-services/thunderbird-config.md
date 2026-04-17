# Konfigurace klienta Mozilla Thunderbird

>  **Tip pro Síťové služby:** Pokud vám některá síťová služba (např. FTP server nebo Mail server) odmítá komunikovat, na 90 % se jedná o chybu brány Firewall. Vždy zkontrolujte příchozí a odchozí pravidla pro daný port (např. 21 pro FTP).


Tento dokument popisuje nastavení poštovního klienta Mozilla Thunderbird pro práci s lokálním serverem Kerio Connect v izolovaném prostředí.

## Podrobný postup nastavení

### 1. Vytvoření nového poštovního účtu
Po spuštění aplikace Thunderbird zvolte možnost "Vytvořit nový účet" → "E-mail". Vyplňte své jméno, celou e-mailovou adresu (např. `uzivatel@skola.localhost`) a odpovídající heslo ze serveru Kerio.

### 2. Ruční konfigurace připojení (Manual Config)
Protože se jedná o lokální server bez veřejných záznamů DNS, Thunderbird nedokáže nastavení detekovat automaticky. Klikněte na tlačítko **"Ruční nastavení"** (Manual Config).

> [!WARNING]
> Thunderbird může zobrazit varování o zabezpečení, protože komunikace v tomto laboratorním prostředí není šifrovaná SSL/TLS certifikátem. Pro pokračování klikněte na **"Schválit bezpečnostní výjimku"**.

### 3. Konfigurace příchozí pošty (POP3 nebo IMAP)
Můžete si vybrat, jakým protokolem chcete e-maily přijímat. Nastavte příchozí server podle vaší preference:

**Varianta A: IMAP (Doporučeno pro většinu nasazení)**
- **Protokol:** `IMAP`
- **Server:** `localhost`
- **Port:** `143` (standardní port pro nešifrovaný IMAP)
- **Zabezpečení:** `Žádné` (None)
- **Autentizace:** `Normální heslo`

**Varianta B: POP3**
- **Protokol:** `POP3`
- **Server:** `localhost`
- **Port:** `110` (standardní port pro nešifrovaný POP3)
- **Zabezpečení:** `Žádné` (None)
- **Autentizace:** `Normální heslo`

### 4. Konfigurace odchozí pošty (SMTP)
Nastavte odchozí server následovně:
- **Server:** `localhost`
- **Port:** `25` (standardní port pro nešifrovaný SMTP)
- **Zabezpečení:** `Žádné` (None)
- **Uživatelské jméno:** Musí být vaše celá e-mailová adresa (`uzivatel@skola.localhost`).

### 5. Testování komunikace mezi uživateli
Doporučujeme nastavit druhý uživatelský účet podle stejného postupu. Následně vyzkoušejte odeslat zkušební e-mail z prvního účtu na druhý.

### 6. Ověření doručení zprávy
Přejděte do doručené pošty druhého uživatele a zkontrolujte, zda e-mail dorazil. Pokud zpráva nebyla doručena, prověřte stav "Fronty zpráv" (Message Queue) přímo v administraci serveru Kerio Connect.

## Troubleshooting — Řešení potíží

#### Thunderbird hlásí "Nelze ověřit konfiguraci — uživatelské jméno nebo heslo je špatně".
> [!NOTE]
> Ujistěte se, že služba Kerio Connect běží a že jste v administraci uživatelský účet skutečně vytvořili. Pokud se připojujete z jiného stroje, místo `localhost` zadejte IP adresu serveru.

#### E-mail se odešle, ale nikdy nedorazí k příjemci.
> [!WARNING]
> Pravděpodobně není povolen "Open Relay" v nastavení SMTP serveru Kerio Connect. V takovém případě server e-mail přijme, ale odmítne jej doručit dál.

[Zpět na přehled](../../README.md)


[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../../README.md)
