namespace SpaceWars.Logic.Actions;

public class PurchaseAction : GamePlayAction
{
    public override string Name => "Purchase";

    public override int Priority => 3;

    public IPurchaseable ItemToPurchase { get; init; }

    public PurchaseAction(IPurchaseable itemToPurchase)
    {
        ItemToPurchase = itemToPurchase;
    }

    public override Result Execute(Player player, GameMap map)
    {
        // check if player has enough money
        // check if item is in shop 
        if (map.CurrentShop != null && !map.CurrentShop.Any(i => i.Name == ItemToPurchase.Name))
        {   
            player.EnqueueMessage(new PlayerMessage(PlayerMessageType.FailedPurchase, $"{ItemToPurchase.Name} is not in shop"));
            return new Result(false, $"{ItemToPurchase.Name} is not in shop");
        }

        var targetItem = map.CurrentShop?.First(i => i.Name == ItemToPurchase.Name);

        if (targetItem != null && targetItem?.Cost <= player.Ship.UpgradeCreditBalance)
        {
            player.EnqueueMessage(new PlayerMessage(PlayerMessageType.FailedPurchase, $"Not enough credit to purchase item {targetItem.Name}"));
            return new Result(false, $"Not enough credit to purchase item {targetItem.Name}");
        }

        // check if player has prerequisites
        if (targetItem.PurchasePrerequisites.Any())
        {
            foreach (var item in targetItem.PurchasePrerequisites)
            {
                if (!player.Ship.Weapons.Any(i => i.Name == item))
                {
                    player.EnqueueMessage(new PlayerMessage(PlayerMessageType.FailedPurchase, "Player does not have prerequisites"));
                    return new Result(false, "Player does not have prerequisites");
                }
            }
        }

        // buy item and put into the inventory
        player.Ship.UpgradeCreditBalance -= targetItem.Cost;
        if (targetItem is Weapon)
        { 
            player.Ship.Weapons.Add((Weapon)targetItem);
            return new Result(true, $"{targetItem.Name}purchased");
        }
        // add to inventory later

        return new Result(false, "Something happened");
    }
}
