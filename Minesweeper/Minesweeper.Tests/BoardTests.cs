namespace Minesweeper.Tests;

public class BoardTests
{
    [Theory]
    [InlineData(10, 10)]
    [InlineData(10, 20)]
    [InlineData(20, 10)]
    public void TestBoardCreation(int width, int height)
    {
        Board board = new Board(width, height, 10);

        Tile[,] tiles = board.GetTiles();

        int boardHeight = tiles.GetLength(0);
        int boardWidth = tiles.GetLength(1);

        Assert.Equal(width, boardWidth);
        Assert.Equal(height, boardHeight);
    }

    [Theory]
    [InlineData(10, 10)]
    [InlineData(10, 20)]
    public void TestGetWidth(int width, int height)
    {
        Board board = new Board(width, height, 10);
        int boardWidth = board.GetWidth();

        Assert.Equal(width, boardWidth);
    }

    [Theory]
    [InlineData(10, 10)]
    [InlineData(10, 20)]
    public void TestGetHeight(int width, int height)
    {
        Board board = new Board(width, height, 10);
        int boardHeight = board.GetHeight();

        Assert.Equal(height, boardHeight);
    }

    [Theory]
    [InlineData(10, 10, 5)]
    [InlineData(10, 20, 10)]
    [InlineData(20, 10, 15)]
    public void TestBombFilling(int width, int height, int bombs)
    {
        Board board = new Board(width, height, bombs);
        board.FillWithBombs();
        Tile[,] tiles = board.GetTiles();
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++) 
            {
                Tile tile = tiles[i, j];
                if (tile.GetType() == TileType.Bomb)
                {
                    bombs--;
                }
            }
        }
        Assert.Equal(0, bombs);
    }
    [Theory]
    [InlineData(10, 10, 5)]
    [InlineData(10, 20, 10)]
    [InlineData(20, 10, 15)]
    public void TestNumberAssignment(int width, int height, int bombs)
    {
        Board board = new Board(width, height, bombs);
        board.FillWithBombs();
        Tile[,] tiles = board.GetTiles();
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++) 
            {
                Tile tile = tiles[i, j];
                if (tile.GetType() == TileType.Bomb)
                {
                    continue;
                }
                int adjacentBombs = tile.GetAdjacentBombs();
                Assert.True(adjacentBombs >= 0 && adjacentBombs <= 8);
            }
        }
    }

    [Theory]
    [InlineData(10, 10)]
    [InlineData(10, 15)]
    [InlineData(15, 10)]
    public void TestTileReveal(int row, int column)
    {
        Board board = new Board(20, 20, 10);
        Tile[,] tiles = board.GetTiles();
        tiles[row, column].Reveal();
        bool isRevealed = tiles[row, column].IsRevealed();
        Assert.True(isRevealed);
    }
    
    [Theory]
    [InlineData(10, 10)]
    [InlineData(10, 15)]
    [InlineData(15, 10)]
    public void TestTileFlag(int row, int column)
    {
        Board board = new Board(20, 20, 10);
        Tile[,] tiles = board.GetTiles();
        tiles[row, column].Flag();
        bool isFlagged = tiles[row, column].IsFlagged();
        Assert.True(isFlagged);
    }

    [Fact]
    public void Should_IncrementCorrectFlags()
    {
        Board board = new Board(10, 10, 10);
        int flags = board.GetCorrectFlags();
        board.IncrementCorrectFlags();
        Assert.Equal(flags + 1, board.GetCorrectFlags());
    }

    [Fact]
    public void Should_GetBombs()
    {
        Board board = new Board(10, 10, 10);
        int bombs = board.GetBombs();
        Assert.Equal(bombs, board.GetBombs());
    }
}