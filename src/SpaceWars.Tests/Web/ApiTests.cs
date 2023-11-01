using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
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
}

public class SpaceWarsWebApplicationFactory : WebApplicationFactory<Program>
{
    public SpaceWarsWebApplicationFactory()
    {

    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            // services.AddAuthentication("Test")
            //     .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>("Test", options => { });
        });
    }
}