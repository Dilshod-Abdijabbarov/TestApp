using System.ComponentModel.DataAnnotations.Schema;
using SaveEat.Domain.Entities;

namespace Domain.Entities;

public class Cart : BaseEntity
{
    [Column("user_id")]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}
