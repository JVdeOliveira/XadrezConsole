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
                    try
                    {
                        Console.Clear();

                        Screen.PrintBoard(chessMath.Chessboard);

                        Console.WriteLine($"\nRound: {chessMath.Round}");
                        Console.WriteLine($"Awaiting move: {chessMath.CurrentPlayer}");

                        Console.Write("\nOrigem: ");
                        var origin = Screen.ReadChessPosition().ToPosition();
                        chessMath.ValidOriginPosition(origin);

                        Console.Clear();

                        bool[,] possibleMoves = chessMath.Chessboard.GetPiece(origin).PossibleMoves();
                        Screen.PrintBoard(chessMath.Chessboard, possibleMoves);

                        Console.Write("\nDestino: ");
                        var destination = Screen.ReadChessPosition().ToPosition();
                        chessMath.ValidDestination(origin, destination);
                        
                        chessMath.PerformMatch(origin, destination);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine($"Board Error: {e.Message}");
                        Console.ReadLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Unexpected Error: {e.Message}");
                        Console.ReadLine();
                    }
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