namespace SaveEat.Domain.Enums;

/// To'lov yozuvining holati — bank javoblari va tranzaksiya monitoringi uchun.
public enum PaymentStatus
{
    ///  To'lov boshlangani/inisializatsiya qilingan. 
    Initialized = 0,

    ///  To'lov jarayoni davom etmoqda (pending). 
    Pending = 1,

    ///  To'lov muvaffaqiyatli yakunlandi. 
    Success = 2,

    ///  To'lov muvaffaqiyatsiz tugadi. 
    Failed = 3,

    ///  Mablag' qaytarildi. 
    Refunded = 4,

    ///  To'lov bekor qilindi. 
    Cancelled = 5
}