using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaveEat.Domain.Entities;
using SaveEat.Domain.Enums;

namespace Domain.Entities;

[Table("products")]
public class Product
{
    ///  product UUID identifikatori. 
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    ///  Qaysi filialga tegishli product. 
    [Column("branch_id")]
    public Guid BranchId { get; set; }

    ///  product nomi (sarlavha). 
    [MaxLength(200)]
    [Column("title")]
    public string Title { get; set; }

    ///  product toifasi (BagCategory). 
    [Column("category")]
    public Category Category { get; set; }

    ///  Mahsulotning aniq yaroqlilik muddati tugash sanasi (UTC). 
    [Column("expiration_date")]
    public DateTime ExpirationDate { get; set; }

    ///  Tavsif va allergenlar haqida matn. 
    [Column("description")]
    public string? Description { get; set; }

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

    ///  Chiqarilgan jami miqdor. 
    [Column("initial_quantity")]
    public int InitialQuantity { get; set; }

    ///  Hozirda mavjud bo'lgan miqdor. 
    [Column("available_quantity")]
    public int AvailableQuantity { get; set; }

    ///  product kiritgan xodim (employees.id). 
    [Column("created_by_user_id")]
    public Guid CreatedByUserId { get; set; }

    ///  Yaratilgan vaqt (UTC). 
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    // Navigation properties
    ///  Tegishli filial. 
    [ForeignKey(nameof(BranchId))]
    public Branch? Branch { get; set; }

    ///  Bundleni yaratgan employee. 
    [ForeignKey(nameof(CreatedByUserId))]
    public Employee? CreatedByEmployee { get; set; }

    ///  rasmlari,Videolar,filellar. 
    public ICollection<FileModel> FileModels { get; set; } = new List<FileModel>();
}

