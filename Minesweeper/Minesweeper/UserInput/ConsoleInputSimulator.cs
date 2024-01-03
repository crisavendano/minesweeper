namespace Minesweeper;

public class ConsoleInputSimulator : IDisposable
{
    private readonly string simulatedInput;
    private readonly System.IO.StringReader stringReader;
    private readonly System.IO.TextReader originalInput;

    public ConsoleInputSimulator(string simulatedInput)
    {
        this.simulatedInput = simulatedInput;
        stringReader = new System.IO.StringReader(simulatedInput);
        originalInput = Console.In;
        Console.SetIn(stringReader);
    }

    public void Dispose()
    {
        Console.SetIn(originalInput);
        stringReader.Dispose();
    }
}