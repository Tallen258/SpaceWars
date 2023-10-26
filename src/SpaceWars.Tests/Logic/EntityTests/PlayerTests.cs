namespace SpaceWars.Tests.Logic.EntityTests;

public class PlayerTests
{
    [Fact]
    public void Player_WhenCreated_HasName()
    {
        var player = new Player("Player 1", new Ship());
        Assert.Equal("Player 1", player.Name);
    }
}
