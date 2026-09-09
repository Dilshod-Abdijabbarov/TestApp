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
    [Column("bundle_id")]
    public Guid BundleId { get; set; }

    ///  Mas'ul xodim (employees.id). 
    [Column("employee_id")]
    public Guid EmployeeId { get; set; }

    ///  Biriktirilgan vaqt (UTC). 
    [Column("assigned_at")]
    public DateTime AssignedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    // Navigation properties
    ///  Tegishli product bundle. 
    [ForeignKey(nameof(BundleId))]
    public Bundle? Bundle { get; set; }

    ///  Tegishli employee. 
    [ForeignKey(nameof(EmployeeId))]
    public Employee? AssignedEmployee { get; set; }
}

