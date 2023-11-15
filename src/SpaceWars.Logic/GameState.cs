namespace SpaceWars.Logic;

public class GameState
{
    public string State { get; set; } = "Joining";
    public Player[] Players { get; set; } = [];
}