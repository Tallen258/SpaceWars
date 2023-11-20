using SpaceWars.Logic.Actions;

namespace SpaceWars.Logic;

public class Game
{
    private readonly Dictionary<PlayerToken, Player> players;
    private readonly IInitialLocationProvider locationProvider;
    public GameState State { get; set; } = new();

    public Game(IInitialLocationProvider locationProvider, int boardWidth = 2000, int boardHeight = 2000)
    {
        this.players = new();
        this.locationProvider = locationProvider;
        BoardWidth = boardWidth;
        BoardHeight = boardHeight;
        state = GameState.Joining;
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

    public void Start()
    {
        if (State != GameState.Joining)
        {
            throw new InvalidGameStateException();
        }

        state = GameState.Playing;
    }

    private GameState state;

    public GameState State => state;

    public IEnumerable<Location> PlayerLocations => players.Values.Select(p => p.Ship.Location);

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
    public int BoardWidth { get; }
    public int BoardHeight { get; }

    public void EnqueueAction(PlayerToken token, GamePlayAction action) => players[token].EnqueueAction(action);
}

record PlayerAction(Player Player, GamePlayAction? Action);
public record GameJoinResult(PlayerToken Token, Location Location);