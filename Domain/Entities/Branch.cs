using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveEat.Domain.Entities;

/// <summary>
/// companiya filial (branch) ma'lumotlari: manzil, telefon, GPS va reytinglar.
/// Har bir filial o'z pickup punktiga ega bo'ladi.
/// </summary>
[Table("branches")]
public class Branch
{
    /// <summary>Filial UUID identifikatori.</summary>
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    /// <summary>Qaysi kompaniyaga tegishli ekanligi.</summary>
    [Column("company_id")]
    public Guid CompanyId { get; set; }

    /// <summary>Filial nomi.</summary>
    [MaxLength(200)]
    [Column("name")]
    public string Name { get; set; }

    /// <summary>To'liq manzil matni.</summary>
    [Column("address_text")]
    public string AddressText { get; set; }

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
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    /// <summary> filial yaratgan user idsi.</summary>
    [Column("created_by")]
    public Guid CreatedBy { get; set; }

    // Navigation properties
    /// <summary>Tegishli merchant.</summary>
    [ForeignKey(nameof(CompanyId))]
    public Company? Company { get; set; }

    /// <summary>Filialga tegishli buyurtmalar.</summary>
    public ICollection<Order> Orders { get; set; } = new List<Order>();

    /// <summary>Filial xodimlar.</summary>
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();

    /// <summary>Filialga qoldirilgan sharhlar.</summary>
    public ICollection<BranchReview> Reviews { get; set; } = new List<BranchReview>();

    /// <summary>Filialning mahsulot to'plami.</summary>
    public ICollection<ProductBundle> ProductBundles { get; set; } = new List<ProductBundle>();
}
