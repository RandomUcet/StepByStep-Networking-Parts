# Instalace Ubuntu Serveru

>  **Tip pro Linuxové servery:** Po každé úspěšné konfiguraci (například po instalaci apache nebo db serveru) doporučujeme vytvořit ve VirtualBoxu tzv. Snímek (Snapshot). Pokud se něco v dalším kroku pokazí, velmi jednoduše a rychle se vrátíte do plně funkčního stavu.


Základní instalace operačního systému Ubuntu Server v prostředí VirtualBox. Tento server slouží jako stabilní základ pro následné nasazení webových, souborových nebo poštovních služeb.

## Podrobný postup instalace

### 1. Konfigurace virtuálního stroje (VM)
Před samotnou instalací je nutné správně připravit virtuální prostředí. V aplikaci VirtualBox vytvořte nový virtuální stroj s následujícími parametry:
- **Typ:** Linux
- **Verze:** Ubuntu (64-bit)
- **Operační paměť (RAM):** Minimálně 2 GB (pro plynulý chod doporučeno 4 GB).
- **Virtuální pevný disk:** 20 GB (dynamicky alokovaný).
- **Síťové nastavení:** Pro první fázi zvolte "NAT" pro přístup k internetu a stažení aktualizací.

Připojte stažený ISO obraz Ubuntu Serveru do virtuální mechaniky a spusťte stroj.


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Krok 1**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


> [!TIP]
> Vždy stahujte verzi označenou jako **LTS (Long Term Support)**. Tato verze zaručuje pětiletou podporu a vysokou stabilitu, což je pro serverové prostředí klíčové.

### 2. Průvodce instalací a výběr balíčků
Po zavedení systému z ISO obrazu zvolte jazyk instalátoru a rozložení klávesnice. V kroku výběru typu instalace se setkáte s volbou "Ubuntu Server" a "Ubuntu Server (minimized)".

> [!NOTE]
> Pro produkční servery se často volí **minimalizovaná instalace**, která neobsahuje nadbytečné balíčky. Tím se snižuje režie systému a zmenšuje se prostor pro potenciální bezpečnostní chyby.

### 3. Nastavení identity a SSH
V této fázi definujete název serveru (hostname) a vytvoříte uživatelský účet. Velmi důležitým krokem je obrazovka "SSH Setup".

> [!IMPORTANT]
> Nezapomeňte zaškrtnout volbu **"Install OpenSSH server"**. SSH (Secure Shell) je standardní protokol pro vzdálenou správu serveru přes terminál, bez kterého byste museli vše ovládat přímo z okna VirtualBoxu.

### 4. Dokončení a aktualizace systému
Po dokončení instalace a restartu systému se přihlaste vytvořeným uživatelem a okamžitě proveďte aktualizaci všech nainstalovaných balíčků na nejnovější verze.

```bash
# Aktualizace seznamu balíčků z repozitářů
sudo apt update

# Instalace dostupných aktualizací
sudo apt upgrade -y
```

## Řešení problémů (Troubleshooting)

#### Ubuntu VM nemá přístup k internetu — příkaz apt update selhává.
> [!WARNING]
> Zkontrolujte nastavení síťového adaptéru ve VirtualBoxu. Pokud je nastaven na "Vnitřní síť" (Internal Network), server nebude mít přístup k internetu. Pro stahování balíčků změňte nastavení na **NAT** nebo **Síťový most** (Bridged Adapter).

#### Instalace se zasekla na hlášení "Waiting for unattended-upgr to exit".
> [!NOTE]
> Toto není chyba. Systém se na pozadí snaží stáhnout a nainstalovat bezpečnostní aktualizace. Doporučujeme vyčkat (obvykle 5–10 minut). Pokud proces trvá příliš dlouho, lze jej přerušit stisknutím kláves `Ctrl+C`, ale systém pak nemusí být plně aktualizován.

[Zpět na přehled](../../README.md)


[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../../README.md)
