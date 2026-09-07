using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaveEat.Domain.Enums;

namespace SaveEat.Domain.Entities;

/// <summary>
/// Do'kon xodimi (merchant user) — asl foydalanuvchi profiliga bog'langan,
/// filial yoki tarmoq menejeri bo'lishi mumkin (OWNER/MANAGER/CASHIER).
/// </summary>
[Table("merchant_users")]
public class MerchantUser
{
    /// <summary>Xodim yozuvi UUID.</summary>
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    /// <summary>Asosiy foydalanuvchi profili identifikatori (users.id).</summary>
    [Column("user_id")]
    public Guid UserId { get; set; }

    /// <summary>Qaysi merchantga tegishli.</summary>
    [Column("merchant_id")]
    public Guid MerchantId { get; set; }

    /// <summary>Biriktirilgan filial (agar mavjud bo'lsa).</summary>
    [Column("branch_id")]
    public Guid? BranchId { get; set; }

    /// <summary>Xodim roli.</summary>
    [Column("role")]
    public MerchantUserRole Role { get; set; } = MerchantUserRole.Cashier;

    /// <summary>Xodim faol yoki emas flagi.</summary>
    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    /// <summary>Yozuv yaratildi (UTC).</summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
