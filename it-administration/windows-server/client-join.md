# Připojení klientské stanice do domény Active Directory

>  **Tip pro Windows Server:** Doporučujeme instalovat vždy anglickou (English) verzi Windows Serveru. Pokud dojde k chybě, anglické chybové hlášky se na internetu dohledávají (např. na fórech jako Stack Overflow nebo Reddit) podstatně snadněji než jejich české překlady.


Tento dokument podrobně popisuje proces integrace klientského počítače se systémem Windows do doménového prostředí. Zahrnuje konfiguraci DNS, samotné připojení k doméně a první přihlášení doménovým účtem.

## Podrobný postup

### 1. Konfigurace DNS na klientské stanici
Pro úspěšné vyhledání doménového řadiče musí mít klient správně nastavenou adresu DNS serveru. Tato adresa musí odpovídat IP adrese vašeho doménového řadiče (např. 192.168.1.1).


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Nastavení DNS**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


> [!IMPORTANT]
> DNS server na klientovi NESMÍ být nastaven na automatiku (DHCP) nebo na veřejné servery jako 8.8.8.8. Bez nasměrování na doménový řadič nebude možné doménu v síti lokalizovat.

Ověřte konektivitu k serveru pomocí příkazu ping:
```powershell
ping [IP_ADRESA_SERVERU]
```

### 2. Změna příslušnosti k doméně
Otevřete **Vlastnosti systému** (System Properties) – lze použít klávesovou zkratku `Win + Pause/Break` nebo vyhledat "Tento počítač", kliknout pravým tlačítkem a zvolit Vlastnosti.


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Změna nastavení**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


1. Klikněte na **Change settings** (Změnit nastavení).
2. Na kartě **Computer Name** klikněte na **Change...** (Změnit).
3. V sekci "Member of" přepněte z Workgroup na **Domain**.
4. Zadejte plný název vaší domény (např. `skola.local`).


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Zadání domény**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


### 3. Autorizace připojení
Po potvrzení názvu domény se zobrazí výzva k zadání přihlašovacích údajů. Zadejte jméno a heslo uživatele, který má právo připojovat počítače do domény (typicky doménový administrátor).


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Přihlášení administrátora**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


> [!NOTE]
> Pokud se zobrazí uvítací zpráva "Welcome to the [domain] domain", bylo připojení úspěšné.

### 4. Restartování systému
Po úspěšném připojení je nezbytný restart počítače, aby se změny projevily a aby se klientská stanice mohla plně integrovat do doménové struktury.


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Restart stanice**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


### 5. První přihlášení doménovým účtem
Na přihlašovací obrazovce zvolte možnost **Other user** (Jiný uživatel). Do pole uživatelského jména zadejte název domény a jméno uživatele ve formátu `DOMÉNA\uživatel` (např. `SKOLA\jan.novak`).


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Přihlášení uživatele**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


### 6. Verifikace v Active Directory
Na serveru v konzoli **Active Directory Users and Computers** (ADUC) ověřte, že se nový počítač objevil v kontejneru **Computers**.


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Ověření v AD**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


Na klientské stanici můžete ověřit aktuální doménu příkazem:
```powershell
whoami
echo %USERDOMAIN%
```

## Řešení potíží (Troubleshooting)

### Problém: Doménový řadič nebyl nalezen (Active Directory Domain Controller could not be contacted)
> [!IMPORTANT]
> Nejčastější příčinou je špatné nastavení DNS. Spusťte příkaz `ipconfig /all` a ujistěte se, že položka "DNS Servers" obsahuje pouze IP adresu vašeho serveru. Také zkontrolujte, zda jsou obě VM v rámci VirtualBoxu ve stejné vnitřní síti (Internal Network).

### Problém: Chyba při zadávání přihlašovacích údajů
> [!WARNING]
> Ujistěte se, že používáte správný formát jména (např. `Administrator`). Pokud se pokoušíte o připojení a účet je zablokován nebo má vypršené heslo, proces selže.

---
[Zpět na přehled](../../README.md)


[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../../README.md)
