namespace SpaceWars.Logic.Actions;

public abstract class GamePlayAction
{
    public string Name { get; }
    public abstract int Priority { get; }
    public abstract void Execute(Player player);
}
