namespace SpaceWars.Tests.Logic.EntityTests;

public class WeaponRangeTests
{

    [Fact]
    public void Weapon_RangesMustBeInIncreasingDistance()
    {
        //this is ok, range increases and power decreases
        WeaponRange.RangesAreValid([
            new WeaponRange(2, 100),
            new WeaponRange(5, 90),
        ]).Should().BeTrue();

        //this is not ok, range decreases
        WeaponRange.RangesAreValid([
            new WeaponRange(5, 100),
            new WeaponRange(2, 90)
        ]).Should().BeFalse();
    }

    [Fact]
    public void Weapon_EffectivenessMustDecrease()
    {
        WeaponRange.RangesAreValid([
            new WeaponRange(5, 90),
            new WeaponRange(10, 100)
        ]).Should().BeFalse();
    }
}
