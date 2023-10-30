
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

    public IEnumerable<Player> GetPlayersInRange(Player player, int maxDistance)
    {
        var playerLocation = new Vector2(player.Ship.Location.X, player.Ship.Location.Y);

        foreach (var otherPlayer in players)
        {
            if (otherPlayer == player)
                continue;

            var otherLocation = new Vector2(otherPlayer.Ship.Location.X, otherPlayer.Ship.Location.Y);
            var distance = (int)Vector2.Distance(playerLocation, otherLocation);
            if (distance <= maxDistance)
                yield return otherPlayer;
        }

        //return from otherPlayer in players
        //       let otherPlayerLocation = new Vector2(otherPlayer.Ship.Location.X, otherPlayer.Ship.Location.Y)
        //       let distance = (int)Vector2.Distance(playerLocation, otherPlayerLocation)
        //       where distance <= maxDistance
        //       select otherPlayer;
    }

    //support for wrapping?

    //edges that do damage?  5 rows or something that take 10% damage every tick that you're there

}