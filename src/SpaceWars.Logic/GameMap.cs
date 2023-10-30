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

    //support for wrapping?

    //edges that do damage?  5 rows or something that take 10% damage every tick that you're there

}