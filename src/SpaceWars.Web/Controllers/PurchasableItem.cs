

namespace SpaceWars.Logic
{
    public class PurchasableItem : IPurchasable
    {
        public int Cost { get; init; }
        public string Name { get; init; }
        public IEnumerable<string> PurchasePrerequisites { get; set; }
    }
}