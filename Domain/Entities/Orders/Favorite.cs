using Domain.Entities.Products;
using Domain.Entities.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Orders;

[Table("favorites")]
public class Favorite : BaseEntity
{
    [Column("user_id")]
    public Guid UserId { get; set; }

    ///  Agar alohida mahsulot yoqtirilsa. 
    [Column("product_id")]
    public Guid ProductId { get; set; }

    ///  Agar Set yoqtirilsa. 
    [Column("set_id")]
    public Guid SetId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; }

    [ForeignKey(nameof(SetId))]
    public Set Set { get; set; }
}
