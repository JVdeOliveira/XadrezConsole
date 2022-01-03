using XadrezConsole.Board;
using XadrezConsole.Board.Enums;
using XadrezConsole.Board.Exceptions;
using XadrezConsole.Chess;

namespace XadrezConsole
{
    class Program
    { 
        static void Main(string[] args)
        {
            try
            {
                var board = new Chessboard(8, 8);

                #region Place Pieces
                board.PlacePiece(new Rook(Color.Black, board), new Position(0, 0));
                board.PlacePiece(new Rook(Color.Black, board), new Position(0, 7));

                board.PlacePiece(new Knight(Color.Black, board), new Position(0, 1));
                board.PlacePiece(new Knight(Color.Black, board), new Position(0, 6));

                board.PlacePiece(new Bishop(Color.Black, board), new Position(0, 2));
                board.PlacePiece(new Bishop(Color.Black, board), new Position(0, 5));

                board.PlacePiece(new King(Color.Black, board), new Position(0, 3));
                board.PlacePiece(new Queen(Color.Black, board), new Position(0, 4));

                for (int i = 0; i < board.Columns; i++)
                {
                    board.PlacePiece(new Pawn(Color.Black, board), new Position(1, i));
                }

                board.PlacePiece(new Rook(Color.White, board), new Position(7, 0));
                board.PlacePiece(new Rook(Color.White, board), new Position(7, 7));

                board.PlacePiece(new Knight(Color.White, board), new Position(7, 1));
                board.PlacePiece(new Knight(Color.White, board), new Position(7, 6));

                board.PlacePiece(new Bishop(Color.White, board), new Position(7, 2));
                board.PlacePiece(new Bishop(Color.White, board), new Position(7, 5));

                board.PlacePiece(new King(Color.White, board), new Position(7, 3));
                board.PlacePiece(new Queen(Color.White, board), new Position(7, 4));

                for (int i = 0; i < board.Columns; i++)
                {
                    board.PlacePiece(new Pawn(Color.White, board), new Position(6, i));
                }
                #endregion

                Screen.PrintBoard(board);

                Console.ReadLine();
            }
            catch (BoardException e)
            {
                Console.WriteLine($"Board Error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected Error: {e.Message}");
            }
            
        }
    }
}