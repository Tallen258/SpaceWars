namespace SpaceWars.Logic.Actions;

public class Repair : GamePlayAction
{
    public int Amount { get; set; }
    public override int Priority => 3;
    public override void Execute(Player player)
    {
        throw new NotImplementedException();
    }
}
