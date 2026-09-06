using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveEat.Domain.Entities;

/// <summary>
/// Mijozlar tomonidan qoldirilgan sharhlar va baholar.
/// Har bir sharh buyurtma bilan bog'langan va filialga tegishli bo'ladi.
/// </summary>
[Table("reviews")]
public class Review
{
    /// <summary>Sharh UUID.</summary>
    [Key]
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>Qaysi buyurtma uchun qoldirilgan.</summary>
    [Column("order_id")]
    public Guid OrderId { get; set; }

    /// <summary>Sharhni yozgan foydalanuvchi (users.id).</summary>
    [Column("user_id")]
    public Guid UserId { get; set; }

    /// <summary>Filial identifikatori.</summary>
    [Column("branch_id")]
    public Guid BranchId { get; set; }

    /// <summary>Baho (1 dan 5 gacha).</summary>
    [Range(1, 5)]
    [Column("rating")]
    public int Rating { get; set; }

    /// <summary>Mijoz matnli fikri.</summary>
    [Column("comment")]
    public string? Comment { get; set; }

    /// <summary>Sharh anonim bo'lib qoldiriladimi.</summary>
    [Column("is_anonymous")]
    public bool IsAnonymous { get; set; } = false;

    /// <summary>Do'kon admini tomonidan berilgan rasmiy javob.</summary>
    [Column("reply_from_merchant")]
    public string? ReplyFromMerchant { get; set; }

    /// <summary>Javob berilgan vaqt (agar mavjud bo'lsa).</summary>
    [Column("replied_at")]
    public DateTime? RepliedAt { get; set; }

    /// <summary>Sharh yozilgan vaqt (UTC).</summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
