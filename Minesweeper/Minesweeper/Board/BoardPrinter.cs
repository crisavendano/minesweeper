namespace Minesweeper;

public static class BoardPrinter
{
    public static void Show(Board board)
    {
        int width = board.GetWidth();
        int height = board.GetHeight();
        Tile[,] tiles = board.GetTiles();
        
        PrintXAxis(width);
        for (int i = 0; i < height; i++)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (i < 10)
            {
                Console.Write(" ");
            }
            Console.Write(i + " ");
            Console.ResetColor();
            for (int j = 0; j < width; j++)
            {
                PrintTileWithColor(tiles[i, j]);
                Console.Write("  ");
            }
            Console.WriteLine();
        }
    }
    private static void PrintXAxis(int width)
    {
        Console.Write("  ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int j = 0; j < width; j++)
        {
            if (j < 10)
            {
                Console.Write(" ");
            }
            Console.Write(j + " ");
        }
        Console.WriteLine();
        Console.ResetColor();
    }
    private static void PrintTileWithColor(Tile tile)
    {
        string symbol = tile.GetContent();
        Console.ForegroundColor = symbol switch
        {
            "0" => ConsoleColor.DarkGray,
            "1" => ConsoleColor.Blue,
            "2" => ConsoleColor.Green,
            "3" => ConsoleColor.Red,
            "4" => ConsoleColor.DarkBlue,
            "5" => ConsoleColor.DarkRed,
            "6" => ConsoleColor.Cyan,
            "7" => ConsoleColor.Magenta,
            "8" => ConsoleColor.DarkYellow,
            "B" => ConsoleColor.Red,
            "F" => ConsoleColor.Green,
            _ => ConsoleColor.White
        };
        Console.Write(symbol);
        Console.ResetColor();
    }
}