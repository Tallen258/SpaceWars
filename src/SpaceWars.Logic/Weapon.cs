
namespace SpaceWars.Logic;


public abstract class Weapon : IWeapon, IEquatable<Weapon?>
{
    private string name;
    private List<WeaponRange> ranges;
    private int power;
    private int purchaseCost;
    private int shotCost;
    private int chargeTurns;

    public Weapon(string name, string description)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Name cannot be null or empty.");
        Name = name;
        Description = description;
        PurchasePrerequisites = [];
    }

    public string Name { get; }
    public string Description { get; }

    public IEnumerable<WeaponRange> Ranges
    {
        get { return ranges; }
        init
        {
            if (value == null || !value.Any())
                throw new ArgumentException("Weapon must have at least one range.");
            if (!WeaponRange.RangesAreValid(value))
                throw new ArgumentException("Ranges must be in increasing distance and decreasing power.");
            ranges = new(value);
        }
    }

    public abstract void Fire(Player player, GameMap map);

    public abstract IEnumerable<TargetedLocation> GetPotentialTargets(Player player, GameMap map);

    public override bool Equals(object? obj)
    {
        return Equals(obj as Weapon);
    }

    public bool Equals(Weapon? other)
    {
        return other is not null &&
               name == other.name &&
               EqualityComparer<IEnumerable<WeaponRange>>.Default.Equals(ranges, other.ranges) &&
               power == other.power &&
               purchaseCost == other.purchaseCost &&
               shotCost == other.shotCost &&
               chargeTurns == other.chargeTurns &&
               Name == other.Name &&
               EqualityComparer<IEnumerable<WeaponRange>>.Default.Equals(Ranges, other.Ranges) &&
               MaxDamage == other.MaxDamage &&
               PurchaseCost == other.PurchaseCost;
    }

    public override int GetHashCode()
    {
        HashCode hash = new HashCode();
        hash.Add(name);
        hash.Add(ranges);
        hash.Add(power);
        hash.Add(purchaseCost);
        hash.Add(shotCost);
        hash.Add(chargeTurns);
        hash.Add(Name);
        hash.Add(Ranges);
        hash.Add(MaxDamage);
        hash.Add(PurchaseCost);
        return hash.ToHashCode();
    }

    public int MaxDamage
    {
        get { return power; }
        init
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(MaxDamage), "Power must be greater than 0.");
            power = value;
        }
    }
    public int PurchaseCost
    {
        get => purchaseCost;
        init
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(PurchaseCost), "Cost must be greater than or equal to 0.");
            purchaseCost = value;
        }
    }

    public IEnumerable<string> PurchasePrerequisites { get; set; }

    public static bool operator ==(Weapon? left, Weapon? right)
    {
        return EqualityComparer<Weapon>.Default.Equals(left, right);
    }

    public static bool operator !=(Weapon? left, Weapon? right)
    {
        return !(left == right);
    }
}
