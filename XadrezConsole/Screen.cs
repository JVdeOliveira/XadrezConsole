using XadrezConsole.board;
using XadrezConsole.Chess;

namespace XadrezConsole
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < board.Columns; j++)
                {
                    WritePiece(board.Pieces[i, j]);
                }

                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void PrintBoard(Board board, bool[,] possibleMoves)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            ConsoleColor newColor = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < board.Columns; j++)
                {
                    if (possibleMoves[i, j]) Console.BackgroundColor = newColor;

                    WritePiece(board.Pieces[i, j]);
                    
                    Console.BackgroundColor = defaultColor;
                }

                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        static void WritePiece(Piece piece)
        {
            if (piece != null)
            {
                switch (piece.Color)
                {
                    case board.Enums.Color.Black:
                        var defaultColor = Console.ForegroundColor;

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(piece);
                        Console.ForegroundColor = defaultColor;
                        break;
                    default:
                        Console.Write(piece);
                        break;
                }

                Console.Write(" ");
            }
            else
                Console.Write("- ");
        }

        public static ChessPosition ReadChessPosition()
        {
            string position = Console.ReadLine();

            char column = position[0];
            int row = int.Parse(position[1] + "");

            return new ChessPosition(column, row);
        }
    }
}
