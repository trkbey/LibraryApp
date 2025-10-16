#  C# Library Management System

Basit bir **konsol tabanlı kütüphane yönetim sistemi**.  
Bu proje, **Nesne Yönelimli Programlama (OOP)** kavramlarını (sınıflar, kalıtım, kapsülleme, nesneler arası etkileşim) öğrenmek amacıyla geliştirilmiştir.

---

##  Özellikler

-  Yeni kitap ekleme  
-  Yeni üye kaydı  
-  Üyelerin kitap ödünç alması ve iade etmesi  
-  Tüm kitapları listeleme (ödünç alınanlar dahil)  
-  Tüm üyeleri görüntüleme  
-  Konsol menüsü üzerinden kolay kullanım  

---

##  Kullanılan Sınıflar

| Sınıf | Açıklama |
|-------|-----------|
| **Book** | Kitap bilgilerini (`BookId`, `Title`, `Author`, `IsBorrowed`) tutar ve gösterir. |
| **Member** | Üye bilgilerini (`MemberId`, `Name`, `BorrowedBooks`) saklar. |
| **Library** | Tüm kitap ve üyeleri yönetir. Kitap ekleme, ödünç alma ve iade işlemlerini yapar. |
| **Program** | Konsol menüsü üzerinden kullanıcı etkileşimini yönetir. |

---

##  OOP Kavramları

Bu projede kullanılan bazı **OOP prensipleri**:

- **Encapsulation (Kapsülleme):**  
  Sınıfların verilerini `public` özellikler ve metodlarla güvenli şekilde yönetme.

- **Composition (Bileşim):**  
  `Member` sınıfı kendi içinde `List<Book>` tutarak başka nesneleri ilişkilendirir.

- **Abstraction (Soyutlama):**  
  Gereksiz detayları gizleyip yalnızca gerekli metodları kullanıcıya sunma.

---

##  Kullanım

1. Projeyi Visual Studio, JetBrains Rider veya VS Code ile açın.  
2. Derleyip çalıştırın.  
3. Konsolda aşağıdaki menü görünecektir:

