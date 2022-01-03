using XadrezConsole.Board;
using XadrezConsole.Board.Enums;

namespace XadrezConsole.Chess
{
    internal class Pawn : Piece
    {
        public Pawn(Color color, Chessboard board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
