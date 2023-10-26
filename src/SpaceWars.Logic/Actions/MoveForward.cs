namespace SpaceWars.Logic.Actions;

public class MoveForward : GamePlayAction
{
    public override int Priority => 1;
    public override void Execute(Player player)
    {
        var ship = player.Ship;
        ship.Location = ship.Heading switch
        {
            > 315 or <= 45 => new Location(ship.Location.X, ship.Location.Y + 1),
            > 45 and <= 135 => new Location(ship.Location.X + 1, ship.Location.Y),
            > 135 and <= 225 => new Location(ship.Location.X, ship.Location.Y - 1),
            _ => new Location(ship.Location.X - 1, ship.Location.Y),
        };
    }
}
