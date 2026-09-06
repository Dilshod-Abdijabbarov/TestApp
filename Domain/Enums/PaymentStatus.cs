namespace SaveEat.Domain.Enums;

/// <summary>
/// To'lov yozuvining holati — bank javoblari va tranzaksiya monitoringi uchun.
/// </summary>
public enum PaymentStatus
{
    /// <summary>To'lov boshlangani/inisializatsiya qilingan.</summary>
    Initialized = 0,

    /// <summary>To'lov jarayoni davom etmoqda (pending).</summary>
    Pending = 1,

    /// <summary>To'lov muvaffaqiyatli yakunlandi.</summary>
    Success = 2,

    /// <summary>To'lov muvaffaqiyatsiz tugadi.</summary>
    Failed = 3,

    /// <summary>Mablag' qaytarildi.</summary>
    Refunded = 4,

    /// <summary>To'lov bekor qilindi.</summary>
    Cancelled = 5
}