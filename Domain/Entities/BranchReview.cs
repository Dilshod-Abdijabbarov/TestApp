using Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveEat.Domain.Entities;

/// Mijozlar tomonidan qoldirilgan sharhlar va baholar.
/// Har bir sharh buyurtma bilan bog'langan va filialga tegishli bo'ladi.
[Table("branch_reviews")]
public class BranchReview : BaseEntity
{
    ///  Qaysi buyurtma uchun qoldirilgan. 
    [Column("order_id")]
    public Guid OrderId { get; set; }

    ///  Sharhni yozgan foydalanuvchi (users.id). 
    [Column("user_id")]
    public Guid UserId { get; set; }

    ///  Filial identifikatori. 
    [Column("branch_id")]
    public Guid BranchId { get; set; }

    ///  Baho (1 dan 5 gacha). 
    [Range(1, 5)]
    [Column("rating")]
    public int Rating { get; set; }

    ///  Mijoz matnli fikri. 
    [Column("comment")]
    public string? Comment { get; set; }

    ///  Sharh anonim bo'lib qoldiriladimi. 
    [Column("is_anonymous")]
    public bool IsAnonymous { get; set; } = false;

    ///  Do'kon admini tomonidan berilgan rasmiy javob. 
    [Column("reply_from_branch")]
    public string? ReplyFromBranch { get; set; }

    //Sharhga javob bergan xodim/admin identifikatori(users.id yoki employees.id).
    [Column("replied_by_employee_id")]
    public Guid? RepliedByEmployeeId { get; set; }

    ///  Javob berilgan vaqt (agar mavjud bo'lsa). 
    [Column("replied_at")]
    public DateTime? RepliedAt { get; set; }

    // Navigation properties
    ///  Tegishli buyurtma. 
    [ForeignKey(nameof(OrderId))]
    public Order? Order { get; set; }

    ///  Sharh yozgan user. 
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    ///  Tegishli filial. 
    [ForeignKey(nameof(BranchId))]
    public Branch? Branch { get; set; }

    [ForeignKey(nameof(RepliedByEmployeeId))]
    public Employee? RepliedByEmployee { get; set; }
}
