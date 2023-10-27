namespace SpaceWars.Tests.Logic.EntityTests;

public class ShipTests
{
    [Fact]
    public void Ship_WhenCreated_HasLocation()
    {
        var ship = new Ship();
        Assert.NotNull(ship.Location);
    }

    [Fact]
    public void Ship_OrentationMustBeBetween0And359()
    {
        var ship = new Ship();
        Assert.Throws<ArgumentOutOfRangeException>(() => ship.Heading = -1);
        Assert.Throws<ArgumentOutOfRangeException>(() => ship.Heading = 360);
    }

    [Fact]
    public void Ship_HealthMustBeBetween0And100()
    {
        var ship = new Ship();
        Assert.Throws<ArgumentOutOfRangeException>(() => ship.Health = -1);
        Assert.Throws<ArgumentOutOfRangeException>(() => ship.Health = 101);
    }

    [Fact]
    public void Ship_SpeedMustBeBetween1And10()
    {
        var ship = new Ship();
        Assert.Throws<ArgumentOutOfRangeException>(() => ship.Speed = -1);
        Assert.Throws<ArgumentOutOfRangeException>(() => ship.Speed = 0);
        Assert.Throws<ArgumentOutOfRangeException>(() => ship.Speed = 11);
    }

    [Fact]
    public void Ship_ShieldMustBeBetween0And100()
    {
        var ship = new Ship();
        Assert.Throws<ArgumentOutOfRangeException>(() => ship.Shield = -1);
        Assert.Throws<ArgumentOutOfRangeException>(() => ship.Shield = 101);
    }

    [Fact]
    public void Ship_RepairCreditBalanceMustBeGreaterThanOrEqualTo0()
    {
        var ship = new Ship();
        Assert.Throws<ArgumentOutOfRangeException>(() => ship.RepairCreditBalance = -1);
    }

    [Fact]
    public void Ship_UpgradeCreditBalanceMustBeGreaterThanOrEqualTo0()
    {
        var ship = new Ship();
        Assert.Throws<ArgumentOutOfRangeException>(() => ship.UpgradeCreditBalance = -1);
    }

    [Theory]
    [InlineData(100, 100, 50, 50, 100)]
    [InlineData(50, 100, 50, 0, 100)]
    [InlineData(25, 100, 50, 0, 75)]
    [InlineData(25, 25, 50, 0, 0)]
    public void Ship_TakesHit(int startingShield, int startingHealth, int shotPower, int endingShield, int endingHealth)
    {
        var ship = new Ship()
        {
            Shield = startingShield,
            Health = startingHealth
        };
        ship.TakeHit(shotPower);
        ship.Shield.Should().Be(endingShield);
        ship.Health.Should().Be(endingHealth);
    }

}
