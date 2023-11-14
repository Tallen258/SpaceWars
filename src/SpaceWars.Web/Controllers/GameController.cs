using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SpaceWars.Logic;
using SpaceWars.Web.Types;

namespace SpaceWars.Web.Controllers;

[ApiController]
[Route("[controller]")]
public partial class GameController(ILogger<GameController> logger, Game game, IOptions<GameConfig> gameConfig) : ControllerBase
{
    [LoggerMessage(6, LogLevel.Warning, "Player {name} failed to join game. Too many players")] partial void LogTooManyPlayers(string name, ILogger<GameController> logger);

    [HttpGet("join")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JoinGameResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<JoinGameResponse>> JoinGame(string name)
    {
        try
        {
            return game.Join(name).ToResponse();
        }
        catch (TooManyPlayersException)
        {
            LogTooManyPlayers(name, logger);
            return Problem("Cannot join game, too many players.", statusCode: 400, title: "Too many players");
        }
    }

    [HttpGet("start")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> StartGame(string password)
    {
        if(gameConfig.Value.Password == password)
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpGet("state")]
    public async Task<GameState> GameStateResponse()
    {
        return game.GetState();
    }
}


public static class Extensions
{
    public static JoinGameResponse ToResponse(this GameJoinResult gameJoinResult)
    {
        var location = new SpaceWars.Web.Types.Location(gameJoinResult.Location.X, gameJoinResult.Location.Y);
        return new JoinGameResponse(gameJoinResult.Token.Value, location, "Joining");
    }
}