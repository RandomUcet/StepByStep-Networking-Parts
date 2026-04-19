# Instalace WordPressu na Ubuntu (LAMP stack)

>  **Tip pro Linuxové servery:** Po každé úspěšné konfiguraci (například po instalaci apache nebo db serveru) doporučujeme vytvořit ve VirtualBoxu tzv. Snímek (Snapshot). Pokud se něco v dalším kroku pokazí, velmi jednoduše a rychle se vrátíte do plně funkčního stavu.


Kompletní postup instalace webové prezentace běžící na systému WordPress v prostředí Ubuntu Serveru. Tento proces zahrnuje nastavení webového serveru Apache, databáze MariaDB, interpretu PHP a samotného CMS WordPress.

## Podrobný postup instalace

### 1. Webový server Apache
Aktualizujte seznam balíčků a nainstalujte Apache2. Po instalaci povolte jeho spuštění při startu systému.

```bash
sudo apt update
sudo apt upgrade -y
sudo apt install apache2 -y
sudo systemctl enable apache2
sudo systemctl start apache2
```

> [!NOTE]
> **Ověření funkčnosti:** První ověření funkčnosti Apache proveďte přímo v Ubuntu zadáním příkazu `systemctl status apache2`. Pokud vidíte zelené slůvko "active", Apache běží. Následně přejděte na Windows klienta, otevřete prohlížeč a zadejte IP adresu vašeho Ubuntu serveru. Měla by se objevit výchozí stránka Apache s nepřehlédnutelným nápisem **"It works!"**.

### 2. Databázový server MariaDB
Pro uložení obsahu WordPressu je nezbytný databázový server. Po instalaci spusťte bezpečnostní skript.

```bash
sudo apt install mariadb-server -y
sudo mysql_secure_installation
```

> [!IMPORTANT]
> Během konfigurace se doporučuje zvolit následující:
> - Nastavit heslo pro root: **Y**
> - Odebrat anonymní uživatele: **Y**
> - Zakázat vzdálené přihlášení pro uživatele root: **Y**
> - Odstranit testovací databázi: **Y**

### 3. Příprava databáze a uživatele
Přihlaste se do konzole MariaDB a vytvořte vyhrazenou databázi a uživatele s dostatečnými oprávněními pro WordPress.

```sql
sudo mysql
-- Vytvoření databáze s podporou kódování UTF-8
CREATE DATABASE wordpress CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Vytvoření uživatele a nastavení hesla
CREATE USER 'wpuser'@'localhost' IDENTIFIED BY 'SilneHeslo123!';

-- Přidělení práv uživateli k databázi
GRANT ALL PRIVILEGES ON wordpress.* TO 'wpuser'@'localhost';
FLUSH PRIVILEGES;
EXIT;
```

### 4. Instalace PHP a podpůrných modulů
WordPress pro svůj běh vyžaduje jazyk PHP a několik jeho rozšiřujících modulů pro práci s databází, grafikou a XML soubory.

```bash
sudo apt install php libapache2-mod-php php-mysql php-curl php-gd php-mbstring php-xml php-xmlrpc php-soap php-intl php-zip -y
sudo systemctl restart apache2
```

### 5. Stažení a příprava WordPressu
Stáhněte si nejnovější verzi WordPressu přímo z oficiálních stránek, rozbalte ji do výchozí složky webového serveru (`/var/www/html`) a nastavte správného vlastníka souborů (uživatel `www-data`).

```bash
cd /tmp
sudo wget https://wordpress.org/latest.tar.gz
sudo tar -xvzf latest.tar.gz
sudo mv wordpress/* /var/www/html/
sudo chown -R www-data:www-data /var/www/html
sudo chmod -R 755 /var/www/html
```

> [!WARNING]
> Při stahování přes `wget` dejte velký pozor na stahovanou verzi nebo výpadky na straně WordPressu. Často se může stát, že starý balíček z předchozích cvičení způsobí potíže s instalací. Vždy doporučujeme použít aktuální `latest.tar.gz` a zkontrolovat úspěšnost stažení.

### 6. Odstranění výchozí Apache stránky
Aby WordPress správně naběhl z hlavní složky html, odstraňte (nebo přejmenujte) výchozí `index.html`, který tam vytvořil Apache.

```bash
sudo rm /var/www/html/index.html
```

