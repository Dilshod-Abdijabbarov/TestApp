using SaveEat.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("bundle_items")]
    public class BundleItem
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("bundle_id")]
        public Guid BundleId { get; set; }

        [Column("product_id")]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Shu to'plam ichidagi ushbu mahsulot miqdori (masalan: 2 dona, 1 dona).
        /// </summary>
        [Column("quantity")]
        public int Quantity { get; set; } = 1;

        ///  Asl umumiy narx. 
        [Column("original_price")]
        public decimal OriginalPrice { get; set; }

        ///  Chegirmali sotish narxi. 
        [Column("discount_price")]
        public decimal DiscountPrice { get; set; }

        // Navigation properties
        [ForeignKey(nameof(BundleId))]
        public Bundle? Bundle { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }

    }
}
