namespace SpaceWars.Logic;




public partial class Ship : ObservableObject
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
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(Shield), $"{nameof(Shield)} must be between 0 and 100.");
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

    public void TakeHit(int power)
    {
        var shieldDecrease = Math.Min(power, Shield);
        Shield -= shieldDecrease;
        power -= shieldDecrease;

        var healthDecrease = Math.Min(power, Health);
        Health -= healthDecrease;

        if (Health < 0)
            throw new Exception("Somehow you have to handle removing players from the game!");
    }
}
