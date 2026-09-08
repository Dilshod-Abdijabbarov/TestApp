using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaveEat.Domain.Entities;
using SaveEat.Domain.Enums;

namespace Domain.Entities;

[Table("products")]
public class Product
{
    /// <summary>product UUID identifikatori.</summary>
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    /// <summary>Qaysi filialga tegishli product.</summary>
    [Column("branch_id")]
    public Guid BranchId { get; set; }

    /// <summary>product nomi (sarlavha).</summary>
    [MaxLength(200)]
    [Column("title")]
    public string Title { get; set; }

    /// <summary>product toifasi (BagCategory).</summary>
    [Column("category")]
    public BagCategory Category { get; set; }

    /// <summary>Mahsulotning aniq yaroqlilik muddati tugash sanasi (UTC).</summary>
    [Column("expiration_date")]
    public DateTime ExpirationDate { get; set; }

    /// <summary>Tavsif va allergenlar haqida matn.</summary>
    [Column("description")]
    public string? Description { get; set; }

    /// <summary>Asosiy muqova rasmi URL.</summary>
    [Column("cover_image_url")]
    public string? CoverImageUrl { get; set; }

    /// <summary>Halol standartlariga mos kelishi flagi.</summary>
    [Column("is_halal")]
    public bool IsHalal { get; set; } = true;

    /// <summary>Teglar (masalan: Vegan, Gluten-free).</summary>
    [MaxLength(255)]
    [Column("dietary_tags")]
    public string? DietaryTags { get; set; }

    /// <summary>Asl umumiy narx.</summary>
    [Column("original_price")]
    public decimal OriginalPrice { get; set; }

    /// <summary>Chegirmali sotish narxi.</summary>
    [Column("discount_price")]
    public decimal DiscountPrice { get; set; }

    /// <summary>Chiqarilgan jami miqdor.</summary>
    [Column("initial_quantity")]
    public int InitialQuantity { get; set; }

    /// <summary>Hozirda mavjud bo'lgan miqdor.</summary>
    [Column("available_quantity")]
    public int AvailableQuantity { get; set; }

    /// <summary>product kiritgan xodim (employees.id).</summary>
    [Column("created_by_user_id")]
    public Guid CreatedByUserId { get; set; }

    /// <summary>Yaratilgan vaqt (UTC).</summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    // Navigation properties
    /// <summary>Tegishli filial.</summary>
    [ForeignKey(nameof(BranchId))]
    public Branch? Branch { get; set; }

    /// <summary>Bundleni yaratgan employee.</summary>
    [ForeignKey(nameof(CreatedByUserId))]
    public Employee? CreatedByEmployee { get; set; }

    /// <summary>Bundle rasmlari.</summary>
    public ICollection<ProductBundleImage> Images { get; set; } = new List<ProductBundleImage>();
}

