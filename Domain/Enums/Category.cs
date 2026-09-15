namespace SaveEat.Domain.Enums;

/// product toifalari — mahsulotlarni guruhlash uchun ishlatiladi.
/// Toifalar UI filterlari va statistikalar uchun qo'llanadi.
public enum Category
{
    ///  Oziq-ovqat mahsulotlari. 
    Food = 0,

    ///  Do'kon tarkibidagi umumiy tovarlar (grocery). 
    Grocery = 1,

    ///  Non mahsulotlari va pishiriqlar. 
    Bakery = 2,

    ///  Ichimliklar (suyuqliklar, gazlangan va boshqalar). 
    Drinks = 3,

    ///  Boshqa yoki aniqlanmagan tur. 
    Other = 4
}