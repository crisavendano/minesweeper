namespace Minesweeper;

public static class Flag
{
    public static void Execute(Board board)
    {
        (int x, int y) = UserInput.GetRowAndColumn();
        PlaceFlag(board, x, y);
    }
    public static void PlaceFlag(Board board, int x, int y)
    {
        Tile[,] tiles = board.GetTiles();
        Tile tile = tiles[x, y];
        if (tile.GetType() == TileType.Bomb)
        {
            tile.SetType(TileType.FlaggedBomb);
            tile.Reveal();
            board.IncrementCorrectFlags();
        }
        else
        {
            tile.SetType(TileType.Flag);
            tile.Reveal();
        }
    }
    public static void Unflag(Board board)
    {
        (int x, int y) = UserInput.GetRowAndColumn();
        RemoveFlag(board, x, y);
    }
    public static void RemoveFlag(Board board, int x, int y)
    {
        Tile[,] tiles = board.GetTiles();
        Tile tile = tiles[x, y];
        if (tile.GetType() == TileType.FlaggedBomb)
        {
            tile.SetType(TileType.Bomb);
            tile.Unreveal();
            board.DecrementCorrectFlags();
        }
        else
        {
            tile.SetType(TileType.Empty);
            tile.Unreveal();
        }
    }
}