using XadrezConsole.board.Exceptions;

namespace XadrezConsole.board
{
    internal class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        public Piece[,] Pieces { get; private set; }

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Pieces = new Piece[Rows, Columns];
        }

        public Piece GetPiece(Position position)
        {
            return Pieces[position.Row, position.Column];
        }

        public void PlacePiece(Piece piece, Position position)
        {
            if (HasPiece(position)) throw new BoardException("Has piece in position");

            Pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }

        public Piece RemovePiece(Position position)
        {
            if (GetPiece(position) == null) return null;

            Piece piece = GetPiece(position);
           
            piece.Position = null;
            Pieces[position.Row, position.Column] = null;

            return piece;
        }

        #region Exceptions

        bool HasPiece(Position position)
        {
            ValidatePosition(position);
            return GetPiece(position) != null;
        }

        public bool ValidPosition(Position position)
        {
            return position.Row >= 0 && position.Row < Rows && position.Column >= 0 && position.Column < Columns;
        }

        void ValidatePosition(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new BoardException("Invalid position");
            }
        }

        #endregion
    }
}
