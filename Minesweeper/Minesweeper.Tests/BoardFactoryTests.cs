namespace Minesweeper.Tests;

public class BoardFactoryTests
{
    [Theory]
    [InlineData(10, 10, 10)]
    [InlineData(10, 20, 10)]
    [InlineData(20, 10, 10)]
    public void TestBoardCreation(int width, int height, int bombs)
    {
        Board board = BoardFactory.CreateBoard(width, height, bombs);
        
        Tile[,] tiles = board.GetTiles();
        
        int boardHeight = tiles.GetLength(0);
        int boardWidth = tiles.GetLength(1);
        
        Assert.Equal(width, boardWidth);
        Assert.Equal(height, boardHeight);
    }
}