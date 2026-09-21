using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;
using Domain.Enums;

namespace SaveEat.Domain.Entities;

/// Filelar 
[Table("file_models")]
public class FileModel : BaseEntity
{
    ///  File,Image,Video. 
    [Column("product_id")]
    public Guid ProductId { get; set; }

    ///  Slaydda ko'rsatish tartibi. 
    [Column("display_order")]
    public int DisplayOrder { get; set; } = 1;

    ///  Asosiy rasm flagi. 
    [Column("is_primary")]
    public bool IsPrimary { get; set; } = false;

    //yuklangan file turi
    [Column("file_type")]
    public FileType FileType { get; set; }

    // Navigation
    ///  Tegishli product. 
    [ForeignKey(nameof(ProductId))]
    public Product? Product { get; set; }
}