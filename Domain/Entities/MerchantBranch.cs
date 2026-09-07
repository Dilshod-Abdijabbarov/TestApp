using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveEat.Domain.Entities;

/// <summary>
/// Merchantning filial (branch) ma'lumotlari: manzil, telefon, GPS va reytinglar.
/// Har bir filial o'z pickup punktiga ega bo'ladi.
/// </summary>
[Table("merchant_branches")]
public class MerchantBranch
{
    /// <summary>Filial UUID identifikatori.</summary>
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    /// <summary>Qaysi merchantga tegishli ekanligi.</summary>
    [Column("merchant_id")]
    public Guid MerchantId { get; set; }

    /// <summary>Filial nomi.</summary>
    [MaxLength(150)]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>To'liq manzil matni.</summary>
    [Column("address_text")]
    public string AddressText { get; set; } = string.Empty;

    /// <summary>Mo'ljal yoki landmark.</summary>
    [MaxLength(255)]
    [Column("landmark")]
    public string? Landmark { get; set; }

    /// <summary>GPS kenglik (latitude).</summary>
    [Column("latitude")]
    public decimal Latitude { get; set; }

    /// <summary>GPS uzunlik (longitude).</summary>
    [Column("longitude")]
    public decimal Longitude { get; set; }

    /// <summary>Filial telefon raqami.</summary>
    [MaxLength(20)]
    [Column("phone_number")]
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>Filial reytingi (1-5).</summary>
    [Column("rating")]
    public decimal Rating { get; set; } = 5.00m;

    /// <summary>Filialga qoldirilgan umumiy sharhlar soni.</summary>
    [Column("total_reviews_count")]
    public int TotalReviewsCount { get; set; } = 0;

    /// <summary>Filial faol yoki yo'qligi.</summary>
    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    /// <summary>Qo'shilgan vaqt (UTC).</summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
