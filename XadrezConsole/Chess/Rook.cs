using XadrezConsole.Board;
using XadrezConsole.Board.Enums;

namespace XadrezConsole.Chess
{
    internal class Rook : Piece
    {
        public Rook(Color color, Chessboard board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
