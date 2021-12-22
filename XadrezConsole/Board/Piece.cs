using XadrezConsole.Board.Enums;

namespace XadrezConsole.Board
{
    internal class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int NumberMovements { get; protected set; }
        public Chessboard Board { get; protected set; }

        public Piece(Position position, Color color, Chessboard board)
        {
            Position = position;
            Color = color;
            Board = board;
        }
    }
}
