using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace SpaceWars.Tests.Web;

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