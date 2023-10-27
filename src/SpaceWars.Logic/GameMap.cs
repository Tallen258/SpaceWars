
using System.Numerics;

namespace SpaceWars.Logic;

public class GameMap
{
    public GameMap(IEnumerable<Player> players)
    {
        foreach (var p in players)
        {
            playerLocations.Add(p.Ship.Location, p);
        }

        this.players = players;
    }

    private Dictionary<Location, Player> playerLocations = new Dictionary<Location, Player>();
    private readonly IEnumerable<Player> players;

    public bool TryHit(Player player, out (Player hitPlayer, int distance)? result)
    {
        Vector2 pLocation = new Vector2(player.Ship.Location.X, player.Ship.Location.Y);
        Vector2 pHeading = new Vector2((float)Math.Cos(player.Ship.Heading), (float)Math.Sin(player.Ship.Heading));
        foreach (var otherPlayer in players)
        {
            var otherLocation = new Vector2(otherPlayer.Ship.Location.X, otherPlayer.Ship.Location.Y);
            var distance = (int)Vector2.Distance(pLocation, otherLocation);
        }

        result = null;
        return false;
    }
}