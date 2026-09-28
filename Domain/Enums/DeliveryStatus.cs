
namespace SaveEat.Domain.Enums;

/// <summary>
/// Yetkazib berish buyurtmasi holati.
/// </summary>
public enum DeliveryStatus
{
    /// <summary>Kuryerin kutilmoqda, tayinlanmagan (hozirgacha).</summary>
    [Display(Name = "Kutilmoqda")]
    Pending = 0,

    /// <summary>Kurye tayinlandi va qabul qildi.</summary>
    [Display(Name = "Tayinlandi")]
    Assigned = 1,

    /// <summary>Kuryerning buyurtmani olib ketdi restorandan/do'konda.</summary>
    [Display(Name = "Olib ketildi")]
    PickedUp = 2,

    /// <summary>Kuryerning yo'lda (mijozga ketayotgan).</summary>
    [Display(Name = "Yo'lda")]
    OnTheWay = 3,

    /// <summary>Buyurtma muvaffaqiyatli yetkazildi.</summary>
    [Display(Name = "Yetkazildi")]
    Delivered = 4,

    /// <summary>Yetkazib berish muvaffaqiyatsiz bo'ldi.</summary>
    [Display(Name = "Muvaffaqiyatsiz")]
    Failed = 5,

    /// <summary>Buyurtma bekor qilingan.</summary>
    [Display(Name = "Bekor qilingan")]
    Cancelled = 6
}