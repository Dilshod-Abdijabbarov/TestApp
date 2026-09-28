
using Domain.Entities.Orders;
using SaveEat.Domain.Entities.Deliveries;
using SaveEat.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Deliveries;

/// <summary>
/// Buyurtmani mijozga yetkazib berish jarayoni.
/// Order - nima sotib olinganini,
/// Delivery - shu buyurtmaning qanday yetkazilayotganini bildiradi.
/// </summary>
[Table("deliveries")]
public class Delivery : BaseEntity
{
    /// <summary>
    /// Yetkazib berilayotgan buyurtma identifikatori.
    /// </summary>
    [Column("order_id")]
    public Guid OrderId { get; set; }

    /// <summary>
    /// Hozirgi vaqtda ushbu delivery uchun tanlangan kuryer.
    /// Kuryer hali biriktirilmagan bo'lishi mumkin.
    /// </summary>
    [Column("courier_id")]
    public Guid? CourierId { get; set; }

    /// <summary>
    /// Yetkazib berishning joriy holati.
    /// </summary>
    [Column("status")]
    public DeliveryStatus Status { get; set; } = DeliveryStatus.Pending;

    /// <summary>
    /// Yetkazib berish manzili.
    /// </summary>
    [Column("delivery_address")]
    [MaxLength(500)]
    public string DeliveryAddress { get; set; } = null!;

    /// <summary>
    /// Yetkazib berish manzilining latitude koordinatasi.
    /// </summary>
    [Column("latitude")]
    public decimal? Latitude { get; set; }

    /// <summary>
    /// Yetkazib berish manzilining longitude koordinatasi.
    /// </summary>
    [Column("longitude")]
    public decimal? Longitude { get; set; }

    /// <summary>
    /// Buyurtmani qabul qiluvchi shaxsning ismi.
    /// </summary>
    [Column("recipient_name")]
    [MaxLength(200)]
    public string RecipientName { get; set; } = null!;

    /// <summary>
    /// Buyurtmani qabul qiluvchi shaxsning telefon raqami.
    /// </summary>
    [Column("recipient_phone")]
    [MaxLength(50)]
    public string RecipientPhone { get; set; } = null!;

    /// <summary>
    /// Yetkazib berish bo'yicha qo'shimcha izoh.
    /// </summary>
    [Column("notes")]
    [MaxLength(500)]
    public string? Notes { get; set; }

    /// <summary>
    /// Kuryerga biriktirilgan vaqt.
    /// </summary>
    [Column("assigned_at")]
    public DateTime? AssignedAt { get; set; }

    /// <summary>
    /// Kuryer buyurtmani olib ketgan vaqt.
    /// </summary>
    [Column("picked_up_at")]
    public DateTime? PickedUpAt { get; set; }

    /// <summary>
    /// Buyurtma yetkazib berilayotgan vaqt.
    /// </summary>
    [Column("started_at")]
    public DateTime? StartedAt { get; set; }

    /// <summary>
    /// Buyurtma mijozga muvaffaqiyatli yetkazilgan vaqt.
    /// </summary>
    [Column("delivered_at")]
    public DateTime? DeliveredAt { get; set; }

    /// <summary>
    /// Delivery bekor qilingan vaqt.
    /// </summary>
    [Column("cancelled_at")]
    public DateTime? CancelledAt { get; set; }

    /// <summary>
    /// Yetkazib berish muvaffaqiyatsiz tugagan vaqt.
    /// </summary>
    [Column("failed_at")]
    public DateTime? FailedAt { get; set; }

    /// <summary>
    /// Delivery bekor qilinishi yoki muvaffaqiyatsiz tugashining sababi.
    /// </summary>
    [Column("failure_reason")]
    [MaxLength(500)]
    public string? FailureReason { get; set; }


    /// <summary>
    /// Ushbu delivery tegishli bo'lgan buyurtma.
    /// </summary>
    [ForeignKey(nameof(OrderId))]
    public Order Order { get; set; } = null!;

    /// <summary>
    /// Hozirgi deliveryga biriktirilgan kuryer.
    /// </summary>
    [ForeignKey(nameof(CourierId))]
    public Courier? Courier { get; set; }

    /// <summary>
    /// Ushbu delivery qaysi kuryerlarga taklif qilinganining tarixi.
    /// </summary>
    public ICollection<DeliveryAssignment> Assignments { get; set; }
        = new List<DeliveryAssignment>();

    /// <summary>
    /// Delivery statuslari o'zgarishining tarixi.
    /// </summary>
    public ICollection<DeliveryStatusHistory> StatusHistory { get; set; }
        = new List<DeliveryStatusHistory>();
}


