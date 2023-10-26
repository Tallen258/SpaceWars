namespace SpaceWars.Logic.Actions;

public class Fire : GamePlayAction
{
    public Weapon Weapon { get; set; }
    public override int Priority => 2;
    public override void Execute(Player player)
    {
        throw new NotImplementedException();
    }
}
