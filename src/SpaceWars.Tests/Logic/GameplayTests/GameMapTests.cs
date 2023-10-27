namespace SpaceWars.Tests.Logic.GameplayTests;

public class GameMapTests
{
    [Fact]
    public void GameMap_TryHitIsTrueIfPlayerInFrontOfYou()
    {
        //Arrange
        var p1 = new Player("Player 1", new Ship(new Location(0, 0))
        {
            Heading = 0
        });
        var p2 = new Player("Player 2", new Ship(new Location(0, 3))
        {
            Heading = 90
        });
        var gameMap = new GameMap([p1, p2]);

        //Act
        var hit = gameMap.TryHit(p1, out (Player hitPlayer, int distance)? result);
        if (hit)
        {

            //Assert
            hit.Should().BeTrue();
            result!.Value.hitPlayer.Should().Be(p2);
        }
        else
        {
            Assert.Fail("This should have been a hit");
        }
    }
}
