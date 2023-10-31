using SpaceWars.Logic.Actions;

namespace SpaceWars.Logic;

public class Player : IEquatable<Player?>
{
    private Queue<GamePlayAction> actions;
    public Player(string name, Ship ship)
    {
        Name = name;
        Ship = ship;
        actions = new Queue<GamePlayAction>();
    }

    public string Name { get; }

    //token (is this only a concern on the api?)
    //hud url (is this only a concern on the api?)

    public Ship Ship { get; }

    public void EnqueueAction(GamePlayAction action)
    {
        actions.Enqueue(action);
    }

    public GamePlayAction? DequeueAction()
    {
        if (actions.Any())
            return actions.Dequeue();
        return null;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Player);
    }

    public bool Equals(Player? other)
    {
        return other is not null &&
               EqualityComparer<Queue<GamePlayAction>>.Default.Equals(actions, other.actions) &&
               Name == other.Name &&
               EqualityComparer<Ship>.Default.Equals(Ship, other.Ship);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(actions, Name, Ship);
    }

    public static bool operator ==(Player? left, Player? right)
    {
        return EqualityComparer<Player>.Default.Equals(left, right);
    }

    public static bool operator !=(Player? left, Player? right)
    {
        return !(left == right);
    }
}
