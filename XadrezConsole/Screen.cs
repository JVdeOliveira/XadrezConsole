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
                    if (board.Pieces[i, j] != null)
                    {
                        WritePiece(board.Pieces[i, j]);
                        Console.Write(" ");
                    }
                    else 
                        Console.Write("- ");
                }

                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }

        static void WritePiece(Piece piece)
        {
            switch (piece.Color)
            {
                case board.Enums.Color.Black:
                    var aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                    break;
                default:
                    Console.Write(piece);
                    break;
            }
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
