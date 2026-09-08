using Domain.Enums;
using SaveEat.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace SaveEat.Domain.Entities;

/// <summary>
/// Buyurtma yozuvi — mijoz buyurtma bergan bundle, miqdor, to'lov holati va tasdiqlash ma'lumotlari.
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

    /// <summary>Sotib olingan bundle ID.</summary>
    [Column("bag_id")]
    public Guid BagId { get; set; }

    /// <summary>Qaysi filialdan olinadi.</summary>
    [Column("branch_id")]
    public Guid BranchId { get; set; }

    /// <summary>QRni skaner qilgan xodim (agar skanerlangan bo'lsa).</summary>
    [Column("scanned_by_employee_id")] 
    public Guid? ScannedByEmployeeId { get; set; }

    /// <summary>Bundle soni.</summary>
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

    /// <summary>Telegram orqali yuborilgan tasdiqlash xabari ID si.</summary>
    [Column("telegram_confirmation_msg_id")]
    public long? TelegramConfirmationMsgId { get; set; }

    /// <summary>Tasdiqlash usuli (Telegram, PIN, avtomatik timeout).</summary>
    [MaxLength(30)]
    [Column("confirmation_method")]
    public ConfirmationMethod ConfirmationMethod { get; set; }

    // TUZATISH: xavfsiz default — bo'sh qator emas, null. PIN faqat Service qatlamida,
    // Order yaratilishi bilan darhol tasodifiy generatsiya qilinadi (masalan RandomNumberGenerator orqali).
    [MaxLength(6)][Column("claim_pin")] 
    public string? ClaimPin { get; set; }

    /// <summary>QR-token tasdiqlash uchun.</summary>
    [Column("qr_token")]
    public Guid QrToken { get; set; } = Guid.NewGuid();

    /// <summary>To'lov kutish vaqti (reserved).</summary>
    [Column("reserved_until")]
    public DateTime ReservedUntil { get; set; }

    /// <summary>Mijoz kelgan vaqt (agar bildirgan bo'lsa).</summary>
    [Column("arrived_at")]
    public DateTime? ArrivedAt { get; set; }

    /// <summary>QR skanerlangan vaqt.</summary>
    [Column("scanned_at")]
    public DateTime? ScannedAt { get; set; }

    /// <summary>Mijoz tasdiqlagan aniq vaqt.</summary>
    [Column("client_confirmed_at")]
    public DateTime? ClientConfirmedAt { get; set; }

    /// <summary>Buyurtma mukammal yakunlangan vaqt.</summary>
    [Column("completed_at")]
    public DateTime? CompletedAt { get; set; }

    /// <summary>Bekor qilingan vaqt.</summary>
    [Column("cancelled_at")]
    public DateTime? CancelledAt { get; set; }

    /// <summary>Yaratilgan vaqt (UTC).</summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    // TUZATISH: string -> enum (kod) + alohida erkin izoh maydoni
    [Column("cancellation_reason_code")] 
    public CancellationReason CancellationReasonCode { get; set; }

    /// TUZATISH: bekor qilish sababi uchun erkin izoh maydoni
    [Column("cancellation_note")]
    public string? CancellationNote { get; set; }

    /// <summary>PIN orqali qo'lda tasdiqlash sababi.</summary>
    [Column("override_reason")] 
    public OverrideReason OverrideReason { get; set; }

    // Navigation properties
    /// <summary>Buyurtma qilgan user.</summary>
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    /// <summary>Sotib olingan bundle.</summary>
    [ForeignKey(nameof(BagId))]
    public ProductBundle? Bundle { get; set; }

    /// <summary>Pickup filiali.</summary>
    [ForeignKey(nameof(BranchId))]
    public Branch? Branch { get; set; }

    /// <summary>QRni skaner qilgan xodim.</summary>
    [ForeignKey(nameof(ScannedByEmployeeId))]
    public Employee? ScannedByEmployee { get; set; }

    /// <summary>Buyurtma to'lov yozuvi.</summary>
    public Payment? Payment { get; set; }

    /// <summary>Buyurtma tasnifi (sharh).</summary>
    public BranchReview? Review { get; set; }

    /// <summary>Service qatlamida saqlashdan oldin tekshirish uchun.</summary>
    public bool IsAmountConsistent() => TotalAmount == PlatformFee + MerchantAmount;
    private string GenerateCode()
    {
        // 6 ta random belgi yaratish
        string randomPart = GetRandomString(6);

        // Yakuniy token yig‘ish
        string token = $"TK-{randomPart}";

        return token;
    }

    private string GetRandomString(int length)
    {
        var result = new StringBuilder(length);
        using (var rng = RandomNumberGenerator.Create())
        {
            var bytes = new byte[length];
            rng.GetBytes(bytes);
            foreach (var b in bytes)
                result.Append(_chars[b % _chars.Length]);
        }
        return result.ToString();
    }

    private char[] _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
}

