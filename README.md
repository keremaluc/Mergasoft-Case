# 📝 To-Do API Uygulaması

Uygulamanın arka uç geliştirmesi ASP.NET Core Web API teknolojisi ile, ön uç geliştirmesi .Net Razor Pages teknolojisi ile geliştirildi.

## 🧱 Mimari Yapı

N katmanlı mimari kullanılarak, **Clean Architecture** prensiplerine dikkat edilerek inşa edilen bu uygulama, aşağıdaki katmanlara sahiptir:

- **API Katmanı (Controller)**: Dış dünya ile iletişim kurar. İstekleri alır ve servis katmanına yönlendirir.
- **Service Katmanı**: İş kurallarını ve akışı yönetir. Repository ile API arasında köprü kurar.
- **Repository Katmanı**: Veritabanı ile doğrudan etkileşime girer. Entity Framework Core kullanılarak geliştirilmiştir.
- **DTO Katmanı**: Veri taşıma nesnelerini içerir. Domain modelleri doğrudan dış dünyaya açılmaz.
- **WEB Katmanı**: Uygulamanın görüntüsünü üstlenen katmandır. Razor Page teknolojisi kullanılarak hazırlanmıştır.

## 📋 Özellikler

- CRUD işlemleri (Create, Read, Update, Delete)
- Soft Delete (Veri silinmeden `IsDeleted` flag'i ile saklanır)
- AutoMapper ile DTO-Entity dönüşümleri
- Asenkron (async/await) veri işlemleri
- Swagger/OpenAPI desteği (geliştirici testleri için)
- Ayrıca proje indirildikten sonra olası veritabanı bağlantı hatalarının önüne geçmek için SQLite kullanılarak, DB projenin içine entegre edilmiştir.

## ❕Uyarı
- Projeyi lütfen API ve WEB katmanlarıyla birlikte çalıştırınız.
