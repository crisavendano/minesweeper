namespace Minesweeper.Tests;

public class GameOverTests
{
    [Theory]
    [InlineData(0,0, true)]
    public void Should_EndGame(int row, int column, bool hasToBeRevealed)
    {
        Board board = BoardFactory.CreateBoard(10, 10, 10);
        if (hasToBeRevealed) board.GetTiles()[row, column].Reveal();
        bool isBomb = board.GetTiles()[row, column].GetType() == TileType.Bomb;
        bool isRevealed = board.GetTiles()[row, column].IsRevealed();
        bool hasLost = isBomb && isRevealed;
        Assert.Equal(hasLost, GameOverChecker.CheckIfLost(board));
    }
    
}