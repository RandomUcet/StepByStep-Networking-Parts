# Instalace a konfigurace MikroTik RouterOS

Tento návod vás provede instalací virtuálního směrovače MikroTik (RouterOS) a připojením klienta s Windows 10, ze kterého budeme RouterOS spravovat přes grafickou utilitu WinBox.

## 1. Příprava virtuálního stroje (MikroTik)

Nejprve vytvoříme nový virtuální stroj pro MikroTik (v našem případě RouterOS verze 7.19.6 z ISO souboru):

*   **Typ OS:** Zvolte `Linux`.
*   **Verze / Distribuce:** Zvolte `Other Linux (64-bit)` *(Jinak nepůjde nainstalovat!)*.
*   **RAM:** Postačí `2 GB` (2048 MB).
*   **Síťové adaptéry (Settings -> Network):**
    *   **Adapter 1:** Nastavte jako **Síťový most** (Bridged Adapter) – slouží jako WAN rozhraní.
    *   **Adapter 2:** Nastavte jako **Vnitřní síť** (Internal Network) – slouží jako LAN rozhraní.
    *   *Tip pro síťování:* U všech virtuálek vždy preventivně vygenerujte novou MAC Adresu (kliknutím na ikonku obnovení v pokročilém nastavení adaptéru), aby se stroje v síti nehádaly.

Spusťte VM. Na instalační obrazovce stiskněte klávesu **`a`** (vybere instalaci všech dostupných balíčků) a následně **`i`** pro spuštění instalace. Těsně před automatickým restartem (Reboot) odeberte instalační ISO soubor z virtuální mechaniky, ať se neustále nespouští průvodce.

## 2. Příprava klientské stanice (Windows 10)

K obsluze MikroTiku slouží šikovný nástroj jménem WinBox, který spustíme na běžných Windows 10.
Vytvořte si nový virtuální stroj s klasickým systémem Windows 10:

*   **Síťové adaptéry:**
    *   **Adapter 1:** Nastavte jako **Vnitřní síť** (Internal Network) – propojeno s druhým adaptérem MikroTiku.
    *   **Adapter 2:** Nastavte jako **NAT** (pouze pro dočasný přístup k internetu kvůli stažení aplikace WinBox).
*   V Ovládacích panelech (Centrum síťových připojení a sdílení -> Změnit nastavení adaptéru) se ve vlastnostech Ethernet adaptérů (IPv4) ujistěte, že je zaškrtnuta možnost **Získat IP adresu ze serveru DHCP automaticky**.

## 3. Stažení a připojení k aplikaci WinBox

1.  Uvnitř vašeho Windows 10 virtuálního stroje otevřete prohlížeč (např. Edge).
2.  Přejděte na adresu: [https://mikrotik.com/download/winbox](https://mikrotik.com/download/winbox)
3.  *Tip:* Pokud máte starý Microsoft Edge a stránka se špatně vykresluje, stiskněte `Ctrl + F`, zadejte "Windows (64-bit)" a tak stáhněte správnou verzi nástroje WinBox.
4.  Stažený nástroj spusťte (nemusí se instalovat).
5.  Ve spodní záložce klikněte na **Neighbors** (Okolní dostupná zařízení).
6.  Měl by se zde ukázat váš MikroTik router. Uvidíte MAC adresu a v kolonce IP Adresa bude svítit `0.0.0.0`. 
7.  Klikněte **přímo na MAC adresu** zařízení (IP se propíše do horního pole "Connect To:").
8.  Vyplňte heslo, které jste si případně v konzoli MikroTiku po instalaci nastavili, a klikněte na **Connect**.

## 4. Prvotní konfigurace v okně Quick Set

Po přihlášení do WinBoxu otevřete v levém menu hned první položku **Quick Set**. Tato obrazovka shrnuje vše nejdůležitější:

1.  **Režim:** V levém horním rohu vyberte profil **Router** nebo **Home Mesh / Bridge**.
2.  **Internet (WAN port připojený do sítě přes Bridge):** 
    *   Zaškrtněte např. **Automatic** (router získá IP z vaší domácí sítě), nebo **Static** a vyplňte napevno:
    *   *IP Address:* `192.168.1.250` (příklad)
    *   *Netmask:* `255.255.255.0`
    *   *Gateway:* `192.168.1.1` (IP adresa reálného domácího routeru)
3.  **Local Network (Vnitřní síť z Adapteru 2):**
    *   *IP Address:* `10.0.0.1` (Tato IP bude výchozí bránou pro klientské PC).
    *   *Netmask:* `255.255.255.0` (nebo /24).
    *   Zaškrtněte políčko **DHCP Server**.
    *   *DHCP Server Range:* `10.0.0.10 - 10.0.0.100` (Rozsah adres, které bude RouterOS automaticky přidělovat napojeným stanicím s Windows).
4.  Klikněte na **Apply** a **OK**. Router se překonfiguruje a vaší virtuálce s Windows 10 by nyní měla přes DHCP přistát IP adresa v rozsahu `10.0.x.x`.

---
[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../../README.md)