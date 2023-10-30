namespace SpaceWars.Logic.Actions;

public class FireWeaponAction(Weapon weapon) : GamePlayAction
{
    public Weapon Weapon { get; } = weapon;
    public override int Priority => 2;
    public override ActionResult Execute(Player player, GameMap map)
    {
        if (!player.Ship.Weapons.Contains(Weapon))
            return new ActionResult(false, $"You do not have the {Weapon.Name}");

        Weapon.Fire(player, map);

        return new ActionResult(true, $"You fired the {Weapon.Name}");
    }
}