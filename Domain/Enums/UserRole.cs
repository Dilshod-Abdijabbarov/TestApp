namespace SaveEat.Domain.Enums;

/// <summary>
/// Foydalanuvchining tizimdagi umumiy roli.
/// Ishlatiladi: autentifikatsiya, ruxsat va UI ko'rsatmalari uchun.
/// </summary>
public enum UserRole
{
    /// <summary>Oddiy mijoz — ilova orqali buyurtma beruvchi.</summary>
    Client = 0,

    /// <summary>Administrator — tizimni boshqarish va sozlash huquqi.</summary>
    Admin = 1,

    /// <summary>Qo'llab-quvvatlash xodimi — mijozlarga yordam beradi.</summary>
    Support = 2
}