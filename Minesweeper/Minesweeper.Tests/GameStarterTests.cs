namespace Minesweeper.Tests
{
    public class GameStarterTests
    {
        // [Fact]
        // public void Should_StartGame()
        // {
        //     var gameStarter = new GameStarter();
        //     gameStarter.Start();
        //     Assert.False(gameStarter.IsOver());
        //     gameStarter.EndGame();
        // }

        [Fact]
        public void Should_CreateBoardWithBombsAndNumbers()
        {
            var gameStarter = new GameStarter();
            gameStarter.CreateBoard();
            Board board = gameStarter.GetBoard();
            Assert.Equal(gameStarter.GetWidth(), board.GetWidth());
            Assert.Equal(gameStarter.GetHeight(), board.GetHeight());
        }
        // [Fact]
        // public void Should_EndGame()
        // {
        //     var gameStarter = new GameStarter();
        //     gameStarter.Start();
        //     gameStarter.EndGame();
        //     Assert.True(gameStarter.IsOver());
        // }
        
    }
}
