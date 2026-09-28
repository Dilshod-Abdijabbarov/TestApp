using Domain.Entities.Companies;
using Domain.Entities.Orders;
using Domain.Entities.Products;
using SaveEat.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Users;

/// Do'kon xodimi (employee) — asl foydalanuvchi profiliga bog'langan,
/// filial yoki tarmoq menejeri bo'lishi mumkin (OWNER/MANAGER/CASHIER).
[Table("employees")]
public class Employee : BaseEntity
{
    ///  Asosiy foydalanuvchi profili identifikatori (users.id). 
    [Column("user_id")]
    public Guid UserId { get; set; }

    ///  Qaysi merchantga tegishli. 
    [Column("company_id")]
    public Guid CompanyId { get; set; }

    ///  Biriktirilgan filial (agar mavjud bo'lsa). 
    [Column("branch_id")]
    public Guid BranchId { get; set; }

    ///  Xodim roli. 
    [Column("role")]
    public CompanyUserRole Role { get; set; } = CompanyUserRole.Ofitsiant;

    ///  Xodim faol yoki emas flagi. 
    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    // Navigation properties
    ///  Tegishli foydalanuvchi. 
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }

    ///  Tegishli merchant. 
    [ForeignKey(nameof(CompanyId))]
    public Company Company { get; set; }

    ///  Tegishli filial (agar mavjud bo'lsa). 
    [ForeignKey(nameof(BranchId))]
    public Branch Branch { get; set; }

    ///  Ushbu xodim yaratgan product Setlari. 
    public ICollection<Set> CreatedSets { get; set; } = new List<Set>();

    ///  Ushbu xodim biriktirilgan Setlar. 
    public ICollection<SetAssignee> SetAssignees { get; set; } = new List<SetAssignee>();

    ///  Ushbu xodim skaner qilgan buyurtmalar. 
    public ICollection<Order> ScannedOrders { get; set; } = new List<Order>();
}
