using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveEat.Domain.Entities;

/// <summary>
/// Savatga tegishli haqiqiy rasmlar galereyasi.
/// Har bir rasm URL va ko'rsatish ketma-ketligini oladi.
/// </summary>
[Table("surprise_bag_images")]
public class SurpriseBagImage
{
    /// <summary>Rasm yozuvi UUID.</summary>
    [Key]
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>Qaysi savatga tegishli.</summary>
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
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>Savatni kiritgan xodim (merchant_users.id).</summary>
    [Column("created_by_user_id")]
    public Guid CreatedByUserId { get; set; }
}
