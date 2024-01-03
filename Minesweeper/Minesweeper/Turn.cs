namespace Minesweeper
{
    public class Turn
    {
        private Board _board;
        private bool _isOver;

        public Turn(Board board)
        {
            _board = board;
            _isOver = false;
        }

        public void Play()
        {
            while (!_isOver)
            {
                BoardPrinter.Show(_board);
                SelectPlay();
            }
        }

        public void SelectPlay()
        {
            PlayType play = UserInput.GetPlay();
            switch (play)
            {
                case PlayType.Reveal:
                    Reveal.Execute(_board);
                    _isOver = GameOverChecker.CheckIfLost(_board) || GameOverChecker.CheckIfWon(_board);
                    break;
                case PlayType.Flag:
                    Flag.Execute(_board);
                    _isOver = GameOverChecker.CheckIfWon(_board);
                    break;
                case PlayType.Unflag:
                    Flag.Unflag(_board);
                    break;
                case PlayType.EndGame:
                    EndTurn();
                    break;
                default:
                    break;
            }
        }

        public void EndTurn()
        {
            _isOver = true;
        }

        public bool IsOver() => _isOver;
    }
}