namespace Minesweeper;

public class GameStarter
{
    private readonly int _width = 15;
    private readonly int _height = 15;
    private readonly int _bombs = 20;
    private bool _isOver = false;
    private Board _board;
    
    public void Start()
    {
        CreateBoard();
        Turn turn = new Turn(_board);
        turn.Play();
        EndGame();
    }
    public void CreateBoard()
    {
        _board = BoardFactory.CreateBoard(_width, _height, _bombs);
        _board.FillWithBombs();
        _board.FillWithNumbers();
    }

    private void EndGame()
    {
        _isOver = true;
        _board.RevealAllTiles();
        BoardPrinter.Show(_board);
        Console.WriteLine("Game Over!");
    }
    public bool IsOver() => _isOver;
    public int GetWidth() => _width;
    public int GetHeight() => _height;
    public Board GetBoard() => _board;
}