namespace Minesweeper;

public static class UserInput
{
    public static (int, int) GetRowAndColumn()
    {
        string message = "Select a tile (row, column): ";
        Console.WriteLine(message);
        int row = GetNumber("Row: ");
        int column = GetNumber("Column: ");
        return (row, column);
    }
    public static int GetNumber(string message)
    {
        Console.Write(message);
        int number = Convert.ToInt32(Console.ReadLine());
        return number;
    }
    public static PlayType GetPlay()
    {
        Console.WriteLine("Select a play:");
        Console.WriteLine("0: Reveal");
        Console.WriteLine("1: Flag");
        Console.WriteLine("2: Unflag");
        Console.WriteLine("3: End Game");
        PlayType play = (PlayType)GetNumber("Play: ");
        return play;
    }
}