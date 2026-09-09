using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;
using SaveEat.Domain.Enums;

namespace SaveEat.Domain.Entities;

/// Mahsulot to'plami — chegirmaga qo'yilgan mahsulot paketlari.
/// Narxi, miqdori, olinadigan oynasi va holati kabi biznes ma'lumotlarni saqlaydi.
[Table("product_bundles")]
public class Bundle
{
    ///  Bundle UUID identifikatori. 
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    ///  Qaysi filialga tegishli bundle. 
    [Column("branch_id")]
    public Guid BranchId { get; set; }

    ///  Bundle nomi (sarlavha). 
    [MaxLength(200)]
    [Column("title")]
    public string Title { get; set; } = string.Empty;

    ///  Asosiy muqova rasmi id. 
    [Column("cover_image_id")]
    public Guid? CoverImageId { get; set; }

    ///  Halol standartlariga mos kelishi flagi. 
    [Column("is_halal")]
    public bool IsHalal { get; set; } = true;

    ///  Teglar (masalan: Vegan, Gluten-free). 
    [MaxLength(255)]
    [Column("dietary_tags")]
    public string? DietaryTags { get; set; }

    ///  Asl umumiy narx. 
    [Column("original_price")]
    public decimal OriginalPrice { get; set; }

    ///  Chegirmali sotish narxi. 
    [Column("discount_price")]
    public decimal DiscountPrice { get; set; }

    ///  Chiqarilgan jami miqdor. 
    [Column("initial_quantity")]
    public int InitialQuantity { get; set; }

    ///  Hozirda mavjud bo'lgan miqdor. 
    [Column("available_quantity")]
    public int AvailableQuantity { get; set; }

    ///  Olib ketish boshlanish vaqti (UTC). 
    [Column("pickup_start")]
    public DateTime PickupStart { get; set; }

    ///  Olib ketish tugash vaqti (UTC). 
    [Column("pickup_end")]
    public DateTime PickupEnd { get; set; }

    ///  to'plam holati (ACTIVE, SOLD_OUT ...). 
    [Column("status")]
    public ProductBundleStatus Status { get; set; } = ProductBundleStatus.Active;

    ///  Mahsulotning aniq yaroqlilik muddati tugash sanasi (UTC). 
    [Column("expiration_date")]
    public DateTime? ExpirationDate { get; set; }

    ///  Bundleni kiritgan xodim (employees.id). 
    [Column("created_by_employee_id")]
    public Guid CreatedByEmployeeId { get; set; }

    ///  Optimistic concurrency versiyasi — raqobatni oldini olish uchun. 
    [ConcurrencyCheck]
    [Column("version")]
    public int Version { get; set; } = 0;

    ///  Yaratilgan vaqt (UTC). 
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    // Navigation properties
    ///  Tegishli filial. 
    [ForeignKey(nameof(BranchId))]
    public Branch? Branch { get; set; }

    ///  Bundleni yaratgan employee. 
    [ForeignKey(nameof(CreatedByEmployeeId))]
    public Employee? CreatedByEmployee { get; set; }

    public ICollection<BundleItem> BundleItems { get; set; } = new List<BundleItem>();
    ///  Bundl buyurtmalari. 
    public ICollection<Order> Orders { get; set; } = new List<Order>();

    ///  Bundl biriktirilgan xodimlar. 
    public ICollection<BundleAssignee> Assignees { get; set; } = new List<BundleAssignee>();

    ///  Bundle rasmlari. 
    public ICollection<FileModel> Images { get; set; } = new List<FileModel>();
}
