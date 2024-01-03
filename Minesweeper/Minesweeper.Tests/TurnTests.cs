namespace Minesweeper.Tests;

public class TurnTests
{
    [Fact]
    public void TestTurnCreation()
    {
        Board board = new Board(10, 10, 10);
        Turn turn = new Turn(board);
        Assert.NotNull(turn);
    }
    
}