using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveEat.Domain.Entities;

/// Bundlni olib chiqish uchun biriktirilgan xodim yozuvi.
/// Qaysi xodim qaysi bundlga javobgar ekanligini saqlaydi.
[Table("bundle_assignees")]
public class BundleAssignee
{
    ///  Yozuv UUID. 
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    ///  Biriktirilgan bundle ID. 
    [Column("bag_id")]
    public Guid BagId { get; set; }

    ///  Mas'ul xodim (employees.id). 
    [Column("merchant_user_id")]
    public Guid MerchantUserId { get; set; }

    ///  Biriktirilgan vaqt (UTC). 
    [Column("assigned_at")]
    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    ///  Tegishli product bundle. 
    [ForeignKey(nameof(BagId))]
    public ProductBundle? Bundle { get; set; }

    ///  Tegishli employee. 
    [ForeignKey(nameof(MerchantUserId))]
    public Employee? AssignedEmployee { get; set; }
}

