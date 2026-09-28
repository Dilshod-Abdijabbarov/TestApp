
using Domain.Entities;
using Domain.Entities.Deliveries;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveEat.Domain.Entities.Deliveries;

/// <summary>
/// Buyurtma tayinlanish yozuvi - ko'p buyurtmani bitta kuryerga biriktirish.
/// Har bir buyurtma bir nechta kuryerlarga taklif qilinishi mumkin.
/// </summary>
[Table("delivery_assignments")] 
public class DeliveryAssignment : BaseEntity
{
    /// <summary>Yetkazib berish buyurtmasi identifikatori.</summary>
    [Column("delivery_id")]
    public Guid DeliveryId { get; set; }

    /// <summary>Kuryerimni identifikatori.</summary>
    [Column("courier_id")]
    public Guid CourierId { get; set; }

    /// <summary>Jadval identifikatori (agar kuryerni schedule'i bilan bog'langan bo'lsa).</summary>
    [Column("courier_schedule_id")]
    public Guid? CourierScheduleId { get; set; }

    /// <summary>Tayinlanish holati (Pending, Accepted, Rejected, Expired).</summary>
    [Column("status")]
    public AssignmentStatus Status { get; set; } = AssignmentStatus.Pending;

    /// <summary>Taklif yuborilgan vaqt (UTC).</summary>
    [Column("offered_at")]
    public DateTime OfferedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    /// <summary>Kuryerning javobini berish muddati (30 sekund).</summary>
    [Column("expires_at")]
    public DateTime ExpiresAt { get; set; }

    /// <summary>Kuryerning javobini bergan vaqt (UTC) (agar javob qilgan bo'lsa).</summary>
    [Column("responded_at")]
    public DateTime? RespondedAt { get; set; }

    /// <summary>Kuryerning javobini bergan vaqti (Accepted/Rejected).</summary>
    [Column("response")]
    public AssignmentResponse Response { get; set; } = AssignmentResponse.None;

    /// <summary>Kuryerning rad etish sababi (agar rad etgan bo'lsa).</summary>
    [Column("rejection_reason")]
    [MaxLength(300)]
    public string? RejectionReason { get; set; }

    /// <summary>Bu kuryerga nechi marta taklif yuborildiligi soni.</summary>
    [Column("offer_attempt_number")]
    public int OfferAttemptNumber { get; set; } = 1;

    // Navigation
    /// <summary>Tegishli yetkazib berish buyurtmasi.</summary>
    [ForeignKey(nameof(DeliveryId))]
    public Delivery Delivery { get; set; } = null!;

    /// <summary>Tegishli kuryeri.</summary>
    [ForeignKey(nameof(CourierId))]
    public Courier Courier { get; set; } = null!;

    /// <summary>Tegishli jadval (agar mavjud bo'lsa).</summary>
    [ForeignKey(nameof(CourierScheduleId))]
    public CourierSchedule? CourierSchedule { get; set; }
}