using SpaceWars.Logic.Actions;

namespace SpaceWars.Logic;

public class Game
{
    private readonly Dictionary<PlayerToken, Player> players;

    public Game()
    {
        this.players = new();
    }

    public GameJoinResult Join(string playerName)
    {
        var newPlayer = new Player(playerName, new Ship(new Location(0, 0)));
        players.Add(newPlayer.Token, newPlayer);
        return new GameJoinResult(newPlayer.Token, newPlayer.Ship.Location);
    }

    public void Tick()
    {
        var playerActions = players.Values.Select(p => new PlayerAction(p, p.DequeueAction()))
            .Where(playerAction => playerAction.Action != null)
            .OrderBy(playerAction => playerAction.Action!.Priority);

        playerActions
            .Where(a => a.Action.Priority == 1)
            .ToList()
            .ForEach(a => a.Action.Execute(a.Player, Map));
        
        Map = new GameMap(players.Values);//initialize that here

        playerActions
            .Where(a => a.Action.Priority != 1)
            .ToList()
            .ForEach(a => a.Action.Execute(a.Player, Map));
    }

    public Player GetPlayerByToken(PlayerToken token) => players[token];
    public GameMap Map { get; private set; }
}

record PlayerAction(Player Player, GamePlayAction? Action);
public record GameJoinResult(PlayerToken Token, Location Location);