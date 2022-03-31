using System.Collections.Generic;
using XadrezConsole.board;
using XadrezConsole.board.Enums;
using XadrezConsole.Chess;

namespace XadrezConsole
{
    internal class Screen
    {
        public static void PrintChessMatch(ChessMatch chessMatch)
        {
            PrintBoard(chessMatch.Chessboard);
            Console.WriteLine();

            PrintCapturedPieces(chessMatch);
            Console.WriteLine();

            Console.WriteLine($"\nRound: {chessMatch.Round}");
            Console.WriteLine($"Awaiting move: {chessMatch.CurrentPlayer}");
        }

        public static void PrintCapturedPieces(ChessMatch chessMatch)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;

            Console.WriteLine("Captured Pieces");

            Console.Write("White ");
            Console.ForegroundColor = ConsoleColor.White;
            PrintPiecesSet(chessMatch.CapturedPieces(Color.White));
            Console.ForegroundColor = defaultColor;

            Console.Write("\nBlack ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintPiecesSet(chessMatch.CapturedPieces(Color.Black));
            Console.ForegroundColor = defaultColor;
        }

        public static void PrintPiecesSet(HashSet<Piece> pieces)
        {
            Console.Write("[");

            foreach (Piece piece in pieces)
                Console.Write(piece + " ");

            Console.Write("]");
        }

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
