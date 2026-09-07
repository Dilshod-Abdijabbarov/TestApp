using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaveEat.Domain.Enums;

namespace SaveEat.Domain.Entities;

/// <summary>
/// Employee uchun taklif havolalari (invites) — deep-link token orqali yangi xodimlarni taklif qilish.
/// Havola muddati, ishlatilganligi va rol ma'lumotlarini saqlaydi.
/// </summary>
[Table("employee_invites")]
public class EmployeeInvite
{
    /// <summary>Taklif yozuvi UUID.</summary>
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    /// <summary>Qaysi Kompaniya taklif qiladi.</summary>
    [Column("company_id")]
    public Guid CompanytId { get; set; }

    /// <summary>Agar kerak bo'lsa, filialga bog'lash.</summary>
    [Column("branch_id")]
    public Guid? BranchId { get; set; }

    /// <summary>Taklif qilingan roli.</summary>
    [Column("role")]
    public MerchantUserRole Role { get; set; } = MerchantUserRole.Cashier;

    /// <summary>Deep-link tokeni.</summary>
    [MaxLength(64)]
    [Column("token")]
    public string Token { get; set; } = string.Empty;

    /// <summary>Taklifni kim yaratdi (users.id).</summary>
    [Column("created_by_user_id")]
    public Guid CreatedByUserId { get; set; }

    /// <summary>Havolaning amallilik muddati (UTC).</summary>
    [Column("expires_at")]
    public DateTime ExpiresAt { get; set; }

    /// <summary>Havola ishlatildimi flagi.</summary>
    [Column("is_used")]
    public bool IsUsed { get; set; } = false;

    /// <summary>Havolani kim ishlatdi (agar ishlatilgan bo'lsa).</summary>
    [Column("used_by_user_id")]
    public long? UsedByUserId { get; set; }

    /// <summary>Yaratilgan vaqt (UTC).</summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    // Navigation properties
    /// <summary>Taklif qilgan merchant.</summary>
    [ForeignKey(nameof(CompanytId))]
    public Company? Company { get; set; }

    /// <summary>Taklif qilgan filial (agar mavjud bo'lsa).</summary>
    [ForeignKey(nameof(BranchId))]
    public Branch? Branch { get; set; }

    /// <summary>Taklifni yaratgan user.</summary>
    [ForeignKey(nameof(CreatedByUserId))]
    public User? CreatedByUser { get; set; }

    /// <summary>Taklifni ishlatgan user (agar ishlatilgan bo'lsa).</summary>
    [ForeignKey(nameof(UsedByUserId))]
    public User? UsedByUser { get; set; }
}

