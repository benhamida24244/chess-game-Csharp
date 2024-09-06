using System;
using System.Windows.Forms;

namespace Chess_Game
{
    public partial class shess : Form
    {
        private ChessBoard chessBoard;

        public shess()
        {

            InitializeComponent();
            chessBoard = new ChessBoard(this);
        }

    }
}
