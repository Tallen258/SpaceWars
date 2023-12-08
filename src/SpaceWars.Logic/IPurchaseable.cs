namespace SpaceWars.Logic;

public interface IPurchaseable
{
    int Cost { get; init; }
    string Name { get; }
    IEnumerable<string> PurchasePrerequisites { get; set; }
}
