# 📝 To-Do API Uygulaması

Bu proje, yapılacaklar listesi yönetimi sağlayan basit ama kurumsal standartlara uygun bir RESTful API uygulamasıdır. Uygulama ASP.NET Core Web API teknolojisi ile geliştirilmiştir.

## 📌 Proje Amacı

Bu proje, bir case çalışması kapsamında geliştirilmiş olup aşağıdaki hedefleri sağlamayı amaçlamaktadır:

- Temiz, okunabilir ve sürdürülebilir bir mimariyle proje geliştirmek
- Katmanlı yapı ile görev ayrımını net bir şekilde uygulamak
- Güncel ve endüstri standartlarına uygun teknolojiler kullanmak

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
