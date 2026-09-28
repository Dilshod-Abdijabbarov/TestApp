using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;
using Domain.Entities.Users;

namespace Domain.Entities.Products;

/// Setni olib chiqish uchun biriktirilgan xodim yozuvi.
/// Qaysi xodim qaysi Setga javobgar ekanligini saqlaydi.
[Table("set_assignees")]
public class SetAssignee : BaseEntity
{
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
    public Set Set { get; set; }

    ///  Tegishli employee. 
    [ForeignKey(nameof(EmployeeId))]
    public Employee AssignedEmployee { get; set; }
}

