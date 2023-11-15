namespace SpaceWars.Logic;

public class GameState
{
    public string State { get; set; } = "Joining";
    public List<Player> Players { get; set; } = new();
}