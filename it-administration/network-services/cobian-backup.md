# Instalace a zálohování s Cobian Backup

Tento návod ukazuje, jak spolehlivě nastavit automatické i manuální zálohování složek ve Windows pomocí nástroje Cobian Backup. 

## 1. Instalace
1. Připojte nebo vložte ISO soubor `maturita_new` a najděte v něm instalační soubor Cobian Backup.
2. Spusťte instalaci a projděte standardním průvodcem. Důležité je ponechat výchozí nastavení pro spouštění (často se instaluje jako služba běžící na pozadí pod Local System účtem, nebo pod konkrétním uživatelem).

## 2. Příprava uživatelských oprávnění
Je naprosto klíčové, aby účet, pod kterým bude záloha probíhat, měl dostatečná práva k oběma místům (odkud se zálohuje a kam se zálohuje).
* Ujistěte se, že máte vytvořeného vyhrazeného uživatele pro zálohování (případně využijte aktuálního administrátora domény).
* Tento uživatel **musí mít povolený přístup pro čtení** do zdrojové složky, kterou chceme zálohovat.
* Tento uživatel **musí mít povolený přístup pro zápis a změny** na cílovém disku (disku vyhrazeném pro zálohy).

## 3. Vytvoření zálohovací úlohy (Task)
1. Spusťte aplikaci Cobian Backup z plochy nebo ze systémové lišty.
2. Klikněte na ikonu `+` nebo v horním menu zvolte **Task -> New task** (Nová úloha).
3. Na první záložce (General) si úlohu nějak pojmenujte, např. "Denní záloha dokumentů".
4. Přepněte se do záložky **Files** (Soubory).
   * V sekci **Source** (Zdroj) klikněte na tlačítko "Add" a vyberte složku, kterou budeme pravidelně zálohovat.
   * V sekci **Destination** (Cíl) klikněte na tlačítko "Add" a vyberte bezpečný disk vyhrazený pro zálohy.

## 4. Běh pod jiným uživatelem (Impersonation)
Aby měl Cobian Backup při běhu služby zaručena správná oprávnění k oběma diskům (zvláště užitečné v doméně nebo při sdílení sítě):
1. Přejděte v nastavení úlohy do záložky **Advanced** (Rozšířené / Pokročilé).
2. Najděte část **Impersonation**.
3. Zaškrtněte **Run the task as another user** (Spustit úlohu jako jiný uživatel).
4. Do příslušných polí zadejte:
   * Jméno uživatele pro zálohy.
   * Název vaší domény.
   * Heslo k tomuto účtu.

## 5. Spuštění a kontrola
1. Jakmile je úloha uložena, objeví se v hlavním okně aplikace v seznamu.
2. Vyberte ji a nahoře klikněte na tlačítko **Run selected tasks** (Modrá šipečka, obdoba tlačítka "Play").
3. V dolním okně uvidíte běžící procesní log. Uvidíte přesně, kolik složek a souborů bylo zpracováno.
4. **Poznámka k chybám:** Pokud se v logu objeví červený chybový řádek `cannot contact shadow volume copy requester`, můžete jej v klidu ignorovat. Nemá na fyzické překopírování dat do zálohy žádný vliv a záloha proběhne i přes toto varování.
5. Pro ověření fyzicky přejděte na váš cílový (zálohovací) disk a zkontrolujte, že se tam objevil nový ZIP archiv nebo složka s dnešním datem a správnými daty.

---
[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../../README.md)