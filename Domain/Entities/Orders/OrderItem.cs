using Domain.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Orders
{
    [Table("order_items")]
    public class OrderItem : BaseEntity
    {
        [Column("order_id")]
        public Guid OrderId { get; set; }

        [Column("product_id")]
        public Guid ProductId { get; set; }

        [Column("set_id")]
        public Guid SetId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; } // Ushbu set yoki product dan nechta buyurtma qilingani

        [Column("price_at_purchase")]
        public decimal PriceAtPurchase { get; set; } // Buyurtma berilgan vaqtdagi narx


        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        [ForeignKey(nameof(SetId))]
        public Set Set { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        public ICollection<OrderItemProduct> OrderItemProducts { get; set; } = new List<OrderItemProduct>();
    }
}
