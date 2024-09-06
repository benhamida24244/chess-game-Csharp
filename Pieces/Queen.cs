using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chess_Game.Pieces
{
    public class Queen : ChessPiece
    {
        public Queen(string color, string imagePath) : base($"{color} Queen", imagePath) { }

        public override bool CanMove(int startRow, int startCol, int targetRow, int targetCol, Tile[,] board)
        {
         
            if (startRow == targetRow || startCol == targetCol ||
                Math.Abs(startRow - targetRow) == Math.Abs(startCol - targetCol))
            {
                return IsPathClear(startRow, startCol, targetRow, targetCol, board);
            }

            return false;
        }
    }
}
