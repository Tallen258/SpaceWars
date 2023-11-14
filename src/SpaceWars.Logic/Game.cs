using SpaceWars.Logic.Actions;

namespace SpaceWars.Logic;

public class Game
{
    private readonly Dictionary<PlayerToken, Player> players;
    private readonly IInitialLocationProvider locationProvider;
    public GameState State { get; set; } = new();

    public Game(IInitialLocationProvider locationProvider)
    {
        this.players = new();
        this.locationProvider = locationProvider;
    }
    
    public void Start(string password)
    {
        if (password != "password")
        {
            
        }
        else
        {
            State.State = "Joining";
        }
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

        foreach (var gamePlayAction in playerActions.Where(a => a.Action.Priority == 1))
        {
            gamePlayAction.Action.Execute(gamePlayAction.Player, Map);
        }

        Map = new GameMap(players.Values);//initialize that here

        foreach (var gamePlayAction in playerActions.Where(a => a.Action.Priority != 1))
        {
            gamePlayAction.Action.Execute(gamePlayAction.Player, Map);
        }
    }

    public Player GetPlayerByToken(PlayerToken token) => players[token];
    public GameMap Map { get; private set; }
    public void EnqueueAction(PlayerToken token, GamePlayAction action) => players[token].EnqueueAction(action);
}

record PlayerAction(Player Player, GamePlayAction? Action);
public record GameJoinResult(PlayerToken Token, Location Location);