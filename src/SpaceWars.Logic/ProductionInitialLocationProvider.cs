namespace SpaceWars.Logic;

public class ProductionInitialLocationProvider : IInitialLocationProvider
{
    private int maxX = 100;
    private int maxY = 100;

    public Location GetNewInitialLocation(int x, int y) => new Location(Random.Shared.Next(maxX), Random.Shared.Next(maxY));
}
