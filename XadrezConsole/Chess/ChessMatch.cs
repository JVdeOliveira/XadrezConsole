using System.Collections.Generic;
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
        public bool Check { get; private set; }

        HashSet<Piece> _pieces;
        HashSet<Piece> _capturedPieces;

        public ChessMatch()
        {
            Chessboard = new Board(8, 8);
            CurrentPlayer = Color.White;
            Round = 1;
            
            _pieces = new HashSet<Piece>();
            _capturedPieces = new HashSet<Piece>();

            PutPieces();
        }

        Piece Movement(Position origin, Position destination)
        {
            Piece piece = Chessboard.RemovePiece(origin);
            piece.IncrementMovement();

            Piece capturedPiece = Chessboard.RemovePiece(destination);

            if (capturedPiece != null)
                _capturedPieces.Add(capturedPiece);

            Chessboard.PlacePiece(piece, destination);

            return capturedPiece;
        }

        void UndoMove(Position origin, Position destination, Piece capturedPiece)
        {
            Piece piece = Chessboard.RemovePiece(destination);
            piece.DecrementMovement();

            Chessboard.PlacePiece(piece, origin);

            if (capturedPiece != null)
            {
                _capturedPieces.Remove(capturedPiece);
                Chessboard.PlacePiece(capturedPiece, destination);
            }
        }

        public void PerformMatch(Position origin, Position destination)
        {
            Piece capturedPiece = Movement(origin, destination);

            if (IsCheck(CurrentPlayer))
            {
                UndoMove(origin, destination, capturedPiece);

                throw new BoardException("You can't put yourself in check");
            }

            Check = IsCheck(AdversaryColor(CurrentPlayer));

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

        public HashSet<Piece> CapturedPieces(Color playerColor)
        {
            HashSet<Piece> aux = new HashSet<Piece>();

            foreach(Piece piece in _capturedPieces)
            {
                if (piece.Color == playerColor)
                    aux.Add(piece);
            }

            return aux;
        }

        public HashSet<Piece> PiecesInMatch(Color playerColor)
        {
            HashSet<Piece> aux = new HashSet<Piece>();

            foreach (Piece piece in _pieces)
            {
                if (piece.Color == playerColor)
                    aux.Add(piece);
            }

            aux.ExceptWith(CapturedPieces(playerColor));

            return aux;
        }
        
        Color AdversaryColor(Color color)
        {
            return color == Color.White ? Color.Black: Color.White;
        }

        Piece GetKing(Color color)
        {
            foreach (Piece piece in PiecesInMatch(color))
            {
                if (piece is King)
                    return piece;
            }

            throw new BoardException($"There is no {color} king on the board");
        }

        public bool IsCheck(Color color)
        {
            Piece king = GetKing(color);

            foreach (Piece piece in PiecesInMatch(AdversaryColor(color)))
            {
                bool[,] posibleMoves = piece.PossibleMoves(); 

                if (posibleMoves[king.Position.Row, king.Position.Column])
                    return true;
            }

            return false;
        }

        void PutNewPiece(int row, int column, Piece piece)
        {
            Chessboard.PlacePiece(piece, new Position(row, column));
            _pieces.Add(piece);
        }

        void PutPieces()
        {
            PutNewPiece(0, 0, new Rook(Color.Black, Chessboard));
            PutNewPiece(0, 7, new Rook(Color.Black, Chessboard));

            PutNewPiece(0, 1, new Knight(Color.Black, Chessboard));
            PutNewPiece(0, 6, new Knight(Color.Black, Chessboard));

            PutNewPiece(0, 2, new Bishop(Color.Black, Chessboard));
            PutNewPiece(0, 5, new Bishop(Color.Black, Chessboard));

            PutNewPiece(0, 3, new King(Color.Black, Chessboard));
            PutNewPiece(0, 4, new Queen(Color.Black, Chessboard));

            for (int i = 0; i < Chessboard.Columns; i++)
            {
                PutNewPiece(1, i, new Pawn(Color.Black, Chessboard));
            }

            PutNewPiece(7, 0, new Rook(Color.White, Chessboard));
            PutNewPiece(7, 7, new Rook(Color.White, Chessboard));

            PutNewPiece(7, 1, new Knight(Color.White, Chessboard));
            PutNewPiece(7, 6, new Knight(Color.White, Chessboard));

            PutNewPiece(7, 2, new Bishop(Color.White, Chessboard));
            PutNewPiece(7, 5, new Bishop(Color.White, Chessboard));

            PutNewPiece(7, 3, new King(Color.White, Chessboard));
            PutNewPiece(7, 4, new Queen(Color.White, Chessboard));

            for (int i = 0; i < Chessboard.Columns; i++)
            {
                PutNewPiece(6, i, new Pawn(Color.White, Chessboard));
            }
        }
    }
}