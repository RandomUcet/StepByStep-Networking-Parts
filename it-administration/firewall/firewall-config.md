# Konfigurace Windows Defender Firewallu

> **Tip pro Nastavení Firewallu:** Povolení Zjišťování sítě a Sdílení souborů/tiskáren na veřejných sítích (např. na letišti nebo v kavárně) je obrovské bezpečnostní riziko. Tyto kroky dělejte výhradně ve vnitřní privátní nebo doménové síti!

Tento postup je nezbytný k tomu, aby o sobě počítače ve vnitřní síti věděly (šlo je "pingnout") a dokázaly spolu bez překážek sdílet soubory a tiskárny. Ve výchozím stavu Windows z důvodu bezpečnosti všechna tato příchozí i odchozí spojení striktně blokuje.

## Postup nastavení Firewallu

Tento postup musíte udělat identicky na všech počítačích (klientech), které mají v síti spolupracovat!

1. Na prvním počítači stiskněte klávesu `Win`, napište **firewall** a z nabídky otevřete aplikaci **Windows Defender Firewall s pokročilým zabezpečením** (případně spusťte přes `wf.msc`).

### Příchozí pravidla (Inbound Rules)
Zde budeme definovat, jakou komunikaci počítač přijme zvenčí.
1. V levém sloupci klikněte na položku **Příchozí pravidla** (Inbound Rules).
2. Uprostřed se zobrazí obrovský seznam stovek pravidel.
3. Klikněte myší na záhlaví prostředního sloupce s názvem **Název** (Name). Tím se celý seznam inteligentně seřadí podle abecedy a usnadní nám hledání.
4. Sjeďte dolů a najděte blok pravidel s názvem **Sdílení souborů a tiskáren** (File and Printer Sharing). Označte je všechna pomocí Shiftu, klikněte na ně pravým tlačítkem a zvolte **Povolit pravidlo** (Enable Rule). Pravidla zezelenají.
5. Sjeďte k bloku pravidel s názvem **Zjišťování sítě** (Network Discovery). Opět označte všechna tato pravidla, pravým tlačítkem a zvolte **Povolit pravidlo**.

### Odchozí pravidla (Outbound Rules)
Zde definujeme, jak se náš počítač může na síti chovat směrem ven (jak on sám hledá ostatní).
1. V levém sloupci přepněte na **Odchozí pravidla** (Outbound Rules).
2. Znovu klikněte na záhlaví sloupce **Název** pro abecední seřazení.
3. Úplně stejně jako v předchozím kroku: najděte všechna pravidla pod názvem **Sdílení souborů a tiskáren**, označte je, klikněte pravým tlačítkem a dejte **Povolit pravidlo**.
4. Najděte a označte pravidla **Zjišťování sítě**, klikněte pravým tlačítkem a znovu **Povolit pravidlo**.

### Závěrečný krok
Nyní přejděte fyzicky (nebo virtuálně) na **druhý počítač v síti** a celý tento postup krok za krokem zopakujte. 

Od této chvíle by na sebe měly oba počítače bez problému v příkazovém řádku zareagovat na povel `ping (IP_Adresa_Druheho_Stroje)` a uvidí na sebe v síťovém sdílení a uvidí si na tiskárny.

---
[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../../README.md)