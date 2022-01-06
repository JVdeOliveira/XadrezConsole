using XadrezConsole.board;
using XadrezConsole.board.Enums;

namespace XadrezConsole.Chess
{
    internal class King : Piece
    {
        public King(Color color, Board board) : base(color, board)
        {
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[Board.Rows, Board.Columns];

            var position = new Position(0,0);

            position.SetPosition(Position.Row + 1, Position.Column);
            if (Board.ValidPosition(position) && CanMove(position))
                possibleMoves[position.Row, position.Column] = true;

            position.SetPosition(Position.Row - 1, Position.Column);
            if (Board.ValidPosition(position) && CanMove(position))
                possibleMoves[position.Row, position.Column] = true;

            position.SetPosition(Position.Row, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
                possibleMoves[position.Row, position.Column] = true;

            position.SetPosition(Position.Row, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
                possibleMoves[position.Row, position.Column] = true;

            position.SetPosition(Position.Row + 1, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
                possibleMoves[position.Row, position.Column] = true;

            position.SetPosition(Position.Row - 1, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
                possibleMoves[position.Row, position.Column] = true;

            position.SetPosition(Position.Row - 1, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
                possibleMoves[position.Row, position.Column] = true;

            position.SetPosition(Position.Row + 1, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
                possibleMoves[position.Row, position.Column] = true;

            return possibleMoves;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
