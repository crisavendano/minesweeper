namespace Minesweeper;

public static class Reveal
{
    public static void Execute(Board board)
    {
        (int x, int y) = UserInput.GetRowAndColumn();
        RevealGroup(board, x, y);
    }

    private static void RevealGroup(Board board, int x, int y)
    {
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                try
                {
                    Tile tileToReveal = board.GetTiles()[x + i, y + j];

                    if (i == 0 && j == 0)
                    {tileToReveal.Reveal();}
                    
                    if (tileToReveal.GetType() == TileType.Empty && tileToReveal.GetAdjacentBombs() == 0 && !tileToReveal.IsRevealed())
                    {
                        tileToReveal.Reveal();
                        RevealGroupAdjacents(board, x + i, y + j);
                    }
                    else if (tileToReveal.GetType() == TileType.Empty && !tileToReveal.IsRevealed())
                    {
                        tileToReveal.Reveal();
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    continue;
                }
            }
        }
    }

    private static void RevealGroupAdjacents(Board board, int x, int y)
    {
        try
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    RevealGroup(board, x + i, y + j);
                }
            }
        }
        catch (IndexOutOfRangeException)
        {
            return;
        }
    }
}