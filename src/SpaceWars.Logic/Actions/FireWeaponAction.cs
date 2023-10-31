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
    public override ActionResult Execute(Player player, GameMap map)
    {
        var playerWeapon = player.Ship.Weapons.FirstOrDefault(w => w.Name == weaponName);
        if (playerWeapon is null)
            return new ActionResult(false, $"You do not have the {weaponName}");

        playerWeapon.Fire(player, map);

        return new ActionResult(true, $"You fired the {weaponName}");
    }
}