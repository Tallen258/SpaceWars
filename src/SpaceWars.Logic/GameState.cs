namespace SpaceWars.Logic;

public class GameState
{
    public string State { get; set; } = "Not Started";
    public List<Player> Players { get; set; } = new();
}