using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveEat.Domain.Entities;

/// Setni olib chiqish uchun biriktirilgan xodim yozuvi.
/// Qaysi xodim qaysi Setga javobgar ekanligini saqlaydi.
[Table("set_assignees")]
public class SetAssignee
{
    ///  Yozuv UUID. 
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    ///  Biriktirilgan Set ID. 
    [Column("set_id")]
    public Guid SetId { get; set; }

    ///  Mas'ul xodim (employees.id). 
    [Column("employee_id")]
    public Guid EmployeeId { get; set; }

    ///  Biriktirilgan vaqt (UTC). 
    [Column("assigned_at")]
    public DateTime AssignedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    // Navigation properties
    ///  Tegishli product Set. 
    [ForeignKey(nameof(SetId))]
    public Set? Set { get; set; }

    ///  Tegishli employee. 
    [ForeignKey(nameof(EmployeeId))]
    public Employee? AssignedEmployee { get; set; }
}

