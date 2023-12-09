namespace SpaceWars.Tests.Logic.GameplayTests;

public class ChangeHeadingTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(22)]
    public void ChangeHeading(int heading)
    {
        //Arrange
        int originalX = 100;
        int originalY = 100;
        var ship = new Ship(new SpaceWars.Logic.Location(originalX, originalY));
        (var game, var result) = GameTestHelpers.CreateGame(players: new List<Player> { new Player("Player 1", ship) });
        game.EnqueueAction(result.First().Token, new ChangeHeadingAction (heading));

        //Act
        game.Tick();

        //Assert
        var actualPlayer = game.GetPlayerByToken(result.First().Token);
        var actualHeading = actualPlayer.Ship.Heading;
        actualHeading.Should().Be(heading);
    }
}
