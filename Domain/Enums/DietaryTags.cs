
namespace Domain.Enums
{
    [Flags]
    public enum DietaryTags
    {
        /// <summary> Hech qanday parhez yoki diniy cheklovlar yo'q </summary>
        None = 0,

        /// <summary> Vegan (Tarkibida go'sht, sut, tuxum va asal kabi hayvoniy mahsulotlar umuman yo'q) </summary>
        Vegan = 1 << 0,          // 1

        /// <summary> Vegetarian (Go'sht mahsulotlari yo'q, lekin sut yoki tuxum bo'lishi mumkin) </summary>
        Vegetarian = 1 << 1,     // 2

        /// <summary> Glyutensiz (Tarkibida bug'doy, arpa va shunga o'xshash glyuten oqsili bor mahsulotlar yo'q) </summary>
        GlutenFree = 1 << 2,     // 4

        /// <summary> Sutsiz / Laktozasiz (Tarkibida sut va sut mahsulotlari yo'q) </summary>
        DairyFree = 1 << 3,      // 8

        /// <summary> Yong'oqsiz (Tarkibida yong'oq va uning turlari yo'q — allergiya xavfi borlar uchun) </summary>
        NutFree = 1 << 4,        // 16

        /// <summary> Halol (Islom shariati qonun-qoidalariga muvofiq tayyorlangan) </summary>
        Halal = 1 << 5,          // 32

        /// <summary> Kosher (Yahudiylik diniy qonun-qoidalariga (Kashrut) muvofiq tayyorlangan) </summary>
        Kosher = 1 << 6          // 64
    }
}
