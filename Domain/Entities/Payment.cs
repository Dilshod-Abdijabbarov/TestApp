using Domain.Entities;
using Domain.Entities.Orders;
using SaveEat.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveEat.Domain.Entities;

/// To'lovlar jurnali — har bir buyurtma bo'yicha bank yoki to'lov provayderi transaksiyalarini saqlaydi.
/// Payload maydoni bankdan kelgan xom JSONni saqlash uchun ishlatiladi.
[Table("payments")]
public class Payment : BaseEntity
{
    ///  Qaysi buyurtmaga tegishli (orders.id). 
    [Column("order_id")]
    public Guid OrderId { get; set; }

    ///  To'lov provayderi (CLICK, PAYME, UZUM ...). 
    [Column("provider")]
    public PaymentProvider Provider { get; set; }

    ///  Bank tranzaksiya raqami. 
    [MaxLength(100)]
    [Column("transaction_id")]
    public string? TransactionId { get; set; }

    ///  To'langan summa. 
    [Column("amount")]
    public decimal Amount { get; set; }

    ///  To'lov holati (Initialized, Success, Failed ...). 
    [Column("status")]
    public PaymentStatus Status { get; set; } = PaymentStatus.Initialized;

    ///  Bankdan kelgan xom JSON javob (postgres jsonb). 
    [Column("payload", TypeName = "jsonb")]
    public string? Payload { get; set; }

    ///  Oxirgi yangilanish vaqti (UTC). 
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    // Navigation
    ///  Tegishli buyurtma. 
    [ForeignKey(nameof(OrderId))]
    public Order? Order { get; set; }
}