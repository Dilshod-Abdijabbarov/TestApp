namespace SaveEat.Domain.Enums;

/// <summary>
/// Buyurtma holatlari — to'lovdan tortib yetkazib berishgacha bo'lgan jarayonni ifodalaydi.
/// </summary>
public enum OrderStatus
{
    /// <summary>To'lov kutilyapti (mijoz hali to'lamagan).</summary>
    PendingPayment = 0,

    /// <summary>To'lov amalga oshirilgan.</summary>
    Paid = 1,

    /// <summary>Buyurtma qayta ishlanmoqda (tayyorlash bosqichi).</summary>
    Processing = 2,

    /// <summary>Olib ketish uchun tayyor.</summary>
    ReadyForPickup = 3,

    /// <summary>Mijoz buyurtmani olib ketgan va jarayon yakunlangan.</summary>
    Completed = 4,

    /// <summary>Buyurtma bekor qilingan.</summary>
    Cancelled = 5,

    /// <summary>Buyurtma summasi qaytarilgan (refund qilingan).</summary>
    Refunded = 6
}