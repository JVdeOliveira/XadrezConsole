using XadrezConsole.Board;
using XadrezConsole.Board.Enums;

namespace XadrezConsole.Chess
{
    internal class King : Piece
    {
        public King(Color color, Chessboard board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
