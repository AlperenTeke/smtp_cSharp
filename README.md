### SMTP C# Mail Gönderme Uygulaması
Genel Bakış
Bu proje, aynı mail içeriğini belirli zamanlarda çok sayıda kişiye gönderme ihtiyacınızı karşılamak için tasarlanmıştır. Geliştirilen bu C# uygulaması, veritabanındaki kayıtlı e-posta adreslerine belirtilen başlık ve içerikteki e-postaları göndermeyi amaçlamaktadır.

### Kullanım
Uygulama, projenize entegre ettiğiniz veritabanındaki "e_mail" alanındaki tüm e-posta adreslerine, TextBox araçlarına girilen "Başlık" ve "İçerik" bilgilerini içeren e-postalar gönderir.

### Kurulum ve Çalıştırma
Projenizi çalıştırmadan önce, kendi veritabanı bilgilerinizi ayarlamalısınız.
"Veritabanı Bağlantısı": Kod içerisinde bulunan bağlantı yolunu, kendi veritabanınızın bağlantı yoluna güncellemelisiniz.
"Mail Adresi ve Şifre": Kod içerisinde bulunan "Mail Adresiniz" ve "Google Tarafından Aldığınız Şifre" kısımlarını kendi e-posta hesap bilgilerinizle güncellemelisiniz.

### SQL
```
-- Veritabanı Oluştur
CREATE DATABASE eMailDB;

USE eMailDB;

-- E-posta Adresleri Tablosu Oluştur
CREATE TABLE email_addresses (
    id INT AUTO_INCREMENT PRIMARY KEY,
    e_mail VARCHAR(255)
);

-- Veri Tabanına Kayıt Eklemek İçin
INSERT INTO email_addresses (E_MAIL) VALUES ('Kaydetmek İstediğiniz Mail Adresi');
```
