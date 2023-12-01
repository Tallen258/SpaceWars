namespace SpaceWars.Logic.Actions;

public class RepairAction : GamePlayAction
{
    public int Amount { get; set; }
    public override int Priority => 3;
    public override Result Execute(Player player, GameMap _)
    {
        throw new NotImplementedException();
    }
}
