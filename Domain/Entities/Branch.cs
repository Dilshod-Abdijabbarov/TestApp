using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveEat.Domain.Entities;

/// companiya filial (branch) ma'lumotlari: manzil, telefon, GPS va reytinglar.
/// Har bir filial o'z pickup punktiga ega bo'ladi.
[Table("branches")]
public class Branch
{
    ///  Filial UUID identifikatori. 
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    ///  Qaysi kompaniyaga tegishli ekanligi. 
    [Column("company_id")]
    public Guid CompanyId { get; set; }

    ///  Filial nomi. 
    [MaxLength(200)]
    [Column("name")]
    public string Name { get; set; }

    ///  To'liq manzil matni. 
    [Column("address_text")]
    public string AddressText { get; set; }

    ///  Mo'ljal yoki landmark. 
    [MaxLength(255)]
    [Column("landmark")]
    public string? Landmark { get; set; }

    ///  GPS kenglik (latitude). 
    [Column("latitude")]
    public decimal Latitude { get; set; }

    ///  GPS uzunlik (longitude). 
    [Column("longitude")]
    public decimal Longitude { get; set; }

    ///  Filial telefon raqami. 
    [MaxLength(20)]
    [Column("phone_number")]
    public string PhoneNumber { get; set; } = string.Empty;

    ///  Filial reytingi (1-5). 
    [Column("rating")]
    public decimal Rating { get; set; } = 5.00m;

    ///  Filialga qoldirilgan umumiy sharhlar soni. 
    [Column("total_reviews_count")]
    public int TotalReviewsCount { get; set; } = 0;

    ///  Filial faol yoki yo'qligi. 
    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    ///  Qo'shilgan vaqt (UTC). 
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    ///   filial yaratgan user idsi. 
    [Column("created_by")]
    public Guid CreatedBy { get; set; }

    // Navigation properties
    ///  Tegishli merchant. 
    [ForeignKey(nameof(CompanyId))]
    public Company? Company { get; set; }

    ///  Filialga tegishli buyurtmalar. 
    public ICollection<Order> Orders { get; set; } = new List<Order>();

    ///  Filial xodimlar. 
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();

    ///  Filialga qoldirilgan sharhlar. 
    public ICollection<BranchReview> Reviews { get; set; } = new List<BranchReview>();

    ///  Filialning mahsulot to'plami. 
    public ICollection<Set> Sets { get; set; } = new List<Set>();
}
