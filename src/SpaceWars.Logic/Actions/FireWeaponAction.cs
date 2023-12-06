namespace SpaceWars.Logic.Actions;

public class FireWeaponAction : GamePlayAction
{
    public FireWeaponAction(string weaponName)
    {
        this.weaponName = weaponName;
    }

    public FireWeaponAction(IWeapon weapon)
    {
        this.weaponName = weapon.Name;
    }
    private string weaponName;
    public override int Priority => 2;

    public override string Name => "Fire";

    public string WeaponName => weaponName;
    public override Result Execute(Player player, GameMap map)
    {
        var playerWeapon = player.Ship.Weapons.FirstOrDefault(w => w.Name == weaponName);
        if (playerWeapon is null)
            return new Result(false, $"You do not have the {weaponName}");

        playerWeapon.Fire(player, map);

        return new Result(true, $"You fired the {weaponName}");
    }
}