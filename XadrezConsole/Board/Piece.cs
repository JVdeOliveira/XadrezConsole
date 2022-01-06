using XadrezConsole.board.Enums;

namespace XadrezConsole.board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int NumberMovements { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Color color, Board board)
        {
            Color = color;
            Board = board;
        }

        public void IncrementMovement()
        {
            NumberMovements++;
        }

        protected virtual bool CanMove(Position position)
        {
            Piece piece = Board.GetPiece(position);

            return piece == null || piece.Color != Color;
        }

        public bool CanMoveTo(Position position)
        {
            return PossibleMoves()[position.Row, position.Column];
        }

        public bool ExistPossibleMoves()
        {
            foreach (var movement in PossibleMoves())
            {
                if (movement) return true;
            }

            return false;
        }

        public abstract bool[,] PossibleMoves();
    }
}
