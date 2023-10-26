namespace SpaceWars.Tests.Logic.GameplayTests;

public class MovementTests
{
    [Theory]
    [InlineData(0, 0, 1, "Straight up")]
    [InlineData(45, 0, 1, "Almost turning right, but still mostly up")]
    [InlineData(46, 1, 0, "Turning right just enough that you go right")]
    [InlineData(90, 1, 0, "Clearly moving right")]
    [InlineData(135, 1, 0, "Still moving right, but almost pointing down")]
    [InlineData(180, 0, -1, "Clearly pointing down")]
    [InlineData(225, 0, -1, "Still going down but almost pointing left")]
    [InlineData(226, -1, 0, "Barely pointing left")]
    [InlineData(270, -1, 0, "Clearly pointing left")]
    [InlineData(315, -1, 0, "Still pointing left but almost going up")]
    [InlineData(316, 0, 1, "Barely going up")]
    [InlineData(359, 0, 1, "Clearly going up")]
    public void ShipMovesForwardAt1xLocationIsUpdatedAccordingly(int heading, int x, int y, string because)
    {
        //Arrange
        var ship = new Ship(new Location(0, 0))
        {
            Heading = heading
        };
        var player = new Player("Player 1", ship);
        player.EnqueueAction(new MoveForward());
        var game = new Game(new[] { player });

        //Act
        game.Tick();

        //Assert
        ship.Location.Should().Be(new Location(x, y), because);
    }
}
