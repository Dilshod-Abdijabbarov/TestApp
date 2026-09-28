
namespace Domain.Enums;

/// <summary>Tayinlanish holati.</summary>
public enum AssignmentStatus
{
    /// <summary>Taklif yuborildi, javob kutilmoqda.</summary>
    Pending = 0,

    /// <summary>Kuryerning javobiga kutilmoqda (30 sec).</summary>
    WaitingForResponse = 1,

    /// <summary>Kuryerning qabul qilgan javob.</summary>
    Accepted = 2,

    /// <summary>Kuryerning rad etgan javob.</summary>
    Rejected = 3,

    /// <summary>Vaqti tugab ketdi - javob bermadi.</summary>
    Expired = 4,

    /// <summary>Tayinlanish bekor qilingan (boshqa kuryerga taqdim etildi).</summary>
    Cancelled = 5
}

