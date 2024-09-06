using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Game.Pieces
{
    public class Bishop : ChessPiece
    {
        public Bishop(string color, string imagePath) : base($"{color} Bishop", imagePath) { }

        public override bool CanMove(int startRow, int startCol, int targetRow, int targetCol, Tile[,] board)
        {
            if (Math.Abs(startRow - targetRow) == Math.Abs(startCol - targetCol))
            {
                return IsPathClear(startRow, startCol, targetRow, targetCol, board);
            }
            return false;
        }
    }
}
