namespace SaveEat.Domain.Enums;

/// <summary>
/// Savatning biznes holati — sotuv jarayoni va inventar nazorati uchun.
/// </summary>
public enum BagStatus
{
    /// <summary>Faol va sotuvda mavjud.</summary>
    Active = 0,

    /// <summary>Hammasi sotib bo'lingan.</summary>
    SoldOut = 1,

    /// <summary>Olib ketish muddati o'tgan (muddati tugagan).</summary>
    Expired = 2,

    /// <summary>Administrator yoki sotuvchi tomonidan bekor qilingan.</summary>
    Cancelled = 3
}