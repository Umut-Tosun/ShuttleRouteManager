# 🚍 ShuttleRouteManager

Kurumsal servis taşımacılığı için geliştirilmiş kapsamlı yönetim sistemi. Şirketler, sürücüler, otobüsler, rotalar ve yolcu yönetimini tek platformda birleştirir.

## 📋 İçindekiler

- [Özellikler](#-özellikler)
- [Teknoloji Yığını](#-teknoloji-yığını)
- [Mimari](#-mimari)
- [Kurulum](#-kurulum)
- [Veritabanı](#-veritabanı)
- [API Endpoints](#-api-endpoints)
- [Kullanım](#-kullanım)
- [Konfigürasyon](#-konfigürasyon)
- [Geliştirme](#-geliştirme)

## ✨ Özellikler

### 🏢 Şirket Yönetimi
- Taşımacılık şirketi kayıt ve takibi
- Sözleşme tarih yönetimi
- Vergi bilgileri ve sorumlu kişi tanımları
- Şirkete bağlı sürücü ve araç listesi

### 👨‍✈️ Sürücü Yönetimi
- Sürücü profil yönetimi
- Ehliyet bilgileri ve işe başlama tarihi takibi
- Sürücüye atanmış rota listesi
- Şirket bazlı sürücü filtreleme

### 🚌 Araç Yönetimi
- Otobüs kayıt ve takibi (plaka, marka, model, yıl)
- Kapasite ve kilometre bilgileri
- Araç bazlı rota atamaları
- Şirkete bağlı araç yönetimi

### 🗺️ Rota Yönetimi
- Sabah ve akşam sefer planlaması
- Başlangıç ve bitiş noktası tanımlama
- Sürücü ve otobüs atama
- Rota bazlı durak yönetimi

### 📍 Durak Yönetimi
- GPS koordinatlı durak tanımlama
- Sıralı durak listesi
- Sabah ve akşam tahmini varış saatleri
- Her duraktaki yolcu sayısı takibi

### 👥 Kullanıcı Yönetimi
- JWT tabanlı kimlik doğrulama
- Kullanıcı kayıt ve giriş
- Ev adresi ve varsayılan durak ataması
- Kullanıcı bazlı sefer takibi

### 🎫 Sefer Yönetimi
- Kullanıcı-rota-durak ilişkilendirme
- Sabah/Akşam sefer tipi seçimi
- Geçerlilik tarih aralığı
- Aktif sefer durumu kontrolü

## 🛠 Teknoloji Yığını

### Backend
- **.NET 9.0** - Ana framework
- **ASP.NET Core Web API** - RESTful API
- **Entity Framework Core 9.0** - ORM
- **SQL Server** - Veritabanı
- **MediatR** - CQRS pattern implementasyonu
- **AutoMapper** - Object-to-object mapping
- **FluentValidation** - Model validasyonu
- **ASP.NET Core Identity** - Kullanıcı yönetimi

### Authentication & Security
- **JWT Bearer Token** - Kimlik doğrulama
- **SymmetricSecurityKey** - Token şifreleme
- **Password Hashing** - Güvenli şifre saklama

### API Documentation
- **Scalar** - Modern API dokümantasyonu
- **OpenAPI** - API şema tanımları

### Database Features
- **Lazy Loading Proxies** - İlişkili verilerin otomatik yüklenmesi
- **Query Filters** - Soft delete desteği
- **Migrations** - Veritabanı versiyonlama
- **Audit Logging** - Tüm işlemlerde kullanıcı ve tarih takibi

## 🏗 Mimari

Proje **Clean Architecture** ve **CQRS** pattern'leri kullanılarak geliştirilmiştir.
```
ShuttleRouteManager/
│
├── ShuttleRouteManager.Domain/              # Domain katmanı
│   ├── Entities/                            # Domain modelleri
│   │   ├── Company.cs
│   │   ├── Driver.cs
│   │   ├── Bus.cs
│   │   ├── Route.cs
│   │   ├── RouteStop.cs
│   │   ├── AppUser.cs
│   │   └── TripAppUser.cs
│   └── Abstractions/
│       ├── Entity.cs                        # Base entity
│       └── EntityDto.cs                     # Base DTO
│
├── ShuttleRouteManager.Application/         # Uygulama katmanı
│   ├── Features/                            # Feature'lar (CQRS)
│   │   ├── Companies/
│   │   │   ├── Commands/
│   │   │   ├── Queries/
│   │   │   ├── Handlers/
│   │   │   ├── Validators/
│   │   │   ├── Mappings/
│   │   │   ├── Result/
│   │   │   └── Endpoints/
│   │   ├── Drivers/
│   │   ├── Buses/
│   │   ├── Routes/
│   │   ├── RouteStops/
│   │   ├── AppUsers/
│   │   └── TripAppUsers/
│   ├── Contracts/
│   │   └── Persistence/
│   │       ├── IRepository.cs
│   │       ├── IUnitOfWork.cs
│   │       └── IJwtService.cs
│   ├── Behaviors/
│   │   └── ValidationBehavior.cs            # FluentValidation pipeline
│   └── Base/
│       ├── BaseResult.cs
│       └── Error.cs
│
├── ShuttleRouteManager.Infrastructure/      # Altyapı katmanı
│   ├── Context/
│   │   └── ApplicationDbContext.cs
│   ├── Configurations/                      # EF Core configurations
│   ├── Repositories/
│   │   └── Repository.cs
│   ├── Services/
│   │   └── JwtService.cs
│   └── Migrations/
│
└── ShuttleRouteManager.API/                 # Sunum katmanı
    ├── EndpointsRegistration/
    ├── ExceptionHandler.cs
    ├── Program.cs
    └── appsettings.json
```

### Mimari Özellikleri

#### 🎯 CQRS (Command Query Responsibility Segregation)
- **Commands**: Veri değiştirme operasyonları (Create, Update, Delete)
- **Queries**: Veri okuma operasyonları (Get, GetAll, GetById)
- **Handlers**: Her command/query için ayrı handler
- **MediatR**: Request/response mediation

#### 📦 Repository Pattern
- Generic repository implementasyonu
- Unit of Work pattern
- Soft delete desteği
- Expression-based filtering

#### 🔄 DTO Pattern
- Liste DTO'ları: Minimal veri (performans)
- Detay DTO'ları: İlişkili veriler dahil
- Summary DTO'lar: Circular reference önleme
- AutoMapper ile otomatik mapping

#### ✅ Validation Pipeline
- FluentValidation ile zengin validasyon kuralları
- MediatR pipeline behavior
- Merkezi exception handling
- Özelleştirilmiş hata mesajları

## 🚀 Kurulum

### Gereksinimler

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server 2019+](https://www.microsoft.com/sql-server) veya LocalDB
- [Visual Studio 2022](https://visualstudio.microsoft.com/) veya [Rider](https://www.jetbrains.com/rider/)

### Adımlar

1. **Projeyi Klonlayın**
```bash
git clone https://github.com/yourusername/ShuttleRouteManager.git
cd ShuttleRouteManager
```

2. **Bağlantı String'ini Güncelleyin**

`ShuttleRouteManager.API/appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=ShuttleRouteManagerDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

3. **Paketleri Yükleyin**
```bash
dotnet restore
```

4. **Migration Çalıştırın**
```bash
dotnet ef database update --project ShuttleRouteManager.Infrastructure --startup-project ShuttleRouteManager.API
```

5. **Uygulamayı Çalıştırın**
```bash
dotnet run --project ShuttleRouteManager.API
```

6. **API Dokümantasyonuna Erişin**
```
https://localhost:7022/scalar
```

## 💾 Veritabanı

### Schema
```sql
Companies
├── Id (PK, GUID)
├── Name
├── Address
├── TaxNumber
├── ContractDate
└── ContractEndDate

Drivers
├── Id (PK, GUID)
├── FirstName
├── LastName
├── PhoneNumber
├── LicenseNumber
├── CompanyId (FK)
└── JobStartDate

Buses
├── Id (PK, GUID)
├── PlateNo (Unique)
├── Brand
├── Model
├── Year
├── Capacity
├── Km
└── CompanyId (FK)

Routes
├── Id (PK, GUID)
├── Name
├── StartPoint
├── EndPoint
├── MorningStartTime
├── EveningStartTime
├── BusId (FK)
└── DriverId (FK)

RouteStops
├── Id (PK, GUID)
├── SequenceNumber
├── City
├── District
├── Address
├── Latitude
├── Longitude
├── EstimatedArrivalTimeMorning
├── EstimatedArrivalTimeEvening
└── RouteId (FK)

Users
├── Id (PK, GUID)
├── FirstName
├── LastName
├── Email
├── PhoneNumber
├── HomeAddress
├── HomeLatitude
├── HomeLongitude
└── DefaultRouteStopId (FK)

TripAppUsers
├── Id (PK, GUID)
├── AppUserId (FK)
├── RouteId (FK)
├── RouteStopId (FK)
├── TripType (Morning/Evening)
├── ValidFrom
└── ValidUntil
```

### Seed Data

Veritabanını test verileriyle doldurmak için SQL script'i kullanabilirsiniz:
```bash
# SQL dosyasını docs/ klasöründe bulabilirsiniz
# SQL Server Management Studio veya Azure Data Studio ile çalıştırın
```

**Örnek Test Kullanıcıları:**
- Admin: `admin@shuttle.com` / `Admin123!`
- User1-10: `ahmet.yilmaz@shuttle.com` / `User123!`

## 📡 API Endpoints

### 🔐 Authentication

#### Register
```http
POST /users/register
Content-Type: application/json

{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john@example.com",
  "password": "Password123!",
  "phoneNumber": "5551234567",
  "homeCity": "Istanbul",
  "homeDistrict": "Kadıköy",
  "homeAddress": "Test Mah. No:1",
  "homeLatitude": 40.9905,
  "homeLongitude": 29.0246
}
```

#### Login
```http
POST /users/login
Content-Type: application/json

{
  "email": "admin@shuttle.com",
  "password": "Admin123!"
}

Response:
{
  "data": {
    "token": "eyJhbGciOiJIUzI1NiIs...",
    "expirationTime": "2025-12-29T18:00:00Z",
    "user": { ... }
  }
}
```

### 🏢 Companies
```http
GET    /companies              # Tüm şirketler
GET    /companies/{id}         # Şirket detayı
POST   /companies              # Yeni şirket
PUT    /companies              # Şirket güncelle
DELETE /companies/{id}         # Şirket sil
```

### 👨‍✈️ Drivers
```http
GET    /drivers                     # Tüm sürücüler
GET    /drivers/{id}                # Sürücü detayı
GET    /drivers/company/{companyId} # Şirkete göre sürücüler
POST   /drivers                     # Yeni sürücü
PUT    /drivers                     # Sürücü güncelle
DELETE /drivers/{id}                # Sürücü sil
```

### 🚌 Buses
```http
GET    /buses                       # Tüm otobüsler
GET    /buses/{id}                  # Otobüs detayı
GET    /buses/company/{companyId}   # Şirkete göre otobüsler
POST   /buses                       # Yeni otobüs
PUT    /buses                       # Otobüs güncelle
DELETE /buses/{id}                  # Otobüs sil
```

### 🗺️ Routes
```http
GET    /routes                      # Tüm rotalar
GET    /routes/{id}                 # Rota detayı (duraklar dahil)
GET    /routes/driver/{driverId}    # Sürücüye göre rotalar
GET    /routes/bus/{busId}          # Otobüse göre rotalar
POST   /routes                      # Yeni rota
PUT    /routes                      # Rota güncelle
DELETE /routes/{id}                 # Rota sil
```

### 📍 Route Stops
```http
GET    /routestops                  # Tüm duraklar
GET    /routestops/{id}             # Durak detayı
GET    /routestops/route/{routeId}  # Rotaya göre duraklar (sıralı)
POST   /routestops                  # Yeni durak
PUT    /routestops                  # Durak güncelle
DELETE /routestops/{id}             # Durak sil
```

### 🎫 Trip App Users
```http
GET    /tripappusers                # Tüm seferler
GET    /tripappusers/{id}           # Sefer detayı
GET    /tripappusers/user/{userId}  # Kullanıcıya göre seferler
GET    /tripappusers/route/{routeId}# Rotaya göre seferler
POST   /tripappusers                # Yeni sefer
PUT    /tripappusers                # Sefer güncelle
DELETE /tripappusers/{id}           # Sefer sil
```










