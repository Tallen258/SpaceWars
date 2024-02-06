using SpaceWars.Logic.Weapons;

namespace SpaceWars.Tests.Logic.GameplayTests;

public class BasicCannonTest
{
    [Theory]
    [InlineData(353, 100)]
    [InlineData(354, 98)]
    [InlineData(355, 98)]
    [InlineData(356, 98)]
    [InlineData(357, 98)]
    [InlineData(358, 98)]
    [InlineData(359, 98)]
    [InlineData(0, 98)]
    [InlineData(1, 98)]
    [InlineData(2, 98)]
    [InlineData(3, 98)]
    [InlineData(4, 98)]
    [InlineData(5, 98)]
    [InlineData(6, 98)]
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
        var gameMap = new GameMap([p1, p2], null);

        var basicCannon = new BasicCannon();

        //Act
        basicCannon.Fire(p1, gameMap);

        //Assert
        p2.Ship.Shield.Should().Be(finalShield);
    }

    [Theory]
    [InlineData(358, 100)]
    [InlineData(359, 98)]
    [InlineData(0, 98)]
    [InlineData(1, 98)]
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
        var gameMap = new GameMap([p1, p2], null);

        var basicCannon = new BasicCannon();

        //Act
        basicCannon.Fire(p1, gameMap);

        //Assert
        p2.Ship.Shield.Should().Be(finalShield);
    }

    [Theory]
    [InlineData(199, 98)]
    [InlineData(200, 98)]
    [InlineData(201, 99)]
    [InlineData(299, 99)]
    [InlineData(300, 99)]
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
        var gameMap = new GameMap([p1, p2], null);

        var basicCannon = new BasicCannon();

        //Act
        basicCannon.Fire(p1, gameMap);

        //Assert
        p2.Ship.Shield.Should().Be(finalShield);
    }
}
