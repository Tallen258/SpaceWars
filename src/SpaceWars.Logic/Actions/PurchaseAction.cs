namespace SpaceWars.Logic.Actions;

public class PurchaseAction : GamePlayAction
{
    public override string Name => "Purchase";

    public override int Priority => 3;

    public string ItemToPurchase { get; init; }

    public PurchaseAction(string itemToPurchase)
    {
        ItemToPurchase = itemToPurchase;
    }

    public override Result Execute(Player player, GameMap map)
    {
        // check if player has enough money
        // check if item is in shop
        if (map.CurrentShop != null && !map.CurrentShop.Any(i => i.Name == ItemToPurchase))
        {
            player.EnqueueMessage(new PlayerMessage(PlayerMessageType.FailedPurchase, $"{ItemToPurchase} is not in shop"));
            return new Result(false, $"{ItemToPurchase} is not in shop");
        }

        var targetItem = map.CurrentShop?.First(i => i.Name == ItemToPurchase);

        if (targetItem != null && targetItem?.PurchaseCost >= player.Ship.UpgradeCreditBalance)
        {
            player.EnqueueMessage(new PlayerMessage(PlayerMessageType.FailedPurchase, $"Not enough credit to purchase item {targetItem.Name}"));
            return new Result(false, $"Not enough credit to purchase item {targetItem.Name}");
        }

        // buy item and put into the inventory

        if (targetItem != null)
        {
            player.Ship.UpgradeCreditBalance -= targetItem.PurchaseCost;
            if (targetItem is Weapon)
            {
                player.Ship.Weapons.Add((Weapon)targetItem);
                return new Result(true, $"{targetItem.Name} purchased");
            }
        }
        // add to inventory later

        return new Result(false, "Something happened");
    }
}
