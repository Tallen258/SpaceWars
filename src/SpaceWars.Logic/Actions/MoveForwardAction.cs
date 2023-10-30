namespace SpaceWars.Logic.Actions;

public class MoveForwardAction : GamePlayAction
{
    private readonly int? newHeading;

    public MoveForwardAction(int? newHeading = null)
    {
        if (newHeading != null && (newHeading < 0 || newHeading >= 360))
        {
            throw new ArgumentException("Heading must be between 0 and 359");
        }

        this.newHeading = newHeading;
    }

    public override int Priority => 1;

    public override ActionResult Execute(Player player, GameMap _)
    {
        var ship = player.Ship;

        if (newHeading.HasValue)
        {
            ship.Heading = newHeading.Value;
        }

        //if speed is more than 1x call a different block of code to be more precise in the angles.

        ship.Location = ship.Heading switch
        {
            > 337 or <= 22 => new Location(ship.Location.X, ship.Location.Y + 1), //up
            > 22 and <= 67 => new Location(ship.Location.X + 1, ship.Location.Y + 1), //up right
            > 67 and <= 112 => new Location(ship.Location.X + 1, ship.Location.Y), //right
            > 112 and <= 157 => new Location(ship.Location.X + 1, ship.Location.Y - 1), //down right
            > 157 and <= 202 => new Location(ship.Location.X, ship.Location.Y - 1),//down
            > 202 and <= 247 => new Location(ship.Location.X - 1, ship.Location.Y - 1), //down left
            > 247 and <= 292 => new Location(ship.Location.X - 1, ship.Location.Y), //left
            > 292 and <= 337 => new Location(ship.Location.X - 1, ship.Location.Y + 1), //up left
        };

        return new ActionResult(true, "OK");
    }
}
