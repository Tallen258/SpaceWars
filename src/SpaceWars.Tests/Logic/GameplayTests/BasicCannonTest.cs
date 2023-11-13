using SpaceWars.Logic.Weapons;

namespace SpaceWars.Tests.Logic.GameplayTests;

public class BasicCannonTest
{
    [Theory]
    [InlineData(353, 100)]
    [InlineData(354, 50)]
    [InlineData(355, 50)]
    [InlineData(356, 50)]
    [InlineData(357, 50)]
    [InlineData(358, 50)]
    [InlineData(359, 50)]
    [InlineData(0, 50)]
    [InlineData(1, 50)]
    [InlineData(2, 50)]
    [InlineData(3, 50)]
    [InlineData(4, 50)]
    [InlineData(5, 50)]
    [InlineData(6, 50)]
    [InlineData(7, 100)]

    public void BasicCannon_TryHitIsTrueIfPlayerInFrontOfYou(int heading, int finalShield)
    {
        //Arrange
        var p1 = new Player("Player 1", new Ship(new Location(0, 0))
        {
            Heading = heading
        });
        var p2 = new Player("Player 2", new Ship(new Location(0, 10))
        {
            Heading = 90,
            Health = 100,
        });
        var gameMap = new GameMap([p1, p2]);

        var basicCannon = new BasicCannon();

        //Act
        basicCannon.Fire(p1, gameMap);

        //Assert
        p2.Ship.Shield.Should().Be(finalShield);
    }

    [Theory]
    [InlineData(358, 100)]
    [InlineData(359, 50)]
    [InlineData(0, 50)]
    [InlineData(1, 50)]
    [InlineData(2, 100)]
    public void BasicCannon_TryHitIsTrueIfPlayerInFrontOfYouButFarAway(int heading, int finalShield)
    {
        //Arrange
        var p1 = new Player("Player 1", new Ship(new Location(0, 0))
        {
            Heading = heading
        });
        var p2 = new Player("Player 2", new Ship(new Location(0, 50))
        {
            Heading = 90,
            Health = 100,
        });
        var gameMap = new GameMap([p1, p2]);

        var basicCannon = new BasicCannon();

        //Act
        basicCannon.Fire(p1, gameMap);

        //Assert
        p2.Ship.Shield.Should().Be(finalShield);
    }

    [Theory]
    [InlineData(199, 50)]
    [InlineData(200, 50)]
    [InlineData(201, 75)]
    [InlineData(299, 75)]
    [InlineData(300, 75)]
    [InlineData(301, 100)]
    public void BasicCannon_HitPowerDecreasesAsDistanceIncreases(int distance, int finalShield)
    {
        //Arrange
        var p1 = new Player("Player 1", new Ship(new Location(0, 0))
        {
            Heading = 0,
        });
        var p2 = new Player("Player 2", new Ship(new Location(0, distance))
        {
            Heading = 90,
            Health = 100,
        });
        var gameMap = new GameMap([p1, p2]);

        var basicCannon = new BasicCannon();

        //Act
        basicCannon.Fire(p1, gameMap);

        //Assert
        p2.Ship.Shield.Should().Be(finalShield);
    }
}
