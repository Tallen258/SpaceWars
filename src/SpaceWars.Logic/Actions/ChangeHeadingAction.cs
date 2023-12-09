namespace SpaceWars.Logic.Actions;

public class ChangeHeadingAction : GamePlayAction
{
    private int newHeading { get; set; }
    public override string Name => "Change Heading";
    public override int Priority => 1;

    public ChangeHeadingAction(int newHeading)
    {
        this.newHeading = newHeading;
    }

    public int NewHeading
    {
        get => newHeading;
        set
        {
            newHeading = value; // Heading should be checked by the ship

        }
    }
    public override Result Execute(Player player, GameMap _)
    {
        player.Ship.Heading = NewHeading;
        return new Result(true, $"Heading Successfully Updated to {newHeading}");
    }
}
