using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveEat.Domain.Entities;

/// <summary>
/// Hamkor do'konning balans va hamyon ma'lumotlari.
/// AvailableBalance — yechib olinadigan pul, PendingBalance — ushlab turilgan summa.
/// </summary>
[Table("merchant_wallets")]
public class MerchantWallet
{
    /// <summary>Hamyon UUID identifikatori.</summary>
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    /// <summary>Ushbu hamyon tegishli bo'lgan merchant ID.</summary>
    [Column("merchant_id")]
    public Guid MerchantId { get; set; }

    /// <summary>Yechib olinishi mumkin bo'lgan balans.</summary>
    [Column("available_balance")]
    public decimal AvailableBalance { get; set; } = 0.00m;

    /// <summary>Hozircha ushlab turilgan balans (pending).</summary>
    [Column("pending_balance")]
    public decimal PendingBalance { get; set; } = 0.00m;

    /// <summary>Jami yechib olingan summa.</summary>
    [Column("total_withdrawn")]
    public decimal TotalWithdrawn { get; set; } = 0.00m;

    /// <summary>Balans oxirgi yangilangan vaqt (UTC).</summary>
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
