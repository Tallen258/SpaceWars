using SpaceWars.Logic.Actions;

namespace SpaceWars.Logic;

public class Game
{
    private readonly List<Player> players;

    public Game(IEnumerable<Player> players)
    {
        this.players = new(players);
    }

    public void Tick()
    {
        var playerActions = players.Select(p => new PlayerAction(p, p.DequeueAction()))
            .Where(playerAction => playerAction.Action != null)
            .OrderBy(playerAction => playerAction.Action!.Priority)
            .ToList();

        GameMap map = null;

        foreach (var playerAction in playerActions)
        {
            bool allMovesAreComplete = playerAction.Action.Priority is not 1;
            if (allMovesAreComplete && map is null)
            {
                map = new GameMap(players);//initialize that here
            }

            playerAction.Action.Execute(playerAction.Player, map);
        }
    }

    public IEnumerable<Player> Players => players;
}

record PlayerAction(Player Player, GamePlayAction? Action);
