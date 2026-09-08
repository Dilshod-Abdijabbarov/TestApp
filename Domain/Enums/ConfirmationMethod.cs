using System.ComponentModel.DataAnnotations;

namespace SaveEat.Domain.Enums;

public enum ConfirmationMethod
{
    // Telegram-bot orqali tasdiqlash
    [Display(Name = "Telegram bot")]
    Telegram = 1,

    // Telefonga yuborilgan yoki tizim ichidagi PIN-kod orqali tasdiqlash
    [Display(Name = "PIN-kod")]
    PinCode = 2,

    // Buyurtma ma'lum vaqt ichida tasdiqlanmagani uchun tizim tomonidan avtomat yopilishi
    [Display(Name = "Avtomatik timeout")]
    AutoTimeout = 3,

    // Agar operator panel orqali qo'lda tasdiqlasa (qo'shimcha variant)
    [Display(Name = "Operator tomonidan (Qo'lda)")]
    ManualByOperator = 4
}

