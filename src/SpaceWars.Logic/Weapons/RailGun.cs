namespace SpaceWars.Logic.Weapons;

public class RailGun : Weapon
{
    public RailGun() : base("Rail Gun", "Long-range weapon with high damage.")
    {
        Ranges = [
            new WeaponRange(500, 100),
            new WeaponRange(600, 50),
            new WeaponRange(700, 25)
        ];
        MaxDamage = 10;
        PurchaseCost = 1_050;
    }
}