namespace SpaceWars.Tests.Logic.GameplayTests;

public class JoinGameTests
{
    [Fact]
    public void CanJoinGameAndGetUniqueToken()
    {
        var game = new Game(new List<Player>());
        var player = new Player("jonathan");
        game.Join(player);
        game.Players.Should().Contain(player);
    }
}
