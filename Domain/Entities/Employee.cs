using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaveEat.Domain.Enums;

namespace SaveEat.Domain.Entities;

/// Do'kon xodimi (employee) — asl foydalanuvchi profiliga bog'langan,
/// filial yoki tarmoq menejeri bo'lishi mumkin (OWNER/MANAGER/CASHIER).
[Table("employees")]
public class Employee
{
    ///  Xodim yozuvi UUID. 
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    ///  Asosiy foydalanuvchi profili identifikatori (users.id). 
    [Column("user_id")]
    public Guid UserId { get; set; }

    ///  Qaysi merchantga tegishli. 
    [Column("company_id")]
    public Guid CompanyId { get; set; }

    ///  Biriktirilgan filial (agar mavjud bo'lsa). 
    [Column("branch_id")]
    public Guid? BranchId { get; set; }

    ///  Xodim roli. 
    [Column("role")]
    public CompanyUserRole Role { get; set; } = CompanyUserRole.Ofitsiant;

    ///  Xodim faol yoki emas flagi. 
    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    ///  Yozuv yaratildi (UTC). 
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    // Navigation properties
    ///  Tegishli foydalanuvchi. 
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    ///  Tegishli merchant. 
    [ForeignKey(nameof(CompanyId))]
    public Company? Company { get; set; }

    ///  Tegishli filial (agar mavjud bo'lsa). 
    [ForeignKey(nameof(BranchId))]
    public Branch? Branch { get; set; }

    ///  Ushbu xodim yaratgan product bundllar. 
    public ICollection<ProductBundle> CreatedBundles { get; set; } = new List<ProductBundle>();

    ///  Ushbu xodim biriktirilgan bundllar. 
    public ICollection<BundleAssignee> AssignedBundles { get; set; } = new List<BundleAssignee>();

    ///  Ushbu xodim skaner qilgan buyurtmalar. 
    public ICollection<Order> ScannedOrders { get; set; } = new List<Order>();
}
