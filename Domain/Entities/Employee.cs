using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaveEat.Domain.Enums;

namespace SaveEat.Domain.Entities;

/// <summary>
/// Do'kon xodimi (employee) — asl foydalanuvchi profiliga bog'langan,
/// filial yoki tarmoq menejeri bo'lishi mumkin (OWNER/MANAGER/CASHIER).
/// </summary>
[Table("employees")]
public class Employee
{
    /// <summary>Xodim yozuvi UUID.</summary>
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    /// <summary>Asosiy foydalanuvchi profili identifikatori (users.id).</summary>
    [Column("user_id")]
    public Guid UserId { get; set; }

    /// <summary>Qaysi merchantga tegishli.</summary>
    [Column("company_id")]
    public Guid CompanyId { get; set; }

    /// <summary>Biriktirilgan filial (agar mavjud bo'lsa).</summary>
    [Column("branch_id")]
    public Guid? BranchId { get; set; }

    /// <summary>Xodim roli.</summary>
    [Column("role")]
    public MerchantUserRole Role { get; set; } = MerchantUserRole.Cashier;

    /// <summary>Xodim faol yoki emas flagi.</summary>
    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    /// <summary>Yozuv yaratildi (UTC).</summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    // Navigation properties
    /// <summary>Tegishli foydalanuvchi.</summary>
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    /// <summary>Tegishli merchant.</summary>
    [ForeignKey(nameof(CompanyId))]
    public Company? Company { get; set; }

    /// <summary>Tegishli filial (agar mavjud bo'lsa).</summary>
    [ForeignKey(nameof(BranchId))]
    public Branch? Branch { get; set; }

    /// <summary>Ushbu xodim yaratgan product bundllar.</summary>
    public ICollection<ProductBundle> CreatedBundles { get; set; } = new List<ProductBundle>();

    /// <summary>Ushbu xodim biriktirilgan bundllar.</summary>
    public ICollection<BundleAssignee> AssignedBundles { get; set; } = new List<BundleAssignee>();

    /// <summary>Ushbu xodim skaner qilgan buyurtmalar.</summary>
    public ICollection<Order> ScannedOrders { get; set; } = new List<Order>();
}
