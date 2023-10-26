using SpaceWars.Logic.Actions;

namespace SpaceWars.Logic;

public class Game
{
    private readonly IEnumerable<Player> players;

    public Game(IEnumerable<Player> players)
    {
        this.players = players;
    }

    public void Tick()
    {
        players.Select(p => new PlayerAction(p, p.DequeueAction()))
            .Where(playerAction => playerAction.Action != null)
            .OrderBy(playerAction => playerAction.Action!.Priority)
            .ToList()//materialize the list
            .ForEach((pa) => pa.Action!.Execute(pa.Player));
    }
}

record PlayerAction(Player Player, GamePlayAction? Action);
