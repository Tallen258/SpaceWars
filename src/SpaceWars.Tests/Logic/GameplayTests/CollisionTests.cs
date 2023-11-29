namespace SpaceWars.Tests.Logic.GameplayTests;

public class CollisionTests
{

    [Fact]
    public void TwoShipsCollide()
    {
        //Arrange
        (var game, _) = GameTestHelpers.CreateGame();
        var player1Result = game.Join("Player 1");
        var player2Result = game.Join("Player 2");
        game.EnqueueAction(player1Result.Token, new MoveForwardAction(23));

        //Act
        game.Tick();

        //Assert
        var actualPlayer1 = game.GetPlayerByToken(player1Result.Token);
        var actualPlayer2 = game.GetPlayerByToken(player2Result.Token);

        var actualPlayer1Location = actualPlayer1.Ship.Location;
        var actualPlayer2Location = actualPlayer2.Ship.Location;

        var actualPlayer1Shield = actualPlayer1.Ship.Shield;
        var actualPlayer2Shield = actualPlayer2.Ship.Shield;

        var actualPlayer1Health = actualPlayer1.Ship.Health;
        var actualPlayer2Health = actualPlayer2.Ship.Health;

        var expectedPlayer1Location = new Location(0, 1);
        var expectedPlayer2Location = new Location(2, 1);

        var expectedShield = 90;
        var expectedHealth = 100;

        actualPlayer1Location.Should().Be(expectedPlayer1Location);
        actualPlayer1Shield.Should().Be(expectedShield);
        actualPlayer1Health.Should().Be(expectedHealth);

        actualPlayer2Location.Should().Be(expectedPlayer2Location);
        actualPlayer2Shield.Should().Be(expectedShield);
        actualPlayer2Health.Should().Be(expectedHealth);

    }

}
