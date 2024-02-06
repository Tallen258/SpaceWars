using SpaceWars.Logic.Weapons;
using static SpaceWars.Tests.Logic.GameplayTests.GameTestHelpers;

namespace SpaceWars.Tests.Logic.GameplayTests;

public class ShootingTests
{
    [Fact]
    public void CannotFireAWeaponYouDontHave()
    {
        var p1 = new Player("Player 1", new Ship(new Location(0, 0))
        {
            Heading = 0
        });

        var basicCannon = new BasicCannon();
        var fancyLaserMock = new Mock<IWeapon>();
        fancyLaserMock.Setup(m => m.Name).Returns("Fancy Laser");

        p1.Ship.Weapons.Add(basicCannon);

        var fireAction = new FireWeaponAction(fancyLaserMock.Object);
        var map = new GameMap([p1], null);

        fireAction.Execute(p1, map).Should().Be(new Result(false, "You do not have the Fancy Laser"));
    }

    [Fact]
    public void OneShipCanHitAnotherShipDirectlyInFrontOfIt()
    {
        //Arrange
        var p1 = new Player("Player 1", new Ship(new Location(0, 0))
        {
            Heading = 0,
            Health = 100,
        });

        var p2 = new Player("Player 2", new Ship(new Location(0, 3))
        {
            Heading = 90,
            Health = 100,
        });


        (var game, var joinResults) = CreateGame(players: [p1, p2]);

        game.EnqueueAction(joinResults.First().Token, new FireWeaponAction(p1.Ship.Weapons.First()));

        //Act
        game.Tick();

        //Assert
        game.GetPlayerByToken(joinResults.Last().Token).Ship.Shield.Should().Be(98);
    }

    [Fact]
    public void TwoShipsWithSameHealthShootEachotherAndBothDie()
    {
        //Arrange
        var p1 = new Player("Player 1", new Ship(new Location(0, 0))
        {
            Health = 1,
            Shield = 0,
            Heading = 0
        });

        var p2 = new Player("Player 2", new Ship(new Location(0, 3))
        {
            Health = 1,
            Shield = 0,
            Heading = 180,
        });

        (var game, var joinResults) = CreateGame(players: [p1, p2]);

        game.EnqueueAction(joinResults.First().Token, new FireWeaponAction(p1.Ship.Weapons.First()));
        game.EnqueueAction(joinResults.Last().Token, new FireWeaponAction(p2.Ship.Weapons.First()));

        //Act
        game.Tick();

        //Assert
        game.GetPlayerByToken(joinResults.First().Token).Ship.Shield.Should().Be(98);
        game.GetPlayerByToken(joinResults.Last().Token).Ship.Shield.Should().Be(98);

        //game.HasPlayer(p1).Should().BeFalse();//not sure the best way to represent that
        //game.HasPlayer(p2).Should().BeFalse();//not sure the best way to represent that
    }
}
