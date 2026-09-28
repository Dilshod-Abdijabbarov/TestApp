using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveEat.Domain.Entities.Deliveries;

/// <summary>
/// Kuryerning ishga chiqish vaqt jadavali.
/// Misol: 28-sentabr, 12:00 dan 18:00 gacha ishga chiqish.
/// </summary>
[Table("courier_schedules")]
public class CourierSchedule : BaseEntity
{
    /// <summary>Kuryerning identifikatori.</summary>
    [Column("courier_id")]
    public Guid CourierId { get; set; }

    /// <summary>Ish boshlanish vaqti (UTC).</summary>
    [Column("shift_start")]
    public DateTime ShiftStart { get; set; }

    /// <summary>Ish tugash vaqti (UTC).</summary>
    [Column("shift_end")]
    public DateTime ShiftEnd { get; set; }

    /// <summary>Maksimal ishlash vaqti (soat).</summary>
    [Column("max_work_duration_hours")]
    public int MaxWorkDurationHours { get; set; } = 8;

    /// <summary>Jadval faol yoki emas flagi.</summary>
    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    /// <summary>Jadval tahrir qilingan vaqt (UTC).</summary>
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    // Navigation
    /// <summary>Tegishli kuryerning profili.</summary>
    [ForeignKey(nameof(CourierId))]
    public Courier Courier { get; set; } = null!;

    /// <summary>Bu jadvaldagi ishlar.</summary>
    public ICollection<DeliveryAssignment> Assignments { get; set; } = new List<DeliveryAssignment>();

    // Validatsiya
    /// <summary>Vaqt oraligi o'zini o'ziga qoplanmasligini tekshiradi.</summary>
    public bool IsValidTimeRange() => ShiftStart < ShiftEnd;
}