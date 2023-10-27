
namespace SpaceWars.Logic.Actions;

public abstract class GamePlayAction
{
    public string Name { get; }
    public abstract int Priority { get; }
    public abstract ActionResult Execute(Player player, GameMap map);
}


public record ActionResult(bool Success, string Message);
