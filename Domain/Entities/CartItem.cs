using System.ComponentModel.DataAnnotations.Schema;
using SaveEat.Domain.Entities;

namespace Domain.Entities;

public class CartItem : BaseEntity
{
    [Column("cart_id")]
    public Guid CartId { get; set; }

    ///  Agar alohida mahsulot qo'shilsa. 
    [Column("product_id")]
    public Guid? ProductId { get; set; }

    ///  Agar Set qo'shilsa. 
    [Column("set_id")]
    public Guid? SetId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; } = 1;

    [ForeignKey(nameof(CartId))]
    public Cart? Cart { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product? Product { get; set; }

    [ForeignKey(nameof(SetId))]
    public Set? Set { get; set; }
}
