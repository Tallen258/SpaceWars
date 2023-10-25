namespace SpaceWars.Game;


public partial class Ship : ObservableObject
{
    private int health;
    private int speed;
    private int shield;
    private int orientation;
    private int repairCreditBalance;
    private int upgradeCreditBalance;

    public Ship(Location? startingLocation = null)
    {
        Location = startingLocation ?? new Location(0, 0);
    }

    public Location Location { get; set; }
    public int Orientation
    {
        get => orientation;
        set
        {
            if (value < 0 || value > 359)
                throw new ArgumentOutOfRangeException(nameof(Orientation), "Orientation must be between 0 and 359.");
            SetProperty(ref orientation, value);
        }
    }

    public int Health
    {
        get => health;
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(Health), "Health must be between 0 and 100.");
            SetProperty(ref health, value);
        }
    }

    public int Speed
    {
        get => speed;
        set
        {
            if (value < 0 || value > 10)
                throw new ArgumentOutOfRangeException(nameof(Speed), "Speed must be between 0 and 10.");
            SetProperty(ref speed, value);
        }
    }

    public int Shield
    {
        get => shield;
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(Shield), "Shield must be between 0 and 100.");
            SetProperty(ref shield, value);
        }
    }

    public List<Weapon> Weapons { get; set; }

    public int RepairCreditBalance
    {
        get => repairCreditBalance;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(RepairCreditBalance), "Repair credit balance must be greater than or equal to 0.");
            SetProperty(ref repairCreditBalance, value);
        }
    }

    public int UpgradeCreditBalance
    {
        get => upgradeCreditBalance;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(UpgradeCreditBalance), "Upgrade credit balance must be greater than or equal to 0.");
            SetProperty(ref upgradeCreditBalance, value);
        }
    }
}
