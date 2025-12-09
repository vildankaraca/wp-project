## 🇬🇧 README (English)
# Dormitory Complaint System

This project is an **ASP.NET Core MVC** web application developed to facilitate communication between dormitory management and students. It provides a platform where students can submit complaints and requests, while the administration can manage these requests and organize dormitory dining menus.

## Table of Contents

- [Basic Flow](#basic-flow)
- [Features](#features)
- [Screenshots](#example-screenshots)
- [Project Requirements and Compliance](#project-requirements-and-compliance-course-requirements)
- [Prerequisites](#prerequisites)
- [Quick Start](#quick-start)
- [Test Seed Users](#test-seed-users-and-passwords)
- [Technology Stack](#technology-stack)

---

## Basic Flow
1.  **Student:** Registers to the system, views dining menus, and reports malfunctions/requests.
2.  **Admin:** Manages student data, enters dining menus, and evaluates incoming complaints.

## Features

* **Authentication:** Secure login and registration system using ASP.NET Core Identity.
* **Automatic Data Seeding:** The application automatically creates the database, tables, and test users upon the first launch.

### Admin Module
* **Student Management:** Register, list, view details, edit, and delete students (CRUD).
* **Dormitory Management Panel:** General occupancy and system status summary.
* **Menu Management:** Adding and updating the daily dining hall menu.

### Student Module
* **Secure Login:** Registration and login operations via Identity infrastructure.
* **Profile Viewing:** Viewing personal information and room details.
* **Complaints & Requests:** Reporting dormitory-related issues (electricity, internet, cleaning, etc.).
* **Menu Tracking:** Viewing the current dining menu.

---

## Example Screenshots

* **Login Screen**
  
  <img width="1920" height="1020" alt="image" src="https://github.com/user-attachments/assets/a05d9e9e-76a6-43c2-99d1-e1343100a591" />

* **Admin Panel**
  
<img width="1920" height="1080" alt="Ekran görüntüsü 2025-12-09 010120" src="https://github.com/user-attachments/assets/e164bb44-ba5f-4638-92c0-d990837a972c" />


* **Student Complaint  Screen** 

<img width="1920" height="1080" alt="Ekran görüntüsü 2025-12-09 005856" src="https://github.com/user-attachments/assets/7e76b424-2025-460f-8c94-26a2f08fc9e0" />

* **Menu**
<img width="1920" height="1080" alt="Ekran görüntüsü 2025-12-09 002733" src="https://github.com/user-attachments/assets/61e6d9cb-81ba-4412-bddd-e72c0aee9830" />

---

## Project Requirements and Compliance (Course Requirements)

This project meets all technical requirements specified within the scope of the **SWE 203 Web Programming** course:

* **Architecture:** Built using ASP.NET Core MVC & Entity Framework Core (ORM).
* **Data Operations (CRUD):** Full Create, Read, Update, Delete operations are implemented on Complaints and Dining Menus.
* **Security:** Authentication and Authorization structures are established; pages are restricted based on `Admin` and `Student` roles.
* **Components:** Layout structure, ViewBag/ViewData usage, Tag Helpers, Forms, and Validations (Server & Client side) are fully implemented.
* **Scope:** The requirement of "at least 3 Controllers and 6 Views" is exceeded with **5 Controllers** and **10+ Views**.

---

## Prerequisites

Before running the project locally, ensure you have the following installed:

* [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
* **SQL Server** or **LocalDB** (Comes with Visual Studio)
* Visual Studio 2022 or VS Code (with C# Dev Kit extension)

## Quick Start

1.  **Clone the Project:**
    ```bash
    git clone [https://github.com/vildankaraca/wp-project.git](https://github.com/vildankaraca/wp-project.git)
    cd DormitoryComplaintSystem
    ```

2.  **Restore Packages:**
    Run the following command to download project libraries:
    ```bash
    dotnet restore
    ```

3.  **Database Configuration:**
    The `appsettings.json` file is configured for `(localdb)\mssqllocaldb` by default. If you are using a different SQL server, please update the connection string.

4.  **Run the Application:**
    Start the project via terminal:
    ```bash
    dotnet run
    ```
    *Note: When the application is run for the first time, the `SeedData` class will trigger, automatically creating the database (migrations) and test users. No extra database commands are required.*

5.  **Open in Browser:**
    Navigate to the address shown in the console output (Usually `https://localhost:7152` or `http://localhost:5xxx`).

---

## Test Seed Users and Passwords

To speed up development and testing processes, the following users are automatically added to the database.

### Admin Accounts
**Password** for all admin accounts: `Admin123!`

* `adminvildan@gmail.com`
* `adminelif@gmail.com`
* `adminayse@gmail.com`
* `adminrana@gmail.com`
* `adminayberk@gmail.com`

### Student Accounts
The system automatically creates 50 student accounts.
**Password** (For all): `Student123!`

* **Username/Email:** From `student1@gmail.com` to `student50@gmail.com`.
* **Example:**
    * **Email:** `student1@gmail.com`
    * **Password:** `Student123!`

---

## Technology Stack

The project is developed in accordance with modern .NET standards.

| Field | Technology |
| :--- | :--- |
| **Framework** | .NET 9.0 (ASP.NET Core MVC) |
| **Database** | MSSQL (LocalDB) |
| **ORM** | Entity Framework Core (Code-First) |
| **Authentication** | ASP.NET Core Identity |
| **Frontend** | HTML5, CSS3, Bootstrap 5 |
| **Scripting** | JavaScript, jQuery, jQuery Validation |
| **Tools** | Visual Studio / VS Code, Git |

---
## 🇹🇷 README (Türkçe)

# 🏢 Dormitory Complaint System (Yurt Şikayet Sistemi)

Bu proje, yurt yönetimi ve öğrenciler arasındaki iletişimi kolaylaştırmak amacıyla geliştirilmiş bir **ASP.NET Core MVC** web uygulamasıdır. Öğrencilerin şikayet ve taleplerini iletebileceği, idarenin ise bu talepleri yönetip yurt yemek menülerini düzenleyebileceği bir platform sunar.



## 📋 İçindekiler

- [Temel Akış](#temel-akış)
- [Özellikler](#özellikler)
- [Ekran Görüntüleri](#ekran-görüntüleri-screenshots)
- [Proje Gereksinimleri ve Uyumluluk](#proje-gereksinimleri-ve-uyumluluk-course-requirements)
- [Ön Gereksinimler](#ön-gereksinimler)
- [Hızlı Kurulum](#hızlı-kurulum-quick-start)
- [Test Kullanıcıları](#test-seed-kullanıcıları-ve-şifreleri)
- [Teknoloji Yığını](#teknoloji-yığını)


## Temel Akış
1.  **Öğrenci:** Sisteme kayıt olur, menüleri görür, arıza/talep bildirimi yapar.
2.  **Yönetici (Admin):** Öğrenci verilerini yönetir, yemek menülerini girer ve gelen şikayetleri değerlendirir.

##  Özellikler

* **Kimlik Doğrulama:** ASP.NET Core Identity ile güvenli giriş ve kayıt sistemi.
* **Otomatik Veri Oluşturma (Seeding):** Uygulama ilk açılışta veritabanını, tabloları ve test kullanıcılarını otomatik oluşturur.

### 👤 Yönetici (Admin) Modülü
* **Öğrenci Yönetimi:** Kayıt, listeleme, detay görüntüleme, düzenleme ve silme (CRUD).
* **Yurt Yönetim Paneli:** Genel doluluk ve sistem durumu özeti.
* **Menü Yönetimi:** Yemekhane günün menüsünü ekleme ve güncelleme.

### 🎓 Öğrenci Modülü
* **Güvenli Giriş:** Identity altyapısı ile kayıt ve giriş işlemleri.
* **Profil Görüntüleme:** Kişisel bilgileri ve oda bilgilerini görüntüleme.
* **Şikayet & Talep:** Yurtla ilgili (elektrik, internet, temizlik vb.) sorunları bildirme.
* **Menü Takibi:** Güncel yemek listesini görüntüleme.

---

##  Ekran Görüntüleri (Screenshots)

* **Giriş Ekranı**
  
  <img width="1920" height="1020" alt="image" src="https://github.com/user-attachments/assets/a05d9e9e-76a6-43c2-99d1-e1343100a591" />

* **Admin Paneli**
  
<img width="1920" height="1080" alt="Ekran görüntüsü 2025-12-09 010120" src="https://github.com/user-attachments/assets/e164bb44-ba5f-4638-92c0-d990837a972c" />


* **Öğrenci Şikayet Ekranı** 

<img width="1920" height="1080" alt="Ekran görüntüsü 2025-12-09 005856" src="https://github.com/user-attachments/assets/7e76b424-2025-460f-8c94-26a2f08fc9e0" />

* **Menü**
<img width="1920" height="1080" alt="Ekran görüntüsü 2025-12-09 002733" src="https://github.com/user-attachments/assets/61e6d9cb-81ba-4412-bddd-e72c0aee9830" />

---

##  Proje Gereksinimleri ve Uyumluluk (Course Requirements)

Bu proje, **SWE 203 Web Programming** dersi kapsamında belirtilen teknik isterleri karşılamaktadır:

* **Mimari:** ASP.NET Core MVC & Entity Framework Core (ORM) kullanılmıştır.
* **Veri İşlemleri (CRUD):** Şikayetler ve Yemek Menüleri üzerinde tam Create, Read, Update, Delete işlemleri mevcuttur.
* **Güvenlik:** Authentication (Giriş) ve Authorization (Yetkilendirme) yapıları kurulmuş; sayfalar `Admin` ve `Student` rollerine göre kısıtlanmıştır.
* **Bileşenler:** Layout yapısı, ViewBag/ViewData kullanımı, Tag Helper'lar, Form yapıları ve Validasyonlar (Server & Client side) eksiksiz uygulanmıştır.
* **Kapsam:** İstenen "en az 3 Controller ve 6 View" şartı; **5 Controller** ve **10+ View** ile fazlasıyla sağlanmıştır.

---

##  Ön Gereksinimler

Projeyi yerel ortamınızda çalıştırmadan önce aşağıdakilerin kurulu olduğundan emin olun:

* [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
* **SQL Server** veya **LocalDB** (Visual Studio kurulumuyla gelir)
* Visual Studio 2022 veya VS Code (C# Dev Kit eklentisi ile)

##  Hızlı Kurulum (Quick Start)

1.  **Projeyi Klonlayın:**
    ```bash
    git clone [https://github.com/vildankaraca/wp-project.git](https://github.com/vildankaraca/wp-project.git)
    cd DormitoryComplaintSystem
    ```
     ```bash
    cd DormitoryComplaintSystem
    ```


2.  **Paketleri Yükleyin (Restore):**
    Proje kütüphanelerini indirmek için şu komutu çalıştırın:
    ```bash
    dotnet restore
    ```

3.  **Veritabanı Ayarları:**
    `appsettings.json` dosyasında varsayılan olarak `(localdb)\mssqllocaldb` tanımlıdır. Eğer farklı bir SQL sunucusu kullanacaksanız bağlantı adresini (ConnectionStrings) güncelleyin.

4.  **Uygulamayı Çalıştırın:**
    Terminalden projeyi başlatın:
    ```bash
    dotnet run
    ```
    *Not: Uygulama ilk çalıştırıldığında `SeedData` sınıfı devreye girerek veritabanını (migrations) ve test kullanıcılarını otomatik olarak oluşturacaktır. Ekstra bir veritabanı komutu çalıştırmanıza gerek yoktur.*

5.  **Tarayıcıda Açın:**
    Konsol çıktısında belirtilen adrese gidin (Genellikle `https://localhost:7152` veya `http://localhost:5xxx`).

---

##  Test Seed Kullanıcıları ve Şifreleri

Geliştirme ve test süreçlerinizi hızlandırmak için veritabanına otomatik olarak aşağıdaki kullanıcılar eklenir.

###  Yönetici (Admin) Hesapları
Aşağıdaki e-posta adreslerinin tümü için **Şifre:** `Admin123!`

* `adminvildan@gmail.com`
* `adminelif@gmail.com`
* `adminayse@gmail.com`
* `adminrana@gmail.com`
* `adminayberk@gmail.com`

### 🎓 Öğrenci (Student) Hesapları
Sistem otomatik olarak 50 adet öğrenci hesabı oluşturur.
**Şifre (Hepsi için):** `Student123!`

* **Kullanıcı Adı/Email:** `student1@gmail.com` 'dan `student50@gmail.com` 'a kadar.
* **Örnek:**
    * **Email:** `student1@gmail.com`
    * **Şifre:** `Student123!`

---

##  Teknoloji Yığını

Proje, modern .NET standartlarına uygun olarak geliştirilmiştir.

| Alan | Teknoloji |
| :--- | :--- |
| **Framework** | .NET 9.0 (ASP.NET Core MVC) |
| **Veritabanı** | MSSQL (LocalDB) |
| **ORM** | Entity Framework Core (Code-First) |
| **Authentication** | ASP.NET Core Identity |
| **Frontend** | HTML5, CSS3, Bootstrap 5 |
| **Scripting** | JavaScript, jQuery, jQuery Validation |
| **Araçlar** | Visual Studio / VS Code, Git |
