
namespace SaveEat.Domain.Enums;

/// <summary>
/// Yetkazib berish muvaffaqiyatsizligining sababi.
/// </summary>
public enum DeliveryFailureReason
{
    /// <summary>Mijoz uy-joyida bo'lmadi / kelmadi.</summary>
    [Display(Name = "Mijoz uy-joyida yo'q")]
    CustomerNotHome = 1,

    /// <summary>Mijoz telefon javob bermadi (bog'lanib bo'lmadi).</summary>
    [Display(Name = "Mijoz telefon javob bermadi")]
    CustomerUnreachable = 2,

    /// <summary>Manzil noto'g'ri yoki topib bo'lmadi.</summary>
    [Display(Name = "Manzil topib bo'lmadi")]
    AddressNotFound = 3,

    /// <summary>Buyurtma o'yoqqa kelib qoldi.</summary>
    [Display(Name = "Buyurtma buzilgan")]
    OrderDamaged = 4,

    /// <summary>Kuryerning vositasi buzildi.</summary>
    [Display(Name = "Kuryerning vositasi buzildi")]
    VehicleBreakdown = 5,

    /// <summary>Xavfsizlik muammosi (qo'rquv, baloa).</summary>
    [Display(Name = "Xavfsizlik muammosi")]
    SecurityIssue = 6,

    /// <summary>Trafikdan so'ng muddati o'tib ketdi.</summary>
    [Display(Name = "Muddati o'tgan (traffic)")]
    TimeoutDueToTraffic = 7,

    /// <summary>Kuryerning shaxsiy sabablari.</summary>
    [Display(Name = "Kuryerning shaxsiy sabablari")]
    CourierPersonalReason = 8,

    /// <summary>Tizimning texnik xatosi.</summary>
    [Display(Name = "Texnik xatolik")]
    SystemError = 9,

    /// <summary>Boshqa sabab.</summary>
    [Display(Name = "Boshqa sabab")]
    Other = 99
}