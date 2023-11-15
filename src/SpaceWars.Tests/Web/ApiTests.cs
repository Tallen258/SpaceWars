using SpaceWars.Web.Types;
using System.Net.Http.Json;

namespace SpaceWars.Tests.Web;

public class ApiTests : IClassFixture<SpaceWarsWebApplicationFactory>
{
    private HttpClient httpClient;

    public ApiTests(SpaceWarsWebApplicationFactory webAppFactory)
    {
        httpClient = webAppFactory.CreateDefaultClient();
    }

    [Fact]
    public async Task CanJoinGameAndGetUniqueToken()
    {
        var response = await httpClient.GetAsync("/game/join?name=jonathan");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<JoinGameResponse>();
        result.GameState.Should().Be("Joining");
    }

    [Fact]
    public async Task CanStartGameWithCorrectPassword()
    {
        var response = await httpClient.GetAsync("/game/start?password=password");
        response.EnsureSuccessStatusCode();
        var gameState = await httpClient.GetFromJsonAsync<GameState>("/game/state");
        gameState.Should().BeEquivalentTo(new GameState
        {
            State="Joining"
        });
    }
}
