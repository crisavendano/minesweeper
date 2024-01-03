namespace Minesweeper.Tests;

public class FlagTests
{
    [Fact]
    public void Should_CreateFlag()
    {
        Board board = BoardFactory.CreateBoard(10, 10, 10);
        Flag.PlaceFlag(board, 0, 0);
        Assert.True(board.GetTiles()[0, 0].IsFlagged());
    }
    [Fact]
    public void Should_UnFlag()
    {
        Board board = BoardFactory.CreateBoard(10, 10, 10);
        Flag.PlaceFlag(board, 0, 0);
        Flag.RemoveFlag(board, 0, 0);
        Assert.False(board.GetTiles()[0, 0].IsFlagged());
    }
    [Fact]
    public void Should_HaveCorrectSymbolWhenFlagged()
    {
        Board board = BoardFactory.CreateBoard(10, 10, 10);
        Flag.PlaceFlag(board, 0, 0);
        Assert.Equal("F", board.GetTiles()[0, 0].GetContent());
    }
}