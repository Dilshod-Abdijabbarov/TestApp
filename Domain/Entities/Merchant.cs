using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaveEat.Domain.Enums;

namespace SaveEat.Domain.Entities;

/// <summary>
/// Hamkor brend/kompaniya — savdo nuqtalarining egasi.
/// Ushbu klass brend haqida yuridik va biznes ma'lumotlarni saqlaydi.
/// </summary>
[Table("merchants")]
public class Merchant
{
    /// <summary>Hamkorning UUID identifikatori.</summary>
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    /// <summary>Brend nomi (jamoat ko'rsatish uchun).</summary>
    [MaxLength(150)]
    [Column("brand_name")]
    public string BrandName { get; set; } = string.Empty;

    /// <summary>Yuridik nom (shartnoma maqsadlari uchun).</summary>
    [MaxLength(255)]
    [Column("legal_name")]
    public string? LegalName { get; set; }

    /// <summary>STIR / INN raqami.</summary>
    [MaxLength(20)]
    [Column("tin_inn")]
    public string? TinInn { get; set; }

    /// <summary>Bank hisobraqami (to'lovlar uchun).</summary>
    [MaxLength(50)]
    [Column("bank_account")]
    public string? BankAccount { get; set; }

    /// <summary>Bank MFO kodi.</summary>
    [MaxLength(10)]
    [Column("mfo_bank_code")]
    public string? MfoBankCode { get; set; }

    /// <summary>Asosiy toifa (bag category).</summary>
    [Column("category")]
    public BagCategory Category { get; set; }

    /// <summary>Logo yoki brend rasmi URL.</summary>
    [Column("logo_url")]
    public string? LogoUrl { get; set; }

    /// <summary>Platforma komissiya foizi (decimal).</summary>
    [Column("commission_rate")]
    public decimal CommissionRate { get; set; } = 0.20m;

    /// <summary>Administrator tomonidan tasdiqlanganmi.</summary>
    [Column("is_verified")]
    public bool IsVerified { get; set; } = false;

    /// <summary>Hamkor faolmi (savdoga ruxsat).</summary>
    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    /// <summary>Yaratilgan vaqt (UTC).</summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>Oxirgi tahrir vaqti (UTC).</summary>
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

