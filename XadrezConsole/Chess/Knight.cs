using XadrezConsole.Board;
using XadrezConsole.Board.Enums;

namespace XadrezConsole.Chess
{
    internal class Knight : Piece
    {
        public Knight(Color color, Chessboard board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
