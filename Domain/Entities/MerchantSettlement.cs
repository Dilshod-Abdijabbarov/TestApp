using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveEat.Domain.Entities;

/// <summary>
/// Bank orqali hisob-kitob reestri — do'konlarga o'tkazilgan/otkaziladigan to'lovlar haqida yozuv.
/// </summary>
[Table("merchant_settlements")]
public class MerchantSettlement
{
    /// <summary>Reestr yozuvi UUID.</summary>
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    /// <summary>Qaysi merchantga to'lov tegishli.</summary>
    [Column("merchant_id")]
    public Guid MerchantId { get; set; }

    /// <summary>To'lov hujjat raqami.</summary>
    [MaxLength(30)]
    [Column("settlement_number")]
    public string SettlementNumber { get; set; } = string.Empty;

    /// <summary>O'tkaziladigan summa.</summary>
    [Column("amount")]
    public decimal Amount { get; set; }

    /// <summary>Pul tushadigan bank hisobi.</summary>
    [MaxLength(50)]
    [Column("bank_account")]
    public string BankAccount { get; set; } = string.Empty;

    /// <summary>Hisob davri boshi (UTC).</summary>
    [Column("period_start")]
    public DateTime PeriodStart { get; set; }

    /// <summary>Hisob davri oxiri (UTC).</summary>
    [Column("period_end")]
    public DateTime PeriodEnd { get; set; }

    /// <summary>Jarayon holati (PENDING, PAID ...).</summary>
    [MaxLength(30)]
    [Column("status")]
    public string Status { get; set; } = "PENDING";

    /// <summary>To'lov topshirig'i fayli yoki URL.</summary>
    [Column("payment_proof_url")]
    public string? PaymentProofUrl { get; set; }

    /// <summary>To'lov qayta ishlangan vaqt (UTC) — agar mavjud bo'lsa.</summary>
    [Column("processed_at")]
    public DateTime? ProcessedAt { get; set; }

    /// <summary>Reestr yozuvi yaratildi (UTC).</summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

