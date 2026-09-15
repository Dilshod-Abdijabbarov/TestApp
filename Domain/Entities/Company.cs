using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaveEat.Domain.Enums;

namespace SaveEat.Domain.Entities;

/// Ushbu klass kompaniya haqida yuridik va biznes ma'lumotlarni saqlaydi.
[Table("companies")]
public class Company
{
    ///  Kompaniyaning UUID identifikatori. 
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    ///  Brend nomi (jamoat ko'rsatish uchun). 
    [MaxLength(150)]
    [Column("brand_name")]
    public string BrandName { get; set; }

    ///  Yuridik nom (shartnoma maqsadlari uchun). 
    [MaxLength(255)]
    [Column("legal_name")]
    public string? LegalName { get; set; }

    ///  STIR / INN raqami. 
    [MaxLength(20)]
    [Column("tin_inn")]
    public string? TinInn { get; set; }

    ///  Bank hisobraqami (to'lovlar uchun). 
    [MaxLength(50)]
    [Column("bank_account")]
    public string? BankAccount { get; set; }

    ///  Bank MFO kodi. 
    [MaxLength(10)]
    [Column("mfo_bank_code")]
    public string? MfoBankCode { get; set; }

    ///  Asosiy toifa (bag category). 
    [Column("category")]
    public Category Category { get; set; }

    ///  Logo yoki brend rasmi URL. 
    [Column("logo_url")]
    public string? LogoUrl { get; set; }

    ///  Platforma komissiya foizi (decimal). 
    [Column("commission_rate")]
    public decimal CommissionRate { get; set; } = 0.10m;

    ///  Administrator tomonidan tasdiqlanganmi. 
    [Column("is_verified")]
    public bool IsVerified { get; set; } = false;

    ///  Hamkor faolmi (savdoga ruxsat). 
    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    ///  Yaratilgan vaqt (UTC). 
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    ///  Oxirgi tahrir vaqti (UTC). 
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    ///   Kompaniyani yaratgan user idsi. 
    [Column("created_by")]
    public Guid CreatedBy { get; set; }

    ///  Companiya hamyoni. 
    public CompanyWallet? Wallet { get; set; }

    // Navigation properties
    ///  Hamkor filiallar. 
    public ICollection<Branch> Branches { get; set; } = new List<Branch>();

    ///  Hamkor hisob-kitob reestri. 
    public ICollection<CompanyPayout> Payouts { get; set; } = new List<CompanyPayout>();

    ///  Hamkor tomonidan yaratilgan taklif havolalari. 
    public ICollection<EmployeeInvite> EmployeeInvites { get; set; } = new List<EmployeeInvite>();
}

