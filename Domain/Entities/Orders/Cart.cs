using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Users;

namespace Domain.Entities.Orders;

public class Cart : BaseEntity
{
    [Column("user_id")]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }

    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}
