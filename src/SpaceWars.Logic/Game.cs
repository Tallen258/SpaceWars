using SpaceWars.Logic.Actions;

namespace SpaceWars.Logic;

public class Game
{
    private readonly Dictionary<PlayerToken, Player> players;
    private readonly IInitialLocationProvider locationProvider;

    public Game(IInitialLocationProvider locationProvider)
    {
        this.players = new();
        this.locationProvider = locationProvider;
    }

    public GameJoinResult Join(string playerName)
    {
        var newPlayer = new Player(playerName, new Ship(locationProvider.GetNewInitialLocation()));
        players.Add(newPlayer.Token, newPlayer);
        return new GameJoinResult(newPlayer.Token, newPlayer.Ship.Location);
    }

    public void Tick()
    {
        var playerActions = players.Values.Select(p => new PlayerAction(p, p.DequeueAction()))
            .Where(playerAction => playerAction.Action != null)
            .OrderBy(playerAction => playerAction.Action!.Priority)
            .ToList();

        GameMap map = null;

        foreach (var playerAction in playerActions)
        {
            bool allMovesAreComplete = playerAction.Action.Priority is not 1;
            if (allMovesAreComplete && map is null)
            {
                map = new GameMap(players.Values);//initialize that here
            }

            playerAction.Action.Execute(playerAction.Player, map);
        }
    }

    public Player GetPlayerByToken(PlayerToken token) => players[token];

    public void EnqueueAction(PlayerToken token, GamePlayAction action) => players[token].EnqueueAction(action);
}

record PlayerAction(Player Player, GamePlayAction? Action);
public record GameJoinResult(PlayerToken Token, Location Location);