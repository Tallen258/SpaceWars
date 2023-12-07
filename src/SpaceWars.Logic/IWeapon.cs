
namespace SpaceWars.Logic
{
    public interface IWeapon : IPurchaseable
    {
        int ChargeTurns { get; init; }
        int Power { get; init; }
        IEnumerable<WeaponRange> Ranges { get; init; }
        int ShotCost { get; init; }

        void Fire(Player player, GameMap map);
    }
}