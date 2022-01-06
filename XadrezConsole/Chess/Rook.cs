using XadrezConsole.board;
using XadrezConsole.board.Enums;

namespace XadrezConsole.Chess
{
    internal class Rook : Piece
    {
        public Rook(Color color, Board board) : base(color, board)
        {
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[Board.Rows, Board.Columns];

            var position = new Position(0, 0);

            position.SetPosition(Position.Row + 1, Position.Column);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;

                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color)
                    break;

                position.Row++;
            }

            position.SetPosition(Position.Row - 1, Position.Column);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;

                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color)
                    break;

                position.Row--;
            }

            position.SetPosition(Position.Row, Position.Column + 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;

                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color)
                    break;

                position.Column++;
            }

            position.SetPosition(Position.Row, Position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Row, position.Column] = true;

                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color)
                    break;

                position.Column--;
            }

            return possibleMoves;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
