namespace SpaceWars.Logic.Weapons;

public class PowerFist : Weapon
{
    public PowerFist() : base("Power Fist", "Close-range heavy-hitter.")
    {
        Ranges = [
            new WeaponRange(5, 100)
        ];
        MaxDamage = 33;
        PurchaseCost = 500;
    }
}

