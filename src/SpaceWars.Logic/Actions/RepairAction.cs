namespace SpaceWars.Logic.Actions;

public class RepairAction : GamePlayAction
{
    public int Amount { get; set; }
    public override string Name => "Repair";
    public override int Priority => 3;
    public override Result Execute(Player player, GameMap _)
    {
        var repairAmount = Math.Min(player.Ship.UpgradeCreditBalance, 50);
        player.Ship.RepairDamage(repairAmount);
        player.Ship.UpgradeCreditBalance -= repairAmount;
        player.EnqueueMessage(new PlayerMessage(PlayerMessageType.SuccessfulRepair, $"Ship repaired. Health: {player.Ship.Health}; Shield: {player.Ship.Shield}"));
        return new Result(true, "Upgraded successfully.");
    }
}
