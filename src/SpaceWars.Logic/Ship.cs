using SpaceWars.Logic.Weapons;

namespace SpaceWars.Logic;




public partial class Ship : ObservableObject, IEquatable<Ship?>
{
    private int health;
    private int speed;
    private int shield;
    private int heading;
    private int repairCreditBalance;
    private int upgradeCreditBalance;

    public Ship(Location? startingLocation = null)
    {
        Location = startingLocation ?? new Location(0, 0);
        Health = 100;
        Speed = 1;
        Shield = 100;
        Weapons = [new BasicCannon()];
        Heading = Random.Shared.Next(0, 360);
    }

    public Location Location { get; set; }
    public int Heading
    {
        get => heading;
        set
        {
            if (value < 0 || value > 359)
                throw new ArgumentOutOfRangeException(nameof(Heading), $"{nameof(Heading)} must be between 0 and 359.");
            SetProperty(ref heading, value);
        }
    }

    public int Health
    {
        get => health;
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(Health), $"{nameof(Health)} must be between 0 and 100.");
            SetProperty(ref health, value);
        }
    }

    public int Speed
    {
        get => speed;
        set
        {
            if (value < 1 || value > 10)
                throw new ArgumentOutOfRangeException(nameof(Speed), $"{nameof(Speed)} must be between 1 and 10.");
            SetProperty(ref speed, value);
        }
    }

    public int Shield
    {
        get => shield;
        set
        {
            if (value < 0)
                value = 0;
            else if (value > 100)
                value = 100;
            SetProperty(ref shield, value);
        }
    }

    public List<Weapon> Weapons { get; set; } = new();

    public int RepairCreditBalance
    {
        get => repairCreditBalance;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(RepairCreditBalance), $"{nameof(RepairCreditBalance)} must be greater than or equal to 0.");
            SetProperty(ref repairCreditBalance, value);
        }
    }

    public int UpgradeCreditBalance
    {
        get => upgradeCreditBalance;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(UpgradeCreditBalance), $"{nameof(UpgradeCreditBalance)} must be greater than or equal to 0.");
            SetProperty(ref upgradeCreditBalance, value);
        }
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Ship);
    }

    public bool Equals(Ship? other)
    {
        return other is not null &&
               health == other.health &&
               speed == other.speed &&
               shield == other.shield &&
               heading == other.heading &&
               repairCreditBalance == other.repairCreditBalance &&
               upgradeCreditBalance == other.upgradeCreditBalance &&
               EqualityComparer<Location>.Default.Equals(Location, other.Location) &&
               Heading == other.Heading &&
               Health == other.Health &&
               Speed == other.Speed &&
               Shield == other.Shield &&
               EqualityComparer<List<Weapon>>.Default.Equals(Weapons, other.Weapons) &&
               RepairCreditBalance == other.RepairCreditBalance &&
               UpgradeCreditBalance == other.UpgradeCreditBalance;
    }

    public override int GetHashCode()
    {
        HashCode hash = new HashCode();
        hash.Add(health);
        hash.Add(speed);
        hash.Add(shield);
        hash.Add(heading);
        hash.Add(repairCreditBalance);
        hash.Add(upgradeCreditBalance);
        hash.Add(Location);
        hash.Add(Heading);
        hash.Add(Health);
        hash.Add(Speed);
        hash.Add(Shield);
        hash.Add(Weapons);
        hash.Add(RepairCreditBalance);
        hash.Add(UpgradeCreditBalance);
        return hash.ToHashCode();
    }

    public void TakeDamage(int damage)
    {
        //first, decrease shield
        var damageDealt = Math.Min(Shield, damage);
        Shield -= damageDealt;

        var remainingDamage = damage - damageDealt;
        if (remainingDamage > 0)
        {
            Health -= Math.Min(Health, remainingDamage);
        }
    }

    public void RepairDamage(int repairAmount)
    {
        Shield += Math.Min(100-Shield, repairAmount);
    }

    public static bool operator ==(Ship? left, Ship? right)
    {
        return EqualityComparer<Ship>.Default.Equals(left, right);
    }

    public static bool operator !=(Ship? left, Ship? right)
    {
        return !(left == right);
    }
}
