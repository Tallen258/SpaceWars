namespace SpaceWars.Logic;

public interface IInitialLocationProvider
{
    Location GetNewInitialLocation(int maxWidth, int maxHeight);
}

public class DefaultInitialLocationProvider : IInitialLocationProvider
{
    public Location GetNewInitialLocation(int maxWidth, int maxHeight)
    {
        return new Location(Random.Shared.Next(0, maxWidth), Random.Shared.Next(0, maxHeight));
    }
}
