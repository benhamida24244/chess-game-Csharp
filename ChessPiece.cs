using System;
using System.Drawing;

namespace Chess_Game
{
    public abstract class ChessPiece
    {
        public string Name { get; private set; }
        public Image PieceImage { get; private set; }
        public PieceColor Color { get; private set; }

        public ChessPiece(string name, string imagePath)
        {
            Name = name;
            PieceImage = Image.FromFile(imagePath);
            Color = name.StartsWith("Vilagos") ? PieceColor.White : PieceColor.Black;
        }

        public abstract bool CanMove(int startRow, int startCol, int targetRow, int targetCol, Tile[,] board);

        public bool IsValidMove(int startRow, int startCol, int targetRow, int targetCol, Tile[,] board)
        {
            if (targetRow < 0 || targetRow >= 8 || targetCol < 0 || targetCol >= 8)
                return false;

            if (board[targetRow, targetCol].Piece != null && board[targetRow, targetCol].Piece.Color == this.Color)
                return false;

            return CanMove(startRow, startCol, targetRow, targetCol, board);
        }

        protected bool IsPathClear(int startRow, int startCol, int targetRow, int targetCol, Tile[,] board)
        {
            int rowStep = Math.Sign(targetRow - startRow);
            int colStep = Math.Sign(targetCol - startCol);

            int currentRow = startRow + rowStep;
            int currentCol = startCol + colStep;

            while (currentRow != targetRow || currentCol != targetCol)
            {
                if (board[currentRow, currentCol].Piece != null)
                    return false;

                currentRow += rowStep;
                currentCol += colStep;
            }

            return true;
        }
    }
}