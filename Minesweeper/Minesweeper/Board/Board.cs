namespace Minesweeper;

public class Board
{
    private int _width;
    private int _height;
    private int _bombs;
    private int _correctFlags;
    private Tile[,] _tiles;
    public Board(int width, int height, int bombs)
    {
        _width = width;
        _height = height;
        _bombs = bombs;
        _correctFlags = 0;
        FillBoardWithEmptyTiles();
    }
    
    public Tile[,] GetTiles() => _tiles;
    private void FillBoardWithEmptyTiles()
    {
        _tiles = new Tile[_height, _width];
        for (int x = 0; x < _height; x++)
        {
            for (int y = 0; y < _width; y++) 
            {
                _tiles[x, y] = new Tile();
            }
        }
    }
    public int GetWidth() => _width;
    public int GetHeight() => _height;

    public void FillWithBombs()
    {
        Random random = new Random();
        int bombs = _bombs;
        while (bombs > 0)
        {
            int x = random.Next(0, _height);
            int y = random.Next(0, _width);
            Tile tile = _tiles[x, y];
            if (tile.GetType() == TileType.Bomb) continue;
            _tiles[x, y].SetType(TileType.Bomb);
            bombs--;
        }
    }

    public void FillWithNumbers()
    {
        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++) 
            {
                Tile tile = _tiles[i, j];
                if (tile.GetType() == TileType.Bomb) continue;
                int adjacentBombs = GetAdjacentBombs(i, j);
                tile.SetAdjacentBombs(adjacentBombs);
                tile.SetSymbol();
            }
        }
    }

    public int GetAdjacentBombs(int row, int column)
    {
        int adjacentBombs = 0;
        for (int i = row - 1; i <= row + 1; i++)
        {
            for (int j = column - 1; j <= column + 1; j++) 
            {
                if (i < 0 || i >= _height || j < 0 || j >= _width) continue;
                Tile tile = _tiles[i, j];
                if (tile.GetType() == TileType.Bomb)
                {
                    adjacentBombs++;
                }
            }
        }
        return adjacentBombs;
    }

    public void RevealAllTiles()
    {
        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++) 
            {
                Tile tile = _tiles[i, j];
                tile.Reveal();
            }
        }
    }

    public int GetBombs() => _bombs;
    public int GetCorrectFlags() => _correctFlags;
    public void IncrementCorrectFlags() => ++_correctFlags;
    public void DecrementCorrectFlags() => --_correctFlags;

}