# Správa uživatelů, skupin a organizačních jednotek (OU)

>  **Tip pro Windows Server:** Doporučujeme instalovat vždy anglickou (English) verzi Windows Serveru. Pokud dojde k chybě, anglické chybové hlášky se na internetu dohledávají (např. na fórech jako Stack Overflow nebo Reddit) podstatně snadněji než jejich české překlady.


Tento dokument poskytuje podrobný návod na správu objektů v Active Directory Domain Services (AD DS). Správná konfigurace organizačních jednotek, bezpečnostních skupin a uživatelů je základem bezpečnosti a přehlednosti každé síťové infrastruktury.

## Podrobný postup konfigurace

### 1. Návrh a vytvoření organizačních jednotek (OU)
Organizační jednotky slouží k logickému uspořádání domény a jsou cílem pro aplikaci GPO (Group Policy Object).
- Otevřete konzoli **Active Directory Users and Computers (ADUC)** z menu Tools v Server Manageru.
- Klikněte pravým tlačítkem na kořen vaší domény → **New** → **Organizational Unit**.
- Doporučujeme vytvořit strukturu odpovídající reálné hierarchii organizace (např. Vedení, IT, Učitelé, Žáci).


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Vytváření OU**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


### 2. Konfigurace bezpečnostních skupin
Skupiny zjednodušují správu oprávnění. Místo přiřazování práv jednotlivcům je přiřazujete skupinám.
- V příslušné OU klikněte pravým tlačítkem → **New** → **Group**.
- **Group Scope:** Zvolte **Global** (pro doménové prostředí).
- **Group Type:** Zvolte **Security** (pro řízení přístupu ke zdrojům).


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Skupiny v AD**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


### 3. Vytvoření uživatelského účtu
Při vytváření uživatele je nutné dodržovat standardizované pojmenování (např. `prijmeni.jmeno`).
- Pravým tlačítkem na OU → **New** → **User**.
- Vyplňte **First name**, **Last name** a **User logon name** (UPN).


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Nový uživatel**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


### 4. Zabezpečení účtu a nastavení hesla
V doménovém prostředí je nutné dbát na bezpečnostní politiku hesel.
- Nastavte dostatečně složité počáteční heslo.
- Zaškrtněte **User must change password at next logon**, aby si uživatel při prvním přihlášení zvolil vlastní tajné heslo.


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Nastavení hesla**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


> [!IMPORTANT]
> Pro administrátorské nebo servisní účty se doporučuje zaškrtnout **Password never expires**, pokud je to vyžadováno politikou organizace, u běžných uživatelů však tuto volbu nepoužívejte.

### 5. Správa členství ve skupinách
Členství ve skupině definuje uživatelova práva (např. přístup k síťovým diskům, tiskárnám).
- Klikněte pravým tlačítkem na uživatele a zvolte **Add to a group...**.
- V dialogovém okně zadejte název cílové skupiny a klikněte na **Check Names**. Systém automaticky ověří a doplní název objektu.


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Přidání do skupiny**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Kontrola názvu**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Potvrzení operace**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


### 6. Praktické ukázky struktur v OU
Příklady správně strukturovaných jednotek s odpovídajícími uživateli a skupinami pro různá oddělení.

- **OU Vedení:** Obsahuje manažerské účty s vyššími privilegii.

*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **OU Vedení**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


- **OU Učitelé:** Strukturální příklad pro pedagogické pracovníky.

*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **OU Učitelé**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


### 7. Speciální servisní účty (Backup User)
Pro automatizované procesy, jako je zálohování, je nutné vytvořit dedikované servisní účty s minimálními potřebnými oprávněními (Least Privilege).
- Příklad: Účet `backup_user` s právy pro přístup k datovým úložištím.


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Zálohovací účet**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


### 8. Komplexní přehled výsledné struktury
Výsledkem by měla být logicky členěná stromová struktura, kde každý objekt má své definované místo a roli.


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Finální struktura**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


## Diagnostika a řešení potíží (Troubleshooting)

### Uživatel se nemůže přihlásit
> [!WARNING]
> Pokud je přihlášení odmítnuto, ověřte v konzoli ADUC (záložka Account), zda účet není uzamčen z důvodu opakovaného špatného zadání hesla (Account is locked out) nebo zda nevypršela platnost účtu.

### Objekt nelze smazat (Protection)
> [!TIP]
> Pokud při pokusu o smazání OU obdržíte chybu, je aktivována ochrana proti náhodnému smazání. V menu View zapněte **Advanced Features**, otevřete Properties dané OU, v záložce Object odškrtněte **Protect object from accidental deletion**.

### Změny v AD se neprojevily na klientovi
> [!IMPORTANT]
> Po změně členství ve skupině je nutné, aby se uživatel na klientské stanici odhlásil a znovu přihlásil. Teprve při novém přihlášení se aktualizuje jeho přístupový token se seznamem skupin.

---
[Zpět na přehled](../../README.md)


[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../../README.md)
