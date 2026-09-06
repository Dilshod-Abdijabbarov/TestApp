namespace SaveEat.Domain.Enums;

/// <summary>
/// To'lov provayderlari — integratsiya va loglash uchun ishlatiladi.
/// </summary>
public enum PaymentProvider
{
    /// <summary>Click to'lov tizimi.</summary>
    Click = 0,

    /// <summary>Payme to'lov tizimi.</summary>
    Payme = 1,

    /// <summary>Uzum yoki boshqa marketplace provayderi.</summary>
    Uzum = 2,

    /// <summary>Boshqa noma'lum yoki kelajakdagi provayderlar.</summary>
    Other = 99
}