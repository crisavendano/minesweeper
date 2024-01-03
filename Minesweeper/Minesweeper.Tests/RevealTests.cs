namespace Minesweeper.Tests;

public class RevealTests
{
    [Fact]
    public void Should_RevealTile()
    {
        Board board = new Board(10, 10, 10);
        string simulatedInput = $"{0}\n{0}\n";
        using (var inputSimulator = new StringReader(simulatedInput))
        {
            TextReader originalInput = Console.In;
            try
            {
                Console.SetIn(inputSimulator);
                Reveal.Execute(board);
                Assert.True(board.GetTiles()[0,0].IsRevealed());
            }
            finally
            {
                Console.SetIn(originalInput);
            }
        }
    }
}