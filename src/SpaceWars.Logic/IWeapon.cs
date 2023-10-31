
namespace SpaceWars.Logic
{
    public interface IWeapon
    {
        int ChargeTurns { get; init; }
        int Cost { get; init; }
        string Name { get; }
        int Power { get; init; }
        IEnumerable<WeaponRange> Ranges { get; init; }
        int ShotCost { get; init; }

        void Fire(Player player, GameMap map);
    }
}