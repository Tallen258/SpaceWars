namespace SpaceWars.Tests.Game.EntityTests;

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
        Assert.Throws<ArgumentOutOfRangeException>(() => ship.Orientation = -1);
        Assert.Throws<ArgumentOutOfRangeException>(() => ship.Orientation = 360);
    }

    [Fact]
    public void Ship_HealthMustBeBetween0And100()
    {
        var ship = new Ship();
        Assert.Throws<ArgumentOutOfRangeException>(() => ship.Health = -1);
        Assert.Throws<ArgumentOutOfRangeException>(() => ship.Health = 101);
    }

    [Fact]
    public void Ship_SpeedMustBeBetween0And10()
    {
        var ship = new Ship();
        Assert.Throws<ArgumentOutOfRangeException>(() => ship.Speed = -1);
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
}
