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
                var chessMatch = new ChessMatch();

                while (!chessMatch.MatchFinished)
                {
                    try
                    {
                        Console.Clear();

                        Screen.PrintChessMatch(chessMatch);

                        Console.Write("\nOrigin: ");
                        var origin = Screen.ReadChessPosition().ToPosition();
                        chessMatch.ValidOriginPosition(origin);

                        Console.Clear();

                        bool[,] possibleMoves = chessMatch.Chessboard.GetPiece(origin).PossibleMoves();
                        Screen.PrintBoard(chessMatch.Chessboard, possibleMoves);

                        Console.Write("\nDestination: ");
                        var destination = Screen.ReadChessPosition().ToPosition();
                        chessMatch.ValidDestination(origin, destination);
                        
                        chessMatch.PerformMatch(origin, destination);
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

                Console.Clear();
                Screen.PrintChessMatch(chessMatch);
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