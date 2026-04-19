# Klonování virtuálních strojů (VM Cloning)

>  **Tip pro Windows Server:** Doporučujeme instalovat vždy anglickou (English) verzi Windows Serveru. Pokud dojde k chybě, anglické chybové hlášky se na internetu dohledávají (např. na fórech jako Stack Overflow nebo Reddit) podstatně snadněji než jejich české překlady.


Tento dokument popisuje efektivní metodu vytváření kopií existujících virtuálních strojů v prostředí VirtualBox. Klonování výrazně urychluje nasazení více klientských stanic v rámci testovací laby bez nutnosti opakované instalace operačního systému.

## Podrobný postup konfigurace

### 1. Proces klonování ve VirtualBoxu
Před zahájením klonování se ujistěte, že je zdrojový virtuální stroj ve stavu **Powered Off**.
- V aplikaci VirtualBox klikněte pravým tlačítkem na zdrojový VM a zvolte **Clone...**.
- **Name:** Zadejte název nového stroje (např. `CLT-WIN10-02`).
- **MAC Address Policy:** Zvolte **Generate new MAC addresses for all network adapters**. Toto je kritické pro zamezení síťových kolizí.
- **Clone type:** Vyberte **Full Clone**.


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Proces klonování**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


> [!TIP]
> **Full Clone** vytvoří zcela nezávislou kopii disku, kterou lze přenášet. **Linked Clone** sdílí disk se zdrojem, což šetří místo, ale klon je nefunkční bez původního stroje.

### 2. Povýšení druhého serveru na záložní řadič
Pokud podle zadání klonujete první hotový Windows Server, abyste z něj vytvořili druhý server (Windows Server 2), musíte změnit jeho název (Hostname) a začlenit jej do domény jako **Záložní řadič domény**.
- Otevřete Server Manager, přidejte roli **Active Directory Domain Services** (pokud tam po klonování nezůstala).
- Po instalaci klikněte na žlutý praporek nahoře a zvolte **Povýšit tento server na řadič domény** (Promote this server to a domain controller).
- Tentokrát ale vyberte první možnost: **Přidat řadič domény do existující domény** (Add a domain controller to an existing domain).
- Zadejte název vaší domény (např. `SPOS.local`) a klikněte na tlačítko Vybrat/Změnit (Select/Change), abyste zadali přihlašovací údaje administrátora z vašeho *prvního* serveru (např. `SPOS\Administrator` a heslo).
- Projděte průvodcem, nastavte DSRM heslo pro obnovu a po restartu se tento druhý server stane plnohodnotným záložním řadičem, na který se budou replikovat uživatelé a nastavení.

### 3. Síťová konfigurace a DHCP
Pokud nepoužíváte DHCP server, musíte ručně nastavit novou statickou IP adresu. V případě DHCP je vhodné vynutit obnovu zapůjčení.
- Pro zobrazení aktuální konfigurace:
```powershell
ipconfig /all
```
- Pro obnovu DHCP zapůjčení:
```powershell
ipconfig /release
ipconfig /renew
```

## Diagnostika a řešení potíží (Troubleshooting)

### Kolize názvů v doméně
> [!WARNING]
> Pokud klonovaný stroj hlásí chybu "The trust relationship between this workstation and the primary domain failed", je to pravděpodobně způsobeno duplicitním SID nebo názvem. V takovém případě stroj vyjměte z domény (přepněte do Workgroup), odstraňte jeho účet v Active Directory a znovu jej do domény připojte.

### Problémy s připojením k síti
> [!IMPORTANT]
> Ověřte, zda má klon vygenerovanou novou MAC adresu. Pokud mají dva stroje v jedné vnitřní síti stejnou MAC adresu, bude síťová komunikace obou strojů nestabilní nebo zcela nefunkční.

### Linked Clone nelze spustit
> [!TIP]
> Pokud jste smazali nebo přesunuli zdrojový virtuální stroj, všechny jeho **Linked Clones** přestanou fungovat. Pro produkční a testovací účely v rámci výuky vždy preferujte **Full Clone**.

---
[Zpět na přehled](../../README.md)


[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../../README.md)
