using SpaceWars.Logic.Weapons;

namespace SpaceWars.Tests.Logic.GameplayTests;

public class BasicCannonTest
{
    [Theory]
    [InlineData(330, 50)]
    [InlineData(335, 50)]
    [InlineData(340, 50)]
    [InlineData(345, 50)]
    [InlineData(350, 50)]
    [InlineData(355, 50)]
    [InlineData(5, 50)]
    [InlineData(10, 50)]
    [InlineData(15, 50)]
    [InlineData(20, 50)]
    [InlineData(25, 50)]
    [InlineData(35, 50)]
    [InlineData(40, 50)]
    [InlineData(45, 50)]
    [InlineData(50, 50)]
    [InlineData(55, 50)]
    [InlineData(60, 50)]
    [InlineData(65, 50)]
    [InlineData(70, 50)]
    [InlineData(75, 50)]
    public void BasicCannon_TryHitIsTrueIfPlayerInFrontOfYou(int heading, int finalHealth)
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
        p2.Ship.Health.Should().Be(finalHealth);
    }

    [Theory]
    [InlineData(0, 50)]
    [InlineData(5, 50)]
    [InlineData(10, 50)]
    [InlineData(15, 50)]
    [InlineData(20, 50)]
    [InlineData(25, 50)]
    [InlineData(35, 50)]
    [InlineData(40, 50)]
    [InlineData(45, 50)]
    [InlineData(50, 50)]
    [InlineData(55, 50)]
    [InlineData(60, 50)]
    [InlineData(65, 50)]
    [InlineData(70, 50)]
    [InlineData(75, 50)]
    [InlineData(125, 50)]
    [InlineData(175, 50)]
    [InlineData(225, 50)]
    [InlineData(275, 50)]
    [InlineData(325, 50)]
    public void BasicCannon_TryHitIsTrueIfPlayerInFrontOfYouButFarAway(int heading, int finalHealth)
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
        p2.Ship.Health.Should().Be(finalHealth);
    }
}
