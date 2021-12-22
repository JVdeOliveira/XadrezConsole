using XadrezConsole.Board;

namespace XadrezConsole.Chess
{
    internal class ChessPosition
    {
        public char Colunm { get; set; }
        public int Row { get; set; }

        public ChessPosition(char colunm, int row)
        {
            Colunm = colunm;
            Row = row;
        }

        public override string ToString()
        {
            return $"{Colunm}{Row}";
        }

        public Position ToPosition()
        {
            return new Position(8 - Row, Colunm - 'a');
        }
    }
}
