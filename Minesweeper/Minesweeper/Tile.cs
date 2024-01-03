namespace Minesweeper;

public class Tile
{
    private TileType _type = TileType.Empty;
    private int _adjacentBombs;
    private string _symbol;
    private bool _isRevealed;
    
    public void SetType(TileType type)
    {
        _type = type;
        SetSymbol();
    }
    public new TileType GetType() => _type;
    public void SetSymbol()
    {
        _symbol = _type switch
        {
            TileType.Flag => "F",
            TileType.FlaggedBomb => "F",
            TileType.Empty => $"{_adjacentBombs}",
            TileType.Bomb => "B",
            _ => _symbol
        };
    }
    public string GetSymbol() => _symbol;
    public void SetAdjacentBombs(int bombs) => _adjacentBombs = bombs;
    public void IncrementAdjacentBombs() => _adjacentBombs++;
    public int GetAdjacentBombs() => _adjacentBombs;
    public bool IsRevealed() => _isRevealed;
    public void Reveal()
    {
        _isRevealed = true;
    }
    public void Unreveal()
    {
        _isRevealed = false;
    }

    public string GetContent()
    {
        return _isRevealed ? _symbol : " ";
    }
    public void Flag()
    {
        switch (_type)
        {
            case TileType.Empty:
                _type = TileType.Flag;
                SetSymbol();
                break;
            case TileType.Bomb:
                _type = TileType.FlaggedBomb;
                SetSymbol();
                break;
            case TileType.Flag:
                break;
            case TileType.FlaggedBomb:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    public bool IsFlagged()
    {
        return _type is TileType.Flag or TileType.FlaggedBomb;
    }
}