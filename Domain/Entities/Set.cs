using Domain.Entities;
using Domain.Enums;
using SaveEat.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveEat.Domain.Entities;

/// Mahsulot to'plami — chegirmaga qo'yilgan mahsulot paketlari.
/// Narxi, miqdori, olinadigan oynasi va holati kabi biznes ma'lumotlarni saqlaydi.
[Table("sets")]
public class Set
{
    ///  Set UUID identifikatori. 
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    ///  filialga tegishli Set. 
    [Column("branch_id")]
    public Guid BranchId { get; set; }

    ///  Set nomi (sarlavha). 
    [MaxLength(200)]
    [Column("title")]
    public string Title { get; set; } = string.Empty;

    ///  Asosiy muqova rasmi id. 
    [Column("cover_image_id")]
    public Guid? CoverImageId { get; set; }

    ///  Teglar (masalan: Vegan, Gluten-free). 
    [Column("dietary_tags")]
    public DietaryTags DietaryTags { get; set; } = DietaryTags.None;

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
    public ProductSetStatus Status { get; set; } = ProductSetStatus.Active;

    ///  Mahsulotning aniq yaroqlilik muddati tugash sanasi (UTC). 
    [Column("expiration_date")]
    public DateTime? ExpirationDate { get; set; }

    ///  Setni kiritgan xodim (employees.id). 
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

    ///  Setni yaratgan employee. 
    [ForeignKey(nameof(CreatedByEmployeeId))]
    public Employee? CreatedByEmployee { get; set; }

    public ICollection<SetItem> SetItems { get; set; } = new List<SetItem>();
    ///  Set buyurtmalari. 
    public ICollection<Order> Orders { get; set; } = new List<Order>();

    ///  Set biriktirilgan xodimlar. 
    public ICollection<SetAssignee> Assignees { get; set; } = new List<SetAssignee>();

    ///  Set rasmlari. 
    public ICollection<FileModel> Images { get; set; } = new List<FileModel>();

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
