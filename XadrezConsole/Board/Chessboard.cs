using XadrezConsole.Board.Exceptions;

namespace XadrezConsole.Board
{
    internal class Chessboard
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        public Piece[,] Pieces { get; private set; }

        public Chessboard(int rows, int columns)
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

        #region Exceptions

        bool HasPiece(Position position)
        {
            ValidatePosition(position);
            return GetPiece(position) != null;
        }

        bool ValidPosition(Position position)
        {
            return position.Row < 0 || position.Row >= Rows || position.Column < 0 || position.Column >= Columns;
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
