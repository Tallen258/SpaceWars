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

        var basicCannon = new Weapon("Basic Cannon")
        {
            ChargeTurns = 0,
            Cost = 0,
            Power = 1,
            Ranges = [new WeaponRange(5, 100)],
            ShotCost = 0,
        };

        var fancyLaser = new Weapon("Fancy Laser")
        {
            ChargeTurns = 2,
            Cost = 3,
            Power = 20,
            Ranges = [new WeaponRange(200, 100)],
            ShotCost = 0,
        };

        p1.Ship.Weapons.Add(basicCannon);

        var fireAction = new Shoot(fancyLaser);
        var map = new GameMap([p1]);

        fireAction.Execute(p1, map).Should().Be(new ActionResult(false, "You do not have the Fancy Laser"));
    }

    [Fact]
    public void OneShipCanHitAnotherShipDirectlyInFrontOfIt()
    {
        //Arrange
        var p1 = new Player("Player 1", new Ship(new Location(0, 0))
        {
            Heading = 0
        });

        var p2 = new Player("Player 2", new Ship(new Location(0, 3))
        {
            Heading = 90,
        });

        var basicCannon = new Weapon("Basic Cannon")
        {
            ChargeTurns = 0,
            Cost = 0,
            Power = 1,
            Ranges = [new WeaponRange(5, 100)],
            ShotCost = 0,
        };

        p1.Ship.Weapons.Add(basicCannon);
        p2.Ship.Weapons.Add(basicCannon);

        p1.EnqueueAction(new Shoot(p1.Ship.Weapons.First()));

        var game = new Game([p1, p2]);

        //Act
        game.Tick();

        //Assert
        p2.Ship.Health.Should().Be(99);
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

        var basicCannon = new Weapon("Basic Cannon")
        {
            ChargeTurns = 0,
            Cost = 0,
            Power = 1,
            Ranges = [new WeaponRange(5, 100)],
            ShotCost = 0,
        };

        p1.Ship.Weapons.Add(basicCannon);
        p2.Ship.Weapons.Add(basicCannon);

        p1.EnqueueAction(new Shoot(p1.Ship.Weapons.First()));
        p2.EnqueueAction(new Shoot(p1.Ship.Weapons.First()));

        var game = new Game([p1, p2]);

        //Act
        game.Tick();

        //Assert
        p1.Ship.Health.Should().Be(0);
        p2.Ship.Health.Should().Be(0);

        //game.HasPlayer(p1).Should().BeFalse();//not sure the best way to represent that
        //game.HasPlayer(p2).Should().BeFalse();//not sure the best way to represent that
    }
}
