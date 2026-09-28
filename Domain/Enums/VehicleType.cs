
namespace SaveEat.Domain.Enums;

/// <summary>
/// Kuryerning yetkazib berish vositalari turi.
/// </summary>
public enum VehicleType
{
    /// <summary>Piyoda (ko'z orqali).</summary>
    [Display(Name = "Piyoda")]
    OnFoot = 0,

    /// <summary>Velosiped.</summary>
    [Display(Name = "Velosiped")]
    Bicycle = 1,

    /// <summary>Motocikl.</summary>
    [Display(Name = "Motocikl")]
    Motorcycle = 2,

    /// <summary>Avtomobil.</summary>
    [Display(Name = "Avtomobil")]
    Car = 3,

    /// <summary>Boshqa.</summary>
    [Display(Name = "Boshqa")]
    Other = 99
}