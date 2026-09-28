using SaveEat.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Companies;

/// Bank orqali hisob-kitob reestri — do'konlarga o'tkazilgan/otkaziladigan to'lovlar haqida yozuv.
[Table("company_payouts")]
public class CompanyPayout : BaseEntity
{
    ///  filialga tegishli to'lov. 
    //BranchId
    [Column("branch_id")]
    public Guid BranchId { get; set; }

    ///  To'lov hujjat raqami. 
    [MaxLength(30)]
    [Column("settlement_number")]
    public string SettlementNumber { get; set; } = string.Empty;

    ///  O'tkaziladigan summa. 
    [Column("amount")]
    public decimal Amount { get; set; }

    ///  Pul tushadigan bank hisobi. 
    [MaxLength(50)]
    [Column("bank_account")]
    public string BankAccount { get; set; } = string.Empty;

    ///  Hisob davri boshi (UTC). 
    [Column("period_start")]
    public DateTime PeriodStart { get; set; }

    ///  Hisob davri oxiri (UTC). 
    [Column("period_end")]
    public DateTime PeriodEnd { get; set; }

    ///  Jarayon holati (PENDING, PAID ...). 
    [Column("status")]
    public PaymentStatus Status { get; set; }

    ///  To'lov topshirig'i fayli yoki URL. 
    [Column("payment_proof_url")]
    public string PaymentProofUrl { get; set; }

    ///  To'lov qayta ishlangan vaqt (UTC) — agar mavjud bo'lsa. 
    [Column("processed_at")]
    public DateTime ProcessedAt { get; set; }

    // Navigation
    ///  Branch. 
    [ForeignKey(nameof(BranchId))]
    public Branch Branch { get; set; }
}

