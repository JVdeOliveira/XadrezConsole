using XadrezConsole.board;
using XadrezConsole.board.Enums;
using XadrezConsole.board.Exceptions;

namespace XadrezConsole.Chess
{
    internal class ChessMatch
    {
        public Board Chessboard { get; private set; }
        public bool MatchFinished { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public int Round { get; private set; }
        

        public ChessMatch()
        {
            Chessboard = new Board(8, 8);
            CurrentPlayer = Color.White;
            Round = 1;

            PutPieces();
        }

        void Movement(Position origin, Position destination)
        {
            Piece piece = Chessboard.RemovePiece(origin);
            piece.IncrementMovement();

            Piece capturedPiece = Chessboard.RemovePiece(destination);

            Chessboard.PlacePiece(piece, destination);
        }

        public void PerformMatch(Position origin, Position destination)
        {
            Movement(origin, destination);

            Round++;
            ChangePlayer();
        }

        public void ValidOriginPosition(Position origin)
        {
            Piece piece = Chessboard.GetPiece(origin);

            if (piece == null)
                throw new BoardException("There is no chess piece in the chosen origin position");
            if (CurrentPlayer != piece.Color)
                throw new BoardException("The original chess piece is not yours");
            if (!piece.ExistPossibleMoves())
                throw new BoardException("There are no possible moves for the chosen origin chess piece");
        }
        
        public void ValidDestination(Position origin, Position destination)
        {
            Piece piece = Chessboard.GetPiece(origin);

            if (!piece.CanMoveTo(destination))
                throw new BoardException("Invalid destinarion position");
        }

        void ChangePlayer()
        {
            CurrentPlayer = CurrentPlayer == Color.White ? Color.Black : Color.White;
        }

        void PutPieces()
        {
            Chessboard.PlacePiece(new Rook(Color.Black, Chessboard), new Position(0, 0));
            Chessboard.PlacePiece(new Rook(Color.Black, Chessboard), new Position(0, 7));

            Chessboard.PlacePiece(new Knight(Color.Black, Chessboard), new Position(0, 1));
            Chessboard.PlacePiece(new Knight(Color.Black, Chessboard), new Position(0, 6));

            Chessboard.PlacePiece(new Bishop(Color.Black, Chessboard), new Position(0, 2));
            Chessboard.PlacePiece(new Bishop(Color.Black, Chessboard), new Position(0, 5));

            Chessboard.PlacePiece(new King(Color.Black, Chessboard), new Position(0, 3));
            Chessboard.PlacePiece(new Queen(Color.Black, Chessboard), new Position(0, 4));

            for (int i = 0; i < Chessboard.Columns; i++)
            {
                Chessboard.PlacePiece(new Pawn(Color.Black, Chessboard), new Position(1, i));
            }

            Chessboard.PlacePiece(new Rook(Color.White, Chessboard), new Position(7, 0));
            Chessboard.PlacePiece(new Rook(Color.White, Chessboard), new Position(7, 7));

            Chessboard.PlacePiece(new Knight(Color.White, Chessboard), new Position(7, 1));
            Chessboard.PlacePiece(new Knight(Color.White, Chessboard), new Position(7, 6));

            Chessboard.PlacePiece(new Bishop(Color.White, Chessboard), new Position(7, 2));
            Chessboard.PlacePiece(new Bishop(Color.White, Chessboard), new Position(7, 5));

            Chessboard.PlacePiece(new King(Color.White, Chessboard), new Position(7, 3));
            Chessboard.PlacePiece(new Queen(Color.White, Chessboard), new Position(7, 4));

            for (int i = 0; i < Chessboard.Columns; i++)
            {
                Chessboard.PlacePiece(new Pawn(Color.White, Chessboard), new Position(6, i));
            }
        }
    }
}