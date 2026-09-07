using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaveEat.Domain.Enums;

namespace SaveEat.Domain.Entities;

/// <summary>
/// To'lovlar jurnali — har bir buyurtma bo'yicha bank yoki to'lov provayderi transaksiyalarini saqlaydi.
/// Payload maydoni bankdan kelgan xom JSONni saqlash uchun ishlatiladi.
/// </summary>
[Table("payments")]
public class Payment
{
    /// <summary>To'lov UUID.</summary>
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    /// <summary>Qaysi buyurtmaga tegishli (orders.id).</summary>
    [Column("order_id")]
    public Guid OrderId { get; set; }

    /// <summary>To'lov provayderi (CLICK, PAYME, UZUM ...).</summary>
    [Column("provider")]
    public PaymentProvider Provider { get; set; }

    /// <summary>Bank tranzaksiya raqami.</summary>
    [MaxLength(100)]
    [Column("transaction_id")]
    public string? TransactionId { get; set; }

    /// <summary>To'langan summa.</summary>
    [Column("amount")]
    public decimal Amount { get; set; }

    /// <summary>To'lov holati (Initialized, Success, Failed ...).</summary>
    [Column("status")]
    public PaymentStatus Status { get; set; } = PaymentStatus.Initialized;

    /// <summary>Bankdan kelgan xom JSON javob (postgres jsonb).</summary>
    [Column("payload", TypeName = "jsonb")]
    public string? Payload { get; set; }

    /// <summary>Yaratilgan vaqt (UTC).</summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    /// <summary>Oxirgi yangilanish vaqti (UTC).</summary>
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    // Navigation
    /// <summary>Tegishli buyurtma.</summary>
    [ForeignKey(nameof(OrderId))]
    public Order? Order { get; set; }
}