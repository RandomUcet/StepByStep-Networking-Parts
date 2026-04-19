# Sdílení souborů a správa oprávnění NTFS

>  **Tip pro Windows Server:** Doporučujeme instalovat vždy anglickou (English) verzi Windows Serveru. Pokud dojde k chybě, anglické chybové hlášky se na internetu dohledávají (např. na fórech jako Stack Overflow nebo Reddit) podstatně snadněji než jejich české překlady.


Tento dokument poskytuje detailní návod na konfiguraci sdílení souborů v prostředí Windows Server, včetně nastavení sdílených složek, oprávnění ke sdílení a zabezpečení na úrovni souborového systému NTFS.

## Podrobný postup konfigurace

### 1. Příprava adresářové struktury (Zadání SPOS)
Před samotným sdílením je nutné vytvořit logickou strukturu složek na lokálním disku C: (nebo lépe na dedikovaném datovém oddílu).
Vytvořte si postupně následující složky: `Home`, `Install`, `Faktury`, `Ucetnictvi`, `Spolecne_dokumenty` a `Zalohy`.


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Příprava složek**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


### 2. Konfigurace pokročilého sdílení
Klikněte pravým tlačítkem na cílovou složku, zvolte **Properties** (Vlastnosti) a přejděte na kartu **Sharing** (Sdílení). Zde klikněte na **Advanced Sharing** (Rozšířené sdílení).


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Aktivace sdílení**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


1. Zaškrtněte **Share this folder** (Sdílet tuto složku).
2. Definujte **Share name** (Název sdílené položky) – tento název uvidí uživatelé v síti.

### 3. Nastavení oprávnění sdílení
V okně pokročilého sdílení klikněte na tlačítko **Permissions** (Oprávnění).


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Oprávnění sdílení**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


> [!IMPORTANT]
> Z bezpečnostních důvodů **vždy odstraňte výchozí skupinu Everyone**. Místo ní přidejte konkrétní doménové skupiny, kterým chcete přístup umožnit (pro zjednodušení můžete přidat např. skupinu všech zaměstnanců a povolit jim **Full Control** přímo na kartě Share, protože skutečná bezpečnostní práva doladíte až v dalším kroku na kartě Security/NTFS).

### 4. Nastavení zabezpečení NTFS (Security) podle zadání
Přepněte se na kartu **Security** (Zabezpečení) ve vlastnostech složky. Zde se definují skutečná oprávnění k souborům a podsložkám pomocí explicitního přidělování (Allow) nebo odepírání (Deny) práv skupinám.

Nastavte práva (přes tlačítko Edit a Add) u jednotlivých složek přesně takto:
*   **H: (Home):** Toto je domovská složka. Každý uživatel zde musí mít svou vlastní podsložku chráněnou proti vstupu neautorizovaných osob.
*   **I: (Install):** Zde u všech běžných zaměstnaneckých skupin zaškrtněte pouze **Read** (čtení). Skupině Administrátorů (Správců) nechte zaškrtnuto **Full Control** nebo **Modify**.
*   **F: (Faktury):** Odepřete přístup všem (Deny) kromě skupin **THP** a **Ucetni**. Těmto dvěma skupinám zaškrtněte políčko **Modify** (Změnit), aby mohly ukládat, měnit a mazat veškerý obsah.
*   **U: (Ucetnictvi):** Naprosto totožné nastavení jako u Faktur (odepřít všem kromě THP a Účetních, kterým přidáte Modify).
*   **S: (Spolecne_dokumenty):** Zde přidejte skupinu všech zaměstnanců (např. Domain Users) a povolte jim zápis (Write/Modify), aby zde mohli všichni ukládat sdílené dokumenty.
*   **Z: (Zalohy):** Sem přidejte pouze administrátory a dedikovaný účet vytvořený pro software na zálohování (backup_user). Všem ostatním přístup odepřete.

### 6. Verifikace a dokončení
Po potvrzení všech dialogových oken se složka začne sdílet. Cestu ke složce (UNC cesta) naleznete na kartě **Sharing**.


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Finální nastavení**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


> [!WARNING]
> Výsledné oprávnění uživatele je vždy nejvíce omezující kombinací (průnikem) oprávnění sdílení a oprávnění NTFS. Pokud má uživatel na sdílení "Read" a na NTFS "Full Control", výsledkem bude pouze "Read".

## Řešení potíží (Troubleshooting)

### Problém: Složka není v síti viditelná
> [!IMPORTANT]
> Zkontrolujte, zda je na serveru v bráně Windows Firewall povolena výjimka **File and Printer Sharing (SMB-In)**. Také ověřte, zda běží služba **Server**.

### Problém: "Access Denied" i přes správné nastavení
> [!NOTE]
> Ujistěte se, že uživatel není členem jiné skupiny, která má explicitně nastaveno **Deny** (Zakázat). Oprávnění Deny má vždy přednost před Allow.

---
[Zpět na přehled](../../README.md)


[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../../README.md)
