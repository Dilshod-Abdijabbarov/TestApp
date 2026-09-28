using Domain.Entities;
using Domain.Entities.Deliveries;
using Domain.Entities.Users;
using SaveEat.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveEat.Domain.Entities.Deliveries;

/// <summary>
/// Yetkazib berish holatining tarix yozuvi - kimin tomonidan qachon o'zgartirilgani.
/// Txning o'tishi kontrol qilish va audit uchun.
/// </summary>
[Table("delivery_status_history")]
public class DeliveryStatusHistory : BaseEntity
{
    /// <summary>Yetkazib berish buyurtmasi identifikatori.</summary>
    [Column("delivery_id")]
    public Guid DeliveryId { get; set; }

    /// <summary>Yangi holati.</summary>
    [Column("status")]
    public DeliveryStatus Status { get; set; }

    /// <summary>Holati kim tomonidan o'zgartirildi (agar mavjud bo'lsa).</summary>
    [Column("changed_by_user_id")]
    public Guid? ChangedByUserId { get; set; }

    /// <summary>O'zgartirilgan vaqt (UTC).</summary>
    [Column("changed_at")]
    public DateTime ChangedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    /// <summary>Holat o'zgartirilish izohali eslatma.</summary>
    [Column("note")]
    [MaxLength(500)]
    public string? Note { get; set; }

    /// <summary>Kuryerning tepa joylashuvi (latitude).</summary>
    [Column("latitude")]
    public decimal? Latitude { get; set; }

    /// <summary>Kuryerning tepa joylashuvi (longitude).</summary>
    [Column("longitude")]
    public decimal? Longitude { get; set; }

    // Navigation
    /// <summary>Tegishli yetkazib berish buyurtmasi.</summary>
    [ForeignKey(nameof(DeliveryId))]
    public Delivery Delivery { get; set; } = null!;

    /// <summary>O'zgartirilgan user.</summary>
    [ForeignKey(nameof(ChangedByUserId))]
    public User? ChangedByUser { get; set; }
}