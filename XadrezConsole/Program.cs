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

                board.PlacePiece(new Rook(Color.Black, board), new Position(0, 0));
                board.PlacePiece(new Rook(Color.Black, board), new Position(1, 3));
                board.PlacePiece(new King(Color.Black, board), new Position(2, 4));

                Screen.PrintBoard(board);

                Console.ReadLine();
            }
            catch (BoardException e)
            {
                Console.WriteLine($"Board Error: {e.Message}");
            }
            
        }
    }
}