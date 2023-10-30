using SpaceWars.Logic.Weapons;

namespace SpaceWars.Tests.Logic.GameplayTests;

public class BasicCannonTest
{
    [Fact]
    public void BasicCannon_TryHitIsTrueIfPlayerInFrontOfYou()
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

        var basicCannon = new BasicCannon();

        //Act
        basicCannon.Fire(p1, gameMap);

        //Assert
        p2.Ship.Health.Should().Be(99);
    }
}
