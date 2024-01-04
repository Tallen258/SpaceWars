
namespace SpaceWars.Tests.Logic.GameplayTests;

public record CreateGameResult(Game Game, IEnumerable<GameJoinResult> JoinResults);

public static class GameTestHelpers
{
    public static CreateGameResult CreateGame(int borderWidth = 2000, int borderHeight = 2000, IEnumerable<Player>? players = null, IEnumerable<Location>? startingLocations = null)
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

        if (locationQueue.Count == 0)
        {
            for (int i = 0; i < 100; i++)
            {
                locationQueue.Enqueue(new Location(i, i));
            }
        }

        locationProviderMock
            .SetupSequence(m => m.GetNewInitialLocation(borderWidth, borderHeight))
            .Returns(() => locationQueue.Dequeue())
            .Returns(() => locationQueue.Dequeue())
            .Returns(() => locationQueue.Dequeue())
            .Returns(() => locationQueue.Dequeue())
            .Returns(() => locationQueue.Dequeue())
            .Returns(() => locationQueue.Dequeue())
            .Returns(() => locationQueue.Dequeue())
            .Returns(() => locationQueue.Dequeue());

        var g = new Game(locationProvider: locationProviderMock.Object, boardWidth: borderWidth, boardHeight: borderHeight);
        var joinResults = players?.Select(p =>{
            var result = g.Join(p.Name);
            g.GetPlayerByToken(result.Token).Ship.Heading = p.Ship.Heading;
            return result;
        }).ToList() ?? [];

        return new CreateGameResult(g, joinResults);
    }
}