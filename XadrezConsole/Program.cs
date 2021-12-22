using XadrezConsole.Board;

namespace XadrezConsole
{
    class Program
    { 
        static void Main(string[] args)
        {
            var board = new Chessboard(8,8);

            Screen.PrintBoard(board);

            Console.ReadLine();
        }
    }
}