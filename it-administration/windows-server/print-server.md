# Instalace a konfigurace tiskového serveru

>  **Tip pro Windows Server:** Doporučujeme instalovat vždy anglickou (English) verzi Windows Serveru. Pokud dojde k chybě, anglické chybové hlášky se na internetu dohledávají (např. na fórech jako Stack Overflow nebo Reddit) podstatně snadněji než jejich české překlady.


Tiskový server v prostředí Windows Server umožňuje centralizovanou správu tiskáren, ovladačů a tiskových front pro všechny doménové klienty. Tento dokument popisuje instalaci role a proces sdílení tiskárny v síti.

## Podrobný postup konfigurace

### 1. Instalace role Print and Document Services
Otevřete **Server Manager**, klikněte na **Add Roles and Features** a v průvodci vyberte roli **Print and Document Services**.


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Instalace role**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


1. V rámci výběru služeb role zaškrtněte **Print Server**.
2. Dokončete instalaci a v případě potřeby restartujte server.

### 2. Správa tisku a přidání tiskárny
Po instalaci role otevřete nástroj **Print Management** (Správa tisku) z nabídky Administrative Tools.


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Přidání tiskárny**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


1. Rozbalte položku **Print Servers** → [Váš_Server] → **Printers**.
2. Klikněte pravým tlačítkem a zvolte **Add Printer...**.
3. Vyberte metodu připojení (např. pomocí IP adresy přes port TCP/IP) a zadejte adresu tiskárny.
4. Vyberte nebo nainstalujte odpovídající ovladač pro daný model tiskárny.

### 3. Sdílení tiskárny pro doménové klienty
Aby byla tiskárna dostupná v síti, musí být explicitně sdílena.

> [!TIP]
> Ve vlastnostech tiskárny (karta **Sharing**) zaškrtněte **Share this printer** a zadejte název sdílení. Uživatelé pak tiskárnu naleznou zadáním cesty `\\Název_Serveru` v Průzkumníku souborů.

## Řešení potíží (Troubleshooting)

### Problém: Klienti nemohou tiskárnu v síti najít
> [!IMPORTANT]
> Prověřte: 1) Zda je v nastavení sdílení tiskárny povoleno vyhledávání. 2) Zda je v bráně Windows Firewall povolena výjimka pro tiskové služby. 3) Zda mají uživatelé na kartě **Security** oprávnění k tisku (Print).

### Problém: Tiskárna nekomunikuje přes TCP/IP
> [!WARNING]
> V testovacím prostředí (VirtualBox) nemusí být reálná tiskárna dostupná. Pro účely testování lze přidat tiskárnu typu "Generic / Text Only" na lokální port (LPT1) nebo využít virtuální tiskárnu do PDF (Microsoft Print to PDF).

---
[Zpět na přehled](../../README.md)


[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../../README.md)
