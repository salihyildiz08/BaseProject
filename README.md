# BaseProject

## Proje Hakkında

**BaseProject**, yeni projeler için sağlam ve esnek bir başlangıç noktası sağlar. Bu proje, yaygın olarak kullanılan yapılandırmaları ve araçları içerir, böylece hızlı ve etkili bir şekilde yeni projeler oluşturabilirsiniz.

## Özellikler

- **Modüler Yapı**: Kolayca genişletilebilir ve özelleştirilebilir modüler yapı.
- **Entegre Araçlar**: Yaygın olarak kullanılan araçlar ve kütüphanelerle önceden yapılandırılmıştır.
- **Dokümantasyon**: Proje yapısı ve kullanımına dair kapsamlı dokümantasyon.

## Kullanılan Teknolojiler ve Kütüphaneler

- **.NET Core**: Modern, hızlı ve platformlar arası uygulama geliştirme.
- **Entity Framework Core**: ORM (Object-Relational Mapping) aracı.
- **ASP.NET Core**: Web uygulamaları ve API'ler için güçlü bir framework.
- **XUnit**: Birim testleri için popüler bir test framework'ü.
- **Swagger**: API dokümantasyonu ve test aracı.
- **AutoMapper**: Nesne-nesne eşlemeleri için kullanılan bir kütüphane.
- **FluentValidation**: Model doğrulama için kullanılan bir kütüphane.
- **Scrutor**: Dependency Injection (DI) için genişletilebilir bir kütüphane.

## Yazılım Mimarisi ve Prensipler

Bu proje, yazılım geliştirme süreçlerinde en iyi uygulamaları ve prensipleri takip eder:

- **SOLID Prensipleri**:
  - **S**ingle Responsibility Principle (SRP): Her sınıfın yalnızca bir sorumluluğu olmalıdır.
  - **O**pen/Closed Principle (OCP): Yazılımlar genişletilmeye açık, ancak değiştirilmeye kapalı olmalıdır.
  - **L**iskov Substitution Principle (LSP): Türetilmiş sınıflar, temel sınıfların yerine geçebilmelidir.
  - **I**nterface Segregation Principle (ISP): Kullanıcıya özel arayüzler, genel amaçlı arayüzlerden daha iyidir.
  - **D**ependency Inversion Principle (DIP): Üst seviye modüller, alt seviye modüllere bağımlı olmamalıdır. Her ikisi de soyutlamalara bağımlı olmalıdır.

- **Katmanlı Mimari**: Uygulama, iş mantığı, veri erişimi ve kullanıcı arayüzü gibi farklı katmanlara ayrılmıştır.
- **Bağımlılık Enjeksiyonu**: Bağımlılıkların yönetimi ve test edilebilirliği için IoC (Inversion of Control) konteyneri kullanılır.

## Kurulum

Projeyi klonlayarak başlayabilirsiniz:

```sh
git clone https://github.com/salihyildiz08/BaseProject.git
cd BaseProject
