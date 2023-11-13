using SpaceWars.Logic.Weapons;
using TechTalk.SpecFlow;
using static SpaceWars.Tests.Logic.GameplayTests.GameTestHelpers;

namespace SpaceWars.Tests.Logic.GameplayTests;

[Binding]
public class ShootingSteps
{
    private readonly ScenarioContext _scenarioContext;

    public ShootingSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"the following game state")]
    public void GivenTheFollowingGameState(Table table)
    {
        var players = playersFromTable(table);
        _scenarioContext.Set(players);
        (var game, var joinResults) = CreateGame(players);
        _scenarioContext.Set(game);
        var playerTokens = new Dictionary<string, PlayerToken>();
        for (var i = 0; i < players.Count(); i++)
        {
            playerTokens.Add(players.ElementAt(i).Name, joinResults.ElementAt(i).Token);
        }
        _scenarioContext.Set(playerTokens);
    }

    private IEnumerable<Player> playersFromTable(Table table)
    {
        return table.Rows.Select(row => new Player(row["Player Name"], new Ship(new Location(int.Parse(row["X"]), int.Parse(row["Y"])))
        {
            Heading = int.Parse(row["Heading"]),
            Health = int.Parse(row["Health"]),
            Shield = int.Parse(row["Shield"]),
            Weapons = [new BasicCannon()]
        }));
    }

    [When(@"(.*) shoots the (.*)")]
    public void WhenPlayerShootsTheBasicCannon(string playerName, string weaponName)
    {
        var game = _scenarioContext.Get<Game>();
        var playerTokens = _scenarioContext.Get<Dictionary<string, PlayerToken>>();
        var token = playerTokens[playerName];
        var player = game.GetPlayerByToken(token);

        player.EnqueueAction(new FireWeaponAction(weaponName));
        game.Tick();
    }

    [Then(@"I have the following game state")]
    public void ThenIHaveTheFollowingGameState(Table table)
    {
        var playerTokens = _scenarioContext.Get<Dictionary<string, PlayerToken>>();
        var actualGame = _scenarioContext.Get<Game>();

        foreach (var row in table.Rows)
        {
            var actualPlayer = actualGame.GetPlayerByToken(playerTokens[row["Player Name"]]);
            Assert.Equivalent(int.Parse(row["Health"]), actualPlayer.Ship.Health);
            Assert.Equivalent(int.Parse(row["Shield"]), actualPlayer.Ship.Shield);
        }
    }
}
