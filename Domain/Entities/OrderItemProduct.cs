

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class OrderItemProduct : BaseEntity
{
    ///  Qaysi OrderItem'ga tegishli (faqat SetId to'ldirilgan OrderItem'lar uchun). 
    [Column("order_item_id")]
    public Guid OrderItemId { get; set; }

    ///  Set ichidagi qaysi mahsulot. 
    [Column("product_id")]
    public Guid ProductId { get; set; }

    ///  Umumiy miqdor: SetItem.Quantity * OrderItem.Quantity. 
    [Column("quantity")]
    public int Quantity { get; set; }

    ///  Buyurtma vaqtidagi bir dona narxi (Set ichidagi ulush narxi). 
    [Column("unit_price_at_order")]
    public decimal UnitPriceAtOrder { get; set; }

    // Navigation properties
    [ForeignKey(nameof(OrderItemId))]
    public OrderItem? OrderItem { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product? Product { get; set; }
}
