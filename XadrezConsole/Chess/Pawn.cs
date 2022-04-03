using XadrezConsole.board;
using XadrezConsole.board.Enums;

namespace XadrezConsole.Chess
{
    internal class Pawn : Piece
    {
        public Pawn(Color color, Board board) : base(color, board)
        {
        }

        bool EnemyExist(Position position)
        {
            Piece piece = Board.GetPiece(position);

            return piece != null && piece.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[Board.Rows, Board.Columns];
            Position position;

            if (Color == Color.Black)
            {
                position = new Position(Position.Row + 1, Position.Column);
                if (Board.ValidPosition(position) && CanMove(position) && !EnemyExist(position))
                    possibleMoves[position.Row, position.Column] = true;

                position = new Position(Position.Row + 2, Position.Column);
                if (Board.ValidPosition(position) && CanMove(position) && !EnemyExist(position) && NumberMovements == 0)
                    possibleMoves[position.Row, position.Column] = true;

                position = new Position(Position.Row + 1, Position.Column + 1);
                if (Board.ValidPosition(position) && CanMove(position) && EnemyExist(position))
                    possibleMoves[position.Row, position.Column] = true;

                position = new Position(Position.Row + 1, Position.Column - 1);
                if (Board.ValidPosition(position) && CanMove(position) && EnemyExist(position))
                    possibleMoves[position.Row, position.Column] = true;
            }
            else
            {
                position = new Position(Position.Row - 1, Position.Column);
                if (Board.ValidPosition(position) && CanMove(position) && !EnemyExist(position))
                    possibleMoves[position.Row, position.Column] = true;

                position = new Position(Position.Row - 2, Position.Column);
                if (Board.ValidPosition(position) && CanMove(position) && !EnemyExist(position) && NumberMovements == 0)
                    possibleMoves[position.Row, position.Column] = true;

                position = new Position(Position.Row - 1, Position.Column + 1);
                if (Board.ValidPosition(position) && CanMove(position) && EnemyExist(position))
                    possibleMoves[position.Row, position.Column] = true;

                position = new Position(Position.Row - 1, Position.Column - 1);
                if (Board.ValidPosition(position) && CanMove(position) && EnemyExist(position))
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
