using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaveEat.Domain.Enums;

namespace SaveEat.Domain.Entities;

/// <summary>
/// Mahsulot to'plami (surprise bag) — chegirmaga qo'yilgan mahsulot paketlari.
/// Narxi, miqdori, olinadigan oynasi va holati kabi biznes ma'lumotlarni saqlaydi.
/// </summary>
[Table("product_bundles")]
public class ProductBundle
{
    /// <summary>Bundle UUID identifikatori.</summary>
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    /// <summary>Qaysi filialga tegishli bundle.</summary>
    [Column("branch_id")]
    public Guid BranchId { get; set; }

    /// <summary>Bundleni kiritgan xodim (employees.id).</summary>
    [Column("created_by_user_id")]
    public Guid CreatedByUserId { get; set; }

    /// <summary>Bundle nomi (sarlavha).</summary>
    [MaxLength(200)]
    [Column("title")]
    public string Title { get; set; } = string.Empty;

    /// <summary>Bundle toifasi (BagCategory).</summary>
    [Column("category")]
    public BagCategory Category { get; set; }

    /// <summary>Tavsif va allergenlar haqida matn.</summary>
    [Column("description")]
    public string? Description { get; set; }

    /// <summary>Asosiy muqova rasmi URL.</summary>
    [Column("cover_image_url")]
    public string? CoverImageUrl { get; set; }

    /// <summary>Halol standartlariga mos kelishi flagi.</summary>
    [Column("is_halal")]
    public bool IsHalal { get; set; } = true;

    /// <summary>Teglar (masalan: Vegan, Gluten-free).</summary>
    [MaxLength(255)]
    [Column("dietary_tags")]
    public string? DietaryTags { get; set; }

    /// <summary>Asl umumiy narx.</summary>
    [Column("original_price")]
    public decimal OriginalPrice { get; set; }

    /// <summary>Chegirmali sotish narxi.</summary>
    [Column("discount_price")]
    public decimal DiscountPrice { get; set; }

    /// <summary>Chiqarilgan jami miqdor.</summary>
    [Column("initial_quantity")]
    public int InitialQuantity { get; set; }

    /// <summary>Hozirda mavjud bo'lgan miqdor.</summary>
    [Column("available_quantity")]
    public int AvailableQuantity { get; set; }

    /// <summary>Olib ketish oynasi boshlanish vaqti (UTC).</summary>
    [Column("pickup_start")]
    public DateTime PickupStart { get; set; }

    /// <summary>Olib ketish oynasi tugash vaqti (UTC).</summary>
    [Column("pickup_end")]
    public DateTime PickupEnd { get; set; }

    /// <summary>Bundle holati (ACTIVE, SOLD_OUT ...).</summary>
    [Column("status")]
    public BagStatus Status { get; set; } = BagStatus.Active;

    /// <summary>Optimistic concurrency versiyasi — raqobatni oldini olish uchun.</summary>
    [ConcurrencyCheck]
    [Column("version")]
    public int Version { get; set; } = 0;

    /// <summary>Yaratilgan vaqt (UTC).</summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    // Navigation properties
    /// <summary>Tegishli filial.</summary>
    [ForeignKey(nameof(BranchId))]
    public Branch? Branch { get; set; }

    /// <summary>Bundleni yaratgan employee.</summary>
    [ForeignKey(nameof(CreatedByUserId))]
    public Employee? CreatedByEmployee { get; set; }

    /// <summary>Bundle rasmlari.</summary>
    public ICollection<ProductBundleImage> Images { get; set; } = new List<ProductBundleImage>();

    /// <summary>Bundl buyurtmalari.</summary>
    public ICollection<Order> Orders { get; set; } = new List<Order>();

    /// <summary>Bundl biriktirilgan xodimlar.</summary>
    public ICollection<BundleAssignee> Assignees { get; set; } = new List<BundleAssignee>();
}
