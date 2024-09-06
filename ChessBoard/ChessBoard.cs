using System;
using System.Windows.Forms;
using Chess_Game.Pieces;

namespace Chess_Game
{
    public class ChessBoard
    {
        public Tile[,] Tiles { get; private set; }
        private int boardSize = 8;
        private int tileSize = 64;
        public PlayerTurn CurrentTurn { get; private set; }

        public ChessBoard(Form parentForm)
        {
            Tiles = new Tile[boardSize, boardSize];
            CreateBoard(parentForm);
            InitializeRandomTurn();
        }

        private void CreateBoard(Form parentForm)
        {
            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    ChessPiece piece = CreatePiece(row, col);
                    Tile tile = new Tile(row, col, tileSize, piece, this);
                    parentForm.Controls.Add(tile.TileButton);
                    Tiles[row, col] = tile;
                }
            }
        }

        private ChessPiece CreatePiece(int row, int col)
        {
            string colorPrefix = (row < 2) ? "Sotet" : "Vilagos";
            if (row == 1 || row == 6)
                return new Pawn($"{colorPrefix}Paraszt", $"Kepek\\{colorPrefix}Paraszt.png");
            if (row == 0 || row == 7)
            {
                switch (col)
                {
                    case 0:
                    case 7:
                        return new Rook($"{colorPrefix}Bastya", $"Kepek\\{colorPrefix}Bastya.png");
                    case 1:
                    case 6:
                        return new Knight($"{colorPrefix}Huszar", $"Kepek\\{colorPrefix}Huszar.png");
                    case 2:
                    case 5:
                        return new Bishop($"{colorPrefix}Futo", $"Kepek\\{colorPrefix}Futo.png");
                    case 3:
                        return new Queen($"{colorPrefix}Kiralyno", $"Kepek\\{colorPrefix}Kiralyno.png");
                    case 4:
                        return new King($"{colorPrefix}Kiraly", $"Kepek\\{colorPrefix}Kiraly.png");
                }
            }
            return null;
        }

        private void InitializeRandomTurn()
        {
            Random random = new Random();
            CurrentTurn = random.Next(2) == 0 ? PlayerTurn.White : PlayerTurn.Black;
            Console.WriteLine($"Initial turn: {CurrentTurn}");
        }

        public void SwitchTurn()
        {
            CurrentTurn = CurrentTurn == PlayerTurn.White ? PlayerTurn.Black : PlayerTurn.White;
            Console.WriteLine($"Turn switched to: {CurrentTurn}");
        }

        public bool IsValidTurn(ChessPiece piece)
        {
            return (CurrentTurn == PlayerTurn.White && piece.Color == PieceColor.White) ||
                   (CurrentTurn == PlayerTurn.Black && piece.Color == PieceColor.Black);
        }

        public bool IsKingInCheck(PieceColor kingColor)
        {
           
            Tile kingTile = FindKing(kingColor);
            if (kingTile == null) return false;

          
            PieceColor opponentColor = kingColor == PieceColor.White ? PieceColor.Black : PieceColor.White;
            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    ChessPiece piece = Tiles[row, col].Piece;
                    if (piece != null && piece.Color == opponentColor)
                    {
                        if (piece.IsValidMove(row, col, kingTile.Row, kingTile.Col, Tiles))
                        {
                            return true; 
                        }
                    }
                }
            }

            return false; // الملك ليس في وضع الكش
        }

        private Tile FindKing(PieceColor color)
        {
            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    ChessPiece piece = Tiles[row, col].Piece;
                    if (piece is King && piece.Color == color)
                    {
                        return Tiles[row, col];
                    }
                }
            }
            return null;
        }

        public bool IsCheckmate(PieceColor kingColor)
        {
            if (!IsKingInCheck(kingColor))
            {
                return false; 
            }

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    ChessPiece piece = Tiles[row, col].Piece;
                    if (piece != null && piece.Color == kingColor)
                    {
                        if (CanPieceMoveToPreventCheck(piece, row, col))
                        {
                            return false; 
                        }
                    }
                }
            }

            return true; 
        }

        private bool CanPieceMoveToPreventCheck(ChessPiece piece, int startRow, int startCol)
        {
            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    if (piece.IsValidMove(startRow, startCol, row, col, Tiles))
                    {
                        
                        ChessPiece originalTargetPiece = Tiles[row, col].Piece;
                        Tiles[row, col].Piece = piece;
                        Tiles[startRow, startCol].Piece = null;

                        bool kingStillInCheck = IsKingInCheck(piece.Color);

                        
                        Tiles[startRow, startCol].Piece = piece;
                        Tiles[row, col].Piece = originalTargetPiece;

                        if (!kingStillInCheck)
                        {
                            return true;
                        }
                    }
                }
            }
            return false; 
        }

    }
}