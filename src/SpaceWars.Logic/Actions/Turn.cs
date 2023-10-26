namespace SpaceWars.Logic.Actions;

public class Turn : GamePlayAction
{
    public int NewHeading { get; set; }
    public override int Priority => 3;
    public override void Execute(Player player)
    {
        throw new NotImplementedException();
    }
}
