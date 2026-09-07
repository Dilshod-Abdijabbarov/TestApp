using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveEat.Domain.Entities;

/// <summary>
/// Bundlni olib chiqish uchun biriktirilgan xodim yozuvi.
/// Qaysi xodim qaysi bundlga javobgar ekanligini saqlaydi.
/// </summary>
[Table("bundle_assignees")]
public class BundleAssignee
{
    /// <summary>Yozuv UUID.</summary>
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    /// <summary>Biriktirilgan bundle ID.</summary>
    [Column("bag_id")]
    public Guid BagId { get; set; }

    /// <summary>Mas'ul xodim (employees.id).</summary>
    [Column("merchant_user_id")]
    public Guid MerchantUserId { get; set; }

    /// <summary>Biriktirilgan vaqt (UTC).</summary>
    [Column("assigned_at")]
    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    /// <summary>Tegishli product bundle.</summary>
    [ForeignKey(nameof(BagId))]
    public ProductBundle? Bundle { get; set; }

    /// <summary>Tegishli employee.</summary>
    [ForeignKey(nameof(MerchantUserId))]
    public Employee? AssignedEmployee { get; set; }
}

