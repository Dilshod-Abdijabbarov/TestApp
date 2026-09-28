using Domain.Entities;
using Domain.Entities.Deliveries;
using Domain.Entities.Users;
using SaveEat.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveEat.Domain.Entities.Deliveries;

/// <summary>
/// Yetkazib beruvchi (kuryerning) profili.
/// Kuryeriga tegishli: reyting, xodim profili, aktiv buyurtmalar va ish jadvali.
/// </summary>
[Table("couriers")]
public class Courier : BaseEntity
{
    /// <summary>Asosiy Employee profili (users.id orqali bog'langan).</summary>
    [Column("employee_id")]
    public Guid EmployeeId { get; set; }

    /// <summary>Kuryerning faollik holati.</summary>
    [Column("status")]
    public CourierStatus Status { get; set; } = CourierStatus.Inactive;

    /// <summary>Kuryerning reytingi (1.0 - 5.0).</summary>
    [Column("rating")]
    public decimal Rating { get; set; } = 5.00m;

    /// <summary>Tayoq (pastki belgi) buyurtma soni.</summary>
    [Column("total_deliveries")]
    public int TotalDeliveries { get; set; } = 0;

    /// <summary>Bajarilgan buyurtmalar soni.</summary>
    [Column("completed_deliveries")]
    public int CompletedDeliveries { get; set; } = 0;

    /// <summary>Muvaffaqiyatsiz yetkazib berish soni (jazo uchun).</summary>
    [Column("failed_deliveries")]
    public int FailedDeliveries { get; set; } = 0;

    /// <summary>Jami jazo nuqtalari (qoidabuzarlik uchun jazolash).</summary>
    [Column("penalty_points")]
    public int PenaltyPoints { get; set; } = 0;

    /// <summary>Joriy aktiv buyurtmalar soni.</summary>
    [Column("active_delivery_count")]
    public int ActiveDeliveryCount { get; set; } = 0;

    /// <summary>Maksimal simultan buyurtmalar soni (bir vaqtda nechta olishi mumkin).</summary>
    [Column("max_concurrent_deliveries")]
    public int MaxConcurrentDeliveries { get; set; } = 5;

    /// <summary>Vositaning tipi (Motocycle, Car, Bicycle, Foot).</summary>
    [Column("vehicle_type")]
    public VehicleType VehicleType { get; set; } = VehicleType.Motorcycle;

    /// <summary>Tizimga registratsiya qilingan vaqt (UTC).</summary>
    [Column("registered_at")]
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow.AddHours(5);

    /// <summary>Oxirgi Aktivasiyon vaqti (UTC).</summary>
    [Column("last_active_at")]
    public DateTime? LastActiveAt { get; set; }

    /// <summary>Kuryerni band qilgan o'tkazmasi / boshqa kommentar.</summary>
    [Column("notes")]
    [MaxLength(500)]
    public string? Notes { get; set; }

    // Navigation
    /// <summary>Employee profili (User orqali bog'langan).</summary>
    [ForeignKey(nameof(EmployeeId))]
    public Employee Employee { get; set; } = null!;

    /// <summary>Kuryerning yetkazib berish buyurtmalari.</summary>
    public ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    /// <summary>Kuryerning ish jadvallari.</summary>
    public ICollection<CourierSchedule> Schedules { get; set; } = new List<CourierSchedule>();

    /// <summary>Kuryerning buyurtma tayinlash yozuvlari.</summary>
    public ICollection<DeliveryAssignment> Assignments { get; set; } = new List<DeliveryAssignment>();

    /// <summary>Jazo yozuvlari.</summary>
    public ICollection<CourierPenalty> Penalties { get; set; } = new List<CourierPenalty>();

    /// <summary>Kuryerning joriy yoki yaqindan keladigan aktiv jadvali.</summary>
    public CourierSchedule? GetActiveSchedule()
    {
        var now = DateTime.UtcNow;
        return Schedules.FirstOrDefault(s => s.IsActive && s.ShiftStart <= now && now <= s.ShiftEnd);
    }

    /// <summary>Kuryerning aktiv buyurtmalarini biriktirish imkoniyati bor yoki yo'q.</summary>
    public bool CanAcceptDelivery()
    {
        return Status == CourierStatus.Active
            && ActiveDeliveryCount < MaxConcurrentDeliveries
            && PenaltyPoints < 100;  // Jazo 100+ dan oshsa, ishga olib qo'ymaydi
    }
}
