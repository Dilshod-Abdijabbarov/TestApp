namespace SaveEat.Domain.Enums;

/// Do'kon ichidagi xodim rollari — filial va platforma darajasidagi ruxsatlar.
public enum CompanyUserRole
{
    ///  Do'kon egasi — to'liq huquqlar. 
    Owner = 0,

    ///  Menejer — filialni boshqarish, xodimlarni boshqarish. 
    Manager = 1,

    ///  Kassir — savdo operatsiyalarini bajaruvchi. 
    Cashier = 2,

    /// Ofitsiant — buyurtmalarni qabul qilish va mijozlarga xizmat ko'rsatish.
    Ofitsiant = 3,

    /// Yetkazib beruvchi — buyurtmalarni yetkazib berish.
    Courier = 4,
}