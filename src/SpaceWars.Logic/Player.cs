using SpaceWars.Logic.Actions;

namespace SpaceWars.Logic;

public class Player
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
}
