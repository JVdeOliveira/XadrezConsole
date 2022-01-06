using XadrezConsole.board;
using XadrezConsole.board.Exceptions;
using XadrezConsole.Chess;

namespace XadrezConsole
{
    class Program
    { 
        static void Main(string[] args)
        {
            try
            {
                var chessMath = new ChessMatch();

                while (!chessMath.MatchFinished)
                {
                    Console.Clear();

                    Screen.PrintBoard(chessMath.Chessboard);

                    Console.WriteLine();

                    Console.Write("Origem: ");
                    var origin = Screen.ReadChessPosition().ToPosition();

                    Console.Clear();

                    bool[,] possibleMoves = chessMath.Chessboard.GetPiece(origin).PossibleMoves();
                    Screen.PrintBoard(chessMath.Chessboard, possibleMoves);

                    Console.WriteLine();

                    Console.Write("Destino: ");
                    var destination = Screen.ReadChessPosition().ToPosition();

                    chessMath.Movement(origin, destination);
                }
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