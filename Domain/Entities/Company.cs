using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaveEat.Domain.Enums;

namespace SaveEat.Domain.Entities;

/// <summary>
/// Ushbu klass kompaniya haqida yuridik va biznes ma'lumotlarni saqlaydi.
/// </summary>
[Table("companies")]
public class Company
{
    /// <summary>Kompaniyaning UUID identifikatori.</summary>
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    /// <summary>Brend nomi (jamoat ko'rsatish uchun).</summary>
    [MaxLength(150)]
    [Column("brand_name")]
    public string BrandName { get; set; }

    /// <summary>Yuridik nom (shartnoma maqsadlari uchun).</summary>
    [MaxLength(255)]
    [Column("legal_name")]
    public string? LegalName { get; set; }

    /// <summary>STIR / INN raqami.</summary>
    [MaxLength(20)]
    [Column("tin_inn")]
    public string? TinInn { get; set; }

    /// <summary>Bank hisobraqami (to'lovlar uchun).</summary>
    [MaxLength(50)]
    [Column("bank_account")]
    public string? BankAccount { get; set; }

    /// <summary>Bank MFO kodi.</summary>
    [MaxLength(10)]
    [Column("mfo_bank_code")]
    public string? MfoBankCode { get; set; }

    /// <summary>Asosiy toifa (bag category).</summary>
    [Column("category")]
    public BagCategory Category { get; set; }

    /// <summary>Logo yoki brend rasmi URL.</summary>
    [Column("logo_url")]
    public string? LogoUrl { get; set; }

    /// <summary>Platforma komissiya foizi (decimal).</summary>
    [Column("commission_rate")]
    public decimal CommissionRate { get; set; } = 0.10m;

    /// <summary>Administrator tomonidan tasdiqlanganmi.</summary>
    [Column("is_verified")]
    public bool IsVerified { get; set; } = false;

    /// <summary>Hamkor faolmi (savdoga ruxsat).</summary>
    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    /// <summary>Yaratilgan vaqt (UTC).</summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    /// <summary>Oxirgi tahrir vaqti (UTC).</summary>
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    /// <summary> Kompaniyani yaratgan user idsi.</summary>
    [Column("created_by")]
    public Guid CreatedBy { get; set; }

    /// <summary>Hamkor hamyoni.</summary>
    public MerchantWallet? Wallet { get; set; }

    // Navigation properties
    /// <summary>Hamkor filiallar.</summary>
    public ICollection<Branch> Branches { get; set; } = new List<Branch>();

    /// <summary> xodimlar.</summary>
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();

    /// <summary>Hamkor hisob-kitob reestri.</summary>
    public ICollection<MerchantPayout> Payouts { get; set; } = new List<MerchantPayout>();

    /// <summary>Hamkor tomonidan yaratilgan taklif havolalari.</summary>
    public ICollection<EmployeeInvite> EmployeeInvites { get; set; } = new List<EmployeeInvite>();

    /// <summary>
    /// Sotib bo'lmagan tovarlarni tekshirish uchun oson yo'l — barcha faol filiallar
    /// bo'yicha muddati yaqinlashgan lotlarni yig'ish
    /// </summary>
    public IEnumerable<ProductBundle> GetAllActiveListings()
        => Branches.SelectMany(b => b.ProductBundles).Where(pb => pb.Status == BagStatus.Active);
}

