
namespace Domain.Enums;

/// <summary>Kuryerning javobini berish reaksiyasi.</summary>
public enum AssignmentResponse
{
    /// <summary>Hali javob bermadi.</summary>
    None = 0,

    /// <summary>Kuryerning qabul qilgan javob.</summary>
    Accepted = 1,

    /// <summary>Kuryerning rad etgan javob.</summary>
    Rejected = 2
}