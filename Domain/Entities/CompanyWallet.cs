using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;

namespace SaveEat.Domain.Entities;

/// Hamkor do'konning balans va hamyon ma'lumotlari.
/// AvailableBalance — yechib olinadigan pul, PendingBalance — ushlab turilgan summa.
[Table("company_wallets")]
public class CompanyWallet : BaseEntity
{
    ///  filial id 
    [Column("branch_id")]
    public Guid BranchId { get; set; }

    ///  Yechib olinishi mumkin bo'lgan balans. 
    [Column("available_balance")]
    public decimal AvailableBalance { get; set; } = 0.00m;

    ///  Hozircha ushlab turilgan balans (pending). 
    [Column("pending_balance")]
    public decimal PendingBalance { get; set; } = 0.00m;

    ///  Jami yechib olingan summa. 
    [Column("total_withdrawn")]
    public decimal TotalWithdrawn { get; set; } = 0.00m;

    ///  Balans oxirgi yangilangan vaqt (UTC). 
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    ///  Filial. 
    [ForeignKey(nameof(BranchId))]
    public Branch? Branch { get; set; }
}
