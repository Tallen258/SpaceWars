

namespace SpaceWars.Logic
{
    public class PurchaseableItem : IPurchaseable
    {
        public int Cost { get; init; }
        public string Name { get; init; }
        public IEnumerable<string> PurchasePrerequisites { get; set; }
    }
}