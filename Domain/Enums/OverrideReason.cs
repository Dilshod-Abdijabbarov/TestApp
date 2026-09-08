using System.ComponentModel.DataAnnotations;


namespace SaveEat.Domain.Enums;
public enum OverrideReason
{
    [Display(Name = "Rahbariyat ko'rsatmasi / Maxsus ruxsat")]
    ManagementApproval = 1,

    [Display(Name = "Doimiy/VIP mijoz uchun istisno holat")]
    VipClientException = 2,

    [Display(Name = "Xodimning xatosini to'g'rilash (Korreksiya)")]
    StaffErrorCorrection = 3,

    [Display(Name = "Aksiya yoki maxsus chegirma qo'llash")]
    SpecialPromotion = 4,

    [Display(Name = "Boshqa sabab")]
    SpecialCase = 99
}

