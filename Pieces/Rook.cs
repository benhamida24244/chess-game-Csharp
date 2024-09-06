using System;

namespace Chess_Game.Pieces
{
    public class Rook : ChessPiece
    {
        public Rook(string color, string imagePath) : base($"{color} Rook", imagePath) { }

        public override bool CanMove(int startRow, int startCol, int targetRow, int targetCol, Tile[,] board)
        {
        
            if (startRow == targetRow || startCol == targetCol)
            {
               
                return IsPathClear(startRow, startCol, targetRow, targetCol, board);
            }
            return false;
        }
    }
}