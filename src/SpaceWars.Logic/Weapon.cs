using System.Numerics;

namespace SpaceWars.Logic;


public abstract class Weapon : IWeapon, IEquatable<Weapon?>
{
    private List<WeaponRange> ranges;
    private int maxDamage;
    private int purchaseCost;

    public Weapon(string name, string description)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Name cannot be null or empty.");
        Name = name;
        Description = description;
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


    public void Fire(Player player, GameMap map)
    {
        var maxWeaponRange = Ranges.Last().Distance;
        var playersInRange = map.GetPlayersInWeaponRange(player, maxWeaponRange);
        if (TryHit(player, playersInRange, out var result) && result is not null)
        {
            var (hitPlayer, distance) = result.Value;
            var damage = (int)(Ranges.First(r => r.Distance >= distance).Effectiveness / 100.0 * MaxDamage);
            hitPlayer.Ship.TakeDamage(damage);
            player.Score += 10;
            player.Ship.UpgradeCreditBalance += 10;
            player.Ship.RepairCreditBalance += 10;
        }
    }

    public IEnumerable<TargetedLocation> GetPotentialTargets(Player player, GameMap map)
    {
        var maxWeaponRange = Ranges.Last().Distance;
        var playersInRange = map.GetPlayersInWeaponRange(player, maxWeaponRange);
        if (TryHit(player, playersInRange, out var result) && result is not null)
        {
            var (predictedTarget, distance) = result.Value;
            predictedTarget.NotifyTargeted();
            var predictedDamage = (int)(Ranges.First(r => r.Distance >= distance).Effectiveness / 100.0 * MaxDamage);
            yield return new(predictedTarget.Ship.Location, predictedDamage);
        }
    }

    public bool TryHit(Player player, IEnumerable<Player> playersInRange, out (Player hitPlayer, int distance)? result)
    {
        Vector2 playerLocation = new Vector2(player.Ship.Location.X, player.Ship.Location.Y);
        var headingRadians = MathF.PI / 180 * (360 - player.Ship.Heading);
        var playerHeading = Vector2.Transform(new Vector2(0, 1), Matrix3x2.CreateRotation(headingRadians));
        playerHeading = Vector2.Normalize(playerHeading);


        foreach (var otherPlayer in playersInRange)
        {
            var targetPosition = otherPlayer.Ship.Location;
            var boxSize = 1;
            // Calculate the four corners of the bounding box around the target.
            Vector2 topRight = new Vector2(targetPosition.X + boxSize, targetPosition.Y + boxSize);
            Vector2 bottomLeft = new Vector2(targetPosition.X - boxSize, targetPosition.Y - boxSize);

            // Check if the ship's forward vector intersects with the bounding box.
            bool inFront = RayIntersectsAABB(bottomLeft, topRight, playerLocation, playerHeading);

            if (inFront)
            {
                var otherLocation = new Vector2(otherPlayer.Ship.Location.X, otherPlayer.Ship.Location.Y);
                var distance = (int)Vector2.Distance(playerLocation, otherLocation);
                result = (otherPlayer, distance);
                return true;
            }
        }

        result = null;
        return false;
    }

    private bool RayIntersectsAABB(Vector2 boxMin, Vector2 boxMax, Vector2 rayOrigin, Vector2 rayDirection)
    {
        var tMin = (boxMin.X - rayOrigin.X) / rayDirection.X;
        var tMax = (boxMax.X - rayOrigin.X) / rayDirection.X;

        if (tMin > tMax)
        {
            (tMin, tMax) = (tMax, tMin);
        }

        var tyMin = (boxMin.Y - rayOrigin.Y) / rayDirection.Y;
        var tyMax = (boxMax.Y - rayOrigin.Y) / rayDirection.Y;

        if (tyMin > tyMax)
        {
            (tyMin, tyMax) = (tyMax, tyMin);
        }

        if (tMin > tyMax || tyMin > tMax)
        {
            return false;
        }

        return true;
    }

    public override bool Equals(object? obj)
    {
        return obj is Weapon weapon &&
               Name == weapon.Name &&
               Description == weapon.Description &&
               EqualityComparer<IEnumerable<WeaponRange>>.Default.Equals(Ranges, weapon.Ranges) &&
               MaxDamage == weapon.MaxDamage &&
               PurchaseCost == weapon.PurchaseCost;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Description, Ranges, MaxDamage, PurchaseCost);
    }

    public bool Equals(Weapon? other) => this == other;

    public int MaxDamage
    {
        get { return maxDamage; }
        init
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(MaxDamage), "Must be greater than 0.");
            maxDamage = value;
        }
    }
    public int PurchaseCost
    {
        get => purchaseCost;
        init
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(PurchaseCost), "Must be greater than or equal to 0.");
            purchaseCost = value;
        }
    }

    public static bool operator ==(Weapon? left, Weapon? right)
    {
        return EqualityComparer<Weapon>.Default.Equals(left, right);
    }

    public static bool operator !=(Weapon? left, Weapon? right)
    {
        return !(left == right);
    }
}
