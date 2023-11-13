namespace SpaceWars.Logic;

public interface IInitialLocationProvider
{
    Location GetNewInitialLocation();
}

public class DefaultInitialLocationProvider : IInitialLocationProvider
{
    public Location GetNewInitialLocation()
    {
        return new Location(Random.Shared.Next(0, 100), Random.Shared.Next(0, 100));
    }
}
