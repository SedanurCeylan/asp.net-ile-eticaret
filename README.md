# ASP.NET ile E-Ticaret #

.NET 9 • Entity Framework Core • SQLite • Identity • Admin Paneli

Bu proje, ASP.NET (.NET 9) kullanılarak geliştirilmiş temel bir e-ticaret uygulamasıdır.
Uygulama; ürün listeleme, ürün detayları, sepet işlemleri, sipariş oluşturma ve yönetim paneli (Admin Panel) gibi bir e-ticaret sisteminde bulunması gereken temel fonksiyonları içerir.

Veri yapısı Entity Framework Core (Code-First) ile oluşturulmuş, veritabanı olarak SQLite kullanılmıştır.
Kullanıcı yönetimi için ASP.NET Identity altyapısı projeye entegre edilmiştir.

## Kullanılan Teknolojiler
* .NET 9.0
* ASP.NET MVC / Razor
* Entity Framework Core 9
* SQLite
* ASP.NET Core Identity
* Bootstrap

## Özellikler
1.**Müşteri Tarafı**

* Ürün listeleme
* Ürün detay sayfaları
* Kategori bazlı filtreleme
* Sepete ekleme / çıkarma
* Sipariş oluşturma
* Önceki siparişleri götüntüleme
* Profil düzenleme(şifre, kullanıcı adı değişimi)

2.**Kimlik Yönetimi**

* ASP.NET Identity altyapısı
* Giriş / kayıt olma için hazır yapı
* Rol tabanlı erişim

3.**Admin Paneli**

* Ürün ekleme, silme, güncelleme
* Kategori yönetimi
* Kullanıcı ve Rol yönetimi
* Stok / fiyat kontrolü, güncellemesi
* Sipariş yönetimi
* Rol bazlı yetkilendirme (Admin & User)
* Yönetim paneline sadece Admin rolü erişebilir

## Kullanılan NuGet Paketleri 
```
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Sqlite
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.Tools
Microsoft.AspNetCore.Identity.EntityFrameworkCore
```

## Kurulum ##
1.**Projeyi Klonlayın**
```
git clone https://github.com/SedanurCeylan/asp.net-ile-eticaret.git
```
2.**Migration Uygulayın**
```
dotnet ef database update
```
3.**Projeyi Çalıştırın**
```
dotnet run
```

## İletişim ##

**GitHub:** https://github.com/SedanurCeylan

**Linkedin:** www.linkedin.com/in/sedanur-ceylan-190702

**Kişisel:** https://sedanurceylan.vercel.app
