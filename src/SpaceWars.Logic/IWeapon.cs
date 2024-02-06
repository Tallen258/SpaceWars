
namespace SpaceWars.Logic
{
    public interface IWeapon : IPurchasable
    {
        int MaxDamage { get; init; }
        IEnumerable<WeaponRange> Ranges { get; init; }
        void Fire(Player player, GameMap map);
    }
}