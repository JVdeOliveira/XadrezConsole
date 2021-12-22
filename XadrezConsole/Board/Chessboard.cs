namespace XadrezConsole.Board
{
    internal class Chessboard
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        public Piece[,] Pieces { get; private set; }

        public Chessboard(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Pieces = new Piece[Rows, Columns];
        }
    }
}
