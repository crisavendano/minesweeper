namespace Minesweeper.Tests;

public class TileTests
{
    [Theory]
    [InlineData(TileType.Empty)]
    [InlineData(TileType.Bomb)]
    [InlineData(TileType.Flag)]
    public void TestTileType(TileType type)
    {
        Tile tile = new Tile();
        tile.SetType(type);
        TileType tileType = tile.GetType();
        Assert.Equal(type, tileType);
    }
    
    [Theory]
    [InlineData(TileType.Empty, "0")]
    [InlineData(TileType.Bomb, "B")]
    [InlineData(TileType.Flag, "F")]
    public void TestTileSymbolWithoutAdjacent(TileType type, string symbol)
    {
        Tile tile = new Tile();
        tile.SetType(type);
        string tileSymbol = tile.GetSymbol();
        Assert.Equal(symbol, tileSymbol);
    }
    
    [Theory]
    [InlineData(TileType.Empty, 1, "1")]
    [InlineData(TileType.Bomb, 5, "B")]
    [InlineData(TileType.Flag, 3, "F")]
    public void TestTileSymbolWithAdjacent(TileType type, int adjacentBombs, string symbol)
    {
        Tile tile = new Tile();
        tile.SetAdjacentBombs(adjacentBombs);
        tile.SetType(type);
        string tileSymbol = tile.GetSymbol();
        Assert.Equal(symbol, tileSymbol);
    }
    [Fact]
    public void TestTileReveal()
    {
        Tile tile = new Tile();
        tile.Reveal();
        bool isRevealed = tile.IsRevealed();
        Assert.True(isRevealed);
    }
    [Theory]
    [InlineData(0)]
    [InlineData(5)]
    [InlineData(10)]
    public void TestTileAdjacentBombs(int bombs)
    {
        Tile tile = new Tile();
        tile.SetAdjacentBombs(bombs);
        int adjacentBombs = tile.GetAdjacentBombs();
        Assert.Equal(bombs, adjacentBombs);
    }
    
    [Theory]
    [InlineData(TileType.Empty, 0, "0")]
    [InlineData(TileType.Empty, 1, "1")]
    [InlineData(TileType.Bomb, 5, "B")]
    [InlineData(TileType.Flag, 3, "F")]
    public void TestTileContent(TileType type, int adjacentBombs, string content)
    {
        Tile tile = new Tile();
        for (int i = 0; i < adjacentBombs; i++)
        {
            tile.IncrementAdjacentBombs();
        }
        tile.SetType(type);
        tile.Reveal();
        string tileSymbol = tile.GetContent();
        Assert.Equal(content, tileSymbol);
    }
}