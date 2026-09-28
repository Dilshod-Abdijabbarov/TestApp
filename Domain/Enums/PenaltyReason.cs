
namespace Domain.Enums;
/// <summary>Jazo sabablari.</summary>
public enum PenaltyReason
{
    /// <summary>Yetkazib berilmadi (buyurtma yo'qoldi yoki kuryerning xatosi).</summary>
    FailedDelivery = 1,

    /// <summary>Muddati o'tgan yetkazib berish (30 min dan ko'p).</summary>
    LateDelivery = 2,

    /// <summary>Buyurtmani bekor qilish (kuryerning sababsiz).</summary>
    CancelledWithoutReason = 3,

    /// <summary>Badbarg (mijozdan shikoyat).</summary>
    BadBehavior = 4,

    /// <summary>Boshqa qoidabuzarlik.</summary>
    Other = 99
}