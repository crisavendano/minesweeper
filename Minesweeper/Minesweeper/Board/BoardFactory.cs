namespace Minesweeper;

public class BoardFactory
{
    public static Board CreateBoard(int width, int height, int bombs)
    {
        Board board = new Board(width, height, bombs);
        return board;
    }
}