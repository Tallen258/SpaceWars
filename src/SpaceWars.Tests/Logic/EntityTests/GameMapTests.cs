namespace SpaceWars.Tests.Logic.EntityTests;

public class GameMapTests
{
    [Fact]
    public void GameMap_GetPlayersInRange()
    {
        var p1 = new Player("p1", new Ship(new Location(0, 0)));
        var p2 = new Player("p2", new Ship(new Location(0, 3)));
        var p3 = new Player("p3", new Ship(new Location(0, 4)));
        var map = new GameMap([p1, p2, p3]);

        var playersInRange = map.GetPlayersInRange(p1, 3);
        playersInRange.Should().HaveCount(1);
        playersInRange.First().Should().Be(p2);
    }

    [Fact]
    public void GameMap_GetPlayersInRangeDiagonal()
    {
        var p1 = new Player("p1", new Ship(new Location(0, 0)));
        var p2 = new Player("p2", new Ship(new Location(3, 3)));
        var p3 = new Player("p3", new Ship(new Location(4, 4)));
        var map = new GameMap([p1, p2, p3]);

        var playersInRange = map.GetPlayersInRange(p1, 4);
        playersInRange.Should().HaveCount(1);
        playersInRange.First().Should().Be(p2);
    }
}
