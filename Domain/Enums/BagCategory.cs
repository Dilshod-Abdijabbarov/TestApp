namespace SaveEat.Domain.Enums;

/// <summary>
/// Savat (surprise bag) toifalari — mahsulotlarni guruhlash uchun ishlatiladi.
/// Toifalar UI filterlari va statistikalar uchun qo'llanadi.
/// </summary>
public enum BagCategory
{
    /// <summary>Oziq-ovqat mahsulotlari.</summary>
    Food = 0,

    /// <summary>Do'kon tarkibidagi umumiy tovarlar (grocery).</summary>
    Grocery = 1,

    /// <summary>Non mahsulotlari va pishiriqlar.</summary>
    Bakery = 2,

    /// <summary>Ichimliklar (suyuqliklar, gazlangan va boshqalar).</summary>
    Drinks = 3,

    /// <summary>Boshqa yoki aniqlanmagan tur.</summary>
    Other = 4
}