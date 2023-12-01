using SpaceWars.Web.Types;

namespace SpaceWars.Tests.Logic.GameplayTests;

public class BorderTests
{
    [Theory]
    [InlineData(158, 0, 0, "Down")]
    public void ShipCantMoveOutOfBounds(int heading, int newX, int newY, string because)
    {
        //Arrange
        var ship = new Ship(new SpaceWars.Logic.Location(0, 0));
        (var game, var joinGameResponse) = GameTestHelpers.CreateGame(players: new List<Player> { new Player("Player 1", ship) });
        var result = joinGameResponse.First();
        game.EnqueueAction(result.Token, new MoveForwardAction(heading));

        //Act
        game.Tick();

        //Assert Location are the same
        var actualPlayer = game.GetPlayerByToken(result.Token);
        var actualLocation = actualPlayer.Ship.Location;
        var expectedLocation = new SpaceWars.Logic.Location(newX, newY);
        actualLocation.Should().Be(expectedLocation, because);
    }
}
