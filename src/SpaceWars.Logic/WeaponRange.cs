namespace SpaceWars.Logic;

public record WeaponRange
{
    public WeaponRange(int distance, int effectiveness)
    {
        if (distance <= 0)
            throw new ArgumentOutOfRangeException(nameof(Distance), "Distance must be greater than 0.");
        Distance = distance;

        if (effectiveness < 0 || effectiveness > 100)
            throw new ArgumentOutOfRangeException(nameof(Effectiveness), "Effectiveness must be between 0 and 100.");
        Effectiveness = effectiveness;
    }

    public int Distance { get; }

    public int Effectiveness { get; }

    public static bool RangesAreValid(IEnumerable<WeaponRange> value)
    {
        var previousDistance = 0;
        var previousEffectiveness = int.MaxValue;

        foreach (var range in value)
        {
            if (range.Distance <= previousDistance || range.Effectiveness >= previousEffectiveness)
                return false;
            previousDistance = range.Distance;
            previousEffectiveness = range.Effectiveness;
        }

        return true;
    }
}
