<div align="center">
  <h1>IT Administrace, Programování a Robotika</h1>
  <p><strong>Znalostní báze a komplexní sbírka technických návodů a tutoriálů pro IT administrátory, vývojáře a nadšence do robotiky.</strong></p>
</div>

<br/>

> **O projektu:** Tento repozitář pokrývá široké spektrum IT dovedností, od nastavení Windows Serveru přes správu Linuxu, síťové služby až po objektově orientované programování v C# a Java, či projekty s LEGO MINDSTORMS EV3.

> 🔍 **Nenašli jste co jste hledali?** Někdy je nejlepší se zeptat internetu. Podívejte se na naši stránku **[Tipy pro vyhledávání a vzorové dotazy (Queries)](./hledani-na-internetu.md)**, kde zjistíte, jak přesně formulovat svůj dotaz v prohlížeči.

---

<details open>
<summary><b>Rychlá navigace</b> <i>(Klikněte pro sbalení/rozbalení)</i></summary>

- [1. Správa Windows Serveru](#1-správa-windows-serveru)
- [2. Windows - Klientské systémy](#2-windows---klientské-systémy)
- [3. Linux (Ubuntu Server)](#3-linux-ubuntu-server)
- [4. Síťové služby](#4-síťové-služby)
- [5. Nastavení Firewallu](#5-nastavení-firewallu)
- [6. Programování a OOP (C# & Java)](#6-programování-a-oop)
- [7. Robotika (LEGO EV3)](#7-robotika-lego-ev3)

</details>

<br/>

## 1. Správa Windows Serveru

Kompletní průvodce pro nastavení a správu Windows Server prostředí, od základu až po komplexní konfigurace Active Directory a doménových řadičů.

<table width="100%">
  <tr>
    <td width="30%"><b>Nastavení VM</b></td>
    <td width="55%">Konfigurace VirtualBoxu a vnitřních sítí.</td>
    <td width="15%" align="center"><a href="./it-administration/windows-server/vm-setup.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
  <tr>
    <td><b>Instalace OS</b></td>
    <td>Podrobný postup instalace Windows Server 2019/2022.</td>
    <td align="center"><a href="./it-administration/windows-server/install-os.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
  <tr>
    <td><b>Doménový řadič</b></td>
    <td>Povýšení na DC a konfigurace AD DS.</td>
    <td align="center"><a href="./it-administration/windows-server/domain-controller.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
  <tr>
    <td><b>Uživatelé a OU</b></td>
    <td>Správa uživatelských účtů a organizační struktury.</td>
    <td align="center"><a href="./it-administration/windows-server/users-groups-ou.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
  <tr>
    <td><b>DHCP Server</b></td>
    <td>Konfigurace automatického přidělování IP adres.</td>
    <td align="center"><a href="./it-administration/windows-server/dhcp-server.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
  <tr>
    <td><b>Sdílení souborů</b></td>
    <td>Nastavení NTFS a Share oprávnění.</td>
    <td align="center"><a href="./it-administration/windows-server/file-sharing.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
  <tr>
    <td><b>Připojení klienta</b></td>
    <td>Připojení pracovní stanice Windows do domény.</td>
    <td align="center"><a href="./it-administration/windows-server/client-join.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
  <tr>
    <td><b>Skupinové politiky</b></td>
    <td>Restrikce uživatelů a automatické mapování disků.</td>
    <td align="center"><a href="./it-administration/windows-server/group-policy.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
  <tr>
    <td><b>Tiskový server</b></td>
    <td>Instalace a nasazení síťových tiskáren.</td>
    <td align="center"><a href="./it-administration/windows-server/print-server.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
  <tr>
    <td><b>Klonování VM</b></td>
    <td>Rychlé nasazení virtuálních strojů pomocí klonů.</td>
    <td align="center"><a href="./it-administration/windows-server/vm-cloning.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
</table>

<br/>

## 2. Windows - Klientské systémy

Návody pro konfiguraci Windows klientských stanic, nastavení P2P sítí a řešení sdílených prostředků.

<table width="100%">
  <tr>
    <td width="30%"><b>P2P propojení</b></td>
    <td width="55%">Peer-to-peer síť mezi VM a nastavení Firewallu se statickou IP.</td>
    <td width="15%" align="center"><a href="./it-administration/windows-client/p2p-networking.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
</table>

<br/>

## 3. Linux (Ubuntu Server)

Základy administrace serverových systémů založených na Linuxu, zprovoznění webových služeb a vzdálené správy.

<table width="100%">
  <tr>
    <td width="30%"><b>Instalace serveru</b></td>
    <td width="55%">Základní nastavení a prvotní konfigurace Ubuntu Serveru.</td>
    <td width="15%" align="center"><a href="./it-administration/linux-ubuntu/install-server.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
  <tr>
    <td><b>SSH přístup</b></td>
    <td>Vzdálená správa přes SSH z prostředí Windows.</td>
    <td align="center"><a href="./it-administration/linux-ubuntu/ssh-access.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
  <tr>
    <td><b>WordPress (LAMP)</b></td>
    <td>Kompletní webový stack: Apache, MariaDB, PHP a WordPress.</td>
    <td align="center"><a href="./it-administration/linux-ubuntu/wordpress-lamp.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
</table>

<br/>

## 4. Síťové služby

Pokročilá konfigurace oblíbených FTP klientů/serverů a nastavení firemního nebo osobního e-mailového prostředí.

<table width="100%">
  <tr>
    <td width="30%"><b>CaesarFTP</b></td>
    <td width="55%">Nastavení jednoduchého FTP serveru pro Windows.</td>
    <td width="15%" align="center"><a href="./it-administration/network-services/caesar-ftp.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
  <tr>
    <td><b>Cerberus FTP</b></td>
    <td>Pokročilý FTP server se šifrováním a podporou SSL/TLS.</td>
    <td align="center"><a href="./it-administration/network-services/cerberus-ftp.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
  <tr>
    <td><b>Total Commander</b></td>
    <td>Použití klasického TC jako výkonného FTP klienta.</td>
    <td align="center"><a href="./it-administration/network-services/total-commander-ftp.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
  <tr>
    <td><b>Kerio Connect</b></td>
    <td>Instalace a konfigurace lokálního poštovního serveru.</td>
    <td align="center"><a href="./it-administration/network-services/kerio-connect.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
  <tr>
    <td><b>Thunderbird</b></td>
    <td>Nastavení e-mailového klienta pro lokální systémy.</td>
    <td align="center"><a href="./it-administration/network-services/thunderbird-config.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
  <tr>
    <td><b>MikroTik (RouterOS)</b></td>
    <td>Instalace, spuštění WinBoxu a konfigurace WAN/LAN, DHCP.</td>
    <td align="center"><a href="./it-administration/network-services/mikrotik-setup.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
  <tr>
    <td><b>Cobian Backup</b></td>
    <td>Nastavení automatického zálohování a správné přiřazení oprávnění (Impersonation).</td>
    <td align="center"><a href="./it-administration/network-services/cobian-backup.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
  <tr>
    <td><b>PDF Creator</b></td>
    <td>Nastavení a nasdílení virtuální PDF tiskárny.</td>
    <td align="center"><a href="./it-administration/network-services/pdf-creator.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
</table>

<br/>

## 5. Nastavení Firewallu

Bezpečnost a konfigurace síťové prostupnosti mezi počítači v lokální síti. Bez těchto kroků nebudou počítače schopny sdílet soubory, tiskárny, ani odpovídat na ICMP pakety (ping).

<table width="100%">
  <tr>
    <td width="30%"><b>Firewall (P2P a Sdílení)</b></td>
    <td width="55%">Konfigurace příchozích a odchozích pravidel pro Zjišťování sítě.</td>
    <td width="15%" align="center"><a href="./it-administration/firewall/firewall-config.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
</table>

<br/>

## 6. Programování a OOP

Praktické projekty a tutoriály zaměřené na základy C#, algoritmy, objektově orientované programování, vývoj desktopových aplikací (Windows Forms) a práci s databázemi.

### Základy C# a Algoritmizace (Teorie a praxe)

<table width="100%">
  <tr>
    <td width="30%"><b>Základy a Algoritmy</b></td>
    <td width="55%">Úvod do C#, proměnné, podmínky a vývojové diagramy.</td>
    <td width="15%" align="center"><a href="./programming-oop/csharp-zaklady.md"><kbd>⮞ Teorie</kbd></a></td>
  </tr>
  <tr>
    <td><b>Pole a Cykly</b></td>
    <td>Práce se statickým polem a smyčkami (FOR, WHILE, FOREACH).</td>
    <td align="center"><a href="./programming-oop/csharp-pole-cykly.md"><kbd>⮞ Teorie</kbd></a></td>
  </tr>
  <tr>
    <td><b>Metody v C#</b></td>
    <td>Definice metod, parametry, návratové typy a přetěžování.</td>
    <td align="center"><a href="./programming-oop/csharp-metody.md"><kbd>⮞ Teorie</kbd></a></td>
  </tr>
  <tr>
    <td><b>Práce se soubory</b></td>
    <td>Ukládání a načítání textu pomocí StreamWriter a třídy File.</td>
    <td align="center"><a href="./programming-oop/csharp-soubory.md"><kbd>⮞ Teorie</kbd></a></td>
  </tr>
  <tr>
    <td><b>Konzolové ukázky</b></td>
    <td>Praktické kódy (Vánoční stromek, Kalkulačka a další ukázky).</td>
    <td align="center"><a href="./programming-oop/csharp-ukazky.md"><kbd>⮞ Prakticky</kbd></a></td>
  </tr>
</table>

### Pokročilé C# Projekty (OOP a WinForms)

<table width="100%">
  <tr>
    <td width="30%"><b>Editor obrázků</b></td>
    <td width="55%">Kompletní tutoriál Photoshop-like aplikace (filtry, míchání, ASCII Art).</td>
    <td width="15%" align="center"><a href="./programming-oop/csharp-photoeditor.md"><kbd>⮞ Tutoriál</kbd></a></td>
  </tr>
  <tr>
    <td><b>ColorMatrix Filtr</b></td>
    <td>Matematická transformace barev (jas, kontrast, alfa) přes matice 5x5.</td>
    <td align="center"><a href="./programming-oop/csharp-colormatrix.md"><kbd>⮞ Projekt</kbd></a></td>
  </tr>
  <tr>
    <td><b>Malování</b></td>
    <td>Jednoduchý kreslící program využívající GDI+ a myš (čáry, pera, barvy).</td>
    <td align="center"><a href="./programming-oop/csharp-malovani.md"><kbd>⮞ Projekt</kbd></a></td>
  </tr>
  <tr>
    <td><b>Knihovní systém v1</b></td>
    <td>Desktopová aplikace pro správu knihovny se základní SQLite databází.</td>
    <td align="center"><a href="./programming-oop/csharp-knihovna.md"><kbd>⮞ Tutoriál</kbd></a></td>
  </tr>
  <tr>
    <td><b>Knihovní systém v2</b></td>
    <td>Pokročilá verze s centrální <code>SQLClass</code> a lepším oddělením vrstev (modely, UI).</td>
    <td align="center"><a href="./programming-oop/csharp-knihovna-2.md"><kbd>⮞ Projekt</kbd></a></td>
  </tr>
  <tr>
    <td><b>Databázový CRUD</b></td>
    <td>Základy SQL příkazů s parametrizací a odděleným Repozitářem.</td>
    <td align="center"><a href="./programming-oop/csharp-databaze.md"><kbd>⮞ Projekt</kbd></a></td>
  </tr>
  <tr>
    <td><b>Safe (Události)</b></td>
    <td>Ukázka využití událostí (Events), delegátů a principů dědičnosti.</td>
    <td align="center"><a href="./programming-oop/csharp-events-delegates.md"><kbd>⮞ Kód</kbd></a></td>
  </tr>
  <tr>
    <td><b>Natankuj (Třída Auto)</b></td>
    <td>Ukázka čistého OOP - Tvorba třídy, vlastnosti, obslužné metody.</td>
    <td align="center"><a href="./programming-oop/csharp-automobil-natankuj.md"><kbd>⮞ Kód</kbd></a></td>
  </tr>
</table>

### Java Koncepty

<table width="100%">
  <tr>
    <td width="30%"><b>Zaměstnanci</b></td>
    <td width="55%">Práce s abstraktními třídami a polymorfním chováním.</td>
    <td width="15%" align="center"><a href="./programming-oop/java-abstract-employees.md"><kbd>⮞ Kód</kbd></a></td>
  </tr>
  <tr>
    <td><b>Generika (Barvy)</b></td>
    <td>Typové parametry a implementace univerzálních generických tříd.</td>
    <td align="center"><a href="./programming-oop/java-generics-colors.md"><kbd>⮞ Kód</kbd></a></td>
  </tr>
  <tr>
    <td><b>Enumy (Rozvrh)</b></td>
    <td>Výčtové typy s integrovanými konstruktory a interními metodami.</td>
    <td align="center"><a href="./programming-oop/java-enums-schedule.md"><kbd>⮞ Kód</kbd></a></td>
  </tr>
  <tr>
    <td><b>Interfacy (Kalkulátor)</b></td>
    <td>Definice kontraktů a flexibilní polymorfní rozhraní.</td>
    <td align="center"><a href="./programming-oop/java-interfaces-calc.md"><kbd>⮞ Kód</kbd></a></td>
  </tr>
</table>

<br/>

## 7. Robotika (LEGO EV3)

Stavba a oživení projektů se stavebnicí LEGO MINDSTORMS EV3. Skvělé pro pochopení základů automatizace, senzoriky a vizuálního programování.

<table width="100%">
  <tr>
    <td width="30%"><b>Základní pojmy a výbava</b></td>
    <td width="55%">Úvod do robotiky, typy senzorů, mozek robota a přehled softwaru.</td>
    <td width="15%" align="center"><a href="./robotics-ev3/roi-zaklady.md"><kbd>⮞ Teorie</kbd></a></td>
  </tr>
  <tr>
    <td><b>Třídička kostek</b></td>
    <td>Automatizace třídění fyzických kostek podle zjištěných barev.</td>
    <td align="center"><a href="./robotics-ev3/brick-sorter.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
  <tr>
    <td><b>Sledovač čáry</b></td>
    <td>Přesné sledování vodící čáry s využitím sofistikované PID regulace.</td>
    <td align="center"><a href="./robotics-ev3/line-follower.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
  <tr>
    <td><b>Gyro Boy</b></td>
    <td>Samobalanční robot na dvou kolech využívající Gyro senzor.</td>
    <td align="center"><a href="./robotics-ev3/gyro-boy.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
  <tr>
    <td><b>Robotické rameno</b></td>
    <td>Pohyb a manipulace s objekty přes souřadnicový systém X, Y, Z.</td>
    <td align="center"><a href="./robotics-ev3/robotic-arm.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
  <tr>
    <td><b>Úvod do Scratch</b></td>
    <td>Základy vizuálního blokového programování a logiky.</td>
    <td align="center"><a href="./robotics-ev3/scratch-intro.md"><kbd>⮞ Návod</kbd></a></td>
  </tr>
</table>

---

## Jak začít?

1. **Vyberte si sekci:** Zajímají vás servery, kód, nebo roboti? Vyberte z tabulek výše!
2. **Následujte návody:** Návody jsou psány přehledně, s ústřižky kódů a konkrétními kroky.
3. **Máte potíže?:** Podívejte se do sekce řešení problémů, která je součástí každé sekce, případně prozkoumejte samotný zdrojový kód.

> **Upozornění:** Tento repozitář nesdílí žádné lokální adresy, uživatelská hesla ani absolutní cesty k hardwaru.

<br/>
<p align="center">
  <i>Tento projekt je volně dostupný pro vzdělávací účely.</i>
</p>