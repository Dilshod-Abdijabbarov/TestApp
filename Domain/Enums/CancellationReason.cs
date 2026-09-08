using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum CancellationReason
{
    // Mijoz tomonidan bekor qilinishi
    [Display(Name = "Mijoz fikridan qaytdi")]
    ClientChangedMind = 1,

    [Display(Name = "Mijoz kelishdan bosh tortdi / kelmadi")]
    ClientNoShow = 2,

    [Display(Name = "Xato/adashib buyurtma berilgan")]
    OrderedByMistake = 3,

    [Display(Name = "Narx to'g'ri kelmadi / qimmatlik qildi")]
    PriceTooHigh = 4,

    // Tizim, operator yoki muassasa tomonidan bekor qilinishi
    [Display(Name = "Xizmat ko'rsatish imkoniyati yo'q (Resurs yetishmaydi)")]
    ServiceUnavailable = 10,

    [Display(Name = "Mijoz bilan bog'lanib bo'lmadi (Tasdiqlanmadi)")]
    ClientUnreachable = 11,

    [Display(Name = "To'lov muddati o'tib ketdi (Avto-bekor qilish)")]
    PaymentTimeout = 12,

    [Display(Name = "Tizimdagi texnik xatolik tufayli")]
    SystemError = 13,

    // Boshqa sabablar
    [Display(Name = "Boshqa sabab (Izoh qoldiriladi)")]
    Other = 99
}

