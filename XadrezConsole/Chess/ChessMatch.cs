using XadrezConsole.board;
using XadrezConsole.board.Enums;

namespace XadrezConsole.Chess
{
    internal class ChessMatch
    {
        public Board Chessboard { get; set; }
        public bool MatchFinished { get; private set; }

        int round;
        Color currentPlayer;

        public ChessMatch()
        {
            Chessboard = new Board(8, 8);
            currentPlayer = Color.White;
            round = 1;

            PutPieces();
        }

        public void Movement(Position origin, Position destination)
        {
            Piece piece = Chessboard.RemovePiece(origin);
            piece.IncrementMovement();

            Piece capturedPiece = Chessboard.RemovePiece(destination);

            Chessboard.PlacePiece(piece, destination);
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