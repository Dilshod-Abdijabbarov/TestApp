namespace SaveEat.Domain.Enums;

/// Buyurtma holatlari — to'lovdan tortib yetkazib berishgacha bo'lgan jarayonni ifodalaydi.
public enum OrderStatus
{
    ///  To'lov kutilyapti (mijoz hali to'lamagan). 
    PendingPayment = 0,

    ///  To'lov amalga oshirilgan. 
    Paid = 1,

    ///  Buyurtma qayta ishlanmoqda (tayyorlash bosqichi). 
    Processing = 2,

    ///  Olib ketish uchun tayyor. 
    ReadyForPickup = 3,

    ///  Mijoz buyurtmani olib ketgan va jarayon yakunlangan. 
    Completed = 4,

    ///  Buyurtma bekor qilingan. 
    Cancelled = 5,

    ///  Buyurtma summasi qaytarilgan (refund qilingan). 
    Refunded = 6
}