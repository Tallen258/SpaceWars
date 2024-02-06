namespace SpaceWars.Logic;

public interface IPurchasable
{
    int PurchaseCost { get; init; }
    int MaxDamage { get; init; }
    IEnumerable<WeaponRange> Ranges { get; init; }
    string Name { get; }
    string Description { get; }
}
