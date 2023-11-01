namespace SpaceWars.Web.Types;

public record JoinGameResponse(string Token, Location StartingLocation, string GameState);
public record Location(int X, int Y);
