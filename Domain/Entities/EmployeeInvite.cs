using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaveEat.Domain.Enums;

namespace SaveEat.Domain.Entities;

/// Employee uchun taklif havolalari (invites) — deep-link token orqali yangi xodimlarni taklif qilish.
/// Havola muddati, ishlatilganligi va rol ma'lumotlarini saqlaydi.
[Table("employee_invites")]
public class EmployeeInvite
{
    ///  Taklif yozuvi UUID. 
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    ///  Qaysi Kompaniya taklif qiladi. 
    [Column("company_id")]
    public Guid CompanyId { get; set; }

    ///  Agar kerak bo'lsa, filialga bog'lash. 
    [Column("branch_id")]
    public Guid? BranchId { get; set; }

    ///  Taklif qilingan roli. 
    [Column("role")]
    public CompanyUserRole Role { get; set; } = CompanyUserRole.Ofitsiant;

    ///  Deep-link tokeni. 
    [MaxLength(64)]
    [Column("token")]
    public string Token { get; set; } = string.Empty;

    ///  Taklifni kim yaratdi (users.id). 
    [Column("created_by_user_id")]
    public Guid CreatedByUserId { get; set; }

    ///  Havolaning amal qilish muddati (UTC). 
    [Column("expires_at")]
    public DateTime ExpiresAt { get; set; }

    ///  Havolani kim ishlatdi (agar ishlatilgan bo'lsa). 
    [Column("used_by_user_id")]
    public Guid? UsedByUserId { get; set; }

    ///  Yaratilgan vaqt (UTC). 
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    // Navigation properties
    ///  Taklif qilgan Companiya. 
    [ForeignKey(nameof(CompanyId))]
    public Company? Company { get; set; }

    ///  Taklif qilgan filial (agar mavjud bo'lsa). 
    [ForeignKey(nameof(BranchId))]
    public Branch? Branch { get; set; }

    ///  Taklifni yaratgan user. 
    [ForeignKey(nameof(CreatedByUserId))]
    public User? CreatedByUser { get; set; }

    ///  Taklifni ishlatgan user (agar ishlatilgan bo'lsa). 
    [ForeignKey(nameof(UsedByUserId))]
    public User? UsedByUser { get; set; }
}

