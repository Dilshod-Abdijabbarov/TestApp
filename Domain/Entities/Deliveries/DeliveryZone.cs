
using Domain.Entities;
using Domain.Entities.Deliveries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveEat.Domain.Entities.Deliveries;

/// <summary>
/// Yetkazib berish mintaqasi - shahar bo'ylab zonalar va har zonda narxi boshqa bo'lishi mumkin.
/// Misol: Shaharning markaziy qismi (Zone A), Periferiya (Zone B) - har biri turli narx.
/// </summary>
[Table("delivery_zones")]
public class DeliveryZone : BaseEntity
{
    /// <summary>Zona nomi (Shahar Markaz³, Periferiya, Tashkent, Bektemir, ...).</summary>
    [MaxLength(150)]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>Zona tavsifi.</summary>
    [Column("description")]
    [MaxLength(500)]
    public string? Description { get; set; }

    /// <summary>Bu zona uchun yetkazib berish narxi (har zonadagi narx boshqa bo'lishi mumkin).</summary>
    [Column("base_delivery_fee")]
    public decimal BaseDeliveryFee { get; set; }

    /// <summary>Minimal buyurtma miqdori bu zona uchun (agar mavjud bo'lsa).</summary>
    [Column("minimum_order_amount")]
    public decimal? MinimumOrderAmount { get; set; }

    /// <summary>O'rtacha yetkazib berish vaqti (soniyalar ichida).</summary>
    [Column("average_delivery_time_minutes")]
    public int AverageDeliveryTimeMinutes { get; set; } = 30;

    /// <summary>Zona faol yoki emas.</summary>
    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    /// <summary>Zona oxirgi yangilangan vaqt (UTC).</summary>
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    // Navigation
    /// <summary>Bu zonada yetkazib berilishi kerak bo'lgan buyurtmalar.</summary>
    public ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
}