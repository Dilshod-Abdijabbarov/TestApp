using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveEat.Domain.Entities;

/// <summary>
/// Savatni olib chiqish uchun biriktirilgan xodim yozuvi.
/// Qaysi xodim qaysi savatga javobgar ekanligini saqlaydi.
/// </summary>
[Table("bag_assignees")]
public class BagAssignee
{
    /// <summary>Yozuv UUID.</summary>
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    /// <summary>Biriktirilgan savat ID.</summary>
    [Column("bag_id")]
    public Guid BagId { get; set; }

    /// <summary>Mas'ul xodim (merchant_users.id).</summary>
    [Column("merchant_user_id")]
    public Guid MerchantUserId { get; set; }

    /// <summary>Biriktirilgan vaqt (UTC).</summary>
    [Column("assigned_at")]
    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
}

