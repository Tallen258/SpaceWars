namespace SpaceWars.Tests.Logic.GameplayTests;
using FluentAssertions;
using static GameTestHelpers;

public class JoinGameTests
{
    [Fact]
    public void CanJoinGameAndGetUniqueToken()
    {
        (var game, var joinResults) = CreateGame([]);
        var joinResult = game.Join("playerABC");
        joinResult.Token.Should().NotBeNull();

        var player = game.GetPlayerByToken(joinResult.Token);
        player.Name.Should().Be("playerABC");
    }
}
