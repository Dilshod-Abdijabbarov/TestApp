using SaveEat.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("order_items")]
    public class OrderItem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("order_id")]
        public Guid OrderId { get; set; }

        [Column("set_id")]
        public Guid SetId { get; set; }

        public int Quantity { get; set; } // Ushbu setdan nechta buyurtma qilingani
        public decimal PriceAtPurchase { get; set; } // Buyurtma berilgan vaqtdagi narx


        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        [ForeignKey(nameof(SetId))]
        public Set Set { get; set; } = null!;
    }
}
