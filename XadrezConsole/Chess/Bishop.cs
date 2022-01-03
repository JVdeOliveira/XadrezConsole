using XadrezConsole.Board;
using XadrezConsole.Board.Enums;

namespace XadrezConsole.Chess
{
    internal class Bishop : Piece
    {
        public Bishop(Color color, Chessboard board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
