using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chess_Game.Pieces
{
    public class Pawn : ChessPiece
    {
        public Pawn(string color, string imagePath) : base($"{color} Pawn", imagePath) { }

        public override bool CanMove(int startRow, int startCol, int targetRow, int targetCol, Tile[,] board)
        {
            int direction = Color == PieceColor.White ? -1 : 1;

            // Normal forward move
            if (startCol == targetCol && board[targetRow, targetCol].Piece == null)
            {
                if (targetRow == startRow + direction)
                {
                    return true; // Single step forward
                }
                if ((startRow == 1 && direction == 1 || startRow == 6 && direction == -1) &&
                    targetRow == startRow + 2 * direction &&
                    board[startRow + direction, startCol].Piece == null)
                {
                    return true; // Double step on first move
                }
            }

            // Diagonal capture
            if (Math.Abs(startCol - targetCol) == 1 && targetRow == startRow + direction)
            {
                if (board[targetRow, targetCol].Piece != null &&
                    board[targetRow, targetCol].Piece.Color != this.Color)
                {
                    return true;
                }
            }

            return false;
        }
    }
}