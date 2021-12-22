using XadrezConsole.Board;

namespace XadrezConsole
{
    internal class Screen
    {
        public static void PrintBoard(Chessboard board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {

                    if (board.Pieces[i, j] != null)
                        Console.Write($"{board.Pieces[i, j]} ");
                    else 
                        Console.Write("- ");
                }

                Console.WriteLine();
            }
        }
    }
}