### 7. Konfigurace Apache VirtualHost a přepisování URL (Rewrite)
Aby mohl WordPress správně pracovat s trvalými odkazy a směřováním, je nutné upravit konfiguraci.

Otevřete výchozí konfigurační soubor Apache:
```bash
sudo nano /etc/apache2/sites-available/000-default.conf
```

A přidejte blok `<Directory>` (v případě, že chcete mít aktivní .htaccess soubory):
```apache
<Directory /var/www/html>
    AllowOverride All
</Directory>
```
Uložte pomocí `Ctrl+O` a ukončete `Ctrl+X`. Následně zapněte přepisovací modul a restartujte službu:

```bash
sudo a2enmod rewrite
sudo systemctl restart apache2
```

### 8. Nastavení souboru wp-config.php
Vytvořte konfigurační soubor WordPressu na základě dodávaného vzoru a vyplňte v něm přístupové údaje k databázi.

```bash
cd /var/www/html
sudo cp wp-config-sample.php wp-config.php
sudo nano wp-config.php
```

> [!WARNING]
> V souboru upravte položky `DB_NAME` na "wordpress", `DB_USER` na "wpuser" a `DB_PASSWORD` na vaše zvolené heslo.

### 9. Nastavení firewallu
Ujistěte se, že firewall ufw propouští HTTP (TCP port 80).

```bash
sudo ufw allow Apache
sudo ufw enable
sudo systemctl reload apache2
```

### 10. Dokončení instalace ve webovém prohlížeči
Přejděte v prohlížeči na adresu `http://ip_vaseho_serveru` a postupujte podle pokynů instalátoru WordPressu (výběr jazyka, název webu, vytvoření administrátora).


*Krok navíc k ověření:* Ujistěte se, že jste v okně či sekci týkající se **Instalace WordPress**. Pečlivě překontrolujte, zda zadané údaje odpovídají přesně podle předchozího textového rozpisu. Důkladně se podívejte na zaklikávací boxy i vybrané hodnoty. Jakmile budete mít vše správně nastavené a ověřené, klikněte na odpovídající potvrzovací tlačítko (např. OK, Další, Next, Apply nebo Uložit), abyste úpravy definitivně potvrdili a posunuli se dál v průvodci.


## Troubleshooting — Řešení častých potíží

#### Prohlížeč zobrazuje výchozí stránku Apache namísto WordPressu.
> [!NOTE]
> Ujistěte se, že jste deaktivovali výchozí konfigurační soubor: `sudo a2dissite 000-default.conf` a následně restartovali Apache: `sudo systemctl reload apache2`.

#### WordPress nemůže nahrávat média nebo instalovat pluginy.
> [!WARNING]
> Příčinou jsou obvykle špatná oprávnění. Zkontrolujte, zda je vlastníkem složky `/var/www/wordpress` uživatel **www-data**: `sudo chown -R www-data:www-data /var/www/wordpress`.

---

## Užitečné odkazy

### Oficiální dokumentace
- [WordPress.org Documentation](https://wordpress.org/support/article/how-to-install-wordpress/) - Oficiální instalační příručka
- [Ubuntu Server Guide](https://ubuntu.com/server/docs) - Dokumentace Ubuntu Serveru
- [Apache HTTP Server](https://httpd.apache.org/docs/) - Dokumentace Apache

### Návody a tutoriály
- [DigitalOcean: Install WordPress on Ubuntu](https://www.digitalocean.com/community/tutorials/how-to-install-wordpress-on-ubuntu-22-04-with-a-lamp-stack) - Podrobný průvodce
- [Linuxize: WordPress Installation](https://linuxize.com/post/how-to-install-wordpress-on-ubuntu-20-04/) - Alternativní návod

### Komunita a řešení problémů
- [Stack Overflow: WordPress + LAMP](https://stackoverflow.com/questions/tagged/wordpress+lamp) - Řešení problémů
- [Reddit r/Wordpress](https://www.reddit.com/r/Wordpress/) - Diskuze komunity
- [WordPress.org Forums](https://wordpress.org/support/forums/) - Oficiální fórum podpory
- [Ask Ubuntu](https://askubuntu.com/questions/tagged/wordpress) - Q&A pro Ubuntu

---
[Zpět na přehled](../../README.md)


[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../../README.md)
