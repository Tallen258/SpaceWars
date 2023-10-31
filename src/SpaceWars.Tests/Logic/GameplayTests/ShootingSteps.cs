using SpaceWars.Logic.Weapons;
using TechTalk.SpecFlow;

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
        _scenarioContext.Set(new Game(players));
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
        var player = game.Players.Single(p => p.Name == playerName);
        player.EnqueueAction(new FireWeaponAction(weaponName));
        game.Tick();
    }

    [Then(@"I have the following game state")]
    public void ThenIHaveTheFollowingGameState(Table table)
    {
        var expectedPlayerState = playersFromTable(table).ToList();
        var actualGame = _scenarioContext.Get<Game>();
        Assert.Equivalent(expectedPlayerState, actualGame.Players);
    }
}
