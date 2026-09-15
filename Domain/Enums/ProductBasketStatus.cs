namespace SaveEat.Domain.Enums;

/// sotuvga chiqarilgan productlar holati
public enum ProductSetStatus
{
    ///  Faol va sotuvda mavjud. 
    Active = 0,

    ///  Hammasi sotib bo'lingan. 
    SoldOut = 1,

    ///  Olib ketish muddati o'tgan (muddati tugagan). 
    Expired = 2,

    ///  Administrator yoki sotuvchi tomonidan bekor qilingan. 
    Cancelled = 3
}