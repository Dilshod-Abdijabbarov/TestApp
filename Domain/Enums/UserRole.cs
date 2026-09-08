namespace SaveEat.Domain.Enums;

/// Foydalanuvchining tizimdagi umumiy roli.
public enum UserRole
{
    ///  Oddiy mijoz — ilova orqali buyurtma beruvchi. 
    Client = 0,

    ///  Administrator — tizimni boshqarish va sozlash huquqi. 
    Admin = 1,

    ///  Qo'llab-quvvatlash xodimi — mijozlarga yordam beradi. 
    Support = 2
}