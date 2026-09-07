using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaveEat.Domain.Enums;

namespace SaveEat.Domain.Entities;

/// <summary>
/// Buyurtma yozuvi — mijoz buyurtma bergan savat, miqdor, to'lov holati va tasdiqlash ma'lumotlari.
/// Order ichida to'lov, kelish va tasdiqlashga oid maydonlar mavjud.
/// </summary>
[Table("orders")]
public class Order
{
    /// <summary>Buyurtma UUID.</summary>
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    /// <summary>O'qilishi oson buyurtma kodi.</summary>
    [MaxLength(20)]
    [Column("order_number")]
    public string OrderNumber { get; set; } = string.Empty;

    /// <summary>Buyurtma qilgan foydalanuvchi (users.id).</summary>
    [Column("user_id")]
    public Guid UserId { get; set; }

    /// <summary>Sotib olingan savat ID.</summary>
    [Column("bag_id")]
    public Guid BagId { get; set; }

    /// <summary>Qaysi filialdan olinadi.</summary>
    [Column("branch_id")]
    public Guid BranchId { get; set; }

    /// <summary>QRni skaner qilgan xodim (agar skanerlangan bo'lsa).</summary>
    [Column("scanned_by_user_id")]
    public Guid? ScannedByUserId { get; set; }

    /// <summary>Savat soni.</summary>
    [Column("quantity")]
    public int Quantity { get; set; } = 1;

    /// <summary>Mijoz to'lagan umumiy summa.</summary>
    [Column("total_amount")]
    public decimal TotalAmount { get; set; }

    /// <summary>Platforma oladigan komissiya summasi.</summary>
    [Column("platform_fee")]
    public decimal PlatformFee { get; set; }

    /// <summary>Do'konga to'lanadigan summa (total - platform_fee).</summary>
    [Column("merchant_amount")]
    public decimal MerchantAmount { get; set; }

    /// <summary>Buyurtma holati (PendingPayment, Paid, Completed ...).</summary>
    [Column("status")]
    public OrderStatus Status { get; set; } = OrderStatus.PendingPayment;

    /// <summary>Mijoz yetib kelganligini bildirgan flag.</summary>
    [Column("is_client_arrived")]
    public bool IsClientArrived { get; set; } = false;

    /// <summary>Mijoz kelgan vaqt (agar bildirgan bo'lsa).</summary>
    [Column("arrived_at")]
    public DateTime? ArrivedAt { get; set; }

    /// <summary>QR skanerlangan vaqt.</summary>
    [Column("scanned_at")]
    public DateTime? ScannedAt { get; set; }

    /// <summary>Telegram orqali yuborilgan tasdiqlash xabari ID si.</summary>
    [Column("telegram_confirmation_msg_id")]
    public long? TelegramConfirmationMsgId { get; set; }

    /// <summary>Mijoz savatni olganini tasdiqladi-mi.</summary>
    [Column("is_client_confirmed")]
    public bool IsClientConfirmed { get; set; } = false;

    /// <summary>Mijoz tasdiqlagan aniq vaqt.</summary>
    [Column("client_confirmed_at")]
    public DateTime? ClientConfirmedAt { get; set; }

    /// <summary>Tasdiqlash usuli (Telegram, PIN, avtomatik timeout).</summary>
    [MaxLength(30)]
    [Column("confirmation_method")]
    public string? ConfirmationMethod { get; set; }

    /// <summary>PIN orqali qo'lda tasdiqlash sababi.</summary>
    [Column("override_reason")]
    public string? OverrideReason { get; set; }

    /// <summary>Zaxira 6 xonali PIN kod (agar ishlatilsa).</summary>
    [MaxLength(6)]
    [Column("claim_pin")]
    public string ClaimPin { get; set; } = string.Empty;

    /// <summary>QR-token tasdiqlash uchun.</summary>
    [Column("qr_token")]
    public Guid QrToken { get; set; } = Guid.NewGuid();

    /// <summary>To'lov kutish vaqti (reserved).</summary>
    [Column("reserved_until")]
    public DateTime ReservedUntil { get; set; }

    /// <summary>Buyurtma mukammal yakunlangan vaqt.</summary>
    [Column("completed_at")]
    public DateTime? CompletedAt { get; set; }

    /// <summary>Bekor qilingan vaqt.</summary>
    [Column("cancelled_at")]
    public DateTime? CancelledAt { get; set; }

    /// <summary>Bekor qilish sababi.</summary>
    [Column("cancellation_reason")]
    public string? CancellationReason { get; set; }

    /// <summary>Yaratilgan vaqt (UTC).</summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
