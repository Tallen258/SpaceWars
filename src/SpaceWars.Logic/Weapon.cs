
namespace SpaceWars.Logic;


public abstract class Weapon : IWeapon, IEquatable<Weapon?>
{
    private string name;
    private List<WeaponRange> ranges;
    private int power;
    private int cost;
    private int shotCost;
    private int chargeTurns;

    public Weapon(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Name cannot be null or empty.");
        Name = name;
    }

    public string Name { get; }

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
               cost == other.cost &&
               shotCost == other.shotCost &&
               chargeTurns == other.chargeTurns &&
               Name == other.Name &&
               EqualityComparer<IEnumerable<WeaponRange>>.Default.Equals(Ranges, other.Ranges) &&
               Power == other.Power &&
               Cost == other.Cost &&
               ShotCost == other.ShotCost &&
               ChargeTurns == other.ChargeTurns;
    }

    public override int GetHashCode()
    {
        HashCode hash = new HashCode();
        hash.Add(name);
        hash.Add(ranges);
        hash.Add(power);
        hash.Add(cost);
        hash.Add(shotCost);
        hash.Add(chargeTurns);
        hash.Add(Name);
        hash.Add(Ranges);
        hash.Add(Power);
        hash.Add(Cost);
        hash.Add(ShotCost);
        hash.Add(ChargeTurns);
        return hash.ToHashCode();
    }

    public int Power
    {
        get { return power; }
        init
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(Power), "Power must be greater than 0.");
            power = value;
        }
    }
    public int Cost
    {
        get => cost;
        init
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(Cost), "Cost must be greater than or equal to 0.");
            cost = value;
        }
    }
    public int ShotCost
    {
        get => shotCost;
        init
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(ShotCost), "ShotCost must be greater than or equal to 0.");
            shotCost = value;
        }
    }
    public int ChargeTurns
    {
        get => chargeTurns;
        init
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(ChargeTurns), "ChargeTurns must be greater than or equal to 0.");
            chargeTurns = value;
        }
    }

    public IEnumerable<string> PurchasePrerequisites { get => PurchasePrerequisites; init => new List<string>() { }; }

    public static bool operator ==(Weapon? left, Weapon? right)
    {
        return EqualityComparer<Weapon>.Default.Equals(left, right);
    }

    public static bool operator !=(Weapon? left, Weapon? right)
    {
        return !(left == right);
    }
}
