namespace SpaceWars.Tests.Logic.EntityTests;

public class RangeTests
{
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void Range_DistanceMustBeGreaterThan0(int distance)
    {
        Action act = () => new WeaponRange(distance, 100);
        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(101)]
    public void Range_EffectivenessMustBeBetween0And100(int effectiveness)
    {
        Action act = () => new WeaponRange(20, effectiveness);
        act.Should().Throw<ArgumentException>();
    }
}
