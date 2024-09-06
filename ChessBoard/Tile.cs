using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Chess_Game
{
    public class Tile
    {
        public Button TileButton { get; private set; }
        public int Row { get; private set; }
        public int Col { get; private set; }
        public ChessPiece Piece { get; set; }
        private static ChessPiece selectedPiece = null;
        private static Tile selectedTile = null;
        private ChessBoard chessBoard;
        private List<Tile> highlightedTiles = new List<Tile>();

        public Tile(int row, int col, int tileSize, ChessPiece piece = null, ChessBoard board = null)
        {
            Row = row;
            Col = col;
            Piece = piece;
            chessBoard = board;

            TileButton = new Button
            {
                Size = new Size(tileSize, tileSize),
                Location = new Point(col * tileSize, row * tileSize),
                BackColor = (row + col) % 2 == 0 ? Color.FromArgb(235, 236, 208) : Color.FromArgb(119, 149, 86),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };

            if (piece != null)
            {
                TileButton.Image = piece.PieceImage;
                TileButton.BackgroundImageLayout = ImageLayout.Stretch;
            }

            TileButton.Click += Tile_Click;
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            if (Piece != null && selectedPiece == null && chessBoard.IsValidTurn(Piece))
            {
                SelectPiece();
                HighlightCaptureMoves();
            }
            else if (selectedPiece != null)
            {
                if (TryMove())
                {
                    chessBoard.SwitchTurn();
                }
                ResetSelection();
            }
        }

        private void SelectPiece()
        {
            selectedPiece = Piece;
            selectedTile = this;
            TileButton.BackColor = TileButton.BackColor == Color.FromArgb(235, 236, 208)
                ? Color.FromArgb(245, 246, 130)
                : Color.FromArgb(185, 202, 67);
        }

        private void HighlightCaptureMoves()
        {
            ResetHighlights();
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Tile targetTile = chessBoard.Tiles[row, col];
                    if (targetTile.Piece != null && targetTile.Piece.Color != selectedPiece.Color &&
                        selectedPiece.IsValidMove(Row, Col, row, col, chessBoard.Tiles))
                    {
                        targetTile.TileButton.BackColor = Color.Red;
                        highlightedTiles.Add(targetTile);
                    }
                }
            }
        }

        private void ResetHighlights()
        {
            foreach (var tile in highlightedTiles)
            {
                tile.ResetTileColor();
            }
            highlightedTiles.Clear();
        }

        private void ResetTileColor()
        {
            TileButton.BackColor = (Row + Col) % 2 == 0
                ? Color.FromArgb(235, 236, 208)
                : Color.FromArgb(119, 149, 86);
        }

        private bool TryMove()
        {
            if (selectedPiece.IsValidMove(selectedTile.Row, selectedTile.Col, Row, Col, chessBoard.Tiles))
            {
                MovePiece(selectedTile, this);
                return true;
            }
            return false;
        }

        private void ResetSelection()
        {
            ResetHighlights();
            selectedTile.ResetTileColor();
            selectedPiece = null;
            selectedTile = null;
        }

        private void MovePiece(Tile fromTile, Tile toTile)
        {
            toTile.Piece = fromTile.Piece;
            toTile.TileButton.Image = fromTile.TileButton.Image;
            fromTile.Piece = null;
            fromTile.TileButton.Image = null;

            
            toTile.ResetTileColor();

            
            PieceColor opponentColor = toTile.Piece.Color == PieceColor.White ? PieceColor.Black : PieceColor.White;
            if (chessBoard.IsKingInCheck(opponentColor))
            {
                if (chessBoard.IsCheckmate(opponentColor))
                {
                    MessageBox.Show($"Checkmate! {toTile.Piece.Color} wins!");
                   
                }
                else
                {
                    MessageBox.Show($"Check! {opponentColor} King is in danger!");
                }
            }
        }


    }
}