using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Game.Pieces
{
    public class Knight : ChessPiece
    {
        public Knight(string color, string imagePath) : base($"{color} Knight", imagePath) { }

        public override bool CanMove(int startRow, int startCol, int targetRow, int targetCol, Tile[,] board)
        {
            int rowDiff = Math.Abs(startRow - targetRow);
            int colDiff = Math.Abs(startCol - targetCol);

            return (rowDiff == 2 && colDiff == 1) || (rowDiff == 1 && colDiff == 2);
        }
    }
}
