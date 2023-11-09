
namespace SpaceWars.Tests.Logic.GameplayTests;

public record CreateGameResult(Game Game, IEnumerable<GameJoinResult> JoinResults);

public static class GameTestHelpers
{
    public static CreateGameResult CreateGame(IEnumerable<Player>? players = null, IEnumerable<Location>? startingLocations = null)
    {
        var locationProviderMock = new Mock<IInitialLocationProvider>();
        var locationQueue = new Queue<Location>();
        if (players is not null)
        {
            foreach (var p in players)
            {
                locationQueue.Enqueue(p.Ship.Location);
            }
        }

        if (startingLocations is not null)
        {
            foreach (var l in startingLocations)
            {
                locationQueue.Enqueue(l);
            }
        }

        if (players is null && startingLocations is null)
        {
            throw new ArgumentException("Must provide either players or startingLocations");
        }
        locationProviderMock.Setup(m => m.GetNewInitialLocation()).Returns(locationQueue.Dequeue());

        var g = new Game(locationProviderMock.Object);
        var joinResults = players?.Select(p => g.Join(p.Name)) ?? [];

        return new CreateGameResult(g, joinResults);
    }
}