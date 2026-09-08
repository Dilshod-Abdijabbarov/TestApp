namespace SaveEat.Domain.Enums;

/// To'lov provayderlari — integratsiya va loglash uchun ishlatiladi. 
public enum PaymentProvider
{
    ///  Click to'lov tizimi. 
    Click = 0,

    ///  Payme to'lov tizimi. 
    Payme = 1,

    ///  Uzum yoki boshqa marketplace provayderi. 
    Uzum = 2,

    ///  Boshqa noma'lum
    Other = 99
}