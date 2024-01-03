namespace Minesweeper;

public static class GameOverChecker
{
    public static bool CheckIfLost(Board board)
    {
        Tile[,] tiles = board.GetTiles();
        for (int i = 0; i < board.GetHeight(); i++)
        {
            for (int j = 0; j < board.GetWidth(); j++)
            {
                Tile tile = tiles[i, j];
                if (tile.GetType() == TileType.Bomb && tile.IsRevealed())
                {
                    Console.WriteLine("You lost!");
                    return true;
                }
            }
        }

        return false;
    }

    public static bool CheckIfWon(Board board)
    {
        Tile[,] tiles = board.GetTiles();
        int revealedTiles = 0;
        for (int i = 0; i < board.GetHeight(); i++)
        {
            for (int j = 0; j < board.GetWidth(); j++)
            {
                Tile tile = tiles[i, j];
                if (tile.IsRevealed()) revealedTiles++;
            }
        }

        if (HasCorrectNumberOfRevealedTiles(revealedTiles, board) || HasCorrectNumberOfFlags(board))
        {
            Console.WriteLine("You won!");
            return true;
        }

        return false;
    }

    private static bool HasCorrectNumberOfFlags(Board board) => board.GetCorrectFlags() == board.GetBombs();

    private static bool HasCorrectNumberOfRevealedTiles(int revealedTiles, Board board)
        => revealedTiles >= board.GetHeight()* board.GetWidth() - board.GetBombs();
}