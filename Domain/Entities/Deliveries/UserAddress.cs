using Domain.Entities.Users;

namespace SaveEat.Domain.Entities.Deliveries;

/// <summary>
/// Foydalanuvchining saqlangan yetkazib berish manzillari.
/// Har bir foydalanuvchining bir nechta manzillari bo'lishi mumkin.
/// </summary>
[Table("user_addresses")]
public class UserAddress
{
    /// <summary>Manzil yozuvi UUID.</summary>
    [Key]
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>Manzil tegishli foydalanuvchisi (users.id).</summary>
    [Column("user_id")]
    public Guid UserId { get; set; }

    /// <summary>Manzil labeli (Uy, Ishxona, Ota-onasining uy, ...).</summary>
    [MaxLength(50)]
    [Column("label")]
    public string Label { get; set; } = "Manzil";

    /// <summary>To'liq manzil matni.</summary>
    [MaxLength(400)]
    [Column("address_text")]
    public string AddressText { get; set; } = string.Empty;

    /// <summary>Mo'ljal yoki joyni tavsifi (masalan: Uy raqami, kvartira raqami, rang ...).</summary>
    [MaxLength(255)]
    [Column("landmark")]
    public string? Landmark { get; set; }

    /// <summary>GPS kenglik (latitude).</summary>
    [Column("latitude")]
    public decimal Latitude { get; set; }

    /// <summary>GPS uzunlik (longitude).</summary>
    [Column("longitude")]
    public decimal Longitude { get; set; }

    /// <summary>Mayl (default address) flagi.</summary>
    [Column("is_default")]
    public bool IsDefault { get; set; } = false;

    /// <summary>Manzil faol yoki saqlangan.</summary>
    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    /// <summary>Manzil yaratilgan vaqt (UTC).</summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    /// <summary>Manzil oxirgi o'zgartirilgan vaqt (UTC).</summary>
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    // Navigation
    /// <summary>Tegishli foydalanuvchisi.</summary>
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;

    /// <summary>Bu manzilga yetkazib berilishi kerak bo'lgan buyurtmalar.</summary>
    public ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
}