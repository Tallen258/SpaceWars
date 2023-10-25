namespace SpaceWars.Tests.Game.EntityTests;

public class WeaponTests
{
    [Fact]
    public void Weapon_Initialization()
    {
        var weapon = new Weapon("Cannon")
        {
            Ranges = [new Range(20, 100)],
            Power = 50,
            Cost = 200,
            ShotCost = 25,
            ChargeTurns = 1
        };

        weapon.Name.Should().Be("Cannon");
        weapon.Ranges.Count().Should().Be(1);
        weapon.Ranges.First().Distance.Should().Be(20);
        weapon.Ranges.First().Effectiveness.Should().Be(100);
        weapon.Power.Should().Be(50);
        weapon.Cost.Should().Be(200);
        weapon.ShotCost.Should().Be(25);
        weapon.ChargeTurns.Should().Be(1);
    }

    [Fact]
    public void Weapon_NameCannotBeNull()
    {
        Action act = () => new Weapon(null!);
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Weapon_NameCannotBeEmpty()
    {
        Action act = () => new Weapon(string.Empty);
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Weapon_MustHaveAtLeastOneRange()
    {
        Action act = () =>
        {
            var weapon = new Weapon("Cannon")
            {
                Ranges = Array.Empty<Range>(),
            };
        };
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Weapon_RangesMustBeInIncreasingDistance()
    {
        //this is ok, range increases and power decreases
        var weapon = new Weapon("Cannon")
        {
            Ranges = [
                new Range(2, 100),
                new Range(5, 90),
            ],
        };

        //this is not ok, range decreases
        Action act = () =>
        {
            var weapon = new Weapon("Cannon")
            {
                Ranges = [
                    new Range(5, 100),
                    new Range(2, 90)
                ],
            };
        };
        act.Should().Throw<ArgumentException>("weapon range must increase with each new range item");
    }

    [Fact]
    public void Weapon_EffectivenessMustDecrease()
    {
        Action act = () =>
        {
            var weapon = new Weapon("Cannon")
            {
                Ranges = [
                    new Range(5, 90),
                    new Range(10, 100)
                ],
            };
        };
        act.Should().Throw<ArgumentException>("weapon range must increase with each new range item");
    }

    [Fact]
    public void Weapon_PowerMustBeGreaterThanOrEqualTo0()
    {
        Action act = () =>
        {
            var weapon = new Weapon("Cannon")
            {
                Ranges = [new Range(20, 100)],
                Power = 0,
            };
        };
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Weapon_CostMustBeGreaterThanOrEqualTo0()
    {
        Action act = () =>
        {
            var weapon = new Weapon("Cannon")
            {
                Ranges = [new Range(20, 100)],
                Cost = -1,
            };
        };
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Weapon_ShotCostMustBeGreaterThanOrEqualTo0()
    {
        Action act = () =>
        {
            var weapon = new Weapon("Cannon")
            {
                Ranges = [new Range(20, 100)],
                ShotCost = -1,
            };
        };
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Weapon_ChargeTurnsMustBeGreaterThanOrEqualTo0()
    {
        Action act = () =>
        {
            var weapon = new Weapon("Cannon")
            {
                Ranges = [new Range(20, 100)],
                ChargeTurns = -1,
            };
        };
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}
