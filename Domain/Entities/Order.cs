using Domain.Enums;
using SaveEat.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace SaveEat.Domain.Entities;

/// Buyurtma yozuvi — mijoz buyurtma bergan bundle, miqdor, to'lov holati va tasdiqlash ma'lumotlari.
/// Order ichida to'lov, kelish va tasdiqlashga oid maydonlar mavjud.
[Table("orders")]
public class Order
{
    public Order()
    {
        ClaimPin = GenerateCode();
    }

    ///  Buyurtma UUID. 
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    ///  O'qilishi oson buyurtma kodi. 
    [MaxLength(20)]
    [Column("order_number")]
    public string OrderNumber { get; set; } = string.Empty;

    ///  Buyurtma qilgan foydalanuvchi (users.id). 
    [Column("user_id")]
    public Guid UserId { get; set; }

    ///  Sotib olingan bundle ID. 
    [Column("bundle_id")]
    public Guid BundleId { get; set; }

    ///  Qaysi filialdan olinadi. 
    [Column("branch_id")]
    public Guid BranchId { get; set; }

    ///  QRni skaner qilgan xodim (agar skanerlangan bo'lsa). 
    [Column("scanned_by_employee_id")] 
    public Guid? ScannedByEmployeeId { get; set; }

    ///  Bundle soni. 
    [Column("quantity")]
    public int Quantity { get; set; } = 1;

    ///  Mijoz to'lagan umumiy summa. 
    [Column("total_amount")]
    public decimal TotalAmount { get; set; }

    ///  Platforma oladigan komissiya summasi. 
    [Column("platform_fee")]
    public decimal PlatformFee { get; set; }

    ///  Do'konga to'lanadigan summa (total - platform_fee). 
    [Column("merchant_amount")]
    public decimal MerchantAmount { get; set; }

    ///  Buyurtma holati (PendingPayment, Paid, Completed ...). 
    [Column("status")]
    public OrderStatus Status { get; set; } = OrderStatus.PendingPayment;

    ///  Telegram orqali yuborilgan tasdiqlash xabari ID si. 
    [Column("telegram_confirmation_msg_id")]
    public long? TelegramConfirmationMsgId { get; set; }

    ///  Tasdiqlash usuli (Telegram, PIN, avtomatik timeout). 
    [MaxLength(30)]
    [Column("confirmation_method")]
    public ConfirmationMethod ConfirmationMethod { get; set; }

    // TUZATISH: xavfsiz default — bo'sh qator emas, null. PIN faqat Service qatlamida,
    // Order yaratilishi bilan darhol tasodifiy generatsiya qilinadi.
    [MaxLength(9)]
    [Column("claim_pin")] 
    public string ClaimPin { get; set; }

    ///  QR-token tasdiqlash uchun. 
    [Column("qr_token")]
    public Guid QrToken { get; set; } = Guid.NewGuid();

    ///  To'lov kutish vaqti (reserved). 
    [Column("reserved_until")]
    public DateTime ReservedUntil { get; set; }

    ///  Mijoz kelgan vaqt (agar bildirgan bo'lsa). 
    [Column("arrived_at")]
    public DateTime? ArrivedAt { get; set; }

    ///  QR skanerlangan vaqt. 
    [Column("scanned_at")]
    public DateTime? ScannedAt { get; set; }

    ///  Mijoz tasdiqlagan aniq vaqt. 
    [Column("client_confirmed_at")]
    public DateTime? ClientConfirmedAt { get; set; }

    ///  Buyurtma yakunlangan vaqt. 
    [Column("completed_at")]
    public DateTime? CompletedAt { get; set; }

    ///  Bekor qilingan vaqt. 
    [Column("cancelled_at")]
    public DateTime? CancelledAt { get; set; }

    ///  Yaratilgan vaqt (UTC). 
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    // TUZATISH: string -> enum (kod) + alohida erkin izoh maydoni
    [Column("cancellation_reason_code")] 
    public CancellationReason CancellationReasonCode { get; set; }

    /// TUZATISH: bekor qilish sababi uchun erkin izoh maydoni
    [Column("cancellation_note")]
    public string? CancellationNote { get; set; }

    ///  PIN orqali qo'lda tasdiqlash sababi. 
    [Column("override_reason")] 
    public OverrideReason OverrideReason { get; set; }

    // Navigation properties
    ///  Buyurtma qilgan user. 
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    ///  Sotib olingan bundle. 
    [ForeignKey(nameof(BundleId))]
    public Bundle? Bundle { get; set; }

    ///  Pickup filiali. 
    [ForeignKey(nameof(BranchId))]
    public Branch? Branch { get; set; }

    ///  QRni skaner qilgan xodim. 
    [ForeignKey(nameof(ScannedByEmployeeId))]
    public Employee? ScannedByEmployee { get; set; }

    ///  Buyurtma to'lov yozuvi. 
    public Payment? Payment { get; set; }

    ///  Buyurtma tasnifi (sharh). 
    public BranchReview? Review { get; set; }

    ///  Service qatlamida saqlashdan oldin tekshirish uchun. 
    public bool IsAmountConsistent() => TotalAmount == PlatformFee + MerchantAmount;
    private static string GenerateCode()
    {
        return GetRandomString(6);
    }

    private static string GetRandomString(int length)
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        var result = new StringBuilder(length);
        using (var rng = RandomNumberGenerator.Create())
        {
            var bytes = new byte[length];
            rng.GetBytes(bytes);
            foreach (var b in bytes)
                result.Append(chars[b % chars.Length]);
        }
        return result.ToString();
    }
}

