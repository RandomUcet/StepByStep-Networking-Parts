# P2P propojení a zabezpečení ve VirtualBoxu

>  **Tip pro Windows klientské systémy:** Instalujte raději Windows 10 než Windows 11, lépe se v něm dělá, prostředí je stabilnější a nerozbíjí se tolik při testování P2P sítí a sdílení složek.


Komplexní návod na vytvoření peer-to-peer sítě mezi dvěma virtuálními stroji s Windows 10/11, včetně sdílení souborů, tiskáren a instalace PDF Creatoru.

---

## Obsah

1. [Konfigurace VirtualBoxu](#1-konfigurace-virtualboxu)
2. [Příprava systému a identita](#2-příprava-systému-a-identita)
3. [Síťové parametry (Statické IP)](#3-síťové-parametry-statické-ip)
4. [Nastavení Firewallu](#4-nastavení-firewallu)
5. [Vytvoření sdíleného bodu](#5-vytvoření-sdíleného-bodu)
6. [Připojení síťové jednotky](#6-připojení-síťové-jednotky)
7. [Instalace PDF Creatoru](#7-instalace-pdf-creatoru)
8. [Sdílení tiskárny](#8-sdílení-tiskárny)
9. [Řešení problémů](#řešení-problémů)
10. [Užitečné odkazy](#užitečné-odkazy)

---

## 1. Konfigurace VirtualBoxu

Aby spolu počítače mohly komunikovat v izolovaném prostředí, musíme je umístit do stejné virtuální sítě.

### Postup

1. U **obou VM** přejděte do **Nastavení** → **Síť**
2. Nastavte následující parametry:

| Parametr | Hodnota |
|----------|---------|
| Připojeno k | **Vnitřní síť** (Internal Network) |
| Název | `intnet` (musí být u obou stejný) |

3. V sekci **Pokročilé** klikněte na ikonu modrých šipek (Refresh) u položky **MAC adresa**, aby měl každý stroj unikátní identifikátor.


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Konfigurace sítě VirtualBox**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.



*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Nastavení vnitřní sítě**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


> **Tip:** Internal Network vytváří izolovanou síť pouze mezi VM - nemají přístup k internetu ani k hostitelskému systému.

---

## 2. Příprava systému a identita

Po spuštění Windows je potřeba stroje pojmenovat a zabezpečit.

### Změna názvu počítače

1. Přejděte do **Nastavení** → **Systém** → **O systému**
2. Klikněte na **Přejmenovat tento počítač**

| Počítač | Název |
|---------|-------|
| PC 1 | `KLIENT1` |
| PC 2 | `KLIENT2` |


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Přejmenování počítače**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


### Nastavení hesla

Oba uživatelské účty musí mít nastavené heslo pro možnost síťového sdílení.

1. **Nastavení** → **Účty** → **Možnosti přihlášení** → **Heslo**
2. Nastavte heslo (např. `Heslo11!`)


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Nastavení hesla**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


> **Důležité:** Windows vyžaduje heslo pro síťové přihlášení. Bez hesla nebude možné se připojit ke sdíleným prostředkům.

---

## 3. Síťové parametry (Statické IP)

Protože ve vnitřní síti obvykle neběží DHCP server, musíme adresy zadat ručně.

### Postup konfigurace

1. Přejděte do: **Ovládací panely** → **Síť a internet** → **Síťová připojení**
2. Pravým tlačítkem na síťový adaptér → **Vlastnosti**
3. Vyberte **Protokol IP verze 4 (TCP/IPv4)** → **Vlastnosti**


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Vlastnosti IPv4**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


### Tabulka IP adres

| Parametr | KLIENT1 | KLIENT2 |
|----------|---------|---------|
| IP adresa | `192.168.0.1` | `192.168.0.2` |
| Maska podsítě | `255.255.255.252` | `255.255.255.252` |
| Výchozí brána | *ponechte prázdné* | *ponechte prázdné* |


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Konfigurace statické IP**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


> **Poznámka:** Maska `/30` (255.255.255.252) umožňuje pouze 2 použitelné adresy - ideální pro P2P propojení.

### Ověření konektivity

Po konfiguraci otestujte spojení pomocí příkazového řádku:

```cmd
ping 192.168.0.2    # z KLIENT1
ping 192.168.0.1    # z KLIENT2
```

---

## 4. Nastavení Firewallu

Povolení sítě mezi klienty bylo přesunuto do vlastní sekce Firewall.
[<kbd> ⮞ Přejít na návod Firewallu </kbd>](../firewall/firewall-config.md)


---

## 5. Vytvoření sdíleného bodu

Na počítači **KLIENT1** vytvoříme sdílenou složku.

### Postup

1. Vytvořte libovolnou složku (např. `C:\Sdilena`)
2. Pravým tlačítkem → **Vlastnosti** → karta **Sdílení**
3. Klikněte na tlačítko **Sdílet...**
4. Přidejte sebe nebo `Everyone` a nastavte úroveň oprávnění


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Vlastnosti sdílení**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


### Rozšířené sdílení

1. Klikněte na **Rozšířené sdílení**
2. Zaškrtněte **Sdílet tuto složku**
3. Potvrďte název sdílení: `\\KLIENT1\Sdilena`


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Sdílená složka**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


---

## 6. Připojení síťové jednotky

Na počítači **KLIENT2** se připojíme ke sdílené složce.

### Postup

1. Otevřete **Tento počítač**
2. V horním menu klikněte na **Připojit síťovou jednotku**
3. Zadejte cestu: `\\KLIENT1\Sdilena` nebo `\\192.168.0.1\Sdilena`
4. Zaškrtněte **Připojit pomocí jiných přihlašovacích údajů**


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Připojení jednotky**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


### Přihlašovací údaje

| Pole | Hodnota |
|------|---------|
| Uživatelské jméno | *(uživatelské jméno na KLIENT1)* |
| Heslo | `Heslo11!` |


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Síťová jednotka**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


---

## 7. Sdílení tiskáren a PDF

Postup pro instalaci a síťové sdílení PDF Creatoru byl pro větší přehlednost přesunut do vlastního návodu do sekce Síťových služeb.
[<kbd> ⮞ Přejít na návod PDF Creator </kbd>](../network-services/pdf-creator.md)


---

## Řešení problémů

### Nelze pingnout druhý počítač

1. Zkontrolujte, zda jsou obě VM ve stejné Internal Network
2. Ověřte správnost IP adres a masky
3. Zkontrolujte, zda je firewall nastaven správně

### Nelze se připojit ke sdílené složce

1. Ověřte, že má uživatel na KLIENT1 nastavené heslo
2. Zkontrolujte oprávnění sdílení
3. Vypněte dočasně firewall pro diagnostiku

### Tiskárna není viditelná

1. Zkontrolujte, zda je tiskárna sdílena
2. Ověřte síťové připojení pomocí `\\IP_adresa`
3. Restartujte službu **Zařazování tisku** (Print Spooler)

```cmd
net stop spooler
net start spooler
```

---

## Užitečné odkazy

### Instalace Windows ve VirtualBoxu
- [Instructables: Instalace Windows 10 na VirtualBox](https://www.instructables.com/GuideHow-to-Install-Windows-10-on-Oracle-VM-Virtua/) - Podrobný průvodce s obrázky
- [Kubuntu Focus: VirtualBox W10 Guide](https://kfocus.org/wf/vbox.html) - Profesionální návod krok za krokem

### Síťové nastavení a sdílení
- [Stack Overflow: VirtualBox Internal Network](https://stackoverflow.com/questions/21069908/how-to-create-a-connection-between-two-virtual-machines-in-virtualbox) - Diskuze o propojení VM
- [Reddit r/VirtualBox: Networking Guide](https://www.reddit.com/r/virtualbox/comments/8z3hy4/networking_two_vms_together/) - Komunitní tipy pro síťování VM

### Windows File Sharing
- [Microsoft Docs: Sdílení souborů](https://support.microsoft.com/cs-cz/windows/sd%C3%ADlen%C3%AD-soubor%C5%AF-v-pr%C5%AFzkumn%C3%ADku-soubor%C5%AF-c49f5db4-3d71-4a43-b8bb-4c58c9a6d8c8) - Oficiální dokumentace
- [Stack Overflow: Windows File Sharing](https://stackoverflow.com/questions/tagged/windows-file-sharing) - Řešení běžných problémů

### PDF Creator
- [PDF Creator Documentation](https://docs.pdfforge.org/pdfcreator/en/) - Oficiální dokumentace
- [Reddit r/sysadmin: PDF Creator Deployment](https://www.reddit.com/r/sysadmin/comments/fwjxl8/pdfcreator_network_printer/) - Diskuze o síťovém nasazení

---

## Shrnutí

Po dokončení tohoto návodu budete mít:

- Dva propojené virtuální stroje v izolované síti
- Funkční sdílení souborů mezi počítači
- Sdílenou PDF tiskárnu dostupnou z obou strojů
- Zabezpečené připojení pomocí hesel

Toto nastavení je ideální pro testování síťových konfigurací, vývoj aplikací nebo vzdělávací účely.


[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../../README.md)
