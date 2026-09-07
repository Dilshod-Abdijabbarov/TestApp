using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveEat.Domain.Entities;

/// <summary>
/// Bundlga tegishli haqiqiy rasmlar galereyasi.
/// Har bir rasm URL va ko'rsatish ketma-ketligini oladi.
/// </summary>
[Table("product_bundle_image")]
public class ProductBundleImage
{
    /// <summary>Rasm yozuvi UUID.</summary>
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    /// <summary>Qaysi bundlga tegishli.</summary>
    [Column("bag_id")]
    public Guid BagId { get; set; }

    /// <summary>Rasm URL (S3 yoki boshqa storage).</summary>
    [Column("image_url")]
    public string ImageUrl { get; set; } = string.Empty;

    /// <summary>Slayderda ko'rsatish tartibi.</summary>
    [Column("display_order")]
    public int DisplayOrder { get; set; } = 0;

    /// <summary>Asosiy rasm flagi.</summary>
    [Column("is_primary")]
    public bool IsPrimary { get; set; } = false;

    /// <summary>Rasm yuklangan vaqt (UTC).</summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    // Navigation
    /// <summary>Tegishli product bundle.</summary>
    [ForeignKey(nameof(BagId))]
    public ProductBundle? Bundle { get; set; }
}