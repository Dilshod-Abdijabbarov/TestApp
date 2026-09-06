namespace SaveEat.Domain.Enums;

/// <summary>
/// Do'kon ichidagi xodim rollari — filial va platforma darajasidagi ruxsatlar.
/// </summary>
public enum MerchantUserRole
{
    /// <summary>Do'kon egasi — to'liq huquqlar.</summary>
    Owner = 0,

    /// <summary>Menejer — filialni boshqarish, xodimlarni boshqarish.</summary>
    Manager = 1,

    /// <summary>Kassir — savdo operatsiyalarini bajaruvchi.</summary>
    Cashier = 2
}