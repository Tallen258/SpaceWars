namespace SpaceWars.Logic.Weapons;

public class BasicCannon : Weapon
{
    public BasicCannon() : base("Basic Cannon", "Narrow, medium-range weapon with small hit box.")
    {
        Ranges = [
            new WeaponRange(200, 100),
            new WeaponRange(300, 50)
        ];
        MaxDamage = 2;
        PurchaseCost = 10;
    }
}

