﻿using XadrezConsole.board;
using XadrezConsole.board.Enums;

namespace XadrezConsole.Chess
{
    internal class Bishop : Piece
    {
        public Bishop(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
