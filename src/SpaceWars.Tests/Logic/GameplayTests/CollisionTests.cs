using TechTalk.SpecFlow.CommonModels;

namespace SpaceWars.Tests.Logic.GameplayTests;

public class CollisionTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void ShipCollisions(List<string> Players, List<Location> StartLocation, List<Location> BouncedLocation, List<List<(int,int)>> Headings)
    {
        (var game, _) = GameTestHelpers.CreateGame();

        List<GameJoinResult> joinResults = new();
        int index = 0;

        foreach(var player in Players)
        {
            joinResults.Add(game.Join(player));
        }
        
        foreach(var result in joinResults)
        {
            var player = game.GetPlayerByToken(result.Token);
            player.Ship.Location.Should().Be(StartLocation[index]);
            index++;
        }

        foreach(var turn in Headings)
        {
            foreach(var move in turn)
            {
                game.EnqueueAction(joinResults[move.Item2].Token, new MoveForwardAction(move.Item1));
            }
            game.Tick();
        }

        index = 0;
        var expectedShield = 90;
        var expectedHealth = 100;
        foreach (var result in joinResults)
        {
            var player = game.GetPlayerByToken(result.Token);
            player.Ship.Location.Should().Be(BouncedLocation[index]);
            player.Ship.Shield.Should().Be(expectedShield);
            player.Ship.Health.Should().Be(expectedHealth);
            index++;
        }
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] {
            new List<string> { "Player 1", "Player 2"},
            new List<Location> { new(0,0), new(1,1)},
            new List<Location> { new(0,1), new(2,1) },
            new List<List<(int,int)>>()
                {
                    new List<(int,int)> {(23,0)}
                }
            };

        yield return new object[] {
            new List<string> { "Player 1", "Player 2", "Player 3"},
            new List<Location> { new(0,0), new(1,1), new(2,2)},
            new List<Location> { new(0,1), new(2,1), new(1,2)},
            new List<List<(int,int)>>()
                {
                    new List<(int,int)> {(23,0),(203,2)}
                }
            };

        yield return new object[] {
            new List<string> { "Player 1", "Player 2", "Player 3", "Player 4" },
            new List<Location> { new(0,0), new(1,1), new(2,2), new(3,3) },
            new List<Location> { new(0,2), new(2,2), new(1,3), new(1,1) },
            new List<List<(int,int)>>()
                {
                    new List<(int,int)> {(0,0), (248,3)},
                    new List<(int,int)> {(23, 0), (0,1), (248,2), (203,3)}
                }
            };

        yield return new object[] {
            new List<string> { "Player 1", "Player 2", "Player 3", "Player 4", "Player 5", "Player 6", "Player 7", "Player 8" },
            new List<Location> { new(0,0), new(1,1), new(2,2), new(3,3), new(4,4), new(5,5), new(6,6), new(7,7) },
            new List<Location> { new(2,4), new(4,4), new(3,5), new(3,3), new(2,5), new(4,5), new(2,3), new(4,3) },
            new List<List<(int,int)>>()
                {
                    new List<(int,int)> {(68,0), (0,1), (0,2), (248,5), (248,6), (248,7)},
                    new List<(int,int)> {(68, 0), (0,1), (248,6), (248,7)},
                    new List<(int,int)> {(23,0), (23,1), (203,6), (248,7)},
                    new List<(int,int)> {(23,0), (248,7)},
                    new List<(int,int)> {(0,0), (203,7)},
                    new List<(int,int)> {(158,7)},
                    new List<(int,int)> {(293,0), (68,1), (23,2), (0,3), (248,4), (203,5), (158,6), (113,7)}
                }
            };
    }

}
