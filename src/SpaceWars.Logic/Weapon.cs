namespace SpaceWars.Logic;


public abstract class Weapon
{
    private string name;
    private IEnumerable<WeaponRange> ranges;
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
            ranges = value;
        }
    }

    public abstract void Fire(Player player, GameMap map);

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
}
