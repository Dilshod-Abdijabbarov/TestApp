using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaveEat.Domain.Enums;

namespace SaveEat.Domain.Entities;

/// <summary>
/// Tizim foydalanuvchisi — Telegram orqali autentifikatsiya qilingan mijoz yoki admin.
/// Ushbu klass foydalanuvchining shaxsiy ma'lumotlarini va holatini saqlaydi.
/// </summary>
[Table("users")]
public class User
{
    /// <summary>Ichki unikal identifikator (PK).</summary>
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    /// <summary>Foydalanuvchining Telegram ID raqami (auth uchun).</summary>
    [Column("telegram_id")]
    public long TelegramId { get; set; }

    /// <summary>Telegram profilidagi ism.</summary>
    [MaxLength(100)]
    [Column("first_name")]
    public string FirstName { get; set; } = string.Empty;

    /// <summary>Telegram profilidagi familiya.</summary>
    [MaxLength(100)]
    [Column("last_name")]
    public string? LastName { get; set; }

    /// <summary>Telegram username (agar mavjud bo'lsa).</summary>
    [MaxLength(100)]
    [Column("username")]
    public string? Username { get; set; }

    /// <summary>Bog'lanish uchun telefon raqami.</summary>
    [MaxLength(20)]
    [Column("phone_number")]
    public string? PhoneNumber { get; set; }

    /// <summary>Tizimdagi global rol (Client, Admin, ...).</summary>
    [Column("role")]
    public UserRole Role { get; set; } = UserRole.Client;

    /// <summary>Mijozning reytingi (1.0 - 5.0).</summary>
    [Column("rating")]
    public decimal Rating { get; set; } = 5.00m;

    /// <summary>Foydalanuvchi bloklanganligi flagi.</summary>
    [Column("is_blocked")]
    public bool IsBlocked { get; set; } = false;

    /// <summary>Ro'yxatdan o'tgan vaqt (UTC).</summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>Profil oxirgi yangilangam vaqt (UTC).</summary>
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

