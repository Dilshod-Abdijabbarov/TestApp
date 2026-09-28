
using System.ComponentModel.DataAnnotations;

namespace SaveEat.Domain.Enums;

/// <summary>
/// Kuryerning ish holati.
/// </summary>
public enum CourierStatus
{
    /// <summary>Kuryerning tizimda registratsiyasi yo'q yoki bloklandi.</summary>
    [Display(Name = "Aktiv emas")]
    Inactive = 0,

    /// <summary>Kuryeri tizimda aktiv va buyurtmalarni qabul qilishi mumkin.</summary>
    [Display(Name = "Aktiv")]
    Active = 1,

    /// <summary>Kuryeri ish kunida, lekin joriy buyurtmalar to'liq.</summary>
    [Display(Name = "Band")]
    Busy = 2,

    /// <summary>Kuryerning ish jadavali tugadi (shift tugadi).</summary>
    [Display(Name = "Shift tugadi")]
    OffDuty = 3,

    /// <summary>Kuryerning vaqtinchalik ishdan chetlashdi.</summary>
    [Display(Name = "Vaqtinchalik chetlang")]
    OnBreak = 4,

    /// <summary>Kuryerning tizimda bloklandi (blokirovka).</summary>
    [Display(Name = "Bloklandi")]
    Blocked = 5
}