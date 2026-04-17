# Vzdálený přístup přes SSH na Ubuntu

>  **Tip pro Linuxové servery:** Po každé úspěšné konfiguraci (například po instalaci apache nebo db serveru) doporučujeme vytvořit ve VirtualBoxu tzv. Snímek (Snapshot). Pokud se něco v dalším kroku pokazí, velmi jednoduše a rychle se vrátíte do plně funkčního stavu.


Tento návod popisuje, jak se vzdáleně připojit k serveru Ubuntu z operačního systému Windows pomocí protokolu SSH (Secure Shell). Vzdálená správa přes SSH je efektivnější a pohodlnější než práce přímo v okně virtuálního stroje.

## Podrobný postup konfigurace

### 1. Instalace a aktivace SSH serveru
Pokud jste při instalaci Ubuntu Serveru nezaškrtli volbu pro instalaci OpenSSH serveru, musíte jej doinstalovat ručně pomocí správce balíčků APT.

```bash
# Aktualizace repozitářů a instalace balíčku
sudo apt update
sudo apt install openssh-server -y

# Povolení spuštění služby při startu systému a spuštění nyní
sudo systemctl enable ssh
sudo systemctl start ssh
```

### 2. Ověření stavu služby a získání IP adresy
Před připojením se ujistěte, že služba běží, a zjistěte aktuální IP adresu serveru.

```bash
# Kontrola stavu služby
sudo systemctl status ssh.service

# Zobrazení IP adres na všech síťových rozhraních
hostname -I
```

> [!NOTE]
> Poznamenejte si IP adresu, kterou vidíte na prvním místě (např. 10.0.2.15 nebo 192.168.1.50). Tato adresa bude použita pro navázání spojení.

### 3. Navázání spojení z prostředí Windows
V operačním systému Windows otevřete terminál (PowerShell nebo Příkazový řádek) a použijte příkaz `ssh` ve formátu `uživatel@ip_adresa`.

```powershell
# Příklad připojení k serveru s IP 10.15.0.69
ssh admin@10.15.0.69
```

> [!IMPORTANT]
> Při prvním připojení k novému serveru vás SSH upozorní, že identita hostitele není známa. Napište **"yes"** pro potvrzení otisku klíče (fingerprint) do souboru známých hostitelů. Následně zadejte své heslo.

### 4. Základní příkazy pro navigaci a správu
Po úspěšném přihlášení můžete server spravovat přímo z vašeho počítače. Zde jsou základní příkazy pro začátek:

```bash
ls -la                    # Detailní výpis souborů v aktuálním adresáři
pwd                       # Zobrazení cesty k aktuálnímu pracovnímu adresáři
cd /var/www               # Změna adresáře (např. do složky s webovými soubory)
sudo su                   # Přepnutí na uživatele root (nejvyšší oprávnění)
systemctl status apache2  # Kontrola stavu webového serveru Apache
```

## Řešení nejčastějších problémů

#### SSH připojení selže — "Connection refused" nebo vypršení časového limitu (timeout).
> [!WARNING]
> Ověřte následující body:
> 1. Služba SSH na Ubuntu skutečně běží (`systemctl status ssh`).
> 2. IP adresa je zadána správně.
> 3. Síťový adaptér ve VirtualBoxu je nastaven na **Síťový most** (Bridged) nebo **NAT** s nastaveným přesměrováním portů (Port Forwarding pro port 22).

#### Hlášení "WARNING: REMOTE HOST IDENTIFICATION HAS CHANGED".
> [!NOTE]
> K tomuto dochází při přeinstalaci serveru nebo změně SSH klíčů. Windows si pamatuje starý klíč a z bezpečnostních důvodů odmítne spojení. Starý záznam odstraňte příkazem: `ssh-keygen -R ip_adresa_serveru` a poté se zkuste připojit znovu.

[Zpět na přehled](../../README.md)


[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../../README.md)
