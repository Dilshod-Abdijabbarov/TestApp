using Domain.Entities;
using Domain.Entities.Deliveries;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveEat.Domain.Entities.Deliveries;

/// <summary>
/// Kuryerning jazo yozuvi - muddati o'tgan yetkazib berish yoki qoidabuzarlik uchun.
/// Jazo ochkolar-ga qo'shiladi va 100+ bo'lsa, kuryer buyutma olishga qo'ymaydi.
/// </summary>
[Table("courier_penalties")]
public class CourierPenalty : BaseEntity 
{
    /// <summary>Kuryerning identifikatori.</summary>
    [Column("courier_id")]
    public Guid CourierId { get; set; }

    /// <summary>Jazo sababi (FailedDelivery, LateDelivery, Cancelled, ...).</summary>
    [Column("reason")]
    public PenaltyReason Reason { get; set; }

    /// <summary>Jazo ochkolari soni (odatda 10 - 50).</summary>
    [Column("points")]
    public int Points { get; set; }

    /// <summary>Tegishli buyurtma (agar mavjud bo'lsa).</summary>
    [Column("delivery_id")]
    public Guid? DeliveryId { get; set; }

    /// <summary>Administrator tomonidan kiritilgan izoh.</summary>
    [Column("notes")]
    [MaxLength(500)]
    public string? Notes { get; set; }

    /// <summary>Jazo ochiqlari o'chirilish vaqti (agar mavjud bo'lsa).</summary>
    [Column("removed_at")]
    public DateTime? RemovedAt { get; set; }

    /// <summary>O'chirilish sababi (Pardon, TimeBasedExpiry, ...).</summary>
    [Column("removal_reason")]
    public string? RemovalReason { get; set; }

    // Navigation
    /// <summary>Tegishli kuryerning profili.</summary>
    [ForeignKey(nameof(CourierId))]
    public Courier Courier { get; set; } = null!;

    /// <summary>Tegishli yetkazib berish (agar mavjud bo'lsa).</summary>
    [ForeignKey(nameof(DeliveryId))]
    public Delivery? Delivery { get; set; }

    /// <summary>Jazo o'chirilgan yoki faqal aktiv.</summary>
    public bool IsActive => RemovedAt == null;
}