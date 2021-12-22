using XadrezConsole.Board.Enums;

namespace XadrezConsole.Board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int NumberMovements { get; protected set; }
        public Chessboard Board { get; protected set; }

        public Piece(Color color, Chessboard board)
        {
            Color = color;
            Board = board;
        }
    }
}
