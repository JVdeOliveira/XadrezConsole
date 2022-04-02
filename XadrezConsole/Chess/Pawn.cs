using XadrezConsole.board;
using XadrezConsole.board.Enums;

namespace XadrezConsole.Chess
{
    internal class Pawn : Piece
    {
        public Pawn(Color color, Board board) : base(color, board)
        {
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[Board.Rows, Board.Columns];
            Position position;

            if (Color == Color.Black)
            {
                for (int i = 1; i <= 2; i++)
                {
                    position = new Position(Position.Row + i, Position.Column);

                    if (Board.ValidPosition(position) && CanMove(position) && Board.GetPiece(position) == null)
                        possibleMoves[position.Row, position.Column] = true;
                }

                position = new Position(Position.Row + 1, Position.Column + 1);
                if (Board.ValidPosition(position) && CanMove(position) && Board.GetPiece(position) != null)
                    possibleMoves[position.Row, position.Column] = true;

                position = new Position(Position.Row + 1, Position.Column - 1);
                if (Board.ValidPosition(position) && CanMove(position) && Board.GetPiece(position) != null)
                    possibleMoves[position.Row, position.Column] = true;
            }
            else
            {
                for (int i = 2; i >= 0; i--)
                {
                    position = new Position(Position.Row - i, Position.Column);

                    if (Board.ValidPosition(position) && CanMove(position) && Board.GetPiece(position) == null)
                        possibleMoves[position.Row, position.Column] = true;
                }

                position = new Position(Position.Row - 1, Position.Column + 1);
                if (Board.ValidPosition(position) && CanMove(position) && Board.GetPiece(position) != null)
                    possibleMoves[position.Row, position.Column] = true;

                position = new Position(Position.Row - 1, Position.Column - 1);
                if (Board.ValidPosition(position) && CanMove(position) && Board.GetPiece(position) != null)
                    possibleMoves[position.Row, position.Column] = true;
            }

            return possibleMoves;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
