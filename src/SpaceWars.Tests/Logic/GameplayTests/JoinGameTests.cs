namespace SpaceWars.Tests.Logic.GameplayTests;

public class JoinGameTests
{
    [Fact]
    public void CanJoinGameAndGetUniqueToken()
    {
        var game = new Game();
        game.Join("jonathan");
        game.Players.Any(p => p.Name == "jonathan").Should().BeTrue();
    }
}
