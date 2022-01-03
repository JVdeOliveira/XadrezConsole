using XadrezConsole.Board;
using XadrezConsole.Board.Enums;

namespace XadrezConsole.Chess
{
    internal class Queen : Piece
    {
        public Queen(Color color, Chessboard board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "Q";
        }
    }
}
