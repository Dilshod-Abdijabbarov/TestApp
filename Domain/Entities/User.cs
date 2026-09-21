using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;
using SaveEat.Domain.Enums;

namespace SaveEat.Domain.Entities;
 
/// Tizim foydalanuvchisi — Telegram orqali autentifikatsiya qilingan mijoz yoki admin.
/// Ushbu klass foydalanuvchining shaxsiy ma'lumotlarini va holatini saqlaydi.
[Table("users")]
public class User : BaseEntity
{
    ///  Foydalanuvchining Telegram ID raqami (auth uchun). 
    [Column("telegram_id")]
    public long TelegramId { get; set; }

    ///  Telegram profilidagi ism. 
    [MaxLength(100)]
    [Column("first_name")]
    public string FirstName { get; set; } = string.Empty;

    ///  Telegram profilidagi familiya. 
    [MaxLength(100)]
    [Column("last_name")]
    public string? LastName { get; set; }

    ///  Telegram username (agar mavjud bo'lsa). 
    [MaxLength(100)]
    [Column("username")]
    public string? Username { get; set; }

    ///  Bog'lanish uchun telefon raqami. 
    [MaxLength(20)]
    [Column("phone_number")]
    public string? PhoneNumber { get; set; }

    ///  Tizimdagi global rol (Client, Admin, ...). 
    [Column("role")]
    public UserRole Role { get; set; } = UserRole.Client;

    ///  Foydalanuvchining reytingi (1.0 - 5.0). 
    [Column("rating")]
    public decimal Rating { get; set; } = 5.00m;

    ///  Foydalanuvchi bloklanganligi flagi. 
    [Column("is_blocked")]
    public bool IsBlocked { get; set; } = false;

    ///  Profil oxirgi yangilangan vaqt (UTC). 
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    // Navigation properties
    ///  Foydalanuvchi yaratgan buyurtmalar. 
    public ICollection<Order> Orders { get; set; } = new List<Order>();

    ///  Foydalanuvchi qoldirgan sharhlar. 
    public ICollection<BranchReview> Reviews { get; set; } = new List<BranchReview>();
}